using System;
using System.Collections.Generic;

namespace Marketplace.DAO.Interfaces
{
    public interface IBuyersRolesDAO
    {
        List<string> GetRoles(string login);

        void AddRoleForBuyer(string login);

        void AssignAdminRights(string login);

        void RevokeAdminRights(int idBuyer);
    }
}
