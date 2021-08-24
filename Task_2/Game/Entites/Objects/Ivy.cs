using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;

namespace Game
{
    public class Ivy : StaticObjects, IDoingDamage
    {
        public int Power { get; set; } = 1;
        public Ivy(Location location) : base(location)
        {
        }

        public void Attack(MovingObject movingObject)
        {
            movingObject.Hp -= Power;
        }

    }
}
