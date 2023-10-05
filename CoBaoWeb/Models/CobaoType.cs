using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoBaoWeb.Models
{
    #region Danh mục
    public class ViewDMNhanVien
    {
        public int NhanVienID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string MaSo { get; set; }
        public string ChucVu { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MaDV { get; set; }
        public string TenDV { get; set; }
        public string MaCT { get; set; }
        public string DVQL { get; set; }
        public string CodeQL { get; set; }
        public short? CapQL { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
    public partial class NhanVien
    {
        public string MaNV { get; set; }
        public short? MaQH { get; set; }
        public short? NL { get; set; }
        public string MaDV { get; set; }
        public bool Active { get; set; }
    }
    public partial class ViewDauMay
    {
        public int ID { get; set; }
        public string DauMayID { get; set; }
        public string LoaiMayID { get; set; }
        public string MaCTSoHuu { get; set; }
        public string TenCTSoHuu { get; set; }
        public string MaCTQuanLy { get; set; }
        public string TenCTQuanLy { get; set; }
        public DateTime? NgayHL { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyName { get; set; }
    }
    public partial class DauMay
    {        
        public string LoaiMayID { get; set; }
        public int HN { get; set; }
        public int VIN { get; set; }
        public int SG { get; set; }
        public int TCT { get; set; }       
    }
    public partial class DmdonVi
    {
        public string MaDv { get; set; }
        public string TenDv { get; set; }
        public string MaDvql { get; set; }
        public string MaCt { get; set; }
        public string Dvql { get; set; }
        public string CodeQl { get; set; }
        public short? CapQl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public short? LoaiDv { get; set; }
        public int? IsActive { get; set; }
    }
    public partial class DonViDM
    {
        public string MaDV { get; set; }
        public string TenDV { get; set; }
        public string TenTat { get; set; }
        public string DiaChi { get; set; }
        public string Tinh { get; set; }
        public string DienThoai { get; set; }
        public string Fax { get; set; }
        public string MST { get; set; }
        public string SoTK { get; set; }
        public string NganHang { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string GaDMList { get; set; }
        public string MaCha { get; set; }
    }
    public partial class DonViKT
    {
        public string MaDV { get; set; }
        public string TenDV { get; set; }
        public string MaDVCha { get; set; }
        public short SapXep { get; set; }
        public int GaID { get; set; }
    }   
    public partial class Tuyen
    {
        public string TuyenID { get; set; }
        public short TuyenMap { get; set; }
        public string TuyenName { get; set; }
        public bool Active { get; set; }
    }
    public partial class TuyenMap
    {
        public short TuyenId { get; set; }
        public string TuyenName { get; set; }
    }
    public partial class LoaiMay
    {
        public string LoaiMayId { get; set; }
        public string LoaiMayMap { get; set; }
        public string LoaiMayName { get; set; }
        public short KhoDuong { get; set; }
        public decimal TuTrong { get; set; }
        public short MaLuc { get; set; }
        public short NhomMay { get; set; }
        public short SoTT { get; set; }
        public bool? Active { get; set; }
    }
    public partial class CongTac
    {
        public short CongTacId { get; set; }
        public string CongTacName { get; set; }
    }
    public partial class HeSoQdnl
    {
        public long ID { get; set; }
        public string MaDv { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public decimal HesoLit { get; set; }
        public decimal HesoKg { get; set; }
        public decimal NhietDo { get; set; }
    }
    public partial class DSNLDinhMuc
    {
        public long ID { get; set; }
        public string MaDV { get; set; }
        public string LoaiMayID { get; set; }
        public short? CongTacId { get; set; }
        public string GhiChu { get; set; }
        public decimal? DinhMuc { get; set; }
        public string DonVi { get; set; }
        public DateTime NgayHL { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string CreatedName { get; set; }
        public DateTime Modifydate { get; set; }
        public string Modifyby { get; set; }
        public string ModifyName { get; set; }
    }   
    public class MienPhat
    {
        public long CoBaoID { get; set; }
        public string SoCB { get; set; }
        public int ThangDT { get; set; }
        public int NamDT { get; set; }
        public decimal TyLe { get; set; }
        public string LyDo { get; set; }
        public string MaDV { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyName { get; set; }
    }
    public partial class LyTrinh
    {
        public long ID { get; set; }
        public string TuyenID { get; set; }
        public string TuyenName { get; set; }
        public int? GaID { get; set; }
        public string TenGa { get; set; }
        public decimal? Km { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string CreatedName { get; set; }
        public DateTime Modifydate { get; set; }
        public string Modifyby { get; set; }
        public string ModifyName { get; set; }
    }
    public partial class TTLytrinh
    {
        public string Tuyentt { get; set; }
        public string Gatt { get; set; }
        public IEnumerable<LyTrinh> LyTrinh { get; set; }
    }
    public partial class DmtramNhienLieu
    {
        public int Id { get; set; }
        public string MaTram { get; set; }
        public string TenTram { get; set; }
        public string MaDvql { get; set; }
        public byte? IsActive { get; set; }
    }
    #endregion

    #region Báo cáo
    public partial class BCTratim
    {
        public string Xinghiep { get; set; }
        public string Nhombc { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Begin { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime End { get; set; }
        public string Nguon { get; set; }
        public string Loaibc { get; set; }
        public short Tuyen { get; set; }
        public string Loaimay { get; set; }
        public string Loaidon { get; set; }
        public string chinhanh { get; set; }
    }
   
    public partial class ViewBcvanDung
    {
        public string DvcbID { get; set; }
        public int ThangDt { get; set; }
        public int NamDt { get; set; }
        public string LoaiMayId { get; set; }
        public string TuyenId { get; set; }
        public int? CongTacId { get; set; }
        public int? TinhChatId { get; set; }
        public int? GioDm { get; set; }
        public int? GioLh { get; set; }
        public int? GioDt { get; set; }
        public int? Dgxp { get; set; }
        public int? Dgdd { get; set; }
        public int? Dgcc { get; set; }
        public int? Dgqd { get; set; }
        public int? Dgdm { get; set; }
        public int? Dgdn { get; set; }
        public int? Dgkm { get; set; }
        public int? Dgkn { get; set; }
        public int? Dnxp { get; set; }
        public int? Dndd { get; set; }
        public int? Dncc { get; set; }
        public decimal? Kmch { get; set; }
        public decimal? Kmdw { get; set; }
        public decimal? Kmgh { get; set; }
        public decimal? Kmdy { get; set; }
        public decimal? Tkch { get; set; }
        public decimal? Tkdw { get; set; }
        public decimal? Tkgh { get; set; }
        public decimal? Tkdy { get; set; }
        public decimal? Slrkm { get; set; }
        public decimal? Slrkn { get; set; }
        public decimal? Sltt { get; set; }
        public decimal? Sltt15 { get; set; }
        public decimal? Sltc { get; set; }
    }
    public partial class ViewBcGioDon
    {
        public string DvcbID { get; set; }
        public string LoaiMayID { get; set; }
        public string GaXPName { get; set; }
        public short? CongTacID { get; set; }
        public int? GioDon { get; set; }
    }
    public partial class ViewBcGioDonCT
    {
        public string DvcbID { get; set; }
        public string GaName { get; set; }
        public string DauMayID { get; set; }
        public DateTime NhanMay { get; set; }
        public string SoCB { get; set; }
        public string TaiXeID { get; set; }
        public string TaiXeName { get; set; }
        public int? GioDon { get; set; }
    }
    public partial class ViewBcNhienLieu
    {
        public long DoanThongID { get; set; }
        public string DvcbID { get; set; }
        public string LoaiMayID { get; set; }
        public string DauMayID { get; set; }
        public DateTime NgayCB { get; set; }
        public int ThangDT { get; set; }
        public int NamDT { get; set; }
        public string TuyenID { get; set; }
        public short? CongTacID { get; set; }
        public short? TinhChatID { get; set; }
        public int GaXPID { get; set; }
        public int GaKTID { get; set; }
        public int? GioDon { get; set; }
        public decimal? TanKM { get; set; }
        public decimal? DinhMuc { get; set; }
        public decimal? TieuThu { get; set; }
    }
    public partial class ViewBcTTNhienLieu
    {
        public string DvcbID { get; set; }
        public string LoaiMayID { get; set; }
        public string DauMayID { get; set; }
        public DateTime NgayCB { get; set; }
        public int ThangDT { get; set; }
        public int NamDT { get; set; }
        public string TuyenID { get; set; }
        public short? CongTacID { get; set; }
        public string CongTacName { get; set; }
        public short? TinhChatID { get; set; }
        public string GaXP { get; set; }
        public string GaKT { get; set; }
        public int? GioDon { get; set; }
        public int? GioDung { get; set; }
        public decimal? KMChinh { get; set; }
        public decimal? KMDon { get; set; }
        public decimal? KMGhep { get; set; }
        public decimal? KMDay { get; set; }
        public decimal? TanKM { get; set; }
        public decimal? DinhMuc { get; set; }
        public decimal? TieuThu { get; set; }
        public decimal? TieuThu15 { get; set; }
    }
    public partial class ViewBcTTTaiXe
    {
        public long CoBaoID { get; set; }
        public int ThangDT { get; set; }
        public int NamDT { get; set; }
        public string DvcbID { get; set; }
        public string TaiXe1ID { get; set; }
        public string TaiXe1Name { get; set; }
        public string PhoXe1ID { get; set; }
        public string PhoXe1Name { get; set; }
        public string TaiXe2ID { get; set; }
        public string TaiXe2Name { get; set; }
        public string PhoXe2ID { get; set; }
        public string PhoXe2Name { get; set; }
        public string TaiXe3ID { get; set; }
        public string TaiXe3Name { get; set; }
        public string PhoXe3ID { get; set; }
        public string PhoXe3Name { get; set; }
        public int? GioDung { get; set; }
        public int? GioDon { get; set; }
        public decimal? KM { get; set; }
        public decimal? DinhMuc { get; set; }
        public decimal? TieuThu { get; set; }
    }
    public partial class ViewBcTacNghiep
    {
        public long DoanThongID { get; set; }
        public string DvcbID { get; set; }
        public string DvdmID { get; set; }
        public string LoaiMayID { get; set; }
        public string DauMayID { get; set; }
        public DateTime NgayCB { get; set; }
        public int ThangDT { get; set; }
        public int NamDT { get; set; }
        public short? CongTacID { get; set; }
        public short? TinhChatID { get; set; }
        public string GaXP { get; set; }
        public string GaKT { get; set; }
        public decimal? KMChinh { get; set; }
        public decimal? KMPhuTro { get; set; }
        public int? GioLH { get; set; }
        public int? GioDon { get; set; }
        public decimal? TanKM { get; set; }
        public decimal? TieuThu { get; set; }
    }
    public partial class ViewBcTonNL
    {
        public string LoaiMayID { get; set; }
        public string DauMayID { get; set; }
        public DateTime NhanMay { get; set; }
        public string MaTram { get; set; }
        public string TenTram { get; set; }
        public decimal? TonDau { get; set; }
        public decimal? Linh { get; set; }
        public decimal? TieuThu { get; set; }
        public decimal? TonCuoi { get; set; }
    }
    public partial class ViewBcBKDauMo
    {
        public string LoaiMayID { get; set; }
        public string DauMayID { get; set; }
        public DateTime NgayCB { get; set; }
        public string SoCB { get; set; }
        public string MaTram { get; set; }
        public decimal? Linh { get; set; }
    }
    public partial class ViewBcBKLuong
    {
        public string DauMayID { get; set; }
        public DateTime NgayCB { get; set; }
        public string SoCB { get; set; }
        public string MaCB { get; set; }
        public string TaiXe1ID { get; set; }
        public string TaiXe1Name { get; set; }
        public string PhoXe1ID { get; set; }
        public string PhoXe1Name { get; set; }
        public string TaiXe2ID { get; set; }
        public string TaiXe2Name { get; set; }
        public string PhoXe2ID { get; set; }
        public string PhoXe2Name { get; set; }
        public string TaiXe3ID { get; set; }
        public string TaiXe3Name { get; set; }
        public string PhoXe3ID { get; set; }
        public string PhoXe3Name { get; set; }
        public string MacTauID { get; set; }
        public short? TinhChatID { get; set; }
        public int? GioDm { get; set; }
        public decimal? Km { get; set; }
        public decimal? NLLoiLo { get; set; }
    }
    public class BCVanDungInfo
    {
        public short SoTT { get; set; }
        public string ChiTieu { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KhachTNChinh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KhachTNDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KhachTNDay { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KhachTNGhep { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KhachDPChinh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KhachDPDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KhachDPDay { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KhachDPGhep { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal HangChinh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal HangDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal HangDay { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal HangGhep { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal DaChinh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal DaDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal DaDay { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal DaGhep { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal ThoiChinh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal ThoiDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal ThoiDay { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal ThoiGhep { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal ChuyenDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal CongDung { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TongCong { get; set; }
    }
    public class BCKTKTXNInfo
    {
        public string TenCT { get; set; }
        public string MaCT { get; set; }
        public string DonVi { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KVTN { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KVDP { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KVHH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KVTong { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal HVHang { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal HVDa { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal HVThoi { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal HVTong { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal CongDung { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KiemDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal ChuyenDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TongCong { get; set; }
    }
    public class BCKTKTTHInfo
    {
        public string TenCT { get; set; }
        public string MaCT { get; set; }
        public string DonVi { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KVYV1435 { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KVYV1000 { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KVHN { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KVVI { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KVDN { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KVSG { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KVTong { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal HVYV1435 { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal HVYV1000 { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal HVHN { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal HVVI { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal HVDN { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal HVSG { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal HVTong { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal CongDung { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KiemDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal ChuyenDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TongCong { get; set; }
    }
    public class BCGioDonInfo
    {
        public short SoTT { get; set; }
        public short MaXN { get; set; }
        public string TenXN { get; set; }
        public string MaGa { get; set; }
        public string TenGa { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal D4H { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal D5H { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal D9E { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal D10H { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal D10H_CAT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal D11H { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal D12E { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal D13E { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal D14E { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal D18E { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal D19E { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal D20E { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal D4Hr { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal D19Er { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Tong { get; set; }
    }
    public class BCCTGioDonInfo
    {
        public short SoTT { get; set; }
        public string DonViDM { get; set; }
        public string DonViKT { get; set; }
        public string TenGa { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime NhanMay { get; set; }
        public string DauMay { get; set; }
        public string SoCB { get; set; }
        public string MaTX { get; set; }
        public string TenTX { get; set; }
        public int GioDon { get; set; }
    }
    public class BCTHSPTNInfo
    {
        public short SoTT { get; set; }
        public short MaCT { get; set; }
        public string TenCT { get; set; }
        public string MaLM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KMCH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KMPT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal DonTD { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TanKM { get; set; }
    }
    public class BCTHNLInfo
    {
        public string MaCap1 { get; set; }
        public string TenCap1 { get; set; }
        public string MaCap2 { get; set; }
        public string TenCap2 { get; set; }
        public string MaCap3 { get; set; }
        public string TenCap3 { get; set; }
        public string MaLM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal DMKH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal DMTH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TanKM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal GioDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal NLTC { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal NLTT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal NLLL { get; set; }
    }
    public class BCTTNLInfo
    {
        public short MaCT { get; set; }
        public string TenCT { get; set; }
        public string MaLM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal DMKH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal DMTH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal NLTC { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal NLTT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal NLTT15 { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KMChinh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KMDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KMGhep { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KMDay { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KMDonTD { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KMDungTD { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KMTong { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TanKM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TanBQ { get; set; }

    }
    public class BCTTDMInfo
    {
        public string MaDM { get; set; }
        public string MaLM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal DMKH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal DMTH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal NLTC { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal NLTT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal NLTT15 { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KMChinh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KMDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KMGhep { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KMDay { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KMDonTD { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KMDungTD { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KMTong { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TanKM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TanBQ { get; set; }

    }
    public class BCTTTXInfo
    {
        public string MaDV { get; set; }
        public string TenDV { get; set; }
        public string Tram { get; set; }
        public string Doi { get; set; }
        public string MaTX { get; set; }
        public string TenTX { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int SoCB { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal NLLoi { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal NLLo { get; set; }
        public string GhiChu { get; set; }
    }
    public class BCDCSPTNInfo
    {
        public string MaCap1 { get; set; }
        public string TenCap1 { get; set; }
        public string MaCap2 { get; set; }
        public string TenCap2 { get; set; }
        public string MaLM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KMCH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KMPT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TanKM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal GioDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal NLTT { get; set; }
    }
    public class BCTonNLInfo
    {
        public string LoaiMayID { get; set; }
        public string DauMayID { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TonDau { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFGBA { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFYVI { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFVIN { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFDNA { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFSGO { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFHNO { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFNBI { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFHPH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFDTR { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFHUE { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFQNG { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFBTH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFNTH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFSOT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFDDA { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFLCA { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFLTH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFMKH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFVTR { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFXGA { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFYBI { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFTHO { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFPUT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFDHO { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFNTR { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal Linh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TieuThu { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TonCuoi { get; set; }

    }
    public class BKDauMoInfo
    {
        public string LoaiMayID { get; set; }
        public string DauMayID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayCB { get; set; }
        public string SoCB { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFGBA { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFYVI { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFVIN { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFDNA { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFSGO { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFHNO { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFNBI { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFHPH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFDTR { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFHUE { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFQNG { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFBTH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFNTH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFSOT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TFDDA { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFLCA { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFLTH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFMKH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFVTR { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFXGA { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFYBI { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFTHO { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFPUT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFDHO { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TFNTR { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal Linh { get; set; }
    }
    public class BKTinhLuongInfo
    {
        public short STT { get; set; }
        public string SoCB { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayCB { get; set; }
        public string DauMayID { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal GioB { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal GioVLM { get; set; }
        public string MacTauID { get; set; }
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public decimal GioLT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public decimal GioTN { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal NLLoi { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal NLLo { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public decimal GioLD { get; set; }
        public string MaCB { get; set; }
        public decimal KepN { get; set; }
        public string MaLD { get; set; }
        public string TenLD { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal TaiXe { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal PhoXe { get; set; }
        public short BanLT { get; set; }
    }
    public class BCHieuQuaSDDMInfo
    {
        public string XiNghiep { get; set; }
        public string CongTac { get; set; }
        public string LoaiMay { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KmChinh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KmPhuTro { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal VTKm { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal GioDM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal GioDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KmBQ { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TanBQ { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal NSuatBQ { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal MayBQ { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TieuThu { get; set; }
    }
    public partial class BCVandung
    {
        public BCTratim BCTratim { get; set; }
        public IEnumerable<BCVanDungInfo> BCVanDungInfo { get; set; }
    }
    public partial class BCChitieuktkt
    {
        public BCTratim BCTratim { get; set; }
        public IEnumerable<BCKTKTXNInfo> BCKTKTXNInfo { get; set; }
        public IEnumerable<BCKTKTTHInfo> BCKTKTTHInfo { get; set; }
    }
    public partial class BCTHGiodon
    {
        public BCTratim BCTratim { get; set; }
        public IEnumerable<BCGioDonInfo> BCGioDonInfo { get; set; }       
    }
    public partial class BCCTGiodon
    {
        public BCTratim BCTratim { get; set; }
        public IEnumerable<BCCTGioDonInfo> BCCTGioDonInfo { get; set; }
    }
    public partial class BCSPTNThuchien
    {
        public BCTratim BCTratim { get; set; }
        public IEnumerable<BCTHSPTNInfo> BCTHSPTNInfo { get; set; }
    }
    public partial class BCNLThuchien
    {
        public BCTratim BCTratim { get; set; }
        public IEnumerable<BCTHNLInfo> BCTHNLInfo { get; set; }
    }
    public partial class BCNLThanhtich
    {
        public BCTratim BCTratim { get; set; }
        public IEnumerable<BCTTNLInfo> BCTTNLInfo { get; set; }
        public IEnumerable<BCTTDMInfo> BCTTDMInfo { get; set; }
        public IEnumerable<BCTTTXInfo> BCTTTXInfo { get; set; }
    }
    public partial class BCSPTNDoichieu
    {
        public BCTratim BCTratim { get; set; }
        public IEnumerable<BCDCSPTNInfo> BCDCSPTNInfo { get; set; }
    }
    public partial class BCDaumo
    {
        public BCTratim BCTratim { get; set; }
        public IEnumerable<BCTonNLInfo> BCTonNLInfo { get; set; }
        public IEnumerable<BKDauMoInfo> BKDauMoInfo { get; set; }       
    }
    public partial class BCTinhluong
    {
        public BCTratim BCTratim { get; set; }
        public IEnumerable<BKTinhLuongInfo> BKTinhLuongInfo { get; set; }
    }
    public partial class BCHieuqua
    {
        public BCTratim BCTratim { get; set; }
        public IEnumerable<BCHieuQuaSDDMInfo> BCHieuQuaSDDMInfo { get; set; }
    }
    #endregion

    #region Cơ báo điện tử
    public class BCCoBaoTTInfo
    {
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal GioDM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal GioLH { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal GioDT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal GioDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal GioDung { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KMChay { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TKM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal DinhMuc { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TieuThu { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal LoiLo { get; set; }
    }
    public class BCCoBaoCTInfo
    {
        public int SoTT { get; set; }
        public DateTime NgayXP { get; set; }
        public string GioDen { get; set; }
        public string GioDi { get; set; }
        public string GioDon { get; set; }
        public string MacTau { get; set; }
        public string GaDi { get; set; }
        public decimal Tan { get; set; }
        public int xeTotal { get; set; }
        public decimal TanRong { get; set; }
        public int xeRong { get; set; }
        public string TinhChat { get; set; }
        public string MayGhep { get; set; }
        public decimal KmAdd { get; set; }
    }
    public partial class TTCobao
    {
        public CoBaoView CobaoTT { get; set; }
        public IEnumerable<CoBao> Cobao { get; set; }
    }
    public partial class TTCobaoct
    {
        public BCCoBaoTTInfo BCCoBaoTTInfo { get; set; }
        public CoBao Cobao { get; set; }
    }
    public partial class CoBaoView
    {
        public string Xinghiep { get; set; }
        public string Trangthai { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Begin { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime End { get; set; }      
        public string Socb { get; set; }
        public string Daumay { get; set; }
    }
    public class CoBaoTT
    {
        public long CoBaoID { get; set; }
        public long CoBaoGoc { get; set; }
        public string SoCB { get; set; }
        public DateTime NgayCB { get; set; }
        public string DauMayID { get; set; }
        public string LoaiMayID { get; set; }
        public int QuayVong { get; set; }
        public int LuHanh { get; set; }
        public int DonThuan { get; set; }
        public int GioDon { get; set; }
        public int GioDung { get; set; }
        public decimal KM { get; set; }
        public decimal TKM { get; set; }
        public decimal NLTieuThu { get; set; }
        public decimal NLTieuChuan { get; set; }
        public decimal NLLoiLo { get; set; }
    }
    public class CoBao
    {
        public long CoBaoID { get; set; }
        public long CoBaoGoc { get; set; }
        public string DauMayID { get; set; }
        public string LoaiMayID { get; set; }
        public string DvdmID { get; set; }
        public string DvdmName { get; set; }
        public string SoCB { get; set; }
        public string DvcbID { get; set; }
        public string DvcbName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayCB { get; set; }
        public int RutGio { get; set; }
        public string ChatLuong { get; set; }
        public decimal SoLanRaKho { get; set; }
        public string TaiXe1ID { get; set; }
        public string TaiXe1Name { get; set; }
        public short TaiXe1GioLT { get; set; }
        public string PhoXe1ID { get; set; }
        public string PhoXe1Name { get; set; }
        public short PhoXe1GioLT { get; set; }
        public string TaiXe2ID { get; set; }
        public string TaiXe2Name { get; set; }
        public short TaiXe2GioLT { get; set; }
        public string PhoXe2ID { get; set; }
        public string PhoXe2Name { get; set; }
        public short PhoXe2GioLT { get; set; }
        public string TaiXe3ID { get; set; }
        public string TaiXe3Name { get; set; }
        public short TaiXe3GioLT { get; set; }
        public string PhoXe3ID { get; set; }
        public string PhoXe3Name { get; set; }
        public short PhoXe3GioLT { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime LenBan { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime NhanMay { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime RaKho { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime VaoKho { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime GiaoMay { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime XuongBan { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int NLBanTruoc { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int NLThucNhan { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int NLLinh { get; set; }
        public string TramNLID { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal NLTrongDoan { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int NLBanSau { get; set; }
        public string SHDT { get; set; }
        public string MaCB { get; set; }
        public decimal DonDocDuong { get; set; }
        public decimal DungDocDuong { get; set; }
        public decimal DungNoMay { get; set; }
        public string GhiChu { get; set; }
        public int GaID { get; set; }
        public string GaName { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string CreatedName { get; set; }
        public DateTime Modifydate { get; set; }
        public string Modifyby { get; set; }
        public string ModifyName { get; set; }
        public string TrangThai { get; set; }
        public bool KhoaCB { get; set; }
        public List<CoBaoCT> coBaoCTs { get; set; }
        public List<CoBaoDM> coBaoDMs { get; set; }
    }
    public class CoBaoCT
    {
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime NgayXP { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime GioDen { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime GioDi { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal GioDon { get; set; }
        public string MacTauID { get; set; }
        public int GaID { get; set; }
        public string GaName { get; set; }
        public short TinhChatID { get; set; }
        public string TinhChatName { get; set; }
        public string MayGhepID { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Tan { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int XeTotal { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TanXeRong { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int XeRongTotal { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KmAdd { get; set; }
        public short CongTacID { get; set; }
        public string CongTacName { get; set; }
        public short? TuyenID { get; set; }
        public string TuyenName { get; set; }
        public string CongTyID { get; set; }
        public string CongTyName { get; set; }
        public long TauID { get; set; }
        public long CoBaoID { get; set; }
        public long ID { get; set; }
    }
    public class CoBaoDM
    {
        public long ID { get; set; }
        public long CoBaoID { get; set; }
        public short LoaiDauMoID { get; set; }
        public string LoaiDauMoName { get; set; }
        public string DonViTinh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal Nhan { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal Linh { get; set; }
        public string MaTram { get; set; }
        public string TenTram { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal Giao { get; set; }
    }
    public class CoBaoALL
    {
        public long CoBaoID { get; set; }
        public CoBao coBaos { get; set; }
        public DoanThong doanThongs { get; set; }
    }
    #endregion

    #region Đoạn thống điện tử
    public partial class TTDoanthong
    {
        public DoanthongTT DoanthongTT { get; set; }
        public IEnumerable<DoanThongView> DoanThongView { get; set; }
    }
    public partial class TTDoanthongct
    {
        public BCCoBaoTTInfo BCCoBaoTTInfo { get; set; }
        public DoanThongView DoanThongView { get; set; }
        public IEnumerable<DoanThongCT> DoanThongCT { get; set; }
        public IEnumerable<DoanThongDM> DoanThongDM { get; set; }
    }
    public partial class DoanthongTT
    {
        public string Xinghiep { get; set; }
        public string Loaimay { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Begin { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime End { get; set; }
        public string Socb { get; set; }
        public string Daumay { get; set; }
        public string Taixe { get; set; }
        public string Mactau { get; set; }
        public long DoanThongID { get; set; }
    }
    public class DoanThongView
    {
        public long DoanThongID { get; set; }
        public long CoBaoGoc { get; set; }
        public string SoCB { get; set; }
        public string DauMayID { get; set; }
        public string LoaiMayID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayCB { get; set; }
        public string TaiXe1ID { get; set; }
        public string TaiXe1Name { get; set; }
        public string PhoXe1ID { get; set; }
        public string PhoXe1Name { get; set; }
        public string TaiXe2ID { get; set; }
        public string TaiXe2Name { get; set; }
        public string PhoXe2ID { get; set; }
        public string PhoXe2Name { get; set; }
        public string TaiXe3ID { get; set; }
        public string TaiXe3Name { get; set; }
        public string PhoXe3ID { get; set; }
        public string PhoXe3Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime LenBan { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime NhanMay { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime RaKho { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime VaoKho { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime GiaoMay { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime XuongBan { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungKB { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int NLBanTruoc { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int NLThucNhan { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int NLLinh { get; set; }
        public string TramNLID { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal NLTrongDoan { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int NLBanSau { get; set; }
        public int ThangDT { get; set; }
        public int NamDT { get; set; }
        public string DvdmName { get; set; }
        public string DvcbID { get; set; }
        public string DvcbName { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string CreatedName { get; set; }
        public DateTime Modifydate { get; set; }
        public string Modifyby { get; set; }
        public string ModifyName { get; set; }
    }
    public class DoanThong
    {
        public long DoanThongID { get; set; }
        public int DungKB { get; set; }
        public int ThangDT { get; set; }
        public int NamDT { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string CreatedName { get; set; }
        public DateTime Modifydate { get; set; }
        public string Modifyby { get; set; }
        public string ModifyName { get; set; }
        public List<DoanThongCT> doanThongCTs { get; set; }
        public List<DoanThongDM> doanThongDMs { get; set; }
    }
    public class DoanThongCT
    {
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime NgayXP { get; set; }
        public long TauID { get; set; }
        public string MacTauID { get; set; }
        public int GaXPID { get; set; }
        public string GaXPName { get; set; }
        public int GaKTID { get; set; }
        public string GaKTName { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal DinhMuc { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TieuThu { get; set; }
        public string KhuDoan { get; set; }
        public string DienGiai { get; set; }
        public string CongTyID { get; set; }
        public string CongTyName { get; set; }
        public short CongTacID { get; set; }
        public string CongTacName { get; set; }
        public short TinhChatID { get; set; }
        public string TinhChatName { get; set; }
        public string TuyenID { get; set; }
        public string TuyenName { get; set; }
        public string MayGhepID { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int QuayVong { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int LuHanh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DonThuan { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungDM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungDN { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungQD { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungXP { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungDD { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungKT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungKhoDM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungKhoDN { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungNM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DonXP { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DonDD { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DonKT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KMChinh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KMDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KMGhep { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KMDay { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TKMChinh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TKMDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TKMGhep { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TKMDay { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Tan { get; set; }
        public int XeTotal { get; set; }
        public decimal TanXeRong { get; set; }
        public int XeRongTotal { get; set; }
        public decimal SLRKDM { get; set; }
        public decimal SLRKDN { get; set; }
        public long ID { get; set; }
        public long DoanThongID { get; set; }
    }
    public class DoanThongDM
    {
        public long ID { get; set; }
        public long DoanThongID { get; set; }
        public short LoaiDauMoID { get; set; }
        public string LoaiDauMoName { get; set; }
        public string DonViTinh { get; set; }
        public string DienGiai { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal DinhMuc { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TieuThu { get; set; }
    }
    #endregion

    #region KT Logic
    public partial class KTLogicTT
    {
        public string Xinghiep { get; set; }
        public string Loaidon { get; set; }
        public int Thang { get; set; }       
        public int Nam { get; set; }        
        public string Daumay { get; set; }
        public string Loaibc { get; set; }
    }
    public partial class TTKTLogic
    {
        public KTLogicTT KTLogicTT { get; set; }
        public IEnumerable<KTQuayVong> KTQuayVong { get; set; }
        public IEnumerable<KTDonThuan> KTDonThuan { get; set; }
        public IEnumerable<KTVanTocKT> KTVanTocKT { get; set; }
        public IEnumerable<KTDungKB> KTDungKB { get; set; }
        public IEnumerable<KTNhienLieu> KTNhienLieu { get; set; }
    }
    public partial class KTQuayVong
    {
        public long CoBaoID { get; set; }
        public string SoCB { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayCB { get; set; }
        public string DauMayID { get; set; }
        public string DvcbID { get; set; }
        public string TaiXe1ID { get; set; }
        public string TaiXe1Name { get; set; }
        public int ThangDT { get; set; }
        public int NamDT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int QuayVong { get; set; }
    }
    public partial class KTDonThuan
    {
        public long CoBaoID { get; set; }
        public string SoCB { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayCB { get; set; }
        public string DauMayID { get; set; }
        public string DvcbID { get; set; }
        public string TaiXe1ID { get; set; }
        public string TaiXe1Name { get; set; }
        public int ThangDT { get; set; }
        public int NamDT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DonThuan { get; set; }
    }
    public partial class KTVanTocKT
    {
        public long CoBaoID { get; set; }
        public string SoCB { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayCB { get; set; }
        public string DauMayID { get; set; }
        public string DvcbID { get; set; }
        public string TaiXe1ID { get; set; }
        public string TaiXe1Name { get; set; }
        public string MacTauID { get; set; }
        public short CongTacID { get; set; }
        public string CongTacName { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal VanToc { get; set; }
    }
    public partial class KTDungKB
    {
        public string DauMayID { get; set; }
        public int DungKB { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime GiaoMay { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime NhanMay { get; set; }
        public string SoCBGiao { get; set; }
        public string SoCBNhan { get; set; }
        public string TaiXeGiao { get; set; }
        public string TaiXeNhan { get; set; }
        public string DvGiao { get; set; }
        public string DvNhan { get; set; }
        public long CoBaoIDGiao { get; set; }
        public long CoBaoIDNhan { get; set; }
    }
    public partial class KTNhienLieu
    {
        public string DauMayID { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public int NLBanGiao { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public int NLBanNhan { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime GiaoMay { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime NhanMay { get; set; }
        public string SoCBGiao { get; set; }
        public string SoCBNhan { get; set; }
        public string TaiXeGiao { get; set; }
        public string TaiXeNhan { get; set; }
        public string DvGiao { get; set; }
        public string DvNhan { get; set; }
        public long CoBaoIDGiao { get; set; }
        public long CoBaoIDNhan { get; set; }
    }
    #endregion

    #region Xuất cơ báo điện tử
    public partial class XCobaodtTT
    {
        public string Xinghiep { get; set; }
        public string Loaimay { get; set; }
        public string Loaidon { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string Loaibc { get; set; }
    }
    public partial class TTXCobaodt
    {
        public XCobaodtTT XCobaodtTT { get; set; }
        public IEnumerable<XCoBao> XCoBao { get; set; }
        public IEnumerable<XCoBaoCT> XCoBaoCT { get; set; }
        public IEnumerable<XCoBaoDM> XCoBaoDM { get; set; }      
    }
    public class XCoBao
    {
        public long CoBaoID { get; set; }
        public long CoBaoGoc { get; set; }
        public string SoCB { get; set; }
        public string DauMayID { get; set; }
        public string LoaiMayID { get; set; }
        public string DvdmID { get; set; }
        public string DvdmName { get; set; }
        public string DvcbID { get; set; }
        public string DvcbName { get; set; }
        public DateTime NgayCB { get; set; }
        public int RutGio { get; set; }
        public string ChatLuong { get; set; }
        public decimal SoLanRaKho { get; set; }
        public string TaiXe1ID { get; set; }
        public string TaiXe1Name { get; set; }
        public short TaiXe1GioLT { get; set; }
        public string PhoXe1ID { get; set; }
        public string PhoXe1Name { get; set; }
        public short PhoXe1GioLT { get; set; }
        public string TaiXe2ID { get; set; }
        public string TaiXe2Name { get; set; }
        public short TaiXe2GioLT { get; set; }
        public string PhoXe2ID { get; set; }
        public string PhoXe2Name { get; set; }
        public short PhoXe2GioLT { get; set; }
        public string TaiXe3ID { get; set; }
        public string TaiXe3Name { get; set; }
        public short TaiXe3GioLT { get; set; }
        public string PhoXe3ID { get; set; }
        public string PhoXe3Name { get; set; }
        public short PhoXe3GioLT { get; set; }
        public DateTime LenBan { get; set; }
        public DateTime NhanMay { get; set; }
        public DateTime RaKho { get; set; }
        public DateTime VaoKho { get; set; }
        public DateTime GiaoMay { get; set; }
        public DateTime XuongBan { get; set; }
        public int NLBanTruoc { get; set; }
        public int NLThucNhan { get; set; }
        public int NLLinh { get; set; }
        public string TramNLID { get; set; }
        public decimal NLTrongDoan { get; set; }
        public int NLBanSau { get; set; }
        public string SHDT { get; set; }
        public string MaCB { get; set; }
        public decimal DonDocDuong { get; set; }
        public decimal DungDocDuong { get; set; }
        public decimal DungNoMay { get; set; }
        public string GhiChu { get; set; }
    }
    public class XCoBaoCT
    {
        public long ID { get; set; }
        public long CoBaoID { get; set; }
        public DateTime NgayXP { get; set; }
        public DateTime GioDen { get; set; }
        public DateTime GioDi { get; set; }
        public decimal GioDon { get; set; }
        public string MacTauID { get; set; }
        public string CongTyID { get; set; }
        public string CongTyName { get; set; }
        public short CongTacID { get; set; }
        public string CongTacName { get; set; }
        public int GaID { get; set; }
        public string GaName { get; set; }
        public short? TuyenID { get; set; }
        public string TuyenName { get; set; }
        public decimal Tan { get; set; }
        public int XeTotal { get; set; }
        public decimal TanXeRong { get; set; }
        public int XeRongTotal { get; set; }
        public short TinhChatID { get; set; }
        public string TinhChatName { get; set; }
        public string MayGhepID { get; set; }
        public decimal KmAdd { get; set; }
    }
    public class XCoBaoDM
    {
        public long ID { get; set; }
        public long CoBaoID { get; set; }
        public short LoaiDauMoID { get; set; }
        public string LoaiDauMoName { get; set; }
        public string DonViTinh { get; set; }
        public decimal Nhan { get; set; }
        public decimal Linh { get; set; }
        public string MaTram { get; set; }
        public string TenTram { get; set; }
        public decimal Giao { get; set; }
    }
    #endregion

    #region Xuất đoạn thống điện tử
    public partial class TTXDoanthongdt
    {
        public XCobaodtTT XCobaodtTT { get; set; }
        public IEnumerable<HNXuatDT> HNXuatDT { get; set; }
        public IEnumerable<YVXuatDT> YVXuatDT { get; set; }       
        public IEnumerable<VIXuatDT> VIXuatDT { get; set; }
        public IEnumerable<DNXuatDT> DNXuatDT { get; set; }
        public IEnumerable<SGXuatDT> SGXuatDT { get; set; }
    }
    public partial class HNXuatDT
    {
        public string socb { get; set; }
        public string lmay { get; set; }
        public string dmay { get; set; }
        public string sdb1 { get; set; }
        public string ten1 { get; set; }
        public string sdb2 { get; set; }
        public string ten2 { get; set; }
        public string sdb3 { get; set; }
        public string ten3 { get; set; }
        public string mtau { get; set; }
        public short ctac { get; set; }
        public string ctacp { get; set; }
        public short tchat { get; set; }
        public string kdoan { get; set; }
        public decimal slbt { get; set; }
        public decimal sllh { get; set; }
        public decimal sldl_d { get; set; }
        public decimal sldl_m { get; set; }
        public decimal slbs { get; set; }
        public decimal sltt { get; set; }
        public decimal sltc { get; set; }
        public decimal slpt { get; set; }
        public string nlanh { get; set; }
        public string nlieu { get; set; }
        public bool thnl { get; set; }
        public bool thbt { get; set; }
        public bool phnl { get; set; }
        public bool phpt { get; set; }
        public short pdoan { get; set; }
        public string gaxp { get; set; }
        public DateTime daycb { get; set; }
        public decimal dgkb { get; set; }
        public decimal dgdm { get; set; }
        public decimal dgdn { get; set; }
        public decimal dgkm { get; set; }
        public decimal dgkn { get; set; }
        public decimal dgqd { get; set; }
        public decimal giqv { get; set; }
        public decimal gilh { get; set; }
        public decimal gidt { get; set; }
        public decimal dgxp { get; set; }
        public decimal dgdd { get; set; }
        public decimal dgcc { get; set; }
        public decimal dnxp { get; set; }
        public decimal dndd { get; set; }
        public decimal dncc { get; set; }
        public decimal slrk { get; set; }
        public decimal kmch { get; set; }
        public decimal kmdw { get; set; }
        public decimal kmgh { get; set; }
        public decimal kmdy { get; set; }
        public decimal tkch { get; set; }
        public decimal tkdw { get; set; }
        public decimal tkgh { get; set; }
        public decimal tkdy { get; set; }
        public string l_nt { get; set; }
        public string l_bg { get; set; }
        public string l_gz { get; set; }
        public decimal l_dc { get; set; }
        public decimal l_tl { get; set; }
        public decimal l_gt { get; set; }
        public decimal t_nt { get; set; }
        public decimal t_bg { get; set; }
        public decimal t_gz { get; set; }
        public decimal t_dc { get; set; }
        public decimal t_tl { get; set; }
        public decimal t_gt { get; set; }
        public decimal c_nt { get; set; }
        public decimal c_bg { get; set; }
        public decimal c_gz { get; set; }
        public decimal c_dc { get; set; }
        public decimal c_tl { get; set; }
        public decimal c_gt { get; set; }
        public decimal slrkm { get; set; }
        public decimal slrkn { get; set; }
        public decimal tgtnm { get; set; }
        public decimal tgtnn { get; set; }
        public string maql { get; set; }
        public string q { get; set; }
        public string lldg { get; set; }
        public string dayxp { get; set; }
        public string dtau { get; set; }
        public string mghep { get; set; }
        public int ThangDT { get; set; }
        public int NamDT { get; set; }
    }
    public partial class YVXuatDT
    {
        public string SOCB { get; set; }
        public string LMAY { get; set; }
        public string DMAY { get; set; }
        public string SDB1 { get; set; }
        public string TEN1 { get; set; }
        public string SDB2 { get; set; }
        public string TEN2 { get; set; }
        public string SDB3 { get; set; }
        public string TEN3 { get; set; }
        public string MTAU { get; set; }
        public short CTAC { get; set; }
        public string CTACP { get; set; }
        public short TCHAT { get; set; }
        public string MDOAN { get; set; }
        public string KDOAN { get; set; }
        public decimal SLBT { get; set; }
        public decimal SLLH { get; set; }
        public decimal SLDL_D { get; set; }
        public decimal SLDL_M { get; set; }
        public decimal SLBS { get; set; }
        public decimal SLTT { get; set; }
        public decimal SLTC { get; set; }
        public decimal SLPT { get; set; }
        public string NLANH { get; set; }
        public string NLIEU { get; set; }
        public bool THNL { get; set; }
        public bool THBT { get; set; }
        public bool PHNL { get; set; }
        public bool PHBT { get; set; }
        public short PDOAN { get; set; }
        public string GAXP { get; set; }
        public DateTime DAYCB { get; set; }
        public decimal DGKB { get; set; }
        public decimal DGDM { get; set; }
        public decimal DGDN { get; set; }
        public decimal DGKM { get; set; }
        public decimal DGKN { get; set; }
        public decimal DGQD { get; set; }
        public decimal GIQV { get; set; }
        public decimal GILH { get; set; }
        public decimal GIDT { get; set; }
        public decimal DGXP { get; set; }
        public decimal DGDD { get; set; }
        public decimal DGCC { get; set; }
        public decimal DNXP { get; set; }
        public decimal DNDD { get; set; }
        public decimal DNCC { get; set; }
        public decimal SLRK { get; set; }
        public decimal KMCH { get; set; }
        public decimal KMDW { get; set; }
        public decimal KMGH { get; set; }
        public decimal KMDY { get; set; }
        public decimal TKCH { get; set; }
        public decimal TKDW { get; set; }
        public decimal TKGH { get; set; }
        public decimal TKDY { get; set; }
        public string L_TN { get; set; }
        public string L_BG { get; set; }
        public string L_GZ { get; set; }
        public decimal L_DC { get; set; }
        public decimal L_TL { get; set; }
        public decimal L_GT { get; set; }
        public decimal T_TN { get; set; }
        public decimal T_BG { get; set; }
        public decimal T_GZ { get; set; }
        public decimal T_DC { get; set; }
        public decimal T_TL { get; set; }
        public decimal T_GT { get; set; }
        public decimal C_TN { get; set; }
        public decimal C_BG { get; set; }
        public decimal C_GZ { get; set; }
        public decimal C_DC { get; set; }
        public decimal C_TL { get; set; }
        public decimal C_GT { get; set; }
        public decimal SLRKM { get; set; }
        public decimal SLRKN { get; set; }
        public decimal TGTNM { get; set; }
        public decimal TGTNN { get; set; }
        public string MAQL { get; set; }
        public string Q { get; set; }
        public string LLDG { get; set; }
        public string CTY { get; set; }
        public DateTime DAY_LT { get; set; }
        public string DTAU { get; set; }
        public string GA_LT { get; set; }
    }   
    public partial class VIXuatDT
    {
        public string socb { get; set; }
        public string lmay { get; set; }
        public string dmay { get; set; }
        public string sdb1 { get; set; }
        public string ten1 { get; set; }
        public string sdb2 { get; set; }
        public string ten2 { get; set; }
        public string sdb3 { get; set; }
        public string ten3 { get; set; }
        public string sdb4 { get; set; }
        public string ten4 { get; set; }
        public string tau { get; set; }
        public string cty { get; set; }
        public short ctac { get; set; }
        public string ctacp { get; set; }
        public short tchat { get; set; }
        public string kdoan { get; set; }
        public decimal slbt { get; set; }
        public decimal sll1 { get; set; }
        public decimal sll2 { get; set; }
        public decimal slsd { get; set; }
        public decimal slbs { get; set; }
        public decimal sltt { get; set; }
        public decimal sltc { get; set; }
        public decimal slpt { get; set; }
        public string kho1 { get; set; }
        public string kho2 { get; set; }
        public string nlieu { get; set; }
        public bool thnl { get; set; }
        public bool thbt { get; set; }
        public bool phnl { get; set; }
        public bool phpt { get; set; }
        public short pdoan { get; set; }
        public string gaxp { get; set; }
        public DateTime daycb { get; set; }
        public string dgkb { get; set; }
        public decimal dgdm { get; set; }
        public decimal dgdn { get; set; }
        public decimal tgtnm { get; set; }
        public decimal tgtnn { get; set; }
        public decimal dgkm { get; set; }
        public decimal dgkn { get; set; }
        public decimal dgqd { get; set; }
        public decimal giqv { get; set; }
        public decimal gilh { get; set; }
        public decimal gidt { get; set; }
        public decimal dgxp { get; set; }
        public decimal dgdd { get; set; }
        public decimal dgcc { get; set; }
        public string tglg { get; set; }
        public decimal dnxp { get; set; }
        public decimal dndd { get; set; }
        public decimal dncc { get; set; }
        public decimal slrk { get; set; }
        public decimal kmch { get; set; }
        public decimal kmdw { get; set; }
        public decimal kmgh { get; set; }
        public decimal kmng { get; set; }
        public decimal kmdy { get; set; }
        public decimal tkch { get; set; }
        public decimal tkdw { get; set; }
        public decimal tkgh { get; set; }
        public decimal tkdy { get; set; }
        public decimal tkdd { get; set; }
        public string k1bt { get; set; }
        public string k2bt { get; set; }
        public decimal l1d1 { get; set; }
        public decimal l2d1 { get; set; }
        public decimal l1d2 { get; set; }
        public decimal l2d2 { get; set; }
        public decimal l3d1 { get; set; }
        public decimal l3d2 { get; set; }
        public decimal t_d1 { get; set; }
        public decimal t_d2 { get; set; }
        public decimal t_d3 { get; set; }
        public decimal c_d1 { get; set; }
        public decimal c_d2 { get; set; }
        public decimal c_d3 { get; set; }
        public decimal slrkm { get; set; }
        public decimal slrkn { get; set; }
        public decimal gioa { get; set; }
        public decimal giod { get; set; }
        public decimal dgnl { get; set; }
        public int ThangDT { get; set; }
        public int NamDT { get; set; }
    }
    public partial class DNXuatDT
    {
        public string socb { get; set; }
        public string madm { get; set; }
        public short mact { get; set; }
        public string ramxe { get; set; }
        public string doimay { get; set; }
        public string cv { get; set; }
        public string makd { get; set; }
        public string vr { get; set; }
        public DateTime ngaydi { get; set; }
        public string giodi { get; set; }
        public string mactau { get; set; }
        public short matc { get; set; }
        public string cb_c { get; set; }
        public string chinh { get; set; }
        public string cb_g { get; set; }
        public string ghep { get; set; }
        public string cb_d1 { get; set; }
        public string day1 { get; set; }
        public string cb_d2 { get; set; }
        public string day2 { get; set; }
        public string kep { get; set; }
        public string don2 { get; set; }
        public decimal solanrk { get; set; }
        public decimal km { get; set; }
        public decimal tkmdm { get; set; }
        public decimal toaxe { get; set; }
        public decimal kmtoaxe { get; set; }
        public decimal tan { get; set; }
        public decimal tkm { get; set; }
        public decimal tanqd { get; set; }
        public decimal tkmqd { get; set; }
        public decimal donxp { get; set; }
        public decimal dondd { get; set; }
        public decimal doncc { get; set; }
        public decimal dungdd { get; set; }
        public decimal dungddnl { get; set; }
        public decimal dungxp { get; set; }
        public decimal dungxpnl { get; set; }
        public decimal dungcc { get; set; }
        public decimal dungccnl { get; set; }
        public decimal dscdm { get; set; }
        public decimal dscdn { get; set; }
        public decimal lh { get; set; }
        public decimal qvlh { get; set; }
        public decimal dungdn { get; set; }
        public decimal dungdm { get; set; }
        public decimal dctlmdm { get; set; }
        public decimal dctlmdmnl { get; set; }
        public decimal dctlmdn { get; set; }
        public decimal dctlmdnnl { get; set; }
        public decimal nldung { get; set; }
        public decimal nldon { get; set; }
        public decimal nltanso { get; set; }
        public decimal nlrvkho { get; set; }
        public decimal nltc { get; set; }
        public decimal nltt { get; set; }
        public string cty { get; set; }
        public decimal gogio { get; set; }
        public decimal nlrc { get; set; }
        public string gaxp { get; set; }
        public DateTime ngayxp { get; set; }
        public string mkep { get; set; }
        public decimal tmkep { get; set; }
        public decimal tkmnguoi { get; set; }
        public decimal nltt15 { get; set; }
        public string dcham { get; set; }
        public decimal nldcham { get; set; }
        public string makdphu { get; set; }
        public int ThangDT { get; set; }
        public int NamDT { get; set; }
    }
    public partial class SGXuatDT
    {
        public long socb { get; set; }
        public string sohieucb { get; set; }
        public string lmay { get; set; }
        public string dmay { get; set; }
        public string madv { get; set; }
        public string maso { get; set; }
        public int doi { get; set; }
        public string sdb1 { get; set; }
        public string ten1 { get; set; }
        public string sdb2 { get; set; }
        public string ten2 { get; set; }
        public string sdb3 { get; set; }
        public string ten3 { get; set; }
        public string sdb4 { get; set; }
        public string ten4 { get; set; }
        public string sdb5 { get; set; }
        public string ten5 { get; set; }
        public string sdb6 { get; set; }
        public string ten6 { get; set; }
        public string tau { get; set; }
        public short ctac { get; set; }
        public string ctacp { get; set; }
        public short tchat { get; set; }
        public string kdoan { get; set; }
        public decimal slbt { get; set; }
        public decimal sllh { get; set; }
        public decimal slsd { get; set; }
        public decimal slbs { get; set; }
        public decimal sltt { get; set; }
        public decimal sltc { get; set; }
        public decimal ca3 { get; set; }
        public decimal hscb { get; set; }
        public decimal bunl { get; set; }
        public decimal lsl1 { get; set; }
        public decimal slpt { get; set; }
        public string nlanh { get; set; }
        public string nlieu { get; set; }
        public bool thnl { get; set; }
        public bool thbt { get; set; }
        public bool phnl { get; set; }
        public bool phpt { get; set; }
        public short pdoan { get; set; }
        public string gaxp { get; set; }
        public string gakt { get; set; }
        public DateTime daycb { get; set; }
        public string ngaylaptau { get; set; }
        public string galaptau { get; set; }
        public string tgltau { get; set; }
        public string glb { get; set; }
        public string gnm { get; set; }
        public string grk { get; set; }
        public string gvk { get; set; }
        public string ggm { get; set; }
        public string gxb { get; set; }
        public decimal dgkb { get; set; }
        public decimal dgdm { get; set; }
        public decimal dgdn { get; set; }
        public decimal dgkm { get; set; }
        public decimal dgkn { get; set; }
        public decimal dgqd { get; set; }
        public decimal giqv { get; set; }
        public decimal gilh { get; set; }
        public decimal gidt { get; set; }
        public decimal dgxp { get; set; }
        public decimal dgdd { get; set; }
        public string dgbd { get; set; }
        public decimal dgcc { get; set; }
        public decimal dnxp { get; set; }
        public decimal dndd { get; set; }
        public decimal dncc { get; set; }
        public decimal slrk { get; set; }
        public decimal kmch { get; set; }
        public decimal kmdw { get; set; }
        public decimal kmgh { get; set; }
        public decimal kmdy { get; set; }
        public decimal tkch { get; set; }
        public decimal tkdw { get; set; }
        public decimal tkgh { get; set; }
        public decimal tkdy { get; set; }
        public decimal srcg { get; set; }
        public decimal l_d1 { get; set; }
        public decimal l_d2 { get; set; }
        public decimal l_d3 { get; set; }
        public decimal t_d1 { get; set; }
        public decimal t_d2 { get; set; }
        public decimal t_d3 { get; set; }
        public decimal c_d1 { get; set; }
        public decimal c_d2 { get; set; }
        public decimal c_d3 { get; set; }
        public decimal slrkm { get; set; }
        public decimal slrkn { get; set; }
        public decimal tgtnm { get; set; }
        public decimal tgtnn { get; set; }
        public decimal bulo { get; set; }
        public decimal tylebulo { get; set; }
        public decimal dthicong { get; set; }
        public decimal bunbd { get; set; }
        public int ThangDT { get; set; }
        public int NamDT { get; set; }
    }
    #endregion

    #region Cơ báo giấy      
    public partial class TTCobaoga
    {
        public CoBaoGAView CobaoTT { get; set; }
        public IEnumerable<CoBaoGA> CoBaoGA { get; set; }
    }

    public partial class TTCobaogact
    {
        public BCCoBaoTTInfo BCCoBaoTTInfo { get; set; }
        public CoBaoGA CoBaoGA { get; set; }
    }
    public partial class CoBaoGAView
    {
        public string Xinghiep { get; set; }
        public string Trangthai { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Begin { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime End { get; set; }
        public string Socb { get; set; }
        public string Daumay { get; set; }
        public string Taixe { get; set; }
    }
    public class CoBaoGATT
    {
        public long CoBaoID { get; set; }
        public long CoBaoGoc { get; set; }
        public string SoCB { get; set; }
        public DateTime NgayCB { get; set; }
        public string DauMayID { get; set; }
        public string LoaiMayID { get; set; }
        public int QuayVong { get; set; }
        public int LuHanh { get; set; }
        public int DonThuan { get; set; }
        public int GioDon { get; set; }
        public int GioDung { get; set; }
        public decimal KM { get; set; }
        public decimal TKM { get; set; }
        public decimal NLTieuThu { get; set; }
        public decimal NLTieuChuan { get; set; }
        public decimal NLLoiLo { get; set; }
    }
    public class CoBaoGA
    {
        public long CoBaoID { get; set; }
        public long CoBaoGoc { get; set; }
        public string DauMayID { get; set; }
        public string LoaiMayID { get; set; }
        public string DvdmID { get; set; }
        public string DvdmName { get; set; }
        public string SoCB { get; set; }
        public string DvcbID { get; set; }
        public string DvcbName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayCB { get; set; }
        public int RutGio { get; set; }
        public string ChatLuong { get; set; }
        public decimal SoLanRaKho { get; set; }
        public string TaiXe1ID { get; set; }
        public string TaiXe1Name { get; set; }
        public short TaiXe1GioLT { get; set; }
        public string PhoXe1ID { get; set; }
        public string PhoXe1Name { get; set; }
        public short PhoXe1GioLT { get; set; }
        public string TaiXe2ID { get; set; }
        public string TaiXe2Name { get; set; }
        public short TaiXe2GioLT { get; set; }
        public string PhoXe2ID { get; set; }
        public string PhoXe2Name { get; set; }
        public short PhoXe2GioLT { get; set; }
        public string TaiXe3ID { get; set; }
        public string TaiXe3Name { get; set; }
        public short TaiXe3GioLT { get; set; }
        public string PhoXe3ID { get; set; }
        public string PhoXe3Name { get; set; }
        public short PhoXe3GioLT { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime LenBan { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime NhanMay { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime RaKho { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime VaoKho { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime GiaoMay { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime XuongBan { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int NLBanTruoc { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int NLThucNhan { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int NLLinh { get; set; }
        public string TramNLID { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal NLTrongDoan { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int NLBanSau { get; set; }
        public string SHDT { get; set; }
        public string MaCB { get; set; }
        public decimal DonDocDuong { get; set; }
        public decimal DungDocDuong { get; set; }
        public decimal DungNoMay { get; set; }
        public string GhiChu { get; set; }
        public int GaID { get; set; }
        public string GaName { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string CreatedName { get; set; }
        public DateTime Modifydate { get; set; }
        public string Modifyby { get; set; }
        public string ModifyName { get; set; }
        public string TrangThai { get; set; }
        public bool KhoaCB { get; set; }
        public List<CoBaoGACT> coBaoGACTs { get; set; }
        public List<CoBaoGADM> coBaoGADMs { get; set; }
    }
    public class CoBaoGACT
    {
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime NgayXP { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime GioDen { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime GioDi { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal PhutDon { get; set; }
        public string MacTauID { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal RutGioNL { get; set; }
        public bool DungGioPT { get; set; }
        public int GaID { get; set; }
        public string GaName { get; set; }
        public short TinhChatID { get; set; }
        public string TinhChatName { get; set; }
        public string MayGhepID { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Tan { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int XeTotal { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TanXeRong { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int XeRongTotal { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal KmAdd { get; set; }
        public short LoaiTauID { get; set; }
        public string LoaiTauName { get; set; }
        public short? TuyenID { get; set; }
        public string TuyenName { get; set; }
        public string CongTyID { get; set; }
        public string CongTyName { get; set; }
        public long TauID { get; set; }
        public long CoBaoID { get; set; }      
    }
    public class CoBaoGADM
    {       
        public long CoBaoID { get; set; }
        public short LoaiDauMoID { get; set; }
        public string LoaiDauMoName { get; set; }
        public string DonViTinh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal Nhan { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal Linh { get; set; }
        public string MaTram { get; set; }
        public string TenTram { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal Giao { get; set; }
    }
    public class CoBaoGAALL
    {
        public long CoBaoID { get; set; }
        public CoBaoGA coBaoGAs { get; set; }
        //public DoanThongGA doanThongGAs { get; set; }
    }
    public class BCCoBaoGACTInfo
    {
        public int SoTT { get; set; }
        public DateTime NgayXP { get; set; }
        public string GioDen { get; set; }
        public string GioDi { get; set; }
        public string GioDon { get; set; }
        public string RutGioNL { get; set; }
        public bool DungGioPT { get; set; }
        public string MacTau { get; set; }
        public string GaDi { get; set; }
        public decimal Tan { get; set; }
        public int xeTotal { get; set; }
        public decimal TanRong { get; set; }
        public int xeRong { get; set; }
        public string TinhChat { get; set; }
        public string MayGhep { get; set; }
        public decimal KmAdd { get; set; }
    }
    public partial class HNPhieuThuong
    {
        public long ID { get; set; }
        public string LoaiPhieu { get; set; }
        public string MacTau { get; set; }
        public int GaID { get; set; }
        public string GaName { get; set; }
        public decimal? DonGia { get; set; }
        public string DonVi { get; set; }
        public DateTime NgayHL { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyName { get; set; }
    }
    #endregion

    #region Đoạn thống giấy
    public partial class TTDoanthongga
    {
        public DoanthongGATT DoanthongGATT { get; set; }
        public IEnumerable<DoanThongGAView> DoanThongGAView { get; set; }
    }
    public partial class TTDoanthonggact
    {
        public BCCoBaoTTInfo BCCoBaoTTInfo { get; set; }
        public DoanThongGAView DoanThongGAView { get; set; }
        public IEnumerable<DoanThongGACT> DoanThongGACT { get; set; }
        public IEnumerable<DoanThongGADM> DoanThongGADM { get; set; }
    }
    public partial class DoanthongGATT
    {
        public string Xinghiep { get; set; }
        public string Loaimay { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Begin { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime End { get; set; }
        public string Socb { get; set; }
        public string Daumay { get; set; }
        public string Taixe { get; set; }
        public string Mactau { get; set; }
        public long DoanThongID { get; set; }
    }
    public class DoanThongGAView
    {
        public long DoanThongID { get; set; }
        public long CoBaoGoc { get; set; }
        public string SoCB { get; set; }
        public string DauMayID { get; set; }
        public string LoaiMayID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayCB { get; set; }
        public string TaiXe1ID { get; set; }
        public string TaiXe1Name { get; set; }
        public string PhoXe1ID { get; set; }
        public string PhoXe1Name { get; set; }
        public string TaiXe2ID { get; set; }
        public string TaiXe2Name { get; set; }
        public string PhoXe2ID { get; set; }
        public string PhoXe2Name { get; set; }
        public string TaiXe3ID { get; set; }
        public string TaiXe3Name { get; set; }
        public string PhoXe3ID { get; set; }
        public string PhoXe3Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime LenBan { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime NhanMay { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime RaKho { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime VaoKho { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime GiaoMay { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime XuongBan { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungKB { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int NLBanTruoc { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int NLThucNhan { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int NLLinh { get; set; }
        public string TramNLID { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal NLTrongDoan { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int NLBanSau { get; set; }
        public int ThangDT { get; set; }
        public int NamDT { get; set; }
        public string DvdmName { get; set; }
        public string DvcbID { get; set; }
        public string DvcbName { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string CreatedName { get; set; }
        public DateTime Modifydate { get; set; }
        public string Modifyby { get; set; }
        public string ModifyName { get; set; }
    }
    public class DoanThongGA
    {
        public long DoanThongID { get; set; }
        public int DungKB { get; set; }
        public int ThangDT { get; set; }
        public int NamDT { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string CreatedName { get; set; }
        public DateTime Modifydate { get; set; }
        public string Modifyby { get; set; }
        public string ModifyName { get; set; }
        public List<DoanThongGACT> doanThongGACTs { get; set; }
        public List<DoanThongGADM> doanThongGADMs { get; set; }
    }
    public class DoanThongGACT
    {
        public short STT { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime NgayXP { get; set; }
        public long TauID { get; set; }
        public string MacTauID { get; set; }
        public int GaXPID { get; set; }
        public string GaXPName { get; set; }
        public int GaKTID { get; set; }
        public string GaKTName { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal DinhMuc { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TieuThu { get; set; }
        public string KhuDoan { get; set; }
        public string DienGiai { get; set; }
        public string CongTyID { get; set; }
        public string CongTyName { get; set; }
        public short CongTacID { get; set; }
        public string CongTacName { get; set; }
        public short TinhChatID { get; set; }
        public string TinhChatName { get; set; }
        public string TuyenID { get; set; }
        public string TuyenName { get; set; }
        public string MayGhepID { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int QuayVong { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int LuHanh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DonThuan { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungDM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungDN { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungQD { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungXP { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungDD { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungKT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungKhoDM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungKhoDN { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DungNM { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DonXP { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DonDD { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int DonKT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KMChinh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KMDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KMGhep { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal KMDay { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TKMChinh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TKMDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TKMGhep { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TKMDay { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Tan { get; set; }
        public int XeTotal { get; set; }
        public decimal TanXeRong { get; set; }
        public int XeRongTotal { get; set; }
        public decimal SLRKDM { get; set; }
        public decimal SLRKDN { get; set; }
        public long ID { get; set; }
        public long DoanThongID { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal RutGioNL { get; set; }
    }
    public class DoanThongGADM
    {
        public long ID { get; set; }
        public long DoanThongID { get; set; }
        public short LoaiDauMoID { get; set; }
        public string LoaiDauMoName { get; set; }
        public string DonViTinh { get; set; }
        public string DienGiai { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal DinhMuc { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TieuThu { get; set; }
    }
    #endregion

    #region Xuất cơ báo điện tử   
    public partial class TTXCobaoga
    {
        public XCobaodtTT XCobaodtTT { get; set; }
        public IEnumerable<XCoBaoGA> XCoBaoGA { get; set; }
        public IEnumerable<XCoBaoGACT> XCoBaoGACT { get; set; }
        public IEnumerable<XCoBaoGADM> XCoBaoGADM { get; set; }
    }
    public class XCoBaoGA
    {
        public long CoBaoID { get; set; }
        public long CoBaoGoc { get; set; }
        public string SoCB { get; set; }
        public string DauMayID { get; set; }
        public string LoaiMayID { get; set; }
        public string DvdmID { get; set; }
        public string DvdmName { get; set; }
        public string DvcbID { get; set; }
        public string DvcbName { get; set; }
        public DateTime NgayCB { get; set; }
        public int RutGio { get; set; }
        public string ChatLuong { get; set; }
        public decimal SoLanRaKho { get; set; }
        public string TaiXe1ID { get; set; }
        public string TaiXe1Name { get; set; }
        public short TaiXe1GioLT { get; set; }
        public string PhoXe1ID { get; set; }
        public string PhoXe1Name { get; set; }
        public short PhoXe1GioLT { get; set; }
        public string TaiXe2ID { get; set; }
        public string TaiXe2Name { get; set; }
        public short TaiXe2GioLT { get; set; }
        public string PhoXe2ID { get; set; }
        public string PhoXe2Name { get; set; }
        public short PhoXe2GioLT { get; set; }
        public string TaiXe3ID { get; set; }
        public string TaiXe3Name { get; set; }
        public short TaiXe3GioLT { get; set; }
        public string PhoXe3ID { get; set; }
        public string PhoXe3Name { get; set; }
        public short PhoXe3GioLT { get; set; }
        public DateTime LenBan { get; set; }
        public DateTime NhanMay { get; set; }
        public DateTime RaKho { get; set; }
        public DateTime VaoKho { get; set; }
        public DateTime GiaoMay { get; set; }
        public DateTime XuongBan { get; set; }
        public int NLBanTruoc { get; set; }
        public int NLThucNhan { get; set; }
        public int NLLinh { get; set; }
        public string TramNLID { get; set; }
        public decimal NLTrongDoan { get; set; }
        public int NLBanSau { get; set; }
        public string SHDT { get; set; }
        public string MaCB { get; set; }
        public decimal DonDocDuong { get; set; }
        public decimal DungDocDuong { get; set; }
        public decimal DungNoMay { get; set; }
        public string GhiChu { get; set; }
    }
    public class XCoBaoGACT
    {
        public long CoBaoID { get; set; }
        public DateTime NgayXP { get; set; }
        public DateTime GioDen { get; set; }
        public DateTime GioDi { get; set; }
        public decimal PhutDon { get; set; }
        public string MacTauID { get; set; }
        public string CongTyID { get; set; }
        public string CongTyName { get; set; }
        public short LoaiTauID { get; set; }
        public string LoaiTauName { get; set; }
        public int GaID { get; set; }
        public string GaName { get; set; }
        public short? TuyenID { get; set; }
        public string TuyenName { get; set; }
        public decimal Tan { get; set; }
        public int XeTotal { get; set; }
        public decimal TanXeRong { get; set; }
        public int XeRongTotal { get; set; }
        public short TinhChatID { get; set; }
        public string TinhChatName { get; set; }
        public string MayGhepID { get; set; }
        public decimal KmAdd { get; set; }
        public decimal RutGioNL { get; set; }
        public bool DungGioPT { get; set; }
    }
    public class XCoBaoGADM
    {
        public long CoBaoID { get; set; }
        public short LoaiDauMoID { get; set; }
        public string LoaiDauMoName { get; set; }
        public string DonViTinh { get; set; }
        public decimal Nhan { get; set; }
        public decimal Linh { get; set; }
        public string MaTram { get; set; }
        public string TenTram { get; set; }
        public decimal Giao { get; set; }
    }
    #endregion

    #region Nhiên liệu
    public partial class DMLoaiDauMo
    {
        public short ID { get; set; }
        public string LoaiDauMo { get; set; }
        public string DonViTinh { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyName { get; set; }
    }   
    public partial class TTLoaidm
    {        
        public string Loaidmtt { get; set; }
        public IEnumerable<DMLoaiDauMo> DMLoaiDauMo { get; set; }
    }
    public partial class NL_NhaCC
    {
        public int ID { get; set; }
        public string TenTat { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Mst { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string NganHang { get; set; }
        public string TaiKhoan { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyName { get; set; }
    }
    public partial class TTNhacc
    {
        public string Tenncc { get; set; }
        public IEnumerable<NL_NhaCC> NL_NhaCC { get; set; }
    }
    public partial class NL_HopDong
    {
        public int ID { get; set; }
        public int MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string HopDong { get; set; }
        public string DienGiai { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayHL { get; set; }      
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal TyLe { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyName { get; set; }
    }
    public partial class TTHopdong
    {
        public string Tenncc { get; set; }
        public string Tenhd { get; set; }
        public IEnumerable<NL_HopDong> NL_HopDong { get; set; }
    }
    public partial class NL_BangGia
    {
        public string MaTramNL { get; set; }
        public string TenTramNL { get; set; }
        public short MaDauMo { get; set; }
        public string TenDauMo { get; set; }
        public string DonViTinh { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime NgayHL { get; set; }
        public long PhieuNhapID { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal DonGia { get; set; }
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public Decimal TyTrong { get; set; }
        public string GhiChu { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyName { get; set; }
    }
    public partial class TTGiadm
    {
        public string Tramln { get; set; }
        public string Loaidm { get; set; }       
        public DateTime Begin { get; set; }        
        public DateTime End { get; set; }
        public IEnumerable<NL_BangGia> NL_BangGia { get; set; }
    }
    public partial class TTPhieunhap
    {
        public string Tramnl { get; set; }
        public string Nhacc { get; set; }
        public string Mapn { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public IEnumerable<NL_PhieuNhap> NL_PhieuNhap { get; set; }
    }
    public partial class NL_PhieuNhap
    {
        public long PhieuNhapID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime NgayNhap { get; set; }
        public string LoaiPhieu { get; set; }
        public string MaTramNL { get; set; }
        public string TenTramNL { get; set; }
        public int MaNCC { get; set; }
        public string TenNCC { get; set; }
        public int MaHopDong { get; set; }
        public string TenHopDong { get; set; }
        public string SoHoaDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayHoaDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TyLe { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public Decimal VAT { get; set; }
        public string NguoiGiao { get; set; }
        public string LyDo { get; set; }
        public bool KhoaSo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyName { get; set; }
        public List<NL_PhieuNhapCT> NL_PhieuNhapCTs { get; set; }
    }   
    public partial class NL_PhieuNhapCT
    {
        public long PhieuNhapID { get; set; }
        public short MaDauMo { get; set; }
        public string TenDauMo { get; set; }
        public string DonViTinh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public Decimal NhietDo { get; set; }
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public Decimal TyTrong { get; set; }
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public Decimal VCF { get; set; }
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public decimal SoLuong { get; set; }
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public decimal SoLuongVCF { get; set; }
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public decimal ConLai { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal DonGia { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TyLe { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public Decimal Vat { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal ThanhTien { get; set; }
    }
    public partial class TTPhieuxuat
    {
        public string Tramnl { get; set; }
        public string Loaimay { get; set; }
        public string Daumay { get; set; }
        public string Mapx { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public IEnumerable<NL_PhieuXuat> NL_PhieuXuat { get; set; }
    }
    public partial class NL_PhieuXuat
    {
        public long PhieuXuatID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime NgayXuat { get; set; }
        public string LoaiPhieu { get; set; }
        public string MaTramNL { get; set; }
        public string TenTramNL { get; set; }
        public string DauMayID { get; set; }
        public string LoaiMayID { get; set; }
        public string SoChungTu { get; set; }
        public string NguoiNhan { get; set; }
        public string LyDo { get; set; }
        public bool KhoaSo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyName { get; set; }
        public List<NL_PhieuXuatCT> NL_PhieuXuatCTs { get; set; }
    }
    public partial class NL_PhieuXuatCT
    {
        public long PhieuXuatID { get; set; }
        public short MaDauMo { get; set; }
        public string TenDauMo { get; set; }
        public string DonViTinh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public Decimal NhietDo { get; set; }
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public Decimal TyTrong { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public Decimal VCF { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal SoLuong { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal SoLuongVCF { get; set; }
        public long PhieuNhapID { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal DonGia { get; set; }
        public long BangGiaID { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal ThanhTien { get; set; }
    }
    public partial class BCNhapkho
    {
        public string Xinghiep { get; set; }
        public string Nhombc { get; set; }
        public string Loaibc { get; set; }       
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public string Tenbc { get; set; }
        public IEnumerable<NL_BCNhapKho> NL_BCNhapKho { get; set; }
    }
    public class NL_BCNhapKho
    {
        public long PhieuNhapID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime NgayNhap { get; set; }
        public string LoaiPhieu { get; set; }
        public string TenTramNL { get; set; }
        public string TenNCC { get; set; }
        public string TenHopDong { get; set; }
        public string SoHoaDon { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayHoaDon { get; set; }
        public string NguoiGiao { get; set; }
        public string LyDo { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public Decimal VAT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public Decimal TongTien { get; set; }
    }
    public partial class BCXuatkho
    {
        public string Xinghiep { get; set; }
        public string Nhombc { get; set; }
        public string Loaibc { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public string Tenbc { get; set; }
        public IEnumerable<NL_BCXuatKho> NL_BCXuatKho { get; set; }
    }
    public class NL_BCXuatKho
    {
        public long PhieuXuatID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime NgayXuat { get; set; }
        public string LoaiPhieu { get; set; }
        public string TenTramNL { get; set; }
        public string DauMayID { get; set; }
        public string LoaiMayID { get; set; }
        public string SoChungTu { get; set; }
        public string NguoiNhan { get; set; }
        public string LyDo { get; set; }
        [DisplayFormat(DataFormatString = "{0:N4}")]
        public Decimal VCF { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public Decimal TongTien { get; set; }
    }
    public partial class BCThekho
    {
        public string Xinghiep { get; set; }
        public string Tramnl { get; set; }
        public string Loaidm { get; set; }
        public string Loaibc { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public string Tenbc { get; set; }
        public IEnumerable<NL_BCTheKho> NL_BCTheKho { get; set; }
    }
    public partial class NL_BCTheKho
    {
        public long PhieuID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Ngay { get; set; }
        public string LoaiPhieu { get; set; }
        public string TramNL { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal SoLuong { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal ThanhTien { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal LuongTK { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TienTK { get; set; }
    }
    public partial class BCTonkho
    {
        public string Xinghiep { get; set; }
        public string Tramnl { get; set; }
        public string Loaidm { get; set; }
        public string Loaibc { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public string Tenbc { get; set; }
        public IEnumerable<NL_BCTonKho> NL_BCTonKho { get; set; }
    }
    public partial class NL_BCTonKho
    {
        public short MaDauMo { get; set; }
        public string TenDauMo { get; set; }
        public string DonViTinh { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal DonGia { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal LuongTD { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TienTD { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal LuongPN { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TienPN { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal LuongPXTT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal LuongPX { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TienPX { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal LuongTK { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TienTK { get; set; }
    }
    #endregion

}
