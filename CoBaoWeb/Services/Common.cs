using System;
using System.Collections.Generic;

namespace CoBaoWeb.Services
{
    public class CoBaoResult
    {
        public long IsOK { get; set; }
        public string msg { get; set; }
    }
    public class TimKiemCoBaoByDateInput
    {
        public string NgayBD { get; set; }
        public string NgayKT { get; set; }
        public string SoCoBao { get; set; }
        public string DauMaySo { get; set; }
        public long? CoBaoID { get; set; }
        //1- khởi tạo, 2- đã duyệt, 3- đã hủy, 4- đã xóa, 5- đã kết thúc, 6- hoàn thành
        public short? TrangThai { get; set; }
        public short? PageNumber { get; set; }
        public short? PageSize { get; set; }
        public string Username { get; set; }
    }
    public class TimKiemCoBaoByIDInput
    {
        public long? CoBaoID { get; set; }
        public string Username { get; set; }
    }
    public class partnerTCTCoBaoByDateOutput
    {
        public int? IsOK { get; set; }
        public string msg { get; set; }
        public IEnumerable<PartnerTCTCoBaoDienTu> Data { get; set; }
    }
    public class PartnerTCTCoBaoDienTu
    {
        public long? CoBaoID { get; set; }
        public string SoCoBao { get; set; }
        public string CoBaoTach { get; set; }
        public DateTime? NgayCoBao { get; set; }
        public string DauMaySo { get; set; }
        public string LoaiMay { get; set; }
        public string MaXNQuanLy { get; set; }
        public string TenXNQuanLy { get; set; }
        public decimal? SoLanRaKho { get; set; }
        public decimal? RutGio { get; set; }
        public string ChatLuong { get; set; }
        public string TaiXe1 { get; set; }
        public string TaiXe1_Ten { get; set; }
        public string TaiXe1_ChucVu { get; set; }
        public string TaiXe1_MaSo { get; set; }
        public short? TaiXe1_GioLuuTru { get; set; }
        public string TaiXe2 { get; set; }
        public string TaiXe2_Ten { get; set; }
        public string TaiXe2_ChucVu { get; set; }
        public string TaiXe2_MaSo { get; set; }
        public short? TaiXe2_GioLuuTru { get; set; }
        public string TaiXe3 { get; set; }
        public string TaiXe3_Ten { get; set; }
        public string TaiXe3_ChucVu { get; set; }
        public string TaiXe3_MaSo { get; set; }
        public short? TaiXe3_GioLuuTru { get; set; }
        public string TaiXe4 { get; set; }
        public string TaiXe4_Ten { get; set; }
        public string TaiXe4_ChucVu { get; set; }
        public string TaiXe4_MaSo { get; set; }
        public short? TaiXe4_GioLuuTru { get; set; }
        public string TaiXe5 { get; set; }
        public string TaiXe5_Ten { get; set; }
        public string TaiXe5_ChucVu { get; set; }
        public string TaiXe5_MaSo { get; set; }
        public short? TaiXe5_GioLuuTru { get; set; }
        public string TaiXe6 { get; set; }
        public string TaiXe6_Ten { get; set; }
        public string TaiXe6_ChucVu { get; set; }
        public string TaiXe6_MaSo { get; set; }
        public short? TaiXe6_GioLuuTru { get; set; }
        public string MaDVLaiMay { get; set; }
        public string TenDVLaiMay { get; set; }
        public string MaXNVanDung { get; set; }
        public string TenXNVanDung { get; set; }
        public DateTime? GioLenBan { get; set; }
        public DateTime? GioNhanMay { get; set; }
        public DateTime? GioRaKho { get; set; }
        public DateTime? GioVaoKho { get; set; }
        public DateTime? GioGiaoMay { get; set; }
        public DateTime? GioXuongBan { get; set; }
        public decimal? NhienLieu_BanTruoc { get; set; }
        public string NhienLieu_BanTruocDVT { get; set; }
        public decimal? NhienLieu_BanNhan { get; set; }
        public string NhienLieu_BanNhanDVT { get; set; }
        public decimal? NhienLieu_BanSau { get; set; }
        public string NhienLieu_BanSauDVT { get; set; }
        public decimal? NhienLieu_Linh { get; set; }
        public string NhienLieu_LinhDVT { get; set; }
        public decimal? NhienLieu_TrongDo { get; set; }
        public string NhienLieu_TrongDoDVT { get; set; }
        public string NhienLieu_MaTram { get; set; }
        public string NhienLieu_TenTram { get; set; }
        public decimal? ThanhTich_QuayVong { get; set; }
        public decimal? ThanhTich_LuHanh { get; set; }
        public decimal? ThanhTich_DonThuan { get; set; }
        public decimal? ThanhTich_Dung { get; set; }
        public decimal? ThanhTich_Don { get; set; }
        public decimal? ThanhTich_KmChay { get; set; }
        public decimal? ThanhTich_TanKM { get; set; }
        public decimal? ThanhTich_NLDinhMuc { get; set; }
        public decimal? ThanhTich_NLTieuThu { get; set; }
        public decimal? ThanhTich_NLLoiLo { get; set; }
        public short? TrangThai { get; set; }
        public string TenTrangThai { get; set; }
        public string MaDVLap { get; set; }
        public string TenDVLap { get; set; }
        public string MaCTLap { get; set; }
        public string TenCTLap { get; set; }
        public string createdby { get; set; }
        public string createdName { get; set; }
        public DateTime? createddate { get; set; }
        public DateTime? modifydate { get; set; }
        public string NguoiTao { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public string TenNguoiTao { get; set; }
        public string modifyby { get; set; }
        public string modifyName { get; set; }
        public DateTime? Thoigianduyet { get; set; }
        public string Nguoiduyet { get; set; }
        public string TenNguoiduyet { get; set; }
        public string MaXNDuyet { get; set; }
        public DateTime? ThoiGianVaoKho { get; set; }
        public string NguoiVaoKho { get; set; }
        public string TenNguoiVaoKho { get; set; }
        public string MaXNVaoKho { get; set; }

        public DateTime? ThoiGianHoanThanh { get; set; }
        public string NguoiHoanThanh { get; set; }
        public string TenNguoiHoanThanh { get; set; }
        public string MaDVHoanThanh { get; set; }
        public string TenDVHoanThanh { get; set; }
        public string MaXNHoanThanh { get; set; }
        public string TenXNHoanThanh { get; set; }
        //DauMo
        public decimal? DauDongCo_Nhan { get; set; }
        public decimal? DauDongCo_Linh { get; set; }
        public decimal? DauDongCo_Giao { get; set; }
        public string DauDongCo_DVT { get; set; }
        public string DauDongCo_MaTram { get; set; }
        public string DauDongCo_TenTram { get; set; }
        public decimal? DauGiamToc_Nhan { get; set; }
        public decimal? DauGiamToc_Linh { get; set; }
        public decimal? DauGiamToc_Giao { get; set; }
        public string DauGiamToc_DVT { get; set; }
        public string DauGiamToc_MaTram { get; set; }
        public string DauGiamToc_TenTram { get; set; }
        public decimal? DauThuyLuc_Nhan { get; set; }
        public decimal? DauThuyLuc_Linh { get; set; }
        public decimal? DauThuyLuc_Giao { get; set; }
        public string DauThuyLuc_DVT { get; set; }
        public string DauThuyLuc_MaTram { get; set; }
        public string DauThuyLuc_TenTram { get; set; }
        //thong tin phu
        public string ThongTinPhu_MaCoBao { get; set; }
        public string ThongTinPhu_SoHieuDuoiTau { get; set; }
        public decimal? ThongTinPhu_NhienLieuPhu { get; set; }
        public string ThongTinPhu_NhienLieuPhuDVT { get; set; }
        public decimal? ThongTinPhu_DonDocDuong { get; set; }
        public decimal? ThongTinPhu_DungDocDuong { get; set; }
        public decimal? ThongTinPhu_DungNoMay { get; set; }
        public string GhiChu { get; set; }
        public IEnumerable<CoBaoDauMay_ThongTinChiTiet> ThongTinChiTietData { get; set; }
        public IEnumerable<PartnerTCTCoBaoDauMay_DonChiTiet> DonChiTietData { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string TenGa { get; set; }
        public short? GaID { get; set; }
    }

    public class partnerTCTCoBaoByIDOutput
    {
        public int? IsOK { get; set; }
        public string msg { get; set; }
        public PartnerTCTCoBaoDienTu Data { get; set; }
    }
    public class CoBaoDauMay_ThongTinChiTiet
    {
        public long? ID { get; set; }
        public long? TauID { get; set; }
        public string MacTau { get; set; }
        public DateTime? NgayXP { get; set; }
        public string MaCTSoHuuTau { get; set; }
        public string TenCTSoHuuTau { get; set; }
        public short? TuyenDSVNID { get; set; }
        public string TenTuyenDSVN { get; set; }
        public short? LoaiTau { get; set; }
        public string TenLoaiTau { get; set; }
        public short? GaID { get; set; }
        public string TenGa { get; set; }
        public DateTime? GioDen { get; set; }
        public DateTime? GioDi { get; set; }
        public decimal? GioDon { get; set; }
        public decimal? TanSo { get; set; }
        public decimal? TanKM { get; set; }
        public decimal? TanXeRong { get; set; }
        public short? TongSoXe { get; set; }
        public short? SLXeRong { get; set; }
        public short? TinhChat { get; set; }
        public string TenTinhChat { get; set; }
        public string MayGhep { get; set; }
        public decimal? KmAdd { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

    }

    public class PartnerTCTCoBaoDauMay_DonChiTiet
    {
        public long? ID { get; set; }
        public long? CoBaoID { get; set; }
        public string SoCoBao { get; set; }
        public string NgayCoBao { get; set; }
        public string MaXNVanDung { get; set; }
        public string TenXNVanDung { get; set; }
        public string DauMaySo { get; set; }
        public string MacTau { get; set; }
        public DateTime? NgayXP { get; set; }
        public short? GaID { get; set; }
        public string TenGa { get; set; }
        public DateTime? ThoiGianDonBD { get; set; }
        public DateTime? ThoiGianDonKT { get; set; }
        public decimal? GioDon { get; set; }
        public string NguoiTao { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public short? LoaiDon { get; set; }
        public string TenLoaiDon { get; set; }
        public int? DiaDiemDon { get; set; }
        public string TenDiaDiemDon { get; set; }
    }


    public class PartnerThanhTichInput
    {
        public long? CoBaoID { get; set; }
        public string CoBaoTach { get; set; }
        public decimal? SoLanRaKho { get; set; }
        public string ChatLuong { get; set; }
        public DateTime? GioVaoKho { get; set; }
        public DateTime? GioGiaoMay { get; set; }
        public DateTime? GioXuongBan { get; set; }
        public decimal? NhienLieu_BanTruoc { get; set; }
        public decimal? NhienLieu_BanNhan { get; set; }
        public decimal? NhienLieu_Linh { get; set; }
        public string NhienLieu_MaTram { get; set; }
        public decimal? NhienLieu_TrongDo { get; set; }
        public decimal? NhienLieu_BanSau { get; set; }
        //Dau mo
        public decimal? DauDongCo_Nhan { get; set; }
        public decimal? DauDongCo_Linh { get; set; }
        public string DauDongCo_MaTram { get; set; }
        public decimal? DauDongCo_Giao { get; set; }
        public decimal? DauGiamToc_Nhan { get; set; }
        public decimal? DauGiamToc_Linh { get; set; }
        public string DauGiamToc_MaTram { get; set; }
        public decimal? DauGiamToc_Giao { get; set; }
        public decimal? DauThuyLuc_Nhan { get; set; }
        public decimal? DauThuyLuc_Linh { get; set; }
        public string DauThuyLuc_MaTram { get; set; }
        public decimal? DauThuyLuc_Giao { get; set; }
        //thong tin phu
        public string MaCoBao { get; set; }
        public string SoHieuDuoiTau { get; set; }
        public decimal? NhienLieuPhu { get; set; }
        public decimal? DonDocDuong { get; set; }
        public decimal? DungDocDuong { get; set; }
        public decimal? DungNoMay { get; set; }
        //thanh tich
        public decimal? ThanhTich_QuayVong { get; set; }
        public decimal? ThanhTich_LuHanh { get; set; }
        public decimal? ThanhTich_DonThuan { get; set; }
        public decimal? ThanhTich_Don { get; set; }
        public decimal? ThanhTich_KmChay { get; set; }
        public decimal? ThanhTich_TanKM { get; set; }
        public decimal? ThanhTich_NLDinhMuc { get; set; }
        public decimal? ThanhTich_NLTieuThu { get; set; }
        public decimal? ThanhTich_NLLoiLo { get; set; }
        public string Username { get; set; }
    }
    public class NhanVienInput
    {
        public string Username { get; set; }
    }

    public class DMNhanVien
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string ChucVu { get; set; }
        public string MaDV { get; set; }
        public string MaSo { get; set; }
        public string TenDV { get; set; }
        public string MaDVQL { get; set; }
    }
    public class DMTramFuel
    {
        public string MaTram { get; set; }
        public string TenTram { get; set; }
        public string MaDVQL { get; set; }
    }
}
