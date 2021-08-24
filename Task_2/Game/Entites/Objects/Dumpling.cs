using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;

namespace Game
{
    public class Dumpling : StaticObjects, IFeeding
    {
        public int HealingPower { get; set; } = 1;
        public Dumpling(Location location) : base (location)
        {
        }

        public Dumpling(Location location, int healingP) : base(location)
        {
            HealingPower = healingP;
        }

        void Feeding(MovingObject movingObject)
        {
            movingObject.Hp += HealingPower;
        }
    }
}
