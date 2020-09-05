using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using doan_qlDuan_CNTT.Areas.Admin.Models;

namespace doan_qlDuan_CNTT.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        AdminDataContext db = new AdminDataContext();
      
        // GET: Admin/Product
        [HandleError]
        public ActionResult Index(string error, string name)
        {
            if (Session["Username"] == null)
            {
                Session["Username"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.ProError = error;
                var model = from sp in db.SANPHAMs select sp;
                if (!string.IsNullOrEmpty(name))
                {
                    model = model.Where(p => p.TenSP.Contains(name));
                }
                return View(model);
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
                //ViewBag.typeListCreate = new SelectList(db.LOAISPs, "MaLoai", "TenLoai");
                //ViewBag.thListCreate = new SelectList(db.THUONGHIEUs, "MaTH", "TenTH");
                //ViewBag.nccListCreate = new SelectList(db.NHACUNGCAPs, "MaNCC", "TenNCC");


                return View();
            }
        }

        [HandleError]
        [HttpPost]
        public ActionResult Create(SANPHAM createPro, HttpPostedFileBase file)
        {
            if (Session["Username"] == null)
            {
                Session["Username"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var pro = db.SANPHAMs.SingleOrDefault(c => c.MaSP.Equals(createPro.MaSP));
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        try
                        {
                            string nameFile = Path.GetFileName(file.FileName);
                            file.SaveAs(Path.Combine(Server.MapPath("/Images"), nameFile));
                            createPro.HinhAnh = "/Images/" + nameFile;
                        }
                        catch (Exception)
                        {
                            ViewBag.CreateProError = "Không thể chọn ảnh.";
                        }
                    }
                    try
                    {
                        if (pro != null)
                        {
                            ViewBag.CreateProError = "Mã sản phẩm đã tồn tại.";
                        }
                        else
                        {
                                db.SANPHAMs.InsertOnSubmit(createPro);
                                db.SubmitChanges();                            
                                ViewBag.CreateProError = "Thêm sản phẩm thành công.";
                        }
                    }
                    catch (Exception )
                    {
                        ViewBag.CreateProError = "Không thể thêm sản phẩm.";
                    }
                }
                else
                {
                    ViewBag.HinhAnh = "Vui lòng chọn hình ảnh.";
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
                //ViewBag.typeListEdit = new SelectList(db.LOAISPs, "MaLoai", "TenLoai");
                //ViewBag.thListEdit = new SelectList(db.THUONGHIEUs, "MaTH", "TenTH");
                //ViewBag.nccListEdit = new SelectList(db.NHACUNGCAPs, "MaNCC", "TenNCC");
                SANPHAM sp = db.SANPHAMs.FirstOrDefault(x => x.MaSP == id);
                if (Request.Form.Count == 0)
                {
                    return View(sp);
                }
                sp.MaSP = Request.Form["MaSP"];
                sp.TenSP = Request.Form["TenSP"];
                sp.DungTich = (Request.Form["DungTich"]);
                sp.DonGiaMua = float.Parse(Request.Form["DonGiaMua"]);
                sp.XuatXu = (Request.Form["XuatXu"]);
                sp.QuiCach = (Request.Form["QuiCach"]);
                sp.MoTa = (Request.Form["MoTa"]);
                sp.MaLoai = (Request.Form["MaLoai"]);
                sp.MaNCC = (Request.Form["MaNCC"]);
                sp.MaTH = (Request.Form["MaTH"]);
                HttpPostedFileBase file = Request.Files["HinhAnh"];
                if (file != null && file.FileName != "")
                {
                    string serverPath = HttpContext.Server.MapPath("~/Images");
                    var fileName = Path.GetFileName(file.FileName);
                    string filePath = serverPath + "/" + fileName;
                    file.SaveAs(filePath);
                    sp.HinhAnh = fileName;
                }
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
                var model = db.SANPHAMs.SingleOrDefault(h => h.MaSP.Equals(id));
                try
                {
                    if (model != null)
                    {
                        db.SANPHAMs.DeleteOnSubmit(model);
                        db.SubmitChanges();
                        return RedirectToAction("Index", "Product", new { error = "Xoá sản phẩm thành công." });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Product", new { error = "Sản phẩm không tồn tại." });
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "Product", new { error = "Không thể xoá sản phẩm." });
                }
            }
        }

        public ActionResult Details(string id)
        {
            if (Session["Username"] == null)
            {
                Session["Username"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var model = db.SANPHAMs.SingleOrDefault(p => p.MaSP.Equals(id));
                return View(model);
            }
        }
        public ActionResult SPBanChay()
        {
            if (Session["Username"] == null)
            {
                Session["Username"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                List<SPBanChayResult> sp = db.SPBanChay().ToList();
                return View(sp);
            }        
        }
        public ActionResult SPBanIt()
        {
            if (Session["Username"] == null)
            {
                Session["Username"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                List<SPBanItResult> sp = db.SPBanIt().ToList();
                return View(sp);
            }
        }
    }
}
    