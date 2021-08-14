using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Hospice.DAL
{
    public class Dpaymentmode : IDisposable
    {
        public tblPaymentMode objtblpaymode = new tblPaymentMode();

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public List<tblPaymentMode> GetPaymentModeMasterList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {

                return mydatacontext.tblPaymentModes.ToList();
            }
        }

        public tblPaymentMode GetPaymentModebymasterid(int _PaymentModeId)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblPaymentModes.Where(x => x.PaymentModeId == _PaymentModeId).SingleOrDefault();
            }
        }

        /// <summary>
        /// Method for Insert the data.
        /// </summary>
        /// <param name="_objexecmaster"></param>

        public int InsertPaymentMode(tblPaymentMode _objPaymentMode)
        {

            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                tblPaymentMode _objPaymentModes = mydatacontext.tblPaymentModes.Where(x => x.PaymentModeCode.ToUpper() == _objPaymentMode.PaymentModeCode.ToUpper()).FirstOrDefault();
                if (_objPaymentModes != null) { changeCount = -1; }//check for brand name already exist
                else
                {
                    mydatacontext.DeferredLoadingEnabled = false;

                    mydatacontext.ExecuteCommand("SET IDENTITY_INSERT tblPaymentMode ON");
                    mydatacontext.tblPaymentModes.InsertOnSubmit(_objPaymentMode);
                    changeSet = mydatacontext.GetChangeSet();
                    changeCount = changeSet.Inserts.Count;
                    mydatacontext.SubmitChanges();
                    mydatacontext.ExecuteCommand("SET IDENTITY_INSERT tblPaymentMode OFF");
                }

                //if (changeCount > 0) return 1; else return 0;
                return changeCount;
            }
        }

        /// <summary>
        /// Method for Update the data.
        /// </summary>
        /// <param name="_objtexeccmaster"></param>         
        /// 1 for data has been updated</returns>
        public int UpdatePaymentMode(tblPaymentMode _objsermaster)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                mydatacontext.DeferredLoadingEnabled = false;

                tblPaymentMode _objtpaymasterchk = mydatacontext.tblPaymentModes.Where(x => x.PaymentModeId != _objsermaster.PaymentModeId && x.PaymentModeCode == _objsermaster.PaymentModeCode).FirstOrDefault();
                if (_objtpaymasterchk != null) { changeCount = -1; }//check for Recommendation already exist
                else
                {
                    _objtpaymasterchk = mydatacontext.tblPaymentModes.Where(x => x.PaymentModeId == _objsermaster.PaymentModeId && x.PaymentModeCode == _objsermaster.PaymentModeCode).FirstOrDefault();
                    _objtpaymasterchk.PaymentModeCode = _objsermaster.PaymentModeCode;
                    _objtpaymasterchk.PaymentMode = _objsermaster.PaymentMode;
                    _objtpaymasterchk.Status = _objsermaster.Status;
                    _objtpaymasterchk.UpdatedBy = _objsermaster.UpdatedBy;
                    _objtpaymasterchk.UpdatedOn = _objsermaster.UpdatedOn;
                    changeSet = mydatacontext.GetChangeSet();
                    changeCount = changeSet.Updates.Count;
                    mydatacontext.SubmitChanges();
                }
                return changeCount;

            }
        }

        /// <summary>
        /// Method for Delete the data
        /// </summary>
        /// <returns>-1 for Exercise Code is already used in other table so data do not delete.
        /// 0 for data do not delete . 
        /// 1 for data has been deleted</returns>
        public int DeletePaymentMode(int _PaymentModeid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                mydatacontext.DeferredLoadingEnabled = false;
                tblPaymentMode _objservmaster = mydatacontext.tblPaymentModes.Where(x => x.PaymentModeId == _PaymentModeid).SingleOrDefault();
                if (_objservmaster == null) return changeCount;
                mydatacontext.tblPaymentModes.DeleteOnSubmit(_objservmaster);
                changeSet = mydatacontext.GetChangeSet();
                changeCount = changeSet.Deletes.Count;
                mydatacontext.SubmitChanges();
                return changeCount;
            }

        }
    }
}
