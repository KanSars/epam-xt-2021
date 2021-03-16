using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey key;
            List<string> mylist = new List<string>();
            string tempstring = "Null";
            int action;

            do
            {
                StageOne();

                action = int.Parse(Console.ReadLine());
                //action = 1;

                switch (action)
                {
                    case 1:
                        mylist.Add(AddFigure());
                        break;

                    case 2:
                        foreach (string figure in mylist)
                        {
                            Console.WriteLine($"//для проверки tempstring= {figure}");
                        }
                        break;
                    case 3:
                        mylist.Clear();
                        break;
                }
            } while (action != 4);

            static string AddFigure()
            {
                Console.WriteLine("Введите № фигры");
                int typeOfFigure = int.Parse(Console.ReadLine());
                string thisFigure = "Null";

                switch (typeOfFigure)
                {
                    case 1:
                        thisFigure = AddCircleToList();
                        Console.WriteLine("Фигура Окружность создана!");
                        break;
                }
                return thisFigure;
            }

            void StageOne()
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1.Добавить фигуру");
                Console.WriteLine("2.Вывести фигуры");
                Console.WriteLine("3.Очистить холст");
                Console.WriteLine("4.Выход");
            }

            static string AddCircleToList()
            {
                Console.WriteLine("Введите X Y");
                int x = 1;
                int y = 3;


                string[] symbols = Console.ReadLine().Split(' ');

                //for (int i = 0; i < symbols.Length; i++)
                //{
                //    x = int.Parse((symbols[i].ToString()));
                //    y = int.Parse((symbols[i].ToString()));
                //}
                //.....

                x = int.Parse((symbols[0].ToString()));
                y = int.Parse((symbols[1].ToString()));


                //Circle newCircle = new Circle(x, y);

                Console.WriteLine("Введите радиус");
                int radius = int.Parse(Console.ReadLine());
                Circle newCircle = new Circle(x, y, radius);
                //newCircle = new Circle(radius);

                return newCircle.ToString();
            }
        }
    }

    class Circle
    {
        int x = 0;
        int y = 0;
        int r = 33;

        public Circle(int X, int Y, int radius)
        {
            this.x = X;
            this.y = Y;
            this.r = radius;
        }
        public Circle(int radius)
        {
            this.r = radius;
        }
        public double LengthCircle()
        {
            double length;
            length = 2 * Math.PI * this.r;
            return length;
        }
        public override string ToString()
        {
            return $"Circle, x= {x.ToString()}, y= {y.ToString()}, r= {r.ToString()}";
        }
    }
    class Round : Circle
    {
        int x = 0;
        int y = 0;
        int r = 0;

        public Round(int radius) : base(radius)
        {
            this.r = radius;
        }

        public double SqrOfRound()
        {
            double result;
            result = Math.PI * this.r * this.r / 2;
            return result;
        }

    }

}
