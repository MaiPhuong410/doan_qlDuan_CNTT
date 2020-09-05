using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_qlDuan_CNTT.Areas.Admin.Models;
namespace doan_qlDuan_CNTT.Areas.Admin.Controllers
{
    public class ProducerController : Controller
    {
        AdminDataContext db = new AdminDataContext();
        // GET: Admin/Producer
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
                ViewBag.PdcError = error;
                return View(db.THUONGHIEUs.ToList());

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
        public ActionResult Create(THUONGHIEU createPdc)
        {
            if (Session["Username"] == null)
            {
                Session["Username"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
             
                    var pdc = db.THUONGHIEUs.SingleOrDefault(c => c.TenTH.Equals(createPdc.TenTH));
                    try
                    {
                        if (ModelState.IsValid)
                        {
                            if (pdc != null)
                            {
                                ViewBag.CreatePdcError = "Thương hiệu đã tồn tại.";
                            }
                            else
                            {
                                db.THUONGHIEUs.InsertOnSubmit(createPdc);
                                db.SubmitChanges();
                                ViewBag.CreatePdcError = "Thêm thương hiệu thành công.";
                            }
                        }
                    }
                    catch (Exception)
                    {
                        ViewBag.CreatePdcError = "Không thể thêm thương hiệu.";
                    }
                
                return View();
            }
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
                THUONGHIEU th = db.THUONGHIEUs.FirstOrDefault(p => p.MaTH == id);
                if (Request.Form.Count == 0)
                {
                    return View(th);
                }
                string tenTH = Request.Form["TenTH"];

                th.TenTH = tenTH;

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
                var model = db.THUONGHIEUs.SingleOrDefault(h => h.MaTH.Equals(id));
                try
                {
                    if (model != null)
                    {
                        db.THUONGHIEUs.DeleteOnSubmit(model);
                        db.SubmitChanges();
                        return RedirectToAction("Index", "Producer", new { error = "Xoá thương hiệu thành công." });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Producer", new { error = "Hãng thương hiệu không tồn tại." });
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "Producer", new { error = "Không thể xoá thương hiệu." });
                }
            }
        }
    }
}