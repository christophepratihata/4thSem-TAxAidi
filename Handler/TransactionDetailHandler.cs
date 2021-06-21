using ProjectPSD.Factory;
using ProjectPSD.Model;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Handler
{
    public class TransactionDetailHandler
    {
        public static TransactionDetail InsertTransactionDetail(int TransactionHeaderID, int StatusID,
            string token)
        {
            TransactionDetail newTransactionDetail = TransactionDetailFactory.Create(TransactionHeaderID,
                StatusID, token);

            TransactionDetailRepository.InsertTransactionDetail(newTransactionDetail);

            return newTransactionDetail;
        }

        public static List<TransactionDetail> getTokenListByHeaderID(int headerId)
        {
            return TransactionDetailRepository.getTokenListByHeaderID(headerId);
        }

        public static bool isTokenUnused(int headerIDtemp)
        {
            return TransactionDetailRepository.isTokenUnused(headerIDtemp);
        }

        public static bool checkTokenIsUsed(string token)
        {
            return TransactionDetailRepository.checkTokenIsUsed(token);
        }

        public static bool setTokenStatusUsed(string token)
        {
            TransactionDetail td = TransactionDetailRepository.GetTransactionDetailByToken(token);
            if (td != null)
            {
                td.StatusId = 2;
                return TransactionDetailRepository.UpdateTransactionDetailStatus(td);
            }
            return false;
        }

        public static TransactionDetail GetTransactionDetailByToken(string token)
        {
            return TransactionDetailRepository.GetTransactionDetailByToken(token);
        }

        public static bool setTokenUnused(string token)
        {
            TransactionDetail td = TransactionDetailRepository.GetTransactionDetailByToken(token);
            if (td != null)
            {
                td.StatusId = 1;
                return TransactionDetailRepository.UpdateTransactionDetailStatus(td);
            }
            return false;
        }

        public static List<TransactionDetail> GetDetailListByHeaderId(int id)
        {
            return TransactionDetailRepository.GetDetailListByHeaderId(id);
        }

        public static string GetTokenStatusByDetailID(int id)
        {
            return TransactionDetailRepository.GetTokenStatusByDetailID(id);
        }
    }
}