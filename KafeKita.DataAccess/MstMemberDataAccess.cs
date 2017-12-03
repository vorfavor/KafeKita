using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using KafeKita.Model;
using KafeKita.ViewModel;

namespace KafeKita.DataAccess
{
    public class MstMemberDataAccess
    {
        private DataContext dataContext = new DataContext();

        public List<MstMemberViewModel> GetAllListMember()
        {
            List<MstMemberViewModel> result = new List<MstMemberViewModel>();
            result = (from member in dataContext.mstMember
                      select new MstMemberViewModel 
                      { 
                          MemberCode = member.MemberCode,
                          Name = member.Name,
                          Address = member.Address,
                          Email = member.Email,
                          Phone = member.Phone,
                          Actived = member.Actived,
                          CreatedOn = member.CreatedOn,
                          CreatedBy = member.CreatedBy,
                          ModifiedOn = member.ModifiedOn,
                          ModifiedBy = member.ModifiedBy
                      }).ToList();
            return result;
        }
        public MstMemberViewModel GetListMemberById(string id)
        {
            MstMemberViewModel result = new MstMemberViewModel();
            result = (from member in dataContext.mstMember
                      where member.MemberCode == id
                      select new MstMemberViewModel
                      {
                          MemberCode = member.MemberCode,
                          Name = member.Name,
                          Address = member.Address,
                          Email = member.Email,
                          Phone = member.Phone,
                          Actived = member.Actived,
                          CreatedOn = member.CreatedOn,
                          CreatedBy = member.CreatedBy,
                          ModifiedOn = member.ModifiedOn,
                          ModifiedBy = member.ModifiedBy
                      }).FirstOrDefault();
            return result;
        }

        public bool Create(MstMemberViewModel vmodelMember)
        {
            bool result = true;
            MstMember modelMmember = new MstMember();
            modelMmember.MemberCode = vmodelMember.MemberCode;
            modelMmember.Name = vmodelMember.Name;
            modelMmember.Address = vmodelMember.Address;
            modelMmember.Email = vmodelMember.Email;
            modelMmember.Phone = vmodelMember.Phone;
            modelMmember.Actived = vmodelMember.Actived;
            modelMmember.CreatedOn = vmodelMember.CreatedOn;
            modelMmember.CreatedBy = vmodelMember.CreatedBy;
            modelMmember.ModifiedOn = vmodelMember.ModifiedOn;
            modelMmember.ModifiedBy = vmodelMember.ModifiedBy;

            dataContext.mstMember.Add(modelMmember);
            try
            {
                dataContext.SaveChanges();
                return result;
            }
            catch (Exception)
            {
                result = false;
                return result;
                throw;
            }
        }
        public bool Update(MstMemberViewModel vmodelMember)
        {
            bool result = true;
            MstMember modelMember = dataContext.mstMember.Where(mdl => mdl.MemberCode == vmodelMember.MemberCode).FirstOrDefault();
            modelMember.Name = vmodelMember.Name;
            modelMember.Address = vmodelMember.Address;
            modelMember.Email = vmodelMember.Email;
            modelMember.Phone = vmodelMember.Phone;
            modelMember.Actived = vmodelMember.Actived;
            modelMember.CreatedOn = vmodelMember.CreatedOn;
            modelMember.CreatedBy = vmodelMember.CreatedBy;
            modelMember.ModifiedOn = vmodelMember.ModifiedOn;
            modelMember.ModifiedBy = vmodelMember.ModifiedBy;

            dataContext.Entry(modelMember).State = EntityState.Modified;
            try
            {
                dataContext.SaveChanges();
                return result;
            }
            catch (Exception)
            {
                result = false;
                return result;
                throw;
            }
        }
    }
}
