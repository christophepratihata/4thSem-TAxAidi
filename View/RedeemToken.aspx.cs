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
    public partial class RedeemToken : System.Web.UI.Page
    {
        Show show = new Show();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRedeem_Click(object sender, EventArgs e)
        {
            string token = txtToken.Text;
            show = ShowController.getShowByToken(token);
            if (show != null)
            {
                string url = show.URL;
                if (TransactionController.checkTokenIsUsed(token) == true || TransactionController.isPastShowTime(token) == true)
                {
                    Response.Redirect("ReviewPage.aspx?token=" + token);
                }
                else if (TransactionController.IsShowTime(token) == true)
                {
                    Response.Redirect("ReviewPage.aspx?url=" + url + "&token=" + token);
                }
            } 
            errToken.Text = "Invalid token or is not on the show time! Please check your token again";
        }


    }
}