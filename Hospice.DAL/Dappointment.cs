using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospice.DAL
{
    public class Dappointment : IDisposable
    {
        public List<tblStatusMaster> GetAppointmentStatus()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblStatusMasters.Where(x=>x.StatusFor.ToLower()== "appointment").ToList();
            }
        }
        public List<sp_GetAppointmentListResult> GetAppointmentList(int branchid)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.sp_GetAppointmentList(branchid).ToList();
            }
        }
        public List<tblGenderMaster> GetGenders()
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblGenderMasters.Where(x => x.Status == 1).ToList();
            }
        }
        public List<sp_GetAvailabilTimeResult> GetAvailabilTime(int branchid, int doctorid, int serviceid, DateTime apptdate)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.sp_GetAvailabilTime(branchid,doctorid,serviceid,apptdate,1).ToList();
            }
        }
        public List<sp_GetAvailabilTimeResult> GetAllAvailabilTime(int branchid, int doctorid, int serviceid, DateTime apptdate)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.sp_GetAvailabilTime(branchid, doctorid, serviceid, apptdate, 0).ToList();
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
