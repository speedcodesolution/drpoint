using System;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.IO;

namespace Hospice.Helper
{
    public static class HospiceHelper
    {
        public static object ToType<T>(this object obj, T type)
        {

            //create instance of T type object:
            var tmp = Activator.CreateInstance(Type.GetType(type.ToString()));

            //loop through the properties of the object you want to covert:          
            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
                try
                {

                    //get the value of property and try 
                    //to assign it to the property of T type object:
                    tmp.GetType().GetProperty(pi.Name).SetValue(tmp, pi.GetValue(obj, null), null);
                }
                catch { }
            }

            //return the T type object:         
            return tmp;
        }
        public static object ToNonAnonymousList<T>(this List<T> list, Type t)
        {

            //define system Type representing List of objects of T type:
            var genericType = typeof(List<>).MakeGenericType(t);

            //create an object instance of defined type:
            var l = Activator.CreateInstance(genericType);

            //get method Add from from the list:
            MethodInfo addMethod = l.GetType().GetMethod("Add");

            //loop through the calling list:
            foreach (T item in list)
            {

                //convert each object of the list into T object 
                //by calling extension ToType<T>()
                //Add this object to newly created list:
                if (t != null)
                    addMethod.Invoke(l, new object[] { item.ToType(t) });
            }

            //return List of T objects:
            return l;
        }
        public static void SendAlert(string sMessage, string sRedirectPage = "")
        {
            string shMessage = "alert('" + sMessage.Replace("'", @"\'").Replace("\n", @"\n") + "');";
            if (sRedirectPage.Trim() != "")
                shMessage = "alert('" + sMessage.Replace("'", @"\'").Replace("\n", @"\n") + "');window.location.href = '" + sRedirectPage + "';";

            if (HttpContext.Current.CurrentHandler is Page)
            {
                Page p = (Page)HttpContext.Current.CurrentHandler;
                if (ScriptManager.GetCurrent(p) != null)
                    ScriptManager.RegisterStartupScript(p, typeof(Page), "Message", shMessage, true);
                else
                    p.ClientScript.RegisterStartupScript(typeof(Page), "Message", shMessage, true);
            }
        }

        public static void SendAlertNoPB(string sMessage, string sRedirectPage = "")
        {
            string shMessage = "alert('" + sMessage.Replace("'", @"\'").Replace("\n", @"\n") + "');";
            if (sRedirectPage.Trim() != "")
                shMessage = "alert('" + sMessage.Replace("'", @"\'").Replace("\n", @"\n") + "');window.location.href = '" + sRedirectPage + "';";

            if (HttpContext.Current.CurrentHandler is Page)
            {
                Page p = (Page)HttpContext.Current.CurrentHandler;
                if (ScriptManager.GetCurrent(p) != null)
                    p.ClientScript.RegisterClientScriptBlock(p.GetType(), "Message", "<script language='javascript'>" + shMessage + "</script>");

                else
                    p.ClientScript.RegisterClientScriptBlock(typeof(Page), "Message", "<script language='javascript'>" + shMessage + "</script>");
            }
        }
        public static DataTable ConvertIEnumerableToDataTable<T>(this IEnumerable<T> collection, string tableName)
        {
            DataTable tbl = ConvertIEnumerableToDataTable(collection);
            tbl.TableName = tableName;
            return tbl;
        }

        public static DataTable ConvertIEnumerableToDataTable<T>(this IEnumerable<T> collection)
        {
            DataTable dt = new DataTable();
            Type t = typeof(T);
            PropertyInfo[] pia = t.GetProperties();
            object temp;
            DataRow dr;

            for (int i = 0; i < pia.Length; i++)
            {
                dt.Columns.Add(pia[i].Name, Nullable.GetUnderlyingType(pia[i].PropertyType) ?? pia[i].PropertyType);
                dt.Columns[i].AllowDBNull = true;
            }

            //Populate the table
            foreach (T item in collection)
            {
                dr = dt.NewRow();
                dr.BeginEdit();

                for (int i = 0; i < pia.Length; i++)
                {
                    temp = pia[i].GetValue(item, null);
                    if (temp == null || (temp.GetType().Name == "Char" && ((char)temp).Equals('\0')))
                    {
                        dr[pia[i].Name] = (object)DBNull.Value;
                    }
                    else
                    {
                        dr[pia[i].Name] = temp;
                    }
                }

                dr.EndEdit();
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static void ExporttoXl(System.Web.UI.WebControls.GridView gridview, List<int> hidegvcolumnlist, string xlfilename = "")
        {
            using (StringWriter stringWrite = new StringWriter())
            {
                using (HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite))
                {
                    if (xlfilename == "")
                        xlfilename = "XportFrmMYoga";

                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + xlfilename + ".xls");
                    HttpContext.Current.Response.ContentType = "application/excel";

                    // Disable Paging.
                    gridview.AllowPaging = false;
                    hidegvcolumnlist.ForEach(delegate (int columnindx) { gridview.Columns[columnindx].Visible = false; });
                    //Re-bind the GridView.
                    gridview.DataBind();

                    //*********Copying the randered Html in StringWriter**********
                    //System.Web.UI.HtmlControls.HtmlForm H1 = new System.Web.UI.HtmlControls.HtmlForm();
                    //H1.Controls.Add(gridview);
                    //this.Controls.Add(H1);
                    //H1.RenderControl(htmlWrite);

                    //**************Or Userd this*********
                    gridview.RenderControl(htmlWrite);

                    HttpContext.Current.Response.Write(stringWrite.ToString());

                    //Enable Paging.
                    gridview.AllowPaging = true;
                    hidegvcolumnlist.ForEach(delegate (int columnindx) { gridview.Columns[columnindx].Visible = true; });
                    //Re-bind the GridView.
                    gridview.DataBind();

                    HttpContext.Current.Response.End();
                }
            }
        }

        public static void Printgv(System.Web.UI.WebControls.GridView gridview, List<int> hidegvcolumnlist)
        {
            //Disable Paging.
            gridview.AllowPaging = false;
            hidegvcolumnlist.ForEach(delegate (int columnindx) { gridview.Columns[columnindx].Visible = false; });
            //Re-bind the GridView.
            gridview.DataBind();

            using (StringWriter sw = new StringWriter())
            {
                //Render GridView to HTML.
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gridview.RenderControl(hw);

                //Enable Paging.
                gridview.AllowPaging = true;
                hidegvcolumnlist.ForEach(delegate (int columnindx) { gridview.Columns[columnindx].Visible = true; });
                gridview.DataBind();

                //Remove single quotes to avoid JavaScript error.
                string gridHTML = sw.ToString().Replace(Environment.NewLine, "");
                //string gridCSS = gridStyles.InnerText.Replace("\"", "'").Replace(Environment.NewLine, "");

                //Print the GridView.
                string script = "window.onload = function() { PrintGrid('" + gridHTML + "'); }";
                //string script = "window.onload = function() { PrintGrid('" + gridHTML + "', '" + gridCSS + "'); }";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "GridPrint", script, true);

                if (HttpContext.Current.CurrentHandler is Page)
                {
                    Page p = (Page)HttpContext.Current.CurrentHandler;
                    if (ScriptManager.GetCurrent(p) != null)
                        ScriptManager.RegisterStartupScript(p, typeof(Page), "Message", script, true);
                    else
                        p.ClientScript.RegisterStartupScript(typeof(Page), "Message", script, true);
                }

            }
        }
        public static DateTime DateTime_ISD()
        {
            TimeZoneInfo India_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime dateTime_Indian = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);

            return dateTime_Indian;
        }
    }
    public class HospiceSession : IDisposable
    {
        //private DateTime _currentdt = DateTime.Now;
        private DateTime _currentdt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")); //for converting to IST
        public DateTime CurrentDT { get { return _currentdt; } private set { _currentdt = value; } }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }

    public static class HospiceSetting
    {
        public enum Days
        {
            DAILY,
            MONDAY,
            TUESDAY,
            WEDNESDAY,
            THURSDAY,
            FRIDAY,
            SATURDAY,
            SUNDAY
        }
        public static string empphoto = ConfigurationManager.AppSettings["empphoto"];
        public static string memberphoto = ConfigurationManager.AppSettings["memberphoto"];
        public static DateTime todaydt = DateTime.Now;
        public static string catcherror = "-1234";

    }

    
}
