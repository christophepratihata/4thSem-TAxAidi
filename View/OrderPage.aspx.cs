using ProjectPSD.Controller;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.View
{
    public partial class OrderPage : System.Web.UI.Page
    {
        protected int showIDtemp;
        protected int buyerIDtemp;

        protected Show show = new Show();
        protected User seller = new User();
        protected DateTime time = DateTime.Now;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["current_user"] == null)    //Guest
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                User user = (User)Session["current_user"];
                if (user.RoleId.Equals(1))  //Seller
                {
                    Response.Redirect("HomePage.aspx");
                }

                buyerIDtemp = user.Id;
            }

            showIDtemp = Convert.ToInt32(Request["ID"]);
            show = ShowController.GetShowById(showIDtemp);
            seller = UserController.GetUserById(show.Id);

            if (pickDate.SelectedDate == DateTime.MinValue)
            {
                pickDate.SelectedDate = DateTime.Now;
            }

            //fill Show Detail
            lblShowName.Text = show.Name;
            lblShowPrice.Text = show.Price.ToString();
            lblSellerName.Text = seller.Name;
            lblDescription.Text = show.Description;
            lblRating.Text = ShowController.getShowAvgRatingById(showIDtemp);
            fillShowTimeList();
            fillGrid();       
        }
        
        protected void fillGrid()
        {
            showTimeGrid.DataSource = fillShowTimeList();
            showTimeGrid.DataBind();
        }


        private static List<ShowTimeList> fillShowTimeList()
        {
            List<ShowTimeList> dt = new List<ShowTimeList>();
            dt.Add(new ShowTimeList { timeList = "00:00 - 00:59" });
            dt.Add(new ShowTimeList { timeList = "01:00 - 01:59" });
            dt.Add(new ShowTimeList { timeList = "02:00 - 02:00" });
            dt.Add(new ShowTimeList { timeList = "03:00 - 03:00" });
            dt.Add(new ShowTimeList { timeList = "04:00 - 04:00" });
            dt.Add(new ShowTimeList { timeList = "05:00 - 05:00" });
            dt.Add(new ShowTimeList { timeList = "06:00 - 06:00" });
            dt.Add(new ShowTimeList { timeList = "07:00 - 07:00" });
            dt.Add(new ShowTimeList { timeList = "08:00 - 08:00" });
            dt.Add(new ShowTimeList { timeList = "09:00 - 09:00" });
            dt.Add(new ShowTimeList { timeList = "10:00 - 10:00" });
            dt.Add(new ShowTimeList { timeList = "11:00 - 11:00" });
            dt.Add(new ShowTimeList { timeList = "12:00 - 12:00" });
            dt.Add(new ShowTimeList { timeList = "13:00 - 13:00" });
            dt.Add(new ShowTimeList { timeList = "14:00 - 14:00" });
            dt.Add(new ShowTimeList { timeList = "15:00 - 15:00" });
            dt.Add(new ShowTimeList { timeList = "16:00 - 16:00" });
            dt.Add(new ShowTimeList { timeList = "17:00 - 17:00" });
            dt.Add(new ShowTimeList { timeList = "18:00 - 18:00" });
            dt.Add(new ShowTimeList { timeList = "19:00 - 19:00" });
            dt.Add(new ShowTimeList { timeList = "20:00 - 20:00" });
            dt.Add(new ShowTimeList { timeList = "21:00 - 21:00" });
            dt.Add(new ShowTimeList { timeList = "22:00 - 22:00" });
            dt.Add(new ShowTimeList { timeList = "23:00 - 23:00" });
            return dt;
        }


        protected bool refreshThisShowTime(string fullDate)
        {
            showIDtemp = Convert.ToInt32(Request["ID"]);
            seller = UserController.GetUserById(show.Id);
            DateTime showTime;
            if (DateTime.TryParse(fullDate, out showTime) == true)
            {
                if ((showTime < DateTime.Now) || (ShowController.checkBought(showTime, buyerIDtemp, showIDtemp) == true))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        protected void showTimeGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string showTime = (e.Row.Cells[0].Text).Substring(0, 4);
                string selectedDate = pickDate.SelectedDate.ToString("dd/MM/yyyy");
                string fullDate = selectedDate + " " + showTime;
                if (refreshThisShowTime(fullDate) == false)
                {
                    Button bf = (Button)e.Row.Cells[1].Controls[0];
                    bf.Text = "Unavailable";
                    bf.Enabled = false;
                }
            }
        }

        protected void showTimeGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Order")
            {
                string quantityStr = txtQuantity.Text;
                int quantity;
                bool valid = int.TryParse(quantityStr, out quantity);

                int showID = showIDtemp;
                int buyerID = buyerIDtemp;

                //getShowTimeRow Start Here
                DateTime DateShowTime;

                int row = Convert.ToInt32(e.CommandArgument.ToString());
                string StringShowTime = (showTimeGrid.Rows[row].Cells[0].Text).Substring(0, 4); ;
                string selectedDate = pickDate.SelectedDate.ToString("dd/MM/yyyy");
                string fullDate = selectedDate + " " + StringShowTime;

                DateShowTime = DateTime.Parse(fullDate);

                //getShowTimeRow End Here
                DateTime createdat = DateTime.Now;

                lblError.Text =
                    TransactionController.InsertTransaction(buyerID, showID, DateShowTime, createdat, quantity);

                txtQuantity.Text = "";
            }
        }
    }
}