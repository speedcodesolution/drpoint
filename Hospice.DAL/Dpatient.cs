using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Hospice.DAL
{
    public class Dpatient : IDisposable
    {
        public tblPatientMaster gtblpatientmaster= new tblPatientMaster();

        public List<sp_GetPatientDetailListResult> GetPatietMasterList(int brainchid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.sp_GetPatientDetailList(brainchid).ToList();
            }
        }
        public IList<tblBloodGroupMaster> GetBloodGroupList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblBloodGroupMasters.ToList();
            }
        }
        public IList<tblPrefixMaster> GetPrefixList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblPrefixMasters.ToList();
            }
        }

        public tblPatientMaster GetPatietMasterById(int _patientid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblPatientMasters.Where(x => x.PatientId == _patientid).SingleOrDefault();
            }
        }


        public int InsertPatientMaster(tblPatientMaster _objpatientmaster)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeset = null;
                int changecount = 0;
                tblPatientMaster _objpmasterchk = mydatacontext.tblPatientMasters.Where(x => x.Name.ToUpper() == _objpatientmaster.Name.ToUpper()).FirstOrDefault();
                if (_objpmasterchk != null)
                {
                    changecount = -1;
                }
                //check for Login name already exist
                else
                {
                    mydatacontext.DeferredLoadingEnabled = false;
                    mydatacontext.ExecuteCommand("Set IDENTITY_INSERT  tblPatientMaster ON");
                    mydatacontext.tblPatientMasters.InsertOnSubmit(_objpatientmaster);
                    changeset = mydatacontext.GetChangeSet();
                    changecount = changeset.Inserts.Count;
                    mydatacontext.SubmitChanges();
                    mydatacontext.ExecuteCommand("SET IDENTITY_INSERT tblPatientMaster OFF");
                }
                return changecount;

            }
            

        }
        /// <summary>
        /// Method for Update the patient master data.
        /// </summary>
        /// <param name="tblPatientMaster"></param>         
        /// 1 for data has been updated</returns>
        public int UpdatePatientMaster(tblPatientMaster tblPatientMaster)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                mydatacontext.DeferredLoadingEnabled = false;

                tblPatientMaster _objpmasterchk = mydatacontext.tblPatientMasters.Where(x => x.PatientId != tblPatientMaster.PatientId && x.Mobile1 == tblPatientMaster.Mobile1).FirstOrDefault();
                if (_objpmasterchk != null) { changeCount = -1; }//check for Recommendation already exist
                else
                {
                    _objpmasterchk = mydatacontext.tblPatientMasters.Where(x => x.PatientId == tblPatientMaster.PatientId && x.Mobile1 == tblPatientMaster.Mobile1).FirstOrDefault();

                    _objpmasterchk.PrefixId = tblPatientMaster.PrefixId;
                    _objpmasterchk.Name= tblPatientMaster.Name ;
                    _objpmasterchk.GenderId = tblPatientMaster.GenderId;
                    _objpmasterchk.DateOfBirth = tblPatientMaster.DateOfBirth;
                    _objpmasterchk.Age = tblPatientMaster.Age;
                    _objpmasterchk.Mobile1 = tblPatientMaster.Mobile1;
                    _objpmasterchk.Mobile2 = tblPatientMaster.Mobile2;
                    _objpmasterchk.BlodGroupId = tblPatientMaster.BlodGroupId;
                    _objpmasterchk.Email = tblPatientMaster.Email;
                    _objpmasterchk.Address = tblPatientMaster.Address;
                    _objpmasterchk.Area = tblPatientMaster.Area;
                    _objpmasterchk.CityId = tblPatientMaster.CityId;
                    _objpmasterchk.Pin = tblPatientMaster.Pin;
                    _objpmasterchk.RefferredBy = tblPatientMaster.RefferredBy;
                    _objpmasterchk.CareOf = tblPatientMaster.CareOf;
                    _objpmasterchk.Occupation = tblPatientMaster.Occupation;
                    _objpmasterchk.Tag = tblPatientMaster.Tag;
                    _objpmasterchk.BranchId = tblPatientMaster.BranchId;
                    _objpmasterchk.Status = tblPatientMaster.Status;

                    _objpmasterchk.UpdatedBy = tblPatientMaster.UpdatedBy;
                    _objpmasterchk.UpdatedOn = tblPatientMaster.UpdatedOn;

                    changeSet = mydatacontext.GetChangeSet();
                    changeCount = changeSet.Updates.Count;
                    mydatacontext.SubmitChanges();
                }
                return changeCount;

            }


        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
