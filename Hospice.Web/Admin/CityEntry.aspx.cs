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
    public partial class CityEntry : BasePage
    {
        private int _cityid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["_cityid"] != null)
            {
                _cityid = Convert.ToInt32(Request.QueryString["_cityid"].ToString());
                //btnbSaveStateM.Visible = false;
            }
            else
            {
                btnbSaveCityM.Visible = true;
            }

            if (!IsPostBack)
            {               
                FillddlCountry();
                FillddlState();
                if (_cityid > 0)
                    GetCityDetail();
            }
        }
        private void GetCityDetail()
        {
            using (Dcity _objdlcitys = new Dcity())
            {
                var _citydet = _objdlcitys.GetcityDetailbycid(_cityid);
                txtCityCode.Text = _citydet.CityCode.ToString();
                txtName.Text = _citydet.CityName.ToString();              
                ddlstate.SelectedValue = _citydet.StateId.ToString();
            }
        }

        private void FillddlCountry()
        {
            using (DCountry objdlocCountry = new DCountry())
            {
                var result = objdlocCountry.GetCountryList();
                ddlCountry.DataSource = result;
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, new ListItem("Select Country", "-1"));
            }
        }

        private void FillddlState()
        {
            using (Dstate objdlocstate = new Dstate())
            {
                var result = objdlocstate.GetLocStateList();
                ddlstate.DataSource = result;
                ddlstate.DataTextField = "StateName";
                ddlstate.DataValueField = "StateID";
                ddlstate.DataBind();
                ddlstate.Items.Insert(0, new ListItem("Select State", "-1"));
            }
        }

        protected void btnbSaveCityM_Click(object sender, EventArgs e)
        {
            try
            {
                int _issaveref = SaveCity();
                if (_issaveref == -1)
                {
                    HospiceHelper.SendAlert("SsMessage:\n City Code " + txtCityCode.Text.ToUpper().Trim() + " is already exist.");
                }
                else if (_issaveref > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "ClearTextBoxes();", true);
                    HospiceHelper.SendAlert("SsMessage:\n City has been successfully saved.", "CityListing");

                }
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\n City not save.\n" + ex.Message);
            }
        }
       
        private int SaveCity()
        {
            int result = 0;

            if (ddlCountry.SelectedIndex == 0)
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease select country.");
                ddlCountry.Focus();
                return -1;
            }
          
            if (txtCityCode.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter State code.");
                txtCityCode.Focus();
                return -1;
            }
            if (txtName.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter State name.");
                txtName.Focus();
                return -1;
            }

            using (Dcity _objdcity = new Dcity())
            {
                if (_cityid > 0)
                _objdcity.ObjDcity = _objdcity.GetcityDetailbycid(_cityid);

                _objdcity.ObjDcity.CityName = txtName.Text.ToString();
                _objdcity.ObjDcity.CityCode= txtCityCode.Text.ToString();               
                _objdcity.ObjDcity.CountryId = Convert.ToInt32(ddlCountry.SelectedValue.ToString());
                _objdcity.ObjDcity.StateId = Convert.ToInt32(ddlstate.SelectedValue.ToString());
                _objdcity.ObjDcity.Status = true;
                using (HospiceSession objmysession = new HospiceSession())
                {
                    if (_cityid > 0)
                    {
                        _objdcity.ObjDcity.UpdatedBy = Convert.ToInt32(LogedinUID);
                        _objdcity.ObjDcity.UpdatedOn = objmysession.CurrentDT;
                        result = _objdcity.UpdateLocCity(_objdcity.ObjDcity);
                    }
                    else
                    {
                        _objdcity.ObjDcity.CreatedBy = Convert.ToInt32(LogedinUID);
                        _objdcity.ObjDcity.CreatedOn = objmysession.CurrentDT;
                        result = _objdcity.InsertLocCity(_objdcity.ObjDcity);
                       
                    }
                }

            }
            return result;
        }
       
    }
}