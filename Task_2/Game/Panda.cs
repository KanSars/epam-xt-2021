using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Panda : MovingObject
    {
        public int Hp = 9;
        public int PandaHp()
        {
            this.Hp = 10;
            return Hp;
        }
        public new void Move(int x, int y)
        {
        }
    }
}
