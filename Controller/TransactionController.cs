using ProjectPSD.Handler;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Controller
{
    public class TransactionController
    {
        private static Random random = new Random();

        public static string InsertTransaction(int buyerid, int showid, DateTime showtime,
            DateTime createdat, int quantity)
        {
            if (quantity <= 0)
                return "Quantity must be above 0";

            TransactionHeader newTransactionHeader = 
                TransactionHeaderHandler.InsertTransactionHeader(buyerid, showid, showtime, createdat);

            int statusid = 1;
            int TransactionHeaderID = newTransactionHeader.Id;

            for(int i=0; i<quantity; i++)
            {
                string token = "";
                token = RandomStringGenerator(6);
                TransactionDetailHandler.InsertTransactionDetail(TransactionHeaderID, statusid, token);
            }

            return "Order Success";
        }

        public static bool IsShowTime(string token)
        {
            return TransactionHeaderHandler.isShowTime(token);
        }

        public static TransactionDetail GetTransactionDetailByToken(string token)
        {
            return TransactionDetailHandler.GetTransactionDetailByToken(token);
        }

        public static List<TransactionHeader> GetHeaderListBySellerId(int id)
        {
            return TransactionHeaderHandler.GetHeaderListBySellerId(id);
        }

        public static bool isPastShowTime(string token)
        {
            return TransactionHeaderHandler.isPastShowTime(token);
        }

        public static bool checkTokenIsUsed(string token)
        {
            return TransactionDetailHandler.checkTokenIsUsed(token);
        }

        public static string RandomStringGenerator(int length)
        {
            const string chars = "QWERTYUIOPASDFGHJKLZXCVBNM";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static List<TransactionDetail> getTokenListByHeaderID(int headerId)
        {
            return TransactionDetailHandler.getTokenListByHeaderID(headerId);
        }

        public static List<TransactionDetail> GetDetailListBySellerId(int id)
        {
            return TransactionDetailHandler.GetDetailListByHeaderId(id);
        }

        public static bool userOwnThisTransaction(int buyerIDtemp, int headerId)
        {
            return TransactionHeaderHandler.userOwnThisTransaction(buyerIDtemp, headerId);
        }

        public static string GetTokenStatusByDetailID(int id)
        {
            return TransactionDetailHandler.GetTokenStatusByDetailID(id);
        }

        public static List<TransactionGridList> getTransactionGridListByUserID(int buyerIDtemp)
        {
            return TransactionHeaderHandler.getTransactionGridListByUserID(buyerIDtemp);
        }

        public static bool cancelTransaction(int headerIDtemp)
        {
            return TransactionHeaderHandler.cancelTransaction(headerIDtemp);
        }

        public static bool isTokenUnused(int headerIDtemp)
        {
            return TransactionDetailHandler.isTokenUnused(headerIDtemp);
        }

        public static bool isBeforeShowTime(int headerIDtemp)
        {
            return TransactionHeaderHandler.isBeforeShowTime(headerIDtemp);
        }

        public static bool setTokenStatusUsed(string token)
        {
            return TransactionDetailHandler.setTokenStatusUsed(token);
        }

        public static bool setTokenUnused(string token)
        {
            return TransactionDetailHandler.setTokenUnused(token);
        }
    }
}