using ProjectPSD.Model;
using ProjectPSD.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repository
{
    public class TransactionDetailRepository
    {
        private static MyDatabaseEntities db = DbManager.GetInstance();

        public static bool InsertTransactionDetail(TransactionDetail newTransactionDetail)
        {
            if (newTransactionDetail == null)
            {
                return false;
            }

            db.TransactionDetails.Add(newTransactionDetail);
            db.SaveChanges();

            return true;
        }

        public static bool UpdateTransactionDetailStatus(TransactionDetail currTransactionDetail)
        {
            if (currTransactionDetail == null)
            {
                return false;
            }

            db.SaveChanges();

            return true;
        }

        public static List<TransactionDetail> getTokenListByHeaderID(int headerId)
        {
            List<TransactionDetail> listToken = (from x in db.TransactionDetails where x.TransactionHeaderId == headerId select x).ToList();
            return listToken;
        }

        public static bool checkTokenIsUsed(string token)
        {
            TransactionDetail td = (from x in db.TransactionDetails
                                    where token == x.Token
                                    select x).FirstOrDefault();
            if (td != null && td.StatusId == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static TransactionDetail GetTransactionDetailByToken(string token)
        {
            TransactionDetail td = (from x in db.TransactionDetails
                                    where x.Token == token
                                    select x).FirstOrDefault();
            if (td != null)
            {
                return td;
            }
            return null;
        }

        public static bool isTokenUnused(int headerId)
        {
            TransactionDetail td = (from x in db.TransactionDetails
                                    where x.TransactionHeaderId == headerId
                                    where x.StatusId == 2
                                    select x).FirstOrDefault();
            if (td != null)
            {
                return false;
            }
            return true;
        }

        public static string GetTokenStatusByDetailID(int id)
        {
            TransactionDetail td = (from x in db.TransactionDetails where id == x.Id select x).FirstOrDefault();
            if (td != null && td.StatusId == 1)
            {
                return "Unused";
            }
            else
            {
                return "Used";
            }
        }

        public static List<TransactionDetail> GetDetailListByHeaderId(int id)
        {
            return (from x in db.TransactionDetails join th in db.TransactionHeaders
                    on x.TransactionHeaderId equals th.Id where id == x.TransactionHeaderId
                    select x).ToList();
        }
    }
}