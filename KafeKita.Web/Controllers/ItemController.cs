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
    public class ItemController : Controller
    {
        MstItemDataAccess serviceItem = new MstItemDataAccess();
        MstSupplierDataAccess serviceSupplier = new MstSupplierDataAccess();
        DateTime today = DateTime.Now;
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllListItem()
        {
            return PartialView("_GetAllListItem",serviceItem.GetAllListItem());
        }
        public ActionResult CreateNewItemForm()
        {
            return PartialView("_CreateNewItemForm");
        }
        public ActionResult UpdateItemForm(string cd)
        {
            return PartialView("_UpdateItemForm",serviceItem.GetById(cd));
        }
        public ActionResult CreateNewItem(MstItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Qty = 0;
                model.Price = 0;
                model.Pieces = "gram";
                model.Actived = false;
                model.CreatedBy = (string)Session["EmployeeName"];
                model.CreatedOn = today;
                model.ModifiedBy = (string)Session["EmployeeName"];
                model.ModifiedOn = today;
                if (serviceItem.Create(model))
                {
                    return Json(new { pesan = "sukses" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { pesan = "gagal" }, JsonRequestBehavior.AllowGet);
                }
            }
            return View("Index");
        }
        public ActionResult Delete(string cd)
        {
            if (ModelState.IsValid)
            {
                if (serviceItem.Delete(cd))
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
        public ActionResult Update(MstItemViewModel model)
        {

            if (ModelState.IsValid)
            {
                model.ModifiedOn = today;
                model.ModifiedBy = (string)Session["EmployeeName"];
                if (serviceItem.Update(model))
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