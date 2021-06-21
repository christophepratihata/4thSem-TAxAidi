using ProjectPSD.Factory;
using ProjectPSD.Model;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Handler
{
    public class UserHandler
    {
        public static User GetUser(string username, string password)
        {
            return UserRepository.GetUser(username, password);
        }

        public static User GetUserById(int id)
        {
            return UserRepository.GetUserById(id);
        }

        public static bool InsertUser(string name, string username, string password, int roleid)
        {
            User testUser = GetUser(username, password);

            if(testUser != null)
            {
                return false;
            }

            User newUser = UserFactory.Create(name, username, password, roleid);

            return UserRepository.InsertUser(newUser);
        }

        public static bool UpdateUser(string username, string password, string name)
        {
            User currUser = GetUser(username, password);

            if (currUser == null)
            {
                return false;
            }

            currUser.Name = name;

            return UserRepository.UpdateUser(currUser);
        }

        public static bool UpdateUser(string username, string password, string name, string newPassword)
        {
            User currUser = GetUser(username, password);

            if (currUser == null)
            {
                return false;
            }

            currUser.Name = name;
            currUser.Password = newPassword;

            return UserRepository.UpdateUser(currUser);
        }
    }
}