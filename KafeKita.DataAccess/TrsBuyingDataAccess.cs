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
    public class TrsBuyingDataAccess
    {
        private DataContext dataContext = new DataContext();

        public List<TrsBuyingViewModel> GetAllListBuying()
        {
            List<TrsBuyingViewModel> result = new List<TrsBuyingViewModel>();
            result = (from buying in dataContext.trsBuying
                      select new TrsBuyingViewModel { 
                      InvoiceCode = buying.InvoiceCode,
                      Date = buying.Date,
                      TotalItem = buying.TotalItem,
                      TotalPrice = buying.TotalPrice,
                      Approved = buying.Approved
                      }).ToList();
            return result;
        }
        public List<TrsBuyingDetailViewModel> GetBuyingDetailByInvoiceCode(string cd)
        {
            List<TrsBuyingDetailViewModel> result = new List<TrsBuyingDetailViewModel>();
            result = (from buyDetail in dataContext.trsBuyingDetail
                      where buyDetail.InvoiceCode == cd
                      select new TrsBuyingDetailViewModel {
                      InvoiceCode = buyDetail.InvoiceCode,
                      ItemCode = buyDetail.ItemCode,
                      Qty = buyDetail.Qty,
                      BuyingPrice = buyDetail.BuyingPrice,
                      SupplierCode = buyDetail.SupplierCode
                      }).ToList();
            return result;
        }
        public bool CreateInvoice(TrsBuyingViewModel vmodelBuying)
        {
            bool result = true;
            TrsBuying modelBuying = new TrsBuying();
            modelBuying.InvoiceCode = vmodelBuying.InvoiceCode;
            modelBuying.Date = vmodelBuying.Date;
            modelBuying.TotalItem = vmodelBuying.TotalItem;
            modelBuying.TotalPrice = vmodelBuying.TotalPrice;
            modelBuying.Approved = vmodelBuying.Approved;
            modelBuying.OfficerCode = vmodelBuying.OfficerCode;

            dataContext.trsBuying.Add(modelBuying);

            foreach (var item in vmodelBuying.BuyingDetail)
            {
                TrsBuyingDetail tbd = new TrsBuyingDetail();
                tbd.InvoiceCode = item.InvoiceCode;
                tbd.ItemCode = item.ItemCode;
                tbd.Qty = item.Qty;
                tbd.BuyingPrice = item.BuyingPrice;
                tbd.SupplierCode = item.SupplierCode;
                dataContext.trsBuyingDetail.Add(tbd);
            }
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
