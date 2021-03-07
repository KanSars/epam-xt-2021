using System;
/* Написать программу, которая определяет площадь прямоугольника со сторонами a и b.
 Если пользователь вводит некорректные знаения (отрицательные или ноль), должно выдаваться сообщение об ошибке.
 Возможность ввода пользователем строки вида "абвгд" или нецелых чисел игнорировать.
*/
namespace Task_1._1
{
    class Program
    {
        static void Main(string[] args)
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
    }
}
