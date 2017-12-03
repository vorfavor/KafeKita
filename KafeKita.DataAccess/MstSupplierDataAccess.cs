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
    public class MstSupplierDataAccess
    {
        private DataContext dataContext = new DataContext();

        public List<MstSupplierViewModel> GetAllListSupplier()
        {
            List<MstSupplierViewModel> result = new List<MstSupplierViewModel>();
            result = (from supplier in dataContext.mstSupplier
                      select new MstSupplierViewModel 
                      {
                          SupplierCode = supplier.SupplierCode,
                          ItemId = supplier.ItemId,
                          Price = supplier.Price,
                          Name = supplier.Name,
                          Address = supplier.Address,
                          Email = supplier.Email,
                          Phone = supplier.Phone,
                          Actived = supplier.Actived,
                          CreatedOn = supplier.CreatedOn,
                          CreatedBy = supplier.CreatedBy,
                          ModifiedOn = supplier.ModifiedOn,
                          ModifiedBy = supplier.ModifiedBy
                      }).ToList();
            return result;
        }
        public MstSupplierViewModel GetById(string cd)
        {
            MstSupplierViewModel result = new MstSupplierViewModel();
            result = (from supplier in dataContext.mstSupplier
                      where supplier.SupplierCode == cd
                      select new MstSupplierViewModel {
                          SupplierCode = supplier.SupplierCode,
                          ItemId = supplier.ItemId,
                          Price = supplier.Price,
                          Name = supplier.Name,
                          Address = supplier.Address,
                          Email = supplier.Email,
                          Phone = supplier.Phone,
                          Actived = supplier.Actived,
                          CreatedOn = supplier.CreatedOn,
                          CreatedBy = supplier.CreatedBy,
                          ModifiedOn = supplier.ModifiedOn,
                          ModifiedBy = supplier.ModifiedBy
                      }).FirstOrDefault();
            return result;
        }
        public List<MstSupplierViewModel> GetByItemCode(string cd)
        {
            List<MstSupplierViewModel> result = new List<MstSupplierViewModel>();
            result = (from supplier in dataContext.mstSupplier
                      join item in dataContext.mstItem
                          on supplier.ItemId equals item.ItemCode
                          where supplier.ItemId == cd
                      select new MstSupplierViewModel { 
                      SupplierCode = supplier.SupplierCode,
                      Name = supplier.Name,
                      ItemId = supplier.ItemId,
                      ItemName = item.Name,
                      Price = supplier.Price
                      }).ToList();
            return result;
        }
        public MstSupplierViewModel GetPriceBySupplierCode(string cd)
        {
            MstSupplierViewModel result = new MstSupplierViewModel();
            result = (from supplier in dataContext.mstSupplier
                      where supplier.SupplierCode == cd
                      select new MstSupplierViewModel {
                      SupplierCode = supplier.SupplierCode,
                      Price = supplier.Price
                      }).FirstOrDefault();
            return result;
        }
        public bool Create(MstSupplierViewModel vmodelSupplier)
        {
            bool result = true;
            MstSupplier modelSupplier = new MstSupplier();
            modelSupplier.SupplierCode = vmodelSupplier.SupplierCode;
            modelSupplier.ItemId = vmodelSupplier.ItemId;
            modelSupplier.Price = vmodelSupplier.Price;
            modelSupplier.Name = vmodelSupplier.Name;
            modelSupplier.Address = vmodelSupplier.Address;
            modelSupplier.Email = vmodelSupplier.Email;
            modelSupplier.Phone = vmodelSupplier.Phone;
            modelSupplier.Actived = vmodelSupplier.Actived;
            modelSupplier.CreatedOn = vmodelSupplier.CreatedOn;
            modelSupplier.CreatedBy = vmodelSupplier.CreatedBy;
            modelSupplier.ModifiedOn = vmodelSupplier.ModifiedOn;
            modelSupplier.ModifiedBy = vmodelSupplier.ModifiedBy;

            dataContext.mstSupplier.Add(modelSupplier);
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

        public bool Update(MstSupplierViewModel vmodelSupplier)
        {
            bool result = true;
            MstSupplier modelSupplier = dataContext.mstSupplier.Where(mdl => mdl.SupplierCode == vmodelSupplier.SupplierCode).FirstOrDefault();
            modelSupplier.SupplierCode = vmodelSupplier.SupplierCode;
            modelSupplier.ItemId = vmodelSupplier.ItemId;
            modelSupplier.Price = vmodelSupplier.Price;
            modelSupplier.Name = vmodelSupplier.Name;
            modelSupplier.Address = vmodelSupplier.Address;
            modelSupplier.Email = vmodelSupplier.Email;
            modelSupplier.Phone = vmodelSupplier.Phone;
            modelSupplier.Actived = vmodelSupplier.Actived;
            modelSupplier.ModifiedOn = vmodelSupplier.ModifiedOn;
            modelSupplier.ModifiedBy = vmodelSupplier.ModifiedBy;

            dataContext.Entry(modelSupplier).State = EntityState.Modified;
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
        public bool Delete(string id)
        {
            bool result = true;
            MstSupplier modelSupplier = dataContext.mstSupplier.Where(mdl => mdl.SupplierCode == id).FirstOrDefault();
            dataContext.mstSupplier.Remove(modelSupplier);
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
