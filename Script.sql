/*
Created		01/09/2020
Modified		01/09/2020
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/
create database QLCH
use QLCH 
go

Create table [LOAISP]
(
	[MaLoai] Char(5) NOT NULL,
	[TenLoai] Nvarchar(20) NULL,
Primary Key ([MaLoai])
) 
go

Create table [SANPHAM]
(
	[MaSP] Char(5) NOT NULL,
	[TenSP] Nvarchar(100) NULL,
	[DungTich] Char(10) NULL,
	[DonGiaMua] Float NULL,
	[XuatXu] Nvarchar(20) NULL,
	[QuiCach] Nvarchar(15) NULL,
	[MoTa] NText NULL,
	[MaLoai] Char(5) NOT NULL,
	[MaNCC] Char(5) NOT NULL,
	[MaTH] Char(5) NOT NULL,
	[HinhAnh] nvarchar(MAX),
Primary Key ([MaSP])
) 
go

Create table [NHACUNGCAP]
(
	[MaNCC] Char(5) NOT NULL,
	[TenNCC] Nvarchar(20) NULL,
	[DiaChi] Nvarchar(20) NULL,
	[SDT] Char(10) NULL,
	[Email] varchar(50),
Primary Key ([MaNCC])
) 
go

Create table [THUONGHIEU]
(
	[MaTH] Char(5) NOT NULL,
	[TenTH] Nvarchar(20) NULL,
Primary Key ([MaTH])
) 
go

Create table [DONDATHANG]
(
	[MaDDH] Char(5) NOT NULL,
	[NgayLap] Datetime NULL,
	[MaNCC] Char(5) NOT NULL,
	[MaTT] Bit NOT NULL,
Primary Key ([MaDDH])
) 
go

Create table [KHACHHANG]
(
	[MaKH] int identity(1,1) NOT NULL,
	[HoTen] Nvarchar(20) NULL,
	[DiaChi] Nvarchar(15) NULL,
	[SDT] Char(10) NULL,
	[MaCapDo] int NOT NULL,
Primary Key ([MaKH])
) 
drop table [KHACHHANG]
go

Create table [PHIEUGIAOHANG]
(
	[SoPhieuGiao] Char(5) NOT NULL,
	[NgayGiao] Datetime NULL,
Primary Key ([SoPhieuGiao])
) 
go

Create table [AccountAdmin]
(
	[UserName] Char(10) NOT NULL,
	[Password] Char(15) NULL,
Primary Key ([UserName])
) 
alter table [AccountAdmin] alter column [Password] varchar(30)
go

Create table [DONHANG]
(
	[MaDH] int identity(1,1) NOT NULL,
	[NgayMua] Datetime NULL,
	[NgayDuKienGiao] Datetime NULL,
	[TinhTrang] Bit NULL,
	[MaKH] int NOT NULL,
Primary Key ([MaDH])
) 
drop table [DONHANG]
go

Create table [CapDoThanhVien]
(
	[MaCapDo] int identity(1,1) NOT NULL,
	[TenCapDo] Nvarchar(30) NULL,
Primary Key ([MaCapDo])
) 
drop table [CapDoThanhVien]
go

Create table [KHUYENMAI]
(
	[MaKM] Char(5) NOT NULL,
	[LoaiKM] Nvarchar(30) NULL,
	[GTKM] Integer NULL,
	[MaCapDo] int NOT NULL,
Primary Key ([MaKM])
) 
drop table [KHUYENMAI]
go

Create table [CTDDH]
(
	[MaDDH] Char(5) NOT NULL,
	[MaSP] Char(5) NOT NULL,
	[SoLuong] Integer NULL,
Primary Key ([MaDDH],[MaSP])
) 
go

Create table [CTPHIEUGIAO]
(
	[MaDDH] Char(5) NOT NULL,
	[SoPhieuGiao] Char(5) NOT NULL,
	[SLGiao] Integer NULL,
	[DGGiao] Float NULL,
	[ThanhTien] Float NULL,
Primary Key ([MaDDH],[SoPhieuGiao])
) 
go

Create table [CTDONHANG]
(
	[MaSP] Char(5) NOT NULL,
	[MaDH] int NOT NULL,
	[SoLuong] Integer NULL,
	[DGBan] Float NULL,
	[ThanhTien] Float NULL,
Primary Key ([MaSP],[MaDH])
) 
drop table [CTDONHANG]
go


Alter table [SANPHAM] add  foreign key([MaLoai]) references [LOAISP] ([MaLoai])  on update no action on delete no action 
go
Alter table [CTDDH] add  foreign key([MaSP]) references [SANPHAM] ([MaSP])  on update no action on delete no action 
go
Alter table [CTDONHANG] add  foreign key([MaSP]) references [SANPHAM] ([MaSP])  on update no action on delete no action 
go
Alter table [SANPHAM] add  foreign key([MaNCC]) references [NHACUNGCAP] ([MaNCC])  on update no action on delete no action 
go
Alter table [DONDATHANG] add  foreign key([MaNCC]) references [NHACUNGCAP] ([MaNCC])  on update no action on delete no action 
go
Alter table [SANPHAM] add  foreign key([MaTH]) references [THUONGHIEU] ([MaTH])  on update no action on delete no action 
go
Alter table [CTDDH] add  foreign key([MaDDH]) references [DONDATHANG] ([MaDDH])  on update no action on delete no action 
go
Alter table [CTPHIEUGIAO] add  foreign key([MaDDH]) references [DONDATHANG] ([MaDDH])  on update no action on delete no action 
go
Alter table [DONHANG] add  foreign key([MaKH]) references [KHACHHANG] ([MaKH])  on update no action on delete no action 
go
Alter table [CTPHIEUGIAO] add  foreign key([SoPhieuGiao]) references [PHIEUGIAOHANG] ([SoPhieuGiao])  on update no action on delete no action 
go
Alter table [CTDONHANG] add  foreign key([MaDH]) references [DONHANG] ([MaDH])  on update no action on delete no action 
go
Alter table [KHACHHANG] add  foreign key([MaCapDo]) references [CapDoThanhVien] ([MaCapDo])  on update no action on delete no action 
go
Alter table [KHUYENMAI] add  foreign key([MaCapDo]) references [CapDoThanhVien] ([MaCapDo])  on update no action on delete no action 
go


Set quoted_identifier on
go


Set quoted_identifier off
go

--NHAP DU LIEU BANG ACCOUNTADMIN
INSERT INTO AccountAdmin (UserName, Password) VALUES ('admin','6CMbfolFR1Kwq2PJOewmzA==')
--NHAP DU LIEU BANG LOAISP
INSERT INTO LOAISP (MaLoai,TenLoai) VALUES ('L0001',N'Chăm sóc da')
INSERT INTO LOAISP (MaLoai,TenLoai) VALUES ('L0002',N'Làm sạch da')
INSERT INTO LOAISP (MaLoai,TenLoai) VALUES ('L0003',N'Trang điểm mặt')
INSERT INTO LOAISP (MaLoai,TenLoai) VALUES ('L0004',N'Trang điểm mắt')
INSERT INTO LOAISP (MaLoai,TenLoai) VALUES ('L0005',N'Son môi')
INSERT INTO LOAISP (MaLoai,TenLoai) VALUES ('L0006',N'Son dưỡng')
--NHAP DU LIEU BANG THUONGHIEU
INSERT INTO THUONGHIEU (MaTH,TenTH) VALUES ('TH001','MAC')
INSERT INTO THUONGHIEU (MaTH,TenTH) VALUES ('TH002','Maybelline')
INSERT INTO THUONGHIEU (MaTH,TenTH) VALUES ('TH003','Loreal')
INSERT INTO THUONGHIEU (MaTH,TenTH) VALUES ('TH004','Innisfree')
INSERT INTO THUONGHIEU (MaTH,TenTH) VALUES ('TH005','Bioderma')
INSERT INTO THUONGHIEU (MaTH,TenTH) VALUES ('TH006','Lanegie')
INSERT INTO THUONGHIEU (MaTH,TenTH) VALUES ('TH007','Shu Uemura')
--NHAP DU LIEU BANG NHACUNGCAP
INSERT INTO NHACUNGCAP (MaNCC,TenNCC,DiaChi,SDT,Email) VALUES ('NCC01','Bicicosmetics',N'Quận 10, TPHCM', '0909904560','bicicosmetics@gmail.com')
INSERT INTO NHACUNGCAP (MaNCC,TenNCC,DiaChi,SDT,Email) VALUES ('NCC02','Boshop',N'Quận Bình Thạnh', '19007101','boshop92@gmail.com')
INSERT INTO NHACUNGCAP (MaNCC,TenNCC,DiaChi,SDT,Email) VALUES ('NCC03','Wholemartcosmetic',N'Quận Tân Bình', '0871099333','wholemart.cosmetic111@gmail.com')
INSERT INTO NHACUNGCAP (MaNCC,TenNCC,DiaChi,SDT,Email) VALUES ('NCC04','Bigmamacosmetics',N'Quận Bình Thạnh', '0286660810','bigmama@bigmamacosmetics.vn')
INSERT INTO NHACUNGCAP (MaNCC,TenNCC,DiaChi,SDT,Email) VALUES ('NCC05','Myphamhanquochcm',N'Quận Gò Vấp', '0906278197','myphamhanquochcm5@gmail.com')
--NHAP DU LIEU BANG SANPHAM
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP001',N'Mặt nạ đất sét Innisfree','100ml','193000',N'Hàn Quốc',N'Hủ',N'Loại bỏ bã nhờn, làm sạch sâu, loại bỏ các tạp chất. Tiêu diệt sạch mụn cám và mụn đầu đen','L0001','NCC05','TH004','sp001.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP002',N'Mặt nạ lột mụn hút bã nhờn Innisfree','100ml','219000',N'Hàn Quốc',N'Tuýp',N'Được chiết xuất từ nguyên liệu tro núi lửa mới Jeju Spcanic Pine Spear TM có khả năng loại bỏ bã nhờn mạnh mẽ hơn so với loại tro núi lửa hiện tại. Do đó, Innisfree Super Peel Off Mask 2X được sử dụng để làm sạch và giúp lỗ chân lông được thông thoáng. Sử dụng bằng cách lột bỏ lớp mặt nạ sau khi bôi.','L0001','NCC05','TH004','sp002.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP003',N'Mặt nạ giấy dưỡng chất cô đặc','30g','47000',N'Pháp',N'Cái',N'Dưỡng chất cô đặc trong mặt nạ có kết cấu nhanh chóng được chuyển hóa thành nước, cho khả năng hấp thụ vượt trội cùng với sự kết hợp đặc biệt giữa hoạt chất dưỡng da, tinh dầu dưỡng cùng nước suối khoáng Pháp mang lại sức mạnh 3 lần dưỡng ẩm chuyên sâu. Làn da bạn sẽ được phục hồi, dưỡng ẩm căng mịn và rạng ngời mà không hề bóng nhờn sau mỗi lần sử dụng.','L0001','NCC01','TH003','sp003.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP004',N'Sữa rửa mặt','100ml','179000',N'Indonesia',N'Tuýp',N'Làm sạch da hoàn toàn: với hoạt chất LHA giúp loại bỏ triệt để bụi bẩn, bã nhờn và lớp trang điểm.Giúp làn da mềm mại, săn chắc và tươi trẻ: được tăng cường với hoạt chất Glycerin, là bước khởi đầu hoàn hảo cho quá trình dưỡng da tươi trẻ của bạn.','L0002','NCC01','TH003','sp004.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP005',N'Sữa rửa mặt Lanegie','30ml','130000',N'Hàn Quốc',N'Tuýp',N'Sữa rửa mặt làm sạch sâu lỗ chân lông với chiết xuất enzym từ quả đu đủ và blue berry giúp làm sạch tàn dư makeup, kem chống nắng, bụi bẩn và tế bào da chết.','L0002','NCC01','TH006','sp005.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP006',N'Sữa rửa mặt Bioderma Sebium Gel Moussant','200ml','395000',N'Pháp',N'Chai',N'với thành phần Kẽm Sulfate và Đồng Sulfate giúp bạn làm sạch da và ngăn ngừa bít tắc lỗ chân lông. Từ đó đem lại cho bạn một làn da sáng mịn, tràn đầy sức sống. Một loại sữa rửa mặt rất đáng để chị em trải nghiệm trong thời tiết hanh khô của mùa đông lạnh giá vì không làm khô da, chống lão hóa, độ pH hoàn hảo không phá vỡ lớp màng ẩm bảo vệ da.','L0002','NCC02','TH005','sp006.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP007',N'Dầu tẩy trang Shu Uemura Ultime8 Sublime Beauty Cleansing Oil ','450ml','2500000',N'Nhật Bản',N'Chai',N'Shu Uemura Ultime8 Sublime Beauty kết hợp tinh túy 8 chiết xuất dầu thực vật giàu khả năng làm sạch và cấp ẩm nhẹ dịu, để sau khi cuốn bay đi lớp trang điểm, bụi bẩn trên da, còn lại là lớp cấp ẩm cho da mềm mại, mượt mà, tươi trẻ.','L0002','NCC04','TH007','sp007.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP008',N'Dầu Tẩy Trang Shu Uemura Cleansing Oil Ultimate ','50ml','245000',N'Nhật Bản',N'Chai',N'Dầu tẩy trang Shu Uemura màu xanh lá , được chiết xuất từ trà xanh, vừa có công dụng tẩy sạch nhẹ nhàng lớp trang điểm vừa có tính chất kháng khuẩn cao, giúp chống lão hóa...','L0002','NCC04','TH007','sp008.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP009',N'Nước Tẩy Trang Bioderma Sesbium H20 Solution Micellaire','250ml','350000',N'Pháp',N'Chai',N'Chiết xuất từ Bạch quả để điều tiết lượng dầu trên da, Zinc và Sulfate vốn có tính sát khuẩn rất tốt cho da dầu mụn không hở. Làm sạch và loại bỏ lớp trang điểm vùng mặt và mắt','L0002','NCC02','TH005','sp009.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP010',N'Mặt nạ tẩy tế bào chết Innisfree','120ml','285000',N'Hàn Quốc',N'Tuýp',N'Tẩy da chết Innisfree Green Barley Gommage Peeling Mask được chiết xuất từ tinh chất sữa non và hạt mầm lúa mạch còn xanh của đảo Jeju Hàn Quốc, chứa đựng dưỡng chất và protein gấp 10 lần cây gạo, giúp làm sạch và loại bỏ hoàn toàn lớp da chết bị xỉn màu đồng thời nuôi dưỡng làn da trắng sáng đều màu chỉ sau 3 tuần sử dụng.','L0002','NCC02','TH004','sp010.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP011',N'Kem che khuyết điểm Maybelline','6ml','196000',N'Mỹ',N'Bút Cushion',N'Giúp che phủ hoàn hảo các loại khuyết điểm và giúp giảm bọng mắt, quầng thâm. Bút cushion che khuyết điểm Instant Age Rewind với đầu bút cushion độc đáo giúp kem len lỏi và che phủ trệt để các khuyết điểm mà tay thường hay các dụng cụ khác không làm được.','L0003','NCC01','TH002','sp011.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP012',N'Kem che khuyết điểm MAC','7ml','480000',N'Mỹ',N'Hộp',N'Kem che khuyết điểm Mac Studio finish concealer là sản phẩm giúp che phủ tốt các vết thâm nám, tàn nhang, mụn, sẹo và các vùng da không đều màu. Kem che khuyết điểm có chống nắng thích hợp dùng hằng ngày. Sản phẩm được giới trang điểm chuyên nghiệp tin dùng.','L0003','NCC01','TH001','sp012.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP013',N'Phấn Nền Shu Uemura Petal Skin Cushion ','13g','1000000',N'Nhật Bản',N'Hộp',N'Phấn nền Petal Skin Cushion mang tới lớp trang điểm mỏng mịn tự nhiên và rạng rỡ như cánh hoa với công nghệ vượt trội.','L0003','NCC03','TH007','sp013.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP014',N'PHẤN NƯỚC MY TO GO CUSHION INNISFREE','13g','365000',N'Hàn Quốc',N'Hộp',N'Chiết xuất từ bột tro núi lửa Jeju,công nghệ che phủ tự nhiên. Độ chống nắng SPF35 PA++. Dễ dàng sử dụng mọi lúc, mọi nơi. Độ che phủ khá, không quá dày giúp bạn thoải mái, cảm giác lớp nền nhẹ tênh.','L0003','NCC03','TH004','sp014.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP015',N'Phấn má hồng Laneige Ideal Blush Duo','8g','600000',N'Hàn Quốc',N'Hộp',N'phấn má hồng Laneige Ideal Blush Duo mang lại làn da tươi sáng với màu sắc tự nhiên, đồng thời lưu giữ lớp trang điểm bền màu trong nhiều giờ liền.','L0003','NCC03','TH006','sp015.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP016',N'Phấn Má Hồng Maybelline','4.5g','96000',N'Mỹ',N'Hộp',N'Giúp tô điểm tông da của bạn với màu sắc má hồng tự nhiên, hoà hợp với nước da sẵn có. Màu sắc nhẹ nhàng, tự nhiên nhưng có khả năng bền màu trên da suốt cả ngày dài.','L0003','NCC04','TH002','sp016.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP017',N'Phấn Mắt Maybelline The Blushed Nudes Palette','9.6g','290000',N'Mỹ',N'Hộp',N'Maybelline The Blushed Nudes Palette gồm 12 màu phấn mắt tông hồng nude. Phù hợp với mọi tông màu da. Giúp bạn dễ dàng phối hợp tạo nhiều phong cách trang điểm khác nhau.','L0004','NCC04','TH002','sp017.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP018',N'Phấn Mắt LOreal Paradise Enchanted No.150','7g','350000',N'Pháp',N'Hộp',N'Gồm 12 tone màu từ ấm áp quyến rũ. Chất phấn mềm mịn, dễ sử dụng. Khả năng bám màu cực tốt, độ lan màu cao.','L0004','NCC02','TH003','sp018.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP019',N'Chì Kẻ Mày Maybelline Define & Blend','2g','128000',N'Mỹ',N'Bút',N'Sản phẩm với 2 đầu: 1 đầu chì mảnh, dễ kẻ nhưng không quá mềm hoặc quá cứng, giúp cho các nét vẽ dễ dàng, tự nhiên và sắc sảo hơn; 1 đầu lông chải giúp tán đều các nét vẽ.','L0004','NCC01','TH002','sp019.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP020',N'Son Môi Mac Matte Lipstick Rouge','2g','450000',N'Mỹ',N'Cây',N'Son Môi Mac Matte Lipstick Rouge cho bạn đôi môi đẹp quyến rũ. Chất son lì mịn, khả năng bám màu tốt, son lên màu cực chuẩn','L0005','NCC01','TH001','sp020.jpg') 
INSERT INTO SANPHAM (MaSP,TenSP,DungTich,DonGiaMua,XuatXu,QuiCach,MoTa,MaLoai,MaNCC,MaTH, HinhAnh) 
	VALUES ('SP021',N'Son Shu Uemura','2g','630000',N'Nhật Bản',N'Cây',N'Son shu Uemura Rouge Unlimited Matte Nhật Bản chiết xuất tự nhiên chất son Shu cổ điển nhưng cần độ lì hơn, matte vào môi và bám màu hơn, phù hợp với các chị em có màu da môi sậm màu, khó lên màu.','L0005','NCC01','TH007','sp021.jpg') 

--NHAP DU LIEU BANG CAPDOTHANHVIEN
INSERT INTO CapDoThanhVien (TenCapDo) VALUES (N'Thành viên Đồng')
INSERT INTO CapDoThanhVien (TenCapDo) VALUES (N'Thành viên Bạc')
INSERT INTO CapDoThanhVien (TenCapDo) VALUES (N'Thành viên Vàng')
INSERT INTO CapDoThanhVien (TenCapDo) VALUES (N'Thành viên Kim cương')

--NHAP DU LIEU BANG KHACHHANG
INSERT INTO KHACHHANG (HoTen,DiaChi,SDT,MaCapDo) VALUES (N'Nguyễn Thị Hoa',N'Quận 1','0964524356',1)
INSERT INTO KHACHHANG (HoTen,DiaChi,SDT,MaCapDo) VALUES (N'Nguyễn Thị Hoa Quỳnh',N'Quận 10','0946786321',3)
INSERT INTO KHACHHANG (HoTen,DiaChi,SDT,MaCapDo) VALUES (N'Nguyễn Thị Mỹ Lan',N'Quận Gò Vấp','0357656444',4)
INSERT INTO KHACHHANG (HoTen,DiaChi,SDT,MaCapDo) VALUES (N'Trần Thị Ngọc Huệ',N'Quận Bình Thạnh','0919365897',2)
INSERT INTO KHACHHANG (HoTen,DiaChi,SDT,MaCapDo) VALUES (N'Phan Nguyễn Tường Vy',N'Quận Thủ Đức','096234654',2)

--NHAP DU LIEU BANG KHUYENMAI
INSERT INTO KHUYENMAI (MaKM,LoaiKM,GTKM,MaCapDo) VALUES ('KM001',N'Tri ân thành viên Đồng','10',1)
INSERT INTO KHUYENMAI (MaKM,LoaiKM,GTKM,MaCapDo) VALUES ('KM002',N'Tri ân thành viên Bạc','25',2)
INSERT INTO KHUYENMAI (MaKM,LoaiKM,GTKM,MaCapDo) VALUES ('KM003',N'Tri ân thành viên Vàng','50',3)
INSERT INTO KHUYENMAI (MaKM,LoaiKM,GTKM,MaCapDo) VALUES ('KM004',N'Tri ân thành viên Kim Cương','70',4)
set dateformat dmy
--NHAP DU LIEU BANG DONDATHANG (0-CHUA GIAO DU/1-DA GIAO DU)
INSERT INTO DONDATHANG (MaDDH,MaNCC,NgayLap,MaTT) VALUES ('DDH01','NCC01','15/6/2020',0)
INSERT INTO DONDATHANG (MaDDH,MaNCC,NgayLap,MaTT) VALUES ('DDH02','NCC05','18/7/2020',1)
INSERT INTO DONDATHANG (MaDDH,MaNCC,NgayLap,MaTT) VALUES ('DDH03','NCC02','25/8/2020',1)

--NHAP DU LIEU BANG CTDDH
INSERT INTO CTDDH (MaDDH,MaSP,SoLuong) VALUES ('DDH01','SP003',10)
INSERT INTO CTDDH (MaDDH,MaSP,SoLuong) VALUES ('DDH02','SP002',15)
INSERT INTO CTDDH (MaDDH,MaSP,SoLuong) VALUES ('DDH03','SP010',5)

--NHAP DU LIEU BANG PHIEUGIAOHANG
INSERT INTO PHIEUGIAOHANG (SoPhieuGiao,NgayGiao) VALUES ('PG001','20/06/2020')
INSERT INTO PHIEUGIAOHANG (SoPhieuGiao,NgayGiao) VALUES ('PG002','20/07/2020')
INSERT INTO PHIEUGIAOHANG (SoPhieuGiao,NgayGiao) VALUES ('PG003','28/08/2020')

--NHAP DU LIEU BANG CTPHIEUGIAO
INSERT INTO CTPHIEUGIAO (MaDDH,SoPhieuGiao,SLGiao,DGGiao,ThanhTien) 
		VALUES ('DDH01','PG001','10','40000','400000')
INSERT INTO CTPHIEUGIAO (MaDDH,SoPhieuGiao,SLGiao,DGGiao,ThanhTien) 
		VALUES ('DDH02','PG002','15','19000','2850000')
INSERT INTO CTPHIEUGIAO (MaDDH,SoPhieuGiao,SLGiao,DGGiao,ThanhTien) 
		VALUES ('DDH03','PG003','5','40000','1425000')
 
--NHAP DU LIEU BANG DONHANG (0-DANG GIAO/1-DA NHAN)
INSERT INTO DONHANG (NgayMua,NgayDuKienGiao,TinhTrang,MaKH) VALUES ('1/8/2020','2/8/2020',0,3)
INSERT INTO DONHANG (NgayMua,NgayDuKienGiao,TinhTrang,MaKH) VALUES ('10/8/2020','10/8/2020',1,5)
INSERT INTO DONHANG (NgayMua,NgayDuKienGiao,TinhTrang,MaKH) VALUES ('25/8/2020','27/8/2020',0,4)

--NHAP DU LIEU BANG CTDONHANG
INSERT INTO CTDONHANG (MaDH,MaSP,SoLuong,DGBan,ThanhTien) VALUES (3,'SP009',1,'350000','350000')
INSERT INTO CTDONHANG (MaDH,MaSP,SoLuong,DGBan,ThanhTien) VALUES (3,'SP008',1,'245000','245000')
INSERT INTO CTDONHANG (MaDH,MaSP,SoLuong,DGBan,ThanhTien) VALUES (4,'SP004',1,'179000','179000')
INSERT INTO CTDONHANG (MaDH,MaSP,SoLuong,DGBan,ThanhTien) VALUES (4,'SP009',1,'350000','350000')
INSERT INTO CTDONHANG (MaDH,MaSP,SoLuong,DGBan,ThanhTien) VALUES (5,'SP005',2,'130000','260000')


