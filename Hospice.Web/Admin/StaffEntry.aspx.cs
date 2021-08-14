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
    public partial class StaffEntry : BasePage
    {
        private int _staffid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["_staffid"] != null)
            {
                _staffid = Convert.ToInt32(Request.QueryString["_staffid"].ToString());
               
            }
            else
            {
                btnSave.Visible = true;
               
            }
            if (!IsPostBack)
            {
                if (_staffid > 0)
                    GetEmployeeDetail();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                int _issaveemp = SaveEmployee();
                if (_issaveemp == -1)
                {
                    HospiceHelper.SendAlert("SsMessage:\n Employee Code " + txtEmpCode.Text.ToUpper().Trim() + " is already exist.");
                }
                else if (_issaveemp > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "ClearTextBoxes();", true);
                    HospiceHelper.SendAlert("SsMessage:\n Employee has been successfully saved.", "StaffListing");

                }
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\n Employee not save.\n" + ex.Message);
            }
        }

        private int SaveEmployee()
        {
            int result = 0;

            if (txtEmpCode.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter employee code.");
                txtEmpCode.Focus();
                return -1;
            }
            if (txtName.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter employee name.");
                txtName.Focus();
                return -1;
            }
            if (txtMobile.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter employee Mobile number.");
                txtMobile.Focus();
                return -1;
            }

            using (Demployee _objdemp = new Demployee())
            {
                if (_staffid > 0)
                    _objdemp.ObjTblEmployeeMaster = _objdemp.GetEmpMasterbyid(_staffid);

                _objdemp.ObjTblEmployeeMaster.EmpCode = txtEmpCode.Text.ToString();
                _objdemp.ObjTblEmployeeMaster.EmpName = txtName.Text.ToString();
                if (txtDOB.Text.Trim() != "")
                {
                    DateTime _dob = DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", null);
                    _objdemp.ObjTblEmployeeMaster.DOB = _dob;
                }
                if (txtDOJ.Text.Trim() != "")
                {
                    DateTime _doj = DateTime.ParseExact(txtDOJ.Text, "dd/MM/yyyy", null);
                    _objdemp.ObjTblEmployeeMaster.DOJ = _doj;
                }
                if (txtAddress.Text.Trim() != "")
                    _objdemp.ObjTblEmployeeMaster.Address = txtAddress.Text;

                _objdemp.ObjTblEmployeeMaster.City = Convert.ToInt32(ddlCity.SelectedValue);

                if (txtMobile.Text.Trim() != "")
                    _objdemp.ObjTblEmployeeMaster.MobileNo = txtMobile.Text;

                if (txtEmail.Text.Trim() != "")
                    _objdemp.ObjTblEmployeeMaster.Email = txtEmail.Text;

               
                if (ddlDesignation.SelectedIndex != 0)
                    _objdemp.ObjTblEmployeeMaster.DesignationId = Convert.ToInt16(ddlDesignation.SelectedValue);
                if (ddlDepartment.SelectedIndex != 0)
                    _objdemp.ObjTblEmployeeMaster.DepartmentId = Convert.ToInt16(ddlDepartment.SelectedValue);

                //if (ddlStatus.SelectedIndex > 0)
                //    _objdemp.ObjTblEmployeeMaster.StatusEmp = ddlStatus.SelectedValue.ToString();

                if (_staffid > 0)
                {

                    if (fileUpload.PostedFile != null)
                    {
                        if (fileUpload.PostedFile.FileName != null && fileUpload.PostedFile.FileName != "")
                        {
                            if (fileUpload.PostedFile.FileName != _objdemp.ObjTblEmployeeMaster.Photo)
                                ImageDelete(_objdemp.ObjTblEmployeeMaster.Photo.ToString());
                        }
                        _objdemp.ObjTblEmployeeMaster.Photo = ImageUpload(fileUpload, _objdemp.ObjTblEmployeeMaster.Photo);
                    }
                    else
                    {
                        ImageDelete(_objdemp.ObjTblEmployeeMaster.Photo.ToString());
                        _objdemp.ObjTblEmployeeMaster.Photo = "no-image.png";

                    }
                }
                else
                {



                    //convert the image into the byte  
                    byte[] bytes;
                    using (System.IO.BinaryReader br = new System.IO.BinaryReader(fileUpload.PostedFile.InputStream))
                    {
                        bytes = br.ReadBytes(fileUpload.PostedFile.ContentLength);
                    }
                    string exten1 = System.IO.Path.GetExtension(fileUpload.PostedFile.FileName).TrimStart(".".ToCharArray()).ToLower();
                    string newfileName = txtEmpCode.Text + "-" + txtName.Text + "." + exten1;

                    _objdemp.ObjTblEmployeeMaster.Photo = newfileName;
                    _objdemp.ObjTblEmployeeMaster.ContentType = fileUpload.PostedFile.ContentType;
                    _objdemp.ObjTblEmployeeMaster.Data = bytes;
                }

                using (HospiceSession objmysession = new HospiceSession())
                {

                    using (Hospice.Web.App_Code.BasePage mbp = new Hospice.Web.App_Code.BasePage())
                    {
                        if (_staffid > 0)
                        {
                            _objdemp.ObjTblEmployeeMaster.UpdatedBy = Convert.ToInt32(mbp.LogedinUID);
                            _objdemp.ObjTblEmployeeMaster.UpdatedOn = objmysession.CurrentDT;
                        }
                        else
                        {
                            _objdemp.ObjTblEmployeeMaster.CreatedBy = Convert.ToInt32(mbp.LogedinUID);
                            _objdemp.ObjTblEmployeeMaster.CreatedOn = objmysession.CurrentDT;
                        }
                    }
                    if (_staffid > 0)
                        result = _objdemp.UpdateEmployee(_objdemp.ObjTblEmployeeMaster);
                    else
                        result = _objdemp.InsertEmployee(_objdemp.ObjTblEmployeeMaster);
                }
            }
            return result;
        }
        private void GetEmployeeDetail()
        {
            using (Demployee _objdemp = new Demployee())
            {
                var _empdet = _objdemp.GetEmpMasterbyid(_staffid);

                txtEmpCode.Text = _empdet.EmpCode.ToString();
                txtName.Text = _empdet.EmpName.ToString();

                if (_empdet.DOB != null)
                    txtDOB.Text = (Convert.ToDateTime(_empdet.DOB.ToString())).ToString("dd/MM/yyyy");
                if (_empdet.DOJ != null)
                    txtDOJ.Text = (Convert.ToDateTime(_empdet.DOJ.ToString())).ToString("dd/MM/yyyy");
                if (_empdet.Address != null)
                    txtAddress.Text = _empdet.Address.ToString();
                if (_empdet.City != null)
                    ddlCity.SelectedValue = _empdet.City.ToString();

                if (_empdet.MobileNo != null)
                    txtMobile.Text = _empdet.MobileNo.ToString();
                if (_empdet.Email != null)
                    txtEmail.Text = _empdet.Email.ToString();
                if (_empdet.DesignationId != null)
                    ddlDesignation.Text = _empdet.DesignationId.ToString();
                if (_empdet.DepartmentId != null)
                    ddlDepartment.Text = _empdet.DepartmentId.ToString();
                if (_empdet.StatusEmp != null)
                    ddlStatus.SelectedValue = _empdet.StatusEmp.ToString();
                string filename = "";
                if (_empdet.Photo != null)
                {
                    string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])_empdet.Data.ToArray());
                    Image1.ImageUrl = imageUrl;
                    
                }

            }
        }
        public byte[] ImageUpload2(System.Web.UI.WebControls.FileUpload fuImageupload, string artno = "")
        {
            byte[] bytes = null;
            string virtualPath = "";
            string filethumimage = fuImageupload.PostedFile.FileName;
            string newfileName = string.Empty;

            System.Drawing.Image myThumbnail150;
            System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);

            if (filethumimage == "")
                if (artno != "")
                    newfileName = artno;
                else
                    newfileName = "no-image.png";
            else
                if (filethumimage != "")
            {

                string exten1 = System.IO.Path.GetExtension(fuImageupload.PostedFile.FileName).TrimStart(".".ToCharArray()).ToLower();
                newfileName = txtEmpCode.Text + "-" + txtName.Text + "." + exten1;// Guid.NewGuid().ToString() + "." + exten1; ;
                                                                                  //Save full image in folder
                virtualPath = HospiceSetting.empphoto + newfileName;//ConfigurationManager.AppSettings["ImagePath"] + newfileName;
                string rootedFilePath = Server.MapPath(virtualPath);
                fuImageupload.PostedFile.SaveAs(rootedFilePath);



                System.Drawing.Image imagesize = System.Drawing.Image.FromFile(ResolveUrl(Server.MapPath(virtualPath)));
                System.Drawing.Bitmap bitmapNew = new System.Drawing.Bitmap(imagesize);
                myThumbnail150 = bitmapNew.GetThumbnailImage(200, 200, myCallback, IntPtr.Zero);

            }

            return bytes;
        }
        public bool ThumbnailCallback()
        {
            return true;
        }
        public string ImageUpload(System.Web.UI.WebControls.FileUpload fuImageupload, string artno = "")
        {
            string virtualPath = "";
            string filethumimage = fuImageupload.PostedFile.FileName;
            string newfileName = string.Empty;
            //string _artno = artno;//lblArticleNo.Text;
            System.Drawing.Image myThumbnail150;
            System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);

            if (filethumimage == "")
                if (artno != "")
                    newfileName = artno;
                else
                    newfileName = "no-image.png";
            else
                if (filethumimage != "")
            {

                string exten1 = System.IO.Path.GetExtension(fuImageupload.PostedFile.FileName).TrimStart(".".ToCharArray()).ToLower();
                newfileName = txtEmpCode.Text + "-" + txtName.Text + "." + exten1;// Guid.NewGuid().ToString() + "." + exten1; ;
                                                                                  //Save full image in folder
                virtualPath = HospiceSetting.empphoto + newfileName;//ConfigurationManager.AppSettings["ImagePath"] + newfileName;
                string rootedFilePath = Server.MapPath(virtualPath);
                fuImageupload.PostedFile.SaveAs(rootedFilePath);



                System.Drawing.Image imagesize = System.Drawing.Image.FromFile(ResolveUrl(Server.MapPath(virtualPath)));
                System.Drawing.Bitmap bitmapNew = new System.Drawing.Bitmap(imagesize);
                myThumbnail150 = bitmapNew.GetThumbnailImage(75, 51, myCallback, IntPtr.Zero);

                fuImageupload.PostedFile.InputStream.Close();
                fuImageupload.PostedFile.InputStream.Dispose();

            }

            return newfileName;
        }

        private void ImageDelete(string deletefilename)
        {
            string fileName = HospiceSetting.empphoto + deletefilename;
            string thumbfileName = HospiceSetting.empphoto + deletefilename;

            if ((fileName != null || fileName != string.Empty) && (thumbfileName != null || thumbfileName != string.Empty))
            {
                if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(fileName)))
                {
                    System.IO.File.Delete(HttpContext.Current.Server.MapPath(fileName));
                }

            }

        }
    }
}