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
    public partial class PaymentModeEntry : BasePage
    {
        private int _paymentmodeid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["_paymentmodeid"] != null)
            {
                _paymentmodeid = Convert.ToInt32(Request.QueryString["_paymentmodeid"].ToString());
              
            }
            else
            {
                btnbSavepaymM.Visible = true;
               
            }
            if (!IsPostBack)
            {
                if (_paymentmodeid > 0)
                    GetPaymentmodeDetail();
            }
        }

        protected void btnbSavepaymM_Click(object sender, EventArgs e)
        {

            try
            {
                int _issaveref = SavePaymentMode();
                if (_issaveref == -1)
                {
                    HospiceHelper.SendAlert("SsMessage:\n Payment Mode Code " + txtName.Text.ToUpper().Trim() + " is already exist.");
                }
                else if (_issaveref > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "ClearTextBoxes();", true);
                    HospiceHelper.SendAlert("SsMessage:\n Payment Mode has been successfully saved.", "PaymentmodeListing");

                }
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\n Payment Mode not save.\n" + ex.Message);
            }
        }
       
        private int SavePaymentMode()
        {
            int result = 0;

            if (txtPaymentModeCode.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter code.");
                txtPaymentModeCode.Focus();
                return -1;
            }
            if (txtName.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter name.");
                txtName.Focus();
                return -1;
            }



            
            using (Dpaymentmode _objpaymentmode = new Dpaymentmode())
            {
                if (_paymentmodeid > 0)
                    _objpaymentmode.objtblpaymode = _objpaymentmode.GetPaymentModebymasterid(_paymentmodeid);
                _objpaymentmode.objtblpaymode.PaymentModeCode = txtPaymentModeCode.Text.ToString();
                _objpaymentmode.objtblpaymode.PaymentMode = txtName.Text.ToString();
                _objpaymentmode.objtblpaymode.Description = txtPaymentModeDesc.Text.ToString();
                _objpaymentmode.objtblpaymode.Status = Convert.ToInt32(ddlStatus.SelectedValue.ToString()) == 1 ? true : false;
                using (HospiceSession objmysession = new HospiceSession())
                {
                    if (_paymentmodeid > 0)
                    {
                        _objpaymentmode.objtblpaymode.UpdatedBy = Convert.ToInt32(LogedinUID);
                        _objpaymentmode.objtblpaymode.UpdatedOn = objmysession.CurrentDT;
                        result = _objpaymentmode.UpdatePaymentMode(_objpaymentmode.objtblpaymode);
                    }
                    else
                    {

                        _objpaymentmode.objtblpaymode.CreatedBy = Convert.ToInt32(LogedinUID);
                        _objpaymentmode.objtblpaymode.CreatedOn = objmysession.CurrentDT;

                        result = _objpaymentmode.InsertPaymentMode(_objpaymentmode.objtblpaymode);
                    }
                }
            }
            return result;
        }
        private void GetPaymentmodeDetail()
        {
            using (Dpaymentmode _objpaymentmode = new Dpaymentmode())
            {
                var _labdet = _objpaymentmode.GetPaymentModeMasterList().Where(x => x.PaymentModeId == _paymentmodeid).SingleOrDefault();
                txtPaymentModeCode.Text = _labdet.PaymentModeCode.ToString();
                txtName.Text = _labdet.PaymentMode.ToString();
                txtPaymentModeDesc.Text = _labdet.Description.ToString();

            }
        }
    }
}