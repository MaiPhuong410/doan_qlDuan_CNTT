using doan_qlDuan_CNTT.Areas.Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace doan_qlDuan_CNTT.Areas.Store.Controllers
{
    public class ThanhToanController : Controller
    {
        // GET: Store/ThanhToan
        QLCHDataContext db = new QLCHDataContext();
        private const string CartSession = "CartSession";
        public ActionResult ThanhToan()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;

            }
            return View(list);
        }

        [HttpPost]
        public ActionResult StepEnd()
        {
            //Nhận reqest từ trang index
            string phone = Request.Form["phone"];
            string fullname = Request.Form["fullname"];
            string email = Request.Form["email"];
            string address = Request.Form["address"];
            string note = Request.Form["note"];
            //kiểm tra xem có customer chưa và cập nhật lại
            KHACHHANG newCus = new KHACHHANG();
            var cus = db.KHACHHANGs.FirstOrDefault(p => p.SDT.Equals(phone));
            if (cus != null)
            {
                //nếu có số điện thoại trong db rồi
                //cập nhật thông tin và lưu
                cus.HoTen = fullname;

                cus.DiaChi = address;

                db.SubmitChanges();
            }
            else
            {

                //nếu chưa có sđt trong db
                //thêm thông tin và lưu
                newCus.HoTen = fullname;
                newCus.DiaChi = address;
                newCus.SDT = phone;
                newCus.MaCapDo = 1;
                db.KHACHHANGs.InsertOnSubmit(newCus);
                db.SubmitChanges();
            }
            //Thêm thông tin vào order và orderdetail

            List<CartItem> giohang = Session[CartSession] as List<CartItem>;

            //thêm order mới
            DONHANG newOrder = new DONHANG();

            newOrder.NgayMua = DateTime.Now;
            newOrder.NgayDuKienGiao = DateTime.Now;
            newOrder.TinhTrang = false;
            if(cus != null)
            {
                newOrder.MaKH = cus.MaKH;
            }
            else
            {
                newOrder.MaKH = newCus.MaKH;
            }
            db.DONHANGs.InsertOnSubmit(newOrder);
            db.SubmitChanges();
            //thêm chi tiết
            for (int i = 0; i < giohang.Count; i++)
            {
                CTDONHANG newOrdts = new CTDONHANG();

                newOrdts.MaDH = newOrder.MaDH;
                newOrdts.MaSP = giohang.ElementAtOrDefault(i).SanPham.MaSP;
                newOrdts.SoLuong = giohang.ElementAtOrDefault(i).Sl;
                newOrdts.DGBan = giohang.ElementAtOrDefault(i).SanPham.DonGiaMua;
                newOrdts.ThanhTien = giohang.ElementAtOrDefault(i).ThanhTien;
                db.CTDONHANGs.InsertOnSubmit(newOrdts);
                db.SubmitChanges();
            }
            Session["MHD"] = "HD" + newOrder.MaDH;
            Session["Phone"] = phone;
            Session["Name"] = fullname;
            Session["Address"] = address;
            //xoá sạch giỏ hàng
            giohang.Clear();
            giohang.Clear();
            return Content("Đơn hàng của bạn đã được tiếp nhận!"); 
        }

        public ActionResult HoaDon()
        {
            return View("HoaDon");
        }
    }
}