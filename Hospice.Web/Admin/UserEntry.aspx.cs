using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospice.Helper;
using Hospice.DAL;
using Hospice.Web.App_Code;

namespace Hospice.Web.Admin
{
    public partial class UserEntry : BasePage
    {
        private int _uid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["_usrid"] != null)
            {
                _uid = Convert.ToInt32(Request.QueryString["_usrid"].ToString());
            }
            if (!IsPostBack)
            {
                //WebHelper.fillddlCity(ddlCity);

                if (_uid > 0)
                {
                   GetUserDetailbyid();
                }
            }
        }
        private void GetUserDetailbyid(object sender=null, EventArgs e=null)
        {
            using (Duser duser = new Duser())
            {
                var _getresult = duser.GetUserDetailsById(_uid);

                txtFirstName.Text = _getresult.UsrFirstName.ToString();
                if(_getresult.UsrLastName != null)
                txtLastName.Text = _getresult.UsrLastName.ToString();
                if(_getresult.UsrContactNo != null)
                txtContact.Text = _getresult.UsrContactNo.ToString();
                txtEmail.Text = _getresult.UsrEmail.ToString();
                if(_getresult.UsrAddress!=null)
                txtAddress.Text = _getresult.UsrAddress.ToString();
                if (_getresult.UsrCity != null)
                    ddlCity.SelectedValue = _getresult.UsrCity.ToString();
                ddlUserType.SelectedValue = _getresult.Usertype.ToString();
                ddlUserType_SelectedIndexChanged(sender, e);
                ddlUserTypeId.SelectedValue = _getresult.UsertypeId.ToString();
                ddlStatus.SelectedValue = _getresult.UsrStatus.ToString();

                txtloginName.Text = _getresult.UsrLoginName.ToString();
                txtPassword.Attributes.Remove("required");
            }
        }

        private void FillddlEmployee(int emptypeid)
        {
            using (Demployee demployee = new Demployee())
            {
                var emplist = demployee.GetEmpMasterList().Where(x => x.EmpType == emptypeid).ToList();
                ddlUserTypeId.DataSource = emplist;
                ddlUserTypeId.DataTextField = "EmpName";
                ddlUserTypeId.DataValueField = "EmpId";
                ddlUserTypeId.DataBind();
                ddlUserTypeId.Items.Insert(0, new ListItem("Select", ""));
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int _issaveref = SaveuserDetails();
                if (_issaveref == -1)
                {
                    HospiceHelper.SendAlert("SsMessage:\n Login Name " + txtloginName.Text.ToUpper().Trim() + " is already exist.");
                }
                else if (_issaveref > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "ClearTextBoxes();", true);

                    HospiceHelper.SendAlert("SsMessage:\n User has been successfully saved.", "UserListing");

                }
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\nUser not save.\n" + ex.Message);
            }
        }

        private int SaveuserDetails()
        {
            int result = 0;

            if (txtFirstName.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter first name");
                txtFirstName.Focus();
                return -1;
            }
            
            if (txtloginName.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter login name");
                txtloginName.Focus();
                return -1;
            }
           
            if (txtEmail.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter email.");
                ddlStatus.Focus();
                return -1;
            }
            if (ddlUserType.SelectedIndex == 0 )
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease select user type.");
                return -1;
            }
            if (ddlUserType.SelectedIndex ==1 && ddlUserTypeId.SelectedIndex == 0)
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease select staffid or employeeid.");
                return -1;
            }
            if (ddlUserType.SelectedIndex == 2 && ddlUserTypeId.SelectedIndex == 0)
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease select doctorid.");
                return -1;
            }
            if (ddlUserType.SelectedIndex == 3 && ddlUserTypeId.SelectedIndex == 0)
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease select patientid.");
                return -1;
            }
            using ( Duser _objusers = new Duser())
            {

                if (_uid > 0)
                    _objusers.ObjTblUserMaster = _objusers.GetUserDetailsById(_uid);

                _objusers.ObjTblUserMaster.UsrFirstName = txtFirstName.Text.Trim();
                _objusers.ObjTblUserMaster.UsrLastName = txtLastName.Text.Trim();

                _objusers.ObjTblUserMaster.UsrStatus = Convert.ToInt16(ddlStatus.SelectedValue.ToString());
                _objusers.ObjTblUserMaster.Usertype = Convert.ToInt32(ddlUserType.SelectedValue.ToString());
                _objusers.ObjTblUserMaster.UsertypeId = Convert.ToInt32(ddlUserTypeId.SelectedValue.ToString());

                _objusers.ObjTblUserMaster.UsrAddress = txtAddress.Text.ToString().Trim();
                if(ddlCity.SelectedIndex>0)
                _objusers.ObjTblUserMaster.UsrCity = Convert.ToInt32(ddlCity.SelectedValue.ToString());

                _objusers.ObjTblUserMaster.UsrEmail = txtEmail.Text.Trim();
                _objusers.ObjTblUserMaster.UsrContactNo = txtContact.Text.Trim();
                _objusers.ObjTblUserMaster.UsrLoginName = txtloginName.Text.Trim();
                _objusers.ObjTblUserMaster.BranchId = Convert.ToInt32(Session["CurrentBranch"]);


                using (HospiceSession objmysession = new HospiceSession())
                {
                    if (_uid > 0)
                    {
                        _objusers.ObjTblUserMaster.UpdatedBy = Convert.ToInt32(LogedinUID);
                        _objusers.ObjTblUserMaster.UpdatedOn = objmysession.CurrentDT;

                        result = _objusers.UpdateUser(_objusers.ObjTblUserMaster);
                    }
                    else
                    {
                        txtPassword.Text = txtloginName.Text.Trim();
                        if (txtPassword.Text.Trim() != "")
                            _objusers.ObjTblUserMaster.UsrPassword = txtPassword.Text.Trim();

                        _objusers.ObjTblUserMaster.CreatedBy = Convert.ToInt32(LogedinUID);
                        _objusers.ObjTblUserMaster.CreatedOn = objmysession.CurrentDT;

                        result = _objusers.InsertUser(_objusers.ObjTblUserMaster);
                    }
                }
            }
            return result;
        }

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlUserType.SelectedIndex>0)
                FillddlEmployee(Convert.ToInt16(ddlUserType.SelectedValue));
        }
    }
}