using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail Create(int transactionheaderid, int statusid, string token)
        {
            TransactionDetail newTransactionDetail = new TransactionDetail();
            newTransactionDetail.TransactionHeaderId = transactionheaderid;
            newTransactionDetail.StatusId = statusid;
            newTransactionDetail.Token = token;

            return newTransactionDetail;
        }
    }
}