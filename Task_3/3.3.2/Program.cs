using System;
using System.Linq;
using System.Collections.Generic;

[Flags]
public enum Styles : byte
{
    None = 0,   //000000
    Rus = 1,    //000001
    Eng = 2,    //000010
    Number = 4, //000100
    Mixed = 8   //001000
}


namespace _3._3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "567ыфв";

            //str.CharCount();

            Console.WriteLine($"Resultat of programm= {str.CharCount()}");
        }
    }
}
public static class ArrayExtension
{
    public static string CharCount(this string arr)
    {
        List<int> list = new List<int>();

        Styles currentStyle = Styles.None;

        byte code;

        string result;

        foreach (int item in arr)
        {
            list.Add(item); // значения вносятся в список вносятся в виде целык в соответствии с Unicod
        }

        foreach (var item in list)
        {
            if (1040 <= item & item <= 1103)
            {
                code = 000001;
                currentStyle = currentStyle | (Styles)code;
                Console.WriteLine($"Yes, currentStyle= {currentStyle}");
            }

            if ((65 <= item & item <= 90) | (97 <= item & item <= 122))
            {
                code = (byte)2;currentStyle = currentStyle | (Styles)code;
                Console.WriteLine($"Yes, currentStyle= {currentStyle}");
            }

            if (48 <= item & item <= 57)
            {
                code = (byte)4;
                currentStyle = currentStyle | (Styles)code;
                Console.WriteLine($"Yes cifera, currentStyle= {currentStyle}");
            }
        }
        if (currentStyle == Styles.Rus || currentStyle == Styles.Eng || currentStyle == Styles.Number)
        {
            result = currentStyle.ToString();
        }
        else
            result = Styles.Mixed.ToString();

        return result;
    }
}
