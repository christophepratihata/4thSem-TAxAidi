using ProjectPSD.Factory;
using ProjectPSD.Model;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Handler
{
    public class ShowHandler
    {
        public static List<Show> GetAllShows()
        {
            return ShowRepository.GetAllShows();
        }

        public static Show GetShowById(int id)
        {
            return ShowRepository.GetShowById(id);
        }

        public static Show GetShowByName(string name)
        {
            return ShowRepository.GetShowByName(name);
        }
        public static List<Show> getShowListBySearch(string search)
        {
            return ShowRepository.getShowListBySearch(search);
        }

        public static Show getShowByToken(string token)
        {
            return ShowRepository.getShowByToken(token);
        }

        public static bool InsertShow(int sellerId, string name, int price, string description,
            string url)
        {
            Show testShow = GetShowByName(name);

            if (testShow != null)
            {
                return false;
            }

            Show newShow = ShowFactory.Create(sellerId, name, price, description, url);

            return ShowRepository.InsertShow(newShow);
        }

        public static bool UpdateShow(int id, string name, int price, string description, string url)
        {
            Show currShow = GetShowById(id);

            if(currShow == null)
            {
                return false;
            }

            currShow.Name = name;
            currShow.Price = price;
            currShow.Description = description;
            currShow.URL = url;

            return ShowRepository.UpdateShow(currShow);
        }

        public static string getShowAvgRatingById(int showID)
        {
            return ShowRepository.getShowAvgRatingById(showID);
        }

        public static bool DeleteShow(int id)
        {
            Show currShow = GetShowById(id);

            if (currShow == null)
            {
                return false;
            }

            return ShowRepository.DeleteShow(currShow);
        }

        public static bool checkBought(DateTime showTime, int buyerIDtemp, int showIDtemp)
        {
            return ShowRepository.checkBought(showTime, buyerIDtemp, showIDtemp);
        }
    }
}