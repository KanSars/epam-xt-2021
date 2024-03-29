﻿using System;
using System.Collections.Generic;
using Marketplace.Entities;

namespace Marketplace.BLL.Interfaces
{
    public interface IBuyersLogic
    {
        void AddBuyer(string login, string pass);

        List<Buyer> GetAllBuyers();

        List<BuyerData> GetBuyersDataList();

        Buyer GetBuyer(int id);

        int GetIdBuyer(string login);

        void DeleteBuyer(int idBuyer);

        void AddBuyerData(string login, string name, string surname, DateTime doB, string email);

        //void EditBuyerData(string login, string name);
        void EditBuyerData(string login, string name, string surname, DateTime doB, string email);

        BuyerData GetBuyerData(string login);

        void DeleteBuyerData(int idBuyer);

        bool IsUserExist(string login, string pass);

        void DeleteBuyerById(int idBuyer);
    }
}
