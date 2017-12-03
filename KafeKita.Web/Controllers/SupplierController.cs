using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KafeKita.ViewModel;
using KafeKita.DataAccess;

namespace KafeKita.Web.Controllers
{
    public class SupplierController : Controller
    {
        MstSupplierDataAccess serviceSupplier = new MstSupplierDataAccess();
        DateTime today = DateTime.Now;
        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllListSupplier()
        {
            return PartialView("_GetAllListSupplier",serviceSupplier.GetAllListSupplier());
        }
        public ActionResult CreateNewSupplierForm()
        {
            return PartialView("_CreateNewSupplierForm");
        }
        public ActionResult UpdateSupplierForm(string cd)
        {
            return PartialView("_UpdateSupplierForm", serviceSupplier.GetById(cd));
        }
        public ActionResult CreateNewSupplier(MstSupplierViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Actived = true;
                model.CreatedBy = (string)Session["EmployeeName"];
                model.CreatedOn = today;
                model.ModifiedBy = (string)Session["EmployeeName"];
                model.ModifiedOn = today;
                if (serviceSupplier.Create(model))
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
                if (serviceSupplier.Delete(cd))
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
        public ActionResult Update(MstSupplierViewModel model)
        {

            if (ModelState.IsValid)
            {
                model.ModifiedOn = today;
                model.ModifiedBy = (string)Session["EmployeeName"];
                if (serviceSupplier.Update(model))
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