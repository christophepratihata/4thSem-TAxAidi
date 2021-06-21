using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader Create(int buyerid, int showid, DateTime showtime,
            DateTime createdat)
        {
            TransactionHeader newTransactionHeader = new TransactionHeader();
            newTransactionHeader.BuyerId = buyerid;
            newTransactionHeader.ShowId = showid;
            newTransactionHeader.ShowTime = showtime;
            newTransactionHeader.CreatedAt = createdat;

            return newTransactionHeader;
        }
    }
}