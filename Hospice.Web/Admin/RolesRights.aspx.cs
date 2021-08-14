using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Hospice.DAL;

namespace Hospice.Web.Admin
{
    public partial class RolesRights : System.Web.UI.Page
    {
        //private dsUsers.RoleRightsDataTable _GlobalRoleRightTable;
        //private dsUsers.RoleRightsDataTable _GlobalReportRightTable;

        bool CheckHeadView = true;
        bool CheckHeadCreate = true;
        bool CheckHeadEdit = true;
        bool CheckHeadDelete = true;
        bool CheckReportView = true;
        bool CheckReportCreate = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillddlRole();
            }
        }

        protected void grdRights_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdRights.PageIndex = e.NewPageIndex;
        }
        protected void grdRights_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CheckBox chk;
            CheckBox chkCreate;
            CheckBox chkEdit;
            CheckBox chkDelete;

            if (e.Row.RowType == DataControlRowType.Header)
            {
                chk = (CheckBox)e.Row.FindControl("chkHed");
                chk.Attributes["onclick"] = "javascript:CheckUncheckView('" + grdRights.ClientID.ToString() + "',event);";

                chk = (CheckBox)e.Row.FindControl("chkHeadCreate");
                chk.Attributes["onclick"] = "javascript:CheckUncheckCreate('" + grdRights.ClientID.ToString() + "',event);";


                chk = (CheckBox)e.Row.FindControl("chkhedEdit");
                chk.Attributes["onclick"] = "javascript:CheckUncheckEdit('" + grdRights.ClientID.ToString() + "',event);";


                chk = (CheckBox)e.Row.FindControl("chkHedDelete");
                chk.Attributes["onclick"] = "javascript:CheckUncheckDelete('" + grdRights.ClientID.ToString() + "',event);";

            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                chk = (CheckBox)e.Row.FindControl("chkItem");
                chk.Attributes["onclick"] = "javascript:CheckOthersView('" + grdRights.ClientID.ToString() + "',event);";

                /* Author- Nitin Tiwari
                  Date-   17-Jan-2009
                  Desc-   It is used when we select or deselect "View" checkBox on Report section.
                          Create checkboxes will be ebabled if view is checked. 
                */

                CheckBox chkViewReport = (CheckBox)e.Row.FindControl("chkItem");
                chkViewReport.Attributes["onclick"] = "javascript:ViewIsCheckedReport('" + grdRights.ClientID.ToString() + "','" + chkViewReport.ClientID.ToString() + "');";


                //chkCreate
                chk = (CheckBox)e.Row.FindControl("chkCreate");
                chk.Attributes["onclick"] = "javascript:CheckOthersCreate('" + grdRights.ClientID.ToString() + "',event);";
                //chkEdit
                chk = (CheckBox)e.Row.FindControl("chkEdit");
                chk.Attributes["onclick"] = "javascript:CheckOthersEdit('" + grdRights.ClientID.ToString() + "',event);";
                //Delete
                chk = (CheckBox)e.Row.FindControl("chkDelete");
                chk.Attributes["onclick"] = "javascript:CheckOthersDelete('" + grdRights.ClientID.ToString() + "',event);";
                //  to hide create/edit/delete checkboxes of "Login" rights

                chkCreate = (CheckBox)e.Row.FindControl("chkCreate");
                if (int.Parse(chkCreate.Attributes["KeyValue"].ToString()) == 1)
                {
                    chkCreate.Checked = true;
                    chkCreate.Enabled = false;
                    chkCreate.Visible = false;
                }
                chkEdit = (CheckBox)e.Row.FindControl("chkEdit");
                if (int.Parse(chkCreate.Attributes["KeyValue"].ToString()) == 1)
                {
                    chkEdit.Checked = true;
                    chkEdit.Enabled = false;
                    chkEdit.Visible = false;
                }
                chkDelete = (CheckBox)e.Row.FindControl("chkDelete");
                if (int.Parse(chkCreate.Attributes["KeyValue"].ToString()) == 1)
                {
                    chkDelete.Checked = true;
                    chkDelete.Enabled = false;
                    chkDelete.Visible = false;
                }

                if (int.Parse(chkCreate.Attributes["KeyValue"].ToString()) == 12)
                {
                    chkCreate.Checked = true;
                    chkCreate.Enabled = false;
                    chkCreate.Visible = false;
                    chkDelete.Visible = false;
                    chkEdit.Visible = false;
                }
                if (int.Parse(chkCreate.Attributes["KeyValue"].ToString()) == 13)
                {
                    chkCreate.Checked = true;
                    chkCreate.Enabled = false;
                    chkCreate.Visible = false;
                    chkDelete.Visible = false;
                    chkEdit.Visible = false;
                }
                if (int.Parse(chkCreate.Attributes["KeyValue"].ToString()) == 14)
                {
                    chkCreate.Checked = true;
                    chkCreate.Enabled = false;
                    chkCreate.Visible = false;
                    chkDelete.Visible = false;
                    chkEdit.Visible = false;
                }
                /* Container Summary  */
                if (int.Parse(chkCreate.Attributes["KeyValue"].ToString()) == 7)
                {
                    chkDelete.Visible = false;
                    chkCreate.Visible = false;
                    chkEdit.Visible = false;
                }
                if (int.Parse(chkCreate.Attributes["KeyValue"].ToString()) == 15)
                {
                    chkDelete.Visible = true;
                    chkCreate.Visible = false;
                    chkEdit.Visible = true;
                }
                if (int.Parse(chkCreate.Attributes["KeyValue"].ToString()) == 10)
                {
                    chkDelete.Visible = false;
                    chkCreate.Visible = false;
                    chkEdit.Visible = false;
                }
                chk = (CheckBox)e.Row.FindControl("chkItem");
                if (int.Parse(chkCreate.Attributes["KeyValue"].ToString()) == 10)
                {
                    chk.Checked = false;
                    chkDelete.Visible = false;
                    chkCreate.Visible = false;
                    chkEdit.Visible = false;
                    e.Row.Visible = false;
                }
                // To hide  users
                if (int.Parse(chkCreate.Attributes["KeyValue"].ToString()) == 9)
                {
                    chk.Checked = false;
                    e.Row.Visible = false;
                }
                // To hide Role right
                if (int.Parse(chkCreate.Attributes["KeyValue"].ToString()) == 26)
                {
                    chk.Checked = false;
                    e.Row.Visible = false;
                }
                // To hide mail setting right
                if (int.Parse(chkCreate.Attributes["KeyValue"].ToString()) == 30)
                {
                    chk.Checked = false;
                    e.Row.Visible = false;
                }
                // To hide mail company information right
                if (int.Parse(chkCreate.Attributes["KeyValue"].ToString()) == 28)
                {
                    chk.Checked = false;
                    e.Row.Visible = false;
                }
                if (int.Parse(chkCreate.Attributes["KeyValue"].ToString()) == 6)
                {
                    chkDelete.Visible = false;
                    chkCreate.Visible = false;
                    chkEdit.Visible = false;
                }

                if (int.Parse(chk.Attributes["KeyValue"].ToString()) == 29)
                {
                    chkDelete.Visible = false;
                    chkCreate.Visible = false;
                }
                if (int.Parse(chk.Attributes["KeyValue"].ToString()) == 28)
                {
                    chkDelete.Visible = false;
                    chkCreate.Visible = false;
                }
                if (int.Parse(chk.Attributes["KeyValue"].ToString()) == 25)
                {
                    chkDelete.Visible = false;
                    chkCreate.Visible = false;

                }
                // hide Bills payable depots right.
                if (int.Parse(chk.Attributes["KeyValue"].ToString()) == 5)
                {
                    chk.Checked = false;
                    chkCreate.Visible = false;
                    e.Row.Visible = false;
                }

                // hide Bills payable surveyor right.
                if (int.Parse(chk.Attributes["KeyValue"].ToString()) == 36)
                {
                    chk.Checked = false;
                    chkCreate.Visible = false;
                    e.Row.Visible = false;
                }
                // hide surveyor report.
                if (int.Parse(chk.Attributes["KeyValue"].ToString()) == 37)
                {
                    chk.Checked = false;
                    chkCreate.Visible = false;
                    chkDelete.Visible = false;
                    chkEdit.Visible = false;
                    e.Row.Visible = false;
                }
                // hide depot repot.
                if (int.Parse(chk.Attributes["KeyValue"].ToString()) == 38)
                {
                    chk.Checked = false;
                    chkCreate.Visible = false;
                    chkDelete.Visible = false;
                    chkEdit.Visible = false;
                    e.Row.Visible = false;
                }
                if (int.Parse(chk.Attributes["KeyValue"].ToString()) == 39)
                {
                    chkCreate.Visible = true;
                    chkDelete.Visible = true;
                    chkEdit.Visible = true;
                }

                if (int.Parse(chk.Attributes["KeyValue"].ToString()) == 34)
                {
                    chkCreate.Visible = false;
                    chkDelete.Visible = false;
                    //chkEdit.Visible = true;
                    chkEdit.Visible = false;
                    e.Row.Cells[4].Text = "Repair Expenses-Payable";
                }

                if (int.Parse(chk.Attributes["KeyValue"].ToString()) == 35)
                {
                    chkCreate.Visible = false;
                    chkDelete.Visible = false;
                    chkEdit.Visible = false;
                }
                chk = (CheckBox)e.Row.FindControl("chkItem");
                if (int.Parse(chkCreate.Attributes["KeyValue"].ToString()) == 31)
                {
                    chk.Checked = false;
                    e.Row.Visible = false;
                }
                chk = (CheckBox)e.Row.FindControl("chkItem");
                if (int.Parse(chkCreate.Attributes["KeyValue"].ToString()) == 41)
                {
                    chkCreate.Visible = false;
                    chkEdit.Visible = false;
                }
                /*  To hide ISO Specification */
                chk = (CheckBox)e.Row.FindControl("chkItem");
                if (int.Parse(chkCreate.Attributes["KeyValue"].ToString()) == 43)
                {
                    chk.Checked = false;
                    e.Row.Visible = false;
                }
            }

        }

        private void FillddlRole()
        {
            using (Drole drole = new Drole())
            {
                var rolelist = drole.GetRoleList();
                ddlRoleName.DataSource = rolelist;
                ddlRoleName.DataTextField = "";
                ddlRoleName.DataValueField = "";
                ddlRoleName.DataBind();
                ddlRoleName.Items.Insert(0, new ListItem("Select Role", ""));
            }
        }
        public int UserRoleId
        {
            get
            {
                return int.Parse(ViewState["UserRoleId"].ToString());
            }
            set
            {
                ViewState["UserRoleId"] = value;
                UserRole _UserRole = new UserRole();
                dsUsers.RoleRow _RoleRow = _UserRole.GetUserRoleById(UserRoleId);
                txtRoleName.Text = _RoleRow.Rl_Description.ToString();
                txtRoleName.ReadOnly = false;
                if (txtRoleName.Text == "Admin")
                {
                    txtRoleName.ReadOnly = true;
                }
            }
        }
        private void BindGrid()
        {
            Right _Right = new Right();
            dsUsers.RightsDataTable _RightsTable = _Right.GetRightList();
            dsUsers.RightsDataTable _RightReportTable = _Right.GetRightReportList();
            RoleRight _RoleRight = new RoleRight();
            if (Mode == CLATransactionMode.enModify)
            {
                _GlobalRoleRightTable = _RoleRight.GetRoleRightListAccRole(UserRoleId);
                _GlobalReportRightTable = _RoleRight.GetReportRoleRightAccRole(UserRoleId);
            }
            else
            {
                _GlobalRoleRightTable = _RoleRight.GetRoleRightList();
                _GlobalReportRightTable = _RoleRight.GetReportRoleRightList();
            }
            grdRights.DataSource = _RightsTable;
            grdRights.DataBind();
            GrdReports.DataSource = _RightReportTable;
            GrdReports.DataBind();
        }
        public void HideRightsForUser()
        {
            try
            {

                for (int i = 0; i <= grdRights.Rows.Count - 1; i++)
                {
                    Label lblRole = (Label)grdRights.Rows[i].FindControl("LblRights");

                    if (lblRole.Text.Equals("Role"))
                    {
                        grdRights.Rows[i].Visible = false;
                    }
                    Label lblmailsett = (Label)grdRights.Rows[i].FindControl("LblRights");

                    if (lblmailsett.Text.Equals("Mail Setting"))
                    {
                        grdRights.Rows[i].Visible = false;
                    }

                    Label lblUsers = (Label)grdRights.Rows[i].FindControl("LblRights");

                    if (lblUsers.Text.Equals("Users"))
                    {
                        grdRights.Rows[i].Visible = false;
                    }
                }
            }
            catch (IndexOutOfRangeException exHide)
            {
                // do nothing.
            }
        }

        public Boolean HasDeleteRight(long DeleteID)
        {
            _GlobalRoleRightTable.DefaultView.RowFilter = "RR_Delete=" + DeleteID;
            if (_GlobalRoleRightTable.DefaultView.Count > 0)
            {
                return true;
            }
            else
            {
                if (DeleteID != 9 && DeleteID != 26 && DeleteID != 37 && DeleteID != 43 && DeleteID != 31 && DeleteID != 38 && DeleteID != 36 && DeleteID != 5 && DeleteID != 28 && DeleteID != 30 && DeleteID != 10 && DeleteID != 6 && DeleteID != 35 && DeleteID != 29 && DeleteID != 14 && DeleteID != 13 && DeleteID != 12 && DeleteID != 25 && DeleteID != 34 && DeleteID != 21)
                    CheckHeadDelete = false;
                return false;
            }
        }

        public Boolean HasEditRight(long EditID)
        {
            _GlobalRoleRightTable.DefaultView.RowFilter = "RR_Edit=" + EditID;
            if (_GlobalRoleRightTable.DefaultView.Count > 0)
            {
                return true;
            }
            else
            {
                if (EditID != 9 && EditID != 26 && EditID != 37 && EditID != 43 && EditID != 31 && EditID != 38 && EditID != 36 && EditID != 5 && EditID != 6 && EditID != 35 && EditID != 28 && EditID != 14 && EditID != 13 && EditID != 12 && EditID != 41 && EditID != 30 && EditID != 34 && EditID != 10)
                    CheckHeadEdit = false;
                return false;
            }
        }

        public Boolean HasCreatetRight(long CreateID)
        {
            _GlobalRoleRightTable.DefaultView.RowFilter = "RR_Create=" + CreateID;
            if (_GlobalRoleRightTable.DefaultView.Count > 0)
            {
                return true;
            }
            else
            {
                if (CreateID != 9 && CreateID != 26 && CreateID != 37 && CreateID != 43 && CreateID != 31 && CreateID != 38 && CreateID != 36 && CreateID != 5 && CreateID != 28 && CreateID != 30 && CreateID != 10 && CreateID != 6 && CreateID != 29 && CreateID != 41 && CreateID != 15 && CreateID != 25 && CreateID != 34 && CreateID != 35)
                    CheckHeadCreate = false;
                return false;
            }
        }

        public Boolean HasRight(long RightID)
        {

            _GlobalRoleRightTable.DefaultView.RowFilter = "RR_RightID=" + RightID;
            if (_GlobalRoleRightTable.DefaultView.Count > 0)
            {
                return true;

            }
            else
            {
                /* 
                Purpose :Some rights are either havs been removed or not in use so need to check those right.So that
                          we can find all view right are available for this role.If "CheckHeadView" returns true then
                         we can make sure for Header checkbox should be checked.  */
                if (RightID != 9 && RightID != 26 && RightID != 37 && RightID != 43 && RightID != 31 && RightID != 38 && RightID != 36 && RightID != 5 && RightID != 28 && RightID != 30 && RightID != 10)
                    CheckHeadView = false;
                return false;
            }

        }

        public Boolean IsCheckedView(long RightID)
        {
            if (HasRight(RightID))
            {
                return true;
            }
            else
                return false;
        }
    }
}