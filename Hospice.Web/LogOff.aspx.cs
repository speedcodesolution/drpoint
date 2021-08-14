using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospice.Helper;

namespace Hospice.Web
{
    public partial class LogOff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            HospiceSession objmysession = null;
            try
            {
                objmysession = new HospiceSession();

                HttpCookie aCookie;
                string cookieName;
                int limit = HttpContext.Current.Request.Cookies.Count;
                for (int i = 0; i < limit; i++)
                {
                    cookieName = HttpContext.Current.Request.Cookies[i].Name;
                    aCookie = new HttpCookie(cookieName);
                    aCookie.Expires = DateTime.Now; // make it expire yesterday
                    Response.Cookies.Add(aCookie); // overwrite it
                }
                LogOut();
            }
            finally
            {
                if (objmysession != null)
                {
                    ((IDisposable)objmysession).Dispose();
                }
            }
            Response.Redirect("Login");
        }
        protected void LogOut()
        {
            Session.Abandon();
            string loggedOutPageUrl = "Login";
            Response.Write("<script language='javascript'>");
            Response.Write("function ClearHistory()");
            Response.Write("{");
            Response.Write(" var backlen=history.length;");
            Response.Write(" history.go(-backlen);");
            Response.Write(" window.location.href='" + loggedOutPageUrl + "'; ");
            Response.Write("}");
            Response.Write("</script>");
        }
    }
}