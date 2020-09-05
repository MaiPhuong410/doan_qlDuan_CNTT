using doan_qlDuan_CNTT.Areas.Store.Models;
using doan_qlDuan_CNTT.Areas.Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace doan_qlDuan_CNTT.Areas.Store.Controllers
{
    public class GioHangController : Controller
    {
        // GET: Store/GioHang

        QLCHDataContext db = new QLCHDataContext();
        private const string CartSession = "CartSession";
        public ActionResult GioHang()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public ActionResult ThemVaoGio(string id)
        {

            
            SANPHAM sp = db.SANPHAMs.FirstOrDefault(x => x.MaSP.Contains(id));
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.SanPham.MaSP.Contains(id)))
                {
                    foreach (var item in list)
                    {
                        if (item.SanPham.MaSP.Contains(id))
                        {
                            item.Sl++;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.SanPham = sp;
                    item.Sl = 1;
                    list.Add(item);
                }
                //gắn vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.SanPham = sp;
                item.Sl = 1;
                var list = new List<CartItem>();
                list.Add(item);
                //gắn vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("GioHang");
        }

        //Sửa số lượng
        public ActionResult SuaSoLuong(string SanPhamID, int soluongmoi)
        {
            // tìm carditem muốn sửa
            var giohang = (List<CartItem>)Session[CartSession];
            CartItem itemSua = giohang.FirstOrDefault(m => m.SanPham.MaSP.Contains(SanPhamID));
            if (itemSua != null)
            {
                if (soluongmoi < 1 || soluongmoi > 100)
                {

                }
                else
                {
                    @ViewBag.GioError = "";
                    itemSua.Sl = soluongmoi;
                }
            }
            Session[CartSession] = giohang;
            return RedirectToAction("GioHang");
        }

        // xóa cartitem không mong muốn
        public ActionResult XoaKhoiGio(string SanPhamID)
        {
            var giohang = (List<CartItem>)Session[CartSession];
            giohang.RemoveAll(x => x.SanPham.MaSP.Contains(SanPhamID));
            return RedirectToAction("GioHang");


        }

    }
}