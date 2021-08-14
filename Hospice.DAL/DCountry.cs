using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Hospice.DAL
{
    public class DCountry : IDisposable
    {
        public tblLocCountry ObjtblCountryMaster = new tblLocCountry();
        public List<tblLocCountry> GetCountryList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblLocCountries.ToList();
            }
        }
        public tblLocCountry GetCountryDetailsById(int _countryid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblLocCountries.Where(x => x.CountryID == _countryid ).SingleOrDefault();
            }
        }
        public int InsertCountry(tblLocCountry _objcountry)
        {

            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeset = null;
                int changecount = 0;
                tblLocCountry _objcounrychk = mydatacontext.tblLocCountries.Where(x => x.CountryName.ToUpper() == _objcountry.CountryName.ToUpper()).FirstOrDefault();
                if (_objcountry != null)
                {
                    changecount = -1;
                }
                //check for Login name already exist
                else
                {
                    mydatacontext.DeferredLoadingEnabled = false;
                    mydatacontext.ExecuteCommand("Set IDENTITY_INSERT  tblLocCountry ON");
                    mydatacontext.tblLocCountries.InsertOnSubmit(_objcountry);
                    changeset = mydatacontext.GetChangeSet();
                    changecount = changeset.Inserts.Count;
                    mydatacontext.SubmitChanges();
                    mydatacontext.ExecuteCommand("SET IDENTITY_INSERT tblLocCountry OFF");
                }
                return changecount;

            }
        }
        /// <summary>
        /// This method only change the status 'false' for deleted the role , 'true' for active 
        /// </summary>
        /// <param name="_objcountrydeleteid"></param>
        /// <returns></returns>
        public int DeleteCountry(int _objcountrydeleteid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                tblLocCountry _objcountry = mydatacontext.tblLocCountries.Where(x => x.CountryID == _objcountrydeleteid).SingleOrDefault();
                changeSet = mydatacontext.GetChangeSet();
                changeCount = changeSet.Updates.Count;
                mydatacontext.SubmitChanges();

                return changeCount;
            }
            //using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            //{
            //    ChangeSet changeSet = null;
            //    int changeCount = 0;

            //    tblLocCountry _objcountry = mydatacontext.tblLocCountries.Where(x => x.CountryId == _objcountrydeleteid).SingleOrDefault();
            //    if (_objcountry != null) { changeCount = -1; }//check for role name is already used
            //    else
            //    {
            //        //tblLocCountry _objcountrys = mydatacontext.tblLocCountries.Where(x => x.CountryId == _objcountrydeleteid).SingleOrDefault();
            //        //_objcountrys.CountryId = true;

            //        changeSet = mydatacontext.GetChangeSet();
            //        changeCount = changeSet.Updates.Count;
            //        mydatacontext.SubmitChanges();
            //    }
            //    return changeCount;
            //}

        }
        public int UpdateCountry(tblLocCountry _objcountry)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                ChangeSet changeSet = null;
                int changeCount = 0;

                mydatacontext.DeferredLoadingEnabled = false;

                tblLocCountry _objtcountrymasterchk = mydatacontext.tblLocCountries.Where(x => x.CountryID != _objcountry.CountryID && x.CountryName.ToUpper() == _objcountry.CountryName.ToUpper() && x.CountryCode.ToUpper() == _objcountry.CountryCode.ToUpper()).FirstOrDefault();
                if (_objtcountrymasterchk != null) { changeCount = -1; }//check for record already exist
                else
                {
                    var _country = mydatacontext.tblLocCountries.Where(x => x.CountryID == _objcountry.CountryID).SingleOrDefault();
                    _country.CountryName = _objtcountrymasterchk.CountryName;
                    _country.CountryCode = _objtcountrymasterchk.CountryCode;
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
    
