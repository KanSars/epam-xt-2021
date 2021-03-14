using System;
using System.Text;
[Flags]
public enum Styles : byte
{
    None = 0,
    Bold = 1,
    Italic = 2,
    Underline = 4,
}

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
            Console.WriteLine("6: FONT ADJUSMENT");
            Console.WriteLine("7: ARRAY PROCESSING");
            Console.WriteLine("8: NO POSITIVE");
            Console.WriteLine("9: NON - NEGATIVE SUM");
            Console.WriteLine("10: 2D ARRAY");
            Console.WriteLine("21: AVERAGES");
            Console.WriteLine("22: DOUBLER");
            Console.WriteLine("23: LOWERCASE");

            Console.WriteLine();

            Console.Write("Укажите номер программы: ");
            //string str_task = Console.ReadLine();
            //int task = int.Parse(str_task);
            Console.WriteLine();
            int task = 6;

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
                case 6:
                    FontAdjusment();
                    break;
                case 12:
                    Triangle_V1();
                    break;
                case 7:
                    ArrayProcessing();
                    break;
                case 8:
                    NoPositive();
                    break;
                case 9:
                    NoNegative();
                    break;
                case 10:
                    DArray();
                    break;
                case 21:
                    Averages();
                    break;
                case 22:
                    Doubler();
                    break;
                case 23:
                    Lowercase();
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
                for (int i = 0; i <= n; i++)
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

                    for (int iiii = 0; iiii < n - 1 - i; iiii++)
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

            static void ArrayProcessing()
            // чет подзастрял..
            {


                // int[] arr = { 2, 7, 8, 5, 9 };
                int n = 5;
                int[] arr = new int[n];

                Random r = new Random();
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = r.Next(1, 29);
                }

                foreach (int item in arr)
                {
                    Console.WriteLine(item);
                }

                int min = arr[0];
                int max = arr[0];

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] < min)
                    {
                        min = arr[i];
                    }
                    if (arr[i] > max)
                    {
                        max = arr[i];
                    }
                }

                Console.WriteLine($"min= {min}, max= {max}");

                for (int i = 1; i < arr.Length; i++)
                {
                    for (int j = 0; j < arr.Length - i; j++)
                    {
                        if (arr[j] > arr[j + 1])
                        {
                            int temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;
                        }
                    }
                }

                foreach (int item in arr)
                {
                    Console.WriteLine(item);
                }


            }

            static void NoPositive()
            {
                int n = 3;
                int m = 2;
                int l = 2;
                int[,,] arr = new int[n, m, l];

                Random r = new Random();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        for (int q = 0; q < l; q++)
                        {
                            arr[i, j, q] = r.Next(-29, 29);
                        }
                    }
                }

                foreach (int item in arr)
                {
                    Console.WriteLine(item);
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        for (int q = 0; q < l; q++)
                        {
                            if (arr[i, j, q] < 0)
                            {
                                arr[i, j, q] = 0;
                            }
                        }
                    }
                }

                foreach (int item in arr)
                {
                    Console.WriteLine(item);
                }
            }

            static void NoNegative()
            {
                int n = 15;
                int[] arr = new int[n];

                Random r = new Random();
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = r.Next(-19, 19);
                }

                foreach (int item in arr)
                {
                    Console.WriteLine(item);
                }

                int sum = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > 0)
                    {
                        sum = sum + arr[i];
                    }

                }

                foreach (int item in arr)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine($"sum= {sum}");
            }
            static void DArray()
            {
                int n = 3;
                int m = 2;
                int[,] arr = new int[n, m];

                int q = 1;
                Random r = new Random();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        //arr[i, j] = r.Next(-29, 29);
                        arr[i, j] = q;
                        q++;
                    }
                }

                foreach (int item in arr)
                {
                    Console.WriteLine(item);
                }

                int sum = 0;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (((i + j) % 2) == 0)
                        {
                            sum = sum + arr[i, j];
                        }
                    }
                }
                sum = sum - arr[0, 0];
                //Console.WriteLine($"arr[0,0]= {arr[0, 0]}");
                Console.WriteLine($"Sum= {sum}");
            }

            static void Averages()
            {
                string phrase = "The quick brown fox jumps over the lazy   dog.";
                Console.WriteLine(phrase);
                string Trimphrase = phrase.Trim(new char[] { '.', ',', '!', '?', ':' });
                //Console.WriteLine(Trimphrase);
                string[] words = Trimphrase.Split(' ');

                int qwords = 0;
                int sum = 0;
                for (int i = 0; i < words.Length; i++)
                {
                    //Console.WriteLine($"count= {words[i]}");
                    int count;
                    count = words[i].Length;
                    //Console.WriteLine($"Length= {count}");
                    sum = sum + count;

                    if (count != 0)
                        qwords++;
                    // Console.WriteLine($"qwords= {qwords}");
                    //Console.WriteLine($"sum= {sum}");
                    //Console.WriteLine();
                }
                double average = (double)sum / qwords; //выводи дробное число "double/int=>double"
                // double average = sum / qwords; //выводит целое число "int/int=>int"
                Console.WriteLine($"average= {average}");
            }

            static void Doubler0()
            {
                string phrase = "asdfs";
                Console.WriteLine($"{phrase}");

                string word = "s";
                Console.WriteLine($"{word}");

                for (int i = 0; i < phrase.Length; i++)
                {
                    if (word.Contains(phrase[i]))
                    {
                        //Console.WriteLine($"{phrase}");
                        //Console.WriteLine($"phrase[i]= {phrase[i]}");
                        phrase = phrase.Insert(i, phrase[i].ToString());
                        i++;
                    }
                }
                Console.WriteLine($"{phrase}");
            }

            static void Doubler()
            {
                string phrase = "asdfs";
                Console.WriteLine($"phrase= {phrase}");

                string word = "smnb";
                Console.WriteLine($"word= {word}");

                char[] letter = word.ToCharArray();

                for (int i = 0; i < phrase.Length;)
                {
                    for (int ii = 0; ii < letter.Length; ii++)
                    {
                        if (letter[ii] == phrase[i])
                        {
                            //Console.WriteLine($"YES");
                            phrase = phrase.Insert(i + 1, letter[ii].ToString());
                            i++;
                        }
                    }
                    i++;
                }
                Console.WriteLine($"result= {phrase}");
            }

            static void Lowercase0()
            {
                string phrase = " A aa a.aa,aa .  ";
                int ind = phrase.IndexOf(' ');
                int count = 0;

                for (int i = 0; i < phrase.Length - 1; i++)
                {
                    if (phrase[i] == ' ' && Char.IsLower(phrase[i + 1]))
                    {
                        int t = i + 1;
                        count++;
                    }
                }
                Console.WriteLine($"result= {count}");
            }

            static void Lowercase()
            {
                string phrase = " A a a.aa,aa .  ";
                int ind = phrase.IndexOf(' ');
                int count = 0;

                for (int i = 0; i < phrase.Length - 1; i++)
                {
                    if ((phrase[i] == ' ' || phrase[i] == '.' || phrase[i] == ',' || phrase[i] == ':' || phrase[i] == ';')
                        && Char.IsLower(phrase[i + 1]))
                    {
                        int t = i + 1;
                        count++;
                    }
                }
                Console.WriteLine($"result= {count}");
            }


            static void FontAdjusment()
            {
                
                Styles currentStyle = Styles.None;

                
                string input;

                do
                {
                    Console.WriteLine($"Параметры надписи: {currentStyle}");
                    lines();

                    input = Console.ReadLine();

                    foreach (var chr in input)
                {
                       
                    byte code;

                    code = Convert.ToByte(chr.ToString());

                        Console.WriteLine($"code= {code}");
                        if (code == 3)
                        {
                            code = 4;
                        }

                        Console.WriteLine($"(Styles)code= {(Styles)code}");
                      
                   // if (byte.TryParse(chr.ToString(), out code))
                    {
                        switch ((Styles)code)
                        {
                            case Styles.Bold:
                            case Styles.Italic:
                            case Styles.Underline:
                                currentStyle = currentStyle ^ (Styles)code;
                                break;
                        }
                    }
                }
                    Console.WriteLine($"Параметры надписи: {currentStyle}");
                    Console.WriteLine();
                } while (Convert.ToInt32(input) != 0);
                
                void lines()
                {
                    Console.WriteLine("1: bold");
                    Console.WriteLine("2: italik");
                    Console.WriteLine("3: underline");
                }

            }

        }
    }
}