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
    public partial class ReviewPage : System.Web.UI.Page
    {
        Show show = new Show();
        User seller = new User();
        Review review = new Review();
        TransactionDetail td = new TransactionDetail();
        string token;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["url"] != null)
            {
                string url = Request.QueryString["url"];
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + url + "','_blank');", true);
            }

            if (!IsPostBack)
            {
                token = Request.QueryString["token"];
                show = ShowController.getShowByToken(token);
                seller = UserController.GetUserById(show.SellerId);

                lblShowName.Text = show.Name;
                lblSellerName.Text = seller.Name;
                lblDescription.Text = show.Description;

                if (TransactionController.checkTokenIsUsed(token) == true)
                {
                    btnRate.Visible = false;
                    review = ReviewController.getReviewByToken(token);
                    if (review != null)
                    {
                        txtRating.Text = review.Rating.ToString();
                        txtDescription.Text = review.Description;
                    }
                }
                else
                {
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                }
            }
        }

        protected void btnRate_Click(object sender, EventArgs e)
        {
            //Passing Data
            token = Request.QueryString["token"];
            td = TransactionController.GetTransactionDetailByToken(token);
            show = ShowController.getShowByToken(token);
            //Passing Data


            int rate;
            if (int.TryParse(txtRating.Text, out rate) == true)
            {
                string desc = txtDescription.Text;
                int tdId = td.Id;
                errReview.Text = "";
                errReview.Text = (ReviewController.checkReviewValidation(rate, desc));
                if (errReview.Text == "")
                {
                    if (ReviewController.addRate(rate, desc, tdId) == true)
                    {
                        if (TransactionController.setTokenStatusUsed(token) == true)
                        {
                            errReview.Text = "Your rate has been added";
                            Response.Redirect("ShowDetailPage.aspx?ID=" + show.Id);
                        }
                    }
                    else
                    {
                        errReview.Text = "Rate failed!";
                    }
                }
            }       
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Passing Data
            token = Request.QueryString["token"];
            td = TransactionController.GetTransactionDetailByToken(token);
            show = ShowController.getShowByToken(token);
            //Passing Data

            int rate;
            if (int.TryParse(txtRating.Text, out rate) == true)
            {
                string desc = txtDescription.Text;
                errReview.Text = "";
                errReview.Text = (ReviewController.checkReviewValidation(rate, desc));
                if (errReview.Text == "")
                {
                    if (ReviewController.updateRate(rate, desc, token) == true)
                    {
                        errReview.Text = "Your rate has been updated";
                        Response.Redirect("ShowDetailPage.aspx?ID=" + show.Id);
                    }
                    else
                    {
                        errReview.Text = "Update rate failed!";
                    }
                }
            }            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //Passing Data
            token = Request.QueryString["token"];
            td = TransactionController.GetTransactionDetailByToken(token);
            show = ShowController.getShowByToken(token);
            //Passing Data


            if (ReviewController.deleteReview(token) == true)
            {
                if (TransactionController.setTokenUnused(token) == true)
                {
                    errReview.Text = "Your rate has been deleted";
                    Response.Redirect("ShowDetailPage.aspx?ID=" + show.Id);
                }              
            }
            else
            {
                errReview.Text = "Delete failed!";
            }
        }
    }
}