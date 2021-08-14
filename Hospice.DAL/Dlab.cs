using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Hospice.DAL
{
    public class Dlab:IDisposable
    {
        public tblLab objtblLab = new tblLab();

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public List<tblLab> GetLabMasterList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {

                return mydatacontext.tblLabs.ToList();
            }
        }

        public tblLab GetLabbymasterid(int _labId)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblLabs.Where(x => x.Labid == _labId).SingleOrDefault();
            }
        }

        /// <summary>
        /// Method for Insert the data.
        /// </summary>
        /// <param name="_objexecmaster"></param>

        public int InsertLab(tblLab _objLab)
        {

            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                tblLab _objLabs = mydatacontext.tblLabs.Where(x => x.LabCode.ToUpper() == _objLab.LabCode.ToUpper()).FirstOrDefault();
                if (_objLabs != null) { changeCount = -1; }//check for brand name already exist
                else
                {
                    mydatacontext.DeferredLoadingEnabled = false;

                    mydatacontext.ExecuteCommand("SET IDENTITY_INSERT tblLab ON");
                    mydatacontext.tblLabs.InsertOnSubmit(_objLab);
                    changeSet = mydatacontext.GetChangeSet();
                    changeCount = changeSet.Inserts.Count;
                    mydatacontext.SubmitChanges();
                    mydatacontext.ExecuteCommand("SET IDENTITY_INSERT tblLab OFF");
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
        public int UpdateLab(tblLab _objsermaster)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                mydatacontext.DeferredLoadingEnabled = false;

                tblLab _objtservmasterchk = mydatacontext.tblLabs.Where(x => x.Labid != _objsermaster.Labid && x.LabCode == _objsermaster.LabCode).FirstOrDefault();
                if (_objtservmasterchk != null) { changeCount = -1; }//check for Recommendation already exist
                else
                {
                    _objtservmasterchk = mydatacontext.tblLabs.Where(x => x.Labid == _objsermaster.Labid && x.LabCode == _objsermaster.LabCode).FirstOrDefault();
                    _objtservmasterchk.LabCode = _objsermaster.LabCode;
                    _objtservmasterchk.LabName = _objsermaster.LabName;
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
        public int DeleteLab(int _Labid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                mydatacontext.DeferredLoadingEnabled = false;
                tblLab _objservmaster = mydatacontext.tblLabs.Where(x => x.Labid == _Labid).SingleOrDefault();
                if (_objservmaster == null) return changeCount;
                mydatacontext.tblLabs.DeleteOnSubmit(_objservmaster);
                changeSet = mydatacontext.GetChangeSet();
                changeCount = changeSet.Deletes.Count;
                mydatacontext.SubmitChanges();
                return changeCount;
            }

        }
    }
}
