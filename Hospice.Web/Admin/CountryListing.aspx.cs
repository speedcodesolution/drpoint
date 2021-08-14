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
    public partial class CountryListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindgvCountryListing();
            }
        }

        private void BindgvCountryListing(string sortexp = "CountryName")
        {
            using (DCountry objdcountry = new DCountry())
            {
                DataTable _getresult = objdcountry.GetCountryList().Where(x => x.Status == false).ToList().ConvertIEnumerableToDataTable();
                rptCountryListing.DataSource = _getresult;
                rptCountryListing.DataBind();

            }
        }
    }
}