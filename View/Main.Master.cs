using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.View
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["current_user"] == null)
            {
                linkAccount.Visible = false;
                linkAddShow.Visible = false;
                linkLogout.Visible = false;
                linkReports.Visible = false;
                linkTransactions.Visible = false;

                lblUser.Text = "Guest";
            }
            else
            {
                User user = (User)Session["current_user"];
                linkLogin.Visible = false;
                linkRegister.Visible = false;
                if(user.RoleId.Equals(1))       //Seller
                {
                    linkTransactions.Visible = false;
                }
                else if(user.RoleId.Equals(2))  //Buyer
                {
                    linkAddShow.Visible = false;
                    linkReports.Visible = false;
                }
                lblUser.Text = user.Name;
            }
        }

        protected void linkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void linkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void linkRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");
        }

        protected void linkTransactions_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionsPage.aspx");
        }

        protected void linkAddShow_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddShowPage.aspx");
        }

        protected void linkReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportPage.aspx");
        }

        protected void linkAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountPage.aspx");
        }

        protected void linkRedeem_Click(object sender, EventArgs e)
        {
            Response.Redirect("RedeemToken.aspx");
        }

        protected void linkLogout_Click(object sender, EventArgs e)
        {
            Session["current_user"] = null;
            Session.Abandon();
            if (Request.Cookies["cookies"] != null)
            {
                HttpCookie cookie = new HttpCookie("cookies");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            Response.Redirect("HomePage.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            Response.Redirect("HomePage.aspx?search=" + search);
        }
    }
}