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
    public partial class ServiceEntry : BasePage
    {
        private int _serviceid = 0;
        private  int servicetype = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            servicetype = Convert.ToInt32(Request.QueryString["_serviceid"].ToString());

            if(servicetype==1)
            {
                othertype.Visible = true;
            }
            else
            {
                othertype.Visible = false;
            }

            if (Request.QueryString["_serviceid"] != null)
            {
                _serviceid = Convert.ToInt32(Request.QueryString["_serviceid"].ToString());
                
            }
            else
            {
                btnbSaveservM.Visible = true;
               
            }
            if (!IsPostBack)
            {
                if (_serviceid > 0)
                    GetservuenceDetail();
                    Fillddldoctorlist();
            }
        }

        protected void btnbSaveservM_Click(object sender, EventArgs e)
        {

            try
            {
                int _issaveref = Saveservice();
                if (_issaveref == -1)
                {
                    HospiceHelper.SendAlert("SsMessage:\n Service Code " + txtservCode.Text.ToUpper().Trim() + " is already exist.");
                }
                else if (_issaveref > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "ClearTextBoxes();", true);
                    HospiceHelper.SendAlert("SsMessage:\n Service has been successfully saved.", "ServiceListing");

                }
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\n Service not save.\n" + ex.Message);
            }
        }
     
        private int Saveservice()
        {
            int result = 0;

            if (txtservCode.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter code.");
                txtservCode.Focus();
                return -1;
            }
            if (txtName.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter name.");
                txtName.Focus();
                return -1;
            }

            if (txtamt.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter Amount.");
                txtName.Focus();
                return -1;
            }




            using (Dservice _objserv = new Dservice())
            {
               
                if (_serviceid > 0)
                _objserv.objTblService = _objserv.GetServicebymasterid(_serviceid);
                _objserv.objTblService.SericeCode = txtservCode.Text.ToString();
                _objserv.objTblService.ServiceName = txtName.Text.ToString();
                _objserv.objTblService.Servicetax = Convert.ToDecimal(txtservicetax.Text.ToString());
                _objserv.objTblService.ServiceAmount = Convert.ToInt32(txtamt.Text.ToString());
                if (servicetype == 1)
                {
                    _objserv.objTblService.ServiceColor = txtservCode.Text.ToString();
                    _objserv.objTblService.Serviceownerid = Convert.ToInt32( ddldocor.SelectedValue.ToString());
                }                
                _objserv.objTblService.ServiceDescription = txtserviceDescription.Text.ToString();
                _objserv.objTblService.ServiceType = servicetype;
                _objserv.objTblService.Status = Convert.ToInt32(ddlStatus.SelectedValue.ToString()) == 1 ? true : false;
                
                using (HospiceSession objmysession = new HospiceSession())
                {
                    if (_serviceid > 0)
                    {
                        _objserv.objTblService.UpdatedBy = Convert.ToInt32(LogedinUID);
                        _objserv.objTblService.UpdatedOn = objmysession.CurrentDT;
                        result = _objserv.UpdateService(_objserv.objTblService);
                    }
                    else
                    {

                        _objserv.objTblService.CreatedBy = Convert.ToInt32(LogedinUID);
                        _objserv.objTblService.CreatedOn = objmysession.CurrentDT;
                        result = _objserv.InsertService(_objserv.objTblService);
                    }
                }
            }
            return result;
        }
        private void GetservuenceDetail()
        {
            using (Dservice _objserv = new Dservice())
            {
                var _servdet = _objserv.GetServiceMasterList().Where(x => x.Serviceid == _serviceid).SingleOrDefault();
                txtservCode.Text = _servdet.SericeCode.ToString();
                txtName.Text = _servdet.ServiceName.ToString();
                txtservicetax.Text = _servdet.Servicetax.ToString();
                txtamt.Text = _servdet.ServiceAmount.ToString();
                txtserviceDescription.Text = _servdet.ServiceDescription.ToString();
               

            }
        }


        private void Fillddldoctorlist()
        {
            using (Dservice objddoctor = new Dservice())
            {
                var result = objddoctor.GetdoctorList();
                ddldocor.DataSource = result;
                ddldocor.DataTextField = "EmpName";
                ddldocor.DataValueField = "EmpID";
                ddldocor.DataBind();
                ddldocor.Items.Insert(0, new ListItem("Select Doctor", "-1"));
            }
        }
    }
}