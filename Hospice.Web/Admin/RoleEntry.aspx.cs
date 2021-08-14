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
    public partial class RoleEntry : BasePage
    {
        int _roleid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["_rlid"] != null)
            {
                _roleid = Convert.ToInt32(Request.QueryString["_rlid"].ToString());
            }

            if (!IsPostBack)
            {
                if (_roleid > 0)
                {
                    GetRoleDetailbyid();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int _issaverole = SaveRole();
                if (_issaverole == -1)
                {
                    HospiceHelper.SendAlert("SsMessage:\n Role Name " + txtRoleName.Text.ToUpper().Trim() + " is already exist.");
                }
                else if (_issaverole > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "ClearTextBoxes();", true);
                    HospiceHelper.SendAlert("SsMessage:\n Role has been successfully saved.", "RoleListing");

                }
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\nRole not save.\n" + ex.Message);
            }
        }
        private void GetRoleDetailbyid()
        {
            using (Drole objdrole = new Drole())
            {
                var _getresult = objdrole.GetRoleDetailsById(_roleid);

                txtRoleName.Text = _getresult.RlName;
                txtRoleDescription.Text = _getresult.RlDescription;
                ddlStatus.SelectedValue = _getresult.RlIsActive.ToString();
            }
        }
        private int SaveRole()
        {
            int result = 0;

            if (txtRoleName.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter role name");
                txtRoleName.Focus();
                return -1;
            }

            if (ddlStatus.SelectedIndex == 0)
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease select status.");
                ddlStatus.Focus();
                return -1;
            }

            using (Drole _objdrole = new Drole())
            {

                if (_roleid > 0)
                    _objdrole.ObjTblRoleMaster = _objdrole.GetRoleDetailsById(_roleid);

                _objdrole.ObjTblRoleMaster.RlName = txtRoleName.Text.Trim();
                _objdrole.ObjTblRoleMaster.RlDescription = txtRoleDescription.Text.Trim();

                _objdrole.ObjTblRoleMaster.RlIsActive = Convert.ToInt16(ddlStatus.SelectedValue.ToString()) == 1 ? true : false;

                _objdrole.ObjTblRoleMaster.RlIsDeleted = false;

                using (HospiceSession objmysession = new HospiceSession())
                {
                    if (_roleid > 0)
                    {
                        _objdrole.ObjTblRoleMaster.UpdatedBy = Convert.ToInt32(LogedinUID);
                        _objdrole.ObjTblRoleMaster.UpdatedOn = objmysession.CurrentDT;

                        result = _objdrole.UpdateRole(_objdrole.ObjTblRoleMaster);
                    }
                    else
                    {

                        _objdrole.ObjTblRoleMaster.CreatedBy = Convert.ToInt32(LogedinUID);
                        _objdrole.ObjTblRoleMaster.CreatedOn = objmysession.CurrentDT;

                        result = _objdrole.InsertRole(_objdrole.ObjTblRoleMaster);
                    }
                }


            }
            return result;
        }
    }
}