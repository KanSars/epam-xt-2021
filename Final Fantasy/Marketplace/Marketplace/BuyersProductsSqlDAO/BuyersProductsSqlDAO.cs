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
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        BuyersSqlDAO buyersSqlDAO = new BuyersSqlDAO();

        public List<Product> GetProductsOfBuyer(int idBuyer)
        {
            //
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
                    throw new InvalidOperationException("Cannot get product of buyer");
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

        public List<Product> GetProductsOfBuyer(string login)
        {
            int idBuyer = buyersSqlDAO.GetIdBuyer(login);

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
                    throw new InvalidOperationException("Cannot get products of buyer");
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

        public void AddProductToCart(string login, int idProduct)
        {
            int idBuyer = buyersSqlDAO.GetIdBuyer(login);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.Buyers_Products(Id_Buyer, Id_Product) VALUES(@Id_Buyer, @Id_Product)";

                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id_Buyer", idBuyer);
                command.Parameters.AddWithValue("@Id_Product", idProduct);

                connection.Open();

                //command.ExecuteNonQuery();

                var result = command.ExecuteNonQuery();


            }
        }

        public void RemoveProductFromCart(string login, int idProduct) // с проверкой (можно через bool)
        {
            int idBuyer = buyersSqlDAO.GetIdBuyer(login);

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM dbo.Buyers_Products WHERE Id_Buyer = @Id_Buyer AND Id_Product = @Id_Product";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id_Buyer", idBuyer);
                command.Parameters.AddWithValue("@Id_Product", idProduct);

                _connection.Open();

                command.ExecuteNonQuery();

            }
        }

        public void DeleteProductFromCart(int idBuyer)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM dbo.Buyers_Products WHERE Id_Buyer = @Id_Buyer";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id_Buyer", idBuyer);

                _connection.Open();

                var result = command.ExecuteNonQuery();

            }
        }
    }
}
