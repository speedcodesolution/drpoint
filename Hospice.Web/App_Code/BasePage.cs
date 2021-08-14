using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*Namespace required for Making Date format compatible*/
using System.Globalization;
using System.Threading;
using System.Reflection;


namespace Hospice.Web.App_Code
{
    public class BasePage : System.Web.UI.Page
    {
        public string LogedinUID
        {
            get
            {
                if (Session["logedinuid"] == null)
                {
                    HttpCookie LoginCookie = HttpContext.Current.Request.Cookies.Get("Credentials"); // Credentials is the name of cookie
                    if (LoginCookie == null)
                        HttpContext.Current.Response.Redirect("~/Login");
                    Session["logedinuid"] = LoginCookie["logedinuid"].ToString();
                }
                return Session["logedinuid"].ToString();
            }
            set
            {
                Session["logedinuid"] = value;
            }
        }
        public string LogedinUserType
        {
            get
            {
                if (Session["logedinusertype"] == null)
                {
                    HttpCookie LoginCookie = HttpContext.Current.Request.Cookies.Get("Credentials"); // Credentials is the name of cookie
                    if (LoginCookie == null)
                        HttpContext.Current.Response.Redirect("~/Login");
                    Session["logedinusertype"] = LoginCookie["logedinusertype"].ToString();
                }
                return Session["logedinusertype"].ToString();
            }
            set
            {
                Session["logedinusertype"] = value;
            }
        }

        protected override void InitializeCulture()
        {
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("IT");

            CultureInfo cinfo = new CultureInfo("en-US");

            NumberFormatInfo nfi = new NumberFormatInfo();
            DateTimeFormatInfo dtfi = new DateTimeFormatInfo();

            //Number Format Information
            nfi.NegativeSign = "-";
            nfi.CurrencyDecimalDigits = 2;
            nfi.CurrencyDecimalSeparator = ".";
            nfi.CurrencyGroupSeparator = ",";

            //Date Time Format Information
            dtfi.DateSeparator = "/";
            dtfi.FirstDayOfWeek = DayOfWeek.Monday;
            dtfi.ShortDatePattern = "dd/MM/yyyy";

            cinfo.NumberFormat = nfi;
            cinfo.DateTimeFormat = dtfi;

            Thread.CurrentThread.CurrentCulture = cinfo;
            Thread.CurrentThread.CurrentUICulture = cinfo;

            base.InitializeCulture();

        }
    }
}