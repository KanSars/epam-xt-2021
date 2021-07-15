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

                // DBNull.Value

                _connection.Open();

                var result = command.ExecuteScalar();

                //if (result != null)
                //    return new Note(
                //        id: (int)result,
                //        text: text,
                //        creationDate: creationDate);

                //throw new InvalidOperationException(
                //    string.Format("Cannot add Note with parameters: {0}, {1};",
                //    text, creationDate));
            }
        }

        public void AddProduct(string title, int price)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.Products(Title, Price) " +
                    "VALUES(@Title, @Price)";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Price", price);

                // DBNull.Value

                _connection.Open();

                var result = command.ExecuteScalar();

                //if (result != null)
                //    return new Note(
                //        id: (int)result,
                //        text: text,
                //        creationDate: creationDate);

                //throw new InvalidOperationException(
                //    string.Format("Cannot add Note with parameters: {0}, {1};",
                //    text, creationDate));
            }
        }
        public List<Product> GetAllProducts()
        {
            var productsList = new List<Product>();

            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
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

            return productsList;
        }

        public List<Product> GetProductsByTitle(string partOfTitle)
        {
            var productsList = new List<Product>();

            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT Id, Title FROM dbo.Products WHERE Title LIKE '%' + @PartOfTitle + '%'", connection);

                command.Parameters.AddWithValue("@PartOfTitle", partOfTitle);

                connection.Open();

                var reader = command.ExecuteReader();
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

        public Product GetProductById(int id)
        {
            var result = GetAllProducts().FirstOrDefault(productInList => productInList.Id == id);

            return result;
        }

        public void EditProductData(int id, string title, int price)
        {

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE dbo.Products SET Title = @Title, Price = @Price " +
                    "WHERE Id = @Id";
                var command = new SqlCommand(query, _connection);


                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Price", price);

                //command.Parameters.AddWithValue("@DateOfBirth", newDateOfBirth);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                //if (result == 0)                                      //TODO add an Exception
                //    throw new InvalidOperationException(
                //        string.Format("Не удалось исправить данные"));
            }
        }



        //public List<Product> GetProductsByTitle(string title)
        //{
        //    Product product = new Product();

        //    List<Product> neededProductsList = new List<Product>();

        //    var allProductsList = GetAllProducts();

        //    foreach (var item in allProductsList)
        //    {
        //        if (item.Title == title)
        //        {
        //            neededProductsList.Add(item);
        //        }
        //    }

        //    return neededProductsList; //кстати не факт что вернет (поэтому лучше через bool)
        //}
    }
}
