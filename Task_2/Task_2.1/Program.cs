using System;

namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Ring qqq;
            qqq = new Ring(2, 4);

            Console.WriteLine($"qqq= {qqq.SqrOfRing()}");

            MyPoint point;
            point = new MyPoint();
            point.x = 7;

            int a = point.InternalSumm();

            int c = 9;
            int b = point.ExternalSumm(a, 9);

            

            string phrase;
            phrase = Console.ReadLine();
            string phrase2;
            phrase2 = Console.ReadLine();

            MyString myString;
            myString = new MyString();

            // myString.SetSymbolsNewValue(phrase);
            Console.WriteLine($"myString.symbols= {myString.symbols}");
            Console.WriteLine($"myString.symbols= {Convert.ToString(myString.SetSymbolsNewValue(phrase))}");


            MyString MyStrResult;
            MyStrResult = new MyString();
            int count = 0;
            count = MyStrResult.MyCompare(phrase, phrase2);

            Console.WriteLine($"count= {count}");

            Console.WriteLine(MyStrResult.MyConCat(phrase, phrase2));
        }
    }

    class MyString
    {
        public char[] symbols;
        public char[] symbols2;

        //public MyString(string phrase)
        //{
        //     this.symbols = phrase.ToCharArray();
        //    // this.SetSymbolsNewValue(phrase);
        //}

        public char[] SetSymbolsNewValue(string phrase)
        {
            this.symbols = phrase.ToCharArray();
           return this.symbols;
        }

        public int MyCompare(string phrase, string phrase2)
        {
            int temp1;
            int temp2;
            int result=0;
            temp1 = (SetSymbolsNewValue(phrase)).Length;
            temp2 = (SetSymbolsNewValue(phrase2)).Length;

            if (temp1 > temp2)
                result = 1;
            else if (temp1 < temp2)
                result = -1;
            else result = 0;

            return result;
        }
        public string MyConCat(string phrase, string phrase2)
        {
            return (phrase + phrase2);
        }
    }

    class MyPoint
    {
        public int x = 5;
        public int y = 6;
        public int InternalSumm()
        { return (this.x + this.y);  }
        public int ExternalSumm(int x, int y)
        { return (x + y); }
    }
}
    
