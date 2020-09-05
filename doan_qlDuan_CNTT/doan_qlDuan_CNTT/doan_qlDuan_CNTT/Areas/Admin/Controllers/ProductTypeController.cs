using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_qlDuan_CNTT.Areas.Admin.Models;


namespace doan_qlDuan_CNTT.Areas.Admin.Controllers
{
    public class ProductTypeController : Controller
    {
        AdminDataContext db = new AdminDataContext();
        // GET: Admin/ProductType
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
                return View(db.LOAISPs.ToList());
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
        public ActionResult Create(LOAISP createType)
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
                        db.LOAISPs.InsertOnSubmit(createType);
                        db.SubmitChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [HandleError]
        public ActionResult Edit(string maLoai)
        {
            if (Session["Username"] == null)
            {
                Session["Username"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                LOAISP lsp = db.LOAISPs.FirstOrDefault(p => p.MaLoai == maLoai);
                if (Request.Form.Count == 0)
                {
                    return View(lsp);
                }
                string tenLoai = Request.Form["TenLoai"];

                lsp.TenLoai = tenLoai;

                db.SubmitChanges();
                return RedirectToAction("Index");
            }
        }
        [HandleError]
        public ActionResult Delete(string maLoai)
        {
            if (Session["Username"] == null)
            {
                Session["Username"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var model = db.LOAISPs.SingleOrDefault(h => h.MaLoai.Equals(maLoai));
                try
                {
                    if (model != null)
                    {
                        db.LOAISPs.DeleteOnSubmit(model);
                        db.SubmitChanges();
                        return RedirectToAction("Index", "ProductType", new { error = "Xoá loại sản phẩm thành công." });
                    }
                    else
                    {
                        return RedirectToAction("Index", "ProductType", new { error = "Loại sản phẩm không tồn tại." });
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "ProductType", new { error = "Không thể xoá loại sản phẩm." });
                }
            }
        }
    }
}

