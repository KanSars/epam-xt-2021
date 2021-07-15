using System;
using System.Configuration;
using System.Data.SqlClient;
using Marketplace.Dependencies;
using Marketplace.Entities;

// функция добавления покупателя:
// должна запускаться одна функция с разными вариантами (указал ли пользователь все поля или оставил пустами)
//ИЛИ: добавить сценарий при внесении не всех необходимых данных типа: вернуть на страницу регистрации с уточнением "Вы не заполнили все необходимые поля"
//а лучше и так и так*



namespace Marketplace.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {

            //var _connectionString = new SqlConnection(@"Data Source=ОЛЬГА-ПК\SQLEXPRESS;Initial Catalog=Market;Integrated Security=True;_connectionString Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            //private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            //string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

            //SqlConnection _connection = new SqlConnection(_connectionString);

            //using (_connection)
            //{
            //    _connection.Open();

            //    string textOfCommand = "SELECT Id_Buyer, Id_Product FROM Buyers_Products";

            //    var command = new SqlCommand(textOfCommand, _connection);

            //    var reader = command.ExecuteReader();

            //    if (reader.Read())
            //    {
            //        Console.WriteLine(new BuyersProducts(
            //            idBuyer: (int)reader["Id_Buyer"],
            //            idProduct: (int)reader["Id_Product"]));

            //    }

            //    Console.WriteLine();
            //}

            var buyer = DependencyResolver.Instance.BuyresLogic.GetBuyer(1);

            Console.WriteLine($"Имя покупателя: {buyer.Login}");

            //-----------------------------------------------------------------
            //Buyer buyer = new Buyer("Vitya");

            //DependencyResolver.Instance.BuyresLogic.AddBuyerToDict(buyer);

            //-----------------------------------------------------------------

            //string textOfCommand = "SELECT Id, Name, Surname FROM Notes";


            //User user = new User(1, "Vasiliy");

            //User user = new User("Vasiliy", DateTime.Parse("10.07.1990"));

            //DependencyResolver.Instance.ListLogic.AddAwardToDict(award);

            //DependencyResolver.Instance.ListLogic.AddUserAwardToList(1, "Cola");





            //DependencyResolver.Instance.ListLogic.EditUser(1, "Kolya!!!!!!!");


            //var listUsers = DependencyResolver.Instance.ListLogic.GetAllUsers(); //проверка данных в файле

            //foreach (var item in listUsers)
            //{
            //    Console.WriteLine($"item=, {item.ToString()}");
            //    Console.WriteLine(item.Id);
            //    Console.WriteLine(item.Name);
            //    //Console.WriteLine(item.DoB);
            //    //Console.WriteLine(item.Age);
            //}

            //DependencyResolver.Instance.ListLogic.RemoveAwardFromDict("Cola");

        }
    }
}
