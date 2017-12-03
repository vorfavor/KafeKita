using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KafeKita.Model;
using KafeKita.ViewModel;

namespace KafeKita.DataAccess
{
    public class MstOfficerDataAccess
    {
        private DataContext dataContext = new DataContext();


        public List<MstOfficerViewModel> GetListOfficerForLogin(MstOfficerViewModel datalogin)
        {
            List<MstOfficerViewModel> result = new List<MstOfficerViewModel>();
            result = (from officer in dataContext.mstOfficer
                      join role in dataContext.mstRole
                      on officer.RoleId equals role.RoleId
                      join login in dataContext.trsLogin
                      on officer.OfficerCode equals login.OfficerCode
                      where login.Username == datalogin.Username
                      && login.Password == datalogin.Password
                      select new MstOfficerViewModel {
                      OfficerCode = officer.OfficerCode,
                      Username = login.Username,
                      Password = login.Password,
                      Actived = officer.Actived,
                      Name = officer.Name,
                      RoleId = officer.RoleId,
                      Desc = role.Desc
                      }).ToList();
            return result;
        }

    }
}
