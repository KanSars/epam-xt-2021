using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Leopard : MovingObject
    {
        public int Power { get; set; } = 1;
        public Leopard(Location point, int hp) : base(point, hp)
        {
        }

        public Leopard(Location point, int hp, int power) : base(point, hp)
        {
            Power = power + 1;
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
