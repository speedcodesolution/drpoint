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
    public partial class DepartmentListing :BasePage
    {
        private string SearchString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSearch.Attributes.Add("onkeyup", "initjsfun();");
            txtSearch.Focus();
            if (!IsPostBack)
            {
                btnAddNew.HRef = "DepartmentEntry";
                BindgvDepartmentListing();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "pageinfo();", true);
            if (gvDepartmentListing.Rows.Count > 0)
            {
                gvDepartmentListing.UseAccessibleHeader = true;
                gvDepartmentListing.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvDepartmentListing.BottomPagerRow.Visible = true;
            }

        }

        protected void gvDepartmentListing_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDepartmentListing.PageIndex = e.NewPageIndex;
            BindgvDepartmentListing();
        }
        protected void gvDepartmentListing_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //System.Threading.Thread.Sleep(2000);
            try
            {
                if (e.CommandName == "btnDelete")
                {
                    int _Exerid = Convert.ToInt32(e.CommandArgument);
                    using (Ddepartment objexer = new Ddepartment())
                    {
                        var _getresult = objexer.Deletedep(_Exerid);

                    }
                    HospiceHelper.SendAlert("SsMessage:\n Department has been successfully deleted.");
                }
                BindgvDepartmentListing();
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\n" + ex.Message);
            }
        }

        protected void ddlPaging_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvDepartmentListing.PageSize = int.Parse(ddlPaging.SelectedValue);
            BindgvDepartmentListing();
        }

        private void BindgvDepartmentListing()
        {
            using (Ddepartment objdep = new Ddepartment())
            {
                int selectedPageSize = int.Parse(ddlPaging.SelectedValue);
                gvDepartmentListing.PageSize = selectedPageSize;

                var _getresult = objdep.GetdepMasterList().ToList();
                if (SearchString != "")
                    _getresult = objdep.GetdepMasterList().Where(x => x.DepartmentCode == SearchString || x.DepartmentName == SearchString).ToList();
                gvDepartmentListing.DataSource = _getresult.OrderByDescending(x => x.Departmentid).ToList();
                gvDepartmentListing.DataBind();

                int totalRecords = _getresult.Count();
                int PageIndex = gvDepartmentListing.PageIndex;

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

                lblRecordsInDisplay.Text = "Showing <b>" + startFrom.ToString() + " to " + endAt.ToString() + " of " + totalRecords.ToString() + " </b>entries " + String.Format(" <b>[Page {0:0} of {1:0}] </b>", PageIndex + 1, gvDepartmentListing.PageCount);

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SearchString = txtSearch.Text.Trim();
            BindgvDepartmentListing();
            txtSearch.Attributes["onfocus"] = "var value = this.value; this.value = ''; this.value = value; onfocus = null;";
            txtSearch.Focus();
        }

        protected void lnkbtnPrint_Click(object sender, EventArgs e)
        {
            BindgvDepartmentListing();
            var hidecolumns = new List<int>() { 0 };
            HospiceHelper.Printgv(gvDepartmentListing, hidecolumns);
        }

        protected void lnkbtnXl_Click(object sender, EventArgs e)
        {
            BindgvDepartmentListing();
            var hidecolumns = new List<int>() { 0 };
            HospiceHelper.ExporttoXl(gvDepartmentListing, hidecolumns, "MDepartmentList");
        }
    }
}