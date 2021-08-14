using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data;
using Hospice.Helper;

namespace Hospice.DAL
{
   public class DInvoice : IDisposable
   {
        public tblPaymentMaster TblPaymentMaster = new tblPaymentMaster();
        public tblPaymentDetail TblPaymentDetail = new tblPaymentDetail();


        public List<sp_GetBillDetailResult> GetBillDetailByIds(int patientid, int serviceid, DateTime apptdate, int branchid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.sp_GetBillDetail(patientid, serviceid, apptdate, branchid).ToList();
            }
        }
        public List<sp_GetPaymentDetailListResult> GetPaymentDetailList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.sp_GetPaymentDetailList().ToList();
            }
        }
        public List<sp_GetPaymentDetailListResult> GetPaymentDetailListByPaymntid(int paymntid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.sp_GetPaymentDetailList().Where(x=>x.PaymentId==paymntid).ToList();
            }
        }

        public DataSet Spfetch(int branchid, int patinetid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                DataTable dt = new DataTable();
                dt = mydatacontext.sp_GetBilldetailsforAddBill(branchid, patinetid).ConvertIEnumerableToDataTable();
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                return ds;
            }
        }
        public int spinsert(int patientid, int discount, int branchid, int createdby, DateTime _apptdate, int serviceid, int _billid, int doctorid, TimeSpan appttime, int durationmin, int apptstatus)
        {
            int result = 0;
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                //TimeSpan apttime = appttime.TimeOfDay;
                result = mydatacontext.sp_InsertBilldetails(patientid, discount, branchid, createdby, _apptdate, serviceid,_billid, doctorid, appttime, durationmin,Convert.ToChar(apptstatus.ToString()));
            }
            return result;
        }
        public int SavePayment(tblPaymentMaster paymentMaster)
        {
            int result = 0;
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                mydatacontext.DeferredLoadingEnabled = false;
                mydatacontext.tblPaymentMasters.InsertOnSubmit(paymentMaster);
                changeSet = mydatacontext.GetChangeSet();
                changeCount = changeSet.Inserts.Count;
                mydatacontext.SubmitChanges();
                result = paymentMaster.PaymentId;
            }
            return result;
        }
        
        public int SavePaymentDetail(tblPaymentDetail paymentDetail)
        {
            int result = 0;
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                mydatacontext.DeferredLoadingEnabled = false;
                mydatacontext.tblPaymentDetails.InsertOnSubmit(paymentDetail);
                changeSet = mydatacontext.GetChangeSet();
                changeCount = changeSet.Inserts.Count;
                mydatacontext.SubmitChanges();
                result = paymentDetail.PaymentDetailId;

            }
            return result;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
