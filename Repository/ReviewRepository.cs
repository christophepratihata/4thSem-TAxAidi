using ProjectPSD.Model;
using ProjectPSD.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repository
{
    public class ReviewRepository
    {
        private static MyDatabaseEntities db = DbManager.GetInstance();

        public static List<Review> getAllReviews(int showID)
        {
            var x = (from rvw in db.Reviews
                     join td in db.TransactionDetails on rvw.TransactionDetailId equals td.Id
                     join th in db.TransactionHeaders on td.TransactionHeaderId equals th.Id
                     orderby rvw.Rating descending
                     where th.ShowId == showID
                     select rvw).ToList();
            return x;
        }

        public static bool addRate(Review review)
        {
            if (review != null)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static Review getReviewByToken(string token)
        {
            Review review = (from x in db.TransactionDetails
                             join r in db.Reviews on x.Id equals r.TransactionDetailId
                             where x.Token == token select r).FirstOrDefault();
            if (review != null)
            {
                return review;
            }
            return null;
        }

        public static bool deleteReview(Review review)
        {
            if (review != null)
            {
                db.Reviews.Remove(review);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool updateReview(Review review)
        {
            if (review != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}