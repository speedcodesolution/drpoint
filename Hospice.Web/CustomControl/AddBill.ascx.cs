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
    public partial class AddBill : System.Web.UI.UserControl
    {
        public static string cnst = "";
        public int branchid=Convert.ToInt16(HttpContext.Current.Session["CurrentBranch"]);

        public int Serviceid
        {
            get
            {
                
                return int.Parse(ViewState["serviceid"].ToString());
            }
            set
            {
                ViewState["serviceid"] = value;
            }
        }
        public DataTable dtAddBill
        {
            get
            {
                if (Session["dtaddbill"] == null)
                {
                    int pid = int.Parse(ddlpatient.SelectedValue);
                    int brid = 0;
                    brid = branchid;
                    using (DInvoice dInvoice = new DInvoice())
                    {
                        DataSet ds = dInvoice.Spfetch(brid, pid);
                        DataTable dt = ds.Tables[0];
                        DataTable CurrentDt = new DataTable();
                        CurrentDt.Columns.Add("billid", typeof(Int32));
                        CurrentDt.Columns.Add("ServiceName", typeof(string));
                        CurrentDt.Columns.Add("UnitPrice", typeof(Int32));
                        CurrentDt.Columns.Add("Discount", typeof(Int32));
                        CurrentDt.Columns.Add("PatinetId", typeof(Int32));
                        CurrentDt.Columns.Add("ServiceId", typeof(Int32));
                        CurrentDt.Columns.Add("mode", typeof(Int32));
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow dr = CurrentDt.NewRow();


                            dr[0] = dt.Rows[i][1];
                            dr[1] = dt.Rows[i][0];
                            dr[2] = dt.Rows[i][6];
                            dr[3] = dt.Rows[i][4];
                            dr[4] = dt.Rows[i][2];
                            dr[5] = dt.Rows[i][13];

                            CurrentDt.Rows.Add(dr);
                        }

                        Session["dtaddbill"] = CurrentDt;
                    }
                }
                return (DataTable)Session["dtaddbill"];

            }
            set
            {
                Session["dtaddbill"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fillpatientdetail();
                fillddlservicename();
                fillddlpaymentmode();
            }
        }

        //public int spinsert(int patientid, int discount, int branchid, int createdby, DateTime createdon, int serviceid, int doctorid, DateTime appttime, int durationmin, int apptstatus)
        //{
        //    int result = 0;
        //    cnst = ConfigurationManager.ConnectionStrings["con"].ToString();
        //    SqlConnection scn = new SqlConnection(cnst);
        //    SqlCommand scmd = new SqlCommand("dbo.sp_InsertBilldetails", scn);
        //    scmd.CommandType = CommandType.StoredProcedure;
        //    scmd.Parameters.AddWithValue("@PatientID", patientid);
        //    scmd.Parameters.AddWithValue("@TotalDiscount", discount);
        //    scmd.Parameters.AddWithValue("@BranchId", branchid);
        //    scmd.Parameters.AddWithValue("@CreatedBy", createdby);
        //    scmd.Parameters.AddWithValue("@CreatedOn", createdon);

        //    scmd.Parameters.AddWithValue("@ServiceId", serviceid);
        //    scmd.Parameters.AddWithValue("@DoctorId", doctorid);
        //    scmd.Parameters.AddWithValue("@ApptTime", appttime);
        //    scmd.Parameters.AddWithValue("@Duration_Min", durationmin);
        //    scmd.Parameters.AddWithValue("@ApptStatus", apptstatus);
        //    scn.Open();
        //    result = scmd.ExecuteNonQuery();
        //    scn.Close();
        //    return result;
        //}
        private void fillddlpaymentmode()
        {
            using (Dpaymentmode dpaymentmode = new Dpaymentmode())
            {
                var pmlist = dpaymentmode.GetPaymentModeMasterList();

                ddlpaymentmode.DataSource = pmlist;
                ddlpaymentmode.DataTextField = "PaymentMode";
                ddlpaymentmode.DataValueField = "PaymentModeId";
                ddlpaymentmode.DataBind();
                ddlpaymentmode.Items.Insert(0, new ListItem("Select", ""));
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
                ddlpatient.Items.Insert(0, new ListItem("Select Patient", ""));
            }
        }
        private void fillddlservicename()
        {
            using (Dservice dservice = new Dservice())
            {
                var list = dservice.GetServiceMasterList();
                ddlservicename.DataSource = list;
                ddlservicename.DataTextField = "ServiceName";
                ddlservicename.DataValueField = "Serviceid";
                ddlservicename.DataBind();
                ddlservicename.Items.Insert(0, new ListItem("Select Service", ""));
            }
        }
        public DataTable GetTableWithInitialData() // this might be your sp for select
        {
            DataTable dt = GetTableWithNoData();
            DataRow dr;

            int price = 0;
            int discount = 0;

            if (String.IsNullOrEmpty(txtdiscount.Text))
            {
                discount = 0;
            }
            else
            {
                discount = int.Parse(txtdiscount.Text);
            }
            if (String.IsNullOrEmpty(txtprice.Text))
            {
                price = 0;
            }
            else
            {
                price = int.Parse(txtprice.Text);
            }

            foreach (GridViewRow gvr in grdaddbill.Rows)
            {
                dr = dt.NewRow();

                dr[0] = gvr.Cells[1].Text;
                dr[1] = gvr.Cells[2].Text;
                dr[2] = gvr.Cells[3].Text;

                dt.Rows.Add(dr); // add grid values in to row and add row to the blank table
            }

            return dt;
        }
        protected void AddNewRowToGrid()
        {
            DataTable dt = GetTableWithInitialData(); // get select column header only records not required
            DataRow dr;


            dr = dt.NewRow(); // add last empty row
            dr[0] = ddlservicename.SelectedItem.Text;


            if (String.IsNullOrEmpty(txtprice.Text))
            {
                dr[1] = 0;
            }
            else
            {
                dr[1] = int.Parse(txtprice.Text);
            }

            if (String.IsNullOrEmpty(txtdiscount.Text))
            {
                dr[2] = 0;
            }
            else
            {
                dr[2] = int.Parse(txtdiscount.Text);
            }


            dt.Rows.Add(dr);

            grdaddbill.DataSource = dt; // bind new datatable to grid
            grdaddbill.DataBind();
        }
        public DataTable GetTableWithNoData() // returns only structure if the select columns
        {
            DataTable table = new DataTable();

            table.Columns.Add("Service Name", typeof(string));
            table.Columns.Add("Unit Price", typeof(string));
            table.Columns.Add("Discount", typeof(string));
            return table;
        }
        protected void btnaddbill_Click(object sender, EventArgs e)
        {
            //AddNewRowToGrid();
            int tbillid = -1;
            DataRow drCurrentRow = dtAddBill.NewRow();
            if (dtAddBill.Rows.Count >= 0)
            {
                int minbillid = Convert.ToInt32(dtAddBill.Compute("min([BillId])", string.Empty));
                int maxbillid = Convert.ToInt32(dtAddBill.Compute("max([BillId])", string.Empty));
                if (minbillid<0)
                    tbillid = -minbillid-1;
                else
                    tbillid = maxbillid;
            }
            drCurrentRow["billid"] = tbillid;
            drCurrentRow["ServiceName"] = ddlservicename.SelectedItem.Text.Trim();
            drCurrentRow["UnitPrice"] = int.Parse(txtprice.Text);
            drCurrentRow["Discount"] = int.Parse(txtdiscount.Text);
            drCurrentRow["PatinetId"] = int.Parse(ddlpatient.SelectedValue);
            drCurrentRow["ServiceId"] = int.Parse(ddlservicename.SelectedValue);
            if (dtAddBill.Rows.Count == 0)
                drCurrentRow["mode"] = -1;
            else
                drCurrentRow["mode"] = -dtAddBill.Rows.Count - 1;


            dtAddBill.Rows.Add(drCurrentRow);


            //using (DrPointsDataContext _mydatacontext = new DrPointsDataContext())
            //{

            //    int _patientid = int.Parse(ddlpatient.SelectedValue);
            //    int _serviceid = int.Parse(ddlservicename.SelectedValue);



            //    tblPatientMaster _tblPatientMaster = _mydatacontext.tblPatientMasters.Where(x => x.PatientId == _patientid).FirstOrDefault();
            //    int _branchid = Convert.ToInt16(Session["CurrentBranch"]); //int.Parse(_tblPatientMaster.BranchId.ToString());

            //    int _discount = int.Parse(txtdiscount.Text);
            //    int _doctorid = 1;
            //    int _apptstatus = 3;
            //    int _durationmin = 10;
            //    DateTime _appttime = DateTime.Now;
            //    int _createdby = 0;


            //    using (HospiceSession objmysession = new HospiceSession())
            //    {
            //        using (BasePage mpg = new BasePage())
            //        {

            //            _createdby = Convert.ToInt32(mpg.LogedinUID);
            //            DateTime _createdon = objmysession.CurrentDT;
            //            //addbill(_patientid,_discount,_branchid,_createdby,_createdon,_serviceid,_doctorid,_appttime,_durationmin,_apptstatus);
            //            using (DInvoice dInvoice = new DInvoice())
            //            {
            //                dInvoice.spinsert(_patientid, _discount, _branchid, _createdby, _createdon, _serviceid, _doctorid, _appttime, _durationmin, _apptstatus);
            //            }

            //        }
            //    }



                BindgvAddbill();
            //}

            ddlservicename.SelectedValue = "";
            txtprice.Text = "";
            txtbalance.Text = "";

        }
        protected void ddlpatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlpatient.SelectedIndex > 0)
            {
                Session["dtaddbill"] = null;
                BindgvAddbill();
            }
        }
        protected void ddlpaymentmode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void BindgvAddbill()
        {
            //int pid = int.Parse(ddlpatient.SelectedValue);
            //int brid = 0;
            //brid = Convert.ToInt16(Session["CurrentBranch"]);
            //using (DInvoice dInvoice = new DInvoice())
            //{
            //    DataSet ds = dInvoice.Spfetch(brid, pid);
            //    DataTable dt = ds.Tables[0];
            //    DataTable dtn = new DataTable();
            //    dtn.Columns.Add("billid", typeof(Int32));
            //    dtn.Columns.Add("ServiceName", typeof(string));
            //    dtn.Columns.Add("UnitPrice", typeof(Int32));
            //    dtn.Columns.Add("Discount", typeof(Int32));
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        DataRow dr = dtn.NewRow();


            //        dr[0] = dt.Rows[i][1];
            //        dr[1] = dt.Rows[i][0];
            //        dr[2] = dt.Rows[i][6];
            //        dr[3] = dt.Rows[i][4];


            //        dtn.Rows.Add(dr);
            //    }


                grdaddbill.DataSource = dtAddBill; // bind new datatable to grid
                grdaddbill.DataBind();
            //}
        }
        protected void ddlservicename_SelectedIndexChanged(object sender, EventArgs e)
        {
            int amount = 0;

            int sid = int.Parse(ddlservicename.SelectedValue);
            using (Dservice dservice = new Dservice())
            {
                var _tblservice = dservice.GetServiceMasterList().Where(x => x.Serviceid == sid).FirstOrDefault();

                if (string.IsNullOrEmpty(_tblservice.TotalAmount.ToString()))
                {
                    amount = 0;
                }
                else
                {
                    amount = int.Parse(_tblservice.TotalAmount.ToString());
                }
                txtprice.Text = Convert.ToString(amount);
                txtdiscount.Text = Convert.ToString(0);
            }
        }
        protected void btnpay_Click(object sender, EventArgs e)
        {
            if (txtbalance.Text == "")
            {
                HospiceHelper.SendAlert("SsMessage:\n Balance amount not empty.");
                txtbalance.Focus();
                return;
            }
            insertpaymentmaster();
        }
        public int insertpaymentmaster()
        {
            ChangeSet changeSet = null;
            int changeCount = 0;

            decimal _balamttxt = Convert.ToDecimal(txtbalance.Text);
            decimal _balamtlbl = Convert.ToDecimal(lblbalamnt.Text);
            int _billid = Convert.ToInt32(lblbillid.Text);
            

            if (_balamttxt > _balamtlbl)
            {

                HospiceHelper.SendAlert("SsMessage:\n Amount Should be less than " + _balamtlbl);
            }
            else
            {
                if (ddlpaymentmode.SelectedValue == "")
                {

                    HospiceHelper.SendAlert("SsMessage:\n Please Select Payment mode");
                }
                else
                {

                    int result = 0;
                    int pid = int.Parse(ddlpatient.SelectedValue);
                    if (pid > 0)
                    {
                        using (DrPointsDataContext _mydatacontext = new DrPointsDataContext())
                        {
                            tblPatientMaster _tblPatientMaster = _mydatacontext.tblPatientMasters.Where(x => x.PatientId == pid).FirstOrDefault();
                            tblPaymentMaster _tblpaymentMaster = _mydatacontext.tblPaymentMasters.Where(x => x.BillId == _billid).FirstOrDefault();

                            decimal consultation = Convert.ToDecimal(lblServiceAmt.Text);
                            decimal balance = Convert.ToDecimal(txtbalance.Text);

                            if (_balamtlbl == balance)
                            {
                                _tblpaymentMaster.BalanceAmount = 0;
                                _tblpaymentMaster.PaymentStatus = "PAID";
                            }
                            else
                            {
                                _tblpaymentMaster.BalanceAmount = _balamtlbl - balance;
                                _tblpaymentMaster.PaymentStatus = "PARTIALLY PAID";
                            }

                            using (HospiceSession objmysession = new HospiceSession())
                            {
                                using (BasePage mpg = new BasePage())
                                {
                                    _tblpaymentMaster.UpdatedBy = Convert.ToInt32(mpg.LogedinUID);
                                    _tblpaymentMaster.UpdatedOn = objmysession.CurrentDT;
                                    _tblpaymentMaster.lastPaymentDt = objmysession.CurrentDT;
                                    changeSet = _mydatacontext.GetChangeSet();
                                    changeCount = changeSet.Updates.Count;
                                    _mydatacontext.SubmitChanges();

                                }
                            }



                            int _paymentid = _tblpaymentMaster.PaymentId;


                            tblPaymentDetail _tblpaymentdetails = new tblPaymentDetail();// _mydatacontext.tblPaymentDetails.FirstOrDefault();

                            _tblpaymentdetails.PaymentId = _paymentid;
                            _tblpaymentdetails.PaymentMode = ddlpaymentmode.SelectedValue;
                            _tblpaymentdetails.RecivedAmount = _balamttxt;
                            _tblpaymentdetails.DueAmount = _balamtlbl - balance;
                            _tblpaymentdetails.BranchId = branchid;// _tblpaymentMaster.BranchId;


                            using (HospiceSession objmysession = new HospiceSession())
                            {
                                using (BasePage mpg = new BasePage())
                                {
                                    _tblpaymentdetails.CreatedBy = Convert.ToInt32(mpg.LogedinUID);
                                    _tblpaymentdetails.PaymentDt = objmysession.CurrentDT;
                                    _tblpaymentdetails.CreatedOn = objmysession.CurrentDT;
                                    insertpaymentdetails(_tblpaymentdetails);

                                }
                            }


                        }

                    }
                }
            }
            return changeCount;
        }
        public int insertpaymentdetails(tblPaymentDetail tblPaymentDetail)
        {
            using (DrPointsDataContext _mydatacontext = new DrPointsDataContext())
            {
                int changepdcount = 0;
                _mydatacontext.DeferredLoadingEnabled = false;
                _mydatacontext.tblPaymentDetails.InsertOnSubmit(tblPaymentDetail);
                _mydatacontext.SubmitChanges();
                txtbalance.Text = "";
                lblServiceAmt.Text = "";
                ddlpaymentmode.SelectedValue = "";

                HospiceHelper.SendAlert("SsMessage:\n Payment done successfully");
                return changepdcount;
            }
        }
        protected void grdaddbill_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "btnAddtoBill")
                {
                    int rw = Convert.ToInt32(e.CommandArgument);
                    int _countrw = grdaddbill.Rows.Count;
                    string _mode = ((HiddenField)grdaddbill.Rows[rw].FindControl("hfmode") as HiddenField).Value;
                    string balance = grdaddbill.Rows[rw].Cells[2].Text;
                    string _servicename = grdaddbill.Rows[rw].Cells[1].Text;
                    int _billid = Convert.ToInt32(((HiddenField) grdaddbill.Rows[rw].FindControl("hfBillid") as HiddenField).Value);
                    int _patientid = Convert.ToInt32(((HiddenField)grdaddbill.Rows[rw].FindControl("hfpatientid") as HiddenField).Value);//Convert.ToInt32(ddlpatient.SelectedValue);
                    Serviceid = Convert.ToInt32(((HiddenField)grdaddbill.Rows[rw].FindControl("hfserviceid") as HiddenField).Value);
                    for (int i = 0; i < _countrw; i++)
                    {
                        if (i == rw)
                        {
                            grdaddbill.Rows[i].BackColor = ColorTranslator.FromHtml("#c4e2ff");
                        }
                        else
                        {
                            grdaddbill.Rows[i].BackColor = Color.Transparent;
                        }
                    }
                    if (_mode.ToString()=="")
                    {
                        using (DrPointsDataContext _mydatacontext = new DrPointsDataContext())
                        {
                            tblPaymentMaster _tblPaymentMaster = _mydatacontext.tblPaymentMasters.Where(x => x.BillId == _billid && x.PatientId == _patientid && x.PaymentStatus != "PAID").OrderByDescending(x => x.BalanceAmount).FirstOrDefault();

                            txtbalance.Text = _tblPaymentMaster.BalanceAmount.ToString();
                            lblbalamnt.Text = _tblPaymentMaster.BalanceAmount.ToString();
                            lblbillid.Text = _billid.ToString();
                        }
                        lblServiceName.Text = _servicename.Split('[')[0].ToString().ToUpper().Trim();//grdaddbill.Rows[rw].Cells[1].Text.ToString().Split('[')[0].ToString().ToUpper().Trim();
                        lblServiceAmt.Text = balance;
                        btnpay.Text = "PAY Rs " + txtbalance.Text;
                    }
                    else if (Convert.ToInt16(_mode)<0)
                    {
                        FillddlDoctor(_servicename.Split('[')[0].ToString().ToUpper().Trim());
                        lblServiceName.Text = _servicename.Split('[')[0].ToString().ToUpper().Trim();
                        txtUnitePrice.Text = balance;
                        txtTotalAmt.Text = balance;
                    }
                }

            }
            catch (Exception ex)
            {
                HospiceHelper.SendAlert("SsException:\n" + ex.Message);
            }
        }


        private void FillddlDoctor(string servicename)
        {
            using (Demployee demployee = new Demployee())
            {
                using (Dservice dservice = new Dservice())
                {
                    var servicelist = dservice.GetServiceMasterList().Where(x=>x.ServiceName.ToLower().Contains(servicename.ToLower())).ToList();
                    var doctorlst = (from a in servicelist 
                                     join b in dservice.GetdoctorList()
                                     on a.Serviceownerid equals b.EmpID
                                     select new { doctorid = b.EmpID, doctor = b.EmpCode.ToUpper() + " " + b.EmpName.ToUpper() }
                        );
                    /*var doctorlst = (from a in demployee.GetEmpMasterList()
                                     select new { doctorid = a.EmpID, doctor = a.EmpCode.ToUpper() + " " + a.EmpName.ToUpper() });
                    */
                    ddlDoctor.DataSource = doctorlst;
                    ddlDoctor.DataTextField = "doctor";
                    ddlDoctor.DataValueField = "doctorid";
                    ddlDoctor.DataBind();
                    ddlDoctor.Items.Insert(0, new ListItem("Select", ""));
                }
            }
        }

        private void FillddlAvailabilTime(int _doctorid,int _serviceid, DateTime apptdate)
        {
            using (Dappointment dappointment = new Dappointment())
            {
                //int doctorid = Convert.ToInt16(ddlDoctor.SelectedValue);
                //int serviceid = Convert.ToInt16(ddlService.SelectedValue);
                //int branchid = 1;
                //DateTime apptdate = DateTime.Now;
                var apptstatus = dappointment.GetAvailabilTime(branchid, _doctorid, _serviceid, apptdate).ToList();
                ddlAvailabilTime.DataSource = apptstatus;
                ddlAvailabilTime.DataTextField = "AvailabilTime";
                ddlAvailabilTime.DataValueField = "AvailabilTime";
                ddlAvailabilTime.DataBind();
                ddlAvailabilTime.Items.Insert(0, new ListItem("Select", ""));
            }
        }

        protected void ddlDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDoctor.SelectedIndex > 0 && Serviceid>0)
                FillddlAvailabilTime(Convert.ToInt16(ddlDoctor.SelectedValue), Serviceid, DateTime.Now);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (DrPointsDataContext _mydatacontext = new DrPointsDataContext())
            {

                int _serviceid = -1;int _billid = -1;
                int _patientid = int.Parse(ddlpatient.SelectedValue);
                foreach (GridViewRow row in grdaddbill.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        if (row.BackColor == ColorTranslator.FromHtml("#c4e2ff"))
                        {
                            _serviceid = int.Parse(((HiddenField)row.FindControl("hfserviceid") as HiddenField).Value);
                            _billid = int.Parse(((HiddenField)row.FindControl("hfBillid") as HiddenField).Value);
                            break;
                        }
                    }
                }


                tblPatientMaster _tblPatientMaster = _mydatacontext.tblPatientMasters.Where(x => x.PatientId == _patientid).FirstOrDefault();
                int _branchid = Convert.ToInt16(Session["CurrentBranch"]); //int.Parse(_tblPatientMaster.BranchId.ToString());

                int _discount = int.Parse(txtdiscount.Text);
                int _doctorid = int.Parse(ddlDoctor.SelectedValue);
                int _apptstatus = 3;
                int _durationmin = int.Parse(ddlDuration.SelectedValue);
                string tempapptdate = txtApptDate.Text.Split('-')[2] + "-" + txtApptDate.Text.Split('-')[1] + "-" + txtApptDate.Text.Split('-')[0];
                DateTime _apptdate = Convert.ToDateTime(tempapptdate);
                TimeSpan _appttime = TimeSpan.Parse(ddlAvailabilTime.SelectedValue); 
                int _createdby = 0;


                using (HospiceSession objmysession = new HospiceSession())
                {
                    using (BasePage mpg = new BasePage())
                    {

                        _createdby = Convert.ToInt32(mpg.LogedinUID);
                        DateTime _createdon = objmysession.CurrentDT;
                        //addbill(_patientid,_discount,_branchid,_createdby,_createdon,_serviceid,_doctorid,_appttime,_durationmin,_apptstatus);
                        using (DInvoice dInvoice = new DInvoice())
                        {
                            var result=dInvoice.spinsert(_patientid, _discount, _branchid, _createdby, _apptdate, _serviceid, _billid, _doctorid, _appttime, _durationmin, _apptstatus);
                            if (result > 0)
                            {
                                BindgvAddbill();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#appoinmentdiv').css('display', 'none');", true);
                            }
                        }

                    }
                }

            }
        }

        protected void grdaddbill_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string _mode = ((HiddenField)e.Row.FindControl("hfmode") as HiddenField).Value;
                var status = (Label)e.Row.FindControl("lblStatus");
                if (_mode != "")
                {
                    e.Row.Cells[1].ForeColor = Color.Red; 
                    e.Row.Cells[2].ForeColor = Color.Red;
                    e.Row.Cells[3].ForeColor = Color.Red;
                }
                else
                {
                    e.Row.Cells[1].ForeColor = ColorTranslator.FromHtml("#666666");
                    e.Row.Cells[2].ForeColor = ColorTranslator.FromHtml("#666666");
                    e.Row.Cells[3].ForeColor = ColorTranslator.FromHtml("#666666");
                }

            }
        }
    }
}