using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8.ASP.Entities
{
    public class ListOfUsers
    {
        //private static ListOfUsers _instance;

        //public static ListOfUsers Instance
        //{
        //    get
        //    {
        //        return _instance ??= new ListOfUsers();
        //    }
        //}


        public List<User> listOfUsers = new List<User>();
    }

}
