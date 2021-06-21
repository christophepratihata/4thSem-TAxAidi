using ProjectPSD.Controller;
using ProjectPSD.DataSet;
using ProjectPSD.Model;
using ProjectPSD.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.View
{
    public partial class ReportPage : System.Web.UI.Page
    {
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
                TransactionsReport tr = new TransactionsReport();
                crvView.ReportSource = tr;
                tr.SetDataSource(getReportData());
            }
        }

        protected DataSetTaxAidi getReportData()
        {
            List<TransactionHeader> headerList = TransactionController.GetHeaderListBySellerId(((User)Session["current_user"]).Id);
            DataSetTaxAidi ds = new DataSetTaxAidi();
            var ds_th = ds.TransactionHeader;
            var ds_td = ds.TransactionDetail;

            foreach (var header in headerList)
            {
                var newRow = ds_th.NewRow();
                newRow["Id"] = header.Id;
                newRow["ShowId"] = header.ShowId;
                newRow["ShowName"] = ShowController.GetShowById(header.ShowId).Name;
                newRow["ShowTime"] = header.ShowTime;
                newRow["BuyerId"] = header.BuyerId;
                newRow["BuyerName"] = UserController.GetUserById(header.BuyerId).Name;
                newRow["PaymentDate"] = header.CreatedAt;
                newRow["Price"] = ShowController.GetShowById(header.ShowId).Price;             
                ds_th.Rows.Add(newRow);

                List<TransactionDetail> detailList = TransactionController.GetDetailListBySellerId(header.Id);
                foreach (var detail in detailList)
                {
                    var newRowDetail = ds_td.NewRow();
                    newRowDetail["HeaderId"] = detail.TransactionHeaderId;
                    newRowDetail["Token"] = detail.Token;
                    newRowDetail["TokenStatus"] = TransactionController.GetTokenStatusByDetailID(detail.Id);
                    newRowDetail["Quantity"] = 1;
                    ds_td.Rows.Add(newRowDetail);
                }
            }
            return ds;  
        }
    }
}