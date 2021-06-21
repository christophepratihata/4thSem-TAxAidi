using ProjectPSD.Model;
using ProjectPSD.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repository
{
    public class TransactionHeaderRepository
    {
        private static MyDatabaseEntities db = DbManager.GetInstance();

        public static List<TransactionHeader> GetAllTransactionHeaders()
        {
            return db.TransactionHeaders.ToList();
        }

        public static bool InsertTransactionHeader(TransactionHeader newTransactionHeader)
        {
            if (newTransactionHeader == null)
            {
                return false;
            }

            db.TransactionHeaders.Add(newTransactionHeader);
            db.SaveChanges();

            return true;
        }

        public static List<TransactionGridList> getTransactionGridListByUserID(int buyerIDtemp)
        {
            var query = (from th in db.TransactionHeaders
                         join td in db.TransactionDetails on th.Id equals td.TransactionHeaderId
                         join sh in db.Shows on th.ShowId equals sh.Id
                         where th.BuyerId == buyerIDtemp
                         group new { th, sh, td } by th into g
                         select new
                         {
                             Id = g.Key.Id,
                             CreatedAt = g.Key.CreatedAt,
                             ShowName = g.Select((x => x.sh.Name)).FirstOrDefault(),
                             ShowTime = g.Key.ShowTime,
                             Quantity = g.Select((x => x.td.TransactionHeaderId)).Count(),
                             TotalPrice = g.Select((x => x.sh.Price)).FirstOrDefault(),
                         }).ToList().Select(x => new TransactionGridList
                         {
                             Id = x.Id,
                             CreatedAt = x.CreatedAt,
                             ShowName = x.ShowName,
                             ShowTime = x.ShowTime,
                             Quantity = x.Quantity,
                             TotalPrice = (x.TotalPrice) * (x.Quantity)
                         }).ToList();
            return query;
        }

        public static List<TransactionHeader> GetHeaderListBySellerId(int id)
        {
            return (from x in db.TransactionHeaders
                    join sh in db.Shows on x.ShowId equals sh.Id
                    where sh.SellerId == id
                    select x).ToList();
        }

        public static bool isShowTime(string token)
        {
            TransactionHeader th = (from x in db.TransactionHeaders
                                    join td in db.TransactionDetails on x.Id equals td.TransactionHeaderId
                                    where td.Token == token
                                    select x).FirstOrDefault();
            if (th != null)
            {
                if (DateTime.Now > th.ShowTime && th.ShowTime.AddHours(1) > DateTime.Now) //jika waktu sekarang lebih besar dari jam mulai show                                                                                           
                {                                                                         // dan lebih kecil dari akhir show (show time + 1 jam)
                    return true;
                }
            }
            return false;
        }

        public static bool isPastShowTime(string token)
        {
            TransactionHeader th = (from x in db.TransactionHeaders
                                    join td in db.TransactionDetails on x.Id equals td.TransactionHeaderId
                                    where token == td.Token
                                    select x).FirstOrDefault();
            if (th != null)
            {
                if (DateTime.Now > th.ShowTime.AddHours(1)) //Jika waktu sekarang udah lewat dari show Time (1 jam + waktu mulai film)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool cancelTransaction(TransactionHeader th)
        {
            if (th != null)
            {
                db.TransactionHeaders.Remove(th);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static TransactionHeader getHeaderByID(int headerIDtemp)
        {
            return (from x in db.TransactionHeaders where x.Id == headerIDtemp select x).FirstOrDefault();
        }

        public static bool userOwnThisTransaction(int buyerIDtemp, int headerId)
        {
            TransactionHeader th = (from x in db.TransactionHeaders where x.BuyerId == buyerIDtemp where x.Id == headerId select x).FirstOrDefault();
            if (th != null)
            {
                return true;
            }
            return false;
        }

        public static bool isBeforeShowTime(int headerId)
        {
            TransactionHeader th = (from x in db.TransactionHeaders
                                    where DateTime.Now < x.ShowTime
                                    where x.Id == headerId
                                    select x).FirstOrDefault();
            if (th != null)
            {
                return true;
            }
            return false;
        }

    }
}