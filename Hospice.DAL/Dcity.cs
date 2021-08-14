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
   public class Dcity:IDisposable
    {
        public tblLocCity ObjDcity = new tblLocCity();
        public tblLocState ObjDstate = new tblLocState();

        public tblLocCity GetcityDetailbycid(int _cityid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblLocCities.Where(x => x.CityId == _cityid).SingleOrDefault();
            }
        }

        public DataTable GetcityList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {

                var _items = (from c in mydatacontext.tblLocCities
                              join s in mydatacontext.tblLocStates on c.StateId equals s.StateId
                              join cn in mydatacontext.tblLocCountries on c.CountryId equals cn.CountryID
                              select new
                              {
                                  CityId = c.CityId,
                                  CityCode = c.CityCode,
                                  CityName = c.CityName,
                                  StateId = s.StateId,
                                  StateCode = s.StateCode,
                                  StateName = s.StateName,
                                  CountryId = cn.CountryID,
                                  CountryCode = cn.CountryCode,
                                  CountryName = cn.CountryName,
                                  Status = c.Status
                              }).ToList().ConvertIEnumerableToDataTable();

                return _items;
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

        public List<tblLocCity> GetLocStateList()
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


        /// <summary>
        /// Method for Insert the State.
        /// </summary>
        /// <param name="_objbrand"></param>
        /// <returns>-1 for State name is already exist in State table so data do not insert.
        /// 0 for data do not insert . 
        /// return id if data has been saved.</returns>
        public int InsertLocCity(tblLocCity _objcity)
        {

            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                tblLocCity _objcitychk = mydatacontext.tblLocCities.Where(x => x.CityName.ToUpper() == _objcity.CityName.ToUpper()).FirstOrDefault();
                if (_objcitychk != null) { changeCount = -1; }//check for State name already exist
                else
                {
                    mydatacontext.DeferredLoadingEnabled = false;
                    mydatacontext.tblLocCities.InsertOnSubmit(_objcity);
                    changeSet = mydatacontext.GetChangeSet();
                    changeCount = changeSet.Inserts.Count;
                    mydatacontext.SubmitChanges();
                    changeCount = _objcity.CityId;
                }

                //if (changeCount > 0) return 1; else return 0;
                return changeCount;
            }
        }

        public int UpdateLocCity(tblLocCity _objcity)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                mydatacontext.DeferredLoadingEnabled = false;

                tblLocCity _objtcitymasterchk = mydatacontext.tblLocCities.Where(x => x.CityId != _objcity.CityId && x.CityName.ToUpper() == _objcity.CityName.ToUpper()  && x.CountryId == _objcity.CountryId).FirstOrDefault();
                if (_objtcitymasterchk != null) { changeCount = -1; }//check for record already exist
                else
                {
                    tblLocCity _objcitys = mydatacontext.tblLocCities.Where(x => x.CityId == _objcity.CityId).SingleOrDefault();
                    _objcitys.CityCode = ObjDcity.CityCode;
                    _objcitys.CityName = ObjDcity.CityName;
                    _objcitys.StateId = ObjDcity.StateId;
                    _objcitys.CountryId = ObjDcity.CountryId;
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
        public int DeleteLocCity(int _cityid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                tblLocCity _objcity = mydatacontext.tblLocCities.Where(x => x.CityId == _cityid).SingleOrDefault();
                _objcity.Status = false;

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
