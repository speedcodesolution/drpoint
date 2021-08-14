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
    public partial class RoleListing :BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindgvRoleListing();
            }
        }

        private void BindgvRoleListing(string sortexp = "RlName")
        {
            using (Drole objdrole = new Drole())
            {
                DataTable _getresult = objdrole.GetRoleList().Where(x => x.RlIsDeleted == false).ToList().ConvertIEnumerableToDataTable();
                rptRoleListing.DataSource = _getresult;
                rptRoleListing.DataBind();

            }
        }
    }
}