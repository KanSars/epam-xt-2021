using Marketplace.BLL.Interfaces;
using Marketplace.Entities;
using Marketplace.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//причесать (подсократить количество команд с обращением в DAL (можно тут на месте решить без DAL)

namespace Marketplace.BLL
{
    public class BuyersLogic : IBuyersLogic
    {
        private IBuyersDAO _buyersDAO;

        public BuyersLogic(IBuyersDAO listDao)
        {
            _buyersDAO = listDao;
        }

        private IBuyersProductsDAO _buyersProductsDAO;
        public BuyersLogic(IBuyersProductsDAO listDAO)
        {
            _buyersProductsDAO = listDAO;
        }
        public void AddBuyer(string login, string pass)
        {
            //добавить проверку на совпадение(наличие) Login

            _buyersDAO.AddBuyer(login, pass);
        }

        public List<Buyer> GetAllBuyers()
        {
            return _buyersDAO.GetAllBuyers();
        }

        public List<BuyerData> GetBuyersDataList()
        {
            return _buyersDAO.GetBuyersDataList();
        }

        public Buyer GetBuyer(int id)
        {
            return _buyersDAO.GetBuyer(id);
        }

        public int GetIdBuyer(string login)
        {
            return _buyersDAO.GetIdBuyer(login);
        }

        public void DeleteBuyer(int idBuyer)
        {
            _buyersDAO.DeleteBuyer(idBuyer);
        }

        public void AddBuyerData(string login, string name, string surname, DateTime doB, string email)
        {
            _buyersDAO.AddBuyerData(login, name, surname, doB, email);
        }

        //public void EditBuyerData(string login, string name)
        //{
        //    _buyersDAO.EditBuyerData(login, name);
        //}

        public void EditBuyerData(string login, string name, string surname, DateTime doB, string email)
        {
            _buyersDAO.EditBuyerData(login, name, surname, doB, email);
        }

        public BuyerData GetBuyerData(string login)
        {
            return _buyersDAO.GetBuyerData(login);
        }

        public void DeleteBuyerData(int idBuyer)
        {
            _buyersDAO.DeleteBuyerData(idBuyer);
        }

        public bool IsUserExist(string login, string pass)
        {
            return _buyersDAO.IsUserExist(login, pass);
        }

        public void DeleteBuyerById(int idBuyer)
        {
            _buyersDAO.DeleteBuyer(idBuyer);
            _buyersDAO.DeleteBuyerData(idBuyer);
            _buyersProductsDAO.DeleteProductFromCart(idBuyer);
        }
    }
}
