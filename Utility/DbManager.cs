using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Utility
{
    public class DbManager
    {
        private static MyDatabaseEntities db;

        private DbManager()
        {

        }

        public static MyDatabaseEntities GetInstance()
        {
            if(db == null)
            {
                db = new MyDatabaseEntities();
            }

            return db;
        }
    }
}