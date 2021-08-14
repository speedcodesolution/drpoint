using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospice.DAL;
using System.Data;
using Hospice.Helper;

namespace Hospice.Web.Admin
{
    public partial class SiteAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (App_Code.BasePage objbasepage = new App_Code.BasePage())
            {
                if (objbasepage.LogedinUID != null || objbasepage.LogedinUserType != null)
                {
                    HttpCookie LogedinnameCookie = Request.Cookies["Credentials"];
                    if (LogedinnameCookie != null)
                    {
                        logedinusernametop.InnerHtml = LogedinnameCookie["logedinusername"].ToString();
                        logedinusernamesm.InnerHtml = LogedinnameCookie["logedinusername"].ToString().Substring(0,2).ToUpper();
                        logedinusernametopr.InnerHtml = LogedinnameCookie["logedinusername"].ToString();
                        using (Drole drole = new Drole())
                        {
                            logedinuserroletopr.InnerHtml = drole.GetRoleList().Where(x=>x.RlId==Convert.ToInt16(LogedinnameCookie["logedinusertype"].ToString())).SingleOrDefault().RlName;
                        }

                    }
                    ddlCurrentBranch.Visible = false;
                    lblCurrentBranch.Visible = false;
                    if (logedinuserroletopr.InnerHtml.ToLower() == "admin")
                        ddlCurrentBranch.Visible = true;
                    else
                        lblCurrentBranch.Visible = true;

                    RolePermission();
                }
            }

            
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            using (Dbranch dbranch = new Dbranch())
            {
                var branchlist = dbranch.GetbranchMasterList();
                ddlCurrentBranch.DataSource = branchlist;
                ddlCurrentBranch.DataTextField = "BranchName";
                ddlCurrentBranch.DataValueField = "BranchID";
                ddlCurrentBranch.DataBind();

                HttpCookie LoginCookie = HttpContext.Current.Request.Cookies.Get("Credentials");
                if (LoginCookie != null && LoginCookie["logedinuserbranchid"].ToString() != "")
                {
                    Session["CurrentBranch"] = LoginCookie["logedinuserbranchid"].ToString();
                    ddlCurrentBranch.SelectedValue = LoginCookie["logedinuserbranchid"].ToString();
                }
                else
                {
                    if (Session["CurrentBranch"] == null)
                        Session["CurrentBranch"] = ddlCurrentBranch.SelectedValue;
                    else
                    {
                        if (ddlCurrentBranch.Items.FindByValue(Session["CurrentBranch"].ToString()) == null)
                            Session["CurrentBranch"] = ddlCurrentBranch.SelectedValue;
                        else
                            ddlCurrentBranch.SelectedValue = Session["CurrentBranch"].ToString();
                    }
                }
                if (Session["IsBranchChanged"] == null)
                    Session["IsBranchChanged"] = false;

                if (branchlist.Count == 0)
                {
                    Session["CurrentBranch"] = 0;
                    lblCurrentBranch.Text = "";
                }
                else
                {
                    lblCurrentBranch.Text = ddlCurrentBranch.SelectedItem.Text;
                }

            }
        }
        protected void lnkbtnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();//clear session
            Session.Abandon();//Abandon session
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Redirect("../LogOff.aspx");
        }

        protected void ddlCurrentBranch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RolePermission()
        {
            mnuappointment.Attributes.Add("class", "nav-link dropdown-toggle");
            mnudashboardadmin.Visible = false;
            mnudoctor.Visible = false;
            mnupatient.Visible = false;
            mnuopd.Visible = false;
            mnuBilling.Visible = false;
            mnustaff.Visible = false;
            mnuappointment.Visible = false;
            mnumaster.Visible = false;
            mnusetting.Visible = false;

            if (logedinuserroletopr.InnerHtml.ToLower() == "admin")
            {
                mnudashboardadmin.Visible = true;
                mnudoctor.Visible = true;
                mnupatient.Visible = true;
                mnuopd.Visible = true;
                mnuBilling.Visible = true;
                mnustaff.Visible = true;
                mnuappointment.Visible = true;
                mnumaster.Visible = true;
                mnusetting.Visible = true;
            }
            else if (logedinuserroletopr.InnerHtml.ToLower() == "receptionist")
            {
                mnuappointment.Attributes.Add("class", "nav-link dropdown-toggle active-page");
                mnudoctor.Visible = true;
                mnupatient.Visible = true;
                mnuBilling.Visible = true;
                mnustaff.Visible = true;
                mnuappointment.Visible = true;
            }
            else if (logedinuserroletopr.InnerHtml.ToLower() == "doctor")
            { }
            else if (logedinuserroletopr.InnerHtml.ToLower() == "staff")
            { }
        }
    }
}