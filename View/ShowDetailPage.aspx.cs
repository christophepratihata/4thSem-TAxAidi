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
    public partial class ShowDetailPage : System.Web.UI.Page
    {
        protected int showID;
        protected Show show = new Show();
        protected User user = new User();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["current_user"] == null)    //Guest
            {
                btnOrder.Visible = false;
                btnUpdate.Visible = false;
            }
            else
            {
                User user = (User)Session["current_user"];
                if (user.RoleId.Equals(1))       //Seller
                    btnOrder.Visible = false;
                else if (user.RoleId.Equals(2))  //Buyer
                    btnUpdate.Visible = false;
            }

            showID = Convert.ToInt32(Request["ID"]);

            show = ShowController.GetShowById(showID);
            user = UserController.GetUserById(show.Id);

            lblShowName.Text = show.Name;
            lblShowPrice.Text = show.Price.ToString();
            lblSellerName.Text = user.Name;
            lblDescription.Text = show.Description;
            lblRating.Text = ShowController.getShowAvgRatingById(showID);

            FillGridReview();
        }

        protected void FillGridReview()
        {
            grdReview.DataSource = ReviewController.getAllReviews(showID);
            grdReview.DataBind();
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderPage.aspx?ID=" + showID);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateShowPage.aspx?ID=" + showID);
        }
    }
}