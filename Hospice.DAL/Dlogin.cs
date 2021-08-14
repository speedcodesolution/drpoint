using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospice.DAL
{
    public class Dlogin : IDisposable
    {
        public List<tblUser> GetLoginDetail(string _loginusername, string _loginpwd)
        {
            using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
            {
                return mydatacontext.tblUsers.Where(x => x.UsrLoginName.ToUpper() == _loginusername.ToString().ToUpper() && x.UsrPassword.ToUpper() == _loginpwd.ToString().ToUpper()).ToList();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>0 for password has been updated</returns>
        public string ChangePassword(int _logedinuid, string newpassword)
        {
            string result = "-1";

            try
            {
                using (DrPointsDataContext mydatacontext = new DrPointsDataContext())
                {
                    var getuser = mydatacontext.tblUsers.Where(x => x.UsrId == Convert.ToInt16(_logedinuid)).SingleOrDefault();
                    getuser.UsrPassword = newpassword;
                    mydatacontext.SubmitChanges();
                    result = "0";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
