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
    public partial class CountryEntry : BasePage
    {
        int _Countryid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["_countryid"] != null)
            {
                _Countryid = Convert.ToInt32(Request.QueryString["_countryid"].ToString());
            }

            if (!IsPostBack)
            {
                if (_Countryid > 0)
                {
                    GetCountryDetailbyid();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int _issavecountry = SaveCountry();
                if (_issavecountry == -1)
                {
                    HospiceHelper.SendAlert("SsMessage:\n Country Name " + txtCountryName.Text.ToUpper().Trim() + " is already exist.");
                    HospiceHelper.SendAlert("SsMessage:\n Country Code " + txtcountrycode.Text.ToUpper().Trim() + " is already exist.");
                }
                else if (_issavecountry > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "ClearTextBoxes();", true);
                    HospiceHelper.SendAlert("SsMessage:\n Country has been successfully saved.", "CountryListing");

                }
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\nRole not save.\n" + ex.Message);
            }
        }
        private void GetCountryDetailbyid()
        {
            using (DCountry objcountry = new DCountry())
            {
                var _getresult = objcountry.GetCountryDetailsById(_Countryid);

                txtCountryName.Text = _getresult.CountryName;
                txtcountrycode.Text = _getresult.CountryCode;
             
            }
        }
        private int SaveCountry()
        {
            int result = 0;

            if (txtCountryName.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter role name");
                txtCountryName.Focus();
                return -1;
            }
            if (txtcountrycode.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter role name");
                txtcountrycode.Focus();
                return -1;
            }

            if (ddlStatus.SelectedIndex == 0)
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease select status.");
                ddlStatus.Focus();
                return -1;
            }

            using (DCountry _objdcountry = new DCountry())
            {

                if (_Countryid > 0)
                    _objdcountry.ObjtblCountryMaster = _objdcountry.GetCountryDetailsById(_Countryid);

                _objdcountry.ObjtblCountryMaster.CountryName = txtCountryName.Text.Trim();
                _objdcountry.ObjtblCountryMaster.CountryCode = txtcountrycode.Text.Trim();
               
                using (HospiceSession objmysession = new HospiceSession())
                {
                    if (_Countryid > 0)
                    {
                        //_objdcountry.ObjtblCountryMaster.up = Convert.ToInt32(LogedinUID);
                        //_objdcountry.ObjtblCountryMaster.UpdatedOn = objmysession.CurrentDT;

                        result = _objdcountry.UpdateCountry(_objdcountry.ObjtblCountryMaster);
                    }
                    else
                    {

                       // _objdcountry.ObjtblCountryMaster.CreatedBy = Convert.ToInt32(LogedinUID);
                        //_objdcountry.ObjtblCountryMaster.CreatedOn = objmysession.CurrentDT;

                        result = _objdcountry.InsertCountry(_objdcountry.ObjtblCountryMaster);
                    }
                }


            }
            return result;
        }
    }
}