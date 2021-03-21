using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> mylist = new List<string>();
            int action;

            do
            {
                Menu();

                action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        mylist.Add(FigureToAdd());
                        break;
                    case 2:
                        foreach (string figure in mylist)
                            Console.WriteLine($"Фигура= {figure}");
                        break;
                    case 3:
                        mylist.Clear();
                        break;
                }
            } while (action != 4);

            static string FigureToAdd()
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
                    case 2:
                        thisFigure = AddRoundToList();
                        Console.WriteLine("Фигура Круг создана!");
                        break;
                    case 3:
                        thisFigure = AddRingToList();
                        Console.WriteLine("Фигура Кольцо создана!");
                        break;
                }
                Console.WriteLine();

                return thisFigure;
            }

            void Menu()
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
                
                string[] symbols = Console.ReadLine().Split(' ');

                int x = int.Parse((symbols[0].ToString()));
                int y = int.Parse((symbols[1].ToString()));

                Console.WriteLine("Введите радиус");
                int radius = int.Parse(Console.ReadLine());
                Circle newCircle = new Circle(x, y, radius);
                return newCircle.ToString();
            }

            static string AddRoundToList()
            {
                Console.WriteLine("Введите X Y");
                
                string[] symbols = Console.ReadLine().Split(' ');

                int x = int.Parse((symbols[0].ToString()));
                int y = int.Parse((symbols[1].ToString()));

                Console.WriteLine("Введите радиус");
                int radius = int.Parse(Console.ReadLine());
                Round newRound = new Round(x, y, radius);

                return newRound.ToString();
            }
            static string AddRingToList()
            {
                Console.WriteLine("Введите X Y");
                
                string[] coordinates = Console.ReadLine().Split(' ');

                int x = int.Parse((coordinates[0].ToString()));
                int y = int.Parse((coordinates[1].ToString()));

                Console.WriteLine("Введите радиусы для внутреннего и внешнего кольца");
                
                string[] radiuses = Console.ReadLine().Split(' ');

                int innerR = int.Parse((radiuses[0].ToString()));
                int outerR = int.Parse((radiuses[1].ToString()));

                if (innerR > outerR)
                {
                    int tempraduis = innerR;
                    innerR = outerR;
                    outerR = tempraduis;
                }

                Ring newRing = new Ring(x, y, innerR, outerR);

                return newRing.ToString();
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
        public double LengthCircle()
        {
            double length;
            length = 2 * Math.PI * this.r;
            return length;
        }
        public override string ToString()
        {
            return $"Circle, x= {this.x.ToString()}, y= {this.y.ToString()}, r= {this.r.ToString()}";
        }
    }
    class Round : Circle
    {
        int x = 0;
        int y = 0;
        int r = 0;

        public Round(int X, int Y, int radius) : base(X, Y, radius)
        {
            this.x = X;
            this.y = Y;
            this.r = radius;
        }

        public double SqrOfRound()
        {
            double result;
            result = Math.PI * this.r * this.r / 2;
            return result;
        }
        public override string ToString()
        {
            return $"Round, x= {x.ToString()}, y= {y.ToString()}, r= {r.ToString()}";
        }
    }
    class Ring
    {
        private Round innerRing;
        private Round outerRing;
        int x;
        int y;
        int innerr;
        int outerr;

        public Ring(int X, int Y, int innerR, int outerR)
        {
            this.innerRing = new Round(X, Y, innerR);
            this.outerRing = new Round(X, Y, outerR);
            this.x = X;
            this.y = Y;
            this.innerr = innerR;
            this.outerr = outerR;
        }
        public double SqrOfRing()
        {
            double square;
            square = outerRing.SqrOfRound() - innerRing.SqrOfRound();
            return square;

        }
        public override string ToString()
        {
            return $"Ring, x= {x.ToString()}, y= {y.ToString()}, innerRadius= {innerr.ToString()}, outerRadius= {outerr.ToString()}";
        }
    }
}
