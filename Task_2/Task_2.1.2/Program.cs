using System;
using System.Collections.Generic;

namespace Task_2._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Figure> mylist = new List<Figure>();
            int action;

            do
            {
                PrintMenu();

                if (!int.TryParse(Console.ReadLine(), out action))
                {
                    Console.WriteLine("Введите целое число");
                    Console.WriteLine();
                }

                switch (action)
                {
                    case 1:
                        PrintListOfFigures();
                        AddFigureToList(int.Parse(Console.ReadLine()));
                        break;

                    case 2:
                        foreach (Figure figure in mylist)
                            Console.WriteLine($"Фигура: {figure.ToString()}");
                        Console.WriteLine();
                        break;

                    case 3:
                        mylist.Clear();
                        break;
                }
            } while (action != 4);

            void PrintMenu()
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1.Добавить фигуру");
                Console.WriteLine("2.Вывести фигуры");
                Console.WriteLine("3.Очистить холст");
                Console.WriteLine("4.Выход");
            }

            void PrintListOfFigures()
            {
                Console.WriteLine("Выберите фигуру:");
                Console.WriteLine("1.Окружность");
                Console.WriteLine("2.Круг");
                Console.WriteLine("3.Окружность");
                Console.WriteLine("4.Отрезок");
                Console.WriteLine("5.Квадрат");
            }

            void AddFigureToList(int typeOfFigure)
            {
                switch (typeOfFigure)
                {
                    case 1:
                        mylist.Add(CreateCircleOrRoundForList(true));
                        break;
                    case 2:
                        mylist.Add(CreateCircleOrRoundForList(false));
                        break;
                    case 3:
                        mylist.Add(CreateRingForList());
                        break;
                    case 4:
                        mylist.Add(CreateLineForList());
                        break;
                    case 5:
                        mylist.Add(CreateSquareForList());
                        break;
                    default:
                        throw new Exception("wrong number");
                }

                Console.WriteLine();
            }

            

            static Figure CreateCircleOrRoundForList(bool circle)
            {
                TakeParams(out int x, out int y);

                Console.WriteLine("Введите радиус");
                int radius = int.Parse(Console.ReadLine());

                if (circle)
                {
                    Circle newCircle = new Circle(x, y, radius);

                    Console.WriteLine("Фигура Окружность добавлена!");

                    return newCircle;
                } else
                {
                    Round newRound = new Round(x, y, radius);

                    Console.WriteLine("Фигура Круг добавлена!");

                    return newRound;
                }

                
            }

            static Figure CreateRingForList()
            {
                TakeParams(out int x, out int y);

                Console.WriteLine("Введите через пробел радиусы для внутреннего и внешнего кольца");

                string[] radiuses = Console.ReadLine().Split(' ');
                int radius = int.Parse((radiuses[0].ToString()));
                int outerR = int.Parse((radiuses[1].ToString()));

                if (radius > outerR)
                {
                    int tempraduis = radius;
                    radius = outerR;
                    outerR = tempraduis;
                }
                Ring newRing = new Ring(x, y, radius, outerR);

                Console.WriteLine("Фигура Кольцо добавлена!");

                return newRing;
            }

            static Figure CreateLineForList()
            {
                TakeParams(out int x1, out int x2);

                Line newLine = new Line(x1, x2);

                Console.WriteLine("Фигура Линия добавлена!");

                return newLine;
            }

            static Figure CreateSquareForList()
            {
                TakeParams(out int x1, out int x2);

                Square newSquare = new Square(x1, x2);

                Console.WriteLine("Фигура Квадрат добавлена!");

                return newSquare;
            }
        }

        static void TakeParams(out int X1, out int X2)
        {
            Console.WriteLine("Введите X1 Х2");

            string[] symbols = Console.ReadLine().Split(' ');
            X1 = int.Parse((symbols[0].ToString()));
            X2 = int.Parse((symbols[1].ToString()));
        }
    }


    public abstract class Figure
    {
        public override string ToString()
        {
            return "Некая фигура";
        }
    }
    class Circle : Figure
    {
        protected int X;
        protected int Y;
        protected int R;

        public Circle(int x, int y, int radius)
        {
            X = x;
            Y = y;
            R = radius;
        }
        public double LengthCircle()
        {
            double length;
            length = 2 * Math.PI * R;
            return length;
        }
        public override string ToString()
        {
            return $"Circle, x= {X.ToString()}, y= {Y.ToString()}, r= {R.ToString()}";
        }
    }
    class Round : Circle
    {
        public Round(int x, int y, int radius) : base(x, y, radius)
        {
            X = x;
            Y = y;
            R = radius;
        }

        public double SqrOfRound()
        {
            double result;
            result = Math.PI * R * R / 2;
            return result;
        }
        public override string ToString()
        {
            return $"Round, x= {X.ToString()}, y= {Y.ToString()}, r= {R.ToString()}";
        }
    }
    class Ring : Round
    {
        private Round outerRing;
        protected int innerR;
        protected int outerR;

        public Ring(int x, int y, int radius, int outerRadius): base (x, y, radius)
        {
            outerRing = new Round(X, Y, outerRadius);
            X = x;
            Y = y;
            innerR = radius;
            outerR = outerRadius;
        }
        public double SqrOfRing()
        {
            double square;
            square = outerRing.SqrOfRound() - SqrOfRound();
            return square;

        }
        public override string ToString()
        {
            return $"Ring, x= {X.ToString()}, y= {Y.ToString()}, innerRadius= {innerR.ToString()}, outerRadius= {outerR.ToString()}";
        }
    }
    public abstract class Linear : Figure
    {
        protected int X1;
        protected int X2;
        public Linear(int x1, int x2)
        {
            X1 = x1;
            X2 = x2;
        }
    }
    public class Line : Linear
    { 
        protected int line;
        
        public Line(int x1, int x2): base ( x1, x2)
        {
            X1 = x1;
            X2 = x2;
            line = Math.Abs(X1 - X2);
        }
        public override string ToString()
        {
            return $"Line, x1= {X1.ToString()}, x2= {X2.ToString()}, length= {this.line.ToString()}";
        }
    }

    public class Square : Linear
    {
        protected int Side;
        public Square(int x1, int x2) : base(x1, x2)
        {
            if (x1 == x2)
                throw new Exception("Координаты точек не должны совпадать");
            else
            {
                X1 = x1;
                X2 = x2;
                Side = Math.Abs(X2 - X1);
            }
        }
        public override string ToString()
        {
            return $"Squere, side= {Side.ToString()}";
        }
    }
}