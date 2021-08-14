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
    public partial class StaffListing : BasePage
    {
        private string SearchString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            txtSearch.Attributes.Add("onkeyup", "initjsfun();");
            txtSearch.Focus();
            if (!IsPostBack)
            {
                btnAddNew.HRef = "StaffEntry";
                BindgvstaffListing();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "pageinfo();", true);
            if (gvstaffListing.Rows.Count > 0)
            {
                gvstaffListing.UseAccessibleHeader = true;
                gvstaffListing.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvstaffListing.BottomPagerRow.Visible = true;
            }

        }

        protected void gvstaffListing_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvstaffListing.PageIndex = e.NewPageIndex;
            BindgvstaffListing();
        }
        protected void gvstaffListing_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //System.Threading.Thread.Sleep(2000);
            try
            {
                if (e.CommandName == "btnDelete")
                {
                    int _Exerid = Convert.ToInt32(e.CommandArgument);
                    using (Demployee objexer = new Demployee())
                    {
                        var _getresult = objexer.DeleteEmployee(_Exerid);

                    }
                    HospiceHelper.SendAlert("SsMessage:\n Employee has been successfully deleted.");
                }
                BindgvstaffListing();
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\n" + ex.Message);
            }
        }

        protected void ddlPaging_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvstaffListing.PageSize = int.Parse(ddlPaging.SelectedValue);
            BindgvstaffListing();
        }

        private void BindgvstaffListing()
        {
            using (Demployee objdemp = new Demployee())
            {

                int selectedPageSize = int.Parse(ddlPaging.SelectedValue);
                gvstaffListing.PageSize = selectedPageSize;

                var _getresult = objdemp.GetEmpMasterList().ToList();
                if (SearchString != "")
                    _getresult = objdemp.GetEmpMasterList().Where(x => x.EmpCode == SearchString || x.EmpName == SearchString || x.Address == SearchString || x.MobileNo == SearchString).ToList();
                gvstaffListing.DataSource = _getresult.OrderByDescending(x => x.EmpID).ToList();
                gvstaffListing.DataBind();

                int totalRecords = _getresult.Count();
                int PageIndex = gvstaffListing.PageIndex;

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

                lblRecordsInDisplay.Text = "Showing <b>" + startFrom.ToString() + " to " + endAt.ToString() + " of " + totalRecords.ToString() + " </b>entries " + String.Format(" <b>[Page {0:0} of {1:0}] </b>", PageIndex + 1, gvstaffListing.PageCount);

                if (gvstaffListing.Rows.Count > 0)
                {
                    gvstaffListing.UseAccessibleHeader = true;
                    gvstaffListing.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SearchString = txtSearch.Text.Trim();
            BindgvstaffListing();
            txtSearch.Attributes["onfocus"] = "var value = this.value; this.value = ''; this.value = value; onfocus = null;";
            txtSearch.Focus();
        }

        protected void lnkbtnPrint_Click(object sender, EventArgs e)
        {
            BindgvstaffListing();
            var hidecolumns = new List<int>() { 0 };
            HospiceHelper.Printgv(gvstaffListing, hidecolumns);
        }

        protected void lnkbtnXl_Click(object sender, EventArgs e)
        {
            BindgvstaffListing();
            var hidecolumns = new List<int>() { 0 };
            HospiceHelper.ExporttoXl(gvstaffListing, hidecolumns, "MStaffList");
        }
    }
}