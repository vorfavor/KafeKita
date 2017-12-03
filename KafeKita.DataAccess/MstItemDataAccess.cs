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
    public class MstItemDataAccess
    {
        private DataContext dataContext = new DataContext();

        public List<MstItemViewModel> GetAllListItem()
        {
            List<MstItemViewModel> result = new List<MstItemViewModel>();
            result = (from item in dataContext.mstItem
                      select new MstItemViewModel 
                      { 
                          ItemCode = item.ItemCode,
                          Name = item.Name,
                          Qty = item.Qty,
                          Pieces = item.Pieces,
                          Price = item.Price,
                          Actived = item.Actived,
                          CreatedOn = item.CreatedOn,
                          CreatedBy = item.CreatedBy,
                          ModifiedOn = item.ModifiedOn,
                          ModifiedBy = item.ModifiedBy
                      }).ToList();
            return result;
        }
        public MstItemViewModel GetById(string cd)
        {
            MstItemViewModel result = new MstItemViewModel();
            result = (from item in dataContext.mstItem
                      where item.ItemCode == cd
                      select new MstItemViewModel {
                          ItemCode = item.ItemCode,
                          Name = item.Name,
                          Qty = item.Qty,
                          Pieces = item.Pieces,
                          Price = item.Price,
                          Actived = item.Actived,
                          CreatedOn = item.CreatedOn,
                          CreatedBy = item.CreatedBy,
                          ModifiedOn = item.ModifiedOn,
                          ModifiedBy = item.ModifiedBy
                      }).FirstOrDefault();
            return result;
        }
        public bool Create(MstItemViewModel vmodelItem)
        {
            bool result = true;
            MstItem modelItem = new MstItem();
            modelItem.ItemCode = vmodelItem.ItemCode;
            modelItem.Name = vmodelItem.Name;
            modelItem.Qty = vmodelItem.Qty;
            modelItem.Pieces = vmodelItem.Pieces;
            modelItem.Price = vmodelItem.Price;
            modelItem.Actived = vmodelItem.Actived;
            modelItem.CreatedOn = vmodelItem.CreatedOn;
            modelItem.CreatedBy = vmodelItem.CreatedBy;
            modelItem.ModifiedOn = vmodelItem.ModifiedOn;
            modelItem.ModifiedBy = vmodelItem.ModifiedBy;

            dataContext.mstItem.Add(modelItem);
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

        public bool Update(MstItemViewModel vmodelItem)
        {
            bool result = true;
            MstItem modelItem = dataContext.mstItem.Where(mdl => mdl.ItemCode == vmodelItem.ItemCode).FirstOrDefault();
            modelItem.Name = vmodelItem.Name;
            modelItem.Actived = vmodelItem.Actived;
            modelItem.ModifiedOn = vmodelItem.ModifiedOn;
            modelItem.ModifiedBy = vmodelItem.ModifiedBy;

            dataContext.Entry(modelItem).State = EntityState.Modified;
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
            MstItem modelItem = dataContext.mstItem.Where(mdl => mdl.ItemCode == id).FirstOrDefault();
            dataContext.mstItem.Remove(modelItem);
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
