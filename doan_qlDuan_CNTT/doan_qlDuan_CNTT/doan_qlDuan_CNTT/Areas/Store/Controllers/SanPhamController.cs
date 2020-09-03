using doan_qlDuan_CNTT.Areas.Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace doan_qlDuan_CNTT.Areas.Store.Controllers
{
    public class SanPhamController : Controller
    {
        //  
        QLCHDataContext db = new QLCHDataContext();

        // GET: Store/SanPham
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult sp_Chamsocda()
        {
            var dsSP = db.SANPHAMs.Where(sp => sp.MaLoai == "L0001" || sp.MaLoai == "L0002").ToList();
            return View(dsSP);
        }


    }
}