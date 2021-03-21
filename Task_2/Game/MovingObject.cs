using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class MovingObject : GameObject, IMovebl, IInteraction
    {
        public void Move(int x, int y)
        { 
        }
        public int ChangeHp()
        {
            throw new NotImplementedException();
        }
    }
}
