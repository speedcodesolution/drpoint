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
    public partial class CityListing : System.Web.UI.Page
    {
        private string SearchString = "";
      
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSearch.Attributes.Add("onkeyup", "initjsfun();");
            txtSearch.Focus();
            if (!IsPostBack)
            {
                btnAddNew.HRef = "CityEntry";
                BindgvCityListing();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "pageinfo();", true);
            if (gvCityListing.Rows.Count > 0)
            {
                gvCityListing.UseAccessibleHeader = true;
                gvCityListing.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvCityListing.BottomPagerRow.Visible = true;
            }

        }

        protected void gvCityListing_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCityListing.PageIndex = e.NewPageIndex;
            BindgvCityListing();
        }
        protected void gvCityListing_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //System.Threading.Thread.Sleep(2000);
            try
            {
                if (e.CommandName == "btnDelete")
                {
                    int _Exerid = Convert.ToInt32(e.CommandArgument);
                    using (Dcity objexer = new Dcity())
                    {
                        var _getresult = objexer.DeleteLocCity(_Exerid);

                    }
                    HospiceHelper.SendAlert("SsMessage:\n City has been successfully deleted.");
                }
                BindgvCityListing();
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\n" + ex.Message);
            }
        }

        protected void ddlPaging_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvCityListing.PageSize = int.Parse(ddlPaging.SelectedValue);
            BindgvCityListing();
        }

        private void BindgvCityListing(string sortexp = "CityName")
        {
            //System.Threading.Thread.Sleep(2000);
            using (Dcity objdloc = new Dcity())
            {

                int selectedPageSize = int.Parse(ddlPaging.SelectedValue);
                gvCityListing.PageSize = selectedPageSize;

                if (objdloc.GetcityList().Rows.Count > 0)
                {
                    DataTable _getresult = objdloc.GetcityList().Select("Status=1").CopyToDataTable();
                    if (SearchString != "")
                    {
                        var tt = _getresult.Select("CityCode like '%" + SearchString + "%' or CityName like '%" + SearchString + "%' or StateName like '%" + SearchString + "%'");
                        if (tt.Count() > 0)
                            _getresult = tt.CopyToDataTable();
                        else
                            _getresult = new DataTable();


                    }
                    gvCityListing.DataSource = _getresult;
                    gvCityListing.DataBind();

                    int totalRecords = _getresult.Rows.Count > 0 ? _getresult.Rows.Count : 0;
                    int PageIndex = gvCityListing.PageIndex;

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

                    lblRecordsInDisplay.Text = "Showing <b>" + startFrom.ToString() + " to " + endAt.ToString() + " of " + totalRecords.ToString() + " </b>entries " + String.Format(" <b>[Page {0:0} of {1:0}] </b>", PageIndex + 1, gvCityListing.PageCount);
                }
                


            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SearchString = txtSearch.Text.Trim();
            BindgvCityListing();
            txtSearch.Attributes["onfocus"] = "var value = this.value; this.value = ''; this.value = value; onfocus = null;";
            txtSearch.Focus();
        }

        protected void lnkbtnPrint_Click(object sender, EventArgs e)
        {
            BindgvCityListing();
            var hidecolumns = new List<int>() { 0 };
            HospiceHelper.Printgv(gvCityListing, hidecolumns);
        }

        protected void lnkbtnXl_Click(object sender, EventArgs e)
        {
            BindgvCityListing();
            var hidecolumns = new List<int>() { 0 };
            HospiceHelper.ExporttoXl(gvCityListing, hidecolumns, "MCityList");
        }
    }
}