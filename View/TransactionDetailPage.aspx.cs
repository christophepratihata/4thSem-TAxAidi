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
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        private int buyerIDtemp;
        private int headerIDtemp;
        private int showId;
        protected Show show = new Show();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["current_user"] == null)
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                showId = int.Parse(Request.QueryString["showId"]);
                headerIDtemp = int.Parse(Request.QueryString["headerId"]);
                User user = (User)Session["current_user"];
                if (user.RoleId.Equals(1) || TransactionController.userOwnThisTransaction(buyerIDtemp, headerIDtemp) == true)//Seller
                {
                    Response.Redirect("HomePage.aspx");
                }
                else
                {                  
                    buyerIDtemp = user.Id;
                    show = ShowController.GetShowById(showId);
                }              
            }
            lblShowName.Text = show.Name;
            lblDescription.Text = show.Description;
            lblRating.Text = ShowController.getShowAvgRatingById(showId);
            FillToken();
        }

        protected void FillToken()
        {
            grToken.DataSource = TransactionController.getTokenListByHeaderID(headerIDtemp);
            grToken.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (TransactionController.isBeforeShowTime(headerIDtemp) == true && TransactionController.isTokenUnused(headerIDtemp) == true)
            {
                if (TransactionController.cancelTransaction(headerIDtemp) == true)
                {
                    lblError.Text = "Your transaction has been canceled";
                }
                else
                {
                    lblError.Text = "There is an error while doing your cancelation";
                }
            }
            else
            {
                lblError.Text = "Your transaction CANNOT be canceled!";
            }
        }
    }
}