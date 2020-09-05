using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_qlDuan_CNTT.Areas.Admin.Models;


namespace doan_qlDuan_CNTT.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        AdminDataContext db = new AdminDataContext();

        // GET: Admin/DonHang
        public ActionResult Index()
        {
            if (Session["Username"] == null)
            {
                Session["Username"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                List<XemDonHangResult> model = db.XemDonHang().ToList();

                return View(model);
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
        public ActionResult Create(DONHANG createdh)
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
                    db.DONHANGs.InsertOnSubmit(createdh);
                    db.SubmitChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [HandleError]
        public ActionResult Edit(int mdh)
        {
            if (Session["Username"] == null)
            {
                Session["Username"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                DONHANG dh = db.DONHANGs.FirstOrDefault(p => p.MaDH == mdh);
                if (Request.Form.Count == 0)
                {
                    return View(dh);
                }

                string ngaymua = Request.Form["NgayMua"];
                string ngaydukiengiao = Request.Form["NgayDuKienGiao"];
                string tinhtrang = Request.Form["TinhTrang"];
                string makh = Request.Form["MaKH"];

                dh.NgayMua  = DateTime.Parse(ngaymua);
                dh.NgayDuKienGiao= DateTime.Parse(ngaydukiengiao);
                dh.TinhTrang =bool.Parse(tinhtrang);
                dh.MaKH = int.Parse(makh);

                db.SubmitChanges();
                return RedirectToAction("Index");
            }
        }
        [HandleError]
        public ActionResult Delete(int mdh)
        {
            if (Session["Username"] == null)
            {
                Session["Username"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var model = db.DONHANGs.SingleOrDefault(h => h.MaDH.Equals(mdh));
                try
                {
                    if (model != null)
                    {
                        db.DONHANGs.DeleteOnSubmit(model);
                        db.SubmitChanges();
                        return RedirectToAction("Index", "DonHang", new { error = "Xoá đơn hàng" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "DonHang", new { error = "Đơn hàng không tồn tại." });
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "DonHang", new { error = "Không thể xoá đơn hàng." });
                }
            }
        }
        public ActionResult Details (int mdh)
        {
            if (Session["Username"] == null)
            {
                Session["Username"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                CTDONHANG ctdh = db.CTDONHANGs.FirstOrDefault(p => p.MaDH == mdh);
                return View(ctdh);
            }
        }
    }
}