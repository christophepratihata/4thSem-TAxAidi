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
    public partial class AccountPage : System.Web.UI.Page
    {
        protected string tempUsername;
        protected string tempPassword;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["current_user"] == null)
            {
                Response.Redirect("HomePage.aspx");
            }

            if(Session["current_user"] != null)
            {
                User user = (User)Session["current_user"];
                lblName.Text = user.Name;
                lblUsername.Text = user.Username;
                tempUsername = user.Username;
                tempPassword = user.Password;
            }
        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            string username = tempUsername;
            string name = txtName.Text;
            string oldPassword = txtOldPassword.Text;
            string currPassword = tempPassword;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if(name == "")
            {
                lblError.Text = "Name / All fields must be filled";
                return;
            }

            if(name != "" && oldPassword == "" && newPassword == "" && confirmPassword == "")
            {
                lblError.Text = UserController.UpdateUser(username, name, currPassword);

                if (lblError.Text == "Update Successfull")
                    lblName.Text = name;

                txtName.Text = "";

                return;
            }

            if (oldPassword == "" || newPassword == "" || confirmPassword == "")
            {
                lblError.Text = "All fields must be filled";
                return;
            }

            lblError.Text = UserController.UpdateUser(username, name, oldPassword, currPassword,
                newPassword, confirmPassword);

            if(lblError.Text == "Update Successfull")
            {
                lblName.Text = name;
                lblUsername.Text = username;
            }

            txtName.Text = txtOldPassword.Text = txtNewPassword.Text = txtConfirmPassword.Text = "";
        }
    }
}