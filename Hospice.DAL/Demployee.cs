using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Hospice.DAL
{
    public class Demployee: IDisposable
    {
        public tblEmployeeMaster ObjTblEmployeeMaster = new tblEmployeeMaster();
        public AvailabilityMaster ObjTblAvailabilityMaster = new AvailabilityMaster();
        public List<AvailabilityMaster> GetAvailabilityMasters(int _empid,int _branchid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.AvailabilityMasters.Where(x => x.DoctorId== _empid && x.BranchId==_branchid).ToList();
            }
        }
        /// <summary>
        /// Method for get employee last id
        /// </summary>
        /// <returns>employee id</returns>
        public int GetEmpID()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                var result = mydatacontext.tblEmployeeMasters.ToList().Count();
                if (result > 0)
                    result = mydatacontext.tblEmployeeMasters.Max(x => x.EmpID) + 1;
                else
                    result = result + 1;

                    return result;
            }
        }
        /// <summary>
        /// Method for get all Recommendation list
        /// </summary>
        /// <returns>Employee master list</returns>
        public List<tblEmployeeMaster> GetEmpMasterList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblEmployeeMasters.ToList();
            }
        }
        /// <summary>
        /// Method for get ReferenceMaster details by refid
        /// </summary>
        /// <param name="_empid"></param>
        /// <returns>Employee master details </returns>
        public tblEmployeeMaster GetEmpMasterbyid(int _empid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblEmployeeMasters.Where(x => x.EmpID == _empid).SingleOrDefault();
            }
        }
        public string UpdateRecomStatus(int _empid, string updatestatus)
        {

            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                tblEmployeeMaster _objtempm = mydatacontext.tblEmployeeMasters.Where(x => x.EmpID == _empid).SingleOrDefault();
                _objtempm.StatusEmp =Convert.ToInt16(updatestatus);
                mydatacontext.SubmitChanges();
                return updatestatus;
            }

        }

        /// <summary>
        /// Method for Insert the data.
        /// </summary>
        /// <param name="_objtempmaster"></param>
        /// <returns>-1 for Employee code  is already exist, so data do not insert.
        /// 0 for data do not insert . 
        /// 1 for data has been inserted.</returns>
        public int InsertEmployee(tblEmployeeMaster _objtempmaster)
        {

            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                tblEmployeeMaster _objtempmasterchk = mydatacontext.tblEmployeeMasters.Where(x => x.EmpCode.ToUpper() == _objtempmaster.EmpCode.ToUpper()).FirstOrDefault();
                if (_objtempmasterchk != null) { changeCount = -1; }//check for brand name already exist
                else
                {
                    mydatacontext.DeferredLoadingEnabled = false;

                    mydatacontext.ExecuteCommand("SET IDENTITY_INSERT tblEmployeeMaster ON");
                    mydatacontext.tblEmployeeMasters.InsertOnSubmit(_objtempmaster);
                    changeSet = mydatacontext.GetChangeSet();
                    changeCount = changeSet.Inserts.Count;
                    mydatacontext.SubmitChanges();
                    mydatacontext.ExecuteCommand("SET IDENTITY_INSERT tblEmployeeMaster OFF");
                    changeCount = _objtempmaster.EmpID;
                }

                return changeCount;
            }
        }
        /*
        public int InsertDrEmployee()
        {

            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                tblEmployeeMaster _objtempmasterchk = mydatacontext.tblEmployeeMasters.Where(x => x.EmpCode.ToUpper() == _objtempmaster.EmpCode.ToUpper()).FirstOrDefault();
                if (_objtempmasterchk != null) { changeCount = -1; }//check for brand name already exist
                else
                {
                    mydatacontext.DeferredLoadingEnabled = false;

                    mydatacontext.ExecuteCommand("SET IDENTITY_INSERT tblEmployeeMaster ON");
                    mydatacontext.tblEmployeeMasters.InsertOnSubmit(_objtempmaster);
                    changeSet = mydatacontext.GetChangeSet();
                    changeCount = changeSet.Inserts.Count;
                    mydatacontext.SubmitChanges();
                    mydatacontext.ExecuteCommand("SET IDENTITY_INSERT tblEmployeeMaster OFF");
                    
                }

                return changeCount;
            }
            int result = 0;
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                tblEmployeeMaster _objtempmasterchk = mydatacontext.tblEmployeeMasters.Where(x => x.EmpName.ToUpper() == ObjTblEmployeeMaster.EmpName.ToUpper()).FirstOrDefault();
                if (_objtempmasterchk != null)
                {
                    result = -1;
                    return result;
                }

            }
            using (TransactionScope ts = new TransactionScope())
            {
                using (MYogaDataContext mydatacontext = new MYogaDataContext())
                {
                    tblExercise _objexec = new tblExercise();
                    _objexec.ExeCode = objTblExc.ExeCode;
                    _objexec.ExerciseName = objTblExc.ExerciseName;
                    //_objexec.Treatment = objTblExc.Treatment;
                    //_objexec.Simtram = objTblExc.Simtram;
                    _objexec.Remarks = objTblExc.Remarks;
                    _objexec.Status = objTblExc.Status;

                    _objexec.CreatedBy = Convert.ToInt32(objTblExc.CreatedBy);
                    _objexec.CreatedOn = objTblExc.CreatedOn;

                    mydatacontext.tblExercises.InsertOnSubmit(_objexec);
                    mydatacontext.SubmitChanges();

                    objTblExcDetail.ExeID = _objexec.ExeID;

                    foreach (DataRow dr in _dtexercisedetail.Rows)
                    {
                        tblExerciseDetail _objexecdetail = new tblExerciseDetail();
                        _objexecdetail.ExeID = _objexec.ExeID;
                        _objexecdetail.DiseaseDetailID = Convert.ToInt32(dr["DiseaseDetailID"].ToString());
                        _objexecdetail.ExeVariation = dr["ExeVariation"].ToString();
                        _objexecdetail.ExeSymptom = dr["ExeSymptom"].ToString();
                        _objexecdetail.Repetition = Convert.ToInt32(dr["Repetition"].ToString());
                        string _duration = dr["Duration"].ToString();
                        TimeSpan time = TimeSpan.Parse(_duration);
                        _objexecdetail.Duration = time;
                        _objexecdetail.StartDate = Convert.ToDateTime(dr["StartDate"].ToString());
                        _objexecdetail.Remarks = dr["Remarks"].ToString();
                        _objexecdetail.Status = Convert.ToInt32(dr["Status"].ToString());
                        _objexecdetail.CreatedBy = Convert.ToInt32(objTblExc.CreatedBy);
                        _objexecdetail.CreatedOn = objTblExc.CreatedOn;
                        mydatacontext.tblExerciseDetails.InsertOnSubmit(_objexecdetail);
                        mydatacontext.SubmitChanges();
                    }
                }
                ts.Complete();
                result = Convert.ToInt32(objTblExcDetail.ExeID);
            }
            return result;
        }
        */
        /// <summary>
        /// Method for Update the data.
        /// </summary>
        /// <param name="_objtrecmaster"></param>
        /// <returns>-1 for Employee Code is already exist in Employee Master table so data do not update.
        /// 0 for data do not update . 
        /// 1 for data has been updated</returns>
        public int UpdateEmployee(tblEmployeeMaster _objtempmaster)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                mydatacontext.DeferredLoadingEnabled = false;

                tblEmployeeMaster _objtempmasterchk = mydatacontext.tblEmployeeMasters.Where(x => x.EmpID != _objtempmaster.EmpID && x.EmpCode == _objtempmaster.EmpCode).FirstOrDefault();
                if (_objtempmasterchk != null) { changeCount = -1; }//check for brand already exist
                else
                {
                    // mydatacontext.tblEmployeeMasters.Attach(_objtempmaster, GetEmpMasterbyid(_objtempmaster.EmpID));
                    _objtempmasterchk = mydatacontext.tblEmployeeMasters.Where(x => x.EmpID == _objtempmaster.EmpID && x.EmpCode == _objtempmaster.EmpCode).FirstOrDefault();
                    _objtempmasterchk.EmpCode = _objtempmaster.EmpCode;
                    _objtempmasterchk.EmpName = _objtempmaster.EmpName;
                    _objtempmasterchk.Address = _objtempmaster.Address;
                    _objtempmasterchk.City = _objtempmaster.City;
                    _objtempmasterchk.MobileNo = _objtempmaster.MobileNo;
                    _objtempmasterchk.DepartmentId = _objtempmaster.DepartmentId;
                    _objtempmasterchk.DOB = _objtempmaster.DOB;
                    _objtempmasterchk.DOJ = _objtempmaster.DOJ;
                    _objtempmasterchk.DesignationId = _objtempmaster.DesignationId;
                    _objtempmasterchk.Qualification = _objtempmaster.Qualification;
                    _objtempmasterchk.ContentType = _objtempmaster.ContentType;
                    _objtempmasterchk.Data = _objtempmaster.Data;
                    _objtempmasterchk.Speciality = _objtempmaster.Speciality;
                    _objtempmasterchk.StatusEmp = _objtempmaster.StatusEmp;

                    changeSet = mydatacontext.GetChangeSet();
                    changeCount = changeSet.Updates.Count;
                    mydatacontext.SubmitChanges();
                }

                return changeCount;
                //if (changeCount > 0) return 1; else return 0;
            }
        }
                          
        /// <summary>
        /// Method for Delete the data
        /// </summary>
        /// <returns>-1 for Employee Code is already used in other table so data do not delete.
        /// 0 for data do not delete .
        /// 1 for data has been deleted</returns>
        public int DeleteEmployee(int _empid)
        {

            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                //tbl_Item _objitemchk = mydatacontext.tbl_Items.Where(x => x.BrandID == _refmasterid).FirstOrDefault();
                //if (_objitemchk != null)
                //    changeCount = -1;
                //else
                //{
                tblEmployeeMaster _objtempmaster = GetEmpMasterbyid(_empid);
                if (_objtempmaster == null) return changeCount;

                mydatacontext.DeferredLoadingEnabled = false;
                tblEmployeeMaster _objempmaster = mydatacontext.tblEmployeeMasters.Where(x => x.EmpID == _empid).SingleOrDefault();
                if (_objempmaster == null) return changeCount;
                // mydatacontext.tblEmployeeMasters.Attach(_objtempmaster);
                mydatacontext.tblEmployeeMasters.DeleteOnSubmit(_objtempmaster);
                changeSet = mydatacontext.GetChangeSet();
                changeCount = changeSet.Deletes.Count;
                mydatacontext.SubmitChanges();

                return changeCount;
            }

        }
        public int InsertAvailability(AvailabilityMaster availabilitymaster)
        {

            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeset = null;
                int changecount = 0;
                
                mydatacontext.DeferredLoadingEnabled = false;
                mydatacontext.ExecuteCommand("Set IDENTITY_INSERT  AvailabilityMaster ON");
                mydatacontext.AvailabilityMasters.InsertOnSubmit(availabilitymaster);
                changeset = mydatacontext.GetChangeSet();
                changecount = changeset.Inserts.Count;
                mydatacontext.SubmitChanges();
                mydatacontext.ExecuteCommand("SET IDENTITY_INSERT AvailabilityMaster OFF");

                return changecount;

            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
