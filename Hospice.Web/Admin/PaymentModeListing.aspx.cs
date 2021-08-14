using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospice.DAL;
using Hospice.Helper;
using Hospice.Web.App_Code;

namespace Hospice.Web.Admin
{
    public partial class PaymentModeListing :BasePage
    {
        private string SearchString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSearch.Attributes.Add("onkeyup", "initjsfun();");
            txtSearch.Focus();
            if (!IsPostBack)
            {
                btnAddNew.HRef = "PaymentModeEntry";
                BindgvPaymodListing();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "pageinfo();", true);
            if (gvPaymodListing.Rows.Count > 0)
            {
                gvPaymodListing.UseAccessibleHeader = true;
                gvPaymodListing.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvPaymodListing.BottomPagerRow.Visible = true;
            }

        }

        protected void gvPaymodListing_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPaymodListing.PageIndex = e.NewPageIndex;
            BindgvPaymodListing();
        }
        protected void gvPaymodListing_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //System.Threading.Thread.Sleep(2000);
            try
            {
                if (e.CommandName == "btnDelete")
                {
                    int _Exerid = Convert.ToInt32(e.CommandArgument);
                    using (Dpaymentmode objexer = new Dpaymentmode())
                    {
                        var _getresult = objexer.DeletePaymentMode(_Exerid);

                    }
                    HospiceHelper.SendAlert("SsMessage:\n PaymentMode has been successfully deleted.");
                }
                BindgvPaymodListing();
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\n" + ex.Message);
            }
        }

        protected void ddlPaging_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvPaymodListing.PageSize = int.Parse(ddlPaging.SelectedValue);
            BindgvPaymodListing();
        }

        private void BindgvPaymodListing()
        {
            using (Dpaymentmode objpaymentmode = new Dpaymentmode())
            {
                int selectedPageSize = int.Parse(ddlPaging.SelectedValue);
                gvPaymodListing.PageSize = selectedPageSize;

                var _getresult = objpaymentmode.GetPaymentModeMasterList().ToList();
                if (SearchString != "")
                _getresult = objpaymentmode.GetPaymentModeMasterList().Where(x => x.PaymentModeCode == SearchString || x.PaymentMode == SearchString).ToList();
                gvPaymodListing.DataSource = _getresult.OrderByDescending(x => x.PaymentModeId).ToList();
                gvPaymodListing.DataBind();

                int totalRecords = _getresult.Count();
                int PageIndex = gvPaymodListing.PageIndex;

                int startFrom;
                int endAt;

                if (totalRecords == 0)
                {
                    lblRecordsInDisplay.Text = "";
                    return;
                }

                if (((PageIndex + 1) * selectedPageSize) > totalRecords)
                {
                    startFrom = (PageIndex * selectedPageSize) + 1;
                    endAt = totalRecords;
                }
                else
                {
                    startFrom = (PageIndex * selectedPageSize) + 1;
                    endAt = ((PageIndex + 1) * selectedPageSize);
                }

                lblRecordsInDisplay.Text = "Showing <b>" + startFrom.ToString() + " to " + endAt.ToString() + " of " + totalRecords.ToString() + " </b>entries " + String.Format(" <b>[Page {0:0} of {1:0}] </b>", PageIndex + 1, gvPaymodListing.PageCount);

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SearchString = txtSearch.Text.Trim();
            BindgvPaymodListing();
            txtSearch.Attributes["onfocus"] = "var value = this.value; this.value = ''; this.value = value; onfocus = null;";
            txtSearch.Focus();
        }

        protected void lnkbtnPrint_Click(object sender, EventArgs e)
        {
            BindgvPaymodListing();
            var hidecolumns = new List<int>() { 0 };
            HospiceHelper.Printgv(gvPaymodListing, hidecolumns);
        }

        protected void lnkbtnXl_Click(object sender, EventArgs e)
        {
            BindgvPaymodListing();
            var hidecolumns = new List<int>() { 0 };
            HospiceHelper.ExporttoXl(gvPaymodListing, hidecolumns, "MPaymentModeList");
        }
    }
}