using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
