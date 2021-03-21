using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public struct Location
    {
        public int row;
        public int collumn;
        public Location(int X, int Y)
        {
            this.row = X;
            this.collumn = Y;
        }
    }
}
