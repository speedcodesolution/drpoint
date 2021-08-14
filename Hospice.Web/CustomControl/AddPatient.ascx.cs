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
    public partial class AddPatient : System.Web.UI.UserControl
    {
        int patientid = -1;int branchid = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["patientid"] != null)
                patientid = Convert.ToInt32(Session["patientid"]);
            if (!IsPostBack)
            {
                FillddlPrefixName();
                FillddlBloodGroup();
                FillddlCity();

                FillddlDoctor();
                FillddlApptStatus();

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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('.bd-patient-modal-xl').modal({ show: true });", true);
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('.bd-example-modal-lg').modal({ show: true });", true);
        }
        private void FillddlAvailabilTime()
        {
            using (Dappointment dappointment = new Dappointment())
            {
                int doctorid = Convert.ToInt16(ddlDoctor.SelectedValue);
                int serviceid = Convert.ToInt16(ddlService.SelectedValue);
                int branchid = 1;
                DateTime apptdate = Convert.ToDateTime(txtApptDate.Text);
                var apptstatus = dappointment.GetAvailabilTime(branchid, doctorid, serviceid, apptdate).ToList();
                ddlAvailabilTime.DataSource = apptstatus;
                ddlAvailabilTime.DataTextField = "AvailabilTime";
                ddlAvailabilTime.DataValueField = "AvailabilTime";
                ddlAvailabilTime.DataBind();
                ddlAvailabilTime.Items.Insert(0, new ListItem("Select", ""));
            }
        }
        public void GetPatientDetailByid(int pid)
        {
            using (Dpatient dpatient = new Dpatient())
            {
                var pd = dpatient.GetPatietMasterById(pid);
                ddlPrefixPName.SelectedValue = pd.PrefixId.ToString();
                txtPName.Text = pd.Name.ToString();
                if(pd.GenderId==1)
                    rbMale.Checked = true;
                else if (pd.GenderId == 2)
                    rbFemale.Checked = true;
                else if (pd.GenderId == 3)
                    rbOther.Checked = true;
                if (pd.Age.ToString() != "")
                { txtAge.Text = pd.Age.ToString();ddlAgeDOB.SelectedIndex = 1; }
                else if (pd.DateOfBirth.ToString() != "")
                { txtAge.Text = pd.DateOfBirth.ToString(); ddlAgeDOB.SelectedIndex = 2; }

                txtMobileNo.Text = pd.Mobile1.ToString();
                if(pd.Email!=null)
                    txtEmail.Text = pd.Email.ToString();
                ddlBloodGroup.SelectedValue = pd.BlodGroupId.ToString();
                if(pd.CareOf!=null)
                    txtCO.Text = pd.CareOf.ToString();
                if(pd.Mobile2!=null)
                    txtMobileNo2.Text = pd.Mobile2.ToString();
                if (pd.Address != null)
                    txtAddress.Text = pd.Address.ToString();
                if (pd.CityId != null)
                    ddlCity.SelectedValue = pd.CityId.ToString();
                if (pd.Pin != null)
                    txtPin.Text = pd.Pin.ToString();
                if (pd.RefferredBy != null)
                    txtReferencedBy.Text = pd.RefferredBy.ToString();
                if (pd.Occupation != null)
                    txtOccupation.Text = pd.Occupation.ToString();
                if (pd.Tag != null)
                    txtTag.Text = pd.Tag.ToString();

            }
        }
        private void FillddlBloodGroup()
        {
            using (Dpatient dpatient = new Dpatient())
            {
                var _bloodgroup = dpatient.GetBloodGroupList();
                ddlBloodGroup.DataSource = _bloodgroup;
                ddlBloodGroup.DataTextField = "BloodGroup";
                ddlBloodGroup.DataValueField = "BloodGroupId";
                ddlBloodGroup.DataBind();
                ddlBloodGroup.Items.Insert(0, new ListItem("Select", ""));

            }
        }
        private void FillddlPrefixName()
        {
            using (Dpatient dpatient = new Dpatient())
            {
                var _patient = dpatient.GetPrefixList();
                ddlPrefixPName.DataSource = _patient;
                ddlPrefixPName.DataTextField = "Name"; 
                ddlPrefixPName.DataValueField = "Prefixid";
                ddlPrefixPName.DataBind();
                ddlPrefixPName.Items.Insert(0, new ListItem("Select", ""));

            }

        }
        private void FillddlCity()
        {
            using (Dcity dcity = new Dcity())
            {
                var _city = dcity.GetLocCityList();
                ddlCity.DataTextField = "CityName";
                ddlCity.DataValueField = "CityId"; 
                ddlCity.DataBind();
                ddlCity.Items.Insert(0, new ListItem("Select City", ""));
            }
        }

        private int SavePatient()
        {
            int result = 0;
            using (Dpatient dpatient = new Dpatient())
            {
                if (patientid > 0)
                    dpatient.gtblpatientmaster = dpatient.GetPatietMasterById(patientid);

                dpatient.gtblpatientmaster.PrefixId =Convert.ToInt16(ddlPrefixPName.SelectedValue);
                dpatient.gtblpatientmaster.Name = txtPName.Text;
                string gender ="";
                if (rbMale.Checked == true)
                    gender = rbMale.Value;
                else if (rbFemale.Checked == true)
                    gender = rbFemale.Value;
                else if (rbOther.Checked == true)
                    gender = rbOther.Value;

                dpatient.gtblpatientmaster.GenderId =Convert.ToInt16(gender);
                if(ddlAgeDOB.SelectedItem.Text.ToLower()=="year")
                    dpatient.gtblpatientmaster.Age = Convert.ToInt16(txtAge.Text);
                else if((ddlAgeDOB.SelectedItem.Text.ToLower() == "dob"))
                    dpatient.gtblpatientmaster.DateOfBirth =Convert.ToDateTime(txtAge.Text);
                
                dpatient.gtblpatientmaster.Mobile1 = txtMobileNo.Text;
                dpatient.gtblpatientmaster.Mobile2 = txtMobileNo2.Text;
                dpatient.gtblpatientmaster.BlodGroupId =Convert.ToInt16(ddlBloodGroup.SelectedValue);
                dpatient.gtblpatientmaster.Email = txtEmail.Text;
                dpatient.gtblpatientmaster.Address = txtAddress.Text;
                //dpatient.gtblpatientmaster.Area = tblPatientMaster.Area;
                dpatient.gtblpatientmaster.CityId = Convert.ToInt32(ddlCity.SelectedValue);
                dpatient.gtblpatientmaster.Pin =Convert.ToInt32(txtPin.Text);
                dpatient.gtblpatientmaster.RefferredBy = txtReferencedBy.Text;
                dpatient.gtblpatientmaster.CareOf = txtCO.Text;
                dpatient.gtblpatientmaster.Occupation = txtOccupation.Text;
                dpatient.gtblpatientmaster.Tag = txtTag.Text;
                dpatient.gtblpatientmaster.BranchId = branchid;

                using (HospiceSession objmysession = new HospiceSession())
                {
                    using (BasePage mbp = new BasePage())
                    {
                        if (patientid > 0)
                        {
                            dpatient.gtblpatientmaster.UpdatedBy = Convert.ToInt32(mbp.LogedinUID);
                            dpatient.gtblpatientmaster.UpdatedOn = objmysession.CurrentDT;
                            result = dpatient.UpdatePatientMaster(dpatient.gtblpatientmaster);
                        }
                        /* else
                         {

                             dpatient.gtblpatientmaster.CreatedBy = Convert.ToInt32(mbp.LogedinUID);
                             dpatient.gtblpatientmaster.CreatedOn = objmysession.CurrentDT;

                             result = dpatient.InsertPatientMaster(dpatient.gtblpatientmaster);
                         }*/
                    }
                }

            }
            return result;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
        }
    }
}