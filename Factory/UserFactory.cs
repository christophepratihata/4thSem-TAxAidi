using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class UserFactory
    {
        public static User Create(string name, string username, string password, int roleid)
        {
            User newUser = new User();
            newUser.Name = name;
            newUser.Username = username;
            newUser.Password = password;
            newUser.RoleId = roleid;

            return newUser;
        }
    }
}