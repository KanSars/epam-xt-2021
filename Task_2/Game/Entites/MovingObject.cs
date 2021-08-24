using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;

namespace Game
{
    public abstract class MovingObject : GameObject, IMovable, IDoingDamage, IDestroyable
    {
        public int Hp { get; set; }

        public MovingObject(Location point, int hp) : base(point)
        {
            Hp = hp;
        }
        public abstract void Move(int x, int y);

    }
}
