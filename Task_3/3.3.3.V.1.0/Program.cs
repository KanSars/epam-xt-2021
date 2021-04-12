using System;
using System.Threading;
// todo
namespace _3._3._3.V._1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ждем клиента");

            Person person = new Person();
            Pizzeria pizzeria = new Pizzeria();

            person.eventZakaz += pizzeria.Prigotovlenie;

            person.Zakaz(Console.ReadLine());

            // отдаем заказ

            Console.WriteLine("Хотите забрать заказ? ");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine();
                pizzeria.eventOtdatZakaz += person.Polu4itPizzy; //подписка на событие передачи пиццы
                pizzeria.OtdatPizzy("Mozarella");
            }
        }
    }
}

public class Person // будет обращаться (вызывать) к пиццерии и передавать ей имя для заказа
{
    public delegate void MethodZakaz(string name);

    public event MethodZakaz eventZakaz;

    public void Zakaz(string name)
    {
        Console.WriteLine($"Дратути меня зовут {name}");
        Console.Write($"Приготовьте, пожалуйста, пиццу");

        Console.WriteLine();
        eventZakaz(name);
    }

    string pizza = null;

    public void Polu4itPizzy(string nameOfPizza)
    {
        pizza = nameOfPizza;
        Console.WriteLine($"Довольный клиент: Теперь у меня есть пицца {pizza}");
    }
}

public class Pizzeria // будет вызывать счетчик приготовления пиццы (через поток) и выдавать сообщение о приготовлении
{

    public void Prigotovlenie(string name)
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
            if (i == 3)
            {
                Console.WriteLine($"{name}, Ваш заказ готов");
                break;
            }
        }
    }
    // а так же передавать клиенту пиццу (вызывать его сообщение, что у него есть пицца)
    public void OtdatPizzy(string somePizza) 
    {
        eventOtdatZakaz(somePizza);
    }

    public delegate void MethodOtdatZakaz(string name);

    public event MethodOtdatZakaz eventOtdatZakaz;
}