using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Ivy : StaticObjects, IHurt // плющ
    {
        int x;
        int y;
        public Ivy(Location location) : base(location)
        {
            this.x = location.row;
            this.y = location.collumn;
        }

    }
}
