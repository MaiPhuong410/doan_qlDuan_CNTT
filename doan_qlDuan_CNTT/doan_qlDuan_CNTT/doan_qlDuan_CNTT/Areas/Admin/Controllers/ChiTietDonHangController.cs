using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_qlDuan_CNTT.Areas.Admin.Models;
namespace doan_qlDuan_CNTT.Areas.Admin.Controllers
{
    public class ChiTietDonHangController : Controller
    {
        AdminDataContext db = new AdminDataContext();

        // GET: Admin/ChiTietDonHang
        public ActionResult Index(int mdh)
        {
            if (Session["Username"] == null)
            {
                Session["Username"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var ctdh = db.CTDONHANGs.Where(x => x.MaDH == mdh).ToList();
                return PartialView("Index", ctdh);
            }
        }
        [HttpGet]
        public ActionResult Create()
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
        [HandleError]
        [HttpPost]
        public ActionResult Create(CTDONHANG createctdh)
        {
            if (Session["Username"] == null)
            {
                Session["Username"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.CTDONHANGs.InsertOnSubmit(createctdh);
                    db.SubmitChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
