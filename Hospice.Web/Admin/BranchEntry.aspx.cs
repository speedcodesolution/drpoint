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
    public partial class BranchEntry : BasePage
    {
        private int _branchid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (Request.QueryString["_branchid"] != null)
            {
                _branchid = Convert.ToInt32(Request.QueryString["_branchid"].ToString());
            }
            else
            {
                btnbSavebranchM.Visible = true;
            }
            if (!IsPostBack)
            {
                FillddlState();
                FillddlCity();

                if (_branchid > 0)
                    GetBranchDetail();
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Purpose :   If the page is listing page then DDL will apear otherwise label will apear.
            Master.FindControl("lblCurrentBranch").Visible = false;
            Master.FindControl("ddlCurrentBranch").Visible = false;
        }
        protected void btnbSavebranchM_Click(object sender, EventArgs e)
        {

            try
            {
                int _issaveref = SaveBranch();
                if (_issaveref == -1)
                {
                    HospiceHelper.SendAlert("SsMessage:\n Branch Code " + txtBranchCode.Text.ToUpper().Trim() + " is already exist.");
                }
                else if (_issaveref > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "ClearTextBoxes();", true);
                    HospiceHelper.SendAlert("SsMessage:\n Branch has been successfully saved.", "BranchListing");

                }
            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\n Branch not save.\n" + ex.Message);
            }
        }
        
        private int SaveBranch()
        {
            int result = 0;

            if (txtBranchCode.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter code.");
                txtBranchCode.Focus();
                return -1;
            }
            if (txtName.Text == "")
            {
                HospiceHelper.SendAlert("SsValidation:\nPlease enter name.");
                txtName.Focus();
                return -1;
            }



            
            using (Dbranch _objbranch = new Dbranch())
            {
                if (_branchid > 0)
                _objbranch.objtbranchmaster = _objbranch.Getbranchbymasterid(_branchid);
                _objbranch.objtbranchmaster.BranchLocation = txtBranchCode.Text.ToString();
                _objbranch.objtbranchmaster.BranchName = txtName.Text.ToString();
                _objbranch.objtbranchmaster.Address1 = txtaddress1.Text.ToString();
                _objbranch.objtbranchmaster.Address2 = txtaddress2.Text.ToString();
                //_objbranch.objtbranchmaster.State = ddlState.SelectedValue.ToString();
                _objbranch.objtbranchmaster.City =Convert.ToInt32(ddlcity.SelectedValue.ToString());
                _objbranch.objtbranchmaster.ContactPh = txtMobile.Text.ToString();
                _objbranch.objtbranchmaster.EmailID = txtEmail.Text.ToString();
                _objbranch.objtbranchmaster.Status = Convert.ToInt32(ddlStatus.SelectedValue.ToString()) == 1 ? true : false;
                using (HospiceSession objmysession = new HospiceSession())
                {
                    if (_branchid > 0)
                    {
                        _objbranch.objtbranchmaster.UpdatedBy = Convert.ToInt32(LogedinUID);
                        _objbranch.objtbranchmaster.UpdatedOn = objmysession.CurrentDT;
                        result = _objbranch.UpdateBranch(_objbranch.objtbranchmaster);
                    }
                    else
                    {

                        _objbranch.objtbranchmaster.CreatedBy = Convert.ToInt32(LogedinUID);
                        _objbranch.objtbranchmaster.CreatedOn = objmysession.CurrentDT;

                        result = _objbranch.InsertBranch(_objbranch.objtbranchmaster);
                    }
                }
            }
            return result;
        }
        private void GetBranchDetail()
        {
            using (Dbranch _objbranch = new Dbranch())
            {
                var _branchdet = _objbranch.GetbranchMasterList().Where(x => x.BranchID == _branchid).SingleOrDefault();
                txtBranchCode.Text = _branchdet.BranchLocation.ToString();
                txtName.Text = _branchdet.BranchName.ToString();
                using (Dcity dcity = new Dcity())
                {
                    ddlState.SelectedValue= dcity.GetLocCityList().Where(x=>x.CityId== Convert.ToInt32(_branchdet.City)).FirstOrDefault().StateId.ToString();
                    ddlcity.SelectedValue = _branchdet.City.ToString();
                }
                if(_branchdet.Address1!=null)
                    txtaddress1.Text = _branchdet.Address1.ToString();
                if (_branchdet.ContactPh != null)
                    txtMobile.Text = _branchdet.ContactPh.ToString();
                if (_branchdet.EmailID != null)
                    txtEmail.Text = _branchdet.EmailID.ToString();
            }
        }
                
        private void FillddlState()
        {
            using (Dstate objdlocstate = new Dstate())
            {
                var result = objdlocstate.GetStateList();
                ddlState.DataSource = result;
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateID";
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("Select State", ""));
            }
        }

        private void FillddlCity(int stateid=0)
        {
            using (Dcity objdloccity = new Dcity())
            {
                var result = objdloccity.GetLocCityList();
                if(stateid>0)
                    result = objdloccity.GetLocCityList().Where(x=>x.StateId==stateid).ToList();
                ddlcity.DataSource = result;
                ddlcity.DataTextField = "CityName";
                ddlcity.DataValueField = "CityID";
                ddlcity.DataBind();
                ddlcity.Items.Insert(0, new ListItem("Select City", ""));
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlState.SelectedIndex>0)
            {
                FillddlCity(Convert.ToInt16(ddlState.SelectedValue));
            }
        }
    }
}