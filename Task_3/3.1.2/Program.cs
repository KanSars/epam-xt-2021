using System;
using System.Collections.Generic;

namespace _3._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст");
            Console.WriteLine();

            var dict = new Dictionary<string, int>();
            
            string[] line;
            line = Console.ReadLine().ToLower().Split(" ,.?!\'()\"".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var word in line)
            {
                if (!dict.ContainsKey(word)) dict.Add(word, 1);
                else dict[word.ToString()] += 1;
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"word= {item.Key} repeated= {item.Value}");
            }

            Console.WriteLine();
            Console.WriteLine("Вы в любом случае молодец!");
        }
    }
}
