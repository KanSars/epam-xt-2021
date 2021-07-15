using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_8.ASP.Roles.Models
{
    public static class Auth //temp static
    {
        public static bool CanLogin(string login, string pass) => login == "admin" || login == "anton";

    }
}