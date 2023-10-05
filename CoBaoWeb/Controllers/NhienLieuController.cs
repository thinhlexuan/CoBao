using ClosedXML.Excel;
using CoBaoWeb.BLLs;
using CoBaoWeb.Models;
using CoBaoWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Reporting.NETCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoBaoWeb.Controllers
{
    [Authorize]
    public class NhienLieuController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvirnoment;
        public NhienLieuController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvirnoment = webHostEnvironment;
        }

        #region NL Loại dm
        public IActionResult Loaidm()
        {
            TTLoaidm request = new TTLoaidm();          
            return View(request);
        }
        [HttpPost]
        public IActionResult Loaidm(TTLoaidm request)
        {
            request.DMLoaiDauMo = new List<DMLoaiDauMo>();
            request.DMLoaiDauMo = Loaidm_Napdl(request.Loaidmtt);            
            return View(request);

        }
        private List<DMLoaiDauMo> Loaidm_Napdl(string tendm)
        {
            string data = "?tenDM=" + tendm;
           
            return HttpHelper.GetList<DMLoaiDauMo>(Configuration.UrlCBApi + "api/NhienLieus/NLGetLoaiDauMo" + data)
               .OrderBy(x => x.ID).ToList();

        }

        public IActionResult ExcelReport_Loaidm(TTLoaidm request)
        {
            request.DMLoaiDauMo = new List<DMLoaiDauMo>();
            request.DMLoaiDauMo = Loaidm_Napdl(request.Loaidmtt);
            XLWorkbook workbook = new XLWorkbook();
            DataTable dt = new DataTable();
            string fileName = string.Empty;
            List<DMLoaiDauMo> listLoaiDM = request.DMLoaiDauMo.ToList();
            dt = CoBaoDAO.ToDataTable<DMLoaiDauMo>(listLoaiDM);
            fileName = "Loaidm.xlsx";
            workbook.Worksheets.Add(dt, "Sheet1");
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            MemoryStream memoryStream = new MemoryStream();
            workbook.SaveAs((Stream)memoryStream);
            memoryStream.Seek(0L, SeekOrigin.Begin);

            var content = memoryStream.ToArray();
            return File(content, contentType, fileName);
        }
        #endregion

        #region NL Nhà cc
        public IActionResult Nhacc()
        {
            TTNhacc request = new TTNhacc();
            return View(request);
        }
        [HttpPost]
        public IActionResult Nhacc(TTNhacc request)
        {
            request.NL_NhaCC = new List<NL_NhaCC>();
            request.NL_NhaCC = Nhacc_Napdl(request.Tenncc);
            return View(request);

        }
        private List<NL_NhaCC> Nhacc_Napdl(string tenncc)
        {
            string data = "?tenNCC=" + tenncc;

            return HttpHelper.GetList<NL_NhaCC>(Configuration.UrlCBApi + "api/NhienLieus/NLGetNhaCC" + data)
               .OrderBy(x => x.ID).ToList();

        }

        public IActionResult ExcelReport_Nhacc(TTNhacc request)
        {
            request.NL_NhaCC = new List<NL_NhaCC>();
            request.NL_NhaCC = Nhacc_Napdl(request.Tenncc);
            XLWorkbook workbook = new XLWorkbook();
            DataTable dt = new DataTable();
            string fileName = string.Empty;
            List<NL_NhaCC> listNhacc = request.NL_NhaCC.ToList();
            dt = CoBaoDAO.ToDataTable<NL_NhaCC>(listNhacc);
            fileName = "Nhacc.xlsx";
            workbook.Worksheets.Add(dt, "Sheet1");
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            MemoryStream memoryStream = new MemoryStream();
            workbook.SaveAs((Stream)memoryStream);
            memoryStream.Seek(0L, SeekOrigin.Begin);

            var content = memoryStream.ToArray();
            return File(content, contentType, fileName);
        }
        #endregion

        #region NL Hợp đồng
        public IActionResult Hopdong()
        {
            TTHopdong request = new TTHopdong();
            return View(request);
        }
        [HttpPost]
        public IActionResult Hopdong(TTHopdong request)
        {
            request.NL_HopDong = new List<NL_HopDong>();
            request.NL_HopDong = Hopdong_Napdl(request.Tenncc,request.Tenhd);
            return View(request);

        }
        private List<NL_HopDong> Hopdong_Napdl(string tenncc, string tenhd)
        {
            string data = "?tenNCC=" + tenncc;
            data += "&hopDong=" + tenhd;
            return HttpHelper.GetList<NL_HopDong>(Configuration.UrlCBApi + "api/NhienLieus/NLGetHopDong" + data)
               .OrderBy(x => x.ID).ToList();

        }

        public IActionResult ExcelReport_Hopdong(TTHopdong request)
        {
            request.NL_HopDong = new List<NL_HopDong>();
            request.NL_HopDong = Hopdong_Napdl(request.Tenncc,request.Tenhd);
            XLWorkbook workbook = new XLWorkbook();
            DataTable dt = new DataTable();
            string fileName = string.Empty;
            List<NL_HopDong> listHopdong = request.NL_HopDong.ToList();
            dt = CoBaoDAO.ToDataTable<NL_HopDong>(listHopdong);
            fileName = "Hopdong.xlsx";
            workbook.Worksheets.Add(dt, "Sheet1");
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            MemoryStream memoryStream = new MemoryStream();
            workbook.SaveAs((Stream)memoryStream);
            memoryStream.Seek(0L, SeekOrigin.Begin);

            var content = memoryStream.ToArray();
            return File(content, contentType, fileName);
        }
        #endregion

        #region NL Giá dm
        public IActionResult Giadm()
        {
            TTGiadm request = new TTGiadm();
            string maDV = User.FindFirst(ClaimTypes.PrimarySid).Value;
            var tramList = HttpHelper.GetList<DmtramNhienLieu>(Configuration.UrlCBApi + "api/DanhMucs/GetDmtramNhienLieu");
            if (maDV != "TCT")
            {
                if (maDV == "YV")
                    tramList = tramList.Where(x => x.MaDvql == maDV || x.MaDvql == "HN").ToList();
                else if (maDV == "DN")
                    tramList = tramList.Where(x => x.MaDvql == maDV || x.MaDvql == "SG").ToList();
                else
                    tramList = tramList.Where(x => x.MaDvql == maDV).ToList();
            }
            var tramNLTT = (from ct in tramList
                            select new
                            {
                                MaTram = ct.MaTram,
                                TenTram = ct.TenTram
                            }).ToList();
            tramNLTT.Add(new { MaTram = "ALL", TenTram = "Tất cả" });
            tramNLTT = tramNLTT.OrderBy(x => x.MaTram).ToList();           
            var tramln = (from t in tramNLTT select new SelectListItem { Value = t.MaTram, Text = t.TenTram }).ToList<SelectListItem>();
            var loaidmList = HttpHelper.GetList<DMLoaiDauMo>(Configuration.UrlCBApi + "api/DanhMucs/GetDMLoaiDauMo");
            var loaiDM = (from ct in loaidmList
                          select new
                          {
                              MaDM = (short)ct.ID,
                              TenDM = ct.LoaiDauMo
                          }).ToList();

            var loaiDMTT = loaiDM.ToList();
            loaiDMTT.Add(new { MaDM = (short)-1, TenDM = "Tất cả" });
            loaiDMTT = loaiDMTT.OrderBy(f => f.MaDM).ToList();
            var loaidm = (from t in loaiDMTT select new SelectListItem { Value = t.MaDM.ToString(), Text = t.TenDM }).ToList<SelectListItem>();
            //assigning SelectListItem to view Bag
            request.Begin = DateTime.Today.AddDays(-1);
            request.End = DateTime.Today;
            ViewBag.tramln = tramln;
            ViewBag.loaidm = loaidm;
            return View(request);
        }
        [HttpPost]
        public IActionResult Giadm(TTGiadm request)
        {
            request.NL_BangGia = new List<NL_BangGia>();          
            //Creating the List of SelectListItem, this list you can bind from the database.
            string maDV = User.FindFirst(ClaimTypes.PrimarySid).Value;
            var tramList = HttpHelper.GetList<DmtramNhienLieu>(Configuration.UrlCBApi + "api/DanhMucs/GetDmtramNhienLieu");
            if (maDV != "TCT")
            {
                if (maDV == "YV")
                    tramList = tramList.Where(x => x.MaDvql == maDV || x.MaDvql == "HN").ToList();
                else if (maDV == "DN")
                    tramList = tramList.Where(x => x.MaDvql == maDV || x.MaDvql == "SG").ToList();
                else
                    tramList = tramList.Where(x => x.MaDvql == maDV).ToList();
            }
            var tramNLTT = (from ct in tramList
                            select new
                            {
                                MaTram = ct.MaTram,
                                TenTram = ct.TenTram
                            }).ToList();
            tramNLTT.Add(new { MaTram = "ALL", TenTram = "Tất cả" });
            tramNLTT = tramNLTT.OrderBy(x => x.MaTram).ToList();
            var tramln = (from t in tramNLTT select new SelectListItem { Value = t.MaTram, Text = t.TenTram }).ToList<SelectListItem>();
            var loaidmList = HttpHelper.GetList<DMLoaiDauMo>(Configuration.UrlCBApi + "api/DanhMucs/GetDMLoaiDauMo");
            var loaiDM = (from ct in loaidmList
                          select new
                          {
                              MaDM = (short)ct.ID,
                              TenDM = ct.LoaiDauMo
                          }).ToList();

            var loaiDMTT = loaiDM.ToList();
            loaiDMTT.Add(new { MaDM = (short)-1, TenDM = "Tất cả" });
            loaiDMTT = loaiDMTT.OrderBy(f => f.MaDM).ToList();
            var loaidm = (from t in loaiDMTT select new SelectListItem { Value = t.MaDM.ToString(), Text = t.TenDM }).ToList<SelectListItem>();
            //assigning SelectListItem to view Bag
            string strTram = string.Empty;
            if (request.Tramln == "ALL")
            {
                foreach (DmtramNhienLieu tr in tramList)
                {
                    strTram += tr.MaTram + ",";
                }
                strTram = strTram.Substring(0, strTram.Length - 1);
            }
            else
            {
                strTram = request.Tramln;
            }
            request.NL_BangGia = Giadm_Napdl(strTram, request);
            ViewBag.tramln = tramln;
            ViewBag.loaidm = loaidm;            
            return View(request);

        }
        private List<NL_BangGia> Giadm_Napdl(string strTram, TTGiadm request)
        {
            string data = "?maTram=" + strTram;
            data += "&maDauMo=" + request.Loaidm;
            data += "&ngayBD=" + request.Begin;
            data += "&ngayKT=" + request.End;
            return HttpHelper.GetList<NL_BangGia>(Configuration.UrlCBApi + "api/NhienLieus/NLGetBangGia" + data).OrderBy(x => x.TenTramNL).ThenBy(x => x.NgayHL).ToList();
        }

        public IActionResult ExcelReport_Giadm(TTGiadm request)
        {
            request.NL_BangGia = new List<NL_BangGia>();
            string maDV = User.FindFirst(ClaimTypes.PrimarySid).Value;
            var tramList = HttpHelper.GetList<DmtramNhienLieu>(Configuration.UrlCBApi + "api/DanhMucs/GetDmtramNhienLieu");
            if (maDV != "TCT")
            {
                if (maDV == "YV")
                    tramList = tramList.Where(x => x.MaDvql == maDV || x.MaDvql == "HN").ToList();
                else if (maDV == "DN")
                    tramList = tramList.Where(x => x.MaDvql == maDV || x.MaDvql == "SG").ToList();
                else
                    tramList = tramList.Where(x => x.MaDvql == maDV).ToList();
            }
            string strTram = string.Empty;
            if (request.Tramln == "ALL")
            {
                foreach (DmtramNhienLieu tr in tramList)
                {
                    strTram += tr.MaTram + ",";
                }
                strTram = strTram.Substring(0, strTram.Length - 1);
            }
            else
            {
                strTram = request.Tramln;
            }
            request.NL_BangGia = Giadm_Napdl(strTram, request);
            XLWorkbook workbook = new XLWorkbook();
            DataTable dt = new DataTable();
            string fileName = string.Empty;
            List<NL_BangGia> listGiadm = request.NL_BangGia.ToList();
            dt = CoBaoDAO.ToDataTable<NL_BangGia>(listGiadm);
            fileName = "Giadm.xlsx";
            workbook.Worksheets.Add(dt, "Sheet1");
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            MemoryStream memoryStream = new MemoryStream();
            workbook.SaveAs((Stream)memoryStream);
            memoryStream.Seek(0L, SeekOrigin.Begin);

            var content = memoryStream.ToArray();
            return File(content, contentType, fileName);
        }
        #endregion

        #region NL Phiếu nhập
        public IActionResult Phieunhap()
        {
            TTPhieunhap request = new TTPhieunhap();
            string maDV = User.FindFirst(ClaimTypes.PrimarySid).Value;
            var tramList = HttpHelper.GetList<DmtramNhienLieu>(Configuration.UrlCBApi + "api/DanhMucs/GetDmtramNhienLieu");
            if (maDV != "TCT")
            {
                if (maDV == "YV")
                    tramList = tramList.Where(x => x.MaDvql == maDV || x.MaDvql == "HN").ToList();
                else if (maDV == "DN")
                    tramList = tramList.Where(x => x.MaDvql == maDV || x.MaDvql == "SG").ToList();
                else
                    tramList = tramList.Where(x => x.MaDvql == maDV).ToList();
            }
            var tramNLTT = (from ct in tramList
                            select new
                            {
                                MaTram = ct.MaTram,
                                TenTram = ct.TenTram
                            }).ToList();
            tramNLTT.Add(new { MaTram = "ALL", TenTram = "Tất cả" });
            tramNLTT = tramNLTT.OrderBy(x => x.MaTram).ToList();
            var tramnl = (from t in tramNLTT select new SelectListItem { Value = t.MaTram, Text = t.TenTram }).ToList<SelectListItem>();
          
            var nhaccList = HttpHelper.GetList<NL_NhaCC>(Configuration.UrlCBApi + "api/NhienLieus/NLGetNhaCC?tenNCC=");
            var nhaCC = (from ct in nhaccList
                         select new
                          {
                              MaNCC = (short)ct.ID,
                              TenNCC = ct.TenNCC
                          }).ToList();

            var nhaCCTT = nhaCC.ToList();
            nhaCCTT.Add(new { MaNCC = (short)0, TenNCC = "Tất cả" });
            nhaCCTT = nhaCCTT.OrderBy(f => f.MaNCC).ToList();
            var nhacc = (from t in nhaCCTT select new SelectListItem { Value = t.MaNCC.ToString(), Text = t.TenNCC }).ToList<SelectListItem>();
            //assigning SelectListItem to view Bag
            request.Begin = DateTime.Today.AddDays(-1);
            request.End = DateTime.Today;
            ViewBag.tramnl = tramnl;
            ViewBag.nhacc = nhacc;
            return View(request);
        }
        [HttpPost]
        public IActionResult Phieunhap(TTPhieunhap request)
        {
            request.NL_PhieuNhap = new List<NL_PhieuNhap>();
            //Creating the List of SelectListItem, this list you can bind from the database.
            string maDV = User.FindFirst(ClaimTypes.PrimarySid).Value;
            var tramList = HttpHelper.GetList<DmtramNhienLieu>(Configuration.UrlCBApi + "api/DanhMucs/GetDmtramNhienLieu");
            if (maDV != "TCT")
            {
                if (maDV == "YV")
                    tramList = tramList.Where(x => x.MaDvql == maDV || x.MaDvql == "HN").ToList();
                else if (maDV == "DN")
                    tramList = tramList.Where(x => x.MaDvql == maDV || x.MaDvql == "SG").ToList();
                else
                    tramList = tramList.Where(x => x.MaDvql == maDV).ToList();
            }
            var tramNLTT = (from ct in tramList
                            select new
                            {
                                MaTram = ct.MaTram,
                                TenTram = ct.TenTram
                            }).ToList();
            tramNLTT.Add(new { MaTram = "ALL", TenTram = "Tất cả" });
            tramNLTT = tramNLTT.OrderBy(x => x.MaTram).ToList();
            var tramnl = (from t in tramNLTT select new SelectListItem { Value = t.MaTram, Text = t.TenTram }).ToList<SelectListItem>();

            var nhaccList = HttpHelper.GetList<NL_NhaCC>(Configuration.UrlCBApi + "api/NhienLieus/NLGetNhaCC?tenNCC=");
            var nhaCC = (from ct in nhaccList
                         select new
                         {
                             MaNCC = (short)ct.ID,
                             TenNCC = ct.TenNCC
                         }).ToList();

            var nhaCCTT = nhaCC.ToList();
            nhaCCTT.Add(new { MaNCC = (short)0, TenNCC = "Tất cả" });
            nhaCCTT = nhaCCTT.OrderBy(f => f.MaNCC).ToList();
            var nhacc = (from t in nhaCCTT select new SelectListItem { Value = t.MaNCC.ToString(), Text = t.TenNCC }).ToList<SelectListItem>();
            //assigning SelectListItem to view Bag
            string strTram = string.Empty;
            if (request.Tramnl == "ALL")
            {
                foreach (DmtramNhienLieu tr in tramList)
                {
                    strTram += tr.MaTram + ",";
                }
                strTram = strTram.Substring(0, strTram.Length - 1);
            }
            else
            {
                strTram = request.Tramnl;
            }
            request.NL_PhieuNhap = Phieunhap_Napdl(strTram, request);
            ViewBag.tramnl = tramnl;
            ViewBag.nhacc = nhacc;
            return View(request);

        }
        private List<NL_PhieuNhap> Phieunhap_Napdl(string strTram, TTPhieunhap request)
        {          
            string data = "?maTram=" + strTram;
            data += "&maNCC=" + request.Nhacc;
            data += "&maPN=" + request.Mapn;
            data += "&ngayBD=" + request.Begin;
            data += "&ngayKT=" + request.End;
            return HttpHelper.GetList<NL_PhieuNhap>(Configuration.UrlCBApi + "api/NhienLieus/NLGetPhieuNhap" + data).OrderBy(x => x.NgayNhap).ToList();
        }

        #endregion

        #region NL Phiếu nhập chi tiết       
        private NL_PhieuNhap Phieunhapct_Napdl(long id)
        {
            NL_PhieuNhap request = new NL_PhieuNhap();
            //Nạp phiếu nhập
            var pn = HttpHelper.Get<NL_PhieuNhap>(Configuration.UrlCBApi + "api/NhienLieus/NLGetPhieuNhapOBJ?id=" + id).Result;          
            request = new NL_PhieuNhap();
            request = pn;            
            return request;
        }
        public IActionResult Phieunhapct(long id)
        {
            NL_PhieuNhap request = Phieunhapct_Napdl(id);           
            return View(request);
        }
        public IActionResult PdfReport_Phieunhapct(NL_PhieuNhap request)
        {           
            return NL_PhieuNhapReport("PDF", "pdf", "application/pdf", request);
        }
        public IActionResult ExcelReport_Phieunhapct(NL_PhieuNhap request)
        {           
            return NL_PhieuNhapReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", request);
        }
        public IActionResult WordReport_Phieunhapct(NL_PhieuNhap request)
        {           
            return NL_PhieuNhapReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", request);
        }
        public IActionResult HtmlReport_Phieunhapct(NL_PhieuNhap request)
        {           
            return NL_PhieuNhapReport("HTML5", "html", "text/html", request);
        }
        private IActionResult NL_PhieuNhapReport(string renderFormat, string extension, string mimeType, NL_PhieuNhap request)
        {
            request = Phieunhapct_Napdl(request.PhieuNhapID);
            using var report = new LocalReport();
            var tramList = HttpHelper.GetList<DmtramNhienLieu>(Configuration.UrlCBApi + "api/DanhMucs/GetDmtramNhienLieu");
            string maDV = tramList.Where(x => x.MaTram == request.MaTramNL).FirstOrDefault().MaDvql;
            string tenDV = HttpHelper.GetList<DonViDM>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViDM").Where(x=>x.MaDV==maDV).FirstOrDefault().TenDV;
            long tongTien = (long)request.NL_PhieuNhapCTs.Sum(x => x.ThanhTien * x.Vat);
            string chuTien = Library.NumberToText(tongTien);
            var parameters = new[]
            {
                new  ReportParameter("prmDonvicha",tenDV),
                  new  ReportParameter("prmDonvicon","TRẠM NHIÊN LIỆU " + request.TenTramNL.ToUpper()),
                  new  ReportParameter("prmLoaibc",request.NgayNhap.ToString("HH:mm") + " Ngày " +request.NgayNhap.ToString("dd")+" tháng " + request.NgayNhap.ToString("MM") + " năm " + request.NgayNhap.ToString("yyyy")),
                   new  ReportParameter("prmCount","Tổng số gồm: " + request.NL_PhieuNhapCTs.Count +" mặt hàng"),
                   new  ReportParameter("prmChutien",chuTien)
            };
            var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptPhieuNhap.rdlc";
            report.ReportPath = path;
            report.SetParameters(parameters);
            //Nạp dữ liệu phiếu nhập
            List<NL_PhieuNhap> listPhieuNhap = new List<NL_PhieuNhap>();
            listPhieuNhap.Add(request);
            report.DataSources.Add(new ReportDataSource("PhieuNhapDS", listPhieuNhap));
            //Nạp dữ liệu phiếu nhập ct
            List<NL_PhieuNhapCT> listPhieuNhapct = new List<NL_PhieuNhapCT>();
            if (request.NL_PhieuNhapCTs != null)
                listPhieuNhapct = request.NL_PhieuNhapCTs;
            report.DataSources.Add(new ReportDataSource("PhieuNhapCTDS", listPhieuNhapct));

            var render = report.Render(renderFormat);
            return File(render, mimeType, "Phieunhap." + extension);
        }
        #endregion

        #region NL Phiếu xuất
        public IActionResult Phieuxuat()
        {
            TTPhieuxuat request = new TTPhieuxuat();
            string maDV = User.FindFirst(ClaimTypes.PrimarySid).Value;
            var tramList = HttpHelper.GetList<DmtramNhienLieu>(Configuration.UrlCBApi + "api/DanhMucs/GetDmtramNhienLieu");
            if (maDV != "TCT")
            {
                if (maDV == "YV")
                    tramList = tramList.Where(x => x.MaDvql == maDV || x.MaDvql == "HN").ToList();
                else if (maDV == "DN")
                    tramList = tramList.Where(x => x.MaDvql == maDV || x.MaDvql == "SG").ToList();
                else
                    tramList = tramList.Where(x => x.MaDvql == maDV).ToList();
            }
            var tramNLTT = (from ct in tramList
                            select new
                            {
                                MaTram = ct.MaTram,
                                TenTram = ct.TenTram
                            }).ToList();
            tramNLTT.Add(new { MaTram = "ALL", TenTram = "Tất cả" });
            tramNLTT = tramNLTT.OrderBy(x => x.MaTram).ToList();
            var tramnl = (from t in tramNLTT select new SelectListItem { Value = t.MaTram, Text = t.TenTram }).ToList<SelectListItem>();

            var loaimayList = HttpHelper.GetList<LoaiMay>(Configuration.UrlCBApi + "api/DanhMucs/GetLoaiMay");
            var loaiMayTT = (from ct in loaimayList
                             select new
                             {
                                 MaLM = ct.LoaiMayId,
                                 TenLM = ct.LoaiMayName
                             }).ToList();
            loaiMayTT.Add(new { MaLM = "ALL", TenLM = "Tất cả các loại máy" });
            loaiMayTT = loaiMayTT.OrderBy(f => f.MaLM).ToList();
            var loaimay = (from t in loaiMayTT select new SelectListItem { Value = t.MaLM, Text = t.TenLM }).ToList<SelectListItem>();
            //assigning SelectListItem to view Bag
            request.Begin = DateTime.Today.AddDays(-1);
            request.End = DateTime.Today;
            ViewBag.tramnl = tramnl;
            ViewBag.loaimay = loaimay;
            return View(request);
        }
        [HttpPost]
        public IActionResult Phieuxuat(TTPhieuxuat request)
        {
            request.NL_PhieuXuat = new List<NL_PhieuXuat>();
            //Creating the List of SelectListItem, this list you can bind from the database.
            string maDV = User.FindFirst(ClaimTypes.PrimarySid).Value;
            var tramList = HttpHelper.GetList<DmtramNhienLieu>(Configuration.UrlCBApi + "api/DanhMucs/GetDmtramNhienLieu");
            if (maDV != "TCT")
            {
                if (maDV == "YV")
                    tramList = tramList.Where(x => x.MaDvql == maDV || x.MaDvql == "HN").ToList();
                else if (maDV == "DN")
                    tramList = tramList.Where(x => x.MaDvql == maDV || x.MaDvql == "SG").ToList();
                else
                    tramList = tramList.Where(x => x.MaDvql == maDV).ToList();
            }
            var tramNLTT = (from ct in tramList
                            select new
                            {
                                MaTram = ct.MaTram,
                                TenTram = ct.TenTram
                            }).ToList();
            tramNLTT.Add(new { MaTram = "ALL", TenTram = "Tất cả" });
            tramNLTT = tramNLTT.OrderBy(x => x.MaTram).ToList();
            var tramnl = (from t in tramNLTT select new SelectListItem { Value = t.MaTram, Text = t.TenTram }).ToList<SelectListItem>();

            var loaimayList = HttpHelper.GetList<LoaiMay>(Configuration.UrlCBApi + "api/DanhMucs/GetLoaiMay");
            var loaiMayTT = (from ct in loaimayList
                             select new
                             {
                                 MaLM = ct.LoaiMayId,
                                 TenLM = ct.LoaiMayName
                             }).ToList();
            loaiMayTT.Add(new { MaLM = "ALL", TenLM = "Tất cả các loại máy" });
            loaiMayTT = loaiMayTT.OrderBy(f => f.MaLM).ToList();
            var loaimay = (from t in loaiMayTT select new SelectListItem { Value = t.MaLM, Text = t.TenLM }).ToList<SelectListItem>();
            //assigning SelectListItem to view Bag
            string strTram = string.Empty;
            if (request.Tramnl == "ALL")
            {
                foreach (DmtramNhienLieu tr in tramList)
                {
                    strTram += tr.MaTram + ",";
                }
                strTram = strTram.Substring(0, strTram.Length - 1);
            }
            else
            {
                strTram = request.Tramnl;
            }
            request.NL_PhieuXuat = Phieuxuat_Napdl(strTram, request);
            ViewBag.tramnl = tramnl;
            ViewBag.loaimay = loaimay;
            return View(request);

        }
        private List<NL_PhieuXuat> Phieuxuat_Napdl(string strTram, TTPhieuxuat request)
        {
            string data = "?maTram=" + strTram;
            data += "&loaiMay=" + request.Loaimay;
            data += "&dauMay=" + request.Daumay;
            data += "&maPX=" + request.Mapx;
            data += "&ngayBD=" + request.Begin;
            data += "&ngayKT=" + request.End;
            return HttpHelper.GetList<NL_PhieuXuat>(Configuration.UrlCBApi + "api/NhienLieus/NLGetPhieuXuat" + data).OrderBy(x => x.NgayXuat).ToList();          
        }

        #endregion

        #region NL Phiếu xuất chi tiết       
        private NL_PhieuXuat Phieuxuatct_Napdl(long id)
        {
            NL_PhieuXuat request = new NL_PhieuXuat();
            //Nạp phiếu xuất
            var px = HttpHelper.Get<NL_PhieuXuat>(Configuration.UrlCBApi + "api/NhienLieus/NLGetPhieuXuatOBJ?id=" + id).Result;
            request = new NL_PhieuXuat();
            request = px;
            return request;
        }
        public IActionResult Phieuxuatct(long id)
        {
            NL_PhieuXuat request = Phieuxuatct_Napdl(id);
            return View(request);
        }
        public IActionResult PdfReport_Phieuxuatct(NL_PhieuXuat request)
        {
            return NL_PhieuXuatReport("PDF", "pdf", "application/pdf", request);
        }
        public IActionResult ExcelReport_Phieuxuatct(NL_PhieuXuat request)
        {
            return NL_PhieuXuatReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", request);
        }
        public IActionResult WordReport_Phieuxuatct(NL_PhieuXuat request)
        {
            return NL_PhieuXuatReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", request);
        }
        public IActionResult HtmlReport_Phieuxuatct(NL_PhieuXuat request)
        {
            return NL_PhieuXuatReport("HTML5", "html", "text/html", request);
        }
        private IActionResult NL_PhieuXuatReport(string renderFormat, string extension, string mimeType, NL_PhieuXuat request)
        {
            request = Phieuxuatct_Napdl(request.PhieuXuatID);
            using var report = new LocalReport();
            var tramList = HttpHelper.GetList<DmtramNhienLieu>(Configuration.UrlCBApi + "api/DanhMucs/GetDmtramNhienLieu");
            string maDV = tramList.Where(x => x.MaTram == request.MaTramNL).FirstOrDefault().MaDvql;
            string tenDV = HttpHelper.GetList<DonViDM>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViDM").Where(x => x.MaDV == maDV).FirstOrDefault().TenDV;
            long tongTien = (long)request.NL_PhieuXuatCTs.Sum(x => x.ThanhTien);
            string chuTien = Library.NumberToText(tongTien);
            var parameters = new[]
            {
                new  ReportParameter("prmDonvicha",tenDV),
                  new  ReportParameter("prmDonvicon","TRẠM NHIÊN LIỆU " + request.TenTramNL.ToUpper()),
                  new  ReportParameter("prmLoaibc",request.NgayXuat.ToString("HH:mm") + " Ngày " +request.NgayXuat.ToString("dd")+" tháng " + request.NgayXuat.ToString("MM") + " năm " + request.NgayXuat.ToString("yyyy")),
                   new  ReportParameter("prmCount","Tổng số gồm: " + request.NL_PhieuXuatCTs.Count +" mặt hàng"),
                   new  ReportParameter("prmChutien",chuTien)
            };
            var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptPhieuXuat.rdlc";
            report.ReportPath = path;
            report.SetParameters(parameters);
            //Nạp dữ liệu phiếu xuất
            List<NL_PhieuXuat> listPhieuXuat = new List<NL_PhieuXuat>();
            listPhieuXuat.Add(request);
            report.DataSources.Add(new ReportDataSource("PhieuXuatDS", listPhieuXuat));
            //Nạp dữ liệu phiếu xuất ct
            List<NL_PhieuXuatCT> listPhieuXuatct = new List<NL_PhieuXuatCT>();
            if (request.NL_PhieuXuatCTs != null)
                listPhieuXuatct = request.NL_PhieuXuatCTs;
            report.DataSources.Add(new ReportDataSource("PhieuXuatCTDS", listPhieuXuatct));

            var render = report.Render(renderFormat);
            return File(render, mimeType, "Phieuxuat." + extension);
        }
        #endregion

        #region Hàm chung
        private List<SelectListItem> NapViewBag_Xinghiep()
        {
            string maDV = User.FindFirst(ClaimTypes.PrimarySid).Value;
            List<SelectListItem> xinghiep = new List<SelectListItem>();
            if (maDV == "HN" || maDV == "YV")
            {
                xinghiep = new List<SelectListItem>()
                {
                    new SelectListItem { Value = "HN", Text = "Đầu máy hà nội" },
                    new SelectListItem { Value = "YV", Text = "Đầu máy yên viên" },
                };
            }
            else if (maDV == "VIN")
            {
                xinghiep = new List<SelectListItem>()
                {
                    new SelectListItem { Value = "VIN", Text = "Đầu máy vinh" }
                };
            }
            else if (maDV == "DN" || maDV == "SG")
            {
                xinghiep = new List<SelectListItem>()
                {
                    new SelectListItem { Value = "DN", Text = "Đầu máy đà nẵng" },
                    new SelectListItem { Value = "SG", Text = "Đầu máy sài gòn" }
                };
            }
            else
            {
                xinghiep = new List<SelectListItem>()
                {
                    new SelectListItem { Value = "TCT", Text = "Tổng công ty" },
                    new SelectListItem { Value = "HN", Text = "Đầu máy hà nội" },
                    new SelectListItem { Value = "YV", Text = "Đầu máy yên viên" },
                    new SelectListItem { Value = "VIN", Text = "Đầu máy vinh" },
                    new SelectListItem { Value = "DN", Text = "Đầu máy đà nẵng" },
                    new SelectListItem { Value = "SG", Text = "Đầu máy sài gòn" }
                };
            }

            return xinghiep;
        }
        private List<SelectListItem> NapViewBag_Xinghiep_Thieu()
        {
            string maDV = User.FindFirst(ClaimTypes.PrimarySid).Value;
            List<SelectListItem> xinghiep = new List<SelectListItem>();
            if (maDV == "HN" || maDV == "YV")
            {
                xinghiep = new List<SelectListItem>()
                {
                    new SelectListItem { Value = "HN", Text = "Đầu máy hà nội" },
                    new SelectListItem { Value = "YV", Text = "Đầu máy yên viên" },
                };
            }
            else if (maDV == "VIN")
            {
                xinghiep = new List<SelectListItem>()
                {
                    new SelectListItem { Value = "VIN", Text = "Đầu máy vinh" }
                };
            }
            else if (maDV == "DN" || maDV == "SG")
            {
                xinghiep = new List<SelectListItem>()
                {
                    new SelectListItem { Value = "DN", Text = "Đầu máy đà nẵng" },
                    new SelectListItem { Value = "SG", Text = "Đầu máy sài gòn" }
                };
            }
            else
            {
                xinghiep = new List<SelectListItem>()
                {
                    new SelectListItem { Value = "HN", Text = "Đầu máy hà nội" },
                    new SelectListItem { Value = "YV", Text = "Đầu máy yên viên" },
                    new SelectListItem { Value = "VIN", Text = "Đầu máy vinh" },
                    new SelectListItem { Value = "DN", Text = "Đầu máy đà nẵng" },
                    new SelectListItem { Value = "SG", Text = "Đầu máy sài gòn" }
                };
            }

            return xinghiep;
        }
        private static List<SelectListItem> NapViewBag_Loaibc()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Tháng" },
                new SelectListItem { Value = "1", Text = "Quý" },
                new SelectListItem { Value = "2", Text = "Sáu tháng" },
                new SelectListItem { Value = "3", Text = "Chín tháng" },
                new SelectListItem { Value = "4", Text = "Năm" },
                new SelectListItem { Value = "5", Text = "Khác" }
            };
        }
        private static void Nap_Loaibc(string Nhombc,DateTime Begin,DateTime End, ref DateTime ngayBD, ref DateTime ngayKT, ref string loaiBC)
        {
            if (Nhombc == "0")
            {
                ngayBD = new DateTime(Begin.Year, Begin.Month, 1);
                ngayKT = new DateTime(Begin.Year, Begin.Month, DateTime.DaysInMonth(Begin.Year, Begin.Month));
                loaiBC = "Tháng " + ngayBD.Month + " năm " + ngayBD.Year;
            }
            else if (Nhombc == "1")
            {
                if (Begin.Month >= 1 && Begin.Month < 4)
                {
                    ngayBD = new DateTime(Begin.Year, 1, 1);
                    ngayKT = new DateTime(Begin.Year, 3, DateTime.DaysInMonth(Begin.Year, 3));
                    loaiBC = "Quý I năm " + ngayBD.Year;
                }
                else if (Begin.Month >= 4 && Begin.Month < 7)
                {
                    ngayBD = new DateTime(Begin.Year, 4, 1);
                    ngayKT = new DateTime(Begin.Year, 6, DateTime.DaysInMonth(Begin.Year, 6));
                    loaiBC = "Quý II năm " + ngayBD.Year;
                }
                else if (Begin.Month >= 6 && Begin.Month < 10)
                {
                    ngayBD = new DateTime(Begin.Year, 6, 1);
                    ngayKT = new DateTime(Begin.Year, 9, DateTime.DaysInMonth(Begin.Year, 9));
                    loaiBC = "Quý III năm " + ngayBD.Year;
                }
                else if (Begin.Month >= 10 && Begin.Month <= 12)
                {
                    ngayBD = new DateTime(Begin.Year, 10, 1);
                    ngayKT = new DateTime(Begin.Year, 12, DateTime.DaysInMonth(Begin.Year, 12));
                    loaiBC = "Quý IV năm " + ngayBD.Year;
                }
            }
            else if (Nhombc == "2")
            {
                if (Begin.Month >= 1 && Begin.Month < 7)
                {
                    ngayBD = new DateTime(Begin.Year, 1, 1);
                    ngayKT = new DateTime(Begin.Year, 6, DateTime.DaysInMonth(Begin.Year, 6));
                    loaiBC = "Sáu tháng đầu năm " + ngayBD.Year;
                }
                else if (Begin.Month >= 7 && Begin.Month <= 12)
                {
                    ngayBD = new DateTime(Begin.Year, 7, 1);
                    ngayKT = new DateTime(Begin.Year, 12, DateTime.DaysInMonth(Begin.Year, 12));
                    loaiBC = "Sáu tháng cuối năm " + ngayBD.Year;
                }
            }
            else if (Nhombc == "3")
            {
                if (Begin.Month >= 1 && Begin.Month < 10)
                {
                    ngayBD = new DateTime(Begin.Year, 1, 1);
                    ngayKT = new DateTime(Begin.Year, 9, DateTime.DaysInMonth(Begin.Year, 9));
                    loaiBC = "Chín tháng đầu năm " + ngayBD.Year;
                }
                else
                {
                    ngayBD = new DateTime(Begin.Year, 4, 1);
                    ngayKT = new DateTime(Begin.Year, 12, DateTime.DaysInMonth(Begin.Year, 12));
                    loaiBC = "Chín tháng cuối năm " + ngayBD.Year;
                }
            }
            else if (Nhombc == "4")
            {
                if (Begin.Month >= 1 && Begin.Month < 10)
                {
                    ngayBD = new DateTime(Begin.Year, 1, 1);
                    ngayKT = new DateTime(Begin.Year, 12, DateTime.DaysInMonth(Begin.Year, 12));
                    loaiBC = "Năm " + ngayBD.Year;
                }
            }
            else
            {
                if (Begin > End)
                {
                    ngayBD = Begin;
                    ngayKT = ngayBD;
                }
                else
                {
                    ngayBD = Begin;
                    ngayKT = End;
                }
                loaiBC = "Từ ngày " + ngayBD.ToString("dd.MM.yyyy") + " đến ngày " + ngayKT.ToString("dd.MM.yyyy");
            }
        }
        #endregion

        #region BC Nhập kho
        private void NapViewBag_BCNhapkho(BCNhapkho request)
        {
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = DateTime.Today;
            string loaiBC = string.Empty;
            if (string.IsNullOrWhiteSpace(request.Loaibc))
            {
                request.Begin = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                request.End = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
                request.Loaibc = "0";
            }
           
            Nap_Loaibc(request.Loaibc, request.Begin, request.End, ref ngayBD, ref ngayKT, ref loaiBC);
            request.Begin = ngayBD;
            request.End = ngayKT;
            request.Tenbc = loaiBC;
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep();
            List<SelectListItem> loaibc = NapViewBag_Loaibc();

            List<SelectListItem> nhombc = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Theo phiếu nhập" },
                new SelectListItem { Value = "1", Text = "Theo trạm nl" }
            };

            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.nhombc = nhombc;
            ViewBag.loaibc = loaibc;           
        }
        private void NapDuLieu_BCNhapkho(BCNhapkho request)
        {
            string maDV = request.Xinghiep;
            DateTime ngayBD = request.Begin;
            DateTime ngayKT = request.End;
            int TongSoBG = 0;
            List<NL_BCNhapKho> listTH = new List<NL_BCNhapKho>();
            //Lấy dữ liệu
            BaoCaoDAO.NapBCNhapKhoTH(maDV, ngayBD, ngayKT, ref TongSoBG, ref listTH);
                     
            request.NL_BCNhapKho = new List<NL_BCNhapKho>();
            request.NL_BCNhapKho = listTH;
        }
        public IActionResult BCNhapkho()
        {
            BCNhapkho request = new BCNhapkho();
            NapViewBag_BCNhapkho(request);
            return View(request);
        }
        [HttpPost]
        public IActionResult BCNhapkho(BCNhapkho request)
        {
            NapViewBag_BCNhapkho(request);
            NapDuLieu_BCNhapkho(request);
            return View(request);
        }
        public IActionResult PdfReport_BCNhapkho(BCNhapkho request)
        {
            NapViewBag_BCNhapkho(request);
            NapDuLieu_BCNhapkho(request);
            return BCNhapkhoReport("PDF", "pdf", "application/pdf", request);
        }
        public IActionResult ExcelReport_BCNhapkho(BCNhapkho request)
        {
            NapViewBag_BCNhapkho(request);
            NapDuLieu_BCNhapkho(request);
            return BCNhapkhoReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", request);
        }
        public IActionResult WordReport_BCNhapkho(BCNhapkho request)
        {
            NapViewBag_BCNhapkho(request);
            NapDuLieu_BCNhapkho(request);
            return BCNhapkhoReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", request);
        }
        public IActionResult HtmlReport_BCNhapkho(BCNhapkho request)
        {
            NapViewBag_BCNhapkho(request);
            NapDuLieu_BCNhapkho(request);
            return BCNhapkhoReport("HTML5", "html", "text/html", request);
        }
        private IActionResult BCNhapkhoReport(string renderFormat, string extension, string mimeType, BCNhapkho request)
        {
            using var report = new LocalReport();
            var donviDMList = HttpHelper.GetList<DonViDM>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViDM");
            var dVQL = donviDMList.Where(x => x.MaDV == request.Xinghiep).FirstOrDefault();
            string tenDV = dVQL.TenDV;
            string tenDVCha = donviDMList.Where(x => x.MaDV == dVQL.MaCha).FirstOrDefault().TenDV.ToUpper();           
            var parameters = new[]
            {
                 new  ReportParameter("prmDonvicha",tenDVCha),
                 new  ReportParameter("prmDonvicon",tenDV.ToUpper()),                  
                  new  ReportParameter("prmLoaibc",request.Tenbc),
                   new  ReportParameter("prmNgayth","Ngày "+DateTime.Today.ToString("dd")+ " tháng " + DateTime.Today.ToString("MM")+ " năm " + DateTime.Today.ToString("yyyy"))
            };
            if (request.Nhombc == "0")
            {
                var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptBCNhapKhoTH.rdlc";
                report.ReportPath = path;
            }
            else
            {
                var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptBCNhapKhoTH.rdlc";
                report.ReportPath = path;
            }
            report.SetParameters(parameters);
            report.DataSources.Add(new ReportDataSource("BaoCaoDS", request.NL_BCNhapKho));
            var render = report.Render(renderFormat);
            return File(render, mimeType, "BCNhapkho." + extension);
        }
        #endregion

        #region BC Xuất kho
        private void NapViewBag_BCXuatkho(BCXuatkho request)
        {
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = DateTime.Today;
            string loaiBC = string.Empty;
            if (string.IsNullOrWhiteSpace(request.Loaibc))
            {
                request.Begin = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                request.End = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
                request.Loaibc = "0";
            }

            Nap_Loaibc(request.Loaibc, request.Begin, request.End, ref ngayBD, ref ngayKT, ref loaiBC);
            request.Begin = ngayBD;
            request.End = ngayKT;
            request.Tenbc = loaiBC;
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep();
            List<SelectListItem> loaibc = NapViewBag_Loaibc();

            List<SelectListItem> nhombc = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Theo phiếu xuất" },
                new SelectListItem { Value = "1", Text = "Theo trạm nl" }
            };

            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.nhombc = nhombc;
            ViewBag.loaibc = loaibc;
        }
        private void NapDuLieu_BCXuatkho(BCXuatkho request)
        {
            string maDV = request.Xinghiep;
            DateTime ngayBD = request.Begin;
            DateTime ngayKT = request.End;
            int TongSoBG = 0;
            List<NL_BCXuatKho> listTH = new List<NL_BCXuatKho>();
            //Lấy dữ liệu
            BaoCaoDAO.NapBCXuatKhoTH(maDV, ngayBD, ngayKT, ref TongSoBG, ref listTH);

            request.NL_BCXuatKho = new List<NL_BCXuatKho>();
            request.NL_BCXuatKho = listTH;
        }
        public IActionResult BCXuatkho()
        {
            BCXuatkho request = new BCXuatkho();
            NapViewBag_BCXuatkho(request);
            return View(request);
        }
        [HttpPost]
        public IActionResult BCXuatkho(BCXuatkho request)
        {
            NapViewBag_BCXuatkho(request);
            NapDuLieu_BCXuatkho(request);
            return View(request);
        }
        public IActionResult PdfReport_BCXuatkho(BCXuatkho request)
        {
            NapViewBag_BCXuatkho(request);
            NapDuLieu_BCXuatkho(request);
            return BCXuatkhoReport("PDF", "pdf", "application/pdf", request);
        }
        public IActionResult ExcelReport_BCXuatkho(BCXuatkho request)
        {
            NapViewBag_BCXuatkho(request);
            NapDuLieu_BCXuatkho(request);
            return BCXuatkhoReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", request);
        }
        public IActionResult WordReport_BCXuatkho(BCXuatkho request)
        {
            NapViewBag_BCXuatkho(request);
            NapDuLieu_BCXuatkho(request);
            return BCXuatkhoReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", request);
        }
        public IActionResult HtmlReport_BCXuatkho(BCXuatkho request)
        {
            NapViewBag_BCXuatkho(request);
            NapDuLieu_BCXuatkho(request);
            return BCXuatkhoReport("HTML5", "html", "text/html", request);
        }
        private IActionResult BCXuatkhoReport(string renderFormat, string extension, string mimeType, BCXuatkho request)
        {
            using var report = new LocalReport();
            var donviDMList = HttpHelper.GetList<DonViDM>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViDM");
            var dVQL = donviDMList.Where(x => x.MaDV == request.Xinghiep).FirstOrDefault();
            string tenDV = dVQL.TenDV;
            string tenDVCha = donviDMList.Where(x => x.MaDV == dVQL.MaCha).FirstOrDefault().TenDV.ToUpper();           
            var parameters = new[]
            {
                 new  ReportParameter("prmDonvicha",tenDVCha),
                 new  ReportParameter("prmDonvicon",tenDV.ToUpper()),
                  new  ReportParameter("prmLoaibc",request.Tenbc),
                   new  ReportParameter("prmNgayth","Ngày "+DateTime.Today.ToString("dd")+ " tháng " + DateTime.Today.ToString("MM")+ " năm " + DateTime.Today.ToString("yyyy"))
            };
            if (request.Nhombc == "0")
            {
                var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptBCXuatKhoTH.rdlc";
                report.ReportPath = path;
            }
            else
            {
                var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptBCXuatKhoTH.rdlc";
                report.ReportPath = path;
            }
            report.SetParameters(parameters);
            report.DataSources.Add(new ReportDataSource("BaoCaoDS", request.NL_BCXuatKho));
            var render = report.Render(renderFormat);
            return File(render, mimeType, "BCXuatkho." + extension);
        }
        #endregion

        #region BC Thẻ kho
        private void NapViewBag_BCThekho(BCThekho request)
        {
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = DateTime.Today;
            string loaiBC = string.Empty;
            if (string.IsNullOrWhiteSpace(request.Loaibc))
            {
                request.Begin = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                request.End = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
                request.Loaibc = "0";
            }

            Nap_Loaibc(request.Loaibc, request.Begin, request.End, ref ngayBD, ref ngayKT, ref loaiBC);
            request.Begin = ngayBD;
            request.End = ngayKT;
            request.Tenbc = loaiBC;
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep();
            List<SelectListItem> loaibc = NapViewBag_Loaibc();

            string maDV = User.FindFirst(ClaimTypes.PrimarySid).Value;
            var tramList = HttpHelper.GetList<DmtramNhienLieu>(Configuration.UrlCBApi + "api/DanhMucs/GetDmtramNhienLieu");
            if (maDV != "TCT")
            {
                if (maDV == "YV")
                    tramList = tramList.Where(x => x.MaDvql == maDV || x.MaDvql == "HN").ToList();
                else if (maDV == "DN")
                    tramList = tramList.Where(x => x.MaDvql == maDV || x.MaDvql == "SG").ToList();
                else
                    tramList = tramList.Where(x => x.MaDvql == maDV).ToList();
            }
            var tramNLTT = (from ct in tramList
                            select new
                            {
                                MaTram = ct.MaTram,
                                TenTram = ct.TenTram
                            }).ToList();
            tramNLTT.Add(new { MaTram = "ALL", TenTram = "Tất cả" });
            tramNLTT = tramNLTT.OrderBy(x => x.MaTram).ToList();
            var tramnl = (from t in tramNLTT select new SelectListItem { Value = t.MaTram, Text = t.TenTram }).ToList<SelectListItem>();

            var loaidmList = HttpHelper.GetList<DMLoaiDauMo>(Configuration.UrlCBApi + "api/DanhMucs/GetDMLoaiDauMo");
            var loaiDM = (from ct in loaidmList
                          select new
                          {
                              MaDM = (short)ct.ID,
                              TenDM = ct.LoaiDauMo
                          }).ToList();

            var loaiDMTT = loaiDM.ToList();
            //loaiDMTT.Add(new { MaDM = (short)-1, TenDM = "Tất cả" });
            loaiDMTT = loaiDMTT.OrderBy(f => f.MaDM).ToList();
            var loaidm = (from t in loaiDMTT select new SelectListItem { Value = t.MaDM.ToString(), Text = t.TenDM }).ToList<SelectListItem>();
            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.tramnl = tramnl;
            ViewBag.loaidm = loaidm;
            ViewBag.loaibc = loaibc;
        }
        private void NapDuLieu_BCThekho(BCThekho request)
        {
            string maDV = request.Xinghiep;
            DateTime ngayBD = request.Begin;
            DateTime ngayKT = request.End;
            short maDauMo = short.Parse(request.Loaidm);
            string tenBC = request.Tenbc;
            int TongSoBG = 0;
            string strTram = string.Empty;
            var TramnlList = HttpHelper.GetList<DmtramNhienLieu>(Configuration.UrlCBApi + "api/DanhMucs/GetDmtramNhienLieu");
            var loaidmList = HttpHelper.GetList<DMLoaiDauMo>(Configuration.UrlCBApi + "api/DanhMucs/GetDMLoaiDauMo");
            if (request.Tramnl != "ALL")
            {
                strTram = request.Tramnl;
                tenBC += "-Trạm nl: " + TramnlList.Where(x => x.MaTram == request.Tramnl).FirstOrDefault().TenTram;
            }
            else
            {
                if (maDV != "TCT")
                {
                    if (maDV == "YV")
                        TramnlList = TramnlList.Where(x => x.MaDvql == maDV || x.MaDvql == "HN").ToList();
                    else if (maDV == "DN")
                        TramnlList = TramnlList.Where(x => x.MaDvql == maDV || x.MaDvql == "SG").ToList();
                    else
                        TramnlList = TramnlList.Where(x => x.MaDvql == maDV).ToList();
                }

                foreach (DmtramNhienLieu tr in TramnlList)
                {
                    strTram += tr.MaTram + ",";
                }
                strTram = strTram.Substring(0, strTram.Length - 1);
                tenBC += "-Trạm nl: Tất cả";
            }
            tenBC += "-Loại dầu mỡ: " + loaidmList.Where(x => x.ID == maDauMo).FirstOrDefault().LoaiDauMo;
            List<NL_BCTheKho> listTH = new List<NL_BCTheKho>();
            //Lấy dữ liệu
            BaoCaoDAO.NapBCTheKho(strTram, maDauMo, ngayBD, ngayKT, ref TongSoBG, ref listTH);

            request.NL_BCTheKho = new List<NL_BCTheKho>();
            request.NL_BCTheKho = listTH;
            request.Tenbc = tenBC;
        }
        public IActionResult BCThekho()
        {
            BCThekho request = new BCThekho();
            NapViewBag_BCThekho(request);
            return View(request);
        }
        [HttpPost]
        public IActionResult BCThekho(BCThekho request)
        {
            NapViewBag_BCThekho(request);
            NapDuLieu_BCThekho(request);
            return View(request);
        }
        public IActionResult PdfReport_BCThekho(BCThekho request)
        {
            NapViewBag_BCThekho(request);
            NapDuLieu_BCThekho(request);
            return BCThekhoReport("PDF", "pdf", "application/pdf", request);
        }
        public IActionResult ExcelReport_BCThekho(BCThekho request)
        {
            NapViewBag_BCThekho(request);
            NapDuLieu_BCThekho(request);
            return BCThekhoReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", request);
        }
        public IActionResult WordReport_BCThekho(BCThekho request)
        {
            NapViewBag_BCThekho(request);
            NapDuLieu_BCThekho(request);
            return BCThekhoReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", request);
        }
        public IActionResult HtmlReport_BCThekho(BCThekho request)
        {
            NapViewBag_BCThekho(request);
            NapDuLieu_BCThekho(request);
            return BCThekhoReport("HTML5", "html", "text/html", request);
        }
        private IActionResult BCThekhoReport(string renderFormat, string extension, string mimeType, BCThekho request)
        {
            using var report = new LocalReport();
            var donviDMList = HttpHelper.GetList<DonViDM>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViDM");
            var dVQL = donviDMList.Where(x => x.MaDV == request.Xinghiep).FirstOrDefault();
            string tenDV = dVQL.TenDV;
            string tenDVCha = donviDMList.Where(x => x.MaDV == dVQL.MaCha).FirstOrDefault().TenDV.ToUpper();           
            var parameters = new[]
            {
                 new  ReportParameter("prmDonvicha",tenDVCha),
                 new  ReportParameter("prmDonvicon",tenDV.ToUpper()),
                  new  ReportParameter("prmLoaibc",request.Tenbc),
                   new  ReportParameter("prmNgayth","Ngày "+DateTime.Today.ToString("dd")+ " tháng " + DateTime.Today.ToString("MM")+ " năm " + DateTime.Today.ToString("yyyy"))
            };
            
            var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptBCTheKho.rdlc";
            report.ReportPath = path;
            
            report.SetParameters(parameters);
            report.DataSources.Add(new ReportDataSource("BaoCaoDS", request.NL_BCTheKho));
            var render = report.Render(renderFormat);
            return File(render, mimeType, "BCThekho." + extension);
        }
        #endregion

        #region BC Tồn kho
        private void NapViewBag_BCTonkho(BCTonkho request)
        {
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = DateTime.Today;
            string loaiBC = string.Empty;
            if (string.IsNullOrWhiteSpace(request.Loaibc))
            {
                request.Begin = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                request.End = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
                request.Loaibc = "0";
            }

            Nap_Loaibc(request.Loaibc, request.Begin, request.End, ref ngayBD, ref ngayKT, ref loaiBC);
            request.Begin = ngayBD;
            request.End = ngayKT;
            request.Tenbc = loaiBC;
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep();
            List<SelectListItem> loaibc = NapViewBag_Loaibc();

            string maDV = User.FindFirst(ClaimTypes.PrimarySid).Value;
            var tramList = HttpHelper.GetList<DmtramNhienLieu>(Configuration.UrlCBApi + "api/DanhMucs/GetDmtramNhienLieu");
            if (maDV != "TCT")
            {
                if (maDV == "YV")
                    tramList = tramList.Where(x => x.MaDvql == maDV || x.MaDvql == "HN").ToList();
                else if (maDV == "DN")
                    tramList = tramList.Where(x => x.MaDvql == maDV || x.MaDvql == "SG").ToList();
                else
                    tramList = tramList.Where(x => x.MaDvql == maDV).ToList();
            }
            var tramNLTT = (from ct in tramList
                            select new
                            {
                                MaTram = ct.MaTram,
                                TenTram = ct.TenTram
                            }).ToList();
            tramNLTT.Add(new { MaTram = "ALL", TenTram = "Tất cả" });
            tramNLTT = tramNLTT.OrderBy(x => x.MaTram).ToList();
            var tramnl = (from t in tramNLTT select new SelectListItem { Value = t.MaTram, Text = t.TenTram }).ToList<SelectListItem>();

            var loaidmList = HttpHelper.GetList<DMLoaiDauMo>(Configuration.UrlCBApi + "api/DanhMucs/GetDMLoaiDauMo");
            var loaiDM = (from ct in loaidmList
                          select new
                          {
                              MaDM = (short)ct.ID,
                              TenDM = ct.LoaiDauMo
                          }).ToList();

            var loaiDMTT = loaiDM.ToList();
            loaiDMTT.Add(new { MaDM = (short)-1, TenDM = "Tất cả" });
            loaiDMTT = loaiDMTT.OrderBy(f => f.MaDM).ToList();
            var loaidm = (from t in loaiDMTT select new SelectListItem { Value = t.MaDM.ToString(), Text = t.TenDM }).ToList<SelectListItem>();
            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.tramnl = tramnl;
            ViewBag.loaidm = loaidm;
            ViewBag.loaibc = loaibc;
        }
        private void NapDuLieu_BCTonkho(BCTonkho request)
        {
            string maDV = request.Xinghiep;
            DateTime ngayBD = request.Begin;
            DateTime ngayKT = request.End;
            short maDauMo = short.Parse(request.Loaidm);
            string tenBC = request.Tenbc;
            int TongSoBG = 0;
            string strTram = string.Empty;
            var TramnlList = HttpHelper.GetList<DmtramNhienLieu>(Configuration.UrlCBApi + "api/DanhMucs/GetDmtramNhienLieu");
            var loaidmList = HttpHelper.GetList<DMLoaiDauMo>(Configuration.UrlCBApi + "api/DanhMucs/GetDMLoaiDauMo");
            if (request.Tramnl != "ALL")
            {
                strTram = request.Tramnl;
                tenBC += "-Trạm nl: " + TramnlList.Where(x => x.MaTram == request.Tramnl).FirstOrDefault().TenTram;
            }
            else
            {
                if (maDV != "TCT")
                {
                    if (maDV == "YV")
                        TramnlList = TramnlList.Where(x => x.MaDvql == maDV || x.MaDvql == "HN").ToList();
                    else if (maDV == "DN")
                        TramnlList = TramnlList.Where(x => x.MaDvql == maDV || x.MaDvql == "SG").ToList();
                    else
                        TramnlList = TramnlList.Where(x => x.MaDvql == maDV).ToList();
                }

                foreach (DmtramNhienLieu tr in TramnlList)
                {
                    strTram += tr.MaTram + ",";
                }
                strTram = strTram.Substring(0, strTram.Length - 1);
                tenBC += "-Trạm nl: Tất cả";
            }
            if(maDauMo==-1)
                tenBC += "-Loại dầu mỡ: Tất cả";
            else
                tenBC += "-Loại dầu mỡ: " + loaidmList.Where(x => x.ID == maDauMo).FirstOrDefault().LoaiDauMo;
            List<NL_BCTonKho> listTH = new List<NL_BCTonKho>();
            //Lấy dữ liệu
            BaoCaoDAO.NapBCTonKho(strTram, maDauMo, ngayBD, ngayKT, ref TongSoBG, ref listTH);

            request.NL_BCTonKho = new List<NL_BCTonKho>();
            request.NL_BCTonKho = listTH;
            request.Tenbc = tenBC;
        }
        public IActionResult BCTonkho()
        {
            BCTonkho request = new BCTonkho();
            NapViewBag_BCTonkho(request);
            return View(request);
        }
        [HttpPost]
        public IActionResult BCTonkho(BCTonkho request)
        {
            NapViewBag_BCTonkho(request);
            NapDuLieu_BCTonkho(request);
            return View(request);
        }
        public IActionResult PdfReport_BCTonkho(BCTonkho request)
        {
            NapViewBag_BCTonkho(request);
            NapDuLieu_BCTonkho(request);
            return BCTonkhoReport("PDF", "pdf", "application/pdf", request);
        }
        public IActionResult ExcelReport_BCTonkho(BCTonkho request)
        {
            NapViewBag_BCTonkho(request);
            NapDuLieu_BCTonkho(request);
            return BCTonkhoReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", request);
        }
        public IActionResult WordReport_BCTonkho(BCTonkho request)
        {
            NapViewBag_BCTonkho(request);
            NapDuLieu_BCTonkho(request);
            return BCTonkhoReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", request);
        }
        public IActionResult HtmlReport_BCTonkho(BCTonkho request)
        {
            NapViewBag_BCTonkho(request);
            NapDuLieu_BCTonkho(request);
            return BCTonkhoReport("HTML5", "html", "text/html", request);
        }
        private IActionResult BCTonkhoReport(string renderFormat, string extension, string mimeType, BCTonkho request)
        {
            using var report = new LocalReport();
            var donviDMList = HttpHelper.GetList<DonViDM>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViDM");
            var dVQL = donviDMList.Where(x => x.MaDV == request.Xinghiep).FirstOrDefault();
            string tenDV = dVQL.TenDV;
            string tenDVCha = donviDMList.Where(x => x.MaDV == dVQL.MaCha).FirstOrDefault().TenDV.ToUpper();            
            var parameters = new[]
            {
                 new  ReportParameter("prmDonvicha",tenDVCha),
                 new  ReportParameter("prmDonvicon",tenDV.ToUpper()),
                  new  ReportParameter("prmLoaibc",request.Tenbc),
                   new  ReportParameter("prmNgayth","Ngày "+DateTime.Today.ToString("dd")+ " tháng " + DateTime.Today.ToString("MM")+ " năm " + DateTime.Today.ToString("yyyy"))
            };

            var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptBCTonKho.rdlc";
            report.ReportPath = path;

            report.SetParameters(parameters);
            report.DataSources.Add(new ReportDataSource("BaoCaoDS", request.NL_BCTonKho));
            var render = report.Render(renderFormat);
            return File(render, mimeType, "BCTonkho." + extension);
        }
        #endregion
    }
}
