using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospice.DAL;

namespace Hospice.Web
{
    public partial class Login : System.Web.UI.Page
    {
        private string _loginusername;
        private string _loginpwd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                txtUserName.Focus();
        }
        //protected void btnSignIn_Click(object sender, EventArgs e)
        //{
        //    _loginusername = txtUserName.Text.ToString();
        //    _loginpwd = txtPassword.Text.ToString();

        //    using (Dlogin objdlogin = new Dlogin())
        //    {
        //        int islogin = objdlogin.GetLoginDetail(_loginusername, _loginpwd).Where(x => x.UsrStatus == 1).Count();
        //        FailureText.Text = "";
        //        if (islogin == 0)
        //        {
        //            FailureText.Text = "Invalid username or password. Please try again";
        //            return;
        //        }
        //        else
        //        {
        //            var logedindetail = objdlogin.GetLoginDetail(_loginusername, _loginpwd).Where(x => x.UsrStatus == 1).SingleOrDefault();
        //            using (DuserRole _objur = new DuserRole())
        //            {
        //                var logedinuserroles = _objur.GetUserRoleList().Where(x => x.userid == logedindetail.UsrId).SingleOrDefault().RoleId;

        //                HttpCookie cookie = new HttpCookie("Credentials");

        //                cookie.Values.Add("logedinuid", logedindetail.UsrId.ToString());// your x value
        //                                                                                //cookie.Values.Add("logedinusertype", logedindetail.UsrRole.ToString()); // your y value
        //                cookie.Values.Add("logedinusername", logedindetail.UsrLoginName.ToString());
        //                cookie.Values.Add("logedinusertype", logedinuserroles.ToString());
        //                //cookie.Values.Add("logedinusertype", logedindetail.RoleId.ToString());
        //                //cookie.Expires = DateTime.Now.AddDays(1); // --------> cookie.Expires is the property you can set timeout

        //                HttpContext.Current.Response.AppendCookie(cookie);

        //                if (logedindetail.UsrId > 0)
        //                {
        //                    if (logedinuserroles.ToString().ToLower() == "3")
        //                    { Response.Redirect("~/Admin/AppointmentList"); }
        //                    else
        //                        Response.Redirect("~/Admin/Default");
        //                }
        //                else
        //                {

        //                }
        //            }



        //        }
        //    }
        //}
        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            _loginusername = txtUserName.Text.ToString();
            _loginpwd = txtPassword.Text.ToString();

            using (Dlogin objdlogin = new Dlogin())
            {
                int islogin = objdlogin.GetLoginDetail(_loginusername, _loginpwd).Where(x => x.UsrStatus == 1).Count();
                FailureText.Text = "";
                if (islogin == 0)
                {
                    FailureText.Text = "Invalid username or password. Please try again";
                    return;
                }
                else
                {
                    var logedindetail = objdlogin.GetLoginDetail(_loginusername, _loginpwd).Where(x => x.UsrStatus == 1).SingleOrDefault();
                    using (DuserRole _objur = new DuserRole())
                    {
                        var logedinuserroles = _objur.GetUserRoleList().Where(x => x.userid == logedindetail.UsrId).SingleOrDefault().RoleId;

                        HttpCookie cookie = new HttpCookie("Credentials");

                        cookie.Values.Add("logedinuid", logedindetail.UsrId.ToString());// your x value
                                                                                        //cookie.Values.Add("logedinusertype", logedindetail.UsrRole.ToString()); // your y value
                        cookie.Values.Add("logedinusername", logedindetail.UsrLoginName.ToString());
                        cookie.Values.Add("logedinusertype", logedinuserroles.ToString());
                        cookie.Values.Add("logedinuserbranchid", logedindetail.BranchId.ToString());
                        //cookie.Values.Add("logedinusertype", logedindetail.RoleId.ToString());
                        //cookie.Expires = DateTime.Now.AddDays(1); // --------> cookie.Expires is the property you can set timeout

                        HttpContext.Current.Response.AppendCookie(cookie);
                        if (logedindetail.UsrId > 0)
                        {
                            if (logedinuserroles.ToString().ToLower() == "3")
                            { Response.Redirect("~/Admin/AppointmentList"); }
                            else
                                Response.Redirect("~/Admin/Default");
                        }
                        else
                        {

                        }

                        ////if (logedindetail.UsrId > 0)
                        ////{
                        ////    if (logedindetail.UsrId == 1)
                        ////        Response.Redirect("~/Admin/Default");
                        ////    else if (logedindetail.UsrId == 3)
                        ////        Response.Redirect("~/Admin/AppointmentList");
                        ////}

                    }



                }
            }
        }
    }
}