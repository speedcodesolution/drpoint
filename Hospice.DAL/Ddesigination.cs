using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Hospice.DAL
{
    public class Ddesigination: IDisposable
    {
        public List<tblDepartment> GetdepMasterList()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {

                return mydatacontext.tblDepartments.ToList();
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
