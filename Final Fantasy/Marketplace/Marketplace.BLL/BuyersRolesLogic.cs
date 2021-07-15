using Marketplace.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.DAO;
using Marketplace.DAO.Interfaces;

namespace Marketplace.BLL
{
    public class BuyersRolesLogic : IBuyersRolesLogic
    {
        private IBuyersRolesDAO _buyersRolesDAO;
        public BuyersRolesLogic(IBuyersRolesDAO listDAO)
        {
            _buyersRolesDAO = listDAO;
        }


        public List<string> GetRolesOfBuyer(string login)
        {
            return _buyersRolesDAO.GetRolesOfBuyer(login);
        }

        public void AddRoleForBuyer(string login)
        {
            _buyersRolesDAO.AddRoleForBuyer(login);
        }

        public void AddAdminRoleForBuyer(string login)
        {
            _buyersRolesDAO.AddAdminRoleForBuyer(login);
        }
    }
}
