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
    public partial class PatientList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindrptPatientListing();
            }
        }
        private void BindrptPatientListing()
        {
            using (DrPointsDataContext demployee = new DrPointsDataContext())
            {
                DataTable _getresult = demployee.tblPatientMasters.ToList().ConvertIEnumerableToDataTable();
                rptPatientListing.DataSource = _getresult;
                rptPatientListing.DataBind();

            }
        }
    }
}