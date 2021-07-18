using Marketplace.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace BuyersProductsSqlDAO
{
    public class Buyers_RolesSqlDAO : IBuyersRolesDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        BuyersSqlDAO buyersSqlDAO = new BuyersSqlDAO();


        public List<string> GetRoles(string login)
        {
            List<string> rolesOfBuyerList = new List<string>();

            int idBuyer = buyersSqlDAO.GetIdBuyer(login);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Roles.Role FROM dbo.Roles " +
                    "JOIN Buyers_Roles ON Roles.Id_Role = Buyers_Roles.Id_Role " +
                    "WHERE Buyers_Roles.Id_Buyer = @Id_Buyer", connection);

                command.Parameters.AddWithValue("@Id_Buyer", idBuyer);

                connection.Open();

                var reader = command.ExecuteReader();

                if (reader == null)
                {
                    throw new Exception("Cannot get rignts");
                }

                while (reader.Read())
                {
                    rolesOfBuyerList.Add((string)reader["Role"]);

                }
            }

            return rolesOfBuyerList;
        }

        public void AddRoleForBuyer(string login)
        {
            int idBuyer = buyersSqlDAO.GetIdBuyer(login);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.Buyers_Roles(Id_Buyer, Id_Role) VALUES(@Id_Buyer, 2)";

                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id_Buyer", idBuyer);

                connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new InvalidOperationException("Cannot assign buyer rights");
                }

            }
        }

        public void AssignAdminRights(string login)
        {
            int idBuyer = buyersSqlDAO.GetIdBuyer(login);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                //var query = "INSERT INTO dbo.Buyers_Roles(Id_Buyer, Id_Role) VALUES(@Id_Buyer, 1)";

                var query = "INSERT  dbo.Buyers_Roles (Id_Buyer, Id_Role) " +
                    "SELECT  @Id_Buyer, 1 " +
                    "WHERE NOT EXISTS " +
                    "(SELECT  1 FROM    dbo.Buyers_Roles WHERE   Id_Buyer = @Id_Buyer AND Id_Role = 1)";

                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id_Buyer", idBuyer);

                connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new InvalidOperationException("Cannot assign admin rights");
                }

            }
        }

        public void RevokeAdminRights(int idBuyer)
        {
            if (idBuyer <= 0)
            {
                throw new FormatException("Invalid parameter format");
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM dbo.Buyers_Roles WHERE (Id_Buyer = @Id_Buyer AND Id_Role = 1)";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id_Buyer", idBuyer);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("Couldn't revoke administrator rights");
                }
            }
        }
    }
}
