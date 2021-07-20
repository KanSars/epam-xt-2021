using System.Collections.Generic;

namespace Marketplace.BLL.Interfaces
{
    public interface IBuyersRolesLogic
    {
        List<string> GetRoles(string login);

        void AddRoleForBuyer(string login);

        void AssignAdminRights(string login);

        void RevokeAdminRights(int idBuyer);
    }
}
