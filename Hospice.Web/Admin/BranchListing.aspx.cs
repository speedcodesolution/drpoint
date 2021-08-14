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
    public partial class BranchListing : BasePage
    {
        private string SearchString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            txtSearch.Attributes.Add("onkeyup", "initjsfun();");
            txtSearch.Focus();
            if (!IsPostBack)
            {
                btnAddNew.HRef = "BranchEntry";
                BindgvBranchListing();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "pageinfo();", true);
            if (gvBranchListing.Rows.Count > 0)
            {
                gvBranchListing.UseAccessibleHeader = true;
                gvBranchListing.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvBranchListing.BottomPagerRow.Visible = true;
            }

        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Purpose :   If the page is listing page then DDL will apear otherwise label will apear.
            Master.FindControl("lblCurrentBranch").Visible = false;
            Master.FindControl("ddlCurrentBranch").Visible = false;
        }
        protected void gvBranchListing_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBranchListing.PageIndex = e.NewPageIndex;
            BindgvBranchListing();
        }
        protected void gvBranchListing_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //System.Threading.Thread.Sleep(2000);
            try
            {
                if (e.CommandName == "btnDelete")
                {
                    int _Exerid = Convert.ToInt32(e.CommandArgument);
                    using (Dbranch objexer = new Dbranch())
                    {
                        var _getresult = objexer.DeleteBranch(_Exerid);

                    }
                    HospiceHelper.SendAlert("SsMessage:\n Branch has been successfully deleted.");
                }
                BindgvBranchListing();
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\n" + ex.Message);
            }
        }

        protected void ddlPaging_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvBranchListing.PageSize = int.Parse(ddlPaging.SelectedValue);
            BindgvBranchListing();
        }

        private void BindgvBranchListing()
        {
            using (Dbranch objservice = new Dbranch())
            {
                int selectedPageSize = int.Parse(ddlPaging.SelectedValue);
                gvBranchListing.PageSize = selectedPageSize;

                var _getresult = objservice.GetbranchMasterList().ToList();
                if (SearchString != "")
                    _getresult = objservice.GetbranchMasterList().Where(x => x.BranchLocation == SearchString || x.BranchName == SearchString).ToList();
                gvBranchListing.DataSource = _getresult.OrderByDescending(x => x.BranchID).ToList();
                gvBranchListing.DataBind();

                int totalRecords = _getresult.Count();
                int PageIndex = gvBranchListing.PageIndex;

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

                lblRecordsInDisplay.Text = "Showing <b>" + startFrom.ToString() + " to " + endAt.ToString() + " of " + totalRecords.ToString() + " </b>entries " + String.Format(" <b>[Page {0:0} of {1:0}] </b>", PageIndex + 1, gvBranchListing.PageCount);

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SearchString = txtSearch.Text.Trim();
            BindgvBranchListing();
            txtSearch.Attributes["onfocus"] = "var value = this.value; this.value = ''; this.value = value; onfocus = null;";
            txtSearch.Focus();
        }

        protected void lnkbtnPrint_Click(object sender, EventArgs e)
        {
            BindgvBranchListing();
            var hidecolumns = new List<int>() { 0 };
            HospiceHelper.Printgv(gvBranchListing, hidecolumns);
        }

        protected void lnkbtnXl_Click(object sender, EventArgs e)
        {
            BindgvBranchListing();
            var hidecolumns = new List<int>() { 0 };
            HospiceHelper.ExporttoXl(gvBranchListing, hidecolumns, "MBranchList");
        }
    }
}