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
    public partial class LabListing : BasePage
    {
        private string SearchString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            txtSearch.Attributes.Add("onkeyup", "initjsfun();");
            txtSearch.Focus();
            if (!IsPostBack)
            {
                btnAddNew.HRef = "LabEntry";
                BindgvLabListing();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "pageinfo();", true);
            if (gvLabListing.Rows.Count > 0)
            {
                gvLabListing.UseAccessibleHeader = true;
                gvLabListing.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvLabListing.BottomPagerRow.Visible = true;
            }

        }

        protected void gvLabListing_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLabListing.PageIndex = e.NewPageIndex;
            BindgvLabListing();
        }
        protected void gvLabListing_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //System.Threading.Thread.Sleep(2000);
            try
            {
                if (e.CommandName == "btnDelete")
                {
                    int _Exerid = Convert.ToInt32(e.CommandArgument);
                    using (Dlab objexer = new Dlab())
                    {
                        var _getresult = objexer.DeleteLab(_Exerid);

                    }
                    HospiceHelper.SendAlert("SsMessage:\n Lab has been successfully deleted.");
                }
                BindgvLabListing();
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\n" + ex.Message);
            }
        }

        protected void ddlPaging_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvLabListing.PageSize = int.Parse(ddlPaging.SelectedValue);
            BindgvLabListing();
        }

        private void BindgvLabListing()
        {
            using (Dlab objservice = new Dlab())
            {
                int selectedPageSize = int.Parse(ddlPaging.SelectedValue);
                gvLabListing.PageSize = selectedPageSize;

                var _getresult = objservice.GetLabMasterList().ToList();
                if (SearchString != "")
                    _getresult = objservice.GetLabMasterList().Where(x => x.LabCode == SearchString || x.LabName == SearchString).ToList();
                gvLabListing.DataSource = _getresult.OrderByDescending(x => x.Labid).ToList();
                gvLabListing.DataBind();

                int totalRecords = _getresult.Count();
                int PageIndex = gvLabListing.PageIndex;

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

                lblRecordsInDisplay.Text = "Showing <b>" + startFrom.ToString() + " to " + endAt.ToString() + " of " + totalRecords.ToString() + " </b>entries " + String.Format(" <b>[Page {0:0} of {1:0}] </b>", PageIndex + 1, gvLabListing.PageCount);

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SearchString = txtSearch.Text.Trim();
            BindgvLabListing();
            txtSearch.Attributes["onfocus"] = "var value = this.value; this.value = ''; this.value = value; onfocus = null;";
            txtSearch.Focus();
        }

        protected void lnkbtnPrint_Click(object sender, EventArgs e)
        {
            BindgvLabListing();
            var hidecolumns = new List<int>() { 0 };
            HospiceHelper.Printgv(gvLabListing, hidecolumns);
        }

        protected void lnkbtnXl_Click(object sender, EventArgs e)
        {
            BindgvLabListing();
            var hidecolumns = new List<int>() { 0 };
            HospiceHelper.ExporttoXl(gvLabListing, hidecolumns, "MLabList");
        }
    }
}