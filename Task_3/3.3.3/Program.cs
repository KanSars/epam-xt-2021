
// персон называет считывает из строки) имя (позже допилит до выбора пиццы)
// пиццерия: создает зааз(пиццу и имя заказчика) получает заказ (имя) и выдет (спустя некоторое время (добавит позже)) его имя (и пуццу позже)
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace _3._3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizzeria pizzeria = new Pizzeria(); // объявляем пиццерию, чтобы вызвать ее функии

            pizzeria.Privetstvie();

            pizzeria.Count(Console.ReadLine(), PizzaType.Fighter); // как этот Fighter вручную с консоли ввести чтобы он его понял?


            //TODO бернуть методы пиццерии в вызов и добавить поток
        }

    }
}


public class Pizzeria
{
    delegate void MethodContainer(string nameOfClient, PizzaType type);

    #region PIZZA PizzaType switch
    public void expEnum(PizzaType type)
    {
        PizzaType y = type;
        int x = (int)type;

        switch (type)
        {
            case PizzaType.None:
                x = 0;
                break;
            case PizzaType.Fighter:
                x = 10;
                break;
            case PizzaType.Scout:
                x = 20;
                break;
        }

    }
    #endregion

    //public void Count(string name, PizzaType type) // ну никак не пашет и так и сяк
    public void Count(string name, PizzaType type)
    {
        PizzaType curretPizza = type;

        int count = 50;

        //TODO добавитьпоток
        for (int i = count; i > 0; i--)
        {
            if (i == count)
            {
                Console.WriteLine($"{name} ваш заказ готов {type}");
                // предложить забрать
            }
        }
    }

    public void Privetstvie() // функция приветствия и приема заказа
    {
        Console.WriteLine("Dratuti, vvedite imya vashe i pizzy");

        // NameClienta = Console.ReadLine();
    }
}

[Flags]
public enum PizzaType : int
{

    None = 0,
    Fighter = 1,
    Scout = 2
}
// появление клиента вызывает функцию в пиццерии приветствие и прием заказа
// после согласия на получения пиццы (пиицерия Говорит имя и получение через ридкей У выывается дестрой клиента