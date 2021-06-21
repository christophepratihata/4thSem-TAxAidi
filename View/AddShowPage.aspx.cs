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
    public partial class AddShowPage : System.Web.UI.Page
    {
        protected int selleridTemp;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["current_user"] == null)
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                User user = (User)Session["current_user"];
                if (user.RoleId.Equals(2))       //Buyer
                {
                    Response.Redirect("HomePage.aspx");
                }

                selleridTemp = user.Id;
            }
        }

        protected void btnAddShow_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string url = txtURL.Text;
            string description = txtDescription.Text;
            string priceStr = txtPrice.Text;
            int sellerid = selleridTemp;

            if (name.Equals("") || url.Equals("") || description.Equals("") ||
                priceStr.Equals(""))
            {
                lblError.Text = "All fields must be filled";
                return;
            }

            int price;
            bool valid = int.TryParse(priceStr, out price);

            lblError.Text = ShowController.InsertShow(sellerid, name, price, description, url);

            txtName.Text = txtURL.Text = txtDescription.Text = txtPrice.Text = "";
        }
    }
}