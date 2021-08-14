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
    public partial class UserListing : System.Web.UI.Page
    {
        private string SearchString = ""; private int branchid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            branchid = int.Parse(Session["CurrentBranch"].ToString());
            txtSearch.Attributes.Add("onkeyup", "initjsfun();");
            txtSearch.Focus();
            if (!IsPostBack)
            {
                btnAddNew.HRef = "UserEntry";
                BindgvUserListing();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "pageinfo();", true);
            if (gvUserListing.Rows.Count > 0)
            {
                gvUserListing.UseAccessibleHeader = true;
                gvUserListing.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvUserListing.BottomPagerRow.Visible = true;
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            
        }
        protected void gvUserListing_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUserListing.PageIndex = e.NewPageIndex;
            BindgvUserListing();
        }

        protected void gvUserListing_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void ddlPaging_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvUserListing.PageSize = int.Parse(ddlPaging.SelectedValue);
            BindgvUserListing();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SearchString = txtSearch.Text.Trim();
            BindgvUserListing();
            txtSearch.Attributes["onfocus"] = "var value = this.value; this.value = ''; this.value = value; onfocus = null;";
            txtSearch.Focus();
        }

        private void BindgvUserListing()
        {
            using (Duser duser = new Duser())
            {
                int selectedPageSize = int.Parse(ddlPaging.SelectedValue);
                gvUserListing.PageSize = selectedPageSize;

                var _getresult = duser.GetUserList(branchid).ToList();
                if (SearchString != "")
                    _getresult = duser.GetUserList(branchid).Where(x => x.UsrFirstName == SearchString || x.UsrEmail == SearchString || x.UsrContactNo == SearchString || x.UsrLoginName == SearchString || x.DOB.ToString() == SearchString).ToList();
                gvUserListing.DataSource = _getresult.OrderByDescending(x => x.UsrId).ToList();
                gvUserListing.DataBind();

                int totalRecords = _getresult.Count();
                int PageIndex = gvUserListing.PageIndex;

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

                lblRecordsInDisplay.Text = "Showing <b>" + startFrom.ToString() + " to " + endAt.ToString() + " of " + totalRecords.ToString() + " </b>entries " + String.Format(" <b>[Page {0:0} of {1:0}] </b>", PageIndex + 1, gvUserListing.PageCount);

            }
        }
    }
}