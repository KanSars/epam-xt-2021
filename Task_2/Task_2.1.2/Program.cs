using System;
using System.Collections.Generic;
using System.Text;

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

                action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        PrintListOfFigures();

                        mylist.Add(GetFigure());
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

            Figure GetFigure()
            {
                int typeOfFigure = int.Parse(Console.ReadLine());
                Figure thisFigure;

                switch (typeOfFigure)
                {
                    case 1:
                        thisFigure = CreateCircleOrRoundForList(true);
                        Console.WriteLine("Фигура Окружность создана!");
                        break;
                    case 2:
                        thisFigure = CreateCircleOrRoundForList(false);
                        Console.WriteLine("Фигура Круг создана!");
                        break;
                    case 3:
                        thisFigure = CreateRingForList();
                        Console.WriteLine("Фигура Кольцо создана!");
                        break;
                    case 4:
                        thisFigure = CreatLineForList();
                        Console.WriteLine("Фигура Линия создана!");
                        break;
                    case 5:
                        thisFigure = CreatSquareForList();    
                        Console.WriteLine("Фигура Квадрат создана!");
                        break;
                    default:
                        throw new Exception("wrong number");
                }
                Console.WriteLine();

                return thisFigure;
            }

            static Figure CreateCircleOrRoundForList(bool circle)
            {
                Console.WriteLine("Введите через пробел X Y");

                string[] symbols = Console.ReadLine().Split(' ');

                int x = int.Parse((symbols[0].ToString()));
                int y = int.Parse((symbols[1].ToString()));

                Console.WriteLine("Введите радиус");
                int radius = int.Parse(Console.ReadLine());

                if (circle)
                {
                    Circle newCircle = new Circle(x, y, radius);
                    return newCircle;
                } else
                {
                    Round newRound = new Round(x, y, radius);
                    return newRound;
                }
            }

            static Figure CreateRingForList()
            {
                Console.WriteLine("Введите через пробел X Y");

                string[] coordinates = Console.ReadLine().Split(' ');

                int x = int.Parse((coordinates[0].ToString()));
                int y = int.Parse((coordinates[1].ToString()));

                Console.WriteLine("Введите через пробел радиусы для внутреннего и внешнего кольца");

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

                return newRing;
            }

            static Figure CreatLineForList()
            {
                Console.WriteLine("Введите через пробел X1 Х2");

                string[] symbols = Console.ReadLine().Split(' ');

                int x1 = int.Parse((symbols[0].ToString()));
                int x2 = int.Parse((symbols[1].ToString()));

                Line newLine = new Line(x1, x2);

                return newLine;
            }

            static Figure CreatSquareForList()
            {
                Console.WriteLine("Введите X1 Х2");

                string[] symbols = Console.ReadLine().Split(' ');

                int x1 = int.Parse((symbols[0].ToString()));
                int x2 = int.Parse((symbols[1].ToString()));

                Square newSquare = new Square(x1, x2);

            return newSquare;
            }
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
        int x, y, r;

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
        int x, y, r;

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
    class Ring : Figure
    {
        private Round innerRing;
        private Round outerRing;
        int x, y, innerr, outerr;

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
    public abstract class Linear : Figure
    {
        void Segment(int x1, int x2) // оставлять ли здесь x1, x2?
        { }
    }
    public class Line : Linear
    {
        public int x1 = 0;
        public int x2 = 0; 
        public int line;
        
        public Line(int coordX1, int coordX2)
        {
            this.x1 = coordX1;
            this.x2 = coordX2;

            this.line = Math.Abs(coordX1 - coordX2);
        }
        public override string ToString()
        {
            return $"Line, x1= {this.x1.ToString()}, x2= {this.x2.ToString()}, length= {this.line.ToString()}";
        }
    }

    public class Square : Line
    {
        public int side;
        public Square(int coordX1, int coordX2) : base(coordX1, coordX2)
        {
                    if (coordX1 == coordX2)
                        throw new Exception("Координаты точек не должны совпадать");
                    else                                                      
                    {
                        this.x1 = coordX1;
                        this.x2 = coordX2;
                        this.side = Math.Abs(x2 - x1);
                    }
        }
        public override string ToString()
        {
            return $"Squere, side= {this.side.ToString()}";
        }
    }
       class Params
    {
        int x, y, radius;
        public Params(int X, int Y)
        {
            this.x = X;
            this.y = Y;
        }
        public Params(int R)
        {
            this.radius = R;
        }
    }
}