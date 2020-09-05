using doan_qlDuan_CNTT.Areas.Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_qlDuan_CNTT.Areas.Store.ViewModels;
namespace doan_qlDuan_CNTT.Areas.Store.Controllers
{
    public class HomeController : Controller
    {
        // GET: Store/Home
        QLCHDataContext db = new QLCHDataContext();
       
        public ActionResult Index()
        {
            return View();
        }

        // tất cả sản phẩm
        public ActionResult SanPham(string searchString)
        {
            var dsSP = db.SANPHAMs.ToList(); 
            if (!String.IsNullOrEmpty(searchString))
            {
                return View(dsSP.Where(sp => sp.TenSP.ToLower().Contains(searchString.ToLower())));
            }
            return View(dsSP);
        }

        //hiển thị sản phẩm theo tên sp
        public ActionResult SearchByName(string name)
        {
            ViewBag.search = name;
           
            return View(db.SANPHAMs.Where(p => p.TenSP.ToLower().Contains(name.ToLower())).OrderByDescending(x => x.TenSP).ToList());
        }

        //Hiển thị chi tiết sản phẩm
        public ActionResult ProductDetail(string id)
        {
            return View(db.SANPHAMs.SingleOrDefault(p => p.MaSP.Equals(id)));
        }
    }
}