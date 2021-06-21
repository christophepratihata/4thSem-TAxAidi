using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class ReviewFactory
    {
        public static Review Create(int rate, string desc, int tdId)
        {
            Review newReview = new Review();
            newReview.Rating = rate;
            newReview.Description = desc;
            newReview.TransactionDetailId = tdId;
            return newReview;
        }


    }
}