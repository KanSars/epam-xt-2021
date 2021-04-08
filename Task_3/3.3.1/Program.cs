using System;
using System.Linq;
using System.Collections.Generic;

namespace _3._3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] s = { 1, 2, 4, 4};

            ArrayExtension.Action action = DoSomething;

            s.CharCount(action);

            foreach (var item in s)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine($"Сумма элементов массива= {s.SummOfElements()}");

            Console.WriteLine($"Среднее значение элементов массива= {s.AverageOfElements()}");

            Console.WriteLine($"Наиболее часто повторяющийся элемент массива= {s.MoreOften()}");
        }

        public static int DoSomething(int value)
        {
            value++;
            return value;
        }
    }
}

public static class ArrayExtension
{
    public delegate int Action(int x);
    public static void CharCount(this int[] arr, Action del) // можно через Funk<>
    {
        if (del != null)    // или del?.Invoke(arr[i]) т.к. void (но здесь цикл - поэтому так лучше)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = del(arr[i]);
            }
        }

    }

    public static int SummOfElements(this int[] arr, int summOfElements = 0)
    {
        for (int i = 0; i < arr.Length; i++)
            summOfElements += arr[i];

        return summOfElements;
    }

    public static double AverageOfElements(this int[] arr, double summOfElements = 0, double average = 0)
    {
        for (int i = 0; i < arr.Length; i++)
            summOfElements += arr[i];
         
        average = summOfElements / arr.Length;

        return average;
    }

    public static int MoreOften(this int[] arr)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int result = 0;

        foreach (var item in arr)
        {
            if (!dict.ContainsKey(item)) dict.Add(item, 1);
            else dict[item] += 1;
        }

        int maxValue = 0;

        if (dict.Values.Max() > 1)
        {
            foreach (var item in dict)
            {
                if (item.Value > maxValue)
                {
                    result = item.Key;
                    maxValue = item.Value;
                }
            }
        }
        
        return result;
    }
}

