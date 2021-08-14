using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospice.DAL;
using Hospice.Helper;
using Hospice.Web.App_Code;

namespace Hospice.Web.CustomControl
{
    public partial class AddAppointment : System.Web.UI.UserControl
    {
        private int branchid=Convert.ToInt16(HttpContext.Current.Session["CurrentBranch"]);
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!IsPostBack)
            {
                txtApptDate.Text = DateTime.Today.ToString("dd-MM-yyyy");
                FillddlDoctor();
                FillddlApptStatus();
            }
        }
        
        private void FillddlService(string ownerid)
        {
            using (Dservice dservice = new Dservice())
            {
                var apptstatus =(from a in dservice.GetServiceMasterList().Where(x=>x.Serviceownerid==Convert.ToInt32(ownerid))
                                 select new { Serviceid=a.Serviceid,ServiceName ="["+a.SericeCode.ToUpper()+"]  "+a.ServiceName.ToUpper(),a.Serviceownerid,a.ServiceAmount,a.Servicetax,a.TotalAmount}).ToList();
                ddlService.DataSource = apptstatus;
                ddlService.DataTextField = "ServiceName";
                ddlService.DataValueField = "Serviceid";
                ddlService.DataBind();
                ddlService.Items.Insert(0, new ListItem("Select", ""));

                
            }
        }
        private void FillddlAvailabilTime()
        {
            using (Dappointment dappointment = new Dappointment())
            {
                int doctorid =Convert.ToInt16(ddlDoctor.SelectedValue);
                int serviceid = Convert.ToInt16(ddlService.SelectedValue);
                //int branchid = Convert.ToInt16(Session["CurrentBranch"]);
                DateTime apptdate =Convert.ToDateTime(txtApptDate.Text);
                var apptstatus =dappointment.GetAvailabilTime(branchid,doctorid,serviceid, apptdate).ToList();
                ddlAvailabilTime.DataSource = apptstatus;
                ddlAvailabilTime.DataTextField = "AvailabilTime";
                ddlAvailabilTime.DataValueField = "AvailabilTime";
                ddlAvailabilTime.DataBind();
                ddlAvailabilTime.Items.Insert(0, new ListItem("Select", ""));
            }
        }
        private void FillddlApptStatus()
        {
            using (Dappointment dappointment = new Dappointment())
            {
                var apptstatus = dappointment.GetAppointmentStatus();
                ddlApptStatus.DataSource = apptstatus;
                ddlApptStatus.DataTextField = "StatusName";
                ddlApptStatus.DataValueField = "StatusId";
                ddlApptStatus.DataBind();
                ddlApptStatus.Items.Insert(0, new ListItem("Select", ""));
                ddlApptStatus.ClearSelection();
                ddlApptStatus.Items.FindByText("Booked").Selected = true;
            }
        }
        private void FillddlDoctor()
        {
            using (Demployee demployee = new Demployee())
            {
                var apptstatus =(from a in demployee.GetEmpMasterList()
                                select new {doctorid=a.EmpID, doctor=a.EmpCode.ToUpper()+" "+a.EmpName.ToUpper()});
                ddlDoctor.DataSource = apptstatus;
                ddlDoctor.DataTextField = "doctor";
                ddlDoctor.DataValueField = "doctorid";
                ddlDoctor.DataBind();
                ddlDoctor.Items.Insert(0, new ListItem("Select", ""));
            }
        }

        protected void ddlDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDoctor.SelectedIndex > 0)
            {
                int ownerid = Convert.ToInt16(ddlDoctor.SelectedValue.ToString());
                FillddlService(ownerid.ToString());
                //if (page.ToString().ToUpper() != "ASP.subcategory_aspx".ToUpper())
                //{
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('.bd-example-modal-lg').modal({ show: true });", true);
                //}
            }
        }

        protected void ddlService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlService.SelectedIndex > 0)
            {
                using (Dservice dservice = new Dservice())
                {
                    var service = dservice.GetServiceMasterList().Where(x => x.Serviceownerid == Convert.ToInt32(ddlDoctor.SelectedValue) && x.Serviceid == Convert.ToInt32(ddlService.SelectedValue)).SingleOrDefault();

                    decimal netamout = 0; decimal tax = 0;
                    txtUnitPrice.Text = service.ServiceAmount.ToString();
                    txtQty.Text = "1";
                    netamout = Convert.ToDecimal(txtUnitPrice.Text) * Convert.ToDecimal(txtQty.Text);
                    txtDiscount.Text = "";
                    if (txtDiscount.Text != "")
                        netamout = netamout - Convert.ToDecimal(txtDiscount.Text);
                    txtTax.Text = service.Servicetax.ToString();
                    if (txtTax.Text != "")
                        tax = (netamout * Convert.ToDecimal(txtTax.Text))/100;
                    lblNetPrice.Text = (tax+netamout).ToString();
                }
            }
            FillddlAvailabilTime();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('.bd-example-modal-lg').modal({ show: true });", true);
        }

        protected void txtApptDate_TextChanged(object sender, EventArgs e)
        {
            FillddlAvailabilTime();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('.bd-example-modal-lg').modal({ show: true });", true);
        }

        protected void btnSaveAppt_Click(object sender, EventArgs e)
        {
            try
            {
                int _saveapptid = saveAppointmet();
                if (_saveapptid > 0)
                {
                    //ClearAll();
                    Response.Redirect("/Admin/AppointmentList");
                    //HospiceHelper.SendAlert("Save ", "AppointmentList");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "initfun();", true);


                }
            }
            catch(Exception ex)
            {
                HospiceHelper.SendAlert("Exception: Data not save. "+ex.Message.ToString());
            }
        }
        private int saveAppointmet()
        {
            int result = 0;

            using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
            {
                using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
                {
                    tblPatientMaster patientMaster = new tblPatientMaster();

                    if (txtPName.Text.Trim()!="")
                        patientMaster.Name = txtPName.Text.Trim();

                    if (txtPContact.Text.Trim() != "")
                        patientMaster.Mobile1 = txtPContact.Text.Trim();

                    patientMaster.Status = 1;
                    patientMaster.BranchId = Convert.ToInt16(Session["CurrentBranch"]);

                    using (HospiceSession objmysession = new HospiceSession())
                    {
                        using (BasePage mbp = new BasePage())
                        {
                            patientMaster.CreatedBy = Convert.ToInt32(mbp.LogedinUID);
                            patientMaster.CreatedOn = objmysession.CurrentDT;
                            mydatacontext.tblPatientMasters.InsertOnSubmit(patientMaster);

                            mydatacontext.SubmitChanges();
                            if (patientMaster.PatientId> 0)
                            {
                                
                                tblAppointment appointment = new tblAppointment();
                                appointment.PatientId = patientMaster.PatientId;
                                appointment.DoctorId = Convert.ToInt32(ddlDoctor.SelectedValue);
                                appointment.ServiceId = Convert.ToInt32(ddlService.SelectedValue);
                                appointment.ApptDate =Convert.ToDateTime(txtApptDate.Text);
                                appointment.ApptTime = TimeSpan.Parse(ddlAvailabilTime.SelectedValue);
                                appointment.Duration_Min = Convert.ToInt32(ddlDuration.SelectedValue);
                                appointment.ApptStatus = Convert.ToInt32(ddlApptStatus.SelectedValue);
                                appointment.BranchId = branchid;

                                appointment.CreatedBy = Convert.ToInt32(mbp.LogedinUID);
                                appointment.CreatedOn = objmysession.CurrentDT;

                                mydatacontext.tblAppointments.InsertOnSubmit(appointment);
                                mydatacontext.SubmitChanges();

                                tblBillMaster billMaster = new tblBillMaster();
                                billMaster.PatientId = patientMaster.PatientId;
                                billMaster.TotalBillAmount = Convert.ToDecimal(txtUnitPrice.Text);
                                if(txtDiscount.Text!="")
                                    billMaster.TotalDiscount = Convert.ToDecimal(txtDiscount.Text);
                                if(txtTax.Text!="")
                                    billMaster.TotalTax = Convert.ToDecimal(txtTax.Text);
                                billMaster.TotalNetAmount = Convert.ToDecimal(lblNetPrice.Text);
                                billMaster.BranchId = branchid;

                                mydatacontext.tblBillMasters.InsertOnSubmit(billMaster);
                                mydatacontext.SubmitChanges();


                                tblBillDetail billDetail = new tblBillDetail();
                                billDetail.BillId = billMaster.BillId;
                                billDetail.BDate = DateTime.Now;
                                billDetail.ServiceId = Convert.ToInt32(ddlService.SelectedValue);
                                billDetail.BillAmount = Convert.ToDecimal(txtUnitPrice.Text);
                                if (txtDiscount.Text != "")
                                    billDetail.Discount  = Convert.ToDecimal(txtDiscount.Text);
                                if (txtTax.Text != "")
                                    billDetail.Tax = Convert.ToDecimal(txtTax.Text);
                                billDetail.NetAmount = Convert.ToDecimal(lblNetPrice.Text);

                                mydatacontext.tblBillDetails.InsertOnSubmit(billDetail);
                                mydatacontext.SubmitChanges();

                                using (DInvoice dInvoice = new DInvoice())
                                {
                                    dInvoice.TblPaymentMaster.BillId = Convert.ToInt32(billDetail.BillId);
                                    dInvoice.TblPaymentMaster.lastPaymentDt = DateTime.Today;
                                    dInvoice.TblPaymentMaster.BillAmount = Convert.ToDecimal(lblNetPrice.Text);
                                    dInvoice.TblPaymentMaster.BalanceAmount = Convert.ToDecimal(lblNetPrice.Text);
                                    dInvoice.TblPaymentMaster.PaymentStatus = "UNPAID";
                                    dInvoice.TblPaymentMaster.PatientId = Convert.ToInt32(patientMaster.PatientId);
                                    dInvoice.TblPaymentMaster.BranchId = branchid;

                                    dInvoice.TblPaymentMaster.CreatedBy = Convert.ToInt32(mbp.LogedinUID);
                                    dInvoice.TblPaymentMaster.CreatedOn = objmysession.CurrentDT;
                                    dInvoice.SavePayment(dInvoice.TblPaymentMaster);

                                }
                            }
                        }
                    }


                    result = patientMaster.PatientId;
                }
                ts.Complete();
            }
            return result;
        }
        
    }
}