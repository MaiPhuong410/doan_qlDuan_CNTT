using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan_qlDuan_CNTT.Areas.Store.Models;
using doan_qlDuan_CNTT.Areas.Store.ViewModels;

namespace doan_qlDuan_CNTT.Areas.Store.Models
{
    public class CartItem
    {
        public SANPHAM SanPham { get; set; }

        public int Sl { get; set; }
        public float ThanhTien
        {
            get
            {
                return (float)(Sl * SanPham.DonGiaMua);
            }
        }
    }
}