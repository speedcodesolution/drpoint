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
    public partial class EditAppointment : System.Web.UI.UserControl
    {
        int branchid = 1; //int PatientId = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            //PatientId = Convert.ToInt32(Session["patientid"]);
            if (!IsPostBack)
            {
                FillddlDoctor();
                FillddlApptStatus();

            }
        }
        public void GetAppointmentDetailbypid(int _patientid, object sender=null, EventArgs e=null)
        {
            using (Dappointment dappointment = new Dappointment())
            {
                var appntdetail = dappointment.GetAppointmentList(branchid).Where(x => x.PatientId == _patientid).SingleOrDefault();
                txtPName.Text = appntdetail.PatinetName.ToString();
                //txtPContact.Text = appntdetail.Mobile1.Tostring();
                ddlDoctor.SelectedValue = appntdetail.DoctorId.ToString();
                ddlDoctor_SelectedIndexChanged(sender, e);
                txtApptDate.Text = appntdetail.ApptDate.ToString();
                ddlService.SelectedValue = appntdetail.ServiceId.ToString();
                ddlService_SelectedIndexChanged(sender, e);
                ddlDuration.SelectedValue = appntdetail.Duration_Min.ToString();
                ddlApptStatus.SelectedValue = appntdetail.ApptStatus.ToString();
                ddlAvailabilTime.SelectedValue = appntdetail.ApptTime.ToString();

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
            }
        }
        private void FillddlDoctor()
        {
            using (Demployee demployee = new Demployee())
            {
                var apptstatus = (from a in demployee.GetEmpMasterList()
                                  select new { doctorid = a.EmpID, doctor = a.EmpCode.ToUpper() + " " + a.EmpName.ToUpper() });
                ddlDoctor.DataSource = apptstatus;
                ddlDoctor.DataTextField = "doctor";
                ddlDoctor.DataValueField = "doctorid";
                ddlDoctor.DataBind();
                ddlDoctor.Items.Insert(0, new ListItem("Select", ""));
            }
        }
        private void FillddlService(string ownerid)
        {
            using (Dservice dservice = new Dservice())
            {
                var apptstatus = (from a in dservice.GetServiceMasterList().Where(x => x.Serviceownerid == Convert.ToInt32(ownerid))
                                  select new { Serviceid = a.Serviceid, ServiceName = "[" + a.SericeCode.ToUpper() + "]  " + a.ServiceName.ToUpper(), a.Serviceownerid, a.ServiceAmount, a.Servicetax, a.TotalAmount }).ToList();
                ddlService.DataSource = apptstatus;
                ddlService.DataTextField = "ServiceName";
                ddlService.DataValueField = "Serviceid";
                ddlService.DataBind();
                ddlService.Items.Insert(0, new ListItem("Select", ""));


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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('.bd-editappnt-modal-lg').modal({ show: true });", true);
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
                        tax = (netamout * Convert.ToDecimal(txtTax.Text)) / 100;
                    lblNetPrice.Text = (tax + netamout).ToString();
                }
            }
            FillddlAvailabilTime();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('.bd-editappnt-modal-lg').modal({ show: true });", true);
        }
        private void FillddlAvailabilTime()
        {
            using (Dappointment dappointment = new Dappointment())
            {
                int doctorid = Convert.ToInt16(ddlDoctor.SelectedValue);
                int serviceid = Convert.ToInt16(ddlService.SelectedValue);
                int branchid = 1;
                DateTime apptdate = Convert.ToDateTime(txtApptDate.Text);
                var apptstatus = dappointment.GetAllAvailabilTime(branchid, doctorid, serviceid, apptdate).ToList();
                ddlAvailabilTime.DataSource = apptstatus;
                ddlAvailabilTime.DataTextField = "AvailabilTime";
                ddlAvailabilTime.DataValueField = "AvailabilTime";
                ddlAvailabilTime.DataBind();
                ddlAvailabilTime.Items.Insert(0, new ListItem("Select", ""));
            }
        }

        protected void txtApptDate_TextChanged(object sender, EventArgs e)
        {
            FillddlAvailabilTime();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('.bd-editappnt-modal-lg').modal({ show: true });", true);
        }

        protected void btnSaveAppt_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}