using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using Hospice.Helper;

namespace Hospice.DAL
{
    public class DuserRole : IDisposable
    {
        public List<sp_GetUserRoleListResult> GetUserRoleList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.sp_GetUserRoleList().ToList();
            }
        }
        public List<tblUserRole> GetUserRoleListbyuid(int _uid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblUserRoles.Where(x => x.UserId == _uid).ToList();
            }
        }

        public int InsertUserRoles(List<tblUserRole> _objtur)
        {

            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeset = null;
                int changecount = 0;
                //tblUser _objuserchk = mydatacontext.tblUserRoles.Where(x => x.UsrLoginName.ToUpper() == _objtur.UsrLoginName.ToUpper()).FirstOrDefault();
                //if (_objuserchk != null) { changecount = -1; }//check for Login name already exist
                //else
                //{
                mydatacontext.DeferredLoadingEnabled = false;
                mydatacontext.ExecuteCommand("Set IDENTITY_INSERT  tblUserRole ON");
                mydatacontext.tblUserRoles.InsertAllOnSubmit(_objtur);
                changeset = mydatacontext.GetChangeSet();
                changecount = changeset.Inserts.Count;
                mydatacontext.SubmitChanges();
                mydatacontext.ExecuteCommand("SET IDENTITY_INSERT tblUserRole OFF");
                //}
                return changecount;

            }
        }
        public int UpdateUserRole(List<tblUserRole> _objtur, int _uid)
        {
            try
            {
                using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
                {
                    ChangeSet changeSet = null;
                    int changeCount = 0;

                    mydatacontext.DeferredLoadingEnabled = false;

                    var _objur = mydatacontext.tblUserRoles.Where(x => x.UserId == _uid);
                    mydatacontext.tblUserRoles.DeleteAllOnSubmit(_objur);
                    if (_objtur.Count > 0)
                    {

                        mydatacontext.tblUserRoles.InsertAllOnSubmit(_objtur);
                        changeSet = mydatacontext.GetChangeSet();
                        changeCount = changeSet.Inserts.Count;
                        mydatacontext.SubmitChanges();
                    }

                    return changeCount;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(HospiceSetting.catcherror);
            }
        }
        public int DeleteUserRole(int _objuserid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                var _objur = mydatacontext.tblUserRoles.Where(x => x.UserId == _objuserid);
                mydatacontext.tblUserRoles.DeleteAllOnSubmit(_objur);

                changeSet = mydatacontext.GetChangeSet();
                changeCount = changeSet.Updates.Count;
                mydatacontext.SubmitChanges();
                
                return changeCount;
            }

        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
