using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using Hospice.DAL;
using Hospice.Helper;

namespace Hospice.Web.Admin
{
    public partial class PrintBill : System.Web.UI.Page
    {
        int patientid = 0;int branchid =0;
        int serviceid = 0;DateTime bidt =Convert.ToDateTime("2021-05-23");
        protected void Page_Load(object sender, EventArgs e)
        {
             branchid = Convert.ToInt16(HttpContext.Current.Session["CurrentBranch"]);
            if(Request.QueryString["ptid"]!=null)
            {
                patientid = Convert.ToInt16(Request.QueryString["ptid"]);
                serviceid = Convert.ToInt16(Request.QueryString["srv"]);
                bidt = Convert.ToDateTime(Request.QueryString["apptdt"]);
            }
            if (!IsPostBack)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/RDLC/Bill.rdlc");
                DataTable dtbilldetail = null;
                ReportDataSource datasource = null;
                using (Dpatient dpatient = new Dpatient())
                {
                     dtbilldetail = dpatient.GetPatietMasterList(branchid).Where(x=>x.PatientId==patientid).ConvertIEnumerableToDataTable();
                     datasource = new ReportDataSource("rdsPatientDetail", dtbilldetail);
                    //ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                }
                using (DInvoice dInvoice = new DInvoice())
                {
                    dtbilldetail = dInvoice.GetBillDetailByIds(patientid, serviceid, bidt, branchid).ConvertIEnumerableToDataTable();
                    datasource = new ReportDataSource("rdsBillDetail", dtbilldetail);
                    //ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                }
            }
        }
    }
}