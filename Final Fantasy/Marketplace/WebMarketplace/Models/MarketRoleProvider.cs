using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Marketplace.Dependencies;

namespace WebMarketplace.Models
{
    public class MarketRoleProvider : RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            var rolesList = DependencyResolver.Instance.BuyersRolesLogic.GetRoles(username);

            return rolesList.Contains(roleName);
        }
        public override string[] GetRolesForUser(string username)
        {
            var rolesList = DependencyResolver.Instance.BuyersRolesLogic.GetRoles(username);

            string[] result = new string[rolesList.Count];

            int i = 0;

            foreach (var role in rolesList)
            {
                result[i] = role;
                i++;
            }

            return result; //TODO проверку
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }


        //public class CalculatorRoleProvider : RoleProvider
        //{

        //    public override bool IsUserInRole(string username, string roleName)
        //    {
        //        var userAndRoleBll = DependencyResolver.Instance.UserAndRoleLogic;

        //        var userRoleName = userAndRoleBll.GetUserAndRoleNames()
        //            .FirstOrDefault(x => x.UserName == username && x.RoleName == roleName);

        //        return userRoleName != null;
        //    }

        //    public override string[] GetRolesForUser(string username)
        //    {
        //        var user = DependencyResolver.Instance.UsersLogic.GetUser(username);
        //        var rolseUser = DependencyResolver.Instance.UserAndRoleLogic.GetRoleByUser(user);

        //        if (rolseUser != null)
        //        {
        //            var result = new string[rolseUser.Count];
        //            int index = 0;
        //            foreach (var item in rolseUser)
        //            {
        //                result[index] = item.Name;
        //                index++;
        //            }
        //            return result;
        //        }
        //        else
        //        {
        //            return new string[] { };
        //        }
        //    }


























        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }



        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}