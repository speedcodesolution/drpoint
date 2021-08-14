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
   public class Dstate:IDisposable
    {
        public tblLocState ObjDLocationState = new tblLocState();
        public tblLocState GetstateDetailbycid(int _stateid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblLocStates.Where(x => x.StateId == _stateid).SingleOrDefault();
            }
        }

        public DataTable GetStateList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {

                var _items = (from s in mydatacontext.tblLocStates                              
                              join cn in mydatacontext.tblLocCountries on s.CountryId equals cn.CountryID
                              select new
                              {
                                  StateId = s.StateId,
                                  StateCode = s.StateCode,
                                  StateName = s.StateName,
                                  CountryId = cn.CountryID,
                                  CountryCode = cn.CountryCode,
                                  CountryName = cn.CountryName,
                                  Status = s.Status
                              }).ToList().ConvertIEnumerableToDataTable();

                return _items;
            }
        }
        public string GetStateName(int _stateid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblLocStates.Where(x => x.StateId == _stateid).SingleOrDefault().StateName;
            }
        }

        public List<tblLocState> GetLocStateList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblLocStates.ToList();
            }
        }
        public List<tblLocCountry> GetLocCountryList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblLocCountries.ToList();
            }
        }


        /// <summary>
        /// Method for Insert the State.
        /// </summary>
        /// <param name="_objbrand"></param>
        /// <returns>-1 for State name is already exist in State table so data do not insert.
        /// 0 for data do not insert . 
        /// return id if data has been saved.</returns>
        public int InsertLocState(tblLocState _objstate)
        {

            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                tblLocState _objstatechk = mydatacontext.tblLocStates.Where(x => x.StateName.ToUpper() == _objstate.StateName.ToUpper()).FirstOrDefault();
                if (_objstatechk != null) { changeCount = -1; }//check for State name already exist
                else
                {
                    mydatacontext.DeferredLoadingEnabled = false;
                    mydatacontext.tblLocStates.InsertOnSubmit(_objstate);
                    changeSet = mydatacontext.GetChangeSet();
                    changeCount = changeSet.Inserts.Count;
                    mydatacontext.SubmitChanges();
                    changeCount = _objstate.StateId;
                }

                //if (changeCount > 0) return 1; else return 0;
                return changeCount;
            }
        }

        public int UpdateLocState(tblLocState _objstate)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                mydatacontext.DeferredLoadingEnabled = false;

                tblLocState _objtstatemasterchk = mydatacontext.tblLocStates.Where(x => x.StateId != _objstate.StateId && x.StateName.ToUpper() == _objstate.StateName.ToUpper()  && x.CountryId == _objstate.CountryId).FirstOrDefault();
                if (_objtstatemasterchk != null) { changeCount = -1; }//check for record already exist
                else
                {
                    tblLocState _objstates = mydatacontext.tblLocStates.Where(x => x.StateId == _objstate.StateId).SingleOrDefault();
                    _objstates.StateCode = ObjDLocationState.StateCode;
                    _objstates.StateName = ObjDLocationState.StateName;
                    //_objstates.StateId = ObjDLocationState.StateId;
                    _objstates.CountryId = ObjDLocationState.CountryId;
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
        public int DeleteLocState(int _stateid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                tblLocState _objstate = mydatacontext.tblLocStates.Where(x => x.StateId == _stateid).SingleOrDefault();
                _objstate.Status = false;

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
