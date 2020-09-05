using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_qlDuan_CNTT.Areas.Admin.Models;

namespace doan_qlDuan_CNTT.Areas.Admin.Controllers
{
    public class ProviderController : Controller
    {
        AdminDataContext db = new AdminDataContext();
        // GET: Admin/Provider
        [HandleError]
        public ActionResult Index(string error)
        {
            if (Session["Username"] == null)
            {
                Session["Username"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.TypeError = error;
                return View(db.NHACUNGCAPs.ToList());
            }
        }
        [HandleError]
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
        public ActionResult Create(NHACUNGCAP createNCC)
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
                    db.NHACUNGCAPs.InsertOnSubmit(createNCC);
                    db.SubmitChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [HandleError]
        public ActionResult Edit(string id)
        {
            if (Session["Username"] == null)
            {
                Session["Username"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                NHACUNGCAP ncc = db.NHACUNGCAPs.FirstOrDefault(p => p.MaNCC == id);
                if (Request.Form.Count == 0)
                {
                    return View(ncc);
                }
                string tenNcc = Request.Form["TenNCC"];
                string diachi = Request.Form["DiaChi"];
                string sdt = Request.Form["SDT"];
                string email = Request.Form["Email"];

                ncc.TenNCC = tenNcc;
                ncc.DiaChi = diachi;
                ncc.SDT = sdt;
                ncc.Email = email;

                db.SubmitChanges();
                return RedirectToAction("Index");
            }
        }
        [HandleError]
        public ActionResult Delete(string id)
        {
            if (Session["Username"] == null)
            {
                Session["Username"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var model = db.NHACUNGCAPs.SingleOrDefault(h => h.MaNCC.Equals(id));
                try
                {
                    if (model != null)
                    {
                        db.NHACUNGCAPs.DeleteOnSubmit(model);
                        db.SubmitChanges();
                        return RedirectToAction("Index", "Provider", new { error = "Xoá nhà cung cấp thành công." });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Provider", new { error = "Nhà cung cấp không tồn tại." });
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "Provider", new { error = "Không thể xoá loại sản phẩm." });
                }
            }
        }
    }
}

