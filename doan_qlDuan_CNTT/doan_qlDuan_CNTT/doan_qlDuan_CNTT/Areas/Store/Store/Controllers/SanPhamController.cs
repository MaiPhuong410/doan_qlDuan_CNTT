using doan_qlDuan_CNTT.Areas.Store.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_qlDuan_CNTT.Areas.Store.ViewModels;
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
        
        // Sản phẩm chăm sóc da
        public ActionResult sp_Chamsocda(string searchString, FormCollection collections)
        {
            var dsSP = from sp in db.SANPHAMs
                       join lsp in db.LOAISPs on sp.MaLoai equals lsp.MaLoai
                       join th in db.THUONGHIEUs on sp.MaTH equals th.MaTH
                       join ncc in db.NHACUNGCAPs on sp.MaNCC equals ncc.MaNCC
                       where sp.MaLoai == "L0001" || sp.MaLoai == "L0002"
                       select new SanPhamViewModel()
                       {
                           MaSP = sp.MaSP,
                           TenSP = sp.TenSP,
                           DungTich = sp.DungTich,
                           DonGiaMua = sp.DonGiaMua,
                           XuatXu = sp.XuatXu,
                           QuiCach = sp.QuiCach,
                           MoTa = sp.MoTa,
                           HinhAnh = sp.HinhAnh,
                           TenLoai = lsp.TenLoai,
                           TenNCC = ncc.TenNCC,
                           TenTH = th.TenTH,
                           MaLoai = lsp.MaLoai,
                           MaNCC = ncc.MaNCC,
                           MaTH = th.MaTH
                       };
            dsSP.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                return View(dsSP.Where(sp => sp.TenSP.ToLower().Contains(searchString.ToLower()) && sp.MaLoai.Contains("L0001") 
                                    || sp.MaLoai.Contains("L0002")).ToList());
            }
            //if (collections.Count != 0)
            //{
            //    double min = double.Parse(collections["txtMin"]);
            //    double max = double.Parse(collections["txtMax"]);
            //    return View(dsSP.Where(sp => sp.DonGiaMua <= max && sp.DonGiaMua >= min).ToList());
            //}
            return View(dsSP);
        }
        public ActionResult xemChitiet_SP_skin(string id)
        {
            var dsSP = from sp in db.SANPHAMs
                       join lsp in db.LOAISPs on sp.MaLoai equals lsp.MaLoai
                       join th in db.THUONGHIEUs on sp.MaTH equals th.MaTH
                       join ncc in db.NHACUNGCAPs on sp.MaNCC equals ncc.MaNCC
                       where sp.MaLoai == "L0001" || sp.MaLoai=="L0002"
                       select new SanPhamViewModel()
                       {
                           MaSP = sp.MaSP,
                           TenSP = sp.TenSP,
                           DungTich = sp.DungTich,
                           DonGiaMua = sp.DonGiaMua,
                           XuatXu = sp.XuatXu,
                           QuiCach = sp.QuiCach,
                           MoTa = sp.MoTa,
                           HinhAnh = sp.HinhAnh,
                           TenLoai = lsp.TenLoai,
                           TenNCC = ncc.TenNCC,
                           TenTH = th.TenTH,
                           MaLoai = lsp.MaLoai,
                           MaNCC = ncc.MaNCC,
                           MaTH = th.MaTH
                       };
            SanPhamViewModel pro = new SanPhamViewModel();
            pro = dsSP.FirstOrDefault(p => p.MaSP.Equals(id));
            return View(pro);
        }

        // Sản phẩm trang điểm mặt
        public ActionResult sp_Trangdiemface(string searchString, FormCollection collections)
        {
            var dsSP = from sp in db.SANPHAMs
                       join lsp in db.LOAISPs on sp.MaLoai equals lsp.MaLoai
                       join th in db.THUONGHIEUs on sp.MaTH equals th.MaTH
                       join ncc in db.NHACUNGCAPs on sp.MaNCC equals ncc.MaNCC
                       where sp.MaLoai == "L0003"
                       select new SanPhamViewModel()
                       {
                           MaSP = sp.MaSP,
                           TenSP=sp.TenSP,
                           DungTich=sp.DungTich,
                           DonGiaMua=sp.DonGiaMua,
                           XuatXu = sp.XuatXu,
                           QuiCach=sp.QuiCach,
                           MoTa=sp.MoTa,
                           HinhAnh=sp.HinhAnh,
                           TenLoai=lsp.TenLoai,
                           TenNCC=ncc.TenNCC,
                           TenTH=th.TenTH,
                           MaLoai=lsp.MaLoai,
                           MaNCC=ncc.MaNCC,
                           MaTH=th.MaTH
                       };
            dsSP.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                return View(dsSP.Where(sp => sp.TenSP.ToLower().Contains(searchString.ToLower()) && sp.MaLoai.Contains("L0003")).ToList());
            }
            //if (collections.Count != 0)
            //{
            //    double min = double.Parse(collections["txtMin"]);
            //    double max = double.Parse(collections["txtMax"]);
            //    return View(dsSP.Where(sp => sp.DonGiaMua <= max && sp.DonGiaMua >= min).ToList());
            //}
                return View(dsSP);         
        }

        public ActionResult xemChitiet_SP_face(string id)
        {
            var dsSP = from sp in db.SANPHAMs
                       join lsp in db.LOAISPs on sp.MaLoai equals lsp.MaLoai
                       join th in db.THUONGHIEUs on sp.MaTH equals th.MaTH
                       join ncc in db.NHACUNGCAPs on sp.MaNCC equals ncc.MaNCC
                       where sp.MaLoai == "L0003"
                       select new SanPhamViewModel()
                       {
                           MaSP = sp.MaSP,
                           TenSP = sp.TenSP,
                           DungTich = sp.DungTich,
                           DonGiaMua = sp.DonGiaMua,
                           XuatXu = sp.XuatXu,
                           QuiCach = sp.QuiCach,
                           MoTa = sp.MoTa,
                           HinhAnh = sp.HinhAnh,
                           TenLoai = lsp.TenLoai,
                           TenNCC = ncc.TenNCC,
                           TenTH = th.TenTH,
                           MaLoai = lsp.MaLoai,
                           MaNCC = ncc.MaNCC,
                           MaTH = th.MaTH
                       };
            SanPhamViewModel pro = new SanPhamViewModel();
            pro = dsSP.FirstOrDefault(p => p.MaSP.Equals(id));
            return View(pro);
        }

        // Sản phẩm trang điểm mắt

        public ActionResult sp_TrangdiemEyes(string searchString, FormCollection collections)
        {
            var dsSP = from sp in db.SANPHAMs
                       join lsp in db.LOAISPs on sp.MaLoai equals lsp.MaLoai
                       join th in db.THUONGHIEUs on sp.MaTH equals th.MaTH
                       join ncc in db.NHACUNGCAPs on sp.MaNCC equals ncc.MaNCC
                       where sp.MaLoai == "L0004"
                       select new SanPhamViewModel()
                       {
                           MaSP = sp.MaSP,
                           TenSP = sp.TenSP,
                           DungTich = sp.DungTich,
                           DonGiaMua = sp.DonGiaMua,
                           XuatXu = sp.XuatXu,
                           QuiCach = sp.QuiCach,
                           MoTa = sp.MoTa,
                           HinhAnh = sp.HinhAnh,
                           TenLoai = lsp.TenLoai,
                           TenNCC = ncc.TenNCC,
                           TenTH = th.TenTH,
                           MaLoai = lsp.MaLoai,
                           MaNCC = ncc.MaNCC,
                           MaTH = th.MaTH
                       };
            dsSP.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                return View(dsSP.Where(sp => sp.TenSP.ToLower().Contains(searchString.ToLower()) && sp.MaLoai.Contains("L0004")).ToList());
            }
            //if (collections.Count != 0)
            //{
            //    double min = double.Parse(collections["txtMin"]);
            //    double max = double.Parse(collections["txtMax"]);
            //    return View(dsSP.Where(sp => sp.DonGiaMua <= max && sp.DonGiaMua >= min).ToList());
            //}
            return View(dsSP);
        }

        public ActionResult xemChitiet_SP_eyes(string id)
        {
            var dsSP = from sp in db.SANPHAMs
                       join lsp in db.LOAISPs on sp.MaLoai equals lsp.MaLoai
                       join th in db.THUONGHIEUs on sp.MaTH equals th.MaTH
                       join ncc in db.NHACUNGCAPs on sp.MaNCC equals ncc.MaNCC
                       where sp.MaLoai == "L0004"
                       select new SanPhamViewModel()
                       {
                           MaSP = sp.MaSP,
                           TenSP = sp.TenSP,
                           DungTich = sp.DungTich,
                           DonGiaMua = sp.DonGiaMua,
                           XuatXu = sp.XuatXu,
                           QuiCach = sp.QuiCach,
                           MoTa = sp.MoTa,
                           HinhAnh = sp.HinhAnh,
                           TenLoai = lsp.TenLoai,
                           TenNCC = ncc.TenNCC,
                           TenTH = th.TenTH,
                           MaLoai = lsp.MaLoai,
                           MaNCC = ncc.MaNCC,
                           MaTH = th.MaTH
                       };
            SanPhamViewModel pro = new SanPhamViewModel();
            pro = dsSP.FirstOrDefault(p => p.MaSP.Equals(id));
            return View(pro);
        }

        // Sản phẩm trang điểm môi

        public ActionResult sp_TrangdiemMoi(string searchString, FormCollection collections)
        {
            var dsSP = from sp in db.SANPHAMs
                       join lsp in db.LOAISPs on sp.MaLoai equals lsp.MaLoai
                       join th in db.THUONGHIEUs on sp.MaTH equals th.MaTH
                       join ncc in db.NHACUNGCAPs on sp.MaNCC equals ncc.MaNCC
                       where sp.MaLoai == "L0005" || sp.MaLoai == "L0006"
                       select new SanPhamViewModel()
                       {
                           MaSP = sp.MaSP,
                           TenSP = sp.TenSP,
                           DungTich = sp.DungTich,
                           DonGiaMua = sp.DonGiaMua,
                           XuatXu = sp.XuatXu,
                           QuiCach = sp.QuiCach,
                           MoTa = sp.MoTa,
                           HinhAnh = sp.HinhAnh,
                           TenLoai = lsp.TenLoai,
                           TenNCC = ncc.TenNCC,
                           TenTH = th.TenTH,
                           MaLoai = lsp.MaLoai,
                           MaNCC = ncc.MaNCC,
                           MaTH = th.MaTH
                       };
            dsSP.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                // Tìm kiếm không phân biệt chữ hoa, chữ thường, tìm kiếm sản phẩm theo loại tương ứng.
                return View(dsSP.Where(sp => sp.TenSP.ToLower().Contains(searchString.ToLower()) && sp.MaLoai.Contains("L0005") || sp.MaLoai.Contains("L0006")).ToList());
            }
            //if (collections.Count != 0)
            //{
            //    double min = double.Parse(collections["txtMin"]);
            //    double max = double.Parse(collections["txtMax"]);
            //    return View(dsSP.Where(sp => sp.DonGiaMua <= max && sp.DonGiaMua >= min).ToList());
            //}
            return View(dsSP);
        }

        public ActionResult xemChitiet_SP_lips(string id)
        {
            var dsSP = from sp in db.SANPHAMs
                       join lsp in db.LOAISPs on sp.MaLoai equals lsp.MaLoai
                       join th in db.THUONGHIEUs on sp.MaTH equals th.MaTH
                       join ncc in db.NHACUNGCAPs on sp.MaNCC equals ncc.MaNCC
                       where sp.MaLoai == "L0005" || sp.MaLoai=="L0006"
                       select new SanPhamViewModel()
                       {
                           MaSP = sp.MaSP,
                           TenSP = sp.TenSP,
                           DungTich = sp.DungTich,
                           DonGiaMua = sp.DonGiaMua,
                           XuatXu = sp.XuatXu,
                           QuiCach = sp.QuiCach,
                           MoTa = sp.MoTa,
                           HinhAnh = sp.HinhAnh,
                           TenLoai = lsp.TenLoai,
                           TenNCC = ncc.TenNCC,
                           TenTH = th.TenTH,
                           MaLoai = lsp.MaLoai,
                           MaNCC = ncc.MaNCC,
                           MaTH = th.MaTH
                       };
            SanPhamViewModel pro = new SanPhamViewModel();
            pro = dsSP.FirstOrDefault(p => p.MaSP.Equals(id));
            return View(pro);
        }

        
    }
}