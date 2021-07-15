using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8.Entities
{
    /*User: 
     * Id,
     * Name, 
     * DateOfBirth, 
     * Age
    */
    public class User
    {
        public int Id;
        public string Name;

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
