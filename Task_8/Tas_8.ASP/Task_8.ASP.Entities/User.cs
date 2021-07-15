using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8.ASP.Entities
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
        //public DateTime DoB;
        ////public int Age => DateTime.Now.Year - DoB.Year;
        //public int Age;

        //public User(int id, string name)
        //{
        //    Id = id;
        //    Name = name;
        //}

        public User(string name)
        {
            Name = name;
        }
        //public User(string name, DateTime dob)
        //{
        //    Name = name;
        //    DoB = dob;
        //}

        //public User(int id, string name, DateTime dob)
        //{
        //    Id = id;
        //    Name = name;
        //    DoB = dob;
        //}

        //public User(int id, string name, DateTime dob, int age)
        //{
        //    Id = id;
        //    Name = name;
        //    DoB = dob;
        //    //Age = age;
        //}
    }
}
