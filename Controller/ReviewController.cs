using ProjectPSD.Handler;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Controller
{
    public class ReviewController
    {
        public static List<Review> getAllReviews(int showID)
        {
            return ReviewHandler.getAllReviews(showID);
        }

        public static Review getReviewByToken(string token)
        {
            return ReviewHandler.getReviewByToken(token);
        }

        public static string checkReviewValidation(int rate, string desc)
        {
            string errorText = "";
            if ((rate < 1 || rate > 5))
            {
                errorText += "Rate must be at least 1 and at most 5";
            }
            if (desc == "")
            {
                errorText += "Description must be filled";
            }
            return errorText;
        }

        public static bool addRate(int rate, string desc, int tdId)
        {
            return ReviewHandler.addRate(rate, desc, tdId);
        }

        public static bool updateRate(int rate, string desc, string token)
        {
            return ReviewHandler.updateRate(rate, desc, token);
        }

        public static bool deleteReview(string token)
        {
            return ReviewHandler.deleteReview(token);
        }
    }
}