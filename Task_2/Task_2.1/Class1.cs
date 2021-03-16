using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._1
{
    class Circle
    {
        int x = 0;
        int y = 0;
        int r = 0;
        public Circle(int radius)
        {
            int r = radius;
        }
        public double LengthCircle()
            {
                double length;
                length = 2 * Math.PI * this.r;
                return length;
            }
    }
    class Round : Circle
    {
        int x = 0;
        int y = 0;
        int r = 0;

        public Round(int radius) : base(radius)
        {
            this.r = radius;
        }

        public double SqrOfRound()
        {
            double result;
            result = Math.PI * this.r * this.r / 2; 
            return result;
        }

    }

    class Ring
    {
        private Round innerRing;
        private Round outerRing;
        public Ring()
        {
            this.innerRing = new Round(3);
            this.outerRing = new Round(5);
        }
        public Ring(int innerR, int outerR)
        {
            this.innerRing = new Round(innerR);
            this.outerRing = new Round(outerR);
        }
        public double SqrOfRing()
        {
            double square;
            square = outerRing.SqrOfRound() - innerRing.SqrOfRound(); 
            return square;

        }
    }
    class Paint
    {
        
    }
}
