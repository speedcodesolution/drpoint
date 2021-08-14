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
    public partial class LabEntry : BasePage
    {
        private int _labid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["_labid"] != null)
            {
                _labid = Convert.ToInt32(Request.QueryString["_labid"].ToString());
               
            }
            else
            {
                btnbSavelbM.Visible = true;
               
            }
            if (!IsPostBack)
            {
                if (_labid > 0)
                    GetLabDetail();
            }
        }

        protected void btnbSavelbM_Click(object sender, EventArgs e)
        {

            try
            {
                int _issaveref = SaveLab();
                if (_issaveref == -1)
                {
                    HospiceHelper.SendAlert("SsMessage:\n Lab Code " + txtlabCode.Text.ToUpper().Trim() + " is already exist.");
                }
                else if (_issaveref > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "ClearTextBoxes();", true);
                    HospiceHelper.SendAlert("SsMessage:\n Lab has been successfully saved.", "LabListing");

                }
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\n Lab not save.\n" + ex.Message);
            }
        }
      
        private int SaveLab()
        {
            int result = 0;

            if (txtlabCode.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter code.");
                txtlabCode.Focus();
                return -1;
            }
            if (txtName.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter name.");
                txtName.Focus();
                return -1;
            }



            
            using (Dlab _objlab = new Dlab())
            {
                if (_labid > 0)
                _objlab.objtblLab = _objlab.GetLabbymasterid(_labid);
                _objlab.objtblLab.LabCode = txtlabCode.Text.ToString();
                _objlab.objtblLab.LabName = txtName.Text.ToString();
                _objlab.objtblLab.Description = txtlabDesc.Text.ToString();                
                _objlab.objtblLab.Status = Convert.ToInt32(ddlStatus.SelectedValue.ToString()) == 1 ? true : false;
                using (HospiceSession objmysession = new HospiceSession())
                {
                    if (_labid > 0)
                    {
                        _objlab.objtblLab.UpdatedBy = Convert.ToInt32(LogedinUID);
                        _objlab.objtblLab.UpdatedOn = objmysession.CurrentDT;
                        result = _objlab.UpdateLab(_objlab.objtblLab);
                    }
                    else
                    {

                        _objlab.objtblLab.CreatedBy = Convert.ToInt32(LogedinUID);
                        _objlab.objtblLab.CreatedOn = objmysession.CurrentDT;

                        result = _objlab.InsertLab(_objlab.objtblLab);
                    }
                }
            }
            return result;
        }
        private void GetLabDetail()
        {
            using (Dlab _objlab = new Dlab())
            {
                var _labdet = _objlab.GetLabMasterList().Where(x => x.Labid == _labid).SingleOrDefault();
                txtlabCode.Text = _labdet.LabCode.ToString();
                txtName.Text = _labdet.LabName.ToString();
                txtlabDesc.Text = _labdet.Description.ToString();

            }
        }
    }
}