using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Panda : MovingObject
    {
        public int Power { get; set; } = 1;

        public Panda(Location point, int hp) : base(point, hp)
        {
            Hp = hp + 1;
        }
        public Panda(Location point, int hp, int power) : base(point, hp)
        {
            Power = power;
        }
        public void Attack(MovingObject movingObject)
        {
            movingObject.Hp -= Power;
        }
        public override void Move(int x, int y)
        {
            location.Row += x;
            location.Collumn += y;
        }

    }
}
