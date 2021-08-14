using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospice.DAL;
using Hospice.Helper;
using Hospice.Web.App_Code;

namespace Hospice.Web.Admin
{
    public partial class StateListing : System.Web.UI.Page
    {
        private string SearchString = "";
      
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSearch.Attributes.Add("onkeyup", "initjsfun();");
            txtSearch.Focus();
            if (!IsPostBack)
            {
                btnAddNew.HRef = "StateEntry";
                BindgvStateListing();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "pageinfo();", true);
            if (gvStateListing.Rows.Count > 0)
            {
                gvStateListing.UseAccessibleHeader = true;
                gvStateListing.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvStateListing.BottomPagerRow.Visible = true;
            }

        }

        protected void gvStateListing_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvStateListing.PageIndex = e.NewPageIndex;
            BindgvStateListing();
        }
        protected void gvStateListing_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //System.Threading.Thread.Sleep(2000);
            try
            {
                if (e.CommandName == "btnDelete")
                {
                    int _Exerid = Convert.ToInt32(e.CommandArgument);
                    using (Dstate objexer = new Dstate())
                    {
                        var _getresult = objexer.DeleteLocState(_Exerid);

                    }
                    HospiceHelper.SendAlert("SsMessage:\n State has been successfully deleted.");
                }
                BindgvStateListing();
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\n" + ex.Message);
            }
        }

        protected void ddlPaging_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvStateListing.PageSize = int.Parse(ddlPaging.SelectedValue);
            BindgvStateListing();
        }

        private void BindgvStateListing(string sortexp = "StateName")
        {
            //System.Threading.Thread.Sleep(2000);
            using (Dstate objdloc = new Dstate())
            {

                int selectedPageSize = int.Parse(ddlPaging.SelectedValue);
                gvStateListing.PageSize = selectedPageSize;

                if (objdloc.GetStateList().Rows.Count > 0)
                {
                    DataTable _getresult = objdloc.GetStateList().Select("Status=1").CopyToDataTable();
                    if (SearchString != "")
                    {
                        var tt = _getresult.Select("StateCode like '%" + SearchString + "%' or StateName like '%" + SearchString + "%' or CountryName like '%" + SearchString + "%'");
                        if (tt.Count() > 0)
                            _getresult = tt.CopyToDataTable();
                        else
                            _getresult = new DataTable();


                    }
                    gvStateListing.DataSource = _getresult;
                    gvStateListing.DataBind();

                    int totalRecords = _getresult.Rows.Count > 0 ? _getresult.Rows.Count : 0;
                    int PageIndex = gvStateListing.PageIndex;

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

                    lblRecordsInDisplay.Text = "Showing <b>" + startFrom.ToString() + " to " + endAt.ToString() + " of " + totalRecords.ToString() + " </b>entries " + String.Format(" <b>[Page {0:0} of {1:0}] </b>", PageIndex + 1, gvStateListing.PageCount);
                }
                


            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SearchString = txtSearch.Text.Trim();
            BindgvStateListing();
            txtSearch.Attributes["onfocus"] = "var value = this.value; this.value = ''; this.value = value; onfocus = null;";
            txtSearch.Focus();
        }

        protected void lnkbtnPrint_Click(object sender, EventArgs e)
        {
            BindgvStateListing();
            var hidecolumns = new List<int>() { 0 };
            HospiceHelper.Printgv(gvStateListing, hidecolumns);
        }

        protected void lnkbtnXl_Click(object sender, EventArgs e)
        {
            BindgvStateListing();
            var hidecolumns = new List<int>() { 0 };
            HospiceHelper.ExporttoXl(gvStateListing, hidecolumns, "MStateList");
        }
    }
}