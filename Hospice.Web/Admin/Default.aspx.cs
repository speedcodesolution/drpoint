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
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (Dadmindashboard dadmindashboard = new Dadmindashboard())
            {
                doctorcount.InnerHtml= dadmindashboard.GetDoctorCount().ToString();
            }
        }
    }
}