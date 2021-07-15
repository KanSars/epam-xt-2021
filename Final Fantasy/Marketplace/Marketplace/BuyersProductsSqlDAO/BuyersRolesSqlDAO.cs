using Marketplace.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyersProductsSqlDAO
{
    public class Buyers_RolesSqlDAO : IBuyersRolesDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        BuyersSqlDAO buyersSqlDAO = new BuyersSqlDAO();


        public List<string> GetRolesOfBuyer(string login)
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
                //command.Parameters.AddWithValue("@Id_Product", idProduct);

                connection.Open();

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

        public void AddAdminRoleForBuyer(string login)
        {
            int idBuyer = buyersSqlDAO.GetIdBuyer(login);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.Buyers_Roles(Id_Buyer, Id_Role) VALUES(@Id_Buyer, 1)";

                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id_Buyer", idBuyer);
                //command.Parameters.AddWithValue("@Id_Product", idProduct);

                connection.Open();

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

    }
}
