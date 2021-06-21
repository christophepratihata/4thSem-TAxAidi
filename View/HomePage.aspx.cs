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
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["search"] != null)
            {
                gvShow.DataSource = ShowController.getShowListBySearch(Request.QueryString["search"]);
                gvShow.DataBind();
            }
            else
            {
                FillGrid();
            }           
        }

        protected void FillGrid()
        {
            List<Show> allShows = ShowController.GetAllShows();

            gvShow.DataSource = allShows;
            gvShow.DataBind();
        }

        protected void gvShow_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = gvShow.Rows[e.NewEditIndex];

            string showID = row.Cells[0].Text.ToString();

            Response.Redirect("ShowDetailPage.aspx?ID=" + showID);
        }
    }
}