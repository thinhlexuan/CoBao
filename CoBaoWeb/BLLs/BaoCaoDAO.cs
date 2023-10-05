using CoBaoWeb.Models;
using CoBaoWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoBaoWeb.BLLs
{
    public class BaoCaoDAO
    {
        #region BC vận dụng
        private static List<BCVanDungInfo> BCVanDungList(List<ViewBcvanDung> dtDoanThong)
        {
            List<BCVanDungInfo> list = new List<BCVanDungInfo>();
            try
            {
                //Tạo list báo cáo.
                BCVanDungInfo vd = new BCVanDungInfo { SoTT = 401, ChiTieu = "Giờ đầu máy" }; list.Add(vd);//0
                vd = new BCVanDungInfo { SoTT = 402, ChiTieu = "    Lữ hành" }; list.Add(vd);//1
                vd = new BCVanDungInfo { SoTT = 403, ChiTieu = "    Đơn thuần" }; list.Add(vd);//2
                vd = new BCVanDungInfo { SoTT = 404, ChiTieu = "Đỗ ga đoạn mình" }; list.Add(vd);//3
                vd = new BCVanDungInfo { SoTT = 405, ChiTieu = "    Đoạn quay đầu" }; list.Add(vd);//4
                vd = new BCVanDungInfo { SoTT = 406, ChiTieu = "    Dọc đường" }; list.Add(vd);//5
                vd = new BCVanDungInfo { SoTT = 407, ChiTieu = "Dồn ga dọc đường" }; list.Add(vd);//6
                vd = new BCVanDungInfo { SoTT = 408, ChiTieu = "    Đoạn mình" }; list.Add(vd);//7
                vd = new BCVanDungInfo { SoTT = 409, ChiTieu = "    Đoạn quay đầu" }; list.Add(vd);//8
                vd = new BCVanDungInfo { SoTT = 410, ChiTieu = "Đỗ khu đoạn quay đầu" }; list.Add(vd);//9                
                vd = new BCVanDungInfo { SoTT = 411, ChiTieu = "Đỗ khu đoạn mình" }; list.Add(vd);//10                
                vd = new BCVanDungInfo { SoTT = 412, ChiTieu = "Km chạy của đầu máy" }; list.Add(vd);//11
                vd = new BCVanDungInfo { SoTT = 413, ChiTieu = "Vận tốc kỹ thuật" }; list.Add(vd);//12
                vd = new BCVanDungInfo { SoTT = 414, ChiTieu = "TGian TNghiệp ĐMình" }; list.Add(vd);//13                
                vd = new BCVanDungInfo { SoTT = 415, ChiTieu = "TGian TNghiệp ĐNgoài" }; list.Add(vd);//14               
                vd = new BCVanDungInfo { SoTT = 416, ChiTieu = "Tổng trọng tấn km" }; list.Add(vd);//15
                vd = new BCVanDungInfo { SoTT = 417, ChiTieu = "Số lần ra kho" }; list.Add(vd);//16
                vd = new BCVanDungInfo { SoTT = 418, ChiTieu = "    Đoạn mình" }; list.Add(vd);//17
                vd = new BCVanDungInfo { SoTT = 419, ChiTieu = "    Đoạn ngoài" }; list.Add(vd);//18
                vd = new BCVanDungInfo { SoTT = 420, ChiTieu = "Km tính đổi dồn" }; list.Add(vd);//19
                vd = new BCVanDungInfo { SoTT = 421, ChiTieu = "Km tính đổi dừng" }; list.Add(vd);//20
                vd = new BCVanDungInfo { SoTT = 422, ChiTieu = "Tổng km của đầu máy" }; list.Add(vd);//21
                vd = new BCVanDungInfo { SoTT = 423, ChiTieu = "Nhiên liệu tiêu thụ" }; list.Add(vd);//22
                vd = new BCVanDungInfo { SoTT = 424, ChiTieu = "    T/thụ lít 15C" }; list.Add(vd);//23               
                //Nạp dữ liệu từ bảng
                foreach (ViewBcvanDung dt in dtDoanThong)
                {
                    int maCT = (int)dt.CongTacId;
                    int maTC = (int)dt.TinhChatId;
                    string CTTC = maCT.ToString() + maTC.ToString();
                    vd = list[0]; NapListVanDung(CTTC, (decimal)dt.GioDm, ref vd);//401
                    vd = list[1]; NapListVanDung(CTTC, (decimal)dt.GioLh, ref vd);//402
                    vd = list[2]; NapListVanDung(CTTC, (decimal)dt.GioDt, ref vd);//403                                    
                    vd = list[3]; NapListVanDung(CTTC, (decimal)dt.Dgxp, ref vd);//404
                    decimal dogaDQD = (decimal)dt.Dgcc + (decimal)dt.Dgqd;
                    vd = list[4]; NapListVanDung(CTTC, dogaDQD, ref vd);//405
                    vd = list[5]; NapListVanDung(CTTC, (decimal)dt.Dgdd, ref vd);//406                                                      
                    vd = list[6]; NapListVanDung(CTTC, (decimal)dt.Dndd, ref vd);//407                    
                    vd = list[7]; NapListVanDung(CTTC, (decimal)dt.Dnxp, ref vd);//408                   
                    vd = list[8]; NapListVanDung(CTTC, (decimal)dt.Dncc, ref vd);//409
                    decimal dodoanQD = (decimal)dt.Dgdn + (decimal)dt.Dgkn;
                    vd = list[9]; NapListVanDung(CTTC, dodoanQD, ref vd);//410
                    decimal dodoanDM = (decimal)dt.Dgdm + (decimal)dt.Dgkm;
                    vd = list[10]; NapListVanDung(CTTC, dodoanDM, ref vd);//411
                    decimal kmTong = (decimal)dt.Kmch + (decimal)dt.Kmdw + (decimal)dt.Kmgh + (decimal)dt.Kmdy;
                    vd = list[11]; NapListVanDung(CTTC, kmTong, ref vd);//412
                    vd = list[13]; NapListVanDung(CTTC, dodoanQD, ref vd);//414
                    vd = list[14]; NapListVanDung(CTTC, dodoanDM, ref vd);//415
                    decimal tanKM = (decimal)dt.Tkch + (decimal)dt.Tkdw + (decimal)dt.Tkgh + (decimal)dt.Tkdy;
                    vd = list[15]; NapListVanDung(CTTC, tanKM, ref vd);//416
                    decimal slRK = (decimal)dt.Slrkm + (decimal)dt.Slrkn;
                    vd = list[16]; NapListVanDung(CTTC, slRK, ref vd);//417
                    vd = list[17]; NapListVanDung(CTTC, (decimal)dt.Slrkm, ref vd);//418
                    vd = list[18]; NapListVanDung(CTTC, (decimal)dt.Slrkn, ref vd);//419
                    decimal donTD = (decimal)dt.Dnxp + (decimal)dt.Dndd + (decimal)dt.Dncc;
                    vd = list[19]; NapListVanDung(CTTC, donTD, ref vd);//420         
                    decimal dungTD = (decimal)dt.Dgdm + (decimal)dt.Dgdn + (decimal)dt.Dgxp + (decimal)dt.Dgdd + (decimal)dt.Dgcc
                        + (decimal)dt.Dgqd + (decimal)dt.Dgkm + (decimal)dt.Dgkn;
                    vd = list[20]; NapListVanDung(CTTC, dungTD, ref vd);//421
                    vd = list[22]; NapListVanDung(CTTC, (decimal)dt.Sltt, ref vd);//423                   
                    vd = list[23]; NapListVanDung(CTTC, (decimal)(dt.Sltt15), ref vd);//422
                }
            }
            catch (Exception)
            {
                list = null;
            }
            return list;
        }
        private static void NapListVanDung(string CTTC, decimal iResult, ref BCVanDungInfo vd)
        {
            //Khách TN
            if (CTTC == "11") vd.KhachTNChinh += iResult;//chính
            if (CTTC == "12") vd.KhachTNDon += iResult;//Đơn
            if (CTTC == "13" || CTTC == "14" || CTTC == "16") vd.KhachTNGhep += iResult;//Ghep
            if (CTTC == "15") vd.KhachTNDay += iResult;//Day
            //Khach DP+HonHop
            if (CTTC == "21" || CTTC == "31") vd.KhachDPChinh += iResult;//chính
            if (CTTC == "22" || CTTC == "32") vd.KhachDPDon += iResult;//Đơn
            if (CTTC == "23" || CTTC == "24" || CTTC == "26" || CTTC == "33" || CTTC == "34" || CTTC == "36") vd.KhachDPGhep += iResult;//Ghep
            if (CTTC == "25" || CTTC == "35") vd.KhachDPDay += iResult;//Day
            //Hàng
            if (CTTC == "41" || CTTC == "101") vd.HangChinh += iResult;//chính
            if (CTTC == "42" || CTTC == "102") vd.HangDon += iResult;//Đơn
            if (CTTC == "43" || CTTC == "44" || CTTC == "46" || CTTC == "103" || CTTC == "104" || CTTC == "106") vd.HangGhep += iResult;//Ghép
            if (CTTC == "45" || CTTC == "105") vd.HangDay += iResult;//Đẩy            
            //Đá
            if (CTTC == "51") vd.DaChinh += iResult;//chính
            if (CTTC == "52") vd.DaDon += iResult;//Đơn
            if (CTTC == "53" || CTTC == "54" || CTTC == "56") vd.DaGhep += iResult;//Ghép
            if (CTTC == "55") vd.DaDay += iResult;//Đẩy            
            //Thoi
            if (CTTC == "61") vd.ThoiChinh += iResult;//chính
            if (CTTC == "62") vd.ThoiDon += iResult;//Đơn
            if (CTTC == "63" || CTTC == "64" || CTTC == "66") vd.ThoiGhep += iResult;//Ghép
            if (CTTC == "65") vd.ThoiDay += iResult;//Đẩy            
            //Công dụng
            if (CTTC == "71" || CTTC == "72" || CTTC == "73" || CTTC == "74" || CTTC == "75" || CTTC == "76") vd.CongDung += iResult;
            //Chuyên dồn
            if (CTTC == "81" || CTTC == "82" || CTTC == "83" || CTTC == "84" || CTTC == "85" || CTTC == "86"
                || CTTC == "91" || CTTC == "92" || CTTC == "93" || CTTC == "94" || CTTC == "95" || CTTC == "96"
                ) vd.ChuyenDon += iResult;
            //Tổng cộng
            vd.TongCong += iResult;
        }
        private static void ChangeMuniteToHour(ref BCVanDungInfo vd)
        {
            vd.KhachTNChinh /= 60;
            vd.KhachTNDon /= 60;
            vd.KhachTNGhep /= 60;
            vd.KhachTNDay /= 60;

            vd.KhachDPChinh /= 60;
            vd.KhachDPDon /= 60;
            vd.KhachDPGhep /= 60;
            vd.KhachDPDay /= 60;

            vd.HangChinh /= 60;
            vd.HangDon /= 60;
            vd.HangGhep /= 60;
            vd.HangDay /= 60;

            vd.DaChinh /= 60;
            vd.DaDon /= 60;
            vd.DaGhep /= 60;
            vd.DaDay /= 60;

            vd.ThoiChinh /= 60;
            vd.ThoiDon /= 60;
            vd.ThoiGhep /= 60;
            vd.ThoiDay /= 60;

            vd.CongDung /= 60;
            vd.ChuyenDon /= 60;
            vd.TongCong /= 60;
        }
        private static void ChangeVanToc(BCVanDungInfo vdKm, BCVanDungInfo vdGioDT, ref BCVanDungInfo vdVanToc)
        {
            vdVanToc.KhachTNChinh = vdGioDT.KhachTNChinh > 0 ? vdKm.KhachTNChinh / vdGioDT.KhachTNChinh : 0;
            vdVanToc.KhachTNDon = vdGioDT.KhachTNDon > 0 ? vdKm.KhachTNDon / vdGioDT.KhachTNDon : 0;
            vdVanToc.KhachTNGhep = vdGioDT.KhachTNGhep > 0 ? vdKm.KhachTNGhep / vdGioDT.KhachTNGhep : 0;
            vdVanToc.KhachTNDay = vdGioDT.KhachTNDay > 0 ? vdKm.KhachTNDay / vdGioDT.KhachTNDay : 0;

            vdVanToc.KhachDPChinh = vdGioDT.KhachDPChinh > 0 ? vdKm.KhachDPChinh / vdGioDT.KhachDPChinh : 0;
            vdVanToc.KhachDPDon = vdGioDT.KhachDPDon > 0 ? vdKm.KhachDPDon / vdGioDT.KhachDPDon : 0;
            vdVanToc.KhachDPGhep = vdGioDT.KhachDPGhep > 0 ? vdKm.KhachDPGhep / vdGioDT.KhachDPGhep : 0;
            vdVanToc.KhachDPDay = vdGioDT.KhachDPDay > 0 ? vdKm.KhachDPDay / vdGioDT.KhachDPDay : 0;

            vdVanToc.HangChinh = vdGioDT.HangChinh > 0 ? vdKm.HangChinh / vdGioDT.HangChinh : 0;
            vdVanToc.HangDon = vdGioDT.HangDon > 0 ? vdKm.HangDon / vdGioDT.HangDon : 0;
            vdVanToc.HangGhep = vdGioDT.HangGhep > 0 ? vdKm.HangGhep / vdGioDT.HangGhep : 0;
            vdVanToc.HangDay = vdGioDT.HangDay > 0 ? vdKm.HangDay / vdGioDT.HangDay : 0;

            vdVanToc.DaChinh = vdGioDT.DaChinh > 0 ? vdKm.DaChinh / vdGioDT.DaChinh : 0;
            vdVanToc.DaDon = vdGioDT.DaDon > 0 ? vdKm.DaDon / vdGioDT.DaDon : 0;
            vdVanToc.DaGhep = vdGioDT.DaGhep > 0 ? vdKm.DaGhep / vdGioDT.DaGhep : 0;
            vdVanToc.DaDay = vdGioDT.DaDay > 0 ? vdKm.DaDay / vdGioDT.DaDay : 0;

            vdVanToc.ThoiChinh = vdGioDT.ThoiChinh > 0 ? vdKm.ThoiChinh / vdGioDT.ThoiChinh : 0;
            vdVanToc.ThoiDon = vdGioDT.ThoiDon > 0 ? vdKm.ThoiDon / vdGioDT.ThoiDon : 0;
            vdVanToc.ThoiGhep = vdGioDT.ThoiGhep > 0 ? vdKm.ThoiGhep / vdGioDT.ThoiGhep : 0;
            vdVanToc.ThoiDay = vdGioDT.ThoiDay > 0 ? vdKm.ThoiDay / vdGioDT.ThoiDay : 0;

            vdVanToc.CongDung = vdGioDT.CongDung > 0 ? vdKm.CongDung / vdGioDT.CongDung : 0;
            vdVanToc.ChuyenDon = vdGioDT.ChuyenDon > 0 ? vdKm.ChuyenDon / vdGioDT.ChuyenDon : 0;
            vdVanToc.TongCong = vdGioDT.TongCong > 0 ? vdKm.TongCong / vdGioDT.TongCong : 0;
        }
        private static void KmTinhDoiDon(ref BCVanDungInfo vd)
        {
            vd.KhachTNChinh *= 10;
            vd.KhachTNDon *= 10;
            vd.KhachTNGhep *= 10;
            vd.KhachTNDay *= 10;

            vd.KhachDPChinh *= 10;
            vd.KhachDPDon *= 10;
            vd.KhachDPGhep *= 10;
            vd.KhachDPDay *= 10;

            vd.HangChinh *= 10;
            vd.HangDon *= 10;
            vd.HangGhep *= 10;
            vd.HangDay *= 10;

            vd.DaChinh *= 10;
            vd.DaDon *= 10;
            vd.DaGhep *= 10;
            vd.DaDay *= 10;

            vd.ThoiChinh *= 10;
            vd.ThoiDon *= 10;
            vd.ThoiGhep *= 10;
            vd.ThoiDay *= 10;

            vd.CongDung *= 10;
            vd.ChuyenDon *= 10;
            vd.TongCong *= 10;
        }
        private static void TongKM(BCVanDungInfo KmChay, BCVanDungInfo KMDoiDon, BCVanDungInfo KMDoiDung, ref BCVanDungInfo vd)
        {
            vd.KhachTNChinh = KmChay.KhachTNChinh + KMDoiDon.KhachTNChinh + KMDoiDung.KhachTNChinh;
            vd.KhachTNDon = KmChay.KhachTNDon + KMDoiDon.KhachTNDon + KMDoiDung.KhachTNDon;
            vd.KhachTNGhep = KmChay.KhachTNGhep + KMDoiDon.KhachTNGhep + KMDoiDung.KhachTNGhep;
            vd.KhachTNDay = KmChay.KhachTNDay + KMDoiDon.KhachTNDay + KMDoiDung.KhachTNDay;

            vd.KhachDPChinh = KmChay.KhachDPChinh + KMDoiDon.KhachDPChinh + KMDoiDung.KhachDPChinh;
            vd.KhachDPDon = KmChay.KhachDPDon + KMDoiDon.KhachDPDon + KMDoiDung.KhachDPDon;
            vd.KhachDPGhep = KmChay.KhachDPGhep + KMDoiDon.KhachDPGhep + KMDoiDung.KhachDPGhep;
            vd.KhachDPDay = KmChay.KhachDPDay + KMDoiDon.KhachDPDay + KMDoiDung.KhachDPDay;

            vd.HangChinh = KmChay.HangChinh + KMDoiDon.HangChinh + KMDoiDung.HangChinh;
            vd.HangDon = KmChay.HangDon + KMDoiDon.HangDon + KMDoiDung.HangDon;
            vd.HangGhep = KmChay.HangGhep + KMDoiDon.HangGhep + KMDoiDung.HangGhep;
            vd.HangDay = KmChay.HangDay + KMDoiDon.HangDay + KMDoiDung.HangDay;

            vd.DaChinh = KmChay.DaChinh + KMDoiDon.DaChinh + KMDoiDung.DaChinh;
            vd.DaDon = KmChay.DaDon + KMDoiDon.DaDon + KMDoiDung.DaDon;
            vd.DaGhep = KmChay.DaGhep + KMDoiDon.DaGhep + KMDoiDung.DaGhep;
            vd.DaDay = KmChay.DaDay + KMDoiDon.DaDay + KMDoiDung.DaDay;

            vd.ThoiChinh = KmChay.ThoiChinh + KMDoiDon.ThoiChinh + KMDoiDung.ThoiChinh;
            vd.ThoiDon = KmChay.ThoiDon + KMDoiDon.ThoiDon + KMDoiDung.ThoiDon;
            vd.ThoiGhep = KmChay.ThoiGhep + KMDoiDon.ThoiGhep + KMDoiDung.ThoiGhep;
            vd.ThoiDay = KmChay.ThoiDay + KMDoiDon.ThoiDay + KMDoiDung.ThoiDay;

            vd.CongDung = KmChay.CongDung + KMDoiDon.CongDung + KMDoiDung.CongDung;
            vd.ChuyenDon = KmChay.ChuyenDon + KMDoiDon.ChuyenDon + KMDoiDung.ChuyenDon;
            vd.TongCong = KmChay.TongCong + KMDoiDon.TongCong + KMDoiDung.TongCong;
        }
        public static void NapBCVanDung(int nguonDL, string maDV, int loaiBC, DateTime ngayBD, DateTime ngayKT, string loaiMay, string tuyen, ref int TongSoBG, ref List<BCVanDungInfo> list)
        {
            //int rowCount = 23;
            string data = "?MaDV=" + maDV;
            data += "&TuThang=" + ngayBD.Month;
            data += "&DenThang=" + ngayKT.Month;
            data += "&TuNam=" + ngayBD.Year;
            data += "&DenNam=" + ngayKT.Year;
            //Lấy hệ số quy đổi nhiên liêu
            var listHeSo = HttpHelper.GetList<HeSoQdnl>(Configuration.UrlCBApi + "api/HeSoQdnls/GetByTraTim" + data).ToList();
            //Lấy dữ liệu báo cáo
            List<BCVanDungInfo> listTH = new List<BCVanDungInfo>();
            List<ViewBcvanDung> dtTK = new List<ViewBcvanDung>();
            List<ViewBcvanDung> dtCB = new List<ViewBcvanDung>();
            List<ViewBcvanDung> dt = new List<ViewBcvanDung>();
            DateTime ngayCBCu = new DateTime(2022, 9, 30);
            if (ngayBD < ngayCBCu)
            {
                if (ngayKT > ngayCBCu)
                {
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayCBCu;
                    data += "&LoaiMayID=" + loaiMay;
                    data += "&TuyenID=" + tuyen;
                    dtTK = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlTkdm + "api/BaoCaos/GetBCVanDung" + data);
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayCBCu.AddDays(1);
                    data += "&ngayKT=" + ngayKT;
                    data += "&LoaiMayID=" + loaiMay;
                    data += "&TuyenID=" + tuyen;
                    if (nguonDL == 1)
                    {
                        dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCVanDung" + data);
                    }
                    else
                    {
                        dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaos/GetBCVanDung" + data);
                    }
                }
                else
                {
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayKT;
                    data += "&LoaiMayID=" + loaiMay;
                    data += "&TuyenID=" + tuyen;
                    dtTK = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlTkdm + "api/BaoCaos/GetBCVanDung" + data);
                }
            }
            else
            {
                data = "?MaDV=" + maDV;
                data += "&loaiBC=" + loaiBC;
                data += "&ngayBD=" + ngayBD;
                data += "&ngayKT=" + ngayKT;
                data += "&LoaiMayID=" + loaiMay;
                data += "&TuyenID=" + tuyen;
                if (nguonDL == 1)
                {
                    dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCVanDung" + data);
                }
                else
                {
                    dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaos/GetBCVanDung" + data);
                }
            }
            if (dtTK.Count > 0)
            {
                foreach (var x in dtTK)
                {
                    if (x.DvcbID == "YV")
                    {

                    }
                    if (x.DvcbID == "HN")
                    {
                        if (x.TinhChatId == 3 | x.TinhChatId == 4 || x.TinhChatId == 6)
                        {
                            x.Kmgh = x.Kmdw;
                            x.Kmdw = 0;
                        }
                    }
                    if (x.DvcbID == "VIN")
                    {
                        //x.Dgqd = 0;
                        //x.Dnxp += x.Dncc;
                        //x.Dncc = 0;
                    }
                    if (x.DvcbID == "DN")
                    {
                        if (x.TinhChatId == 2)
                        {
                            x.Kmdw = x.Kmch;
                            x.Kmch = 0;
                        }
                        else if (x.TinhChatId == 5)
                        {
                            x.Kmdy = x.Kmch;
                            x.Kmch = 0;
                        }
                        else if (x.TinhChatId == 3 | x.TinhChatId == 4 || x.TinhChatId == 6)
                        {
                            x.Kmgh = x.Kmch;
                            x.Kmch = 0;
                        }
                    }
                    if (x.DvcbID == "SG")
                    {

                    }
                }
            }
            dt = dtCB.Concat(dtTK).ToList();
            if (dt.Count > 0)
            {
                foreach (ViewBcvanDung vd in dt)
                {
                    HeSoQdnl heSo = listHeSo.Where(x => x.MaDv == vd.DvcbID && x.Thang == vd.ThangDt && x.Nam == vd.NamDt).FirstOrDefault();
                    vd.Sltt15 = heSo != null ? vd.Sltt * heSo.HesoLit : 0;
                }
                List<ViewBcvanDung> dtTH = (from x in dt
                                            group x by new { x.CongTacId, x.TinhChatId } into g
                                            select new ViewBcvanDung
                                            {
                                                CongTacId = g.Key.CongTacId,
                                                TinhChatId = g.Key.TinhChatId,
                                                GioDm = g.Sum(x => x.GioDm),
                                                GioLh = g.Sum(x => x.GioLh),
                                                GioDt = g.Sum(x => x.GioDt),
                                                Dgxp = g.Sum(x => x.Dgxp),
                                                Dgdd = g.Sum(x => x.Dgdd),
                                                Dgqd = g.Sum(x => x.Dgqd),
                                                Dgcc = g.Sum(x => x.Dgcc),
                                                Dgdm = g.Sum(x => x.Dgdm),
                                                Dgdn = g.Sum(x => x.Dgdn),
                                                Dgkm = g.Sum(x => x.Dgkm),
                                                Dgkn = g.Sum(x => x.Dgkn),
                                                Dnxp = g.Sum(x => x.Dnxp),
                                                Dndd = g.Sum(x => x.Dndd),
                                                Dncc = g.Sum(x => x.Dncc),
                                                Kmch = g.Sum(x => x.Kmch),
                                                Kmdw = g.Sum(x => x.Kmdw),
                                                Kmgh = g.Sum(x => x.Kmgh),
                                                Kmdy = g.Sum(x => x.Kmdy),
                                                Tkch = g.Sum(x => x.Tkch),
                                                Tkdw = g.Sum(x => x.Tkdw),
                                                Tkgh = g.Sum(x => x.Tkgh),
                                                Tkdy = g.Sum(x => x.Tkdy),
                                                Slrkm = g.Sum(x => x.Slrkm),
                                                Slrkn = g.Sum(x => x.Slrkn),
                                                Sltt = g.Sum(x => x.Sltt),
                                                Sltt15 = g.Sum(x => x.Sltt15),
                                                Sltc = g.Sum(x => x.Sltc)
                                            }).ToList();
                //var liCD = dtTH.Where(x => x.CongTacId == 8).ToList();
                list = BCVanDungList(dtTH);
            }
            //Duyệt lại bảng để tính và đinh dạng.
            if (list.Count > 0)
            {
                BCVanDungInfo vd = new BCVanDungInfo();
                vd = list[0]; ChangeMuniteToHour(ref vd);
                vd = list[1]; ChangeMuniteToHour(ref vd);
                vd = list[2]; ChangeMuniteToHour(ref vd);
                vd = list[3]; ChangeMuniteToHour(ref vd);
                vd = list[4]; ChangeMuniteToHour(ref vd);
                vd = list[5]; ChangeMuniteToHour(ref vd);
                vd = list[6]; ChangeMuniteToHour(ref vd);
                vd = list[7]; ChangeMuniteToHour(ref vd);
                vd = list[8]; ChangeMuniteToHour(ref vd);
                vd = list[9]; ChangeMuniteToHour(ref vd);
                vd = list[10]; ChangeMuniteToHour(ref vd);
                vd = list[13]; ChangeMuniteToHour(ref vd);
                vd = list[14]; ChangeMuniteToHour(ref vd);
                vd = list[19]; ChangeMuniteToHour(ref vd);
                vd = list[20]; ChangeMuniteToHour(ref vd);

                vd = list[12]; ChangeVanToc(list[11], list[2], ref vd);
                vd = list[19]; KmTinhDoiDon(ref vd);
                vd = list[21]; TongKM(list[11], list[19], list[20], ref vd);
            }
        }
        #endregion

        #region BC chỉ tiêu ktkt
        private static List<BCKTKTXNInfo> BCKTKTXNList()
        {
            List<BCKTKTXNInfo> list = new List<BCKTKTXNInfo>();
            try
            {
                //Tạo list báo cáo.
                BCKTKTXNInfo ct = new BCKTKTXNInfo(); ct.TenCT = "Năng xuất đầu máy ngày"; ct.MaCT = "701"; ct.DonVi = "TKm/ngày"; list.Add(ct);//0
                ct = new BCKTKTXNInfo(); ct.TenCT = "Tổng trọng bình quân đoàn tầu"; ct.MaCT = "702"; ct.DonVi = "Tấn"; list.Add(ct);//1
                ct = new BCKTKTXNInfo(); ct.TenCT = "Trọng tải bình quân đoàn tầu"; ct.MaCT = "703"; ct.DonVi = "Tấn"; list.Add(ct);//2
                ct = new BCKTKTXNInfo(); ct.TenCT = "Số xe bình quân đoàn tầu"; ct.MaCT = "704"; ct.DonVi = "Xe"; list.Add(ct);//3
                ct = new BCKTKTXNInfo(); ct.TenCT = "Đầu máy Km chạy chính"; ct.MaCT = "801"; ct.DonVi = "Km"; list.Add(ct);//4
                ct = new BCKTKTXNInfo(); ct.TenCT = "Đầu máy Km chạy phụ trợ"; ct.MaCT = "802"; ct.DonVi = "Km"; list.Add(ct);//5
                ct = new BCKTKTXNInfo(); ct.TenCT = "Km chạy bình quân đầu máy ngày"; ct.MaCT = "705"; ct.DonVi = "Km máy ngày"; list.Add(ct);//6
                ct = new BCKTKTXNInfo(); ct.TenCT = "Tốc độ lữ hành"; ct.MaCT = "706"; ct.DonVi = "Km/giờ"; list.Add(ct);//7
                ct = new BCKTKTXNInfo(); ct.TenCT = "Tốc độ kĩ thuật"; ct.MaCT = "707"; ct.DonVi = "Km/giờ"; list.Add(ct);//8
                ct = new BCKTKTXNInfo(); ct.TenCT = "Cự li quay toàn vòng"; ct.MaCT = "708"; ct.DonVi = "Km"; list.Add(ct);//9
                ct = new BCKTKTXNInfo(); ct.TenCT = "Thời gian quay toàn vòng"; ct.MaCT = "709"; ct.DonVi = "Giờ"; list.Add(ct);//10
                ct = new BCKTKTXNInfo(); ct.TenCT = "   +Chạy đơn thuần"; ct.MaCT = "710"; ct.DonVi = "Giờ"; list.Add(ct);//11
                ct = new BCKTKTXNInfo(); ct.TenCT = "   +Dừng, dồn dọc đường"; ct.MaCT = "711"; ct.DonVi = "Giờ"; list.Add(ct);//12
                ct = new BCKTKTXNInfo(); ct.TenCT = "   +Dừng đoạn quay máy"; ct.MaCT = "712"; ct.DonVi = "Giờ"; list.Add(ct);//13
                ct = new BCKTKTXNInfo(); ct.TenCT = "   +Dừng, dồn ga đoạn q.máy"; ct.MaCT = "713"; ct.DonVi = "Giờ"; list.Add(ct);//14
                ct = new BCKTKTXNInfo(); ct.TenCT = "   +Dừng đoạn mình"; ct.MaCT = "714"; ct.DonVi = "Giờ"; list.Add(ct);//15
                ct = new BCKTKTXNInfo(); ct.TenCT = "   +Dừng, dồn ga đoạn mình"; ct.MaCT = "715"; ct.DonVi = "Giờ"; list.Add(ct);//16
                ct = new BCKTKTXNInfo(); ct.TenCT = "Tỉ lệ Km phụ trợ/Tổng Km chạy"; ct.MaCT = "716"; ct.DonVi = "%"; list.Add(ct);//17
                ct = new BCKTKTXNInfo(); ct.TenCT = "Tỉ lệ Km đơn/Km chính"; ct.MaCT = "717"; ct.DonVi = "%"; list.Add(ct);//18
                ct = new BCKTKTXNInfo(); ct.TenCT = "Tỉ lệ Km phụ trợ/Km chính"; ct.MaCT = "718"; ct.DonVi = "%"; list.Add(ct);//19
                ct = new BCKTKTXNInfo(); ct.TenCT = "Số máy vận dụng ngày"; ct.MaCT = "719"; ct.DonVi = "Máy"; list.Add(ct);//20               
            }
            catch
            {
                list = null;
            }
            return list;
        }
        private static List<BCKTKTTHInfo> BCKTKTTHList()
        {
            List<BCKTKTTHInfo> list = new List<BCKTKTTHInfo>();
            try
            {
                //Tạo list báo cáo.
                BCKTKTTHInfo ct = new BCKTKTTHInfo(); ct.TenCT = "Năng xuất đầu máy ngày"; ct.MaCT = "701"; ct.DonVi = "TKm/ngày"; list.Add(ct);//0
                ct = new BCKTKTTHInfo(); ct.TenCT = "Tổng trọng bình quân đoàn tầu"; ct.MaCT = "702"; ct.DonVi = "Tấn"; list.Add(ct);//1
                ct = new BCKTKTTHInfo(); ct.TenCT = "Trọng tải bình quân đoàn tầu"; ct.MaCT = "703"; ct.DonVi = "Tấn"; list.Add(ct);//2
                ct = new BCKTKTTHInfo(); ct.TenCT = "Số xe bình quân đoàn tầu"; ct.MaCT = "704"; ct.DonVi = "Xe"; list.Add(ct);//3
                ct = new BCKTKTTHInfo(); ct.TenCT = "Đầu máy Km chạy chính"; ct.MaCT = "801"; ct.DonVi = "Km"; list.Add(ct);//4
                ct = new BCKTKTTHInfo(); ct.TenCT = "Đầu máy Km chạy phụ trợ"; ct.MaCT = "802"; ct.DonVi = "Km"; list.Add(ct);//5
                ct = new BCKTKTTHInfo(); ct.TenCT = "Km chạy bình quân đầu máy ngày"; ct.MaCT = "705"; ct.DonVi = "Km máy ngày"; list.Add(ct);//6
                ct = new BCKTKTTHInfo(); ct.TenCT = "Tốc độ lữ hành"; ct.MaCT = "706"; ct.DonVi = "Km/giờ"; list.Add(ct);//7
                ct = new BCKTKTTHInfo(); ct.TenCT = "Tốc độ kĩ thuật"; ct.MaCT = "707"; ct.DonVi = "Km/giờ"; list.Add(ct);//8
                ct = new BCKTKTTHInfo(); ct.TenCT = "Cự li quay toàn vòng"; ct.MaCT = "708"; ct.DonVi = "Km"; list.Add(ct);//9
                ct = new BCKTKTTHInfo(); ct.TenCT = "Thời gian quay toàn vòng"; ct.MaCT = "709"; ct.DonVi = "Giờ"; list.Add(ct);//10
                ct = new BCKTKTTHInfo(); ct.TenCT = "   +Chạy đơn thuần"; ct.MaCT = "710"; ct.DonVi = "Giờ"; list.Add(ct);//11
                ct = new BCKTKTTHInfo(); ct.TenCT = "   +Dừng, dồn dọc đường"; ct.MaCT = "711"; ct.DonVi = "Giờ"; list.Add(ct);//12
                ct = new BCKTKTTHInfo(); ct.TenCT = "   +Dừng đoạn quay máy"; ct.MaCT = "712"; ct.DonVi = "Giờ"; list.Add(ct);//13
                ct = new BCKTKTTHInfo(); ct.TenCT = "   +Dừng, dồn ga đoạn q.máy"; ct.MaCT = "713"; ct.DonVi = "Giờ"; list.Add(ct);//14
                ct = new BCKTKTTHInfo(); ct.TenCT = "   +Dừng đoạn mình"; ct.MaCT = "714"; ct.DonVi = "Giờ"; list.Add(ct);//15
                ct = new BCKTKTTHInfo(); ct.TenCT = "   +Dừng, dồn ga đoạn mình"; ct.MaCT = "715"; ct.DonVi = "Giờ"; list.Add(ct);//16
                ct = new BCKTKTTHInfo(); ct.TenCT = "Tỉ lệ Km phụ trợ/Tổng Km chạy"; ct.MaCT = "716"; ct.DonVi = "%"; list.Add(ct);//17
                ct = new BCKTKTTHInfo(); ct.TenCT = "Tỉ lệ Km đơn/Km chính"; ct.MaCT = "717"; ct.DonVi = "%"; list.Add(ct);//18
                ct = new BCKTKTTHInfo(); ct.TenCT = "Tỉ lệ Km phụ trợ/Km chính"; ct.MaCT = "718"; ct.DonVi = "%"; list.Add(ct);//19
                ct = new BCKTKTTHInfo(); ct.TenCT = "Số máy vận dụng ngày"; ct.MaCT = "719"; ct.DonVi = "Máy"; list.Add(ct);//20               
            }
            catch
            {
                list = null;
            }
            return list;
        }
        private static void NapListKTKTXN(short CT, decimal iResult, ref BCKTKTXNInfo ct)
        {
            //Khách
            if (CT == 1) ct.KVTN += iResult;//TN
            if (CT == 2) ct.KVDP += iResult;//DP
            if (CT == 3) ct.KVHH += iResult;//HH
            if (CT == 11) ct.KVTong += iResult;//KVTong            
            //Hàng
            if (CT == 4 || CT == 10) ct.HVHang += iResult;//hang
            if (CT == 5) ct.HVDa += iResult;//da
            if (CT == 6) ct.HVThoi += iResult;//thoi
            if (CT == 12) ct.HVTong += iResult;//HVTong            
            //Công dụng
            if (CT == 7) ct.CongDung += iResult;
            //Chuyên dồn
            if (CT == 8) ct.ChuyenDon += iResult;
            if (CT == 9) ct.KiemDon += iResult;
            //Tổng cộng
            if (CT == 13) ct.TongCong += iResult;
        }
        private static void NapListKTKTTH(string CT, decimal iResult, ref BCKTKTTHInfo ct)
        {
            //Khách
            if (CT == "KVYV1000") ct.KVYV1000 += iResult;
            if (CT == "KVYV1435") ct.KVYV1435 += iResult;
            if (CT == "KVHN") ct.KVHN += iResult;
            if (CT == "KVVI") ct.KVVI += iResult;
            if (CT == "KVDN") ct.KVDN += iResult;
            if (CT == "KVSG") ct.KVSG += iResult;
            if (CT == "KVTong") ct.KVTong += iResult;//KVTong            
            //Hàng
            if (CT == "HVYV1000") ct.HVYV1000 += iResult;
            if (CT == "HVYV1435") ct.HVYV1435 += iResult;
            if (CT == "HVHN") ct.HVHN += iResult;
            if (CT == "HVVI") ct.HVVI += iResult;
            if (CT == "HVDN") ct.HVDN += iResult;
            if (CT == "HVSG") ct.HVSG += iResult;
            if (CT == "HVTong") ct.HVTong += iResult;//HVTong
            //Khác
            if (CT == "CongDung") ct.CongDung += iResult;
            if (CT == "ChuyenDon") ct.ChuyenDon += iResult;
            if (CT == "KiemDon") ct.KiemDon += iResult;
            //Tổng cộng
            if (CT == "Tong") ct.TongCong += iResult;
        }
        public static void NapBCKTKTXN(int nguonDL, string maDV, int loaiBC, DateTime ngayBD, DateTime ngayKT, string loaiMay, string tuyen, ref int TongSoBG, ref List<BCKTKTXNInfo> list)
        {
            int ngayDM = int.Parse((ngayKT - ngayBD).TotalDays.ToString());
            //Lấy dữ liệu báo cáo           
            string data = string.Empty;
            List<ViewBcvanDung> dtTK = new List<ViewBcvanDung>();
            List<ViewBcvanDung> dtCB = new List<ViewBcvanDung>();
            List<ViewBcvanDung> dt = new List<ViewBcvanDung>();
            DateTime ngayCBCu = new DateTime(2022, 9, 30);
            if (ngayBD < ngayCBCu)
            {
                if (ngayKT > ngayCBCu)
                {
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayCBCu;
                    data += "&LoaiMayID=" + loaiMay;
                    data += "&TuyenID=" + tuyen;
                    dtTK = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlTkdm + "api/BaoCaos/GetBCVanDung" + data);
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayCBCu.AddDays(1);
                    data += "&ngayKT=" + ngayKT;
                    data += "&LoaiMayID=" + loaiMay;
                    data += "&TuyenID=" + tuyen;
                    if (nguonDL == 1)
                    {
                        dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCVanDung" + data);
                    }
                    else
                    {
                        dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaos/GetBCVanDung" + data);
                    }
                }
                else
                {
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayKT;
                    data += "&LoaiMayID=" + loaiMay;
                    data += "&TuyenID=" + tuyen;
                    dtTK = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlTkdm + "api/BaoCaos/GetBCVanDung" + data);
                }
            }
            else
            {
                data = "?MaDV=" + maDV;
                data += "&loaiBC=" + loaiBC;
                data += "&ngayBD=" + ngayBD;
                data += "&ngayKT=" + ngayKT;
                data += "&LoaiMayID=" + loaiMay;
                data += "&TuyenID=" + tuyen;
                if (nguonDL == 1)
                {
                    dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCVanDung" + data);
                }
                else
                {
                    dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaos/GetBCVanDung" + data);
                }
            }
            if (dtTK.Count > 0)
            {
                foreach (var x in dtTK)
                {
                    if (x.DvcbID == "DN")
                    {
                        if (x.TinhChatId == 2)
                        {
                            x.Kmdw = x.Kmch;
                            x.Kmch = 0;
                        }
                        else if (x.TinhChatId == 5)
                        {
                            x.Kmdy = x.Kmch;
                            x.Kmch = 0;
                        }
                        else if (x.TinhChatId == 3 | x.TinhChatId == 4 || x.TinhChatId == 6)
                        {
                            x.Kmgh = x.Kmch;
                            x.Kmch = 0;
                        }
                    }
                }
            }
            dt = dtCB.Concat(dtTK).ToList();
            if (dt.Count > 0)
            {
                List<ViewBcvanDung> dtTH = (from x in dt
                                            group x by new { x.CongTacId } into g
                                            select new ViewBcvanDung
                                            {
                                                CongTacId = g.Key.CongTacId,
                                                GioDm = g.Sum(x => x.GioDm),
                                                GioLh = g.Sum(x => x.GioLh),
                                                GioDt = g.Sum(x => x.GioDt),
                                                Dgxp = g.Sum(x => x.Dgxp),
                                                Dgdd = g.Sum(x => x.Dgdd),
                                                Dgqd = g.Sum(x => x.Dgqd),
                                                Dgcc = g.Sum(x => x.Dgcc),
                                                Dgdm = g.Sum(x => x.Dgdm),
                                                Dgdn = g.Sum(x => x.Dgdn),
                                                Dgkm = g.Sum(x => x.Dgkm),
                                                Dgkn = g.Sum(x => x.Dgkn),
                                                Dnxp = g.Sum(x => x.Dnxp),
                                                Dndd = g.Sum(x => x.Dndd),
                                                Dncc = g.Sum(x => x.Dncc),
                                                Kmch = g.Sum(x => x.Kmch),
                                                Kmdw = g.Sum(x => x.Kmdw),
                                                Kmgh = g.Sum(x => x.Kmgh),
                                                Kmdy = g.Sum(x => x.Kmdy),
                                                Tkch = g.Sum(x => x.Tkch),
                                                Tkdw = g.Sum(x => x.Tkdw),
                                                Tkgh = g.Sum(x => x.Tkgh),
                                                Tkdy = g.Sum(x => x.Tkdy),
                                                Slrkm = g.Sum(x => x.Slrkm),
                                                Slrkn = g.Sum(x => x.Slrkn),
                                                Sltt = g.Sum(x => x.Sltt),
                                                Sltt15 = g.Sum(x => x.Sltt15),
                                                Sltc = g.Sum(x => x.Sltc)
                                            }).ToList();

                var listTH = (from t in dtTH
                              group t by t.CongTacId into g
                              select new
                              {
                                  CTAC = (short)g.Key,
                                  GioDM = (decimal)g.Sum(f => f.GioDm),
                                  GioDMKD = (decimal)g.Sum(f => f.GioDm),
                                  GioLH = (decimal)g.Sum(f => f.GioLh),
                                  GioDT = (decimal)g.Sum(f => f.GioDt),
                                  GioDungDonDD = (decimal)g.Sum(f => f.Dgdd + f.Dndd),
                                  GioDungQD = (decimal)g.Sum(f => f.Dgqd),
                                  GioDungDonQD = (decimal)g.Sum(f => f.Dgqd + f.Dncc),
                                  GioDungDM = (decimal)g.Sum(f => f.Dgdm),
                                  GioDungDonDM = (decimal)g.Sum(f => f.Dgdm + f.Dnxp),
                                  DungTD = (decimal)g.Sum(f => f.Dgxp + f.Dgdd + f.Dgcc + f.Dgqd + f.Dgdn + f.Dgkn + f.Dgdm + f.Dgkm),
                                  DonTD = (decimal)g.Sum(f => f.Dnxp + f.Dndd + f.Dncc),
                                  SLRK = (decimal)g.Sum(f => f.Slrkm + f.Slrkn),
                                  KMDW = (decimal)g.Sum(f => f.Kmdw),
                                  KMCH = (decimal)g.Sum(f => f.Kmch),
                                  KMPT = (decimal)g.Sum(f => f.Kmdw + f.Kmgh + f.Kmdy),
                                  KM = (decimal)g.Sum(f => f.Kmch + f.Kmdw + f.Kmgh + f.Kmdy),
                                  TKCH = (decimal)g.Sum(f => f.Tkch),
                                  TanKM = (decimal)g.Sum(f => f.Tkch + f.Tkdw + f.Tkgh + f.Tkdy)
                              }).ToList();
                var listTHKV = (from t in listTH
                                where t.CTAC == 1 || t.CTAC == 2 || t.CTAC == 3
                                select new
                                {
                                    CTAC = (short)11,
                                    GioDM = (decimal)t.GioDM,
                                    GioDMKD = (decimal)t.GioDMKD,
                                    GioLH = (decimal)t.GioLH,
                                    GioDT = (decimal)t.GioDT,
                                    GioDungDonDD = (decimal)t.GioDungDonDD,
                                    GioDungQD = (decimal)t.GioDungQD,
                                    GioDungDonQD = (decimal)t.GioDungDonQD,
                                    GioDungDM = (decimal)t.GioDungDM,
                                    GioDungDonDM = (decimal)t.GioDungDonDM,
                                    DungTD = (decimal)t.DungTD,
                                    DonTD = (decimal)t.DonTD,
                                    SLRK = (decimal)t.SLRK,
                                    KMDW = (decimal)t.KMDW,
                                    KMCH = (decimal)t.KMCH,
                                    KMPT = (decimal)t.KMPT,
                                    KM = (decimal)t.KM,
                                    TKCH = (decimal)t.TKCH,
                                    TanKM = (decimal)t.TanKM
                                }).ToList();

                var listTHHV = (from t in listTH
                                where t.CTAC == 4 || t.CTAC == 5 || t.CTAC == 6 || t.CTAC == 10
                                select new
                                {
                                    CTAC = (short)12,
                                    GioDM = (decimal)t.GioDM,
                                    GioDMKD = (decimal)t.GioDMKD,
                                    GioLH = (decimal)t.GioLH,
                                    GioDT = (decimal)t.GioDT,
                                    GioDungDonDD = (decimal)t.GioDungDonDD,
                                    GioDungQD = (decimal)t.GioDungQD,
                                    GioDungDonQD = (decimal)t.GioDungDonQD,
                                    GioDungDM = (decimal)t.GioDungDM,
                                    GioDungDonDM = (decimal)t.GioDungDonDM,
                                    DungTD = (decimal)t.DungTD,
                                    DonTD = (decimal)t.DonTD,
                                    SLRK = (decimal)t.SLRK,
                                    KMDW = (decimal)t.KMDW,
                                    KMCH = (decimal)t.KMCH,
                                    KMPT = (decimal)t.KMPT,
                                    KM = (decimal)t.KM,
                                    TKCH = (decimal)t.TKCH,
                                    TanKM = (decimal)t.TanKM
                                }).ToList();

                var listTHTO = (from t in listTH
                                    //where t.CTAC != 7 && t.CTAC != 8 && t.CTAC != 9
                                select new
                                {
                                    CTAC = (short)13,
                                    GioDM = (decimal)t.GioDM,
                                    GioDMKD = t.CTAC == 8 || t.CTAC == 9 ? 0 : (decimal)t.GioDMKD,
                                    GioLH = (decimal)t.GioLH,
                                    GioDT = (decimal)t.GioDT,
                                    GioDungDonDD = (decimal)t.GioDungDonDD,
                                    GioDungQD = (decimal)t.GioDungQD,
                                    GioDungDonQD = (decimal)t.GioDungDonQD,
                                    GioDungDM = (decimal)t.GioDungDM,
                                    GioDungDonDM = (decimal)t.GioDungDonDM,
                                    DungTD = (decimal)t.DungTD,
                                    DonTD = (decimal)t.DonTD,
                                    SLRK = (decimal)t.SLRK,
                                    KMDW = (decimal)t.KMDW,
                                    KMCH = (decimal)t.KMCH,
                                    KMPT = (decimal)t.KMPT,
                                    KM = (decimal)t.KM,
                                    TKCH = (decimal)t.TKCH,
                                    TanKM = (decimal)t.TanKM
                                }).ToList();

                var listG = listTH;
                foreach (var vd in listTHKV)
                {
                    listG.Add(vd);
                }
                foreach (var vd in listTHHV)
                {
                    listG.Add(vd);
                }
                foreach (var vd in listTHTO)
                {
                    listG.Add(vd);
                }
                var listGROUP = (from t in listG
                                 group t by t.CTAC into g
                                 select new
                                 {
                                     CTAC = g.Key,
                                     GioDM = g.Sum(f => f.GioDM),
                                     GioDMKD = g.Sum(f => f.GioDMKD),
                                     GioLH = g.Sum(f => f.GioLH),
                                     GioDT = g.Sum(f => f.GioDT),
                                     GioDungDonDD = g.Sum(f => f.GioDungDonDD),
                                     GioDungQD = g.Sum(f => f.GioDungQD),
                                     GioDungDonQD = g.Sum(f => f.GioDungDonQD),
                                     GioDungDM = g.Sum(f => f.GioDungDM),
                                     GioDungDonDM = g.Sum(f => f.GioDungDonDM),
                                     DungTD = g.Sum(f => f.DungTD),
                                     DonTD = g.Sum(f => f.DonTD),
                                     SLRK = g.Sum(f => f.SLRK),
                                     KMDW = g.Sum(f => f.KMDW),
                                     KMCH = g.Sum(f => f.KMCH),
                                     KMPT = g.Sum(f => f.KMPT),
                                     KM = g.Sum(f => f.KM),
                                     TKCH = g.Sum(f => f.TKCH),
                                     TanKM = g.Sum(f => f.TanKM)
                                 }).ToList();

                if (listG != null)
                {
                    list = BCKTKTXNList();
                    BCKTKTXNInfo ct = new BCKTKTXNInfo();
                    foreach (var aRow in listGROUP)
                    {
                        short maCT = (short)aRow.CTAC;
                        ct = list[0]; NapListKTKTXN(maCT, aRow.GioDMKD == 0 ? 0 : (aRow.TanKM / aRow.GioDMKD) * 60 * 24, ref ct);//701=416/401
                        ct = list[1]; NapListKTKTXN(maCT, aRow.KMCH == 0 ? 0 : aRow.TanKM / aRow.KMCH, ref ct);//702=416/kmchinh
                        ct = list[2]; NapListKTKTXN(maCT, aRow.KMCH == 0 ? 0 : aRow.TKCH / aRow.KMCH, ref ct);
                        ct = list[3]; NapListKTKTXN(maCT, 0, ref ct);
                        ct = list[4]; NapListKTKTXN(maCT, aRow.KMCH, ref ct);
                        ct = list[5]; NapListKTKTXN(maCT, aRow.KMPT, ref ct);
                        ct = list[6]; NapListKTKTXN(maCT, aRow.GioDMKD == 0 ? 0 : (aRow.KM / aRow.GioDMKD) * 24 * 60, ref ct);
                        ct = list[7]; NapListKTKTXN(maCT, aRow.GioLH == 0 ? 0 : (aRow.KM / aRow.GioLH) * 60, ref ct);
                        ct = list[8]; NapListKTKTXN(maCT, aRow.GioDT == 0 ? 0 : (aRow.KM / aRow.GioDT) * 60, ref ct);
                        ct = list[9]; NapListKTKTXN(maCT, aRow.SLRK == 0 ? 0 : aRow.KM / aRow.SLRK, ref ct);
                        ct = list[10]; NapListKTKTXN(maCT, aRow.SLRK == 0 ? 0 : aRow.GioDM / (aRow.SLRK * 60), ref ct);
                        ct = list[11]; NapListKTKTXN(maCT, aRow.SLRK == 0 ? 0 : aRow.GioDT / (aRow.SLRK * 60), ref ct);
                        ct = list[12]; NapListKTKTXN(maCT, aRow.SLRK == 0 ? 0 : aRow.GioDungDonDD / (aRow.SLRK * 60), ref ct);//(406+407)/417
                        ct = list[13]; NapListKTKTXN(maCT, aRow.SLRK == 0 ? 0 : aRow.GioDungQD / (aRow.SLRK * 60), ref ct);//410/417
                        ct = list[14]; NapListKTKTXN(maCT, aRow.SLRK == 0 ? 0 : aRow.GioDungDonQD / (aRow.SLRK * 60), ref ct);//(405+409)417
                        ct = list[15]; NapListKTKTXN(maCT, aRow.SLRK == 0 ? 0 : aRow.GioDungDM / (aRow.SLRK * 60), ref ct);//411/417
                        ct = list[16]; NapListKTKTXN(maCT, aRow.SLRK == 0 ? 0 : aRow.GioDungDonDM / (aRow.SLRK * 60), ref ct);//404/417
                        ct = list[17]; NapListKTKTXN(maCT, aRow.KM == 0 ? 0 : (aRow.KMPT / aRow.KM) * 100, ref ct);
                        ct = list[18]; NapListKTKTXN(maCT, aRow.KMCH == 0 ? 0 : (aRow.KMDW / aRow.KMCH) * 100, ref ct);
                        ct = list[19]; NapListKTKTXN(maCT, aRow.KMCH == 0 ? 0 : (aRow.KMPT / aRow.KMCH) * 100, ref ct);
                        ct = list[20]; NapListKTKTXN(maCT, aRow.GioDM / (ngayDM * 60 * 24), ref ct);
                    }
                }
            }
        }
        public static void NapBCKTKTTH(int nguonDL, string maDV, int loaiBC, DateTime ngayBD, DateTime ngayKT, string loaiMay, string tuyen, ref int TongSoBG, ref List<BCKTKTTHInfo> list)
        {
            int ngayDM = int.Parse((ngayKT - ngayBD).TotalDays.ToString());
            //Lấy dữ liệu báo cáo           
            string data = string.Empty;
            List<ViewBcvanDung> dtTK = new List<ViewBcvanDung>();
            List<ViewBcvanDung> dtCB = new List<ViewBcvanDung>();
            List<ViewBcvanDung> dt = new List<ViewBcvanDung>();
            DateTime ngayCBCu = new DateTime(2022, 9, 30);
            if (ngayBD < ngayCBCu)
            {
                if (ngayKT > ngayCBCu)
                {
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayCBCu;
                    data += "&LoaiMayID=" + loaiMay;
                    data += "&TuyenID=" + tuyen;
                    dtTK = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlTkdm + "api/BaoCaos/GetBCVanDung" + data);
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayCBCu.AddDays(1);
                    data += "&ngayKT=" + ngayKT;
                    data += "&LoaiMayID=" + loaiMay;
                    data += "&TuyenID=" + tuyen;
                    if (nguonDL == 1)
                    {
                        dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCVanDung" + data);
                    }
                    else
                    {
                        dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaos/GetBCVanDung" + data);
                    }
                }
                else
                {
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayKT;
                    data += "&LoaiMayID=" + loaiMay;
                    data += "&TuyenID=" + tuyen;
                    dtTK = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlTkdm + "api/BaoCaos/GetBCVanDung" + data);
                }
            }
            else
            {
                data = "?MaDV=" + maDV;
                data += "&loaiBC=" + loaiBC;
                data += "&ngayBD=" + ngayBD;
                data += "&ngayKT=" + ngayKT;
                data += "&LoaiMayID=" + loaiMay;
                data += "&TuyenID=" + tuyen;
                if (nguonDL == 1)
                {
                    dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCVanDung" + data);
                }
                else
                {
                    dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaos/GetBCVanDung" + data);
                }
            }
            if (dtTK.Count > 0)
            {
                foreach (var x in dtTK)
                {
                    if (x.DvcbID == "DN")
                    {
                        if (x.TinhChatId == 2)
                        {
                            x.Kmdw = x.Kmch;
                            x.Kmch = 0;
                        }
                        else if (x.TinhChatId == 5)
                        {
                            x.Kmdy = x.Kmch;
                            x.Kmch = 0;
                        }
                        else if (x.TinhChatId == 3 | x.TinhChatId == 4 || x.TinhChatId == 6)
                        {
                            x.Kmgh = x.Kmch;
                            x.Kmch = 0;
                        }
                    }
                }
            }
            dt = dtCB.Concat(dtTK).ToList();
            if (dt.Count > 0)
            {
                List<ViewBcvanDung> dtTH = (from x in dt
                                            group x by new { x.DvcbID, x.LoaiMayId, x.CongTacId } into g
                                            select new ViewBcvanDung
                                            {
                                                DvcbID = g.Key.DvcbID,
                                                LoaiMayId = g.Key.LoaiMayId,
                                                CongTacId = g.Key.CongTacId,
                                                GioDm = g.Sum(x => x.GioDm),
                                                GioLh = g.Sum(x => x.GioLh),
                                                GioDt = g.Sum(x => x.GioDt),
                                                Dgxp = g.Sum(x => x.Dgxp),
                                                Dgdd = g.Sum(x => x.Dgdd),
                                                Dgqd = g.Sum(x => x.Dgqd),
                                                Dgcc = g.Sum(x => x.Dgcc),
                                                Dgdm = g.Sum(x => x.Dgdm),
                                                Dgdn = g.Sum(x => x.Dgdn),
                                                Dgkm = g.Sum(x => x.Dgkm),
                                                Dgkn = g.Sum(x => x.Dgkn),
                                                Dnxp = g.Sum(x => x.Dnxp),
                                                Dndd = g.Sum(x => x.Dndd),
                                                Dncc = g.Sum(x => x.Dncc),
                                                Kmch = g.Sum(x => x.Kmch),
                                                Kmdw = g.Sum(x => x.Kmdw),
                                                Kmgh = g.Sum(x => x.Kmgh),
                                                Kmdy = g.Sum(x => x.Kmdy),
                                                Tkch = g.Sum(x => x.Tkch),
                                                Tkdw = g.Sum(x => x.Tkdw),
                                                Tkgh = g.Sum(x => x.Tkgh),
                                                Tkdy = g.Sum(x => x.Tkdy),
                                                Slrkm = g.Sum(x => x.Slrkm),
                                                Slrkn = g.Sum(x => x.Slrkn),
                                                Sltt = g.Sum(x => x.Sltt),
                                                Sltt15 = g.Sum(x => x.Sltt15),
                                                Sltc = g.Sum(x => x.Sltc)
                                            }).ToList();


                foreach (var ct1 in dtTH)
                {
                    if (ct1.CongTacId == 1 || ct1.CongTacId == 2 || ct1.CongTacId == 3)
                    {
                        if (ct1.DvcbID == "YV")
                        {
                            if (ct1.LoaiMayId == "D14Er" || ct1.LoaiMayId == "D19Er") ct1.TuyenId = "KVYV1435";
                            else ct1.TuyenId = "KVYV1000";
                        }
                        else if (ct1.DvcbID == "HN") ct1.TuyenId = "KVHN";
                        else if (ct1.DvcbID == "VIN") ct1.TuyenId = "KVVI";
                        else if (ct1.DvcbID == "DN") ct1.TuyenId = "KVDN";
                        else if (ct1.DvcbID == "SG") ct1.TuyenId = "KVSG";
                    }
                    else if (ct1.CongTacId == 7) ct1.TuyenId = "CongDung";
                    else if (ct1.CongTacId == 8) ct1.TuyenId = "ChuyenDon";
                    else if (ct1.CongTacId == 9) ct1.TuyenId = "KiemDon";
                    else
                    {
                        if (ct1.DvcbID == "YV")
                        {
                            if (ct1.LoaiMayId == "D14Er" || ct1.LoaiMayId == "D19Er") ct1.TuyenId = "HVYV1435";
                            else ct1.TuyenId = "HVYV1000";
                        }
                        else if (ct1.DvcbID == "HN") ct1.TuyenId = "HVHN";
                        else if (ct1.DvcbID == "VIN") ct1.TuyenId = "HVVI";
                        else if (ct1.DvcbID == "DN") ct1.TuyenId = "HVDN";
                        else if (ct1.DvcbID == "SG") ct1.TuyenId = "HVSG";
                    }
                }

                var listTH = (from t in dtTH
                              group t by t.TuyenId into g
                              select new
                              {
                                  CTAC = g.Key,
                                  GioDM = (decimal)g.Sum(f => f.GioDm),
                                  GioDMKD = (decimal)g.Sum(f => f.GioDm),
                                  GioLH = (decimal)g.Sum(f => f.GioLh),
                                  GioDT = (decimal)g.Sum(f => f.GioDt),
                                  GioDungDonDD = (decimal)g.Sum(f => f.Dgdd + f.Dndd),
                                  GioDungQD = (decimal)g.Sum(f => f.Dgqd),
                                  GioDungDonQD = (decimal)g.Sum(f => f.Dgqd + f.Dncc),
                                  GioDungDM = (decimal)g.Sum(f => f.Dgdm),
                                  GioDungDonDM = (decimal)g.Sum(f => f.Dgdm + f.Dnxp),
                                  DungTD = (decimal)g.Sum(f => f.Dgxp + f.Dgdd + f.Dgcc + f.Dgqd + f.Dgdn + f.Dgkn + f.Dgdm + f.Dgkm),
                                  DonTD = (decimal)g.Sum(f => f.Dnxp + f.Dndd + f.Dncc),
                                  SLRK = (decimal)g.Sum(f => f.Slrkm + f.Slrkn),
                                  KMDW = (decimal)g.Sum(f => f.Kmdw),
                                  KMCH = (decimal)g.Sum(f => f.Kmch),
                                  KMPT = (decimal)g.Sum(f => f.Kmdw + f.Kmgh + f.Kmdy),
                                  KM = (decimal)g.Sum(f => f.Kmch + f.Kmdw + f.Kmgh + f.Kmdy),
                                  TKCH = (decimal)g.Sum(f => f.Tkch),
                                  TanKM = (decimal)g.Sum(f => f.Tkch + f.Tkdw + f.Tkgh + f.Tkdy)
                              }).ToList();

                var listTHKV = (from t in listTH
                                where t.CTAC == "KVYV1000" || t.CTAC == "KVYV1435" || t.CTAC == "KVHN" || t.CTAC == "KVVI" || t.CTAC == "KVDN" || t.CTAC == "KVSG"
                                select new
                                {
                                    CTAC = "KVTong",
                                    GioDM = (decimal)t.GioDM,
                                    GioDMKD = (decimal)t.GioDMKD,
                                    GioLH = (decimal)t.GioLH,
                                    GioDT = (decimal)t.GioDT,
                                    GioDungDonDD = (decimal)t.GioDungDonDD,
                                    GioDungQD = (decimal)t.GioDungQD,
                                    GioDungDonQD = (decimal)t.GioDungDonQD,
                                    GioDungDM = (decimal)t.GioDungDM,
                                    GioDungDonDM = (decimal)t.GioDungDonDM,
                                    DungTD = (decimal)t.DungTD,
                                    DonTD = (decimal)t.DonTD,
                                    SLRK = (decimal)t.SLRK,
                                    KMDW = (decimal)t.KMDW,
                                    KMCH = (decimal)t.KMCH,
                                    KMPT = (decimal)t.KMPT,
                                    KM = (decimal)t.KM,
                                    TKCH = (decimal)t.TKCH,
                                    TanKM = (decimal)t.TanKM
                                }).ToList();

                var listTHHV = (from t in listTH
                                where t.CTAC == "HVYV1000" || t.CTAC == "HVYV1435" || t.CTAC == "HVHN" || t.CTAC == "HVVI" || t.CTAC == "HVDN" || t.CTAC == "HVSG"
                                select new
                                {
                                    CTAC = "HVTong",
                                    GioDM = (decimal)t.GioDM,
                                    GioDMKD = (decimal)t.GioDMKD,
                                    GioLH = (decimal)t.GioLH,
                                    GioDT = (decimal)t.GioDT,
                                    GioDungDonDD = (decimal)t.GioDungDonDD,
                                    GioDungQD = (decimal)t.GioDungQD,
                                    GioDungDonQD = (decimal)t.GioDungDonQD,
                                    GioDungDM = (decimal)t.GioDungDM,
                                    GioDungDonDM = (decimal)t.GioDungDonDM,
                                    DungTD = (decimal)t.DungTD,
                                    DonTD = (decimal)t.DonTD,
                                    SLRK = (decimal)t.SLRK,
                                    KMDW = (decimal)t.KMDW,
                                    KMCH = (decimal)t.KMCH,
                                    KMPT = (decimal)t.KMPT,
                                    KM = (decimal)t.KM,
                                    TKCH = (decimal)t.TKCH,
                                    TanKM = (decimal)t.TanKM
                                }).ToList();

                var listTHTO = (from t in listTH
                                select new
                                {
                                    CTAC = "Tong",
                                    GioDM = (decimal)t.GioDM,
                                    GioDMKD = t.CTAC == "ChuyenDon" || t.CTAC == "KiemDon" ? 0 : (decimal)t.GioDMKD,
                                    GioLH = (decimal)t.GioLH,
                                    GioDT = (decimal)t.GioDT,
                                    GioDungDonDD = (decimal)t.GioDungDonDD,
                                    GioDungQD = (decimal)t.GioDungQD,
                                    GioDungDonQD = (decimal)t.GioDungDonQD,
                                    GioDungDM = (decimal)t.GioDungDM,
                                    GioDungDonDM = (decimal)t.GioDungDonDM,
                                    DungTD = (decimal)t.DungTD,
                                    DonTD = (decimal)t.DonTD,
                                    SLRK = (decimal)t.SLRK,
                                    KMDW = (decimal)t.KMDW,
                                    KMCH = (decimal)t.KMCH,
                                    KMPT = (decimal)t.KMPT,
                                    KM = (decimal)t.KM,
                                    TKCH = (decimal)t.TKCH,
                                    TanKM = (decimal)t.TanKM
                                }).ToList();

                var listG = listTH;
                foreach (var vd in listTHKV)
                {
                    listG.Add(vd);
                }
                foreach (var vd in listTHHV)
                {
                    listG.Add(vd);
                }
                foreach (var vd in listTHTO)
                {
                    listG.Add(vd);
                }
                var listGROUP = (from t in listG
                                 group t by t.CTAC into g
                                 select new
                                 {
                                     CTAC = g.Key,
                                     GioDM = g.Sum(f => f.GioDM),
                                     GioDMKD = g.Sum(f => f.GioDMKD),
                                     GioLH = g.Sum(f => f.GioLH),
                                     GioDT = g.Sum(f => f.GioDT),
                                     GioDungDonDD = g.Sum(f => f.GioDungDonDD),
                                     GioDungQD = g.Sum(f => f.GioDungQD),
                                     GioDungDonQD = g.Sum(f => f.GioDungDonQD),
                                     GioDungDM = g.Sum(f => f.GioDungDM),
                                     GioDungDonDM = g.Sum(f => f.GioDungDonDM),
                                     DungTD = g.Sum(f => f.DungTD),
                                     DonTD = g.Sum(f => f.DonTD),
                                     SLRK = g.Sum(f => f.SLRK),
                                     KMDW = g.Sum(f => f.KMDW),
                                     KMCH = g.Sum(f => f.KMCH),
                                     KMPT = g.Sum(f => f.KMPT),
                                     KM = g.Sum(f => f.KM),
                                     TKCH = g.Sum(f => f.TKCH),
                                     TanKM = g.Sum(f => f.TanKM)
                                 }).ToList();

                if (listGROUP != null)
                {
                    list = BCKTKTTHList();
                    BCKTKTTHInfo ct = new BCKTKTTHInfo();
                    foreach (var aRow in listGROUP)
                    {
                        string maCT = aRow.CTAC;
                        ct = list[0]; NapListKTKTTH(maCT, aRow.GioDMKD == 0 ? 0 : (aRow.TanKM / aRow.GioDMKD) * 60 * 24, ref ct);
                        ct = list[1]; NapListKTKTTH(maCT, aRow.KMCH == 0 ? 0 : aRow.TanKM / aRow.KMCH, ref ct);
                        ct = list[2]; NapListKTKTTH(maCT, aRow.KMCH == 0 ? 0 : aRow.TKCH / aRow.KMCH, ref ct);
                        ct = list[3]; NapListKTKTTH(maCT, 0, ref ct);
                        ct = list[4]; NapListKTKTTH(maCT, aRow.KMCH, ref ct);
                        ct = list[5]; NapListKTKTTH(maCT, aRow.KMPT, ref ct);
                        ct = list[6]; NapListKTKTTH(maCT, aRow.GioDMKD == 0 ? 0 : (aRow.KM / aRow.GioDMKD) * 60 * 24, ref ct);
                        ct = list[7]; NapListKTKTTH(maCT, aRow.GioLH == 0 ? 0 : (aRow.KM / aRow.GioLH) * 60, ref ct);
                        ct = list[8]; NapListKTKTTH(maCT, aRow.GioDT == 0 ? 0 : (aRow.KM / aRow.GioDT) * 60, ref ct);
                        ct = list[9]; NapListKTKTTH(maCT, aRow.SLRK == 0 ? 0 : aRow.KM / aRow.SLRK, ref ct);
                        ct = list[10]; NapListKTKTTH(maCT, aRow.SLRK == 0 ? 0 : aRow.GioDM / (aRow.SLRK * 60), ref ct);
                        ct = list[11]; NapListKTKTTH(maCT, aRow.SLRK == 0 ? 0 : aRow.GioDT / (aRow.SLRK * 60), ref ct);
                        ct = list[12]; NapListKTKTTH(maCT, aRow.SLRK == 0 ? 0 : aRow.GioDungDonDD / (aRow.SLRK * 60), ref ct);
                        ct = list[13]; NapListKTKTTH(maCT, aRow.SLRK == 0 ? 0 : aRow.GioDungQD / (aRow.SLRK * 60), ref ct);
                        ct = list[14]; NapListKTKTTH(maCT, aRow.SLRK == 0 ? 0 : aRow.GioDungDonQD / (aRow.SLRK * 60), ref ct);
                        ct = list[15]; NapListKTKTTH(maCT, aRow.SLRK == 0 ? 0 : aRow.GioDungDM / (aRow.SLRK * 60), ref ct);
                        ct = list[16]; NapListKTKTTH(maCT, aRow.SLRK == 0 ? 0 : aRow.GioDungDonDM / (aRow.SLRK * 60), ref ct);
                        ct = list[17]; NapListKTKTTH(maCT, aRow.KM == 0 ? 0 : (aRow.KMPT / aRow.KM) * 100, ref ct);
                        ct = list[18]; NapListKTKTTH(maCT, aRow.KMCH == 0 ? 0 : (aRow.KMDW / aRow.KMCH) * 100, ref ct);
                        ct = list[19]; NapListKTKTTH(maCT, aRow.KMCH == 0 ? 0 : (aRow.KMPT / aRow.KMCH) * 100, ref ct);
                        ct = list[20]; NapListKTKTTH(maCT, aRow.GioDM / (ngayDM * 60 * 24), ref ct);
                    }
                }
            }
        }
        #endregion

        #region BC giờ dồn  
        public static void NapBCGioDon(int nguonDL, string maDV, int loaiDon, int loaiBC, DateTime ngayBD, DateTime ngayKT, ref int TongSoBG, ref List<BCGioDonInfo> list)
        {
            string data = string.Empty;
            List<ViewBcGioDon> dtTK = new List<ViewBcGioDon>();
            List<ViewBcGioDon> dtCB = new List<ViewBcGioDon>();
            List<ViewBcGioDon> dt = new List<ViewBcGioDon>();
            DateTime ngayCBCu = new DateTime(2022, 9, 30);
            if (ngayBD < ngayCBCu)
            {
                if (ngayKT > ngayCBCu)
                {
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayCBCu;
                    dtTK = HttpHelper.GetList<ViewBcGioDon>(Configuration.UrlTkdm + "api/BaoCaos/GetBCGioDon" + data);
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayCBCu.AddDays(1);
                    data += "&ngayKT=" + ngayKT;
                    if (nguonDL == 1)
                    {
                        dtCB = HttpHelper.GetList<ViewBcGioDon>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCGioDon" + data);
                    }
                    else
                    {
                        dtCB = HttpHelper.GetList<ViewBcGioDon>(Configuration.UrlCBApi + "api/BaoCaos/GetBCGioDon" + data);
                    }
                }
                else
                {
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayKT;
                    dtTK = HttpHelper.GetList<ViewBcGioDon>(Configuration.UrlTkdm + "api/BaoCaos/GetBCGioDon" + data);
                }
            }
            else
            {
                data = "?MaDV=" + maDV;
                data += "&loaiBC=" + loaiBC;
                data += "&ngayBD=" + ngayBD;
                data += "&ngayKT=" + ngayKT;
                if (nguonDL == 1)
                {
                    dtCB = HttpHelper.GetList<ViewBcGioDon>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCGioDon" + data);
                }
                else
                {
                    dtCB = HttpHelper.GetList<ViewBcGioDon>(Configuration.UrlCBApi + "api/BaoCaos/GetBCGioDon" + data);
                }
            }
            dt = dtCB.Concat(dtTK).ToList();
            if (dt.Count > 0)
            {
                if (loaiDon == 1)
                    dt = dt.Where(x => x.CongTacID == 8 || x.CongTacID == 998).ToList();
                else if (loaiDon == 2)
                    dt = dt.Where(x => x.CongTacID != 8 && x.CongTacID != 998).ToList();
                dt = dt.Where(x => x.GioDon > 0).ToList();
                TongSoBG += dt.Count;
                List<BCGioDonInfo> listGR = new List<BCGioDonInfo>();
                foreach (var ct in dt)
                {
                    BCGioDonInfo vd = new BCGioDonInfo();
                    vd.SoTT = -1;
                    if (ct.DvcbID == "YV")
                        vd.TenXN = "I.Cộng Yên Viên";
                    if (ct.DvcbID == "HN")
                        vd.TenXN = "II.Cộng Hà Nội";
                    if (ct.DvcbID == "VIN")
                        vd.TenXN = "III.Cộng Vinh";
                    if (ct.DvcbID == "DN")
                        vd.TenXN = "IV.Cộng Đà Nẵng";
                    if (ct.DvcbID == "SG")
                        vd.TenXN = "V.Cộng Sài Gòn";
                    vd.TenGa = ct.GaXPName;
                    if (ct.LoaiMayID == "D4H")
                        vd.D4H = (decimal)ct.GioDon / 60;
                    else if (ct.LoaiMayID == "D4Hr")
                        vd.D4Hr = (decimal)ct.GioDon / 60;
                    else if (ct.LoaiMayID == "D5H")
                        vd.D5H = (decimal)ct.GioDon / 60;
                    else if (ct.LoaiMayID == "D9E")
                        vd.D9E = (decimal)ct.GioDon / 60;
                    else if (ct.LoaiMayID == "D10H")
                        vd.D10H = (decimal)ct.GioDon / 60;
                    else if (ct.LoaiMayID == "D10H_CAT")
                        vd.D10H_CAT = (decimal)ct.GioDon / 60;
                    else if (ct.LoaiMayID == "D11H")
                        vd.D11H = (decimal)ct.GioDon / 60;
                    else if (ct.LoaiMayID == "D12E")
                        vd.D12E = (decimal)ct.GioDon / 60;
                    else if (ct.LoaiMayID == "D13E")
                        vd.D13E = (decimal)ct.GioDon / 60;
                    else if (ct.LoaiMayID == "D14Er")
                        vd.D14E = (decimal)ct.GioDon / 60;
                    else if (ct.LoaiMayID == "D18E")
                        vd.D18E = (decimal)ct.GioDon / 60;
                    else if (ct.LoaiMayID == "D19E")
                        vd.D19E = (decimal)ct.GioDon / 60;
                    else if (ct.LoaiMayID == "D19Er")
                        vd.D19Er = (decimal)ct.GioDon / 60;
                    else if (ct.LoaiMayID == "D20E")
                        vd.D20E = (decimal)ct.GioDon / 60;
                    vd.Tong = (decimal)ct.GioDon / 60;
                    listGR.Add(vd);
                }
                // ra ngoai vong for thi goup lại
                list = (from ct in listGR
                        group ct by new { ct.TenXN, ct.TenGa } into g
                        select new BCGioDonInfo
                        {
                            TenXN = g.Key.TenXN,
                            TenGa = g.Key.TenGa,
                            D4H = g.Sum(x => x.D4H),
                            D4Hr = g.Sum(x => x.D4Hr),
                            D5H = g.Sum(x => x.D5H),
                            D9E = g.Sum(x => x.D9E),
                            D10H = g.Sum(x => x.D10H),
                            D10H_CAT = g.Sum(x => x.D10H_CAT),
                            D11H = g.Sum(x => x.D11H),
                            D12E = g.Sum(x => x.D12E),
                            D13E = g.Sum(x => x.D13E),
                            D14E = g.Sum(x => x.D14E),
                            D18E = g.Sum(x => x.D13E),
                            D19E = g.Sum(x => x.D19E),
                            D19Er = g.Sum(x => x.D19Er),
                            D20E = g.Sum(x => x.D20E),
                            Tong = g.Sum(x => x.Tong)
                        }).OrderBy(f => f.TenGa).OrderBy(f => f.TenXN).ToList();
                short soTT = 0;
                string tenXN = string.Empty;
                foreach (BCGioDonInfo vd in list)
                {
                    if (tenXN != vd.TenXN)
                        soTT = 1;
                    else
                        soTT += 1;
                    vd.SoTT = soTT;
                    tenXN = vd.TenXN;
                }
            }
        }
        public static void NapBCCTGioDon(int nguonDL, string maDV, string donviKT, int loaiBC, DateTime ngayBD, DateTime ngayKT, List<DonViKT> DonviKTList, ref int TongSoBG, ref List<BCCTGioDonInfo> list)
        {
            string data = "?MaDV=" + maDV;
            data += "&loaiBC=" + loaiBC;
            data += "&ngayBD=" + ngayBD;
            data += "&ngayKT=" + ngayKT;
            List<ViewBcGioDonCT> dt = new List<ViewBcGioDonCT>();
            if (nguonDL == 1)
            {
                dt = HttpHelper.GetList<ViewBcGioDonCT>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCGioDonCT" + data);
            }
            else
            {
                dt = HttpHelper.GetList<ViewBcGioDonCT>(Configuration.UrlCBApi + "api/BaoCaos/GetBCGioDonCT" + data);
            }
            if (dt.Count > 0)
            {
                dt = dt.OrderBy(x => x.GaName).ThenBy(x => x.NhanMay).ToList();
                short soTT = 0;
                string tenGa = string.Empty;
                foreach (var ct in dt)
                {
                    BCCTGioDonInfo vd = new BCCTGioDonInfo();
                    if (tenGa != ct.GaName)
                        soTT = 1;
                    else
                        soTT += 1;
                    vd.SoTT = soTT;
                    if (ct.DvcbID == "YV")
                        vd.DonViDM = "I.Cộng Yên Viên";
                    if (ct.DvcbID == "HN")
                        vd.DonViDM = "II.Cộng Hà Nội";
                    if (ct.DvcbID == "VIN")
                        vd.DonViDM = "III.Cộng Vinh";
                    if (ct.DvcbID == "DN")
                        vd.DonViDM = "IV.Cộng Đà Nẵng";
                    if (ct.DvcbID == "SG")
                        vd.DonViDM = "V.Cộng Sài Gòn";
                    var obj = DonviKTList.Where(x => x.TenDV == ct.GaName).FirstOrDefault();
                    if (obj != null)
                        vd.DonViKT = obj.MaDVCha;
                    else
                        vd.DonViKT = "Chưa thuộc chi nhánh kt nào";
                    vd.TenGa = ct.GaName;
                    vd.NhanMay = ct.NhanMay;
                    vd.DauMay = ct.DauMayID;
                    vd.SoCB = ct.SoCB;
                    vd.MaTX = ct.TaiXeID;
                    vd.TenTX = ct.TaiXeName;
                    vd.GioDon = (int)ct.GioDon;
                    tenGa = ct.GaName;
                    list.Add(vd);
                }
                if (donviKT != "Tất cả") list = list.Where(x => x.DonViKT == donviKT).ToList();
            }
        }
        #endregion

        #region BC SPTN Thực hiện
        public static void NapBCTHSPTN(int nguonDL, string maDV, int loaiBC, DateTime ngayBD, DateTime ngayKT, ref int TongSoBG, ref List<BCTHSPTNInfo> list)
        {
            List<BCTHSPTNInfo> listTH = new List<BCTHSPTNInfo>();
            string data = string.Empty;
            List<ViewBcvanDung> dtTK = new List<ViewBcvanDung>();
            List<ViewBcvanDung> dtCB = new List<ViewBcvanDung>();
            List<ViewBcvanDung> dt = new List<ViewBcvanDung>();
            DateTime ngayCBCu = new DateTime(2022, 9, 30);
            if (ngayBD < ngayCBCu)
            {
                if (ngayKT > ngayCBCu)
                {
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayCBCu;
                    data += "&LoaiMayID=ALL";
                    data += "&TuyenID=ALL";
                    dtTK = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlTkdm + "api/BaoCaos/GetBCVanDung" + data);
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayCBCu.AddDays(1);
                    data += "&ngayKT=" + ngayKT;
                    data += "&LoaiMayID=ALL";
                    data += "&TuyenID=ALL";
                    if (nguonDL == 1)
                    {
                        dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCVanDung" + data);
                    }
                    else
                    {
                        dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaos/GetBCVanDung" + data);
                    }
                }
                else
                {
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayKT;
                    data += "&LoaiMayID=ALL";
                    data += "&TuyenID=ALL";
                    dtTK = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlTkdm + "api/BaoCaos/GetBCVanDung" + data);
                }
            }
            else
            {
                data = "?MaDV=" + maDV;
                data += "&loaiBC=" + loaiBC;
                data += "&ngayBD=" + ngayBD;
                data += "&ngayKT=" + ngayKT;
                data += "&LoaiMayID=ALL";
                data += "&TuyenID=ALL";
                if (nguonDL == 1)
                {
                    dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCVanDung" + data);
                }
                else
                {
                    dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaos/GetBCVanDung" + data);
                }
            }
            if (dtTK.Count > 0)
            {
                foreach (var x in dtTK)
                {
                    if (x.DvcbID == "DN")
                    {
                        if (x.TinhChatId == 2)
                        {
                            x.Kmdw = x.Kmch;
                            x.Kmch = 0;
                        }
                        else if (x.TinhChatId == 5)
                        {
                            x.Kmdy = x.Kmch;
                            x.Kmch = 0;
                        }
                        else if (x.TinhChatId == 3 | x.TinhChatId == 4 || x.TinhChatId == 6)
                        {
                            x.Kmgh = x.Kmch;
                            x.Kmch = 0;
                        }
                    }
                }
            }
            dt = dtCB.Concat(dtTK).ToList();           
            if (dt.Count > 0)
            {
                TongSoBG += dt.Count;
                var listSL = (from ct in dt
                              group ct by new { ct.LoaiMayId, ct.CongTacId } into g
                              select new
                              {
                                  LoaiMayID = (string)g.Key.LoaiMayId,
                                  CongTacID = (short)g.Key.CongTacId,
                                  KMPhuTro = (decimal)g.Sum(x => x.Kmdw + x.Kmdy + x.Kmgh),
                                  KMChinh = (decimal)g.Sum(x => x.Kmch),
                                  TanKM = (decimal)g.Sum(x => x.Tkch + x.Tkdw + x.Tkdy + x.Tkgh),
                                  GioDon = (int)g.Sum(x => x.Dnxp + x.Dndd + x.Dncc)
                              }).ToList();
                foreach (var ct in listSL)
                {
                    BCTHSPTNInfo vd = new BCTHSPTNInfo();
                    if (ct.CongTacID <= 3)
                    {
                        vd.MaCT = 11;
                        vd.TenCT = "Tầu khách:";
                    }
                    else if (ct.CongTacID == 8)
                    {
                        vd.MaCT = 13;
                        vd.TenCT = "Chuyên dồn:";
                    }
                    else if (ct.CongTacID == 9)
                    {
                        vd.MaCT = 14;
                        vd.TenCT = "Kiêm dồn:";
                    }
                    else
                    {
                        vd.MaCT = 12;
                        vd.TenCT = "Tầu hàng:";
                    }
                    vd.MaLM = ct.LoaiMayID;
                    vd.KMPT = ct.CongTacID == 8 || ct.CongTacID == 9 ? 0 : ct.KMPhuTro;
                    vd.KMCH = ct.KMChinh;
                    vd.TanKM = ct.TanKM;
                    //vd.DonTD = ct.CongTacID == 8 ? ct.GioDon : 0;
                    vd.DonTD = ct.GioDon;
                    if (vd.KMPT > 0 || vd.KMCH > 0 || vd.TanKM > 0 || vd.DonTD > 0)
                        listTH.Add(vd);
                }

                // ra ngoai vong for thi goup lại
                list = (from ct in listTH
                        group ct by new { ct.MaCT, ct.TenCT, ct.MaLM } into g
                        select new BCTHSPTNInfo
                        {
                            SoTT = -1,
                            MaCT = g.Key.MaCT,
                            TenCT = g.Key.TenCT,
                            MaLM = g.Key.MaLM,
                            KMPT = g.Key.MaCT == 13 || g.Key.MaCT == 14 ? 0 : g.Sum(f => f.KMPT),
                            KMCH = g.Sum(f => f.KMCH),
                            TanKM = g.Sum(f => f.TanKM),
                            DonTD = g.Sum(f => f.DonTD) / 60
                        }).ToList<BCTHSPTNInfo>();
            }
        }
        #endregion

        #region BC NL Thực hiện
        public static void NapBCTHNL(int nguonDL, string maDV, int loaiBC, DateTime ngayBD, DateTime ngayKT, string tuyen, ref int TongSoBG, ref List<BCTHNLInfo> list)
        {
            List<BCTHNLInfo> listTH = new List<BCTHNLInfo>();
            //Lấy định mức của tổng công ty
            string data = "?NgayHL=" + ngayKT;
            data += "&LoaiMay=ALL";
            data += "&CongTac=0";
            data += "&MaDV=TCT";
            var listDSNLDinhMuc = HttpHelper.GetList<DSNLDinhMuc>(Configuration.UrlCBApi + "api/DuongSats/DSGetNLDinhMuc" + data).OrderBy(x => x.MaDV).ToList();
            //Lấy hệ số quy đổi nhiên liêu
            data = "?MaDV=" + maDV;
            data += "&TuThang=" + ngayBD.Month;
            data += "&DenThang=" + ngayKT.Month;
            data += "&TuNam=" + ngayBD.Year;
            data += "&DenNam=" + ngayKT.Year;
            var listHeSo = HttpHelper.GetList<HeSoQdnl>(Configuration.UrlCBApi + "api/HeSoQdnls/GetByTraTim" + data).ToList();
            //Lấy dữ liệu báo cáo
            List<ViewBcNhienLieu> dtTK = new List<ViewBcNhienLieu>();
            List<ViewBcNhienLieu> dtCB = new List<ViewBcNhienLieu>();
            List<ViewBcNhienLieu> dt = new List<ViewBcNhienLieu>();
            DateTime ngayCBCu = new DateTime(2022, 9, 30);
            if (ngayBD < ngayCBCu)
            {
                if (ngayKT > ngayCBCu)
                {
                    data = "?maDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayCBCu;
                    data += "&TuyenID=" + tuyen;
                    dtTK = HttpHelper.GetList<ViewBcNhienLieu>(Configuration.UrlTkdm + "api/BaoCaos/GetBCNhienLieu" + data);
                    data = "?maDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayCBCu.AddDays(1);
                    data += "&ngayKT=" + ngayKT;
                    data += "&TuyenID=" + tuyen;
                    if (nguonDL == 1)
                    {
                        dtCB = HttpHelper.GetList<ViewBcNhienLieu>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCNhienLieu" + data);
                    }
                    else
                    {
                        dtCB = HttpHelper.GetList<ViewBcNhienLieu>(Configuration.UrlCBApi + "api/BaoCaos/GetBCNhienLieu" + data);
                    }
                }
                else
                {
                    data = "?maDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayKT;
                    data += "&TuyenID=" + tuyen;
                    dtTK = HttpHelper.GetList<ViewBcNhienLieu>(Configuration.UrlTkdm + "api/BaoCaos/GetBCNhienLieu" + data);
                }
            }
            else
            {
                data = "?maDV=" + maDV;
                data += "&loaiBC=" + loaiBC;
                data += "&ngayBD=" + ngayBD;
                data += "&ngayKT=" + ngayKT;
                data += "&TuyenID=" + tuyen;
                if (nguonDL == 1)
                {
                    dtCB = HttpHelper.GetList<ViewBcNhienLieu>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCNhienLieu" + data);
                }
                else
                {
                    dtCB = HttpHelper.GetList<ViewBcNhienLieu>(Configuration.UrlCBApi + "api/BaoCaos/GetBCNhienLieu" + data);
                }
            }
            if (dtTK.Count > 0)
            {
                foreach (var ct in dtTK)
                {
                    if (ct.DvcbID == "YV")
                    {
                        if (ct.CongTacID == 8 && (ct.DauMayID == "LT" || ct.DauMayID == "TKLT"))
                            ct.DauMayID = "LT";
                        else if (ct.DauMayID == "DM-DD" || ct.DauMayID == "DM-ND" || ct.DauMayID == "YTND" || ct.DauMayID == "ND-DD" || ct.DauMayID == "DD-ND")
                            ct.DauMayID = "ĐM";
                        else if (ct.DauMayID == "LCSY" || ct.DauMayID == "LC-SY")
                            ct.DauMayID = "LC";
                        else if (ct.DauMayID == "CLCT" || ct.DauMayID == "UB-PL")
                            ct.DauMayID = "MK";
                        else
                            ct.DauMayID = string.Empty;
                        //if (ct.CongTacID == 8 && (ct.DauMayID == "LT" || ct.DauMayID == "TKLT"))
                        //    ct.DauMayID = "LT";
                        //else if (ct.CongTacID == 6 && (ct.DauMayID == "DM-DD" || ct.DauMayID == "DM-ND" || ct.DauMayID == "YTND" || ct.DauMayID == "ND-DD" || ct.DauMayID == "DD-ND"))
                        //    ct.DauMayID = "ĐM";
                        //else if (ct.CongTacID == 6 && (ct.DauMayID == "LCSY" || ct.DauMayID == "LC-SY"))
                        //    ct.DauMayID = "LC";
                        //else if (ct.CongTacID == 6 && (ct.DauMayID == "CLCT" || ct.DauMayID == "UB-PL"))
                        //    ct.DauMayID = "MK";
                        //else
                        //    ct.DauMayID = string.Empty;
                    }
                    else
                        ct.DauMayID = string.Empty;
                    if (ct.TinhChatID == 5)
                        ct.DauMayID = "Đẩy";
                    ct.GioDon = ct.CongTacID == 8 || ct.CongTacID == 9 ? ct.GioDon : 0;
                    ct.TanKM = ct.CongTacID == 8 || ct.CongTacID == 9 ? 0 : ct.TanKM;
                    var HeSo = listHeSo.Where(x => x.Thang == ct.ThangDT && x.Nam == ct.NamDT && x.MaDv == ct.DvcbID).FirstOrDefault();
                    ct.TieuThu = HeSo != null ? ct.TieuThu * HeSo.HesoLit : ct.TieuThu;
                    ct.DinhMuc = 0;
                    //Nạp định mức TCT
                    var dmds = new DSNLDinhMuc();
                    short congTac = (short)ct.CongTacID;
                    string ghiChu = ct.DauMayID;
                    if (ct.DauMayID == "Đẩy")
                    {
                        congTac = 5;
                        ghiChu = string.Empty;
                    }
                    else if (ct.DauMayID == "LT")
                    {
                        ghiChu = string.Empty;
                    }
                    else if (!string.IsNullOrWhiteSpace(ct.DauMayID))
                    {
                        congTac = 6;
                    }
                    else if (ct.CongTacID == 6 && string.IsNullOrWhiteSpace(ct.DauMayID))
                    {
                        congTac = 5;
                    }
                    dmds = listDSNLDinhMuc.Where(x => x.NgayHL <= ct.NgayCB && x.LoaiMayID == ct.LoaiMayID && x.CongTacId == congTac && x.MaDV == ct.DvcbID && x.GhiChu == ghiChu)
                            .OrderByDescending(x => x.NgayHL).FirstOrDefault();

                    if (dmds != null)
                    {
                        ct.DinhMuc = (ct.CongTacID == 8 || ct.CongTacID == 9) ? dmds.DinhMuc * ct.GioDon / 60 : dmds.DinhMuc * ct.TanKM / 10000;
                    }
                    else
                    {
                        if (ct.CongTacID <= 3) congTac = 1;
                        else if (ct.CongTacID == 8 || ct.CongTacID == 9) congTac = 8;
                        else congTac = 4;
                        ghiChu = string.Empty;
                        dmds = listDSNLDinhMuc.Where(x => x.NgayHL <= ct.NgayCB && x.LoaiMayID == ct.LoaiMayID && x.CongTacId == congTac && x.MaDV == ct.DvcbID && x.GhiChu == ghiChu)
                            .OrderByDescending(x => x.NgayHL).FirstOrDefault();
                        if (dmds != null)
                        {
                            ct.DinhMuc = (ct.CongTacID == 8 || ct.CongTacID == 9) ? dmds.DinhMuc * ct.GioDon / 60 : dmds.DinhMuc * ct.TanKM / 10000;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(ct.DauMayID))
                        ct.LoaiMayID += "-" + ct.DauMayID;
                    if (ct.CongTacID == 7 || ct.DauMayID == "LT")
                        ct.DinhMuc = ct.TieuThu;
                }
            }
            if (dtCB.Count > 0)
            {
                foreach (var ct in dtCB)
                {
                    int[] IntArrayThoiLC = { 3008, 3218 };
                    int[] IntArrayThoiDM = { 2962, 2918, 2921, 3110, 3006, 2957, 3066, 3027 };
                    int[] IntArrayThoiMK = { 3091, 3107, 3016, 2963, 2942, 2948 };
                    string[] strArrayMTU = { "D13E-720", "D13E-720", "D13E-725" };
                    string loaiMay = ct.LoaiMayID;
                    if (ct.GaXPID == 3000 && (ct.CongTacID == 8 || ct.CongTacID == 9))
                        ct.DauMayID = "LT";
                    else if (strArrayMTU.Contains(ct.DauMayID) && ct.CongTacID == 4)
                        ct.DauMayID = "MTU";
                    else if (ct.CongTacID == 6)
                    {
                        if (IntArrayThoiLC.Contains(ct.GaXPID) && IntArrayThoiLC.Contains(ct.GaKTID))
                            ct.DauMayID = "LC";
                        else if (IntArrayThoiDM.Contains(ct.GaXPID) && IntArrayThoiDM.Contains(ct.GaKTID))
                            ct.DauMayID = "ĐM";
                        else if (IntArrayThoiMK.Contains(ct.GaXPID) && IntArrayThoiMK.Contains(ct.GaKTID))
                            ct.DauMayID = "MK";
                        else
                            ct.DauMayID = string.Empty;
                    }
                    else ct.DauMayID = string.Empty;
                    if (ct.TinhChatID == 5)
                        ct.DauMayID = "Đẩy";
                    ct.GioDon = ct.CongTacID == 8 || ct.CongTacID == 9 ? ct.GioDon : 0;
                    ct.TanKM = ct.CongTacID == 8 || ct.CongTacID == 9 ? 0 : ct.TanKM;
                    var HeSo = listHeSo.Where(x => x.Thang == ct.ThangDT && x.Nam == ct.NamDT && x.MaDv == ct.DvcbID).FirstOrDefault();
                    ct.TieuThu = HeSo != null ? ct.TieuThu * HeSo.HesoLit : ct.TieuThu;
                    ct.DinhMuc = 0;
                    //Nạp định mức TCT
                    var dmds = new DSNLDinhMuc();
                    short congTac = (short)ct.CongTacID;
                    string ghiChu = ct.DauMayID;
                    if (ct.DauMayID == "Đẩy")
                    {
                        congTac = 5;
                        ghiChu = string.Empty;
                    }
                    else if (ct.DauMayID == "LT")
                    {
                        ghiChu = string.Empty;
                    }
                    else if (ct.DauMayID == "MTU")
                    {
                        congTac = 4;
                    }
                    else if (!string.IsNullOrWhiteSpace(ct.DauMayID))
                    {
                        congTac = 6;
                    }
                    else if (ct.CongTacID == 6 && string.IsNullOrWhiteSpace(ct.DauMayID))
                    {
                        congTac = 5;
                    }
                    dmds = listDSNLDinhMuc.Where(x => x.NgayHL <= ct.NgayCB && x.LoaiMayID == loaiMay && x.CongTacId == congTac && x.MaDV == ct.DvcbID && x.GhiChu == ghiChu)
                           .OrderByDescending(x => x.NgayHL).FirstOrDefault();
                    if (dmds != null)
                    {
                        ct.DinhMuc = (ct.CongTacID == 8 || ct.CongTacID == 9) ? dmds.DinhMuc * ct.GioDon / 60 : dmds.DinhMuc * ct.TanKM / 10000;
                    }
                    else
                    {
                        if (ct.CongTacID <= 3) congTac = 1;
                        else if (ct.CongTacID == 8 || ct.CongTacID == 9) congTac = 8;
                        else congTac = 4;
                        ghiChu = string.Empty;
                        dmds = listDSNLDinhMuc.Where(x => x.NgayHL <= ct.NgayCB && x.LoaiMayID == ct.LoaiMayID && x.CongTacId == congTac && x.MaDV == ct.DvcbID && x.GhiChu == ghiChu)
                            .OrderByDescending(x => x.NgayHL).FirstOrDefault();
                        if (dmds != null)
                        {
                            ct.DinhMuc = (ct.CongTacID == 8 || ct.CongTacID == 9) ? dmds.DinhMuc * ct.GioDon / 60 : dmds.DinhMuc * ct.TanKM / 10000;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(ct.DauMayID))
                        ct.LoaiMayID += "-" + ct.DauMayID;
                    if (ct.CongTacID == 7 || ct.DauMayID == "LT")
                        ct.DinhMuc = ct.TieuThu;
                }
            }
            dt = dtCB.Concat(dtTK).ToList();
            var listSL = (from x in dt
                          group x by new { x.LoaiMayID, x.CongTacID } into g
                          select new
                          {
                              LoaiMayID = (string)g.Key.LoaiMayID,
                              CongTacID = (short)g.Key.CongTacID,
                              TanKM = (decimal)g.Sum(x => x.TanKM),
                              GioDon = (int)g.Sum(x => x.GioDon),
                              DinhMuc = (decimal)g.Sum(x => x.DinhMuc),
                              TieuThu = (decimal)g.Sum(x => x.TieuThu)
                          }).ToList();

            foreach (var y in listSL)
            {
                BCTHNLInfo vd = new BCTHNLInfo();
                if (y.CongTacID <= 7 || y.CongTacID > 9)
                {
                    vd.MaCap1 = "*";
                    vd.TenCap1 = "TKMTT";
                    if (y.CongTacID <= 3)
                    {
                        vd.MaCap2 = "I";
                        vd.TenCap2 = "Khách";
                        if (y.CongTacID == 1)
                        {
                            vd.MaCap3 = "1";
                            vd.TenCap3 = "Thống nhất";
                        }
                        else if (y.CongTacID == 2)
                        {
                            vd.MaCap3 = "2";
                            vd.TenCap3 = "Địa phương";
                        }
                        else
                        {
                            vd.MaCap3 = "3";
                            vd.TenCap3 = "Hỗn hợp";
                        }

                    }
                    else
                    {
                        vd.MaCap2 = "II";
                        vd.TenCap2 = "Hàng";
                        if (y.CongTacID == 4)
                        {
                            vd.MaCap3 = "1";
                            vd.TenCap3 = "Hàng";
                        }
                        else if (y.CongTacID == 7)
                        {
                            vd.MaCap3 = "3";
                            vd.TenCap3 = "Công dụng";
                        }
                        else if (y.CongTacID == 10)
                        {
                            vd.MaCap3 = "4";
                            vd.TenCap3 = "Hàng 80";
                        }
                        else
                        {
                            vd.MaCap3 = "2";
                            vd.TenCap3 = "Đá+Thoi+Đẩy";
                        }
                    }
                }
                else
                {
                    vd.MaCap1 = "**";
                    vd.TenCap1 = "Dồn";
                    vd.MaCap2 = "III";
                    vd.TenCap2 = "Máy dồn";
                    if (y.CongTacID == 8)
                    {
                        vd.MaCap3 = "1";
                        vd.TenCap3 = "Chuyên dồn";
                    }
                    else
                    {
                        vd.MaCap3 = "2";
                        vd.TenCap3 = "Kiêm dồn";
                    }
                }
                vd.MaLM = y.LoaiMayID;
                vd.TanKM = y.TanKM;
                vd.GioDon = y.GioDon;
                vd.NLTC = y.DinhMuc;
                vd.NLTT = y.TieuThu;
                listTH.Add(vd);
            }

            // ra ngoai vong for thi goup lại
            list = (from z in listTH
                    group z by new { z.MaCap1, z.MaCap2, z.MaCap3, z.MaLM } into g
                    select new BCTHNLInfo
                    {
                        MaCap1 = g.Key.MaCap1,
                        TenCap1 = g.FirstOrDefault().TenCap1,
                        MaCap2 = g.Key.MaCap2,
                        TenCap2 = g.FirstOrDefault().TenCap2,
                        MaCap3 = g.Key.MaCap3,
                        TenCap3 = g.FirstOrDefault().TenCap3,
                        MaLM = g.Key.MaLM,
                        TanKM = g.Key.MaCap1 == "**" ? g.Sum(f => f.GioDon) / 60 : g.Sum(f => f.TanKM),
                        GioDon = g.Sum(f => f.GioDon) / 60,
                        NLTC = g.Sum(x => x.NLTC),
                        NLTT = g.Sum(x => x.NLTT),
                        NLLL = g.Sum(x => x.NLTC) - g.Sum(x => x.NLTT)
                    }).ToList<BCTHNLInfo>();

            foreach (var vd in list)
            {
                if (vd.MaCap1 == "**" && vd.GioDon > 0)
                {
                    //if (vd.MaCap3 == "2" && vd.MaCap2 == "III")//Kiêm dồn
                    //{
                    //    vd.DMTH = vd.NLTT / vd.GioDon;
                    //    vd.DMKH = vd.DMTH;
                    //    vd.NLTC = vd.NLTT;
                    //    vd.NLLL = 0;
                    //}
                    //else
                    //{
                    vd.DMKH = vd.NLTC / vd.GioDon;
                    vd.DMTH = vd.NLTT / vd.GioDon;
                    //}
                }
                else if (vd.TanKM > 0)
                {
                    if (vd.MaCap3 == "3" && vd.MaCap2 == "II")//Công dụng
                    {
                        vd.DMTH = vd.NLTT * 10000 / vd.TanKM;
                        vd.DMKH = vd.DMTH;
                        vd.NLTC = vd.NLTT;
                        vd.NLLL = 0;
                    }
                    else
                    {
                        vd.DMKH = vd.NLTC * 10000 / vd.TanKM;
                        vd.DMTH = vd.NLTT * 10000 / vd.TanKM;
                    }
                }
            }
            TongSoBG += dt.Count;
        }
        #endregion

        #region BC NL Thành tích
        public static void NapBCTTNL(int nguonDL, string maDV, int loaiBC, DateTime ngayBD, DateTime ngayKT, string tuyen, ref int TongSoBG, ref List<BCTTNLInfo> list)
        {
            List<BCTTNLInfo> listTT = new List<BCTTNLInfo>();
            //Lấy định mức của tổng công ty
            string data = "?NgayHL=" + ngayKT;
            data += "&LoaiMay=ALL";
            data += "&CongTac=0";
            data += "&MaDV=TCT";
            List<DSNLDinhMuc> listDSNLDinhMuc = HttpHelper.GetList<DSNLDinhMuc>(Configuration.UrlCBApi + "api/DuongSats/DSGetNLDinhMuc" + data).OrderBy(x => x.MaDV).ToList();
            //Lấy hệ số quy đổi nhiên liêu
            data = "?MaDV=" + maDV;
            data += "&TuThang=" + ngayBD.Month;
            data += "&DenThang=" + ngayKT.Month;
            data += "&TuNam=" + ngayBD.Year;
            data += "&DenNam=" + ngayKT.Year;
            var listHeSo = HttpHelper.GetList<HeSoQdnl>(Configuration.UrlCBApi + "api/HeSoQdnls/GetByTraTim" + data).ToList();
            var CongtacList = HttpHelper.GetList<CongTac>(Configuration.UrlCBApi + "api/DanhMucs/GetCongTac");
            //Lấy dữ liệu báo cáo
            List<ViewBcTTNhienLieu> dtTK = new List<ViewBcTTNhienLieu>();
            List<ViewBcTTNhienLieu> dtCB = new List<ViewBcTTNhienLieu>();
            List<ViewBcTTNhienLieu> dt = new List<ViewBcTTNhienLieu>();
            DateTime ngayCBCu = new DateTime(2022, 9, 30);
            if (ngayBD < ngayCBCu)
            {
                if (ngayKT > ngayCBCu)
                {
                    data = "?maDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayCBCu;
                    data += "&TuyenID=" + tuyen;
                    dtTK = HttpHelper.GetList<ViewBcTTNhienLieu>(Configuration.UrlTkdm + "api/BaoCaos/GetBCTTNhienLieu" + data);
                    data = "?maDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayCBCu.AddDays(1);
                    data += "&ngayKT=" + ngayKT;
                    data += "&TuyenID=" + tuyen;
                    if (nguonDL == 1)
                    {
                        dtCB = HttpHelper.GetList<ViewBcTTNhienLieu>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCTTNhienLieu" + data);
                    }
                    else
                    {
                        dtCB = HttpHelper.GetList<ViewBcTTNhienLieu>(Configuration.UrlCBApi + "api/BaoCaos/GetBCTTNhienLieu" + data);
                    }
                }
                else
                {
                    data = "?maDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayKT;
                    data += "&TuyenID=" + tuyen;
                    dtTK = HttpHelper.GetList<ViewBcTTNhienLieu>(Configuration.UrlTkdm + "api/BaoCaos/GetBCTTNhienLieu" + data);
                }
            }
            else
            {
                data = "?maDV=" + maDV;
                data += "&loaiBC=" + loaiBC;
                data += "&ngayBD=" + ngayBD;
                data += "&ngayKT=" + ngayKT;
                data += "&TuyenID=" + tuyen;
                if (nguonDL == 1)
                {
                    dtCB = HttpHelper.GetList<ViewBcTTNhienLieu>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCTTNhienLieu" + data);
                }
                else
                {
                    dtCB = HttpHelper.GetList<ViewBcTTNhienLieu>(Configuration.UrlCBApi + "api/BaoCaos/GetBCTTNhienLieu" + data);
                }

            }
            if (dtTK.Count > 0)
            {               
                foreach (var ct in dtTK)
                {
                    if (ct.DvcbID == "HN")
                    {
                        if (ct.TinhChatID == 3 | ct.TinhChatID == 4 || ct.TinhChatID == 6)
                        {
                            ct.KMGhep = ct.KMDon;
                            ct.KMDon = 0;
                        }
                    }
                    if (ct.DvcbID == "DN")
                    {
                        if (ct.TinhChatID == 2)
                        {
                            ct.KMDon = ct.KMChinh;
                            ct.KMChinh = 0;
                        }
                        else if (ct.TinhChatID == 5)
                        {
                            ct.KMDay = ct.KMChinh;
                            ct.KMChinh = 0;
                        }
                        else if (ct.TinhChatID == 3 | ct.TinhChatID == 4 || ct.TinhChatID == 6)
                        {
                            ct.KMGhep = ct.KMChinh;
                            ct.KMChinh = 0;
                        }
                    }

                    if (ct.DvcbID == "YV")
                    {
                        if (ct.CongTacID == 8 && (ct.GaKT == "LT" || ct.GaKT == "TKLT"))
                            ct.GaKT = "LT";
                        else if (ct.GaKT == "DM-DD" || ct.GaKT == "DM-ND" || ct.GaKT == "YTND" || ct.GaKT == "ND-DD" || ct.GaKT == "DD-ND")
                            ct.GaKT = "ĐM";
                        else if (ct.GaKT == "LCSY" || ct.GaKT == "LC-SY")
                            ct.GaKT = "LC";
                        else if (ct.GaKT == "CLCT" || ct.GaKT == "UB-PL")
                            ct.GaKT = "MK";
                        else
                            ct.GaKT = string.Empty;
                        //if (ct.CongTacID == 8 && (ct.GaKT == "LT" || ct.GaKT == "TKLT"))
                        //    ct.GaKT = "LT";
                        //else if (ct.CongTacID == 6 && (ct.GaKT == "DM-DD" || ct.GaKT == "DM-ND" || ct.GaKT == "YTND" || ct.GaKT == "ND-DD" || ct.GaKT == "DD-ND"))
                        //    ct.GaKT = "ĐM";
                        //else if (ct.CongTacID == 6 && (ct.GaKT == "LCSY" || ct.GaKT == "LC-SY"))
                        //    ct.GaKT = "LC";
                        //else if (ct.CongTacID == 6 && (ct.GaKT == "CLCT" || ct.GaKT == "UB-PL"))
                        //    ct.GaKT = "MK";
                        //else
                        //    ct.GaKT = string.Empty;
                    }
                    else
                        ct.GaKT = string.Empty;
                    if (ct.TinhChatID == 5)
                        ct.GaKT = "Đẩy";
                    var HeSo = listHeSo.Where(x => x.Thang == ct.ThangDT && x.Nam == ct.NamDT && x.MaDv == ct.DvcbID).FirstOrDefault();
                    ct.TieuThu15 = HeSo != null ? ct.TieuThu * HeSo.HesoLit : ct.TieuThu;
                    ct.DinhMuc = 0;
                    //Nạp định mức TCT
                    var dmds = new DSNLDinhMuc();
                    short congTac = (short)ct.CongTacID;
                    string ghiChu = ct.GaKT;
                    if (ct.GaKT == "Đẩy")
                    {
                        congTac = 5;
                        ghiChu = string.Empty;
                    }
                    else if (ct.GaKT == "LT")
                    {
                        ghiChu = string.Empty;
                    }
                    else if (!string.IsNullOrWhiteSpace(ct.GaKT))
                    {
                        congTac = 6;
                    }
                    else if (ct.CongTacID == 6 && string.IsNullOrWhiteSpace(ct.GaKT))
                    {
                        congTac = 5;
                    }
                    dmds = listDSNLDinhMuc.Where(x => x.NgayHL <= ct.NgayCB && x.LoaiMayID == ct.LoaiMayID && x.CongTacId == congTac && x.MaDV == ct.DvcbID && x.GhiChu == ghiChu)
                            .OrderByDescending(x => x.NgayHL).FirstOrDefault();

                    if (dmds != null)
                    {
                        ct.DinhMuc = (ct.CongTacID == 8 || ct.CongTacID == 9) ? dmds.DinhMuc * ct.GioDon / 60 : dmds.DinhMuc * ct.TanKM / 10000;
                    }
                    else
                    {
                        if (ct.CongTacID <= 3) congTac = 1;
                        else if (ct.CongTacID == 8 || ct.CongTacID == 9) congTac = 8;
                        else congTac = 4;
                        ghiChu = string.Empty;
                        dmds = listDSNLDinhMuc.Where(x => x.NgayHL <= ct.NgayCB && x.LoaiMayID == ct.LoaiMayID && x.CongTacId == congTac && x.MaDV == ct.DvcbID && x.GhiChu == ghiChu)
                            .OrderByDescending(x => x.NgayHL).FirstOrDefault();
                        if (dmds != null)
                        {
                            ct.DinhMuc = (ct.CongTacID == 8 || ct.CongTacID == 9) ? dmds.DinhMuc * ct.GioDon / 60 : dmds.DinhMuc * ct.TanKM / 10000;
                        }
                    }
                    ct.DauMayID = ct.LoaiMayID + "-" + ct.DauMayID;
                    if (!string.IsNullOrWhiteSpace(ct.GaKT))
                        ct.LoaiMayID += "-" + ct.GaKT;
                    if (ct.CongTacID == 7 || ct.GaKT == "LT")
                        ct.DinhMuc = ct.TieuThu15;
                }
            }
            if (dtCB.Count > 0)
            {               
                foreach (var ct in dtCB)
                {
                    string[] strArrayThoiLC = { "Lào Cai", "Sơn Yêu" };
                    string[] strArrayThoiDM = { "Đồng Mỏ", "Bắc Thủy", "Bản Thí", "Yên Trạch", "Lạng Sơn", "Đồng Đăng", "Tân Liên", "Na Dương" };
                    string[] strArrayThoiMK = { "Uông Bí", "Yên Dưỡng", "Mạo Khê", "Đông Triều", "Chí Linh", "Cổ Thành" };
                    string[] strArrayMTU = { "D13E-720", "D13E-720", "D13E-725" };
                    string loaiMay = ct.LoaiMayID;
                    string gaKT = ct.GaKT;
                    if (ct.GaXP == "Lâm Thao" && (ct.CongTacID == 8 || ct.CongTacID == 9))
                        gaKT = "LT";
                    else if (strArrayMTU.Contains(ct.DauMayID) && ct.CongTacID == 4)
                        gaKT = "MTU";
                    else if (ct.CongTacID == 6)
                    {
                        if (strArrayThoiLC.Contains(ct.GaXP) && strArrayThoiLC.Contains(ct.GaKT))
                            gaKT = "LC";
                        else if (strArrayThoiDM.Contains(ct.GaXP) && strArrayThoiDM.Contains(ct.GaKT))
                            gaKT = "ĐM";
                        else if (strArrayThoiMK.Contains(ct.GaXP) && strArrayThoiMK.Contains(ct.GaKT))
                            gaKT = "MK";
                        else
                            gaKT = string.Empty;
                    }
                    else gaKT = string.Empty;
                    if (ct.TinhChatID == 5)
                        gaKT = "Đẩy";
                    var HeSo = listHeSo.Where(x => x.Thang == ct.ThangDT && x.Nam == ct.NamDT && x.MaDv == ct.DvcbID).FirstOrDefault();
                    ct.TanKM = ct.CongTacID == 8 || ct.CongTacID == 9 ? 0 : ct.TanKM;
                    ct.TieuThu15 = HeSo != null ? ct.TieuThu * HeSo.HesoLit : ct.TieuThu;
                    ct.DinhMuc = 0;
                    //Nạp định mức TCT
                    var dmds = new DSNLDinhMuc();
                    short congTac = (short)ct.CongTacID;
                    string ghiChu = gaKT;
                    if (gaKT == "Đẩy")
                    {
                        congTac = 5;
                        ghiChu = string.Empty;
                    }
                    else if (gaKT == "LT")
                    {
                        ghiChu = string.Empty;
                    }
                    else if (gaKT == "MTU")
                    {
                        congTac = 4;
                    }
                    else if (!string.IsNullOrWhiteSpace(gaKT))
                    {
                        congTac = 6;
                    }
                    else if (ct.CongTacID == 6 && string.IsNullOrWhiteSpace(gaKT))
                    {
                        congTac = 5;
                    }
                    dmds = listDSNLDinhMuc.Where(x => x.NgayHL <= ct.NgayCB && x.LoaiMayID == loaiMay && x.CongTacId == congTac && x.MaDV == ct.DvcbID && x.GhiChu == ghiChu)
                           .OrderByDescending(x => x.NgayHL).FirstOrDefault();
                    if (dmds != null)
                    {
                        ct.DinhMuc = (ct.CongTacID == 8 || ct.CongTacID == 9) ? dmds.DinhMuc * ct.GioDon / 60 : dmds.DinhMuc * ct.TanKM / 10000;
                    }
                    else
                    {
                        if (ct.CongTacID <= 3) congTac = 1;
                        else if (ct.CongTacID == 8 || ct.CongTacID == 9) congTac = 8;
                        else congTac = 4;
                        ghiChu = string.Empty;
                        dmds = listDSNLDinhMuc.Where(x => x.NgayHL <= ct.NgayCB && x.LoaiMayID == ct.LoaiMayID && x.CongTacId == congTac && x.MaDV == ct.DvcbID && x.GhiChu == ghiChu)
                            .OrderByDescending(x => x.NgayHL).FirstOrDefault();
                        if (dmds != null)
                        {
                            ct.DinhMuc = (ct.CongTacID == 8 || ct.CongTacID == 9) ? dmds.DinhMuc * ct.GioDon / 60 : dmds.DinhMuc * ct.TanKM / 10000;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(gaKT))
                        ct.LoaiMayID += "-" + gaKT;
                    //if (ct.CongTacID == 7 || ct.CongTacID == 9 || gaKT == "LT")
                    if (ct.CongTacID == 7 || gaKT == "LT")
                        ct.DinhMuc = ct.TieuThu15;
                }
            }
            dt = dtCB.Concat(dtTK).ToList();
            var listSL = (from x in dt
                          group x by new { x.LoaiMayID, x.CongTacID } into g
                          select new
                          {
                              LoaiMayID = (string)g.Key.LoaiMayID,
                              CongTacID = (short)g.Key.CongTacID,
                              GioDon = (int)g.Sum(x => x.GioDon),
                              GioDung = (int)g.Sum(x => x.GioDung),
                              KMChinh = (decimal)g.Sum(x => x.KMChinh),
                              KMDon = (decimal)g.Sum(x => x.KMDon),
                              KMGhep = (decimal)g.Sum(x => x.KMGhep),
                              KMDay = (decimal)g.Sum(x => x.KMDay),
                              TanKM = (decimal)g.Sum(x => x.TanKM),
                              DinhMuc = (decimal)g.Sum(x => x.DinhMuc),
                              TieuThu = (decimal)g.Sum(x => x.TieuThu),
                              TieuThu15 = (decimal)g.Sum(x => x.TieuThu15)
                          }).ToList();

            foreach (var y in listSL)
            {
                BCTTNLInfo vd = new BCTTNLInfo();
                vd.MaCT = y.CongTacID;
                vd.TenCT = CongtacList.Where(z => z.CongTacId == vd.MaCT).FirstOrDefault().CongTacName;
                vd.MaLM = y.LoaiMayID;
                vd.KMChinh = y.KMChinh;
                vd.KMDon = y.KMDon;
                vd.KMGhep = y.KMGhep;
                vd.KMDay = y.KMDay;
                vd.KMDonTD = y.GioDon;
                vd.KMDungTD = y.GioDung;
                vd.TanKM = y.TanKM;
                vd.NLTC = y.DinhMuc;
                vd.NLTT = y.TieuThu;
                vd.NLTT15 = y.TieuThu15;
                listTT.Add(vd);
                if (y.CongTacID <= 3)
                {
                    vd = new BCTTNLInfo();
                    vd.MaCT = 11;
                    vd.TenCT = "Khách vận";
                    vd.MaLM = y.LoaiMayID;
                    vd.KMChinh = y.KMChinh;
                    vd.KMDon = y.KMDon;
                    vd.KMGhep = y.KMGhep;
                    vd.KMDay = y.KMDay;
                    vd.KMDonTD = y.GioDon;
                    vd.KMDungTD = y.GioDung;
                    vd.TanKM = y.TanKM;
                    vd.NLTC = y.DinhMuc;
                    vd.NLTT = y.TieuThu;
                    vd.NLTT15 = y.TieuThu15;
                    listTT.Add(vd);
                }
                else if ((y.CongTacID > 3 && y.CongTacID < 8) || y.CongTacID == 10)
                {
                    vd = new BCTTNLInfo();
                    vd.MaCT = 12;
                    vd.TenCT = "Hóa vận";
                    vd.MaLM = y.LoaiMayID;
                    vd.KMChinh = y.KMChinh;
                    vd.KMDon = y.KMDon;
                    vd.KMGhep = y.KMGhep;
                    vd.KMDay = y.KMDay;
                    vd.KMDonTD = y.GioDon;
                    vd.KMDungTD = y.GioDung;
                    vd.TanKM = y.TanKM;
                    vd.NLTC = y.DinhMuc;
                    vd.NLTT = y.TieuThu;
                    vd.NLTT15 = y.TieuThu15;
                    listTT.Add(vd);
                }
                vd = new BCTTNLInfo();
                vd.MaCT = 13;
                vd.TenCT = "Chung";
                vd.MaLM = y.LoaiMayID;
                vd.KMChinh = y.KMChinh;
                vd.KMDon = y.KMDon;
                vd.KMGhep = y.KMGhep;
                vd.KMDay = y.KMDay;
                vd.KMDonTD = y.GioDon;
                vd.KMDungTD = y.GioDung;
                vd.TanKM = y.TanKM;
                vd.NLTC = y.DinhMuc;
                vd.NLTT = y.TieuThu;
                vd.NLTT15 = y.TieuThu15;
                listTT.Add(vd);
            }

            // ra ngoai vong for thi goup lại
            list = (from z in listTT
                    group z by new { z.MaCT, z.TenCT, z.MaLM } into g
                    select new BCTTNLInfo
                    {
                        MaCT = g.Key.MaCT,
                        TenCT = g.Key.TenCT,
                        MaLM = g.Key.MaLM,
                        KMChinh = g.Sum(x => x.KMChinh),
                        KMDon = g.Sum(x => x.KMDon),
                        KMGhep = g.Sum(x => x.KMGhep),
                        KMDay = g.Sum(x => x.KMDay),
                        KMDonTD = g.Sum(x => x.KMDonTD) / 60,
                        KMDungTD = g.Sum(x => x.KMDungTD) / 60,
                        TanKM = g.Sum(f => f.TanKM),
                        NLTC = g.Sum(x => x.NLTC),
                        NLTT = g.Sum(x => x.NLTT),
                        NLTT15 = g.Sum(x => x.NLTT15)
                    }).ToList<BCTTNLInfo>();
            foreach (var vd in list)
            {
                if (vd.MaCT == 8 || vd.MaCT == 9)
                {
                    if (vd.KMDonTD > 0)
                    {
                        vd.DMKH = vd.NLTC / vd.KMDonTD;
                        vd.DMTH = vd.NLTT15 / vd.KMDonTD;
                    }
                    vd.TanBQ = vd.KMDonTD;
                }
                else
                {
                    vd.TanBQ = vd.TanKM / 10000;
                    if (vd.TanKM > 0)
                    {
                        vd.DMKH = (vd.NLTC / vd.TanKM) * 10000;
                        vd.DMTH = (vd.NLTT15 / vd.TanKM) * 10000;
                    }
                }
                vd.KMDonTD = vd.KMDonTD * 10;
                vd.KMTong = vd.KMChinh + vd.KMDon + vd.KMGhep + vd.KMDay + vd.KMDonTD + vd.KMDungTD;
            }
            TongSoBG += dt.Count;
        }
        public static void NapBCTTDM(int nguonDL, string maDV, int loaiBC, DateTime ngayBD, DateTime ngayKT, string tuyen, ref int TongSoBG, ref List<BCTTDMInfo> list)
        {
            List<BCTTDMInfo> listTT = new List<BCTTDMInfo>();
            //Lấy định mức của tổng công ty
            string data = "?NgayHL=" + ngayKT;
            data += "&LoaiMay=ALL";
            data += "&CongTac=0";
            data += "&MaDV=TCT";
            List<DSNLDinhMuc> listDSNLDinhMuc = HttpHelper.GetList<DSNLDinhMuc>(Configuration.UrlCBApi + "api/DuongSats/DSGetNLDinhMuc" + data).OrderBy(x => x.MaDV).ToList();
            //Lấy hệ số quy đổi nhiên liêu
            data = "?MaDV=" + maDV;
            data += "&TuThang=" + ngayBD.Month;
            data += "&DenThang=" + ngayKT.Month;
            data += "&TuNam=" + ngayBD.Year;
            data += "&DenNam=" + ngayKT.Year;
            var listHeSo = HttpHelper.GetList<HeSoQdnl>(Configuration.UrlCBApi + "api/HeSoQdnls/GetByTraTim" + data).ToList();
            //Lấy dữ liệu báo cáo
            List<ViewBcTTNhienLieu> dtTK = new List<ViewBcTTNhienLieu>();
            List<ViewBcTTNhienLieu> dtCB = new List<ViewBcTTNhienLieu>();
            List<ViewBcTTNhienLieu> dt = new List<ViewBcTTNhienLieu>();
            DateTime ngayCBCu = new DateTime(2022, 9, 30);
            if (ngayBD < ngayCBCu)
            {
                if (ngayKT > ngayCBCu)
                {
                    data = "?maDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayCBCu;
                    data += "&TuyenID=" + tuyen;
                    dtTK = HttpHelper.GetList<ViewBcTTNhienLieu>(Configuration.UrlTkdm + "api/BaoCaos/GetBCTTNhienLieu" + data);
                    data = "?maDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayCBCu.AddDays(1);
                    data += "&ngayKT=" + ngayKT;
                    data += "&TuyenID=" + tuyen;
                    if (nguonDL == 1)
                    {
                        dtCB = HttpHelper.GetList<ViewBcTTNhienLieu>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCTTNhienLieu" + data);
                    }
                    else
                    {
                        dtCB = HttpHelper.GetList<ViewBcTTNhienLieu>(Configuration.UrlCBApi + "api/BaoCaos/GetBCTTNhienLieu" + data);
                    }
                }
                else
                {
                    data = "?maDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayKT;
                    data += "&TuyenID=" + tuyen;
                    dtTK = HttpHelper.GetList<ViewBcTTNhienLieu>(Configuration.UrlTkdm + "api/BaoCaos/GetBCTTNhienLieu" + data);
                }
            }
            else
            {
                data = "?maDV=" + maDV;
                data += "&loaiBC=" + loaiBC;
                data += "&ngayBD=" + ngayBD;
                data += "&ngayKT=" + ngayKT;
                data += "&TuyenID=" + tuyen;
                if (nguonDL == 1)
                {
                    dtCB = HttpHelper.GetList<ViewBcTTNhienLieu>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCTTNhienLieu" + data);
                }
                else
                {
                    dtCB = HttpHelper.GetList<ViewBcTTNhienLieu>(Configuration.UrlCBApi + "api/BaoCaos/GetBCTTNhienLieu" + data);
                }
            }
            if (dtTK.Count > 0)
            {
                foreach (var ct in dtTK)
                {
                    if (ct.DvcbID == "HN")
                    {
                        if (ct.TinhChatID == 3 | ct.TinhChatID == 4 || ct.TinhChatID == 6)
                        {
                            ct.KMGhep = ct.KMDon;
                            ct.KMDon = 0;
                        }
                    }
                    if (ct.DvcbID == "DN")
                    {
                        if (ct.TinhChatID == 2)
                        {
                            ct.KMDon = ct.KMChinh;
                            ct.KMChinh = 0;
                        }
                        else if (ct.TinhChatID == 5)
                        {
                            ct.KMDay = ct.KMChinh;
                            ct.KMChinh = 0;
                        }
                        else if (ct.TinhChatID == 3 | ct.TinhChatID == 4 || ct.TinhChatID == 6)
                        {
                            ct.KMGhep = ct.KMChinh;
                            ct.KMChinh = 0;
                        }
                    }

                    if (ct.DvcbID == "YV")
                    {
                        if (ct.CongTacID == 8 && (ct.GaKT == "LT" || ct.GaKT == "TKLT"))
                            ct.GaKT = "LT";
                        else if (ct.GaKT == "DM-DD" || ct.GaKT == "DM-ND" || ct.GaKT == "YTND" || ct.GaKT == "ND-DD" || ct.GaKT == "DD-ND")
                            ct.GaKT = "ĐM";
                        else if (ct.GaKT == "LCSY" || ct.GaKT == "LC-SY")
                            ct.GaKT = "LC";
                        else if (ct.GaKT == "CLCT" || ct.GaKT == "UB-PL")
                            ct.GaKT = "MK";
                        else
                            ct.GaKT = string.Empty;
                        //if (ct.CongTacID == 8 && (ct.GaKT == "LT" || ct.GaKT == "TKLT"))
                        //    ct.GaKT = "LT";
                        //else if (ct.CongTacID == 6 && (ct.GaKT == "DM-DD" || ct.GaKT == "DM-ND" || ct.GaKT == "YTND" || ct.GaKT == "ND-DD" || ct.GaKT == "DD-ND"))
                        //    ct.GaKT = "ĐM";
                        //else if (ct.CongTacID == 6 && (ct.GaKT == "LCSY" || ct.GaKT == "LC-SY"))
                        //    ct.GaKT = "LC";
                        //else if (ct.CongTacID == 6 && (ct.GaKT == "CLCT" || ct.GaKT == "UB-PL"))
                        //    ct.GaKT = "MK";
                        //else
                        //    ct.GaKT = string.Empty;
                    }
                    else
                        ct.GaKT = string.Empty;
                    if (ct.TinhChatID == 5)
                        ct.GaKT = "Đẩy";
                    var HeSo = listHeSo.Where(x => x.Thang == ct.ThangDT && x.Nam == ct.NamDT && x.MaDv == ct.DvcbID).FirstOrDefault();
                    ct.TieuThu15 = HeSo != null ? ct.TieuThu * HeSo.HesoLit : ct.TieuThu;
                    ct.DinhMuc = 0;
                    //Nạp định mức TCT
                    var dmds = new DSNLDinhMuc();
                    short congTac = (short)ct.CongTacID;
                    string ghiChu = ct.GaKT;
                    if (ct.GaKT == "Đẩy")
                    {
                        congTac = 5;
                        ghiChu = string.Empty;
                    }
                    else if (ct.GaKT == "LT")
                    {
                        ghiChu = string.Empty;
                    }
                    else if (!string.IsNullOrWhiteSpace(ct.GaKT))
                    {
                        congTac = 6;
                    }
                    else if (ct.CongTacID == 6 && string.IsNullOrWhiteSpace(ct.GaKT))
                    {
                        congTac = 5;
                    }
                    dmds = listDSNLDinhMuc.Where(x => x.NgayHL <= ct.NgayCB && x.LoaiMayID == ct.LoaiMayID && x.CongTacId == congTac && x.MaDV == ct.DvcbID && x.GhiChu == ghiChu)
                            .OrderByDescending(x => x.NgayHL).FirstOrDefault();

                    if (dmds != null)
                    {
                        ct.DinhMuc = (ct.CongTacID == 8 || ct.CongTacID == 9) ? dmds.DinhMuc * ct.GioDon / 60 : dmds.DinhMuc * ct.TanKM / 10000;
                    }
                    else
                    {
                        if (ct.CongTacID <= 3) congTac = 1;
                        else if (ct.CongTacID == 8 || ct.CongTacID == 9) congTac = 8;
                        else congTac = 4;
                        ghiChu = string.Empty;
                        dmds = listDSNLDinhMuc.Where(x => x.NgayHL <= ct.NgayCB && x.LoaiMayID == ct.LoaiMayID && x.CongTacId == congTac && x.MaDV == ct.DvcbID && x.GhiChu == ghiChu)
                            .OrderByDescending(x => x.NgayHL).FirstOrDefault();
                        if (dmds != null)
                        {
                            ct.DinhMuc = (ct.CongTacID == 8 || ct.CongTacID == 9) ? dmds.DinhMuc * ct.GioDon / 60 : dmds.DinhMuc * ct.TanKM / 10000;
                        }
                    }
                    ct.DauMayID = ct.LoaiMayID + "-" + ct.DauMayID;
                    //if (!string.IsNullOrWhiteSpace(ct.GaKT))
                    //    ct.LoaiMayID += "-" + ct.GaKT;
                    if (ct.CongTacID == 7 || ct.GaKT == "LT")
                        ct.DinhMuc = ct.TieuThu15;
                }
            }
            if (dtCB.Count > 0)
            {
                foreach (var ct in dtCB)
                {
                    string[] strArrayThoiLC = { "Lào Cai", "Sơn Yêu" };
                    string[] strArrayThoiDM = { "Đồng Mỏ", "Bắc Thủy", "Bản Thí", "Yên Trạch", "Lạng Sơn", "Đồng Đăng", "Tân Liên", "Na Dương" };
                    string[] strArrayThoiMK = { "Uông Bí", "Yên Dưỡng", "Mạo Khê", "Đông Triều", "Chí Linh", "Cổ Thành" };
                    string[] strArrayMTU = { "D13E-720", "D13E-720", "D13E-725" };
                    string loaiMay = ct.LoaiMayID;
                    string gaKT = ct.GaKT;
                    if (ct.GaXP == "Lâm Thao" && (ct.CongTacID == 8 || ct.CongTacID == 9))
                        gaKT = "LT";
                    else if (strArrayMTU.Contains(ct.DauMayID) && ct.CongTacID == 4)
                        gaKT = "MTU";
                    else if (ct.CongTacID == 6)
                    {
                        if (strArrayThoiLC.Contains(ct.GaXP) && strArrayThoiLC.Contains(ct.GaKT))
                            gaKT = "LC";
                        else if (strArrayThoiDM.Contains(ct.GaXP) && strArrayThoiDM.Contains(ct.GaKT))
                            gaKT = "ĐM";
                        else if (strArrayThoiMK.Contains(ct.GaXP) && strArrayThoiMK.Contains(ct.GaKT))
                            gaKT = "MK";
                        else
                            gaKT = string.Empty;
                    }
                    else gaKT = string.Empty;
                    if (ct.TinhChatID == 5)
                        gaKT = "Đẩy";
                    var HeSo = listHeSo.Where(x => x.Thang == ct.ThangDT && x.Nam == ct.NamDT && x.MaDv == ct.DvcbID).FirstOrDefault();
                    ct.TanKM = ct.CongTacID == 8 || ct.CongTacID == 9 ? 0 : ct.TanKM;
                    ct.TieuThu15 = HeSo != null ? ct.TieuThu * HeSo.HesoLit : ct.TieuThu;
                    ct.DinhMuc = 0;
                    //Nạp định mức TCT
                    var dmds = new DSNLDinhMuc();
                    short congTac = (short)ct.CongTacID;
                    string ghiChu = gaKT;
                    if (gaKT == "Đẩy")
                    {
                        congTac = 5;
                        ghiChu = string.Empty;
                    }
                    else if (gaKT == "LT")
                    {
                        ghiChu = string.Empty;
                    }
                    else if (gaKT == "MTU")
                    {
                        congTac = 4;
                    }
                    else if (!string.IsNullOrWhiteSpace(gaKT))
                    {
                        congTac = 6;
                    }
                    else if (ct.CongTacID == 6 && string.IsNullOrWhiteSpace(gaKT))
                    {
                        congTac = 5;
                    }
                    dmds = listDSNLDinhMuc.Where(x => x.NgayHL <= ct.NgayCB && x.LoaiMayID == loaiMay && x.CongTacId == congTac && x.MaDV == ct.DvcbID && x.GhiChu == ghiChu)
                           .OrderByDescending(x => x.NgayHL).FirstOrDefault();
                    if (dmds != null)
                    {
                        ct.DinhMuc = (ct.CongTacID == 8 || ct.CongTacID == 9) ? dmds.DinhMuc * ct.GioDon / 60 : dmds.DinhMuc * ct.TanKM / 10000;
                    }
                    else
                    {
                        if (ct.CongTacID <= 3) congTac = 1;
                        else if (ct.CongTacID == 8 || ct.CongTacID == 9) congTac = 8;
                        else congTac = 4;
                        ghiChu = string.Empty;
                        dmds = listDSNLDinhMuc.Where(x => x.NgayHL <= ct.NgayCB && x.LoaiMayID == ct.LoaiMayID && x.CongTacId == congTac && x.MaDV == ct.DvcbID && x.GhiChu == ghiChu)
                            .OrderByDescending(x => x.NgayHL).FirstOrDefault();
                        if (dmds != null)
                        {
                            ct.DinhMuc = (ct.CongTacID == 8 || ct.CongTacID == 9) ? dmds.DinhMuc * ct.GioDon / 60 : dmds.DinhMuc * ct.TanKM / 10000;
                        }
                    }
                    //if (!string.IsNullOrWhiteSpace(gaKT))
                    //    ct.LoaiMayID += "-" + gaKT;
                    //if (ct.CongTacID == 7 || ct.CongTacID==9 || gaKT == "LT")
                    if (ct.CongTacID == 7 || gaKT == "LT")
                        ct.DinhMuc = ct.TieuThu15;
                }
            }
            dt = dtCB.Concat(dtTK).ToList();

            var listSL = (from x in dt
                          group x by new { x.DauMayID, x.LoaiMayID, x.CongTacID } into g
                          select new
                          {
                              DauMayID = (string)g.Key.DauMayID,
                              LoaiMayID = (string)g.Key.LoaiMayID,
                              CongTacID = (short)g.Key.CongTacID,
                              GioDon = (int)g.Sum(x => x.GioDon),
                              GioDung = (int)g.Sum(x => x.GioDung),
                              KMChinh = (decimal)g.Sum(x => x.KMChinh),
                              KMDon = (decimal)g.Sum(x => x.KMDon),
                              KMGhep = (decimal)g.Sum(x => x.KMGhep),
                              KMDay = (decimal)g.Sum(x => x.KMDay),
                              TanKM = (decimal)g.Sum(x => x.TanKM),
                              DinhMuc = (decimal)g.Sum(x => x.DinhMuc),
                              TieuThu = (decimal)g.Sum(x => x.TieuThu),
                              TieuThu15 = (decimal)g.Sum(x => x.TieuThu15)
                          }).ToList();

            foreach (var y in listSL)
            {
                BCTTDMInfo vd = new BCTTDMInfo();
                vd.MaDM = y.DauMayID;
                vd.MaLM = y.LoaiMayID;
                vd.KMChinh = y.KMChinh;
                vd.KMDon = y.KMDon;
                vd.KMGhep = y.KMGhep;
                vd.KMDay = y.KMDay;
                vd.KMDonTD = y.GioDon;
                vd.KMDungTD = y.GioDung;
                vd.TanKM = y.TanKM;
                vd.NLTC = y.DinhMuc;
                vd.NLTT = y.TieuThu;
                vd.NLTT15 = y.TieuThu15;
                if (y.CongTacID == 8 || y.CongTacID == 9)
                    vd.TanBQ = y.GioDon / 60;
                else
                    vd.TanBQ = y.TanKM / 10000;
                listTT.Add(vd);
            }

            // ra ngoai vong for thi goup lại
            list = (from z in listTT
                    group z by new { z.MaDM, z.MaLM } into g
                    select new BCTTDMInfo
                    {
                        MaDM = g.Key.MaDM,
                        MaLM = g.Key.MaLM,
                        KMChinh = g.Sum(x => x.KMChinh),
                        KMDon = g.Sum(x => x.KMDon),
                        KMGhep = g.Sum(x => x.KMGhep),
                        KMDay = g.Sum(x => x.KMDay),
                        KMDonTD = g.Sum(x => x.KMDonTD),
                        KMDungTD = g.Sum(x => x.KMDungTD),
                        TanKM = g.Sum(f => f.TanKM),
                        TanBQ = g.Sum(f => f.TanBQ),
                        NLTC = g.Sum(x => x.NLTC),
                        NLTT = g.Sum(x => x.NLTT),
                        NLTT15 = g.Sum(x => x.NLTT15)
                    }).ToList<BCTTDMInfo>();
            foreach (var vd in list)
            {
                if (vd.TanBQ > 0)
                {
                    vd.DMKH = vd.NLTC / vd.TanBQ;
                    vd.DMTH = vd.NLTT15 / vd.TanBQ;
                }
                vd.KMDonTD = vd.KMDonTD * 10 / 60;
                vd.KMDungTD = vd.KMDungTD / 60;
                vd.KMTong = vd.KMChinh + vd.KMDon + vd.KMGhep + vd.KMDay + vd.KMDonTD + vd.KMDungTD;
            }
            TongSoBG += dt.Count;
        }
        public static void NapBCTTTX(int nguonDL, string maDV, int loaiBC, DateTime ngayBD, DateTime ngayKT, ref int TongSoBG, ref List<BCTTTXInfo> list)
        {
            List<BCTTTXInfo> listTT = new List<BCTTTXInfo>();
            BCTTTXInfo vd = new BCTTTXInfo();
            string data = "?MaDV=" + maDV;
            data += "&TuThang=" + ngayBD.Month;
            data += "&DenThang=" + ngayKT.Month;
            data += "&TuNam=" + ngayBD.Year;
            data += "&DenNam=" + ngayKT.Year;
            //Lấy miễn phạt tài xế
            var listMienPhat = HttpHelper.GetList<MienPhat>(Configuration.UrlCBApi + "api/MienPhats/GetMienPhat" + data);
            var DonviDMList = HttpHelper.GetList<DonViDM>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViDM");
            var DMDonviList = HttpHelper.GetList<DmdonVi>(Configuration.UrlCBApi + "api/DanhMucs/GetDmdonVi");
            //Lấy danh sách tài xế
            data = "?MaDV=" + maDV;
            data += "&MaNV=";
            List<ViewDMNhanVien> listTaiXe = HttpHelper.GetList<ViewDMNhanVien>(Configuration.UrlCBApi + "api/DMNhanViens/GetViewDMNhanVien" + data)
                .OrderBy(x => x.MaSo).OrderBy(x => x.MaDV).ToList();
            //Lấy dữ liệu báo cáo
            List<ViewBcTTTaiXe> dtTK = new List<ViewBcTTTaiXe>();
            List<ViewBcTTTaiXe> dtCB = new List<ViewBcTTTaiXe>();
            List<ViewBcTTTaiXe> dt = new List<ViewBcTTTaiXe>();
            DateTime ngayCBCu = new DateTime(2022, 9, 30);
            if (ngayBD < ngayCBCu)
            {
                if (ngayKT > ngayCBCu)
                {
                    data = "?maDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayCBCu;
                    dtTK = HttpHelper.GetList<ViewBcTTTaiXe>(Configuration.UrlTkdm + "api/BaoCaos/GetBCTTTaiXe" + data);
                    data = "?maDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayCBCu.AddDays(1);
                    data += "&ngayKT=" + ngayKT;

                    if (nguonDL == 1)
                    {
                        dtCB = HttpHelper.GetList<ViewBcTTTaiXe>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCTTTaiXe" + data);
                    }
                    else
                    {
                        dtCB = HttpHelper.GetList<ViewBcTTTaiXe>(Configuration.UrlCBApi + "api/BaoCaos/GetBCTTTaiXe" + data);
                    }
                }
                else
                {
                    data = "?maDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayKT;
                    dtTK = HttpHelper.GetList<ViewBcTTTaiXe>(Configuration.UrlTkdm + "api/BaoCaos/GetBCTTTaiXe" + data);
                }
            }
            else
            {
                data = "?maDV=" + maDV;
                data += "&loaiBC=" + loaiBC;
                data += "&ngayBD=" + ngayBD;
                data += "&ngayKT=" + ngayKT;
                if (nguonDL == 1)
                {
                    dtCB = HttpHelper.GetList<ViewBcTTTaiXe>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCTTTaiXe" + data);
                }
                else
                {
                    dtCB = HttpHelper.GetList<ViewBcTTTaiXe>(Configuration.UrlCBApi + "api/BaoCaos/GetBCTTTaiXe" + data);
                }
            }
            dt = dtCB.Concat(dtTK).ToList();
            if (dt.Count > 0)
            {
                dt = dt.Where(x => x.TieuThu > 0).ToList();
                foreach (var ct in dt)
                {
                    int hsChia = 0;
                    decimal kM = (decimal)(ct.KM + (ct.GioDung / 60) + (ct.GioDon * 10 / 60));
                    decimal nlLL = (decimal)(ct.DinhMuc - ct.TieuThu);
                    var mp = listMienPhat.Where(x => x.CoBaoID == ct.CoBaoID && x.ThangDT == ct.ThangDT && x.NamDT == ct.NamDT && x.MaDV == ct.DvcbID).FirstOrDefault();
                    if (nlLL < 0 && mp != null)
                    {
                        nlLL = (decimal)(nlLL - (nlLL * mp.TyLe / 100));
                    }
                    if (!string.IsNullOrWhiteSpace(ct.TaiXe1ID)) hsChia += 1;
                    if (!string.IsNullOrWhiteSpace(ct.PhoXe1ID)) hsChia += 1;
                    if (!string.IsNullOrWhiteSpace(ct.TaiXe2ID)) hsChia += 1;
                    if (!string.IsNullOrWhiteSpace(ct.PhoXe2ID)) hsChia += 1;
                    if (!string.IsNullOrWhiteSpace(ct.TaiXe3ID)) hsChia += 1;
                    if (!string.IsNullOrWhiteSpace(ct.PhoXe3ID)) hsChia += 1;
                    if (hsChia > 0) nlLL = nlLL / hsChia;
                    if (!string.IsNullOrWhiteSpace(ct.TaiXe1ID) && hsChia > 0)
                    {
                        vd = new BCTTTXInfo();
                        vd.MaDV = ct.DvcbID;
                        vd.MaTX = ct.TaiXe1ID;
                        vd.TenTX = ct.TaiXe1Name;
                        vd.SoCB = 1;
                        vd.KM = kM;
                        vd.NLLoi = nlLL > 0 ? nlLL : 0;
                        vd.NLLo = nlLL < 0 ? -nlLL : 0;
                        listTT.Add(vd);
                    }
                    if (!string.IsNullOrWhiteSpace(ct.PhoXe1ID) && hsChia > 0)
                    {
                        vd = new BCTTTXInfo();
                        vd.MaDV = ct.DvcbID;
                        vd.MaTX = ct.PhoXe1ID;
                        vd.TenTX = ct.PhoXe1Name;
                        vd.SoCB = 1;
                        vd.KM = kM;
                        vd.NLLoi = nlLL > 0 ? nlLL : 0;
                        vd.NLLo = nlLL < 0 ? -nlLL : 0;
                        listTT.Add(vd);
                    }

                    if (!string.IsNullOrWhiteSpace(ct.TaiXe2ID) && hsChia > 0)
                    {
                        vd = new BCTTTXInfo();
                        vd.MaDV = ct.DvcbID;
                        vd.MaTX = ct.TaiXe2ID;
                        vd.TenTX = ct.TaiXe2Name;
                        vd.SoCB = 1;
                        vd.KM = kM;
                        vd.NLLoi = nlLL > 0 ? nlLL : 0;
                        vd.NLLo = nlLL < 0 ? -nlLL : 0;
                        listTT.Add(vd);
                    }
                    if (!string.IsNullOrWhiteSpace(ct.PhoXe2ID) && hsChia > 0)
                    {
                        vd = new BCTTTXInfo();
                        vd.MaDV = ct.DvcbID;
                        vd.MaTX = ct.PhoXe2ID;
                        vd.TenTX = ct.PhoXe2Name;
                        vd.SoCB = 1;
                        vd.KM = kM;
                        vd.NLLoi = nlLL > 0 ? nlLL : 0;
                        vd.NLLo = nlLL < 0 ? -nlLL : 0;
                        listTT.Add(vd);
                    }

                    if (!string.IsNullOrWhiteSpace(ct.TaiXe3ID) && hsChia > 0)
                    {
                        vd = new BCTTTXInfo();
                        vd.MaDV = ct.DvcbID;
                        vd.MaTX = ct.TaiXe3ID;
                        vd.TenTX = ct.TaiXe3Name;
                        vd.SoCB = 1;
                        vd.KM = kM;
                        vd.NLLoi = nlLL > 0 ? nlLL : 0;
                        vd.NLLo = nlLL < 0 ? -nlLL : 0;
                        listTT.Add(vd);
                    }
                    if (!string.IsNullOrWhiteSpace(ct.PhoXe3ID) && hsChia > 0)
                    {
                        vd = new BCTTTXInfo();
                        vd.MaDV = ct.DvcbID;
                        vd.MaTX = ct.PhoXe3ID;
                        vd.TenTX = ct.PhoXe3Name;
                        vd.SoCB = 1;
                        vd.KM = kM;
                        vd.NLLoi = nlLL > 0 ? nlLL : 0;
                        vd.NLLo = nlLL < 0 ? -nlLL : 0;
                        listTT.Add(vd);
                    }
                }

                // ra ngoai vong for thi goup lại
                var listG = (from x in listTT
                             group x by new { x.MaDV, x.MaTX } into g
                             select new BCTTTXInfo
                             {
                                 MaDV = g.Key.MaDV,
                                 MaTX = g.Key.MaTX,
                                 TenTX = g.FirstOrDefault().TenTX,
                                 SoCB = g.Sum(x => x.SoCB),
                                 KM = g.Sum(x => x.KM),
                                 NLLoi = g.Sum(x => x.NLLoi),
                                 NLLo = g.Sum(x => x.NLLo)
                             }).ToList<BCTTTXInfo>();
                foreach (var ct in listG)
                {
                    ct.TenDV = DonviDMList.Where(x => x.MaDV == ct.MaDV).FirstOrDefault().TenDV;
                    var viewNV = listTaiXe.Where(x => x.MaSo == ct.MaTX && x.MaCT == ct.MaDV).FirstOrDefault();
                    if (viewNV != null)
                    {
                        if (viewNV.CapQL == 4)
                        {
                            ct.Doi = viewNV.TenDV;
                            ct.Tram =DMDonviList.Where(x => x.MaDv == viewNV.DVQL).FirstOrDefault().TenDv;
                        }
                        else if (viewNV.CapQL == 3)
                        {
                            ct.Doi = "Tất cả các đội";
                            ct.Tram = viewNV.TenDV;
                        }
                        else
                        {
                            ct.Doi = "Tất cả các đội";
                            ct.Tram = "Tất cả các trạm";
                        }
                    }
                    decimal nlLL = ct.NLLoi - ct.NLLo;
                    ct.NLLoi = nlLL > 0 ? nlLL : 0;
                    ct.NLLo = nlLL < 0 ? -nlLL : 0;
                }
                list = listG.ToList();
                TongSoBG += dt.Count;
            }
        }
        #endregion

        #region BC SPTN Đối chiếu
        public static void NapBCDCSPTNKT(int nguonDL, string maDV, int loaiBC, DateTime ngayBD, DateTime ngayKT, ref int TongSoBG, ref List<BCDCSPTNInfo> list)
        {
            List<BCDCSPTNInfo> listTH = new List<BCDCSPTNInfo>();
            string data = "?MaDV=" + maDV;
            data += "&TuThang=" + ngayBD.Month;
            data += "&DenThang=" + ngayKT.Month;
            data += "&TuNam=" + ngayBD.Year;
            data += "&DenNam=" + ngayKT.Year;
            //Lấy hệ số quy đổi nhiên liêu
            var listHeSo = HttpHelper.GetList<HeSoQdnl>(Configuration.UrlCBApi + "api/HeSoQdnls/GetByTraTim" + data).ToList();
            //Lấy dữ liệu báo cáo
            List<ViewBcTacNghiep> dtTK = new List<ViewBcTacNghiep>();
            List<ViewBcTacNghiep> dtCB = new List<ViewBcTacNghiep>();
            List<ViewBcTacNghiep> dt = new List<ViewBcTacNghiep>();
            DateTime ngayCBCu = new DateTime(2022, 9, 30);
            if (ngayBD < ngayCBCu)
            {
                if (ngayKT > ngayCBCu)
                {
                    data = "?maDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayCBCu;
                    dtTK = HttpHelper.GetList<ViewBcTacNghiep>(Configuration.UrlTkdm + "api/BaoCaos/GetBCTacNghiep" + data);
                    data = "?maDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayCBCu.AddDays(1);
                    data += "&ngayKT=" + ngayKT;

                    if (nguonDL == 1)
                    {
                        dtCB = HttpHelper.GetList<ViewBcTacNghiep>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCTacNghiep" + data);
                    }
                    else
                    {
                        dtCB = HttpHelper.GetList<ViewBcTacNghiep>(Configuration.UrlCBApi + "api/BaoCaos/GetBCTacNghiep" + data);
                    }
                }
                else
                {
                    data = "?maDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayKT;
                    dtTK = HttpHelper.GetList<ViewBcTacNghiep>(Configuration.UrlTkdm + "api/BaoCaos/GetBCTacNghiep" + data);
                }
            }
            else
            {
                data = "?maDV=" + maDV;
                data += "&loaiBC=" + loaiBC;
                data += "&ngayBD=" + ngayBD;
                data += "&ngayKT=" + ngayKT;
                if (nguonDL == 1)
                {
                    dtCB = HttpHelper.GetList<ViewBcTacNghiep>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCTacNghiep" + data);
                }
                else
                {
                    dtCB = HttpHelper.GetList<ViewBcTacNghiep>(Configuration.UrlCBApi + "api/BaoCaos/GetBCTacNghiep" + data);
                }
            }
            if (dtTK.Count > 0)
            {
                foreach (var ct in dtTK)
                {
                    if (ct.DvcbID == "DN")
                    {
                        if (ct.TinhChatID >= 2 && ct.TinhChatID <= 6)
                        {
                            ct.KMPhuTro = ct.KMChinh;
                            ct.KMChinh = 0;
                        }
                    }
                    if (ct.DvcbID == "YV")
                    {
                        if (ct.CongTacID == 8 && (ct.GaKT == "LT" || ct.GaKT == "TKLT"))
                            ct.LoaiMayID += "-LT";

                    }
                }
            }
            if (dtCB.Count > 0)
            {
                foreach (var ct in dtCB)
                {

                    string[] strArrayThoiLC = { "Lào Cai", "Sơn Yêu" };
                    string[] strArrayThoiDM = { "Đồng Mỏ", "Bắc Thủy", "Bản Thí", "Yên Trạch", "Lạng Sơn", "Đồng Đăng", "Tân Liên", "Na Dương" };
                    string[] strArrayThoiMK = { "Uông Bí", "Yên Dưỡng", "Mạo Khê", "Đông Triều", "Chí Linh", "Cổ Thành" };
                    string[] strArrayThoiLB = { "Hà Nội", "Long Biên", "Gia Lâm" };
                    string[] strArrayMTU = { "D13E-720", "D13E-720", "D13E-725" };

                    if (ct.GaXP == "Lâm Thao" && (ct.CongTacID == 8 || ct.CongTacID == 9))
                        ct.LoaiMayID += "-LT";
                    else if (strArrayMTU.Contains(ct.DauMayID) && ct.CongTacID == 4)
                        ct.LoaiMayID += "-MTU";
                    else if (ct.CongTacID == 6)
                    {
                        if (strArrayThoiLC.Contains(ct.GaXP) && strArrayThoiLC.Contains(ct.GaKT))
                        {
                            ct.LoaiMayID += "-Thoi-SY";
                            ct.CongTacID = 12;
                        }
                        else if (strArrayThoiDM.Contains(ct.GaXP) && strArrayThoiDM.Contains(ct.GaKT))
                        {
                            ct.LoaiMayID += "-Thoi-ĐM";
                            ct.CongTacID = 12;
                        }
                        else if (strArrayThoiMK.Contains(ct.GaXP) && strArrayThoiMK.Contains(ct.GaKT))
                        {
                            ct.LoaiMayID += "-Thoi-MK";
                            ct.CongTacID = 12;
                        }
                        else if (strArrayThoiLB.Contains(ct.GaXP) && strArrayThoiLB.Contains(ct.GaKT))
                        {
                            ct.LoaiMayID += "-Thoi-LB";
                            ct.CongTacID = 12;
                        }
                    }
                    if (ct.TinhChatID == 5)
                    {
                        ct.LoaiMayID += "-Đẩy";
                        ct.CongTacID = 11;
                    }
                }
            }
            dt = dtCB.Concat(dtTK).ToList();
            List<ViewBcTacNghiep> listSL1 = new List<ViewBcTacNghiep>();
            if (dt.Count > 0)
            {
                dt = dt.Where(x => x.DvcbID == maDV).ToList();
                foreach (var ct in dt)
                {
                    ViewBcTacNghiep vd = new ViewBcTacNghiep();
                    vd.DoanThongID = ct.DoanThongID;
                    vd.DvcbID = ct.DvcbID;
                    vd.DvdmID = ct.DvdmID;
                    vd.LoaiMayID = ct.LoaiMayID;
                    vd.ThangDT = ct.ThangDT;
                    vd.NamDT = ct.NamDT;
                    vd.CongTacID = ct.CongTacID;
                    vd.KMChinh = ct.KMChinh;
                    vd.KMPhuTro = ct.KMPhuTro;
                    vd.GioLH = ct.GioLH;
                    vd.GioDon = ct.GioDon;
                    vd.TanKM = ct.TanKM;
                    var HeSo = listHeSo.Where(x => x.Thang == ct.ThangDT && x.Nam == ct.NamDT && x.MaDv == ct.DvcbID).FirstOrDefault();
                    vd.TieuThu = HeSo != null ? ct.TieuThu * HeSo.HesoLit : ct.TieuThu;
                    listSL1.Add(vd);
                }
                var listSL = (from x in listSL1
                              group x by new { x.LoaiMayID, x.CongTacID } into g
                              select new
                              {
                                  LoaiMayID = (string)g.Key.LoaiMayID,
                                  CongTacID = (short)g.Key.CongTacID,
                                  KMChinh = (decimal)g.Sum(x => x.KMChinh),
                                  KMPhuTro = (decimal)g.Sum(x => x.KMPhuTro),
                                  TanKM = (decimal)g.Sum(x => x.TanKM),
                                  GioLH = (int)g.Sum(x => x.GioLH),
                                  GioDon = (int)g.Sum(x => x.GioDon),
                                  TieuThu = (decimal)g.Sum(x => x.TieuThu)
                              }).ToList();

                foreach (var ct in listSL)
                {
                    BCDCSPTNInfo vd = new BCDCSPTNInfo();
                    if (ct.CongTacID <= 7 || ct.CongTacID == 10)
                    {
                        vd.MaCap1 = "A";
                        vd.TenCap1 = "Công tác chạy tầu";
                        if (ct.CongTacID <= 3)
                        {
                            vd.MaCap2 = "1";
                            vd.TenCap2 = "Tầu khách";
                        }
                        else
                        {
                            vd.MaCap2 = "2";
                            vd.TenCap2 = "Tầu hàng+C.dụng";
                        }
                    }
                    else if (ct.CongTacID >= 11)
                    {
                        vd.MaCap1 = "C";
                        vd.TenCap1 = "Công tác đặc biệt";
                        if (ct.CongTacID == 11)
                        {
                            vd.MaCap2 = "1";
                            vd.TenCap2 = "Đẩy quy đổi";
                        }
                        else
                        {
                            vd.MaCap2 = "2";
                            vd.TenCap2 = "Thoi quy đổi";
                        }
                    }
                    else
                    {
                        vd.MaCap1 = "B";
                        vd.TenCap1 = "Công tác dồn tầu";
                        if (ct.CongTacID == 8)
                        {
                            vd.MaCap2 = "1";
                            vd.TenCap2 = "Chuyên dồn";
                        }
                        else
                        {
                            vd.MaCap2 = "2";
                            vd.TenCap2 = "Kiêm dồn";
                        }
                    }
                    vd.MaLM = ct.LoaiMayID;
                    vd.KMCH = ct.KMChinh;
                    vd.KMPT = ct.CongTacID >= 11 ? 20 * ct.GioLH / 60 : ct.KMPhuTro;
                    vd.TanKM = ct.TanKM;
                    vd.GioDon = ct.GioDon;
                    vd.NLTT = ct.TieuThu;
                    listTH.Add(vd);
                }
                // ra ngoai vong for thi goup lại
                list = (from ct in listTH
                        group ct by new { ct.MaCap1, ct.MaCap2, ct.MaLM } into g
                        select new BCDCSPTNInfo
                        {
                            MaCap1 = g.Key.MaCap1,
                            TenCap1 = g.FirstOrDefault().TenCap1,
                            MaCap2 = g.Key.MaCap2,
                            TenCap2 = g.FirstOrDefault().TenCap2,
                            MaLM = g.Key.MaLM,
                            KMCH = g.Sum(x => x.KMCH),
                            KMPT = g.Sum(x => x.KMPT),
                            TanKM = g.Sum(f => f.TanKM),
                            GioDon = g.Sum(f => f.GioDon) / 60,
                            NLTT = g.Sum(x => x.NLTT)
                        }).ToList<BCDCSPTNInfo>();
                TongSoBG += dt.Count;
            }
        }
        public static void NapBCDCSPTNQL(int nguonDL, string maDV, int loaiBC, DateTime ngayBD, DateTime ngayKT, ref int TongSoBG, ref List<BCDCSPTNInfo> list)
        {
            List<BCDCSPTNInfo> listTH = new List<BCDCSPTNInfo>();
            string data = "?MaDV=" + maDV;
            data += "&TuThang=" + ngayBD.Month;
            data += "&DenThang=" + ngayKT.Month;
            data += "&TuNam=" + ngayBD.Year;
            data += "&DenNam=" + ngayKT.Year;
            //Lấy hệ số quy đổi nhiên liêu
            var listHeSo = HttpHelper.GetList<HeSoQdnl>(Configuration.UrlCBApi + "api/HeSoQdnls/GetByTraTim" + data).ToList();
            //Lấy danh sách đầu máy theo đơn vị quản lý
            data = "?maDVSH=TCT";
            data += "&maDVQL=TCT";
            data += "&loaiMay=";
            data += "&dauMay=";
            var listDauMay = HttpHelper.GetList<ViewDauMay>(Configuration.UrlCBApi + "api/DauMays/GetViewDauMay" + data)
               .OrderBy(x => x.LoaiMayID).ThenBy(x => x.DauMayID).ThenBy(x => x.NgayHL).ToList();
            //Lấy dữ liệu báo cáo
            List<ViewBcTacNghiep> dtTK = new List<ViewBcTacNghiep>();
            List<ViewBcTacNghiep> dtCB = new List<ViewBcTacNghiep>();
            List<ViewBcTacNghiep> dt = new List<ViewBcTacNghiep>();
            DateTime ngayCBCu = new DateTime(2022, 9, 30);
            if (ngayBD < ngayCBCu)
            {
                if (ngayKT > ngayCBCu)
                {
                    data = "?maDV=TCT";
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayCBCu;
                    dtTK = HttpHelper.GetList<ViewBcTacNghiep>(Configuration.UrlTkdm + "api/BaoCaos/GetBCTacNghiep" + data);
                    data = "?maDV=TCT";
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayCBCu.AddDays(1);
                    data += "&ngayKT=" + ngayKT;

                    if (nguonDL == 1)
                    {
                        dtCB = HttpHelper.GetList<ViewBcTacNghiep>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCTacNghiep" + data);
                    }
                    else
                    {
                        dtCB = HttpHelper.GetList<ViewBcTacNghiep>(Configuration.UrlCBApi + "api/BaoCaos/GetBCTacNghiep" + data);
                    }
                }
                else
                {
                    data = "?maDV=TCT";
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayKT;
                    dtTK = HttpHelper.GetList<ViewBcTacNghiep>(Configuration.UrlTkdm + "api/BaoCaos/GetBCTacNghiep" + data);
                }
            }
            else
            {
                data = "?maDV=TCT";
                data += "&loaiBC=" + loaiBC;
                data += "&ngayBD=" + ngayBD;
                data += "&ngayKT=" + ngayKT;
                if (nguonDL == 1)
                {
                    dtCB = HttpHelper.GetList<ViewBcTacNghiep>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCTacNghiep" + data);
                }
                else
                {
                    dtCB = HttpHelper.GetList<ViewBcTacNghiep>(Configuration.UrlCBApi + "api/BaoCaos/GetBCTacNghiep" + data);
                }
            }
            if (dtTK.Count > 0)
            {
                foreach (var ct in dtTK)
                {
                    ct.DvdmID = listDauMay.Where(x => x.DauMayID == ct.LoaiMayID + "-" + ct.DauMayID && x.NgayHL <= ct.NgayCB).OrderByDescending(x => x.NgayHL).FirstOrDefault().MaCTQuanLy;
                    if (ct.DvcbID == "DN")
                    {
                        if (ct.TinhChatID >= 2 && ct.TinhChatID <= 6)
                        {
                            ct.KMPhuTro = ct.KMChinh;
                            ct.KMChinh = 0;
                        }
                    }
                    if (ct.DvcbID == "YV")
                    {
                        if (ct.CongTacID == 8 && (ct.GaKT == "LT" || ct.GaKT == "TKLT"))
                            ct.LoaiMayID += "-LT";
                    }
                }
            }
            if (dtCB.Count > 0)
            {
                foreach (var ct in dtCB)
                {
                    ct.DvdmID = listDauMay.Where(x => x.DauMayID == ct.DauMayID && x.NgayHL <= ct.NgayCB).OrderByDescending(x => x.NgayHL).FirstOrDefault().MaCTQuanLy;

                    string[] strArrayThoiLC = { "Lào Cai", "Sơn Yêu" };
                    string[] strArrayThoiDM = { "Đồng Mỏ", "Bắc Thủy", "Bản Thí", "Yên Trạch", "Lạng Sơn", "Đồng Đăng", "Tân Liên", "Na Dương" };
                    string[] strArrayThoiMK = { "Uông Bí", "Yên Dưỡng", "Mạo Khê", "Đông Triều", "Chí Linh", "Cổ Thành" };
                    string[] strArrayThoiLB = { "Hà Nội", "Long Biên", "Gia Lâm" };
                    string[] strArrayMTU = { "D13E-720", "D13E-720", "D13E-725" };

                    if (ct.GaXP == "Lâm Thao" && (ct.CongTacID == 8 || ct.CongTacID == 9))
                        ct.LoaiMayID += "-LT";
                    else if (strArrayMTU.Contains(ct.DauMayID) && ct.CongTacID == 4)
                        ct.LoaiMayID += "-MTU";
                    else if (ct.CongTacID == 6)
                    {
                        if (strArrayThoiLC.Contains(ct.GaXP) && strArrayThoiLC.Contains(ct.GaKT))
                        {
                            ct.LoaiMayID += "-Thoi-SY";
                            ct.CongTacID = 12;
                        }
                        else if (strArrayThoiDM.Contains(ct.GaXP) && strArrayThoiDM.Contains(ct.GaKT))
                        {
                            ct.LoaiMayID += "-Thoi-ĐM";
                            ct.CongTacID = 12;
                        }
                        else if (strArrayThoiMK.Contains(ct.GaXP) && strArrayThoiMK.Contains(ct.GaKT))
                        {
                            ct.LoaiMayID += "-Thoi-MK";
                            ct.CongTacID = 12;
                        }
                        else if (strArrayThoiLB.Contains(ct.GaXP) && strArrayThoiLB.Contains(ct.GaKT))
                        {
                            ct.LoaiMayID += "-Thoi-LB";
                            ct.CongTacID = 12;
                        }
                    }
                    if (ct.TinhChatID == 5)
                    {
                        ct.LoaiMayID += "-Đẩy";
                        ct.CongTacID = 11;
                    }
                }
            }
            dt = dtCB.Concat(dtTK).Where(x => x.DvcbID == maDV || x.DvdmID == maDV).ToList();
            List<ViewBcTacNghiep> listSL1 = new List<ViewBcTacNghiep>();
            if (dt.Count > 0)
            {
                foreach (var ct in dt)
                {
                    ViewBcTacNghiep vd = new ViewBcTacNghiep();
                    vd.DoanThongID = ct.DoanThongID;
                    vd.DvcbID = ct.DvcbID;
                    vd.DvdmID = ct.DvdmID;
                    vd.LoaiMayID = ct.LoaiMayID;
                    vd.ThangDT = ct.ThangDT;
                    vd.NamDT = ct.NamDT;
                    vd.CongTacID = ct.CongTacID;
                    vd.KMChinh = ct.KMChinh;
                    vd.KMPhuTro = ct.KMPhuTro;
                    vd.GioLH = ct.GioLH;
                    vd.GioDon = ct.GioDon;
                    vd.TanKM = ct.TanKM;
                    var HeSo = listHeSo.Where(x => x.Thang == ct.ThangDT && x.Nam == ct.NamDT && x.MaDv == ct.DvcbID).FirstOrDefault();
                    vd.TieuThu = HeSo != null ? ct.TieuThu * HeSo.HesoLit : ct.TieuThu;

                    if (ct.DvcbID != maDV)//Ban lái tầu của đơn vị khác
                    {
                        vd.LoaiMayID += "-" + ct.DvcbID;
                        vd.TanKM = 0;
                        vd.TieuThu = 0;
                    }
                    if (ct.DvdmID != maDV)//Đầu máy của đơn vị khác
                    {
                        vd.LoaiMayID += "+" + ct.DvdmID;
                        vd.GioDon = 0;
                        vd.KMChinh = 0;
                        vd.KMPhuTro = 0;
                    }
                    listSL1.Add(vd);
                }

                var listSL = (from x in listSL1
                              group x by new { x.LoaiMayID, x.CongTacID } into g
                              select new
                              {
                                  LoaiMayID = (string)g.Key.LoaiMayID,
                                  CongTacID = (short)g.Key.CongTacID,
                                  KMChinh = (decimal)g.Sum(x => x.KMChinh),
                                  KMPhuTro = (decimal)g.Sum(x => x.KMPhuTro),
                                  TanKM = (decimal)g.Sum(x => x.TanKM),
                                  GioLH = (int)g.Sum(x => x.GioLH),
                                  GioDon = (int)g.Sum(x => x.GioDon),
                                  TieuThu = (decimal)g.Sum(x => x.TieuThu)
                              }).ToList();

                foreach (var ct in listSL)
                {
                    BCDCSPTNInfo vd = new BCDCSPTNInfo();
                    if (ct.CongTacID <= 7 || ct.CongTacID == 10)
                    {
                        vd.MaCap1 = "A";
                        vd.TenCap1 = "Công tác chạy tầu";
                        if (ct.CongTacID <= 3)
                        {
                            vd.MaCap2 = "1";
                            vd.TenCap2 = "Tầu khách";
                        }
                        else
                        {
                            vd.MaCap2 = "2";
                            vd.TenCap2 = "Tầu hàng+C.dụng";
                        }
                    }
                    else if (ct.CongTacID >= 11)
                    {
                        vd.MaCap1 = "C";
                        vd.TenCap1 = "Công tác đặc biệt";
                        if (ct.CongTacID == 11)
                        {
                            vd.MaCap2 = "1";
                            vd.TenCap2 = "Đẩy quy đổi";
                        }
                        else
                        {
                            vd.MaCap2 = "2";
                            vd.TenCap2 = "Thoi quy đổi";
                        }
                    }
                    else
                    {
                        vd.MaCap1 = "B";
                        vd.TenCap1 = "Công tác dồn tầu";
                        if (ct.CongTacID == 8)
                        {
                            vd.MaCap2 = "1";
                            vd.TenCap2 = "Chuyên dồn";
                        }
                        else
                        {
                            vd.MaCap2 = "2";
                            vd.TenCap2 = "Kiêm dồn";
                        }
                    }
                    vd.MaLM = ct.LoaiMayID;
                    vd.KMCH = ct.KMChinh;
                    vd.KMPT = ct.CongTacID >= 11 ? 20 * ct.GioLH / 60 : ct.KMPhuTro;
                    vd.TanKM = ct.TanKM;
                    vd.GioDon = ct.GioDon;
                    vd.NLTT = ct.TieuThu;
                    listTH.Add(vd);
                }
                // ra ngoai vong for thi goup lại
                list = (from ct in listTH
                        group ct by new { ct.MaCap1, ct.MaCap2, ct.MaLM } into g
                        select new BCDCSPTNInfo
                        {
                            MaCap1 = g.Key.MaCap1,
                            TenCap1 = g.FirstOrDefault().TenCap1,
                            MaCap2 = g.Key.MaCap2,
                            TenCap2 = g.FirstOrDefault().TenCap2,
                            MaLM = g.Key.MaLM,
                            KMCH = g.Sum(x => x.KMCH),
                            KMPT = g.Sum(x => x.KMPT),
                            TanKM = g.Sum(f => f.TanKM),
                            GioDon = g.Sum(f => f.GioDon) / 60,
                            NLTT = g.Sum(x => x.NLTT)
                        }).ToList<BCDCSPTNInfo>();
                TongSoBG += dt.Count;
            }
        }
        #endregion

        #region BC Dầu mỡ
        public static void NapBCTonNL(int nguonDL, string maDV, int tuThang, int denThang, int namDT, ref int TongSoBG, ref List<BCTonNLInfo> list)
        {
            string data = "?MaDV=" + maDV;
            data += "&TuThang=" + tuThang;
            data += "&DenThang=" + denThang;
            data += "&Nam=" + namDT;

            List<BCTonNLInfo> listSL = new List<BCTonNLInfo>();
            List<ViewBcTonNL> dt = new List<ViewBcTonNL>();
            if (nguonDL == 1)
            {
                dt = HttpHelper.GetList<ViewBcTonNL>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCTonNL" + data)
                .OrderBy(x => x.LoaiMayID).ThenBy(x => x.DauMayID).ThenBy(x => x.NhanMay).ToList();
            }
            else
            {
                dt = HttpHelper.GetList<ViewBcTonNL>(Configuration.UrlCBApi + "api/BaoCaos/GetBCTonNL" + data)
                .OrderBy(x => x.LoaiMayID).ThenBy(x => x.DauMayID).ThenBy(x => x.NhanMay).ToList();
            }
            if (dt.Count > 0)
            {
                string dauMay = string.Empty;
                decimal tonDau = 0;
                decimal tonCuoi = 0;
                foreach (var ct in dt)
                {
                    BCTonNLInfo dm = new BCTonNLInfo();
                    dm.LoaiMayID = ct.LoaiMayID;
                    dm.DauMayID = ct.DauMayID.Split('-')[1];
                    if (dauMay != ct.DauMayID)
                    {
                        tonDau = (decimal)ct.TonDau;
                        tonCuoi = (decimal)dt.Where(x => x.DauMayID == ct.DauMayID).OrderByDescending(x => x.NhanMay).FirstOrDefault().TonDau;
                    }
                    dm.TonDau = tonDau;
                    dm.TFGBA = ct.MaTram == "TFGBA" ? (decimal)ct.Linh : 0M;
                    dm.TFYVI = ct.MaTram == "TFYVI" ? (decimal)ct.Linh : 0M;
                    dm.TFVIN = ct.MaTram == "TFVIN" ? (decimal)ct.Linh : 0M;
                    dm.TFDNA = ct.MaTram == "TFDNA" ? (decimal)ct.Linh : 0M;
                    dm.TFSGO = ct.MaTram == "TFSGO" ? (decimal)ct.Linh : 0M;
                    dm.TFHNO = ct.MaTram == "TFHNO" ? (decimal)ct.Linh : 0M;
                    dm.TFNBI = ct.MaTram == "TFNBI" ? (decimal)ct.Linh : 0M;
                    dm.TFHPH = ct.MaTram == "TFHPH" ? (decimal)ct.Linh : 0M;
                    dm.TFDTR = ct.MaTram == "TFDTR" ? (decimal)ct.Linh : 0M;
                    dm.TFHUE = ct.MaTram == "TFHUE" ? (decimal)ct.Linh : 0M;
                    dm.TFQNG = ct.MaTram == "TFQNG" ? (decimal)ct.Linh : 0M;
                    dm.TFBTH = ct.MaTram == "TFBTH" ? (decimal)ct.Linh : 0M;
                    dm.TFNTH = ct.MaTram == "TFNTH" ? (decimal)ct.Linh : 0M;
                    dm.TFSOT = ct.MaTram == "TFSOT" ? (decimal)ct.Linh : 0M;
                    dm.TFDDA = ct.MaTram == "TFDDA" ? (decimal)ct.Linh : 0M;
                    dm.TFLCA = ct.MaTram == "TFLCA" ? (decimal)ct.Linh : 0M;
                    dm.TFLTH = ct.MaTram == "TFLTH" ? (decimal)ct.Linh : 0M;
                    dm.TFMKH = ct.MaTram == "TFMKH" ? (decimal)ct.Linh : 0M;
                    dm.TFVTR = ct.MaTram == "TFVTR" ? (decimal)ct.Linh : 0M;
                    dm.TFXGA = ct.MaTram == "TFXGA" ? (decimal)ct.Linh : 0M;
                    dm.TFYBI = ct.MaTram == "TFYBI" ? (decimal)ct.Linh : 0M;
                    dm.TFTHO = ct.MaTram == "TFTHO" ? (decimal)ct.Linh : 0M;
                    dm.TFPUT = ct.MaTram == "TFPUT" ? (decimal)ct.Linh : 0M;
                    dm.TFDHO = ct.MaTram == "TFDHO" ? (decimal)ct.Linh : 0M;
                    dm.TFNTR = ct.MaTram == "TFNTR" ? (decimal)ct.Linh : 0M;
                    dm.Linh = (decimal)ct.Linh;
                    dm.TieuThu = (decimal)ct.TieuThu;
                    dm.TonCuoi = tonCuoi;
                    dauMay = ct.DauMayID;
                    listSL.Add(dm);
                }

                list = (from x in listSL
                        group x by new { x.LoaiMayID, x.DauMayID, x.TonDau, x.TonCuoi } into g
                        select new BCTonNLInfo
                        {
                            LoaiMayID = (string)g.Key.LoaiMayID,
                            DauMayID = (string)g.Key.DauMayID,
                            TonDau = g.Key.TonDau,
                            TFGBA = (int)g.Sum(x => x.TFGBA),
                            TFYVI = (decimal)g.Sum(x => x.TFYVI),
                            TFVIN = (decimal)g.Sum(x => x.TFVIN),
                            TFDNA = (decimal)g.Sum(x => x.TFDNA),
                            TFSGO = (decimal)g.Sum(x => x.TFSGO),
                            TFHNO = (decimal)g.Sum(x => x.TFHNO),
                            TFNBI = (decimal)g.Sum(x => x.TFNBI),
                            TFHPH = (decimal)g.Sum(x => x.TFHPH),
                            TFDTR = (decimal)g.Sum(x => x.TFDTR),
                            TFHUE = (decimal)g.Sum(x => x.TFHUE),
                            TFQNG = (decimal)g.Sum(x => x.TFQNG),
                            TFBTH = (decimal)g.Sum(x => x.TFBTH),
                            TFNTH = (decimal)g.Sum(x => x.TFNTH),
                            TFSOT = (decimal)g.Sum(x => x.TFSOT),
                            TFDDA = (decimal)g.Sum(x => x.TFDDA),
                            TFLCA = (decimal)g.Sum(x => x.TFLCA),
                            TFLTH = (decimal)g.Sum(x => x.TFLTH),
                            TFMKH = (decimal)g.Sum(x => x.TFMKH),
                            TFVTR = (decimal)g.Sum(x => x.TFVTR),
                            TFXGA = (decimal)g.Sum(x => x.TFXGA),
                            TFYBI = (decimal)g.Sum(x => x.TFYBI),
                            TFTHO = (decimal)g.Sum(x => x.TFTHO),
                            TFPUT = (decimal)g.Sum(x => x.TFPUT),
                            TFDHO = (decimal)g.Sum(x => x.TFDHO),
                            TFNTR = (decimal)g.Sum(x => x.TFNTR),
                            Linh = (decimal)g.Sum(x => x.Linh),
                            TieuThu = (decimal)g.Sum(x => x.TieuThu),
                            TonCuoi = g.Key.TonCuoi
                        }).ToList();
                TongSoBG += dt.Count;
            }
        }
        public static void NapBCBKDauMo(int nguonDL, short loaiDM, string maDV, int tuThang, int denThang, int namDT, ref int TongSoBG, ref List<BKDauMoInfo> list)
        {
            string data = "?MaDV=" + maDV;
            data += "&LoaiDM=" + loaiDM;
            data += "&TuThang=" + tuThang;
            data += "&DenThang=" + denThang;
            data += "&Nam=" + namDT;
            List<ViewBcBKDauMo> dt = new List<ViewBcBKDauMo>();
            if (nguonDL == 1)
            {
                dt = HttpHelper.GetList<ViewBcBKDauMo>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCBKDauMo" + data)
                .OrderBy(x => x.DauMayID).OrderBy(x => x.LoaiMayID).OrderBy(x => x.NgayCB).ToList();
            }
            else
            {
                dt = HttpHelper.GetList<ViewBcBKDauMo>(Configuration.UrlCBApi + "api/BaoCaos/GetBCBKDauMo" + data)
                .OrderBy(x => x.DauMayID).OrderBy(x => x.LoaiMayID).OrderBy(x => x.NgayCB).ToList();
            }
            if (dt.Count > 0)
            {
                foreach (var ct in dt)
                {
                    BKDauMoInfo dm = new BKDauMoInfo();
                    dm.LoaiMayID = ct.LoaiMayID;
                    dm.DauMayID = ct.DauMayID.Split('-')[1];
                    dm.NgayCB = ct.NgayCB;
                    dm.SoCB = ct.SoCB;
                    dm.TFGBA = ct.MaTram == "TFGBA" ? (decimal)ct.Linh : 0M;
                    dm.TFYVI = ct.MaTram == "TFYVI" ? (decimal)ct.Linh : 0M;
                    dm.TFVIN = ct.MaTram == "TFVIN" ? (decimal)ct.Linh : 0M;
                    dm.TFDNA = ct.MaTram == "TFDNA" ? (decimal)ct.Linh : 0M;
                    dm.TFSGO = ct.MaTram == "TFSGO" ? (decimal)ct.Linh : 0M;
                    dm.TFHNO = ct.MaTram == "TFHNO" ? (decimal)ct.Linh : 0M;
                    dm.TFNBI = ct.MaTram == "TFNBI" ? (decimal)ct.Linh : 0M;
                    dm.TFHPH = ct.MaTram == "TFHPH" ? (decimal)ct.Linh : 0M;
                    dm.TFDTR = ct.MaTram == "TFDTR" ? (decimal)ct.Linh : 0M;
                    dm.TFHUE = ct.MaTram == "TFHUE" ? (decimal)ct.Linh : 0M;
                    dm.TFQNG = ct.MaTram == "TFQNG" ? (decimal)ct.Linh : 0M;
                    dm.TFBTH = ct.MaTram == "TFBTH" ? (decimal)ct.Linh : 0M;
                    dm.TFNTH = ct.MaTram == "TFNTH" ? (decimal)ct.Linh : 0M;
                    dm.TFSOT = ct.MaTram == "TFSOT" ? (decimal)ct.Linh : 0M;
                    dm.TFDDA = ct.MaTram == "TFDDA" ? (decimal)ct.Linh : 0M;
                    dm.TFLCA = ct.MaTram == "TFLCA" ? (decimal)ct.Linh : 0M;
                    dm.TFLTH = ct.MaTram == "TFLTH" ? (decimal)ct.Linh : 0M;
                    dm.TFMKH = ct.MaTram == "TFMKH" ? (decimal)ct.Linh : 0M;
                    dm.TFVTR = ct.MaTram == "TFVTR" ? (decimal)ct.Linh : 0M;
                    dm.TFXGA = ct.MaTram == "TFXGA" ? (decimal)ct.Linh : 0M;
                    dm.TFYBI = ct.MaTram == "TFYBI" ? (decimal)ct.Linh : 0M;
                    dm.TFTHO = ct.MaTram == "TFTHO" ? (decimal)ct.Linh : 0M;
                    dm.TFPUT = ct.MaTram == "TFPUT" ? (decimal)ct.Linh : 0M;
                    dm.TFDHO = ct.MaTram == "TFDHO" ? (decimal)ct.Linh : 0M;
                    dm.TFNTR = ct.MaTram == "TFNTR" ? (decimal)ct.Linh : 0M;
                    dm.Linh = (decimal)ct.Linh;
                    list.Add(dm);
                }
                TongSoBG += dt.Count;
            }
        }
        #endregion

        #region BC Tính lương
        public static void BKTinhLuong(int nguonDL, string maDV, int loaiBC, DateTime ngayBD, DateTime ngayKT, ref int TongSoBG, ref List<BKTinhLuongInfo> list)
        {
            List<BKTinhLuongInfo> listTH = new List<BKTinhLuongInfo>();
            string data = "?MaDV=" + maDV;
            data += "&loaiBC=" + loaiBC;
            data += "&ngayBD=" + ngayBD;
            data += "&ngayKT=" + ngayKT;
            List<ViewBcBKLuong> dt = new List<ViewBcBKLuong>();
            if (nguonDL == 1)
            {
                dt = HttpHelper.GetList<ViewBcBKLuong>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCBKLuong" + data)
                .OrderBy(x => x.DauMayID).OrderBy(x => x.NgayCB).ToList();
            }
            else
            {
                dt = HttpHelper.GetList<ViewBcBKLuong>(Configuration.UrlCBApi + "api/BaoCaos/GetBCBKLuong" + data)
                .OrderBy(x => x.DauMayID).OrderBy(x => x.NgayCB).ToList();
            }
            if (dt.Count > 0)
            {
                BKTinhLuongInfo dm = new BKTinhLuongInfo();
                string macTau = string.Empty;
                Regex regexNumber = new Regex("^[0-9]+$");
                foreach (ViewBcBKLuong aRow in dt)
                {
                    int banLT = 0; int taiXe = 0; int phoXe = 0;
                    if (!string.IsNullOrWhiteSpace(aRow.TaiXe1ID))
                    {
                        banLT += 1; taiXe += 1;
                    }
                    if (!string.IsNullOrWhiteSpace(aRow.TaiXe2ID))
                    {
                        banLT += 1; taiXe += 1;
                    }
                    if (!string.IsNullOrWhiteSpace(aRow.TaiXe3ID))
                    {
                        banLT += 1; taiXe += 1;
                    }
                    if (!string.IsNullOrWhiteSpace(aRow.PhoXe1ID))
                    {
                        banLT += 1; phoXe += 1;
                    }
                    if (!string.IsNullOrWhiteSpace(aRow.PhoXe2ID))
                    {
                        banLT += 1; phoXe += 1;
                    }
                    if (!string.IsNullOrWhiteSpace(aRow.PhoXe3ID))
                    {
                        banLT += 1; phoXe += 1;
                    }
                    var sumGioLT = (decimal)dt.Where(x => x.DauMayID == aRow.DauMayID && x.SoCB == aRow.SoCB && x.NgayCB == aRow.NgayCB).Sum(x => x.GioDm) / 60;
                    //Thêm mới khi có bản ghi
                    //Nếu có lái tầu 1
                    if (!string.IsNullOrWhiteSpace(aRow.TaiXe1ID))
                    {
                        dm = new BKTinhLuongInfo();
                        dm.NgayCB = aRow.NgayCB;
                        dm.SoCB = aRow.SoCB;
                        dm.MaCB = aRow.MaCB;
                        dm.DauMayID = aRow.DauMayID;
                        macTau = string.IsNullOrWhiteSpace(aRow.MacTauID) ? macTau : aRow.MacTauID;
                        if (aRow.TinhChatID == 5)
                            macTau = "DAY";
                        else if (aRow.TinhChatID == 3 || aRow.TinhChatID == 4 || aRow.TinhChatID == 6)
                            macTau = "KEP";
                        dm.MacTauID = macTau;
                        dm.MaLD = aRow.TaiXe1ID;
                        dm.TenLD = aRow.TaiXe1Name;
                        dm.TaiXe = 1;
                        dm.PhoXe = 0;
                        decimal _nlLoiLo = (decimal)aRow.NLLoiLo;
                        dm.NLLoi = _nlLoiLo > 0 ? _nlLoiLo : 0;
                        dm.NLLo = _nlLoiLo < 0 ? Math.Abs(_nlLoiLo) : 0;
                        dm.KM = (decimal)aRow.Km;

                        dm.GioLT = (decimal)aRow.GioDm / 60;
                        dm.GioTN = 2M;
                        dm.GioLD = sumGioLT + dm.GioTN;

                        if (banLT == 3)
                            dm.GioB = 2.5M;
                        int _maCB = -1;
                        if (regexNumber.IsMatch(dm.MaCB))
                            _maCB = int.Parse(dm.MaCB);
                        if (_maCB < 16 || (_maCB > 18 && _maCB < 24))
                        {
                            dm.GioVLM = dm.GioLD * 60 > 590 ? (dm.GioLD * 60 - 590) / 60 : 0;
                        }
                        if (_maCB >= 24 || (_maCB <= 16 && _maCB >= 18))
                        {
                            dm.GioVLM = dm.GioLD * 60 > 750 ? (dm.GioLD * 60 - 750) / 60 : 0;
                        }
                        listTH.Add(dm);
                    }
                    //Nếu có lái tầu 2
                    if (!string.IsNullOrWhiteSpace(aRow.TaiXe2ID))
                    {
                        dm = new BKTinhLuongInfo();
                        dm.NgayCB = aRow.NgayCB;
                        dm.SoCB = aRow.SoCB;
                        dm.MaCB = aRow.MaCB;
                        dm.DauMayID = aRow.DauMayID;
                        macTau = string.IsNullOrWhiteSpace(aRow.MacTauID) ? macTau : aRow.MacTauID;
                        if (aRow.TinhChatID == 5)
                            macTau = "DAY";
                        else if (aRow.TinhChatID == 3 || aRow.TinhChatID == 4 || aRow.TinhChatID == 6)
                            macTau = "KEP";
                        dm.MacTauID = macTau;
                        dm.MaLD = aRow.TaiXe2ID;
                        dm.TenLD = aRow.TaiXe2Name;
                        dm.TaiXe = 1;
                        dm.PhoXe = 0;
                        dm.NLLoi = 0;
                        dm.NLLo = 0;
                        dm.KM = 0;

                        dm.GioLT = (decimal)aRow.GioDm / 60;
                        dm.GioTN = 0;
                        dm.GioLD = sumGioLT + dm.GioTN;

                        if (banLT == 3)
                            dm.GioB = 2.5M;
                        if (banLT > 3)
                            dm.GioB = sumGioLT / 2;
                        dm.GioLT = 0;
                        dm.GioVLM = 0;
                        listTH.Add(dm);
                    }
                    //Nếu có lái tầu 3
                    if (!string.IsNullOrWhiteSpace(aRow.TaiXe3ID))
                    {
                        dm = new BKTinhLuongInfo();
                        dm.NgayCB = aRow.NgayCB;
                        dm.SoCB = aRow.SoCB;
                        dm.MaCB = aRow.MaCB;
                        dm.DauMayID = aRow.DauMayID;
                        macTau = string.IsNullOrWhiteSpace(aRow.MacTauID) ? macTau : aRow.MacTauID;
                        if (aRow.TinhChatID == 5)
                            macTau = "DAY";
                        else if (aRow.TinhChatID == 3 || aRow.TinhChatID == 4 || aRow.TinhChatID == 6)
                            macTau = "KEP";
                        dm.MacTauID = macTau;
                        dm.MaLD = aRow.TaiXe3ID;
                        dm.TenLD = aRow.TaiXe3Name;
                        dm.TaiXe = 1;
                        dm.PhoXe = 0;
                        dm.NLLoi = 0;
                        dm.NLLo = 0;
                        dm.KM = 0;

                        dm.GioLT = (decimal)aRow.GioDm / 60;
                        dm.GioTN = 0;
                        dm.GioLD = sumGioLT + dm.GioTN;

                        if (banLT == 3)
                            dm.GioB = 2.5M;
                        if (banLT > 3)
                            dm.GioB = sumGioLT / 2;
                        dm.GioLT = 0;
                        dm.GioVLM = 0;
                        listTH.Add(dm);
                    }
                    //Nếu có phụ lái tầu 1
                    if (!string.IsNullOrWhiteSpace(aRow.PhoXe1ID))
                    {
                        dm = new BKTinhLuongInfo();
                        dm.NgayCB = aRow.NgayCB;
                        dm.SoCB = aRow.SoCB;
                        dm.MaCB = aRow.MaCB;
                        dm.DauMayID = aRow.DauMayID;
                        macTau = string.IsNullOrWhiteSpace(aRow.MacTauID) ? macTau : aRow.MacTauID;
                        if (aRow.TinhChatID == 5)
                            macTau = "DAY";
                        else if (aRow.TinhChatID == 3 || aRow.TinhChatID == 4 || aRow.TinhChatID == 6)
                            macTau = "KEP";
                        dm.MacTauID = macTau;
                        dm.MaLD = aRow.PhoXe1ID;
                        dm.TenLD = aRow.PhoXe1Name;
                        dm.TaiXe = 0;
                        dm.PhoXe = 1;
                        dm.NLLoi = 0;
                        dm.NLLo = 0;
                        dm.KM = 0;

                        dm.GioLT = (decimal)aRow.GioDm / 60;
                        dm.GioTN = 2M;
                        dm.GioLD = sumGioLT + dm.GioTN;

                        if (banLT == 3)
                            dm.GioB = 2.5M;
                        int _maCB = -1;
                        if (regexNumber.IsMatch(dm.MaCB))
                            _maCB = int.Parse(dm.MaCB);
                        if (_maCB < 16 || (_maCB > 18 && _maCB < 24))
                        {
                            dm.GioVLM = dm.GioLD * 60 > 590 ? (dm.GioLD * 60 - 590) / 60 : 0;
                        }
                        if (_maCB >= 24 || (_maCB <= 16 && _maCB >= 18))
                        {
                            dm.GioVLM = dm.GioLD * 60 > 750 ? (dm.GioLD * 60 - 750) / 60 : 0;
                        }
                        listTH.Add(dm);
                    }
                    //Nếu có phụ lái tầu 2
                    if (!string.IsNullOrWhiteSpace(aRow.PhoXe2ID))
                    {
                        dm = new BKTinhLuongInfo();
                        dm.NgayCB = aRow.NgayCB;
                        dm.SoCB = aRow.SoCB;
                        dm.MaCB = aRow.MaCB;
                        dm.DauMayID = aRow.DauMayID;
                        macTau = string.IsNullOrWhiteSpace(aRow.MacTauID) ? macTau : aRow.MacTauID;
                        if (aRow.TinhChatID == 5)
                            macTau = "DAY";
                        else if (aRow.TinhChatID == 3 || aRow.TinhChatID == 4 || aRow.TinhChatID == 6)
                            macTau = "KEP";
                        dm.MacTauID = macTau;
                        dm.MaLD = aRow.PhoXe2ID;
                        dm.TenLD = aRow.PhoXe2Name;
                        dm.TaiXe = 0;
                        dm.PhoXe = 1;
                        dm.NLLoi = 0;
                        dm.NLLo = 0;
                        dm.KM = 0;

                        dm.GioLT = (decimal)aRow.GioDm / 60;
                        dm.GioTN = 0;
                        dm.GioLD = sumGioLT + dm.GioTN;

                        if (banLT == 3)
                            dm.GioB = 2.5M;
                        if (banLT > 3)
                            dm.GioB = sumGioLT / 2;
                        dm.GioLT = 0;
                        dm.GioVLM = 0;
                        listTH.Add(dm);
                    }
                    //Nếu có phụ lái tầu 3
                    if (!string.IsNullOrWhiteSpace(aRow.PhoXe3ID))
                    {
                        dm = new BKTinhLuongInfo();
                        dm.NgayCB = aRow.NgayCB;
                        dm.SoCB = aRow.SoCB;
                        dm.MaCB = aRow.MaCB;
                        dm.DauMayID = aRow.DauMayID;
                        macTau = string.IsNullOrWhiteSpace(aRow.MacTauID) ? macTau : aRow.MacTauID;
                        if (aRow.TinhChatID == 5)
                            macTau = "DAY";
                        else if (aRow.TinhChatID == 3 || aRow.TinhChatID == 4 || aRow.TinhChatID == 6)
                            macTau = "KEP";
                        dm.MacTauID = macTau;
                        dm.MaLD = aRow.PhoXe3ID;
                        dm.TenLD = aRow.PhoXe3Name;
                        dm.TaiXe = 0;
                        dm.PhoXe = 1;
                        dm.NLLoi = 0;
                        dm.NLLo = 0;
                        dm.KM = 0;

                        dm.GioLT = (decimal)aRow.GioDm / 60;
                        dm.GioTN = 0;
                        dm.GioLD = sumGioLT + dm.GioTN;

                        if (banLT == 3)
                            dm.GioB = 2.5M;
                        if (banLT > 3)
                            dm.GioB = sumGioLT / 2;
                        dm.GioLT = 0;
                        dm.GioVLM = 0;
                        listTH.Add(dm);
                    }
                }
                //Ra ngoai vòng for nhóm lại
                list = (from x in listTH
                        group x by new
                        {
                            x.NgayCB,
                            x.SoCB,
                            x.MaCB,
                            x.DauMayID,
                            x.MaLD,
                            x.TenLD
                        } into g
                        select new BKTinhLuongInfo
                        {
                            SoCB = g.Key.SoCB,
                            MaCB = g.Key.MaCB,
                            NgayCB = g.Key.NgayCB,
                            DauMayID = g.Key.DauMayID.Split('-')[1],
                            MacTauID = g.FirstOrDefault().MacTauID,
                            MaLD = g.Key.MaLD,
                            TenLD = g.Key.TenLD,
                            TaiXe = g.FirstOrDefault().TaiXe,
                            PhoXe = g.FirstOrDefault().PhoXe,
                            NLLoi = g.Sum(x => x.NLLoi),
                            NLLo = g.Sum(x => x.NLLo),
                            KM = g.Sum(x => x.KM),
                            GioLT = g.Sum(x => x.GioLT),
                            GioTN = g.FirstOrDefault().GioTN,
                            GioLD = g.FirstOrDefault().GioLD,
                            GioB = g.FirstOrDefault().GioB,
                            GioVLM = g.FirstOrDefault().GioVLM
                        }
                        ).OrderBy(x => x.DauMayID).OrderBy(x => x.NgayCB).OrderBy(x => x.SoCB).ToList();
                short _soTT = 1;
                foreach (BKTinhLuongInfo x in list)
                {
                    x.STT = _soTT;
                    _soTT += 1;
                    if (string.IsNullOrWhiteSpace(x.MaCB)) x.MaCB = "0";
                    decimal _nlLoiLo = x.NLLoi - x.NLLo;
                    x.NLLoi = _nlLoiLo > 0 ? _nlLoiLo : 0;
                    x.NLLo = _nlLoiLo < 0 ? Math.Abs(_nlLoiLo) : 0;
                }

                TongSoBG += dt.Count;
            }
        }

        #endregion

        #region BC Hiệu quả
        public static void NapBCHQSDDMLM(int nguonDL, string maDV, int loaiBC, DateTime ngayBD, DateTime ngayKT, ref List<BCHieuQuaSDDMInfo> list)
        {
            int ngayDM = int.Parse((ngayKT - ngayBD).TotalDays.ToString());
            //Lấy dữ liệu báo cáo           
            string data = string.Empty;
            List<ViewBcvanDung> dtTK = new List<ViewBcvanDung>();
            List<ViewBcvanDung> dtCB = new List<ViewBcvanDung>();
            List<ViewBcvanDung> dt = new List<ViewBcvanDung>();
            DateTime ngayCBCu = new DateTime(2022, 9, 30);
            if (ngayBD < ngayCBCu)
            {
                if (ngayKT > ngayCBCu)
                {
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayCBCu;
                    data += "&LoaiMayID=ALL";
                    data += "&TuyenID=ALL";
                    dtTK = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlTkdm + "api/BaoCaos/GetBCVanDung" + data);
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayCBCu.AddDays(1);
                    data += "&ngayKT=" + ngayKT;
                    data += "&LoaiMayID=ALL";
                    data += "&TuyenID=ALL";
                    if (nguonDL == 1)
                    {
                        dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCVanDung" + data);
                    }
                    else
                    {
                        dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaos/GetBCVanDung" + data);
                    }
                }
                else
                {
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayKT;
                    data += "&LoaiMayID=ALL";
                    data += "&TuyenID=ALL";
                    dtTK = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlTkdm + "api/BaoCaos/GetBCVanDung" + data);
                }
            }
            else
            {
                data = "?MaDV=" + maDV;
                data += "&loaiBC=" + loaiBC;
                data += "&ngayBD=" + ngayBD;
                data += "&ngayKT=" + ngayKT;
                data += "&LoaiMayID=ALL";
                data += "&TuyenID=ALL";
                if (nguonDL == 1)
                {
                    dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCVanDung" + data);
                }
                else
                {
                    dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaos/GetBCVanDung" + data);
                }
            }
            if (dtTK.Count > 0)
            {
                foreach (var x in dtTK)
                {
                    if (x.DvcbID == "DN")
                    {
                        if (x.TinhChatId == 2)
                        {
                            x.Kmdw = x.Kmch;
                            x.Kmch = 0;
                        }
                        else if (x.TinhChatId == 5)
                        {
                            x.Kmdy = x.Kmch;
                            x.Kmch = 0;
                        }
                        else if (x.TinhChatId == 3 | x.TinhChatId == 4 || x.TinhChatId == 6)
                        {
                            x.Kmgh = x.Kmch;
                            x.Kmch = 0;
                        }
                    }
                }
            }
            dt = dtCB.Concat(dtTK).ToList();
            if (dt.Count > 0)
            {
                list = (from x in dt
                        group x by new { x.LoaiMayId } into g
                        select new BCHieuQuaSDDMInfo
                        {
                            LoaiMay = g.Key.LoaiMayId,
                            GioDM = (decimal)g.Sum(x => x.GioDm) / 60,
                            GioDon = (decimal)g.Sum(x => x.Dnxp + x.Dndd + x.Dncc) / 60,
                            KmChinh = (decimal)g.Sum(x => x.Kmch),
                            KmPhuTro = (decimal)g.Sum(x => x.Kmdw + x.Kmgh + x.Kmdy),
                            VTKm = (decimal)g.Sum(x => x.Tkch + x.Tkdw + x.Tkgh + x.Tkdy),
                            KmBQ = (decimal)(g.Sum(x => x.Kmch + x.Kmdw + x.Kmgh + x.Kmdy) * 24 * 60 / g.Sum(x => x.GioDm)),
                            TanBQ = (decimal)(g.Sum(x => x.Tkch + x.Tkdw + x.Tkgh + x.Tkdy) / g.Sum(x => x.Kmch + x.Kmdw + x.Kmgh + x.Kmdy)),
                            NSuatBQ = (decimal)(g.Sum(x => x.Tkch + x.Tkdw + x.Tkgh + x.Tkdy) * 24 * 60 / g.Sum(x => x.GioDm)),
                            MayBQ = (decimal)(g.Sum(x => x.GioDm) / (ngayDM * 24 * 60)),
                            TieuThu = (decimal)g.Sum(x => x.Sltt)
                        }).ToList();
                var ctTCT = new BCHieuQuaSDDMInfo();
                ctTCT.LoaiMay = "Tất cả";
                foreach (var ct in list)
                {
                    ctTCT.GioDM += ct.GioDM;
                    ctTCT.GioDon += ct.GioDon;
                    ctTCT.KmChinh += ct.KmChinh;
                    ctTCT.KmPhuTro += ct.KmPhuTro;
                    ctTCT.VTKm += ct.VTKm;
                    ctTCT.TieuThu += ct.TieuThu;
                }
                ctTCT.KmBQ = (ctTCT.KmChinh + ctTCT.KmPhuTro) * 24 / ctTCT.GioDM;
                ctTCT.TanBQ = ctTCT.VTKm / (ctTCT.KmChinh + ctTCT.KmPhuTro);
                ctTCT.NSuatBQ = ctTCT.VTKm * 24 / ctTCT.GioDM;
                ctTCT.MayBQ = ctTCT.GioDM / (ngayDM * 24);
                list.Add(ctTCT);
            }
        }
        public static void NapBCHQSDDMDV(int nguonDL, string maDV, int loaiBC, DateTime ngayBD, DateTime ngayKT, ref List<BCHieuQuaSDDMInfo> list)
        {
            int ngayDM = int.Parse((ngayKT - ngayBD).TotalDays.ToString());
            //Lấy dữ liệu báo cáo           
            string data = string.Empty;
            List<ViewBcvanDung> dtTK = new List<ViewBcvanDung>();
            List<ViewBcvanDung> dtCB = new List<ViewBcvanDung>();
            List<ViewBcvanDung> dt = new List<ViewBcvanDung>();
            DateTime ngayCBCu = new DateTime(2022, 9, 30);
            if (ngayBD < ngayCBCu)
            {
                if (ngayKT > ngayCBCu)
                {
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayCBCu;
                    data += "&LoaiMayID=ALL";
                    data += "&TuyenID=ALL";
                    dtTK = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlTkdm + "api/BaoCaos/GetBCVanDung" + data);
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayCBCu.AddDays(1);
                    data += "&ngayKT=" + ngayKT;
                    data += "&LoaiMayID=ALL";
                    data += "&TuyenID=ALL";
                    if (nguonDL == 1)
                    {
                        dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCVanDung" + data);
                    }
                    else
                    {
                        dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaos/GetBCVanDung" + data);
                    }
                }
                else
                {
                    data = "?MaDV=" + maDV;
                    data += "&loaiBC=" + loaiBC;
                    data += "&ngayBD=" + ngayBD;
                    data += "&ngayKT=" + ngayKT;
                    data += "&LoaiMayID=ALL";
                    data += "&TuyenID=ALL";
                    dtTK = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlTkdm + "api/BaoCaos/GetBCVanDung" + data);
                }
            }
            else
            {
                data = "?MaDV=" + maDV;
                data += "&loaiBC=" + loaiBC;
                data += "&ngayBD=" + ngayBD;
                data += "&ngayKT=" + ngayKT;
                data += "&LoaiMayID=ALL";
                data += "&TuyenID=ALL";
                if (nguonDL == 1)
                {
                    dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaoGAs/GetBCVanDung" + data);
                }
                else
                {
                    dtCB = HttpHelper.GetList<ViewBcvanDung>(Configuration.UrlCBApi + "api/BaoCaos/GetBCVanDung" + data);
                }
            }
            if (dtTK.Count > 0)
            {
                foreach (var x in dtTK)
                {
                    if (x.DvcbID == "DN")
                    {
                        if (x.TinhChatId == 2)
                        {
                            x.Kmdw = x.Kmch;
                            x.Kmch = 0;
                        }
                        else if (x.TinhChatId == 5)
                        {
                            x.Kmdy = x.Kmch;
                            x.Kmch = 0;
                        }
                        else if (x.TinhChatId == 3 | x.TinhChatId == 4 || x.TinhChatId == 6)
                        {
                            x.Kmgh = x.Kmch;
                            x.Kmch = 0;
                        }
                    }
                }
            }
            dt = dtCB.Concat(dtTK).ToList();
            if (dt.Count > 0)
            {
                list = (from x in dt
                        group x by new { x.DvcbID } into g
                        select new BCHieuQuaSDDMInfo
                        {
                            XiNghiep = g.Key.DvcbID,
                            GioDM = (decimal)g.Sum(x => x.GioDm) / 60,
                            GioDon = (decimal)g.Sum(x => x.Dnxp + x.Dndd + x.Dncc) / 60,
                            KmChinh = (decimal)g.Sum(x => x.Kmch),
                            KmPhuTro = (decimal)g.Sum(x => x.Kmdw + x.Kmgh + x.Kmdy),
                            VTKm = (decimal)g.Sum(x => x.Tkch + x.Tkdw + x.Tkgh + x.Tkdy),
                            KmBQ = (decimal)(g.Sum(x => x.Kmch + x.Kmdw + x.Kmgh + x.Kmdy) * 24 * 60 / g.Sum(x => x.GioDm)),
                            TanBQ = (decimal)(g.Sum(x => x.Tkch + x.Tkdw + x.Tkgh + x.Tkdy) / g.Sum(x => x.Kmch + x.Kmdw + x.Kmgh + x.Kmdy)),
                            NSuatBQ = (decimal)(g.Sum(x => x.Tkch + x.Tkdw + x.Tkgh + x.Tkdy) * 24 * 60 / g.Sum(x => x.GioDm)),
                            MayBQ = (decimal)(g.Sum(x => x.GioDm) / (ngayDM * 24 * 60)),
                            TieuThu = (decimal)g.Sum(x => x.Sltt)
                        }).ToList();
                var ctTCT = new BCHieuQuaSDDMInfo();
                ctTCT.XiNghiep = "TCT";
                foreach (var ct in list)
                {
                    ctTCT.GioDM += ct.GioDM;
                    ctTCT.GioDon += ct.GioDon;
                    ctTCT.KmChinh += ct.KmChinh;
                    ctTCT.KmPhuTro += ct.KmPhuTro;
                    ctTCT.VTKm += ct.VTKm;
                    ctTCT.TieuThu += ct.TieuThu;
                }
                ctTCT.KmBQ = (ctTCT.KmChinh + ctTCT.KmPhuTro) * 24 / ctTCT.GioDM;
                ctTCT.TanBQ = ctTCT.VTKm / (ctTCT.KmChinh + ctTCT.KmPhuTro);
                ctTCT.NSuatBQ = ctTCT.VTKm * 24 / ctTCT.GioDM;
                ctTCT.MayBQ = ctTCT.GioDM / (ngayDM * 24);
                list.Add(ctTCT);
            }
        }
        #endregion

        #region BC Nhập kho  
        public static void NapBCNhapKhoTH(string maDV, DateTime ngayBD, DateTime ngayKT, ref int TongSoBG, ref List<NL_BCNhapKho> list)
        {
            var TramnlList = HttpHelper.GetList<DmtramNhienLieu>(Configuration.UrlCBApi + "api/DanhMucs/GetDmtramNhienLieu");            
            if (maDV != "TCT")
            {
                if (maDV == "YV")
                    TramnlList = TramnlList.Where(x => x.MaDvql == maDV || x.MaDvql == "HN").ToList();
                else if (maDV == "DN")
                    TramnlList = TramnlList.Where(x => x.MaDvql == maDV || x.MaDvql == "SG").ToList();
                else
                    TramnlList = TramnlList.Where(x => x.MaDvql == maDV).ToList();
            }
            string strTram = string.Empty;
            foreach (DmtramNhienLieu tr in TramnlList)
            {
                strTram += tr.MaTram + ",";
            }
            strTram = strTram.Substring(0, strTram.Length - 1);
            string data = "?maTram=" + strTram;
            data += "&maNCC=0";
            data += "&maPN=";
            data += "&ngayBD=" + ngayBD;
            data += "&ngayKT=" + ngayKT;
            List<NL_PhieuNhap> listPhieuNhap = HttpHelper.GetList<NL_PhieuNhap>(Configuration.UrlCBApi + "api/NhienLieus/NLGetPhieuNhap" + data).ToList();
            if (listPhieuNhap.Count > 0)
            {
                foreach (var pn in listPhieuNhap)
                {
                    NL_BCNhapKho bc = new NL_BCNhapKho();
                    bc.PhieuNhapID = pn.PhieuNhapID;
                    bc.NgayNhap = pn.NgayNhap;
                    bc.LoaiPhieu = pn.LoaiPhieu;
                    bc.TenTramNL = pn.TenTramNL;
                    bc.TenNCC = pn.TenNCC;
                    bc.TenHopDong = pn.TenHopDong;
                    bc.SoHoaDon = pn.SoHoaDon;
                    bc.NgayHoaDon = pn.NgayHoaDon;
                    bc.NguoiGiao = pn.NguoiGiao;
                    bc.LyDo = pn.LyDo;
                    bc.VAT = pn.VAT;
                    bc.TongTien = (pn.VAT + 100) * pn.NL_PhieuNhapCTs.Sum(x => x.ThanhTien) / 100;
                    list.Add(bc);
                }
            }
        }

        #endregion

        #region BC Xuất kho  
        public static void NapBCXuatKhoTH(string maDV, DateTime ngayBD, DateTime ngayKT, ref int TongSoBG, ref List<NL_BCXuatKho> list)
        {
            var TramnlList = HttpHelper.GetList<DmtramNhienLieu>(Configuration.UrlCBApi + "api/DanhMucs/GetDmtramNhienLieu");
            if (maDV != "TCT")
            {
                if (maDV == "YV")
                    TramnlList = TramnlList.Where(x => x.MaDvql == maDV || x.MaDvql == "HN").ToList();
                else if (maDV == "DN")
                    TramnlList = TramnlList.Where(x => x.MaDvql == maDV || x.MaDvql == "SG").ToList();
                else
                    TramnlList = TramnlList.Where(x => x.MaDvql == maDV).ToList();
            }
            string strTram = string.Empty;
            foreach (DmtramNhienLieu tr in TramnlList)
            {
                strTram += tr.MaTram + ",";
            }
            strTram = strTram.Substring(0, strTram.Length - 1);
            string data = "?maTram=" + strTram;
            data += "&loaiMay=ALL";
            data += "&dauMay=";
            data += "&maPX=";
            data += "&ngayBD=" + ngayBD;
            data += "&ngayKT=" + ngayKT;
            List<NL_PhieuXuat> listPhieuXuat = HttpHelper.GetList<NL_PhieuXuat>(Configuration.UrlCBApi + "api/NhienLieus/NLGetPhieuXuat" + data).ToList();
            if (listPhieuXuat.Count > 0)
            {
                foreach (var px in listPhieuXuat)
                {
                    NL_BCXuatKho bc = new NL_BCXuatKho();
                    bc.PhieuXuatID = px.PhieuXuatID;
                    bc.NgayXuat = px.NgayXuat;
                    bc.LoaiPhieu = px.LoaiPhieu;
                    bc.TenTramNL = px.TenTramNL;
                    bc.DauMayID = px.DauMayID;
                    bc.LoaiMayID = px.LoaiMayID;
                    bc.SoChungTu = px.SoChungTu;
                    bc.NguoiNhan = px.NguoiNhan;
                    bc.LyDo = px.LyDo;
                    //bc.VCF = px.VCF;
                    bc.TongTien = px.NL_PhieuXuatCTs.Sum(x => x.ThanhTien);
                    list.Add(bc);
                }
            }
            list = list.OrderBy(x => x.NgayXuat).ToList();
        }

        #endregion

        #region BC Thẻ kho  
        public static void NapBCTheKho(string maTram, short maDauMo, DateTime ngayBD, DateTime ngayKT, ref int TongSoBG, ref List<NL_BCTheKho> list)
        {
            string data = "?maTram=" + maTram;
            data += "&maDauMo=" + maDauMo;
            data += "&ngayBD=" + ngayBD;
            data += "&ngayKT=" + ngayKT;
            List<NL_BCTheKho> listTheKho = HttpHelper.GetList<NL_BCTheKho>(Configuration.UrlCBApi + "api/NhienLieus/GetBCTheKho" + data).ToList();
            if (listTheKho.Count > 0)
            {
                decimal luongTK = 0M;
                decimal tienTK = 0M;
                foreach (var tk in listTheKho)
                {
                    NL_BCTheKho bc = new NL_BCTheKho();
                    bc.LoaiPhieu = tk.LoaiPhieu;
                    bc.Ngay = tk.Ngay;
                    bc.PhieuID = tk.PhieuID;
                    bc.TramNL = tk.TramNL;
                    bc.SoLuong = tk.SoLuong;
                    bc.ThanhTien = tk.ThanhTien;
                    if (tk.LoaiPhieu == "DK")
                    {
                        bc.Ngay = DateTime.Parse(tk.Ngay.ToShortDateString() + " 23:59");
                        bc.TramNL = "Tồn đầu kỳ";
                        bc.LuongTK = tk.SoLuong;
                        bc.TienTK = tk.ThanhTien;
                        luongTK = tk.SoLuong;
                        tienTK = tk.ThanhTien;
                    }
                    else if (tk.LoaiPhieu == "PN")
                    {
                        luongTK += tk.SoLuong;
                        tienTK += tk.ThanhTien;
                        bc.LuongTK = luongTK;
                        bc.TienTK = tienTK;
                    }
                    else if (tk.LoaiPhieu == "PX")
                    {
                        luongTK -= tk.SoLuong;
                        tienTK -= tk.ThanhTien;
                        bc.LuongTK = luongTK;
                        bc.TienTK = tienTK;
                    }
                    list.Add(bc);
                }
            }
        }
        #endregion

        #region BC Tồn kho  
        public static void NapBCTonKho(string maTram, short maDauMo, DateTime ngayBD, DateTime ngayKT, ref int TongSoBG, ref List<NL_BCTonKho> list)
        {
            string data = "?maTram=" + maTram;
            data += "&maDauMo=" + maDauMo;
            data += "&ngayBD=" + ngayBD;
            data += "&ngayKT=" + ngayKT;
            list = HttpHelper.GetList<NL_BCTonKho>(Configuration.UrlCBApi + "api/NhienLieus/GetBCTonKho" + data).ToList();
            foreach (var tk in list)
            {
                tk.DonGia = (tk.TienTD + tk.TienPN) / (tk.LuongTD + tk.LuongPN);
            }
        }
        #endregion
    }
}
