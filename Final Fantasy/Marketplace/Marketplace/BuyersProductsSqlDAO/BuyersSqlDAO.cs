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
    public class BuyersSqlDAO : IBuyersDAO //не пплачусь ли я за этот static
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        SqlConnection _connection = new SqlConnection(_connectionString);

        public void AddBuyer(string login)
        {
            using (_connection)
            {
                //var query = "INSERT INTO dbo.Buyers(Login) " +
                //    "VALUES(@Login); SELECT CAST(scope_identity() AS INT) AS NewID";
                var query = "INSERT INTO dbo.Buyers(Login) " +
                    "VALUES(@Login)";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Login", login);

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

        public void AddBuyer(string login, string pass)
        {
            using (_connection)
            {
                //var query = "INSERT INTO dbo.Buyers(Login) " +
                //    "VALUES(@Login); SELECT CAST(scope_identity() AS INT) AS NewID";
                var query = "INSERT INTO dbo.Buyers(Login, Pass) " +
                    "VALUES(@Login, @Pass)";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Pass", pass);

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

        public Buyer GetBuyer(int id)
        {
            Buyer buyer = new Buyer();

            buyer = GetAllBuyers().FirstOrDefault(buyerInList => buyerInList.Id == id);

            return buyer;
        }

        public int GetIdBuyer(string login)
        {
            //Buyer buyer = new Buyer();

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
                        //,dateOfBirth: (DateTime)reader["DateOfBirth"]
                        ));
                }
            }

            return buyersList;
        }

        public void DeleteBuyer(int idBuyer)
        {
            // проверт а есть ли такой в списке

            //int idBuyer = buyersSqlDAO.GetIdBuyer(login);

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM dbo.Buyers WHERE Id = @IdBuyer";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@IdBuyer", idBuyer);

                _connection.Open();

                //var result = command.ExecuteNonQuery();
                command.ExecuteNonQuery();
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

            int id_RegData = GetIdBuyer(login); //TODO если не получилось вернуть id

            var buyersDataList = GetBuyersDataList(); //TODO есть ли лист покупателей

            var buyerData = buyersDataList.FirstOrDefault(itemBuyerData => itemBuyerData.Id == id_RegData);

            return buyerData;
        }


        public void EditBuyerData(string login, string name)
        {
            var buyer = GetBuyerData(login);

            int id_RegData = buyer.Id;

            if (buyer is null)
            {
                AddBuyerData(login, name);
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE dbo.RegData SET Name = @Name " +
                    "WHERE Id_RegData = @Id_RegData";
                var command = new SqlCommand(query, _connection);

                
                command.Parameters.AddWithValue("@Id_RegData", id_RegData);
                command.Parameters.AddWithValue("@Name", name);

                //command.Parameters.AddWithValue("@DateOfBirth", newDateOfBirth);

                _connection.Open();
                 
                var result = command.ExecuteNonQuery();

                //if (result == 0)                                      //TODO add an Exception
                //    throw new InvalidOperationException(
                //        string.Format("Не удалось исправить данные"));
            }

        }

        public void EditBuyerData(string login, string name, string surname, DateTime doB, string email)
        {
            var buyer = GetBuyerData(login);

            int id_RegData = buyer.Id;

            if (buyer is null)
            {
                AddBuyerData(login, name);
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

                //command.Parameters.AddWithValue("@DateOfBirth", newDateOfBirth);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                //if (result == 0)                                      //TODO add an Exception
                //    throw new InvalidOperationException(
                //        string.Format("Не удалось исправить данные"));
            }
        }



        public void AddBuyerData(string login, string name)
        {
            int id_RegData = GetIdBuyer(login); //TODO если не получилось вернуть id

            //int id_RegData = 6;
            SqlConnection _connection = new SqlConnection(_connectionString); //иначе ошибка занятого потока

            using (_connection)
            {
                var query = "INSERT INTO dbo.RegData(Id_RegData, Name) " +
                        "VALUES(@Id_RegData, @Name)";

                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id_RegData", id_RegData);
                command.Parameters.AddWithValue("@Name", name);

                // DBNull.Value

                _connection.Open();

                var result = command.ExecuteScalar();


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

                //var result = command.ExecuteNonQuery();
                command.ExecuteNonQuery();
            }
        }

        public bool IsUserExist(string login, string pass)
        {
            //запрашиваем юзера с логином и паролем
            //если на выходе не нулл то труе

            //Buyer buyer = new Buyer();

            var buyersList = GetAllBuyers();

            var result = buyersList.FirstOrDefault(buyerInList => buyerInList.Login == login && buyerInList.Pass == pass);

            if (result != null)
            {
                return true;
            }
            return false;
        }

       

    }
}