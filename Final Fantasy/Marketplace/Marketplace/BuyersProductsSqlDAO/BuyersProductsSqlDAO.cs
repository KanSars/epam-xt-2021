using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Marketplace.Entities;
using Marketplace.DAO.Interfaces;
using NLog;

namespace BuyersProductsSqlDAO
{
    public class Buyers_ProductsSqlDAO : IBuyersProductsDAO
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        BuyersSqlDAO buyersSqlDAO = new BuyersSqlDAO();

        public List<Product> GetProductsOfBuyer(int idBuyer)
        {
            if (idBuyer <= 0)
            {
                throw new FormatException("Invalid parameter format");
            }

            var productsList = new List<Product>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Products.Id, Products.Title FROM Products " +
                    "JOIN Buyers_Products ON Products.Id = Buyers_Products.Id_Product " +
                    "WHERE Buyers_Products.Id_Buyer = @Id_Buyer", connection);

                command.Parameters.AddWithValue("@Id_Buyer", idBuyer);

                connection.Open();

                var reader = command.ExecuteReader();

                if (reader == null)
                {
                    throw new Exception("Cannot get product of buyer");
                }

                while (reader.Read())
                {
                    productsList.Add(new Product(
                        id: (int)reader["Id"],
                        title: (string)reader["Title"]
                        ));
                }
            }

            return productsList;
        }

        public List<ProductInCart> GetProductsInCart(int idBuyer)
        {
            if (idBuyer <= 0)
            {
                throw new FormatException("Invalid parameter format");
            }

            var productsInCartList = new List<ProductInCart>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Products.Id, Products.Title, Max(Counter) as MaxCounter " +
                    "FROM Products JOIN Buyers_Products ON Products.Id = Buyers_Products.Id_Product " +
                    "WHERE(Buyers_Products.Id_Buyer = @Id_Buyer) " +
                    "GROUP BY Products.Id, Products.Title", connection);

                command.Parameters.AddWithValue("@Id_Buyer", idBuyer);

                connection.Open();

                var reader = command.ExecuteReader();

                if (reader == null)
                {
                    throw new Exception("Cannot get product of buyer");
                }

                while (reader.Read())
                {
                    productsInCartList.Add(new ProductInCart(
                        id: (int)reader["Id"],
                        title: (string)reader["Title"],
                        count: (int)reader["MaxCounter"]
                        ));
                }
            }

            return productsInCartList;
        }

        public List<Product> GetProductsOfBuyer(string login)
        {
            int idBuyer = buyersSqlDAO.GetIdBuyer(login);

            var productsList = GetProductsOfBuyer(idBuyer);

            return productsList;
        }

        public List<ProductInCart> GetProductsInCart(string login)
        {
            int idBuyer = buyersSqlDAO.GetIdBuyer(login);

            var productsList = GetProductsInCart(idBuyer);

            return productsList;
        }

        //public void AddProductToCart(string login, int idProduct)
        //{
        //    if (idProduct <= 0)
        //    {
        //        throw new FormatException("Invalid parameter format");
        //    }

        //    int idBuyer = buyersSqlDAO.GetIdBuyer(login);

        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        var query = "INSERT INTO dbo.Buyers_Products(Id_Buyer, Id_Product) VALUES(@Id_Buyer, @Id_Product)";

        //        var command = new SqlCommand(query, connection);

        //        command.Parameters.AddWithValue("@Id_Buyer", idBuyer);
        //        command.Parameters.AddWithValue("@Id_Product", idProduct);

        //        connection.Open();

        //        var result = command.ExecuteNonQuery();

        //        if (result == 0)
        //        {
        //            throw new Exception("Couldn't add the product to the cart");
        //        }

        //    }
        //}

        public void AddProductToCart(string login, int idProduct)
        {
            if (idProduct <= 0)
            {
                throw new FormatException("Invalid parameter format");
            }

            int idBuyer = buyersSqlDAO.GetIdBuyer(login);
            int newCount = GetNewCount(idBuyer, idProduct);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.Buyers_Products(Id_Buyer, Id_Product, Counter) VALUES(@Id_Buyer, @Id_Product, @Counter)";

                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id_Buyer", idBuyer);
                command.Parameters.AddWithValue("@Id_Product", idProduct);
                command.Parameters.AddWithValue("@Counter", newCount);

                connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("Couldn't add the product to the cart");
                }

            }
        }

        int GetNewCount(int idBuyer, int idProduct)
        {
            int newCount = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT TOP (1) Buyers_Products.Counter " +
                    "FROM Products JOIN Buyers_Products ON Products.Id = Buyers_Products.Id_Product " +
                    "WHERE(Buyers_Products.Id_Buyer = @Id_Buyer and Buyers_Products.Id_Product = @Id_Product) " +
                    "ORDER BY Buyers_Products.Counter DESC", connection);

                command.Parameters.AddWithValue("@Id_Buyer", idBuyer);
                command.Parameters.AddWithValue("@Id_Product", idProduct);

                connection.Open();

                var reader = command.ExecuteReader();

                if (reader == null)
                {
                    throw new Exception("Cannot get product of buyer");
                }

                while (reader.Read())
                {
                    newCount = (int)reader["Counter"];
                }
            }
            newCount++;

            return newCount; //TODO возможно упросить и проверочку
        }


        public void RemoveProductFromCart(string login, int idProduct) // с проверкой (можно через bool) - TODO ОШИБКА УДАЛЕНИЯ
        {
            if (idProduct <= 0)
            {
                throw new FormatException("Invalid parameter format");
            }

            int idBuyer = buyersSqlDAO.GetIdBuyer(login);

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM dbo.Buyers_Products WHERE Id_Buyer = @Id_Buyer AND Id_Product = @Id_Product";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id_Buyer", idBuyer);
                command.Parameters.AddWithValue("@Id_Product", idProduct);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("Couldn't remove the product from the cart");
                }

            }
        }

        public void DeleteProductFromCart(int idBuyer)
        {
            if (idBuyer <= 0)
            {
                throw new FormatException("Invalid parameter format");
            }

            //проверка - а ест ли такой в таблице

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM dbo.Buyers_Products WHERE Id_Buyer = @Id_Buyer";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id_Buyer", idBuyer);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                //if (result == 0)
                //{
                //    throw new Exception("Couldn't delete the product from the cart");
                //}

            }
        }

        public void DeleteProductFromCartByIdProduct(int idProduct)
        {
            if (idProduct <= 0)
            {
                throw new FormatException("Invalid parameter format");
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM dbo.Buyers_Products WHERE Id_Product = @Id_Product";

                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id_Product", idProduct);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("Couldn't delete the product from the cart");
                }

            }
        }
    }
}
