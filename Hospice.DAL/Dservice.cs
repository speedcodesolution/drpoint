using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Hospice.DAL
{
    public class Dservice:IDisposable
    {
        public tblService objTblService = new tblService();
        public tblEmployeeMaster ObjdDoctor = new tblEmployeeMaster();
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public List<tblService> GetServiceMasterList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {

                return mydatacontext.tblServices.Where(x => x.ServiceType == 1).ToList();
            }
        }
        public List<tblService> GetOtherServiceMasterList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {

                return mydatacontext.tblServices.Where(x=>x.ServiceType==0).ToList();
            }
        }
        public tblService GetServicebymasterid(int _servicemasterID)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblServices.Where(x => x.Serviceid == _servicemasterID).SingleOrDefault();
            }
        }

        public List<tblEmployeeMaster> GetdoctorList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblEmployeeMasters.Where(x=>x.EmpType==1).ToList();
            }
        }

        /// <summary>
        /// Method for Insert the data.
        /// </summary>
        /// <param name="_objexecmaster"></param>

        public int InsertService(tblService _objservice)
        {

            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                tblService _objservices = mydatacontext.tblServices.Where(x => x.SericeCode.ToUpper() == _objservice.SericeCode.ToUpper()).FirstOrDefault();
                if (_objservices != null) { changeCount = -1; }//check for brand name already exist
                else
                {
                    mydatacontext.DeferredLoadingEnabled = false;

                    mydatacontext.ExecuteCommand("SET IDENTITY_INSERT tblService ON");
                    mydatacontext.tblServices.InsertOnSubmit(_objservice);
                    changeSet = mydatacontext.GetChangeSet();
                    changeCount = changeSet.Inserts.Count;
                    mydatacontext.SubmitChanges();
                    mydatacontext.ExecuteCommand("SET IDENTITY_INSERT tblService OFF");
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
        public int UpdateService(tblService _objsermaster)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                mydatacontext.DeferredLoadingEnabled = false;

                tblService _objtservmasterchk = mydatacontext.tblServices.Where(x => x.Serviceid != _objsermaster.Serviceid && x.SericeCode == _objsermaster.SericeCode).FirstOrDefault();
                if (_objtservmasterchk != null) { changeCount = -1; }//check for Recommendation already exist
                else
                {
                    _objtservmasterchk = mydatacontext.tblServices.Where(x => x.Serviceid == _objsermaster.Serviceid && x.SericeCode == _objsermaster.SericeCode).FirstOrDefault();
                    _objtservmasterchk.SericeCode = _objsermaster.SericeCode;
                    _objtservmasterchk.ServiceName = _objsermaster.ServiceName;
                    _objtservmasterchk.Servicetax = Convert.ToDecimal(_objsermaster.ServiceName);
                    _objtservmasterchk.ServiceColor = _objsermaster.ServiceColor;
                    _objtservmasterchk.Serviceownerid = _objsermaster.Serviceownerid;
                    _objtservmasterchk.Status = _objsermaster.Status;
                    _objtservmasterchk.UpdatedBy = _objsermaster.UpdatedBy;
                    _objtservmasterchk.UpdatedOn = _objsermaster.UpdatedOn;
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
        public int DeleteService(int _serviceid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                mydatacontext.DeferredLoadingEnabled = false;
                tblService _objservmaster = mydatacontext.tblServices.Where(x => x.Serviceid == _serviceid).SingleOrDefault();
                if (_objservmaster == null) return changeCount;
                mydatacontext.tblServices.DeleteOnSubmit(_objservmaster);
                changeSet = mydatacontext.GetChangeSet();
                changeCount = changeSet.Deletes.Count;
                mydatacontext.SubmitChanges();
                return changeCount;
            }

        }
    }
}
