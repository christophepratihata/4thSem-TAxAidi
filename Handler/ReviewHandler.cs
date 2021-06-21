using ProjectPSD.Factory;
using ProjectPSD.Model;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ProjectPSD.Handler
{
    public class ReviewHandler
    {
        public static List<Review> getAllReviews (int showID)
        {
            return ReviewRepository.getAllReviews(showID);
        }

        public static Review getReviewByToken(string token)
        {
            return ReviewRepository.getReviewByToken(token);
        }

        public static bool addRate(int rate, string desc, int tdId)
        {
            Review review = ReviewFactory.Create(rate, desc, tdId);
            if (review != null)
            {
                return ReviewRepository.addRate(review);
            }
            return false;
        }

        public static bool updateRate(int rate, string desc, string token)
        {
            Review review = ReviewRepository.getReviewByToken(token);
            if (review != null)
            {
                review.Rating = rate;
                review.Description = desc;
                return ReviewRepository.updateReview(review);
            }
            return false;
        }

        public static bool deleteReview(string token)
        {
            Review review = ReviewRepository.getReviewByToken(token);
            if (review != null)
            {
                return ReviewRepository.deleteReview(review);
            }
            return false;
        }
    }
}