﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.BLL.Interfaces;
using Marketplace.BLL;
using Marketplace.DAO.Interfaces;
//using Task_8.ASP.DAL.UsersAndAdwardsJsonDAO;
using BuyersProductsSqlDAO;

using Marketplace.DAO;


namespace Marketplace.Dependencies
{
    public class DependencyResolver
    {
        public static DependencyResolver _instance;

        public static DependencyResolver Instance
        {
            get
            {
                return _instance = new DependencyResolver(); //добавит проверку ??=
            }
        }


        //private IBuyersDAO BuyersDAO => new BuyersDAO();
        private IBuyersDAO BuyersDAO => new BuyersSqlDAO();
        public IBuyersLogic BuyresLogic => new BuyersLogic(BuyersDAO);

        private IProductsDAO ProductsDAO => new ProductsSqlDAO();
        public IProductsLogic ProductsLogic => new ProductsLogic(ProductsDAO);

        private IBuyersProductsDAO BuyersProductsDAO => new Buyers_ProductsSqlDAO();
        public IBuyersProductsLogic BuyersProductsLogic => new BuyersProductsLogic(BuyersProductsDAO);


        private IBuyersRolesDAO BuyersRolesDAO => new Buyers_RolesSqlDAO();
        public IBuyersRolesLogic BuyersRolesLogic => new BuyersRolesLogic(BuyersRolesDAO);
    }
}
