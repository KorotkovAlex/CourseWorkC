using MvcApplication5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

public class MyRoleProvider : RoleProvider
{
    public static bool Role(string username, string[] roleName)
    {
        bool outputResult = false;
        using (flowofdocumentEntities _db = new flowofdocumentEntities())
        {
            foreach (var rn in roleName)
            {
                var user = (from u in _db.Employee
                            where u.login == username
                            select u).FirstOrDefault();
                if (user != null)
                {
                    var role = user.Role;

                    if (role.name.Equals(rn))
                    {
                        outputResult = true;
                    }
                }
            }
        }
        return outputResult;
    }

    public override void AddUsersToRoles(string[] usernames, string[] roleNames)
    {
        throw new NotImplementedException();
    }

    public override string ApplicationName
    {
        get
        {
            throw new NotImplementedException();
        }
        set
        {
            throw new NotImplementedException();
        }
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

    public override string[] GetRolesForUser(string username)
    {
        string[] role = new string[] { };
        using (flowofdocumentEntities _db = new flowofdocumentEntities())
        {
            try
            {
                // Получаем пользователя
                var user = (from u in _db.Employee
                            where u.login == username
                            select u).FirstOrDefault();
                if (user != null)
                {
                    // получаем роль
                    var userRole = (from u in _db.Role
                                    where u.IdRole == user.idRole
                                    select u).FirstOrDefault();

                    if (userRole != null)
                    {
                        role = new string[] { userRole.name };
                    }
                }
            }
            catch
            {
                role = new string[] { };
            }
        }
        return role;
    }

    public override string[] GetUsersInRole(string roleName)
    {
        throw new NotImplementedException();
    }

    public override bool IsUserInRole(string username, string roleName)
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