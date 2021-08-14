using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospice.DAL;

namespace Hospice.Web.App_Code
{
    public  class WebHelper
    {
        public static void fillddlCity(DropDownList dropDownList,int stateid=0)
        {
            using (Dcity objdloccity = new Dcity())
            {
                var result = objdloccity.GetLocCityList();
                if (stateid > 0)
                    result = objdloccity.GetLocCityList().Where(x => x.StateId == stateid).ToList();
                dropDownList.DataSource = result;
                dropDownList.DataTextField = "CityName";
                dropDownList.DataValueField = "CityID";
                dropDownList.DataBind();
                dropDownList.Items.Insert(0, new ListItem("Select City", ""));
            }
        }
    }
}