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
    public partial class AppointmentList : BasePage
    {
        int branchid =0;
        protected void Page_Load(object sender, EventArgs e)
        {
            branchid = Convert.ToInt16(HttpContext.Current.Session["CurrentBranch"]);
            if (!IsPostBack)
            {
                BindrptAppointmentListing();
                FillddlPaymentMode();
            }
        }

        private void BindrptAppointmentListing()
        {
            using (Dappointment dappointment = new Dappointment())
            {
                var _getresult = dappointment.GetAppointmentList(branchid);
                rptAppointmentListing.DataSource = _getresult;
                rptAppointmentListing.DataBind();

            }
        }

        private void FillddlPaymentMode()
        {
            using (Dpaymentmode dpaymentmode= new Dpaymentmode())
            {
                var _getresult = dpaymentmode.GetPaymentModeMasterList();
                ddlPaymentMode.DataSource = _getresult;
                ddlPaymentMode.DataTextField = "PaymentMode";
                ddlPaymentMode.DataValueField = "PaymentModeId";
                ddlPaymentMode.DataBind();

            }
        }
        private void GetBillDetail(int patientid, int serviceid, DateTime apptdate)
        {
            using (DInvoice dInvoice = new DInvoice())
            {
                //int patientid = 0;
                //int serviceid = 0;
                //DateTime apptdate = DateTime.Now;

                var billdetail = dInvoice.GetBillDetailByIds(patientid, serviceid, apptdate,branchid).SingleOrDefault();
                hfbillid.Value = billdetail.BillId.ToString();
                hfpaymentid.Value = billdetail.paymntid.ToString();
                txtGrossBillAmt.Text = billdetail.BillAmount.ToString();
                txtDiscount.Text = billdetail.Discount.ToString()==""?"- 0.00":"- "+billdetail.Discount.ToString();
                txtServiceTax.Text = billdetail.Tax.ToString();
                txtNetBilledAmt.Text = billdetail.NetAmount.ToString();
                txtCollectedAmt.Text = billdetail.RecivedAmount.ToString()==""?"0.00": billdetail.RecivedAmount.ToString();
                txtNetPaidAmt.Text = txtCollectedAmt.Text;
                /*using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
                {
                    var paymaster = mydatacontext.tblPaymentMasters.Where(x => x.BillId == Convert.ToInt32(billdetail.BillId.ToString())).SingleOrDefault();
                    if (paymaster!=null)
                    {
                        var paydetail = mydatacontext.tblPaymentDetails.Where(x => x.PaymentId == paymaster.PaymentId).FirstOrDefault();
                        txtCollectedAmt.Text = paydetail.RecivedAmount;
                        txtNetPaidAmt.Text = paydetail.DueAmount;
                    }
                }*/
                txtBalanceAmt.Text = billdetail.BalanceAmount.ToString();
                //txtPayingAmount.Text = txtBalanceAmt.Text;

                gvpaymentDetailList.DataSource = dInvoice.GetPaymentDetailListByPaymntid(Convert.ToInt32(billdetail.paymntid.ToString()));
                gvpaymentDetailList.DataBind();
            }
        }
        
        protected void rptAppointmentListing_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "payment")
            {
                string ptid = PatientId=((HiddenField)e.Item.FindControl("hfpatientid")).Value;
                string servid = ((HiddenField)e.Item.FindControl("hfserviceid")).Value;
                string aptdt = ((HiddenField)e.Item.FindControl("hfapptdt")).Value;
                string pname = ((LinkButton)e.Item.FindControl("lnkbtnPname")).Text;
                GetBillDetail(Convert.ToInt32(ptid), Convert.ToInt32(servid),DateTime.Parse(aptdt));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#paymentTitle').html('"+pname.ToUpper()+"');$('.bd-payment-modal-lg').modal({ show: true });", true);
            }
            if (e.CommandName == "editpatient")
            {
                Session["patientid"] = PatientId = ((HiddenField)e.Item.FindControl("hfpatientid")).Value;
                string pname = ((LinkButton)e.Item.FindControl("lnkbtnPname")).Text;

                CustomControl.EditPatient editPatient = this.EditPatient;
                editPatient.GetPatientDetailByid(Convert.ToInt32(PatientId));

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#myeditpatientModal').html('" + pname.ToUpper() + "');$('.bd-editpatient-modal-xl').modal({ show: true });savePayment('" + PatientId + "');", true);
               
            }
            if (e.CommandName == "editappointment")
            {
                Session["patientid"] = PatientId = ((HiddenField)e.Item.FindControl("hfpatientid")).Value;
                string pname = ((LinkButton)e.Item.FindControl("lnkbtnPname")).Text;

                CustomControl.EditAppointment editappnt = this.EditAppointment;
                editappnt.GetAppointmentDetailbypid(Convert.ToInt32(PatientId));

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#myEditAppntLabel').html('" + pname.ToUpper() + "');$('.bd-editappnt-modal-lg').modal({ show: true });", true);
            }
        }
        private string PatientId
        {
            get
            {
                return ViewState["PatientId"].ToString();
            }
            set
            {
                ViewState["PatientId"] = value;
            }
        }
        
        protected void btnAddPayment_Click(object sender, EventArgs e)
        {
            int result = 0;
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                using (HospiceSession objmysession = new HospiceSession())
                {
                    int _paymentid = Convert.ToInt32(hfpaymentid.Value);
                    tblPaymentMaster tpm = mydatacontext.tblPaymentMasters.Where(x => x.PaymentId == _paymentid).SingleOrDefault();

                    tpm.lastPaymentDt = objmysession.CurrentDT; ;
                    //var oldPaymentStatus = tpm.PaymentStatus;
                    var recivedamt = Convert.ToDecimal(txtPayingAmount.Text);
                    var dueamt = Convert.ToDouble(tpm.BillAmount - recivedamt);

                    if (Convert.ToDecimal(dueamt) == 0)
                        tpm.PaymentStatus = "Paid".ToUpper();
                    else if (Convert.ToDecimal(dueamt) > 0)
                        tpm.PaymentStatus = "Partial".ToUpper();

                    tpm.BalanceAmount = Convert.ToDecimal(dueamt);//objinvoice.TotalPaidAmount-Convert.ToDecimal(txtPaidAmount.Text);
                
                
                    tpm.UpdatedOn = objmysession.CurrentDT;
                    tpm.UpdatedBy = Convert.ToInt32(LogedinUID); 
                    mydatacontext.SubmitChanges();

                    using (DInvoice dInvoice = new DInvoice())
                    {
                        dInvoice.TblPaymentDetail.PaymentId = _paymentid;
                        dInvoice.TblPaymentDetail.PaymentDt = objmysession.CurrentDT;
                        dInvoice.TblPaymentDetail.PaymentMode = ddlPaymentMode.SelectedValue;
                        dInvoice.TblPaymentDetail.RecivedAmount = Convert.ToDecimal(txtPayingAmount.Text) ;
                        dInvoice.TblPaymentDetail.DueAmount = Convert.ToDecimal(dueamt);
                        dInvoice.TblPaymentDetail.BranchId = branchid;
                        dInvoice.TblPaymentDetail.CreatedBy = Convert.ToInt32(LogedinUID);
                        dInvoice.TblPaymentDetail.CreatedOn = objmysession.CurrentDT;

                        var savepaymentd = dInvoice.SavePaymentDetail(dInvoice.TblPaymentDetail);
                    }
                }
            }txtPayingAmount.Text = "";
        }
        
    }
}