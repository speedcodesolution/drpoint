using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Hospice.DAL
{
    public class Drole : IDisposable
    {
        public tblRole ObjTblRoleMaster = new tblRole();
        public List<tblRole> GetRoleList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblRoles.ToList();
            }
        }
        public tblRole GetRoleDetailsById(int _rlid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblRoles.Where(x => x.RlId == _rlid && x.RlIsDeleted == false).SingleOrDefault();
            }
        }
        public int InsertRole(tblRole _objrole)
        {

            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeset = null;
                int changecount = 0;
                tblRole _objrolechk = mydatacontext.tblRoles.Where(x => x.RlName.ToUpper() == _objrole.RlName.ToUpper()).FirstOrDefault();
                if (_objrolechk != null) { changecount = -1; }//check for Login name already exist
                else
                {
                    mydatacontext.DeferredLoadingEnabled = false;
                    mydatacontext.ExecuteCommand("Set IDENTITY_INSERT  tblRoles ON");
                    mydatacontext.tblRoles.InsertOnSubmit(_objrole);
                    changeset = mydatacontext.GetChangeSet();
                    changecount = changeset.Inserts.Count;
                    mydatacontext.SubmitChanges();
                    mydatacontext.ExecuteCommand("SET IDENTITY_INSERT tblRoles OFF");
                }
                return changecount;

            }
        }
        /// <summary>
        /// This method only change the status 'false' for deleted the role , 'true' for active 
        /// </summary>
        /// <param name="_objroledeleteid"></param>
        /// <returns></returns>
        public int DeleteRole(int _objroledeleteid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                tblUserRole _objuserrole = mydatacontext.tblUserRoles.Where(x => x.RoleId == _objroledeleteid).SingleOrDefault();
                if (_objuserrole != null) { changeCount = -1; }//check for role name is already used
                else
                {
                    tblRole _objrole = mydatacontext.tblRoles.Where(x => x.RlId == _objroledeleteid).SingleOrDefault();
                    _objrole.RlIsDeleted = true;

                    changeSet = mydatacontext.GetChangeSet();
                    changeCount = changeSet.Updates.Count;
                    mydatacontext.SubmitChanges();
                }
                return changeCount;
            }

        }
        public int UpdateRole(tblRole _objrole)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                mydatacontext.DeferredLoadingEnabled = false;

                tblRole _objtrolemasterchk = mydatacontext.tblRoles.Where(x => x.RlId != _objrole.RlId && x.RlName.ToUpper() == _objrole.RlName.ToUpper()).FirstOrDefault();
                if (_objtrolemasterchk != null) { changeCount = -1; }//check for record already exist
                else
                {
                    var _role = mydatacontext.tblRoles.Where(x => x.RlId == _objrole.RlId).SingleOrDefault();
                    _role.RlName = ObjTblRoleMaster.RlName;
                    _role.RlDescription = ObjTblRoleMaster.RlDescription;
                    _role.RlIsActive = ObjTblRoleMaster.RlIsActive;

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
