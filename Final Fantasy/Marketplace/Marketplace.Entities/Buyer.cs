using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Entities
{
    public class Buyer
    {
        public int Id { get; set; }
        public string Login { get; private set; }
        public string Pass { get; private set; }
        public Buyer()
        {

        }

        public Buyer(int id, string login)
        {
            Id = id;
            Login = login;
        }

        public Buyer(int id, string login, string pass)
        {
            Id = id;
            Login = login;
            Pass = pass;
        }
    }
}
