using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KafeKita.DataAccess;
using KafeKita.ViewModel;
using System.Web.Routing;


namespace KafeKita.Web.Controllers
{
    public class LoginController : Controller
    {
        MstOfficerDataAccess serviceOfficer = new MstOfficerDataAccess();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(MstOfficerViewModel dataLogin)
        {
            var modelUser = serviceOfficer.GetListOfficerForLogin(dataLogin);
            if (modelUser.Count == 0)
            {
                ViewBag.error = "Username atau Password salah";
                return View("Index");
            }
            else
            {
                if (modelUser[0].Actived.ToString() == "True")
                {
                    Session["Username"] = modelUser[0].Username;
                    Session["Role"] = modelUser[0].Desc;
                    Session["OfficerCode"] = modelUser[0].OfficerCode;
                    Session["EmployeeName"] = modelUser[0].Name;
                    return Json(new { pesan = "sukses" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { pesan = "gagal" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
    }
}