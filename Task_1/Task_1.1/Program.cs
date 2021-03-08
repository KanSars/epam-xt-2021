using System;
using System.Text;

namespace Task_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Список программ:");
            Console.WriteLine("1: RECTANGLE");
            Console.WriteLine("2: TRIANGLE");
            Console.WriteLine("3: ANOTHER TRIANGLE");
            Console.WriteLine("4: X-MASS TREE");
            Console.WriteLine("5: SUM OF NUMBERS");

            Console.Write("Укажите номер программы: ");
            //string str_task = Console.ReadLine();
            //int task = int.Parse(str_task);
             int task = 2;

            switch (task)
            {
                case 1:
                    Rectangle();
                    break;
                case 2:
                    Triangle();
                    break;
                case 3:
                    AnotherTriangle();
                    break;
                case 4:
                    XmassTree();
                    break;
                case 5:
                    SumOfNumbers();
                    break;
                case 12:
                    Triangle_V1();
                    break;

            }
            //Task 1.1.1 RECTANGLE

            /* Написать программу, которая определяет площадь прямоугольника со сторонами a и b.
            Если пользователь вводит некорректные знаения (отрицательные или ноль), должно выдаваться сообщение об ошибке.
            Возможность ввода пользователем строки вида "абвгд" или нецелых чисел игнорировать.
            */

            static void Rectangle()
            {
                int a;
                do
                {
                    Console.Write("Введите сторону 'а' (значение больше 0): ");
                    string str_a = Console.ReadLine();
                    a = int.Parse(str_a);
                    if (a < 1)
                    {
                        Console.WriteLine("Alarm: a<=0");
                    }
                } while (a < 1);

                int b;
                do
                {
                    Console.Write("Введите сторону 'b' (значение больше 0): ");
                    string str_b = Console.ReadLine();
                    b = int.Parse(str_b);
                    if (b < 1)
                    {
                        Console.WriteLine("Alarm: b<=0");
                    }
                } while (b < 1);

                int S = a * b;

                Console.WriteLine("Площадь прямоугольника = {0}", S);
            }

            //Task 1.1.2 TRIANGLE
            
            static void Triangle_V1()
            {
                int n;

                Console.Write("Введите высоту треугольника: ");
                string str_n = Console.ReadLine();
                n = int.Parse(str_n);

                //for (int i = 0; i < n; i++)
                for (int i = 0; i <=  n; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    string s = new string('*', i);
                    Console.WriteLine(s);

                    //int ii = 0;
                    //while (ii <= i)
                    //{
                    //    Console.Write("*");
                    //    ii++;
                    //}
                    //Console.WriteLine();
                }
                Console.ResetColor();
            }
            //Task 1.1.2 TRIANGLE
            //StringBuilder

            static void Triangle()
            {
                int n;

                Console.Write("Введите высоту треугольника: ");
                string str_n = Console.ReadLine();
                n = int.Parse(str_n);

                for (int i = 0; i <= n; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    StringBuilder s = new StringBuilder();

                    for (int ii = 0; ii < i; ii++)
                        s.Append("*");

                    Console.WriteLine(s.ToString());
                }
                Console.ResetColor();
            }

            //Task 1.1.3 ANOTHER TRIANGLE

            static void AnotherTriangle()
            {
                int n;

                Console.Write("Введите высоту треугольника: ");
                string str_n = Console.ReadLine();
                n = int.Parse(str_n);

                for (int i = 0; i < n; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    for (int iiii = 0; iiii < n-1-i; iiii++)
                    {
                        Console.Write(" ");
                    }

                    int iii = 1;
                    while (iii <= i)
                    {
                        Console.Write("*");
                        iii++;
                    }

                    int ii = 0;
                    while (ii <= i)
                    {
                        Console.Write("*");
                        ii++;
                    }
                    Console.WriteLine();
                }
                Console.ResetColor();
            }

            //Task 1.1.3 ANOTHER TRIANGLE

            static void XmassTree()
            {
                int ni;

                Console.Write("Введите количество треугольников: ");
                string str_ni = Console.ReadLine();
                ni = int.Parse(str_ni);

                for (int n = 1; n <= ni; n++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        for (int iiii = 0; iiii < ni - 1 - i; iiii++)
                        {
                            Console.Write(" ");
                        }

                        int iii = 1;
                        while (iii <= i)
                        {
                            Console.Write("*");
                            iii++;
                        }

                        int ii = 0;
                        while (ii <= i)
                        {
                            Console.Write("*");
                            ii++;
                        }
                        Console.WriteLine();
                    }
                    Console.ResetColor();
                }
            }
            static void SumOfNumbers()
            {
                int sum = 0;
                for (int i = 0; i < 1000; i++)
                {
                    if ((i % 3 == 0) || (i % 5 == 0))
                    {
                        sum = sum + i;
                    }
                }
                Console.WriteLine("Чудная сумма= {0}", sum);
            }
        }
    }
}