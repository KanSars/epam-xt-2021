using System;
using Task_8.ASP.Entities;
using Task_8.ASP.Dependencies;

namespace Task_8.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            //User user = new User(1, "Vasiliy");

            //User user = new User("Vasiliy", DateTime.Parse("10.07.1990"));
            User user = new User("Vasiliy");

            //user.DoB = DateTime.Parse("10.07.1990");


            Award award = new Award("SuperFanta");


            DependencyResolver.Instance.ListLogic.AddUserToDict(user);

            DependencyResolver.Instance.ListLogic.AddAwardToDict(award);

            //DependencyResolver.Instance.ListLogic.AddUserAwardToList(1, "Cola");





            //DependencyResolver.Instance.ListLogic.EditUser(1, "Kolya!!!!!!!");


            var listUsers = DependencyResolver.Instance.ListLogic.GetAllUsers(); //проверка данных в файле

            foreach (var item in listUsers)
            {
                Console.WriteLine($"item=, {item.ToString()}");
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                //Console.WriteLine(item.DoB);
                //Console.WriteLine(item.Age);
            }

            //DependencyResolver.Instance.ListLogic.RemoveAwardFromDict("Cola");

        }
    }
}
