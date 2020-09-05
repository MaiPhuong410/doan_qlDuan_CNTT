create proc SPBanChay
as
begin
	SELECT top 1 with ties SP.MASP, TENSP,lsp.TenLoai,th.TenTH,HinhAnh
	FROM SANPHAM SP, CTDONHANG CTDH, LOAISP lsp, THUONGHIEU th
	WHERE  SP.MASP = CTDH.MASP and SP.MaLoai=lsp.MaLoai and SP.MaTH=th.MaTH
	GROUP BY SP.MASP, TENSP,lsp.TenLoai,th.TenTH,HinhAnh
	ORDER BY count (CTDH.MaSP) DESC
end

create proc XemDonHang
as
	begin
	select MaDH, NgayMua, NgayDuKienGiao, MaKH, iif([TinhTrang]='0', N'Chưa giao hàng', N'Đã giao hàng') as [TinhTrang]
	from DONHANG
end

create proc SPBanIt
as
begin
	SELECT top 1 with ties SP.MASP, TENSP,lsp.TenLoai,th.TenTH,HinhAnh
	FROM SANPHAM SP, CTDONHANG CTDH, LOAISP lsp, THUONGHIEU th
	WHERE  SP.MASP = CTDH.MASP and SP.MaLoai=lsp.MaLoai and SP.MaTH=th.MaTH
	GROUP BY SP.MASP, TENSP,lsp.TenLoai,th.TenTH,HinhAnh
	ORDER BY count (CTDH.MaSP) ASC
end

	

