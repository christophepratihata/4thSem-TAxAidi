using ProjectPSD.Factory;
using ProjectPSD.Model;
using ProjectPSD.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repository
{
    public class UserRepository
    {
        private static MyDatabaseEntities db = DbManager.GetInstance();

        public static User GetUser(string username, string password)
        {
            System.Diagnostics.Debug.WriteLine("Ini yang dicari di DB" + username);
            System.Diagnostics.Debug.WriteLine("Ini yang dicari di DB" + password);
            return (from x in db.Users
                    where
                     x.Username == username &&
                     x.Password == password
                    select x).FirstOrDefault();
        }

        public static User GetUserById(int id)
        {
            return (from x in db.Users
                    where
                     x.Id == id
                    select x).FirstOrDefault();
        }

        public static bool InsertUser(User newUser)
        {
            if(newUser == null)
            {
                return false;
            }

            db.Users.Add(newUser);
            db.SaveChanges();

            return true;
        }

        public static bool UpdateUser(User currUser)
        {
            if(currUser == null)
            {
                return false;
            }

            db.SaveChanges();

            return true;
        }
    }
}