using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Marketplace.Dependencies;
using Marketplace.Entities;
using NLog;

// функция добавления покупателя:
// должна запускаться одна функция с разными вариантами (указал ли пользователь все поля или оставил пустами)
//ИЛИ: добавить сценарий при внесении не всех необходимых данных типа: вернуть на страницу регистрации с уточнением "Вы не заполнили все необходимые поля"
//а лучше и так и так*



namespace Marketplace.ConsolePL
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            try
            {
                DependencyResolver.Instance.BuyersRolesLogic.AssignAdminRights("qweqwe");
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            


            

            //Console.WriteLine(DependencyResolver.Instance.BuyresLogic.GetBuyer(1).Login);

            //DependencyResolver.Instance.BuyresLogic.AddBuyer("Kolya1");


            //DependencyResolver.Instance.BuyresLogic.AddBuyerData("qwe", "QWE1");
            //DependencyResolver.Instance.BuyresLogic.EditBuyerData("qwe", "QWE11");

            //DependencyResolver.Instance.BuyresLogic.DeleteBuyerData(10);

            //var listof = DependencyResolver.Instance.BuyersRolesLogic.GetRoles("admin");

            //foreach (var item in listof)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("Hello World!");
            ////logger.Error("Error message test");
            //var result = DependencyResolver.Instance.BuyersProductsLogic.GetProductsOfBuyer("qwe");

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Title);
            //}

        }
    }
}
