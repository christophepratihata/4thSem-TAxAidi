using ProjectPSD.Handler;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Controller
{
    public class ShowController
    {
        public static List<Show> GetAllShows()
        {
            return ShowHandler.GetAllShows();
        }

        public static Show GetShowById(int id)
        {
            return ShowHandler.GetShowById(id);
        }

        public static Show GetShowByName(string name)
        {
            return ShowHandler.GetShowByName(name);
        }

        public static Show getShowByToken(string token)
        {
            return ShowHandler.getShowByToken(token);
        }

        public static List<Show> getShowListBySearch(string search)
        {
            return ShowHandler.getShowListBySearch(search);
        }

        public static string getShowAvgRatingById(int showID)
        {
            return ShowHandler.getShowAvgRatingById(showID);
        }

        public static string InsertShow(int sellerId, string name, int price, string description,
            string url)
        {
            if (price < 1000)
                return "Price must be at least 1000";

            if(!ShowHandler.InsertShow(sellerId, name, price, description, url))
            {
                return "Failed to insert show";
            }
            
            return "Show added successfully";
        }

        public static string UpdateShow(int id, string name, int price, string description, string url)
        {
            if (price < 1000)
                return "Price must be at least 1000";

            if(!ShowHandler.UpdateShow(id, name, price, description, url))
            {
                return "Show's Name must be unique among other shows";
            }

            return "Show's updated successfully";
        }

        public static bool checkBought(DateTime showTime, int buyerIDtemp, int showIDtemp)
        {
            return ShowHandler.checkBought(showTime, buyerIDtemp, showIDtemp);
        }
    }
}