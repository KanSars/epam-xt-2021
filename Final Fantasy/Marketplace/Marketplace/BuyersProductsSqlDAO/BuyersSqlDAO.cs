using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using Marketplace.DAO.Interfaces;
using Marketplace.Entities;
using System.Configuration;

namespace BuyersProductsSqlDAO
{
    public class BuyersSqlDAO : IBuyersDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        SqlConnection _connection = new SqlConnection(_connectionString);

        public void AddBuyer(string login)
        {
            using (_connection)
            {
                var query = "INSERT INTO dbo.Buyers(Login) " +
                    "VALUES(@Login)";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Login", login);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new InvalidOperationException("Cannot add buyer");
                }

            }
        }

        public void AddBuyer(string login, string pass)
        {
            using (_connection)
            {
                var query = "INSERT INTO dbo.Buyers(Login, Pass) " +
                    "VALUES(@Login, @Pass)";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Pass", pass);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new InvalidOperationException("Cannot add buyer");
                }

            }
        }

        public Buyer GetBuyer(int id)
        {
            if (id <= 0)
            {
                throw new FormatException("Invalid parameter format");
            }

            Buyer buyer = new Buyer();

            buyer = GetAllBuyers().FirstOrDefault(buyerInList => buyerInList.Id == id);

            if (buyer == null)
            {
                throw new InvalidOperationException("Cannot get buyer");
            }

            return buyer;
        }

        public int GetIdBuyer(string login)
        {
            var buyersList = GetAllBuyers();

            var result = buyersList.FirstOrDefault(buyerInList => buyerInList.Login == login);

            if (result != null)
            {
                return result.Id;
            }

            return 0;
        }

        public List<Buyer> GetAllBuyers()
        {
            var buyersList = new List<Buyer>();
            
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Login, Pass FROM Buyers", _connection);
                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    buyersList.Add(new Buyer(
                        id: (int)reader["Id"],
                        login: (string)reader["Login"],
                        pass: (string)reader["Pass"]
                        ));
                }
            }

            return buyersList;
        }

        public void DeleteBuyer(int idBuyer)
        {
            if (idBuyer <= 0)
            {
                throw new FormatException("Invalid parameter format");
            }


            // проверт а есть ли такой в списке

            //int idBuyer = buyersSqlDAO.GetIdBuyer(login);

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM dbo.Buyers WHERE Id = @IdBuyer";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@IdBuyer", idBuyer);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("Couldn't delete buyer");
                }
            }
        }

        public List<BuyerData> GetBuyersDataList()
        {
            var buyersDataList = new List<BuyerData>();

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Id_RegData, Name, Surname, DoB, Email FROM dbo.RegData", _connection);
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    buyersDataList.Add(new BuyerData(
                        id: (int)reader["Id_RegData"],
                        name: (string)reader["Name"],
                        surname: (string)reader["Surname"],
                        doB: (DateTime)reader["DoB"],
                        email: (string)reader["Email"])
                        );
                }
            }

            return buyersDataList;
        }

        public BuyerData GetBuyerData(string login)
        {
            int id_RegData = 0;

            id_RegData = GetIdBuyer(login); //TODO если не получилось вернуть id

            if (id_RegData == 0)
            {
                throw new Exception("Couldn't get buyer Id");
            }

            var buyersDataList = GetBuyersDataList(); //TODO есть ли лист покупателей

            var buyerData = buyersDataList.FirstOrDefault(itemBuyerData => itemBuyerData.Id == id_RegData);

            if (buyerData != null)
            {
                return buyerData;
            }

            DateTime date = new DateTime(1900, 1, 1);

            AddBuyerData(login, "", "", date, "");

            buyerData = buyersDataList.FirstOrDefault(itemBuyerData => itemBuyerData.Id == id_RegData);

            return buyerData;
        }

        public void EditBuyerData(string login, string name, string surname, DateTime doB, string email)
        {
            //TODO проверка
            var buyer = GetBuyerData(login);

            int id_RegData = buyer.Id;

            if (buyer is null)
            {
                AddBuyerData(login, name, surname, doB, email);
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE dbo.RegData SET Name = @Name, Surname = @Surname, DoB = @DoB, Email = @Email " +
                    "WHERE Id_RegData = @Id_RegData";
                var command = new SqlCommand(query, _connection);


                command.Parameters.AddWithValue("@Id_RegData", id_RegData);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Surname", surname);
                command.Parameters.AddWithValue("@DoB", doB);
                command.Parameters.AddWithValue("@Email", email);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("Data could not be changed");
                }
            }
        }



        public void AddBuyerData(string login, string name, string surname, DateTime doB, string email)
        {
            int id_RegData = 0;

            id_RegData = GetIdBuyer(login); //TODO если не получилось вернуть id (см.выше)

            if (id_RegData == 0)
            {
                throw new Exception("Couldn't get buyer Id");
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.RegData(Id_RegData, Name, Surname, DoB, Email) " +
                        "VALUES(@Id_RegData, @Name, @Surname, @DoB, @Email)";

                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id_RegData", id_RegData);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Surname", surname);
                command.Parameters.AddWithValue("@DoB", doB);
                command.Parameters.AddWithValue("@Email", email);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new InvalidOperationException("Failed to add data");
                }

            }   
        }

        public void DeleteBuyerData(int idBuyer)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM dbo.RegData WHERE Id_RegData = @Id_RegData";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id_RegData", idBuyer);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("Couldn't delete data");
                }
            }
        }


        public bool IsUserExist(string login, string pass)
        {
            var buyersList = GetAllBuyers();

            var result = buyersList.FirstOrDefault(buyerInList => buyerInList.Login == login && buyerInList.Pass == pass);

            if (result != null)
            {
                return true;
            }
            return false;
        }

        public void DeleteBuyerById(int idBuyer)
        {
            if (idBuyer <= 0)
            {
                throw new FormatException("Invalid parameter format");
            }

            Buyers_ProductsSqlDAO Buyers_Products = new Buyers_ProductsSqlDAO();

            DeleteBuyer(idBuyer);

            DeleteBuyerData(idBuyer);

            Buyers_Products.DeleteProductFromCart(idBuyer);
        }

    }
}