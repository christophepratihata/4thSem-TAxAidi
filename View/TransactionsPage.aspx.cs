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
    public partial class TransactionsPage : System.Web.UI.Page
    {

        private int buyerIDtemp;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["current_user"] == null)
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                User user = (User)Session["current_user"];
                if (user.RoleId.Equals(1))  //Seller
                {
                    Response.Redirect("HomePage.aspx");
                }

                buyerIDtemp = user.Id;
            }

            if (!IsPostBack)
            {
                FillGrid();
            }
        }

        protected void FillGrid()
        {
            grTransactions.DataSource = TransactionController.getTransactionGridListByUserID(buyerIDtemp);
            grTransactions.DataBind();
        }

        protected void grTransactions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grTransactions, "Select$" + e.Row.RowIndex);
            e.Row.ToolTip = "See this transactions";
        }

        protected void grTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grTransactions.Rows)
            {
                if (row.RowIndex == grTransactions.SelectedIndex)
                {
                    row.ToolTip = string.Empty;
                    string showName = grTransactions.SelectedRow.Cells[2].Text;
                    int showId = ShowController.GetShowByName(showName).Id;
                    int userId = ((User)Session["current_user"]).Id;
                    int headerId = int.Parse(grTransactions.SelectedRow.Cells[0].Text);
                    Response.Redirect("TransactionDetailPage.aspx?showId=" + showId + "&headerId=" + headerId);
                }
                else
                {
                    row.ToolTip = "See this transactions";
                }
            }
        }
    }
}