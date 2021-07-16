using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Entities;

namespace Marketplace.DAO.Interfaces
{
    public interface IBuyersDAO
    {
        void AddBuyer(string login, string pass);

        Buyer GetBuyer(int id);

        List<Buyer> GetAllBuyers();

        List<BuyerData> GetBuyersDataList();

        void DeleteBuyer(int idBuyer);

        int GetIdBuyer(string login);

        void AddBuyerData(string login, string name, string surname, DateTime doB, string email);

        void EditBuyerData(string login, string name, string surname, DateTime doB, string email);

        BuyerData GetBuyerData(string login);

        void DeleteBuyerData(int idBuyer);

        bool IsUserExist(string login, string pass);

    }
}
