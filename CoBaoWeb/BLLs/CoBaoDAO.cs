using CoBaoWeb.Models;
using CoBaoWeb.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoBaoWeb.BLLs
{
    public static class CoBaoDAO
    {
        public static BCCoBaoTTInfo NapObThanhTichByCoBaoGoc(long CoBaoID)
        {
            BCCoBaoTTInfo infobc = new BCCoBaoTTInfo();
            try
            {
                var listCobaoTT = HttpHelper.GetList<CoBaoTT>(Configuration.UrlCBApi + "api/CoBaos/GetThanhTichByCoBaoGoc?id=" + CoBaoID);
                if (listCobaoTT != null && listCobaoTT.Count > 0)
                {
                    CoBaoTT info = (from x in listCobaoTT
                                    group x by new { x.CoBaoGoc, x.DauMayID } into g
                                    select new CoBaoTT
                                    {
                                        CoBaoID = g.FirstOrDefault().CoBaoID,
                                        CoBaoGoc = g.Key.CoBaoGoc,
                                        SoCB = g.FirstOrDefault().SoCB,
                                        NgayCB = g.FirstOrDefault().NgayCB,
                                        DauMayID = g.Key.DauMayID,
                                        LoaiMayID = g.FirstOrDefault().LoaiMayID,
                                        QuayVong = g.Sum(x => x.QuayVong),
                                        LuHanh = g.Sum(x => x.LuHanh),
                                        DonThuan = g.Sum(x => x.DonThuan),
                                        GioDung = g.Sum(x => x.GioDung),
                                        GioDon = g.Sum(x => x.GioDon),
                                        KM = g.Sum(x => x.KM),
                                        TKM = g.Sum(x => x.TKM),
                                        NLTieuChuan = g.Sum(x => x.NLTieuChuan),
                                        NLTieuThu = g.Sum(x => x.NLTieuThu),
                                        NLLoiLo = g.Sum(x => x.NLLoiLo)
                                    }).FirstOrDefault();
                    infobc = new BCCoBaoTTInfo();
                    infobc.GioDM = (decimal)info.QuayVong / 60;
                    infobc.GioLH = (decimal)info.LuHanh / 60;
                    infobc.GioDT = (decimal)info.DonThuan / 60;
                    infobc.GioDung = (decimal)info.GioDung / 60;
                    infobc.GioDon = (decimal)info.GioDon / 60M;
                    infobc.KMChay = info.KM;
                    infobc.TKM = info.TKM;
                    infobc.DinhMuc = info.NLTieuChuan;
                    infobc.TieuThu = info.NLTieuThu;
                    infobc.LoiLo = info.NLLoiLo;
                }
            }
            //catch(Exception ex)
            catch
            {
                //DialogHelper.Error(ex.Message);
                infobc = null;
            }
            return infobc;
        }

        public async static Task<BCCoBaoTTInfo> ObjNapThanhTichByCoBaoGA(long CoBaoID)
        {
            BCCoBaoTTInfo infobc = new BCCoBaoTTInfo();
            try
            {
                CoBaoTT info = await HttpHelper.Get<CoBaoTT>(Configuration.UrlCBApi + "api/CoBaoGAs/GetThanhTichGA?id=" + CoBaoID);
                if (info != null)
                {
                    infobc = new BCCoBaoTTInfo();
                    infobc.GioDM = (decimal)info.QuayVong / 60;
                    infobc.GioLH = (decimal)info.LuHanh / 60;
                    infobc.GioDT = (decimal)info.DonThuan / 60;
                    infobc.GioDung = (decimal)info.GioDung / 60;
                    infobc.GioDon = (decimal)info.GioDon / 60M;
                    infobc.KMChay = info.KM;
                    infobc.TKM = info.TKM;
                    infobc.DinhMuc = info.NLTieuChuan;
                    infobc.TieuThu = info.NLTieuThu;
                    infobc.LoiLo = info.NLLoiLo;
                }
            }
            catch
            {
                infobc = null;
            }
            return infobc;
        }
        public static async Task<List<CoBaoCT>> NapCoBaoCT(CoBao coBao, UserRequest user)
        {
            List<CoBaoCT> listcobaoct = new List<CoBaoCT>();
            // Lấy chi tiết bên lõi QTHH                    
            
            var resCT = await AuthenticationService.PartnerTCTGetCoBaoDienTuByID(coBao.CoBaoGoc, user.MaNV, user.BearerToken);
            if (resCT == null || resCT.Data == null)
            {
                throw new Exception("Cảnh báo: Không lấy được dữ liệu chi tiết");
            }
            if (resCT != null && resCT.Data != null && resCT.Data.CoBaoID > 0)
            {
                List<CoBaoCT> listTemp = new List<CoBaoCT>();
                CoBaoCT cobaoct = new CoBaoCT();
                CoBaoCT cobaoctOld = new CoBaoCT();
                //Nếu có chi tiết cơ báo
                if (resCT.Data.ThongTinChiTietData != null)
                {
                    foreach (var obj in resCT.Data.ThongTinChiTietData)
                    {
                        cobaoct = new CoBaoCT();
                        cobaoct.CoBaoID = coBao.CoBaoID;
                        cobaoct.NgayXP = obj.NgayXP.HasValue ? obj.NgayXP.Value : coBao.NgayCB;
                        cobaoct.GioDen = obj.GioDen.HasValue ? obj.GioDen.Value : obj.GioDi.Value;
                        cobaoct.GioDi = obj.GioDi.HasValue ? obj.GioDi.Value : obj.GioDen.Value;
                        cobaoct.GioDon = obj.GioDon.HasValue ? obj.GioDon.Value : 0;
                        cobaoct.TauID = obj.TauID.HasValue ? obj.TauID.Value : 0;
                        cobaoct.MacTauID = obj.MacTau;
                        cobaoct.CongTyID = obj.MaCTSoHuuTau;
                        cobaoct.CongTyName = obj.TenCTSoHuuTau;
                        cobaoct.CongTacID = obj.LoaiTau.HasValue ? obj.LoaiTau.Value : (short)1;
                        cobaoct.CongTacName = obj.TenLoaiTau;
                        cobaoct.GaID = obj.GaID.HasValue ? obj.GaID.Value : 0;
                        cobaoct.GaName = obj.TenGa;
                        cobaoct.TuyenID = obj.TuyenDSVNID.HasValue ? obj.TuyenDSVNID : (short)1;
                        cobaoct.TuyenName = obj.TenTuyenDSVN;
                        cobaoct.Tan = obj.TanSo.HasValue ? obj.TanSo.Value : 0;
                        cobaoct.XeTotal = obj.TongSoXe.HasValue ? obj.TongSoXe.Value : 0;
                        cobaoct.TanXeRong = obj.TanXeRong.HasValue ? obj.TanXeRong.Value : 0;
                        cobaoct.XeRongTotal = obj.SLXeRong.HasValue ? obj.SLXeRong.Value : 0;
                        cobaoct.TinhChatID = obj.TinhChat.HasValue ? obj.TinhChat.Value : (short)1;
                        cobaoct.TinhChatName = obj.TenTinhChat;
                        if (cobaoct.TinhChatID == 4)
                        {
                            cobaoct.Tan = 0;
                            cobaoct.XeTotal = 0;
                            cobaoct.TanXeRong = 0;
                            cobaoct.XeRongTotal = 0;
                        }
                        cobaoct.MayGhepID = obj.MayGhep;
                        cobaoct.KmAdd = obj.KmAdd.HasValue ? obj.KmAdd.Value : 0;
                        if (cobaoctOld != null && cobaoctOld.GioDi == cobaoct.GioDen && cobaoct.GioDi > cobaoct.GioDen)
                            cobaoct.GioDen = cobaoct.GioDen.AddMinutes(1);
                        listTemp.Add(cobaoct);
                        cobaoctOld = cobaoct;
                    }
                }
                //Nếu có chi tiết dồn
                if (resCT.Data.DonChiTietData != null)
                {
                    foreach (var objDon in resCT.Data.DonChiTietData)
                    {
                        //den-bd-di
                        var ngayXPMT = listTemp.Where(x => x.GioDen <= objDon.ThoiGianDonBD && x.GioDi >= objDon.ThoiGianDonKT && x.GaID == objDon.GaID && objDon.LoaiDon == 1).FirstOrDefault();
                        if (ngayXPMT != null)
                        {
                            int gioDung = (int)(ngayXPMT.GioDi - ngayXPMT.GioDen).TotalMinutes;
                            cobaoct = ngayXPMT;
                            cobaoct.GioDon += objDon.GioDon.HasValue ? objDon.GioDon.Value : 0;
                            if (cobaoct.GioDon > (decimal)gioDung)
                            {
                                cobaoct.GioDon = (decimal)gioDung;
                            }
                            continue;
                        }
                        cobaoct = new CoBaoCT();
                        cobaoct.CoBaoID = coBao.CoBaoID;
                        cobaoct.NgayXP = objDon.ThoiGianDonBD.HasValue ? objDon.ThoiGianDonBD.Value : objDon.NgayXP.Value;
                        cobaoct.GioDen = objDon.ThoiGianDonBD.HasValue ? objDon.ThoiGianDonBD.Value : objDon.NgayXP.Value;
                        cobaoct.GioDi = objDon.ThoiGianDonKT.HasValue ? objDon.ThoiGianDonKT.Value : objDon.NgayXP.Value;
                        cobaoct.GioDon = objDon.GioDon.HasValue ? objDon.GioDon.Value : 0;
                        cobaoct.TauID = 0;
                        cobaoct.MacTauID = objDon.LoaiDon == 1 ? "KDON" : "CDON";
                        cobaoct.CongTyID = objDon.DiaDiemDon == 1 ? coBao.DvcbID : "C12";
                        cobaoct.CongTyName = objDon.DiaDiemDon == 1 ? coBao.DvcbName : "Tổng công ty";
                        cobaoct.CongTacID = objDon.LoaiDon == 1 ? (short)999 : (short)998;
                        cobaoct.CongTacName = objDon.TenLoaiDon;
                        cobaoct.GaID = objDon.GaID.HasValue ? objDon.GaID.Value : 0;
                        cobaoct.GaName = objDon.TenGa;
                        //Chỗ này căn giờ dồn khi nhập vào sai
                        //Giờ đến nắm trong khoảng giờ dồn
                        var gioDiLoi = listTemp.Where(x => x.GioDen >= cobaoct.GioDen && x.GioDen <= cobaoct.GioDi && x.GioDi >= cobaoct.GioDi && x.GaID == cobaoct.GaID).FirstOrDefault();
                        if (gioDiLoi != null)
                        {
                            decimal gioDon = (decimal)(gioDiLoi.GioDen - cobaoct.GioDen).TotalMinutes;
                            cobaoct.GioDon = gioDon <= cobaoct.GioDon ? gioDon - 1 : cobaoct.GioDon;
                            cobaoct.GioDi = cobaoct.GioDen.AddMinutes((double)cobaoct.GioDon);
                        }
                        //Giờ đi nắm trong khoảng giờ dồn
                        var gioDenLoi = listTemp.Where(x => x.GioDen <= cobaoct.GioDen && x.GioDi >= cobaoct.GioDen && x.GioDi <= cobaoct.GioDi && x.GaID == cobaoct.GaID).FirstOrDefault();
                        if (gioDenLoi != null)
                        {
                            decimal gioDon = (decimal)(cobaoct.GioDi - gioDenLoi.GioDi).TotalMinutes;
                            cobaoct.GioDon = gioDon <= cobaoct.GioDon ? gioDon - 1 : cobaoct.GioDon;
                            cobaoct.GioDen = cobaoct.GioDi.AddMinutes(-(double)cobaoct.GioDon);
                        }
                        //Giờ đến và giờ đi nắm trong khoảng giờ dồn
                        var gioDenDiLoi = listTemp.Where(x => x.GioDen >= cobaoct.GioDen && x.GioDi <= cobaoct.GioDi && x.GaID == cobaoct.GaID).FirstOrDefault();
                        if (gioDenDiLoi != null)
                        {
                            decimal gioDonDau = (decimal)(gioDenDiLoi.GioDen - cobaoct.GioDen).TotalMinutes;
                            decimal gioDonCuoi = (decimal)(cobaoct.GioDi - gioDenDiLoi.GioDi).TotalMinutes;
                            if (gioDonCuoi > gioDonDau)
                            {
                                cobaoct.GioDon = gioDonCuoi <= cobaoct.GioDon ? gioDonCuoi - 1 : cobaoct.GioDon;
                                cobaoct.GioDen = cobaoct.GioDi.AddMinutes(-(double)cobaoct.GioDon);
                            }
                            else
                            {
                                cobaoct.GioDon = gioDonDau <= cobaoct.GioDon ? gioDonDau - 1 : cobaoct.GioDon;
                                cobaoct.GioDi = cobaoct.GioDen.AddMinutes((double)cobaoct.GioDon);
                            }
                        }
                        cobaoct.TuyenID = 1;
                        cobaoct.TuyenName = string.Empty;
                        cobaoct.Tan = 0;
                        cobaoct.XeTotal = 0;
                        cobaoct.TanXeRong = 0;
                        cobaoct.XeRongTotal = 0;
                        cobaoct.TinhChatID = (short)1;
                        cobaoct.TinhChatName = "Máy chính";
                        cobaoct.MayGhepID = string.Empty;
                        cobaoct.KmAdd = 0;
                        listTemp.Add(cobaoct);
                    }
                }
                listcobaoct = listTemp.OrderBy(f => f.MacTauID).OrderBy(f => f.GioDi).OrderBy(f => f.GioDen).ToList();
            }
            else//Không có dữ liệu chi tiết
            {
                throw new Exception("Cảnh báo: Không có dữ liệu dồn chi tiết");
            }
            return listcobaoct;
        }
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
