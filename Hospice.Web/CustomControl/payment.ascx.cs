using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Hospice.DAL;
using Hospice.Helper;
using Hospice.Web.App_Code;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;



namespace Hospice.Web.CustomControl
{
    public partial class payment : System.Web.UI.UserControl
    {

        public static string cnst;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fillpatientdetail();
            }
           
        }
        private void fillpatientdetail()
        {
            using (Dpatient dpatient = new Dpatient())
            {
                var plist = dpatient.GetPatietMasterList(Convert.ToInt16(Session["CurrentBranch"]));

                ddlpatient.DataSource = plist;
                ddlpatient.DataTextField = "Patient_Name";
                ddlpatient.DataValueField = "PatientId";
                ddlpatient.DataBind();
                ddlpatient.Items.Insert(0, new ListItem("Select", ""));
            }
        }

        protected void ddlpatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlpatient.SelectedIndex > 0)
            {
                bindgrdpaidbills();
            }
        }

        public void bindgrdpaidbills()
        {
            int pid = int.Parse(ddlpatient.SelectedValue);
            int brid = 0;
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                brid = Convert.ToInt16(Session["CurrentBranch"]);
                DataSet ds = spfetchpaidbills(pid, brid);
                DataTable dt = ds.Tables[0];

                DataTable dtn = new DataTable();
                dtn.Columns.Add("date", typeof(string));
                dtn.Columns.Add("billid", typeof(string));
                dtn.Columns.Add("type", typeof(string));
                dtn.Columns.Add("amount", typeof(string));
               
                dtn.Columns.Add("paymentmode", typeof(string));
                dtn.Columns.Add("category", typeof(string));
                dtn.Columns.Add("amountitem", typeof(string));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dtn.NewRow();
                    dr[0] = dt.Rows[i][5];
                    dr[1] = dt.Rows[i][3];
                    dr[2] = "Payment";
                    dr[3] = dt.Rows[i][4];
                    dr[4] = dt.Rows[i][0];
                    dr[5] = "consultation";
                    dr[6] = dt.Rows[i][4];
                    dtn.Rows.Add(dr);


                }
                grdpaidbills.DataSource = dtn;
                grdpaidbills.DataBind();
            }
        }

        public DataSet spfetchpaidbills(int patientid, int branchid)
        {
           
            DataSet ds = new DataSet();
            cnst = ConfigurationManager.ConnectionStrings["con"].ToString();
            SqlConnection scn = new SqlConnection(cnst);
            SqlCommand scmd = new SqlCommand("sp_GetPaidBillsDetails", scn);
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.Parameters.AddWithValue("@patientid", patientid);
            scmd.Parameters.AddWithValue("@branchid", branchid);
            SqlDataAdapter ad = new SqlDataAdapter(scmd);
            ad.Fill(ds);
            return ds;
        }
        protected void grdpaidbills_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {


                int pid = int.Parse(ddlpatient.SelectedValue);


                int rw = Convert.ToInt32(e.CommandArgument);
                    int _count = grdpaidbills.Rows.Count;

                    string _Amount = e.CommandName;

                    
                    
                    
                string _Date = (grdpaidbills.Rows[rw].FindControl("lbldate") as Label).Text;
                int _Billid = Convert.ToInt32((grdpaidbills.Rows[rw].FindControl("lblbillid") as Label).Text);
                string _Type = (grdpaidbills.Rows[rw].FindControl("lbltype") as Label).Text;
                string _Paymentmode = (grdpaidbills.Rows[rw].FindControl("lblpaymentmode") as Label).Text;
                string _Category = (grdpaidbills.Rows[rw].FindControl("lblcategory") as Label).Text;

                


                txtgrossamount.Text = _Amount;

                using (DrPointsDataContext _mydatacontext = new DrPointsDataContext())
                {
                    //tblPatientMaster _tblpaymentmaster = _mydatacontext.tblPaymentMasters.Where(x => x.BillId == _Billid).FirstOrDefault();
                    tblPaymentMaster _tblPaymentMaster = _mydatacontext.tblPaymentMasters.Where(x => x.BillId == _Billid && x.PatientId == pid ).FirstOrDefault();
                    tblBillMaster _tblbillmaster=_mydatacontext.tblBillMasters.Where(x => x.BillId == _Billid && x.PatientId == pid ).FirstOrDefault();
                    
                        txtdiscount.Text = _tblbillmaster.TotalDiscount.ToString();
                    
                    
                    txttaxamount.Text = _tblbillmaster.TotalTax.ToString();
                    txtNetamount.Text = _tblbillmaster.TotalNetAmount.ToString();
                    string _paymentid = _tblPaymentMaster.PaymentId.ToString();
                    int _paymntid = Convert.ToInt32(_paymentid);
                    //tblPaymentDetail _tblpaymentdetails = _mydatacontext.tblPaymentDetails.Where(x => x.PaymentId == _paymntid).OrderByDescending(x => x.PaymentDetailId).FirstOrDefault();
                    txtcollectedamount.Text = _tblPaymentMaster.BillAmount.ToString();
                    txtbalanceamount.Text = _tblPaymentMaster.BalanceAmount.ToString();
                    txtnetpaidamount.Text = _tblPaymentMaster.BillAmount.ToString();

                }

                
                
            }
            catch(Exception ex)
            {
                HospiceHelper.SendAlert("SSException: \n" + ex.Message);
            }
        }

       
    }


}