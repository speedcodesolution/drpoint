using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Hospice.DAL
{
    public partial class DrPointsDataContext
    {
        public DrPointsDataContext() : base(ConfigurationManager.ConnectionStrings["DrPointsDBConnection"].ConnectionString, mappingSource)
        {
            OnCreated();
        }
    }
}
