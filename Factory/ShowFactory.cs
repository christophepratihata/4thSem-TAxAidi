using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class ShowFactory
    {
        public static Show Create(int sellerId, string name, int price, string description,
            string url)
        {
            Show newShow = new Show();
            newShow.SellerId = sellerId;
            newShow.Name = name;
            newShow.Price = price;
            newShow.Description = description;
            newShow.URL = url;

            return newShow;
        }
    }
}