using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospice.Web.App_Code;
using Hospice.DAL;
using Hospice.Helper;
using System.Data;

namespace Hospice.Web.Admin
{
    public partial class DoctorListing : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindrptDoctorListing();
            }
        }
        private void BindrptDoctorListing(string sortexp = "EmpName")
        {
            using (Demployee demployee = new Demployee())
            {
                DataTable _getresult = demployee.GetEmpMasterList().Where(x=>x.EmpType==1).ToList().ConvertIEnumerableToDataTable();
                rptDoctorListing.DataSource = _getresult;
                rptDoctorListing.DataBind();

            }
        }
    }
}