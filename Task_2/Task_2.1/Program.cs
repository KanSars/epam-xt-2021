using System;
using System.Text;

namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите строку:");

            string phrase = "asdf";
            string phrase2 = "asdf";
            
            MyString row = new MyString(phrase);

            //проверяем класс и метод: выводит сумму символов массивов, т.к. класс содержит строку как массив
            char[] s3 = row.ConCat(phrase2);
            foreach (var item in s3)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class MyString
    {
        char[] stringInMassiv;

        public MyString(string phrase)
        {
            this.stringInMassiv = new char[phrase.Length];
            
            for (int i = 0; i < phrase.Length; i++)
            {
                this.stringInMassiv[i] = phrase[i];
            }
        }
        public int CompareLength(string phrase2)
        {
            int result;

            if (this.stringInMassiv.Length > phrase2.Length)
                result = 1;
            else if (this.stringInMassiv.Length < phrase2.Length)
                result = -1;
            else result = 0;
            return result;
        }
        public char[] ConCat(string phrase2)
        {
            char[] summOfMassivs;
            summOfMassivs = new char[stringInMassiv.Length + phrase2.Length];

            for (int i = 0; i <this.stringInMassiv.Length; i++)
            {
                summOfMassivs[i] = this.stringInMassiv[i];
            }

            for (int i = 0; i < phrase2.Length; i++)
            {
                summOfMassivs[i + stringInMassiv.Length] = phrase2[i];
            }
            return summOfMassivs;
        }

        public string FindIt(char a)
        {
            var result = new StringBuilder();
            result = null;

            for (int i = 0; i < this.stringInMassiv.Length; i++)
            {
                if (stringInMassiv[i] == a)
                    result.Append(i);
            }
            return result.ToString();
        }
        public string MyToString()
        {
            var result = new StringBuilder();
            result = null;

            for (int i = 0; i < this.stringInMassiv.Length; i++)
            {
                    result.Append(stringInMassiv[i]);
            }
            return result.ToString();
        }
    }
}