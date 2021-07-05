using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_8.ASP.Roles.Models
{
    public static class Auth //не лучший вариант static
    {
        public static bool CanLogin(string login, string pass) => login == "admin" || login == "anton";
        //{
        //    bool result = false;
        //    if (login == "admin")
        //    {
        //        result = true;
        //    }
        //    return result; //заглушка (правильнее - обратиться в базу, сравнить хеш..)
        //}
    }
}