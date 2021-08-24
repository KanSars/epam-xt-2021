using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;

namespace Game
{
    public abstract class GameObject
    {
        public Location location { get; set; }

        public GameObject(Location point)
        {
            location = point;
        }

    }
}
