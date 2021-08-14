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
    public partial class ServiceListing : BasePage
    {
        private string SearchString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
          //  txtSearch.Attributes.Add("onkeyup", "initjsfun();");
            //txtSearch.Focus();
            if (!IsPostBack)
            {
                btnAddNew.HRef = "ServiceEntry?servicetype=1";
                btnAddother.HRef = "ServiceEntry?servicetype=0";
                BindgvServiceListing();
                BindgvServiceListingother();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "pageinfo();", true);
            if (gvServiceListing.Rows.Count > 0)
            {
                gvServiceListing.UseAccessibleHeader = true;
                gvServiceListing.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvServiceListing.BottomPagerRow.Visible = true;
            }

        }
        // Appoinment Service
        protected void gvServiceListing_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvServiceListing.PageIndex = e.NewPageIndex;
            BindgvServiceListing();
        }
        protected void gvServiceListing_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //System.Threading.Thread.Sleep(2000);
            try
            {
                if (e.CommandName == "btnDelete")
                {
                    int _Exerid = Convert.ToInt32(e.CommandArgument);
                    using (Dservice objexer = new Dservice())
                    {
                        var _getresult = objexer.DeleteService(_Exerid);

                    }
                    HospiceHelper.SendAlert("SsMessage:\n Service has been successfully deleted.");
                }
                BindgvServiceListing();
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\n" + ex.Message);
            }
        }

        



        //protected void ddlPaging_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    gvServiceListing.PageSize = int.Parse(ddlPaging.SelectedValue);
        //    BindgvServiceListing();
        //}

        private void BindgvServiceListing()
        {
            using (Dservice objservice = new Dservice())
            {
               // int selectedPageSize = int.Parse(ddlPaging.SelectedValue);
               // gvServiceListing.PageSize = selectedPageSize;

                var _getresult = objservice.GetServiceMasterList().ToList();
                if (SearchString != "")
                    _getresult = objservice.GetServiceMasterList().Where(x => x.SericeCode == SearchString || x.ServiceName == SearchString).ToList();
                gvServiceListing.DataSource = _getresult.OrderByDescending(x => x.Serviceid).ToList();
                gvServiceListing.DataBind();

                int totalRecords = _getresult.Count();
                int PageIndex = gvServiceListing.PageIndex;

                int startFrom;
                int endAt;

                if (totalRecords == 0)
                {
                    lblRecordsInDisplay.Text = "";
                    return;
                }

                //if (((PageIndex + 1) * selectedPageSize) > totalRecords)
                //{
                //    startFrom = (PageIndex * selectedPageSize) + 1;
                //    endAt = totalRecords;
                //}
                //else
                //{
                //    startFrom = (PageIndex * selectedPageSize) + 1;
                //    endAt = ((PageIndex + 1) * selectedPageSize);
                //}

              //  lblRecordsInDisplay.Text = "Showing <b>" + startFrom.ToString() + " to " + endAt.ToString() + " of " + totalRecords.ToString() + " </b>entries " + String.Format(" <b>[Page {0:0} of {1:0}] </b>", PageIndex + 1, gvServiceListing.PageCount);

            }
        }
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    SearchString = txtSearch.Text.Trim();
        //    BindgvServiceListing();
        //    txtSearch.Attributes["onfocus"] = "var value = this.value; this.value = ''; this.value = value; onfocus = null;";
        //    txtSearch.Focus();
        //}

        protected void lnkbtnPrint_Click(object sender, EventArgs e)
        {
            BindgvServiceListing();
            var hidecolumns = new List<int>() { 0 };
            HospiceHelper.Printgv(gvServiceListing, hidecolumns);
        }

        protected void lnkbtnXl_Click(object sender, EventArgs e)
        {
            BindgvServiceListing();
            var hidecolumns = new List<int>() { 0 };
            HospiceHelper.ExporttoXl(gvServiceListing, hidecolumns, "MServiceList");
        }


        // other service 

        private void BindgvServiceListingother()
        {
            using (Dservice objservice = new Dservice())
            {
               // int selectedPageSize = int.Parse(ddlPaging.SelectedValue);
               // gvServiceListing.PageSize = selectedPageSize;

                var _getresult = objservice.GetOtherServiceMasterList().ToList();
                if (SearchString != "")
                    _getresult = objservice.GetOtherServiceMasterList().Where(x => x.SericeCode == SearchString || x.ServiceName == SearchString).ToList();
                gvServiceListingother.DataSource = _getresult.OrderByDescending(x => x.Serviceid).ToList();
                gvServiceListingother.DataBind();

                int totalRecords = _getresult.Count();
                int PageIndex = gvServiceListingother.PageIndex;

                //int startFrom;
                //int endAt;

                if (totalRecords == 0)
                {
                    lblRecordsInDisplay.Text = "";
                    return;
                }

                //if (((PageIndex + 1) * selectedPageSize) > totalRecords)
                //{
                //    startFrom = (PageIndex * selectedPageSize) + 1;
                //    endAt = totalRecords;
                //}
                //else
                //{
                //    startFrom = (PageIndex * selectedPageSize) + 1;
                //    endAt = ((PageIndex + 1) * selectedPageSize);
                //}

                //lblRecordsInDisplay.Text = "Showing <b>" + startFrom.ToString() + " to " + endAt.ToString() + " of " + totalRecords.ToString() + " </b>entries " + String.Format(" <b>[Page {0:0} of {1:0}] </b>", PageIndex + 1, gvServiceListing.PageCount);

            }
        }


        // Appoinment Service
        protected void gvServiceListingother_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvServiceListing.PageIndex = e.NewPageIndex;
            BindgvServiceListing();
        }
        protected void gvServiceListingother_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //System.Threading.Thread.Sleep(2000);
            try
            {
                if (e.CommandName == "btnDelete")
                {
                    int _Exerid = Convert.ToInt32(e.CommandArgument);
                    using (Dservice objexer = new Dservice())
                    {
                        var _getresult = objexer.DeleteService(_Exerid);

                    }
                    HospiceHelper.SendAlert("SsMessage:\n Service has been successfully deleted.");
                }
                BindgvServiceListing();
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\n" + ex.Message);
            }
        }


    }
}