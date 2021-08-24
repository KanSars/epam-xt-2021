using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Location
    {
        public int Row { get; set; }
        public int Collumn { get; set; }
        public Location(int X, int Y)
        {
            Row = X;
            Collumn = Y;
        }
    }
}
