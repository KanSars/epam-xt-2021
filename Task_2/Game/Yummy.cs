using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Yummy : StaticObjects, IInteraction // вкусняшка увеличивает Нр
    {
        int Hp = 1;
        public Yummy(Location location) : base(location)
        {
        }
        public int ChangeHp()
        {
            throw new NotImplementedException();
        }
    }
}
