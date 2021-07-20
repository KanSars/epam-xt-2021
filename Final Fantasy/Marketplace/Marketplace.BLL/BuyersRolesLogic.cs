using Marketplace.BLL.Interfaces;
using System.Collections.Generic;
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

        public List<string> GetRoles(string login)
        {
            return _buyersRolesDAO.GetRoles(login);
        }

        public void AddRoleForBuyer(string login)
        {
            _buyersRolesDAO.AddRoleForBuyer(login);
        }

        public void AssignAdminRights(string login)
        {
            _buyersRolesDAO.AssignAdminRights(login);
        }

        public void RevokeAdminRights(int idBuyer)
        {
            _buyersRolesDAO.RevokeAdminRights(idBuyer);
        }
    }
}
