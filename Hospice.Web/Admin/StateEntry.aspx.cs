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
    public partial class StateEntry : BasePage
    {
        private int _stateid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["_stateid"] != null)
            {
                _stateid = Convert.ToInt32(Request.QueryString["_stateid"].ToString());
                //btnbSaveStateM.Visible = false;
            }
            else
            {
                btnbSaveStateM.Visible = true;
            }

            if (!IsPostBack)
            {               
                FillddlCountry();
                if (_stateid > 0)
                    GetStateDetail();
            }
        }
        private void GetStateDetail()
        {
            using (Dstate _objdlis = new Dstate())
            {
                var _statedet = _objdlis.GetstateDetailbycid(_stateid);
                txtstateCode.Text = _statedet.StateCode.ToString();
                txtName.Text = _statedet.StateName.ToString();              
                ddlCountry.SelectedValue = _statedet.CountryId.ToString();
            }
        }

        private void FillddlCountry()
        {
            using (Dstate objdlocCountry = new Dstate())
            {
                var result = objdlocCountry.GetLocCountryList();
                ddlCountry.DataSource = result;
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, new ListItem("Select Country", "-1"));
            }
        }

        protected void btnbSaveStateM_Click(object sender, EventArgs e)
        {

            try
            {
                int _issaveref = SaveState();
                if (_issaveref == -1)
                {
                    HospiceHelper.SendAlert("SsMessage:\n State Code " + txtstateCode.Text.ToUpper().Trim() + " is already exist.");
                }
                else if (_issaveref > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "ClearTextBoxes();", true);
                    HospiceHelper.SendAlert("SsMessage:\n State has been successfully saved.", "StateListing");

                }
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\n State not save.\n" + ex.Message);
            }
        }
        //protected void btnbSaveNewservM_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int _issaveref = SaveState();
        //        if (_issaveref == -1)
        //        {
        //            HospiceHelper.SendAlert("SsMessage:\n State Name " + txtName.Text.ToUpper().Trim() + " is already exist.");
        //        }
        //        else if (_issaveref > 0)
        //        {
        //            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "ClearTextBoxes();", true);
        //            HospiceHelper.SendAlert("SsMessage:\n Save has been successfully saved.");

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        HospiceHelper.SendAlert("SsException:\n Save not save.\n" + ex.Message);
        //    }
        //}
        private int SaveState()
        {
            int result = 0;

            if (ddlCountry.SelectedIndex == 0)
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease select country.");
                ddlCountry.Focus();
                return -1;
            }
          
            if (txtstateCode.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter State code.");
                txtstateCode.Focus();
                return -1;
            }
            if (txtName.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter State name.");
                txtName.Focus();
                return -1;
            }

            using (Dstate _objdlocState = new Dstate())
            {
                if (_stateid > 0)
                _objdlocState.ObjDLocationState = _objdlocState.GetstateDetailbycid(_stateid);

                _objdlocState.ObjDLocationState.StateName = txtName.Text.ToString();
                _objdlocState.ObjDLocationState.StateCode = txtstateCode.Text.ToString();               
                _objdlocState.ObjDLocationState.CountryId = Convert.ToInt32(ddlCountry.SelectedValue.ToString());
                _objdlocState.ObjDLocationState.Status = true;
                if (_stateid > 0)
                {
                    result = _objdlocState.UpdateLocState(_objdlocState.ObjDLocationState);
                }
                else
                {
                    result = _objdlocState.InsertLocState(_objdlocState.ObjDLocationState);
                }

            }
            return result;
        }
       
    }
}