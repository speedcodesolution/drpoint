using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Hospice.DAL
{
    public class Dadmindashboard : IDisposable
    {
        public int GetDoctorCount()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                var result = mydatacontext.tblEmployeeMasters.Where(x => x.EmpType == 1).ToList().Count();

                return result;
            }
        }
        public int GetDoctorCountByBranchid(int branchid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                var result = mydatacontext.tblEmployeeMasters.Where(x => x.EmpType == 1 && x.Branchid== branchid).ToList().Count();

                return result;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
