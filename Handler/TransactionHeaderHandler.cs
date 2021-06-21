using ProjectPSD.Factory;
using ProjectPSD.Model;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Handler
{
    public class TransactionHeaderHandler
    {
        public static TransactionHeader InsertTransactionHeader(int buyerid, int showid, 
            DateTime showtime, DateTime createdat)
        {
            TransactionHeader newTransactionHeader = TransactionHeaderFactory.Create(buyerid, showid,
                showtime, createdat);

            TransactionHeaderRepository.InsertTransactionHeader(newTransactionHeader);

            return newTransactionHeader;
        }

        public static List<TransactionGridList> getTransactionGridListByUserID(int buyerIDtemp)
        {
            return TransactionHeaderRepository.getTransactionGridListByUserID(buyerIDtemp);
        }

        public static bool userOwnThisTransaction(int buyerIDtemp, int headerId)
        {
            return TransactionHeaderRepository.userOwnThisTransaction(buyerIDtemp, headerId);
        }

        public static bool isBeforeShowTime(int headerIDtemp)
        {
            return TransactionHeaderRepository.isBeforeShowTime(headerIDtemp);
        }

        public static bool isShowTime(string token)
        {
            return TransactionHeaderRepository.isShowTime(token);
        }

        public static bool isPastShowTime(string token)
        {
            return TransactionHeaderRepository.isPastShowTime(token);
        }

        public static List<TransactionHeader> GetHeaderListBySellerId(int id)
        {
            return TransactionHeaderRepository.GetHeaderListBySellerId(id);
        }

        public static bool cancelTransaction(int headerIDtemp)
        {
            TransactionHeader th = TransactionHeaderRepository.getHeaderByID(headerIDtemp);
            return TransactionHeaderRepository.cancelTransaction(th);

        }
    }
}