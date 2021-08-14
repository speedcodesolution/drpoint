using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospice.DAL;
using Hospice.Helper;
using Hospice.Web.App_Code;
using System.IO;
using System.Data;

namespace Hospice.Web.Admin
{
    public partial class DoctorEntry : BasePage
    {
        private int _empgid = 0;private int _branchid = 0;

        public DataTable dtAvabilityList
        {
            get
            {
                if (Session["dtAvabilityList"] == null)
                {
                    using (Demployee demployee = new Demployee())
                    {
                        var result = demployee.GetAvailabilityMasters(_empgid,_branchid);

                        DataTable CurrentDt = result.ConvertIEnumerableToDataTable();

                        Session["dtAvabilityList"] = CurrentDt;

                    }
                }
                return (DataTable)Session["dtAvabilityList"];

            }
            set
            {
                Session["dtAvabilityList"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["_employeid"] != null)
            {
                _empgid = Convert.ToInt32(Request.QueryString["_employeid"].ToString());
            }
            if (!IsPostBack)
            {
                FillddlBranch();
                FillddlDesignation();
                FillddlDepartment();
                FillddlCity();
                FillddlWorkingDay();
                if (_empgid > 0)
                    GetEmployeeDetail();
                BindgvAvabilityList();
            }
        }
        private void FillddlBranch()
        {
            using (Dbranch dbranch = new Dbranch())
            {
                var _branch = dbranch.GetbranchMasterList().Where(x=>x.Status==true).ToList();
                ddlBranch.DataSource = _branch;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "BranchID";
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Branch", ""));
            }
        }
        private void FillddlWorkingDay()
        {
            ddlWorkingDay1.DataSource = Enum.GetNames(typeof(HospiceSetting.Days));
            ddlWorkingDay1.DataBind();
            ddlWorkingDay1.Items.Insert(0, new ListItem("Select Working Day", ""));
            ddlWorkingDay1.Multiple = true;
        }
        private void FillddlCity()
        {
            //using (DLocation objdloc = new DLocation())
            //{
            //    var _items = objdloc.GetLocationList();
            //    ddlCity.DataSource = _items;
            //    ddlCity.DataTextField = "CityName";
            //    ddlCity.DataValueField = "CityId";
            //    ddlCity.DataBind();
            //    ddlCity.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select City", ""));
            //}
        }
        private void FillddlDesignation()
        {
            //using (DLocation objdloc = new DLocation())
            //{
            //    var _items = objdloc.GetLocationList();
            //    ddlDesignation.DataSource = _items;
            //    ddlDesignation.DataTextField = "Designation";
            //    ddlDesignation.DataValueField = "DesignationId";
            //    ddlDesignation.DataBind();
            //    ddlDesignation.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Designation", ""));
            //}
        }
        private void FillddlDepartment()
        {
            //using (Ddepartment ddepartment = new Ddepartment())
            //{
            //    var _items = ddepartment.GetdepMasterList();
            //    ddlDepartment.DataSource = _items;
            //    ddlDepartment.DataTextField = "Department";
            //    ddlDepartment.DataValueField = "DepartmentId";
            //    ddlDepartment.DataBind();
            //    ddlDepartment.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Department", ""));
            //}
        }
        private void GetEmployeeDetail()
        {
            using (Demployee _objdemp = new Demployee())
            {
                var _empdet = _objdemp.GetEmpMasterbyid(_empgid);

                //txtEmpCode.Text = _empdet.EmpCode.ToString();
                txtFullName.Text = _empdet.EmpName.ToString();

                if (_empdet.DOB != null)
                    txtDOB.Text = (Convert.ToDateTime(_empdet.DOB.ToString())).ToString("dd-MM-yyyy");
                if (_empdet.DOJ != null)
                    txtDOJ.Text = (Convert.ToDateTime(_empdet.DOJ.ToString())).ToString("dd-MM-yyyy");
                if (_empdet.Address != null)
                    txtAddress.Text = _empdet.Address.ToString();
                if (_empdet.City != null)
                    ddlCity.SelectedValue = _empdet.City.ToString();

                if (_empdet.MobileNo != null)
                    txtMobileno.Text = _empdet.MobileNo.ToString();
                if (_empdet.Email != null)
                    txtEmail.Text = _empdet.Email.ToString();
                if (_empdet.DesignationId != null)
                    ddlDesignation.SelectedValue = _empdet.DesignationId.ToString();
                if (_empdet.DepartmentId != null)
                    ddlDepartment.SelectedValue = _empdet.DepartmentId.ToString();
                if (_empdet.StatusEmp != null)
                    ddlStatus.SelectedValue = _empdet.StatusEmp.ToString();
                if (_empdet.Qualification != null)
                    txtQualification.Text = _empdet.Qualification.ToString();
                if (_empdet.Speciality != null)
                    txtSpeciality.Text= _empdet.Speciality.ToString();
                if (_empdet.Data != null)
                {
                    byte[] bytes = (byte[])_empdet.Data.ToArray();
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    imgEmp.Src = String.Format("data:{0};base64,{1}", _empdet.ContentType.ToString(), base64String); //"data:image/png;base64," + base64String;
                }

            }
            
        }

        private int SaveDoctorDetail()
        {
            int result = 0;

            if (txtFullName.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter name.");
                txtFullName.Focus();
                return -1;
            }
            if (txtMobileno.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter Mobile number.");
                txtMobileno.Focus();
                return -1;
            }

            using (Demployee demployee = new Demployee())
            {
                

                string empcode = ddlDesignation.SelectedIndex == 0 ?"0": ddlDesignation.SelectedValue;
                empcode = empcode +(ddlDepartment.SelectedIndex == 0 ? "0" : ddlDepartment.SelectedValue);
                empcode= "DR" + empcode + demployee.GetEmpID().ToString();

                if (_empgid > 0)
                {
                    demployee.ObjTblEmployeeMaster = demployee.GetEmpMasterbyid(_empgid);
                    empcode = demployee.ObjTblEmployeeMaster.EmpCode.ToString();
                }

                demployee.ObjTblEmployeeMaster.EmpCode =  empcode;

                demployee.ObjTblEmployeeMaster.EmpName = txtFullName.Text.ToString();
                if (txtDOB.Text.Trim() != "")
                {
                    string tempdob = txtDOB.Text.Split('-')[2] + "-" + txtDOB.Text.Split('-')[1] + "-" + txtDOB.Text.Split('-')[0];
                    demployee.ObjTblEmployeeMaster.DOB = Convert.ToDateTime(tempdob); 
                }
                if (txtDOJ.Text.Trim() != "")
                {
                    string tempdoj = txtDOJ.Text.Split('-')[2] + "-" + txtDOJ.Text.Split('-')[1] + "-" + txtDOJ.Text.Split('-')[0];
                    demployee.ObjTblEmployeeMaster.DOJ = Convert.ToDateTime(tempdoj); ;
                }
                if (txtAddress.Text.Trim() != "")
                    demployee.ObjTblEmployeeMaster.Address = txtAddress.Text;

                demployee.ObjTblEmployeeMaster.City = Convert.ToInt32(ddlCity.SelectedValue);

                if (txtMobileno.Text.Trim() != "")
                    demployee.ObjTblEmployeeMaster.MobileNo = txtMobileno.Text;

                if (txtEmail.Text.Trim() != "")
                    demployee.ObjTblEmployeeMaster.Email = txtEmail.Text;

                if (ddlDesignation.SelectedIndex != 0)
                    demployee.ObjTblEmployeeMaster.DesignationId =Convert.ToInt16(ddlDesignation.SelectedValue);
                if (ddlDepartment.SelectedIndex!=0)
                    demployee.ObjTblEmployeeMaster.DepartmentId = Convert.ToInt16(ddlDepartment.SelectedValue);
                if (ddlStatus.SelectedIndex > 0)
                    demployee.ObjTblEmployeeMaster.StatusEmp =Convert.ToInt16(ddlStatus.SelectedValue.ToString());

                if (txtQualification .Text.Trim() != "")
                    demployee.ObjTblEmployeeMaster.Qualification = txtQualification.Text;
                if (txtSpeciality.Text.Trim() != "")
                    demployee.ObjTblEmployeeMaster.Speciality = txtSpeciality.Text;

                
                demployee.ObjTblEmployeeMaster.EmpType =1;
                _branchid= Convert.ToInt16(ddlBranch.SelectedValue.ToString());
                demployee.ObjTblEmployeeMaster.Branchid = _branchid;

                //System.Web.UI.HtmlControls.HtmlInputFile img = (System.Web.UI.HtmlControls.HtmlInputFile) fpProfile;
                //FileUpload img = (FileUpload)fupProfile;
                Byte[] imgByte = null;
                if (fupProfile.PostedFile != null)
                {
                    //To create a PostedFile
                    HttpPostedFile File = fupProfile.PostedFile;
                    //Create byte Array with file len
                    imgByte = new Byte[File.ContentLength];
                    //force the control to load data in array
                    File.InputStream.Read(imgByte, 0, File.ContentLength);
                }
                demployee.ObjTblEmployeeMaster.ContentType = fupProfile.PostedFile.ContentType;
                demployee.ObjTblEmployeeMaster.Data = imgByte;
                   
                using (HospiceSession objmysession = new HospiceSession())
                {
                    if (_empgid > 0)
                    {
                        demployee.ObjTblEmployeeMaster.UpdatedBy = Convert.ToInt32(LogedinUID);
                        demployee.ObjTblEmployeeMaster.UpdatedOn = objmysession.CurrentDT;
                        result = demployee.UpdateEmployee(demployee.ObjTblEmployeeMaster);
                    }
                    else
                    {
                        demployee.ObjTblEmployeeMaster.CreatedBy = Convert.ToInt32(LogedinUID);
                        demployee.ObjTblEmployeeMaster.CreatedOn = objmysession.CurrentDT;
                        result = demployee.InsertEmployee(demployee.ObjTblEmployeeMaster);
                        _empgid = result;
                    }
                }
                if (result > 0)
                {
                    foreach (GridViewRow row in gvAvailabilityList.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            Label lblgvToTime = row.FindControl("lblgvToTime") as Label;
                            Label lblgvFromTime = row.FindControl("lblgvFromTime") as Label;
                            Label lblgvWorkingDay = row.FindControl("lblgvWorkingDay") as Label;

                            if (lblgvWorkingDay.Text.Contains(HospiceSetting.Days.DAILY.ToString()) == true)
                            {
                                string wday = "";
                                foreach (int i in Enum.GetValues(typeof(HospiceSetting.Days)))
                                {
                                    if (Enum.GetName(typeof(HospiceSetting.Days), i) != HospiceSetting.Days.DAILY.ToString())
                                    {
                                        if (wday == "")
                                            wday = Enum.GetName(typeof(HospiceSetting.Days), i);
                                        else
                                            wday = wday + "," + Enum.GetName(typeof(HospiceSetting.Days), i);
                                    }
                                }
                                demployee.ObjTblAvailabilityMaster.WorkingDay = wday;

                            }
                            else
                                demployee.ObjTblAvailabilityMaster.WorkingDay = lblgvWorkingDay.Text;

                            demployee.ObjTblAvailabilityMaster.WorkingFromTime = TimeSpan.Parse(lblgvFromTime.Text);
                            demployee.ObjTblAvailabilityMaster.WorkingToTime = TimeSpan.Parse(lblgvToTime.Text);
                            demployee.ObjTblAvailabilityMaster.DoctorId = _empgid;
                            demployee.ObjTblAvailabilityMaster.BranchId = _branchid;

                            result = demployee.InsertAvailability(demployee.ObjTblAvailabilityMaster);
                        }
                    }
                }
                    /*if (_empgid > 0)
                    {
                        demployee.ObjTblAvailabilityMaster = demployee.GetEmpMasterbyid(_empgid);
                        empcode = demployee.ObjTblEmployeeMaster.EmpCode.ToString();
                    }
                    

                    if (_empgid > 0)
                    {
                        //result = demployee.UpdateEmployee(demployee.ObjTblAvailabilityMaster);
                    }
                    else
                    {
                       
                    }*/

                }
            return result;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int _issave = SaveDoctorDetail();
                if (_issave == -1)
                {
                    HospiceHelper.SendAlert("SsMessage:\n Doctor " + txtFullName.Text.ToUpper().Trim() + " is already exist.");
                }
                else if (_issave > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "ClearTextBoxes();", true);
                    HospiceHelper.SendAlert("SsMessage:\n Doctor details has been successfully saved.", "DoctorListing");

                }
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\n Doctor details not save.\n" + ex.Message);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddlWorkingDay1.SelectedIndex == 0)
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease select working day.");
                ddlWorkingDay1.Focus();
                return;
            }
            if (txtToTime.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter to time.");
                ddlWorkingDay1.Focus();
                return;
            }
            if (txtFromtime.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter from time.");
                ddlWorkingDay1.Focus();
                return;
            }
            DataRow drCurrentRow = dtAvabilityList.NewRow();
            //if (btnAddTaskDetail.Text.ToLower() == "update")
            //{
            //    int hfTaskid = 0;
            //    drCurrentRow = dtTaskList.Select("Taskid=" + Convert.ToInt32(hfTaskid))[0];
            //}
            //else
            //{
                if (dtAvabilityList.Rows.Count == 0)
                    drCurrentRow["AvailabilityId"] = -1;
                else
                    drCurrentRow["AvailabilityId"] = -dtAvabilityList.Rows.Count - 1;
            //}

            drCurrentRow["DoctorId"] = _empgid;
            drCurrentRow["BranchId"] = _branchid;
            drCurrentRow["WorkingFromTime"] = txtFromtime.Text;
            drCurrentRow["WorkingToTime"] = txtToTime.Text;
            
            //if (ddlWorkingDay.SelectedItem.Text == CheckListSetting.Days.DAILY.ToString())
            if (hfSelectedWorkingDay.Value.Contains(HospiceSetting.Days.DAILY.ToString()) == true)
            {
                string wday = "";
                foreach (int i in Enum.GetValues(typeof(HospiceSetting.Days)))
                {
                    if (Enum.GetName(typeof(HospiceSetting.Days), i) != HospiceSetting.Days.DAILY.ToString())
                    {
                        if (wday == "")
                            wday = Enum.GetName(typeof(HospiceSetting.Days), i);
                        else
                            wday = wday + "," + Enum.GetName(typeof(HospiceSetting.Days), i);
                    }
                }
                drCurrentRow["WorkingDay"] = wday;
            }
            else
                drCurrentRow["WorkingDay"] = hfSelectedWorkingDay.Value;// ddlWorkingDay.SelectedItem.Text;

            //if (btnAddTaskDetail.Text.ToLower() == "add")
                dtAvabilityList.Rows.Add(drCurrentRow);

            BindgvAvabilityList();
        }

        protected void gvAvailabilityList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        private void BindgvAvabilityList()
        {
            gvAvailabilityList.DataSource = dtAvabilityList;
            gvAvailabilityList.DataBind();
        }
    }
}