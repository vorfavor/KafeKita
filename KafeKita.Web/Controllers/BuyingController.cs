using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KafeKita.ViewModel;
using KafeKita.DataAccess;
using System.Data;

namespace KafeKita.Web.Controllers
{
    public class BuyingController : Controller
    {
        MstOfficerDataAccess serviceOfficer = new MstOfficerDataAccess();
        TrsBuyingDataAccess serviceBuying = new TrsBuyingDataAccess();
        MstItemDataAccess serviceItem = new MstItemDataAccess();
        MstSupplierDataAccess serviceSupplier = new MstSupplierDataAccess();
        DateTime today = DateTime.Now;

        // GET: Buying
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllListBuying()
        {
            return PartialView("_GetAllListBuying", serviceBuying.GetAllListBuying());
        }
        public ActionResult GetBuyingDetailByInvoiceCode(string cd)
        {
            return PartialView("_GetBuyingDetailByInvoiceCode",serviceBuying.GetBuyingDetailByInvoiceCode(cd));
        }
        public ActionResult GetListItem()
        {
            ItemSupplierViewModel ItemSupplier = new ItemSupplierViewModel();
            ItemSupplier.Item = serviceItem.GetAllListItem();
            ItemSupplier.Supplier = serviceSupplier.GetAllListSupplier();
            return PartialView("_GetListItem", ItemSupplier);
        }
        public JsonResult GetPrice(string cd)
        {
            return Json(serviceSupplier.GetPriceBySupplierCode(cd), JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateNewInvoice(TrsBuyingViewModel model)
        {
            model.Date = today;
            model.OfficerCode = @Session["OfficerCode"].ToString();
            if (ModelState.IsValid)
            {
                if (serviceBuying.CreateInvoice(model))
                {
                    return Json(new { pesan = "sukses" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { pesan = "gagal" }, JsonRequestBehavior.AllowGet);
                }
            }
            return View();
        }
    }
}