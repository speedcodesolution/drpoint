using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Hospice.DAL
{
    public class Duser : IDisposable
    {
        public tblUser ObjTblUserMaster = new tblUser();
        public List<tblUser> GetUsertblList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblUsers.ToList();
            }
        }
        public List<sp_GetUserListResult> GetUserList(int branchid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.sp_GetUserList(0, branchid).ToList();
            }
        }
        public List<sp_GetUserListResult> GetDoctorUserList(int branchid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.sp_GetUserList(branchid,1).ToList();
            }
        }
        public List<sp_GetUserListResult> GetStaffUserList(int branchid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.sp_GetUserList(branchid,2).ToList();
            }
        }
        public List<sp_GetUserListResult> GetPatientUserList(int branchid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.sp_GetUserList(branchid,3).ToList();
            }
        }
        public tblUser GetUserDetailsById(int _usrid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblUsers.Where(x => x.UsrId == _usrid).SingleOrDefault();
            }
        }
        public int InsertUser(tblUser _objuserid)
        {

            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeset = null;
                int changecount = 0;
                tblUser _objuserchk = mydatacontext.tblUsers.Where(x => x.UsrLoginName.ToUpper() == _objuserid.UsrLoginName.ToUpper()).FirstOrDefault();
                if (_objuserchk != null) { changecount = -1; }//check for Login name already exist
                else
                {
                    mydatacontext.DeferredLoadingEnabled = false;
                    mydatacontext.ExecuteCommand("Set IDENTITY_INSERT  tblUsers ON");
                    mydatacontext.tblUsers.InsertOnSubmit(_objuserid);
                    changeset = mydatacontext.GetChangeSet();
                    changecount = changeset.Inserts.Count;
                    mydatacontext.SubmitChanges();
                    mydatacontext.ExecuteCommand("SET IDENTITY_INSERT tblUsers OFF");
                }
                return changecount;

            }
        }
        /// <summary>
        /// This method only change the status '2' for deleted the usere , '1' for active and '0' for inactive
        /// </summary>
        /// <param name="_objuserdeleteid"></param>
        /// <returns></returns>
        public int DeleteUser(int _objuserdeleteid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                tblUser _objuser = mydatacontext.tblUsers.Where(x => x.UsrId == _objuserdeleteid && x.UsrStatus == 0).SingleOrDefault();
                _objuser.UsrStatus = 2;
                _objuser.UpdatedBy = ObjTblUserMaster.UpdatedBy;
                _objuser.UpdatedOn = ObjTblUserMaster.UpdatedOn;

                changeSet = mydatacontext.GetChangeSet();
                changeCount = changeSet.Updates.Count;
                mydatacontext.SubmitChanges();

                return changeCount;
            }

        }
        public int UpdateUser(tblUser _objtblusr)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                mydatacontext.DeferredLoadingEnabled = false;

                tblUser _objtusermasterchk = mydatacontext.tblUsers.Where(x => x.UsrId != _objtblusr.UsrId && x.UsrFirstName.ToUpper() == _objtblusr.UsrFirstName.ToUpper() && x.UsrLoginName == _objtblusr.UsrLoginName).FirstOrDefault();
                if (_objtusermasterchk != null) { changeCount = -1; }//check for record already exist
                else
                {
                    tblUser _objuser = mydatacontext.tblUsers.Where(x => x.UsrId == _objtblusr.UsrId).SingleOrDefault();
                    _objuser.UsrFirstName = ObjTblUserMaster.UsrFirstName;
                    _objuser.UsrLastName = ObjTblUserMaster.UsrLastName;
                    _objuser.UsrLoginName = ObjTblUserMaster.UsrLoginName;

                    _objuser.UsrContactNo = ObjTblUserMaster.UsrContactNo;
                    _objuser.UsrEmail = ObjTblUserMaster.UsrEmail;
                    _objuser.UsrCity = ObjTblUserMaster.UsrCity;

                    _objuser.UsrAddress = ObjTblUserMaster.UsrAddress;

                    _objuser.Usertype = ObjTblUserMaster.Usertype;
                    _objuser.UsertypeId = ObjTblUserMaster.UsertypeId;

                    _objuser.UsrStatus = ObjTblUserMaster.UsrStatus;

                    _objuser.UpdatedBy = ObjTblUserMaster.UpdatedBy;
                    _objuser.UpdatedOn = ObjTblUserMaster.UpdatedOn;

                    _objuser.BranchId = ObjTblUserMaster.BranchId;

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
