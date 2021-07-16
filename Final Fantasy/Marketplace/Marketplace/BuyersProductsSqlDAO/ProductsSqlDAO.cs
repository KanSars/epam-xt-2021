using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.DAO;
using Marketplace.DAO.Interfaces;
using Marketplace.Entities;

namespace BuyersProductsSqlDAO
{
    public class ProductsSqlDAO : IProductsDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public void AddProduct(string title)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.Products(Title) " +
                    "VALUES(@Title)";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Title", title);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new InvalidOperationException("Cannot add the product");
                }

            }
        }

        public void AddProduct(string title, int price)
        {
            if (price < 0)
            {
                throw new FormatException("Invalid parameter format");
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.Products(Title, Price) " +
                    "VALUES(@Title, @Price)";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Price", price);

                // DBNull.Value

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new InvalidOperationException("Cannot add the product");
                }
            }
        }
        public List<Product> GetAllProducts()
        {
            var productsList = new List<Product>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Title, Price FROM Products", connection);
                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productsList.Add(new Product(
                        id: (int)reader["Id"],
                        title: (string)reader["Title"],
                        price: (int)reader["Price"]
                        ));
                }
            }

            return productsList; //TODO если не удалось вернуть то?
        }

        public List<Product> GetProductsByTitle(string partOfTitle)
        {
            var productsList = new List<Product>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Title, Price FROM dbo.Products WHERE Title LIKE '%' + @PartOfTitle + '%'", connection);

                command.Parameters.AddWithValue("@PartOfTitle", partOfTitle);

                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productsList.Add(new Product(
                        id: (int)reader["Id"],
                        title: (string)reader["Title"],
                        price: (int)reader["Price"]
                        ));
                }
            }

            return productsList; //то же (см.выше)
        }

        public Product GetProductById(int id)
        {
            if (id <= 0)
            {
                throw new FormatException("Invalid parameter format");
            }

            var result = GetAllProducts().FirstOrDefault(productInList => productInList.Id == id);

            return result; //TODO если не удалось?
        }

        public void EditProductData(int id, string title, int price)
        {
            if ((id <= 0) || (price < 0))
            {
                throw new FormatException("Invalid parameter format");
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE dbo.Products SET Title = @Title, Price = @Price " +
                    "WHERE Id = @Id";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Price", price);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new InvalidOperationException("Data could not be changed");
                }
            }
        }

    }
}
