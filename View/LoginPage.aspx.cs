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
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["current_user"] != null || Request.Cookies["cookies"] != null)
            {
                int userId = -1;
                if (Session["current_user"] == null)
                {
                    userId = int.Parse(Request.Cookies["cookies"].Value);
                    User userCookie = UserController.GetUserById(userId);
                    Session["current_user"] = userCookie;                 
                }
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            User user = UserController.GetUser(username, password);

            if(user == null)
            {
                lblError.Text = "Username or password incorect";
                return;
            }
            else
            {
                int userId = user.Id;

                if (chkRemember.Checked)
                {
                    HttpCookie newCookie = new HttpCookie("cookies");
                    newCookie.Value = userId.ToString();
                    newCookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(newCookie);
                }

                lblError.Text = "Login successfull";

                Session["current_user"] = user;

                Response.Redirect("HomePage.aspx");
            }         
        }
    }
}