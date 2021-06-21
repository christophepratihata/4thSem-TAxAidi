using ProjectPSD.Model;
using ProjectPSD.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repository
{
    public class ShowRepository
    {
        private static MyDatabaseEntities db = DbManager.GetInstance();

        public static List<Show> GetAllShows()
        {
            return db.Shows.ToList();
        }

        public static Show GetShowById(int id)
        {
            return (from x in db.Shows where x.Id == id select x).FirstOrDefault();
        }

        public static Show GetShowByName(string name)
        {
            return (from x in db.Shows where x.Name == name select x).FirstOrDefault();
        }

        public static bool InsertShow(Show newShow)
        {
            if (newShow == null)
            {
                return false;
            }

            db.Shows.Add(newShow);
            db.SaveChanges();

            return true;
        }

        public static Show getShowByToken(string token)
        {
            Show show = (from sh in db.Shows
                         join
     th in db.TransactionHeaders on sh.Id equals th.ShowId
                         join
td in db.TransactionDetails on th.Id equals td.TransactionHeaderId
                         where td.Token == token
                         select sh).FirstOrDefault();
            if (show != null)
            {
                return show;
            }
            return null;
        }

        public static bool UpdateShow(Show currShow)
        {
            if (currShow == null)
            {
                return false;
            }

            db.SaveChanges();

            return true;
        }

        public static List<Show> getShowListBySearch(string search)
        {
            return (from x in db.Shows where x.Name.Contains(search) select x).ToList();
        }

        public static bool DeleteShow(Show currShow)
        {
            if (currShow == null)
            {
                return false;
            }

            db.Shows.Remove(currShow);
            db.SaveChanges();

            return true;
        }

        public static string getShowAvgRatingById(int showID)
        {
            var q = (from rvw in db.Reviews
                     join td in db.TransactionDetails on rvw.TransactionDetailId equals td.Id
                     join th in db.TransactionHeaders on td.TransactionHeaderId equals th.Id
                     where th.ShowId == showID
                     select rvw).ToList();
            double result = 0;
            if (q.Count > 0)
            {
                result = q.Average(x => x.Rating);
            }
            double value = (double)System.Math.Round(result, 2);
            return value.ToString();
        }




        public static bool checkBought(DateTime showTime, int buyerIDtemp, int showIDtemp)
        {
            if ((from x in db.TransactionHeaders where buyerIDtemp == x.BuyerId where showIDtemp == x.ShowId where showTime == x.ShowTime select x).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }
    }
}