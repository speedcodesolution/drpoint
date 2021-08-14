using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospice.DAL;

namespace Hospice.Web
{
    public partial class WebMethods : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<sp_GetPatientDetailListResult> GetShippingName(string _pid)
        {
            List<sp_GetPatientDetailListResult> allShippingName = new List<sp_GetPatientDetailListResult>();
            using (DrPointsDataContext sctdatacontext = new DrPointsDataContext())
            {
                allShippingName = sctdatacontext.sp_GetPatientDetailList(1).ToList();

            }


            return allShippingName;
        }
    }
}