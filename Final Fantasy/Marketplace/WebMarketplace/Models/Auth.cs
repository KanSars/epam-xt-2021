using Marketplace.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMarketplace.Models
{
    public static class Auth //не лучший вариант static
    {
        public static bool CanLogin(string login, string pass) //=> login == "admin" || login == "anton"; //здесь запрос в базу на проверку пользователя
        {
            return DependencyResolver.Instance.BuyresLogic.IsUserExist(login, pass);
        }
    }
}