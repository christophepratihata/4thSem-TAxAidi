using ProjectPSD.Handler;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Controller
{
    public class UserController
    {
        public static User GetUser(string username, string password)
        {
            return UserHandler.GetUser(username, password);
        }

        public static User GetUserById(int id)
        {
            return UserHandler.GetUserById(id);
        }

        public static string InsertUser(string name, string username, string password,
            string confirmPassword, int roleid)
        {
            if (name.Length < 1 || name.Length > 30)
                return "Name length must be be between 1 and 30 characters";
            if (username.Length < 6 || username.Length > 20)
                return "Username length must be between 6 and 20 characters";
            if (password.Length < 6)
                return "Password length must be at least 6 characters";
            if (roleid == 0)
                return "Role must be choosen";
            if (password != confirmPassword)
                return "Password and Confirm Password must be the same";

            if (!UserHandler.InsertUser(name, username, password, roleid))
            {
                return "Register failed";
            }

            return "Register successfull";
        }

        public static string UpdateUser(string username, string name, string currPassword)
        {
            if (name.Length < 1 || name.Length > 30)
                return "Name length must be be between 1 and 30 characters";

            if (!UserHandler.UpdateUser(username, currPassword, name))
            {
                return "Update Failed";
            }

            return "Update Successfull";
        }

        public static string UpdateUser(string username, string name, string oldPassword, 
            string currPassword, string newPassword, string confirmPassword)
        {
            if (name.Length < 1 || name.Length > 30)
                return "Name length must be be between 1 and 30 characters";
            if (oldPassword != currPassword)
                return "Old Password and New Password must be the same";
            if (newPassword != confirmPassword)
                return "New Password and Confirm Password must be the same";

            if (!UserHandler.UpdateUser(username, currPassword, name, newPassword))
            {
                return "Update Failed";
            }

            return "Update Successfull";
        }
    }
}