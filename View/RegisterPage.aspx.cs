using ProjectPSD.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.View
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["current_user"] != null)
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void Selection_Change(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string roleidStr = RoleList.SelectedValue;

            if(name.Equals("") || username.Equals("") || password.Equals("") ||
                confirmPassword.Equals("") || roleidStr.Equals(""))
            {
                lblError.Text = "All fields must be filled";
                return;
            }

            int roleid;
            bool valid = int.TryParse(roleidStr, out roleid);

            lblError.Text = UserController.InsertUser(name, username, password, confirmPassword,
                roleid);

            txtName.Text = txtUsername.Text = txtPassword.Text = txtConfirmPassword.Text = "";
        }
    }
}