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
   public class Dbranch:IDisposable
    {
        public Branch_Master objtbranchmaster = new Branch_Master();
        public Branch_Master ObjDcity = new Branch_Master();
        public tblLocState ObjDstate = new tblLocState();
        public Branch_Master GetstateDetailbycid(int _branchid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.Branch_Masters.Where(x => x.BranchID == _branchid).SingleOrDefault();
            }
        }

       

        public string GetCityName(int _cityid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblLocCities.Where(x => x.CityId == _cityid).SingleOrDefault().CityName;
            }
        }

        public List<tblLocCity> GetLocCityList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblLocCities.ToList();
            }
        }

        public List<tblLocCountry> GetLocCountryList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblLocCountries.ToList();
            }
        }

        public List<Branch_Master> GetbranchMasterList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {

                return mydatacontext.Branch_Masters.ToList();
            }
        }

        public Branch_Master Getbranchbymasterid(int _branchid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.Branch_Masters.Where(x => x.BranchID == _branchid).SingleOrDefault();
            }
        }


        /// <summary>
        /// Method for Insert the State.
        /// </summary>
        /// <param name="_objbrand"></param>
        /// <returns>-1 for State name is already exist in State table so data do not insert.
        /// 0 for data do not insert . 
        /// return id if data has been saved.</returns>
        public int InsertBranch(Branch_Master _objbranch)
        {

            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeset = null;
                int changecount = 0;
                Branch_Master _objbranchchk = mydatacontext.Branch_Masters.Where(x => x.BranchName.ToUpper() == _objbranch.BranchName.ToUpper()).FirstOrDefault();
               
                if (_objbranchchk != null)//check for Login name already exist
                {
                    changecount = -1;
                }
                else
                {
                    mydatacontext.DeferredLoadingEnabled = false;
                    mydatacontext.ExecuteCommand("Set IDENTITY_INSERT  Branch_Master ON");
                    mydatacontext.Branch_Masters.InsertOnSubmit(_objbranch);
                    changeset = mydatacontext.GetChangeSet();
                    changecount = changeset.Inserts.Count;
                    mydatacontext.SubmitChanges();
                    mydatacontext.ExecuteCommand("SET IDENTITY_INSERT Branch_Master OFF");
                }
                return changecount;

            }

            
        }

        public int UpdateBranch(Branch_Master _objbranch)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                mydatacontext.DeferredLoadingEnabled = false;

                Branch_Master _objtbranchmasterchk = mydatacontext.Branch_Masters.Where(x => x.BranchID != _objbranch.BranchID && x.BranchName.ToUpper() == _objbranch.BranchName.ToUpper()).FirstOrDefault();
                if (_objtbranchmasterchk != null) { changeCount = -1; }//check for record already exist
                else
                {
                    Branch_Master _objbranchs = mydatacontext.Branch_Masters.Where(x => x.BranchID == _objbranch.BranchID).SingleOrDefault();
                    _objbranchs.BranchLocation = _objbranch.BranchLocation;
                    _objbranchs.BranchName = _objbranch.BranchName;
                    _objbranchs.Address1 = _objbranch.Address1;
                    _objbranchs.Address2 = _objbranch.Address2;
                    _objbranchs.City = _objbranch.City;
                    //_objbranchs.State = _objbranchs.State;
                    _objbranchs.ContactPh = _objbranch.ContactPh;
                    _objbranchs.EmailID = _objbranch.EmailID;
                    changeSet = mydatacontext.GetChangeSet();
                    changeCount = changeSet.Updates.Count;
                    mydatacontext.SubmitChanges();
                }

                return changeCount;
            }
        }

        /// <summary>
        /// Only set the status 1 for active and 0 for inactive or delete
        /// </summary>
        /// <param name="_Stateid"></param>
        /// <returns></returns>
        public int DeleteBranch(int _branchid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                Branch_Master _objbranch = mydatacontext.Branch_Masters.Where(x => x.BranchID == _branchid).SingleOrDefault();
                _objbranch.Status = false;

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
