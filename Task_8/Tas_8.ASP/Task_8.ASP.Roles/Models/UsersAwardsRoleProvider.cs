﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Task_8.ASP.Roles.Models
{
    public class UsersAwardsRoleProvider : RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            return (username == "admin" && roleName == "admin") ||
                (username == "admin" && roleName == "users") ||
                (username == "admin" && roleName == "admin");
        }
        public override string[] GetRolesForUser(string username)
        {
            if (username == "admin")
                return new[] { "users", "admin" };
            else if (username == "anton")
                return new[] { "users" };
            else return new string[] { };
            
        }

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

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