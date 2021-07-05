using System;
using Task_8.Entities;
using Task_8.Dependencies;

//TODO проверка на нулл добавку награды (если удалить из файла - ошибка)
//то же и с юзерами

namespace Task_8.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            Entities.User user = new(1, "Vasiliy");
            int id = 2; // переделать в генератор

            Entities.Award award = new("Cola");

            Console.WriteLine($"{user.Id}, {user.Name}");

            Dependencies.DependencyResolver.Instance.ListLogic.AddUserToDict(user); //TODO генератор ID

            Dependencies.DependencyResolver.Instance.ListLogic.AddAwardToDict(id, award); // в данном случае ID юзера кого награждают

            Dependencies.DependencyResolver.Instance.ListLogic.AddUserAwardToList(1, 1); //

            var listUsers = DependencyResolver.Instance.ListLogic.GetAllUsers();

            foreach (var item in listUsers)
            {
                Console.WriteLine($"item=, {item.ToString()}");
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
            }

        }
    }
}
