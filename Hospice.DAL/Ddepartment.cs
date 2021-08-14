using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Hospice.DAL
{
    public class Ddepartment:IDisposable
    {
        public tblDepartment objtblDepartment = new tblDepartment();

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public List<tblDepartment> GetdepMasterList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {

                return mydatacontext.tblDepartments.ToList();
            }
        }

        public tblDepartment Getdepbymasterid(int _depmasterID)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblDepartments.Where(x => x.Departmentid == _depmasterID).SingleOrDefault();
            }
        }

        /// <summary>
        /// Method for Insert the data.
        /// </summary>
        /// <param name="_objexecmaster"></param>

        public int Insertdep(tblDepartment _objdep)
        {

            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                tblDepartment _objdeps = mydatacontext.tblDepartments.Where(x => x.DepartmentCode.ToUpper() == _objdep.DepartmentCode.ToUpper()).FirstOrDefault();
                if (_objdeps != null) { changeCount = -1; }//check for brand name already exist
                else
                {
                    mydatacontext.DeferredLoadingEnabled = false;

                    mydatacontext.ExecuteCommand("SET IDENTITY_INSERT tblDepartment ON");
                    mydatacontext.tblDepartments.InsertOnSubmit(_objdep);
                    changeSet = mydatacontext.GetChangeSet();
                    changeCount = changeSet.Inserts.Count;
                    mydatacontext.SubmitChanges();
                    mydatacontext.ExecuteCommand("SET IDENTITY_INSERT tblDepartment OFF");
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
        public int Updatedep(tblDepartment _objsermaster)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                mydatacontext.DeferredLoadingEnabled = false;

                tblDepartment _objtservmasterchk = mydatacontext.tblDepartments.Where(x => x.Departmentid != _objsermaster.Departmentid && x.DepartmentCode == _objsermaster.DepartmentCode).FirstOrDefault();
                if (_objtservmasterchk != null) { changeCount = -1; }//check for Recommendation already exist
                else
                {
                    _objtservmasterchk = mydatacontext.tblDepartments.Where(x => x.Departmentid == _objsermaster.Departmentid && x.DepartmentCode == _objsermaster.DepartmentCode).FirstOrDefault();
                    _objtservmasterchk.DepartmentCode = _objsermaster.DepartmentCode;
                    _objtservmasterchk.DepartmentName = _objsermaster.DepartmentName;
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
        public int Deletedep(int _depid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                mydatacontext.DeferredLoadingEnabled = false;
                tblDepartment _objservmaster = mydatacontext.tblDepartments.Where(x => x.Departmentid == _depid).SingleOrDefault();
                if (_objservmaster == null) return changeCount;
                mydatacontext.tblDepartments.DeleteOnSubmit(_objservmaster);
                changeSet = mydatacontext.GetChangeSet();
                changeCount = changeSet.Deletes.Count;
                mydatacontext.SubmitChanges();
                return changeCount;
            }

        }
    }
}
