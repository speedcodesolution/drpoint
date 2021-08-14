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
    public partial class DepartmentEntry : BasePage
    {
        private int _depid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["_depid"] != null)
            {
                _depid = Convert.ToInt32(Request.QueryString["_depid"].ToString());
               
            }
            else
            {
                btnbSavedepM.Visible = true;
               
            }
            if (!IsPostBack)
            {
                if (_depid > 0)
                    GetservuenceDetail();
            }
        }

        protected void btnbSavedepM_Click(object sender, EventArgs e)
        {

            try
            {
                int _issaveref = SaveDepartment();
                if (_issaveref == -1)
                {
                    HospiceHelper.SendAlert("SsMessage:\n Department Code " + txtdepCode.Text.ToUpper().Trim() + " is already exist.");
                }
                else if (_issaveref > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "ClearTextBoxes();", true);
                    HospiceHelper.SendAlert("SsMessage:\n Department has been successfully saved.", "DepartmentListing");

                }
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\n Department not save.\n" + ex.Message);
            }
        }
      
        private int SaveDepartment()
        {
            int result = 0;

            if (txtdepCode.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter code.");
                txtdepCode.Focus();
                return -1;
            }
            if (txtName.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter name.");
                txtName.Focus();
                return -1;
            }



            
            using (Ddepartment _objdep = new Ddepartment())
            {
                if (_depid > 0)
                _objdep.objtblDepartment = _objdep.Getdepbymasterid(_depid);
                _objdep.objtblDepartment.DepartmentCode = txtdepCode.Text.ToString();
                _objdep.objtblDepartment.DepartmentName = txtName.Text.ToString();
                _objdep.objtblDepartment.Description = txtDepDesc.Text.ToString();
                //_objdep.objTblService.Status = Convert.ToString(ddlStatus.SelectedValue.ToString())==1 ? true : false;
                _objdep.objtblDepartment.Status = Convert.ToInt32(ddlStatus.SelectedValue.ToString()) == 1 ? true : false;
                using (HospiceSession objmysession = new HospiceSession())
                {
                    if (_depid > 0)
                    {
                        _objdep.objtblDepartment.UpdatedBy = Convert.ToInt32(LogedinUID);
                        _objdep.objtblDepartment.UpdatedOn = objmysession.CurrentDT;
                        result = _objdep.Updatedep(_objdep.objtblDepartment);
                    }
                    else
                    {

                        _objdep.objtblDepartment.CreatedBy = Convert.ToInt32(LogedinUID);
                        _objdep.objtblDepartment.CreatedOn = objmysession.CurrentDT;

                        result = _objdep.Insertdep(_objdep.objtblDepartment);
                    }
                }
            }
            return result;
        }
        private void GetservuenceDetail()
        {
            using (Ddepartment _objdep = new Ddepartment())
            {
                var _servdet = _objdep.GetdepMasterList().Where(x => x.Departmentid == _depid).SingleOrDefault();
                txtdepCode.Text = _servdet.DepartmentCode.ToString();
                txtName.Text = _servdet.DepartmentName.ToString();
                txtDepDesc.Text = _servdet.Description.ToString();

            }
        }
    }
}