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
    public partial class UpdateShowPage : System.Web.UI.Page
    {
        protected int showID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["current_user"] == null)    //Guest
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                User user = (User)Session["current_user"];
                if (user.RoleId.Equals(2))  //Buyer
                {
                    Response.Redirect("HomePage.aspx");
                }
            }

            showID = Convert.ToInt32(Request["ID"]);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = showID;
            string name = txtName.Text;
            string description = txtDescription.Text;
            string priceStr = txtPrice.Text;
            string URL = txtURL.Text;

            if(name.Equals("") || description.Equals("") || priceStr.Equals("") || URL.Equals(""))
            {
                lblError.Text = "All fields must be filled";
                return;
            }

            int price;
            bool valid = int.TryParse(priceStr, out price);

            lblError.Text = ShowController.UpdateShow(id, name, price, description, URL);

            txtName.Text = txtDescription.Text = txtPrice.Text = txtURL.Text = "";
        }
    }
}