using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_qlDuan_CNTT.Areas.Admin.Models;

namespace doan_qlDuan_CNTT.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        AdminDataContext db = new AdminDataContext();
        [HandleError]
        public ActionResult Index()
        {
            if (Session["Username"] == null)
            {
                Session["Username"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }
    }
}