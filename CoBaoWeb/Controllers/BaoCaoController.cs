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
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoBaoWeb.Controllers
{
    [Authorize]
    public class BaoCaoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvirnoment;
        public BaoCaoController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvirnoment = webHostEnvironment;
        }

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
        private static List<SelectListItem> NapViewBag_Nhombc()
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
        private static void Nap_Loaibc(BCTratim request,ref DateTime ngayBD,ref DateTime ngayKT,ref string loaiBC)
        {
            if (request.Nhombc == "0")
            {
                ngayBD = new DateTime(request.Begin.Year, request.Begin.Month, 1);
                ngayKT = new DateTime(request.Begin.Year, request.Begin.Month, DateTime.DaysInMonth(request.Begin.Year, request.Begin.Month));
                loaiBC = "Tháng " + ngayBD.Month + " năm " + ngayBD.Year;
            }
            else if (request.Nhombc == "1")
            {
                if (request.Begin.Month >= 1 && request.Begin.Month < 4)
                {
                    ngayBD = new DateTime(request.Begin.Year, 1, 1);
                    ngayKT = new DateTime(request.Begin.Year, 3, DateTime.DaysInMonth(request.Begin.Year, 3));
                    loaiBC = "Quý I năm " + ngayBD.Year;
                }
                else if (request.Begin.Month >= 4 && request.Begin.Month < 7)
                {
                    ngayBD = new DateTime(request.Begin.Year, 4, 1);
                    ngayKT = new DateTime(request.Begin.Year, 6, DateTime.DaysInMonth(request.Begin.Year, 6));
                    loaiBC = "Quý II năm " + ngayBD.Year;
                }
                else if (request.Begin.Month >= 6 && request.Begin.Month < 10)
                {
                    ngayBD = new DateTime(request.Begin.Year, 6, 1);
                    ngayKT = new DateTime(request.Begin.Year, 9, DateTime.DaysInMonth(request.Begin.Year, 9));
                    loaiBC = "Quý III năm " + ngayBD.Year;
                }
                else if (request.Begin.Month >= 10 && request.Begin.Month <= 12)
                {
                    ngayBD = new DateTime(request.Begin.Year, 10, 1);
                    ngayKT = new DateTime(request.Begin.Year, 12, DateTime.DaysInMonth(request.Begin.Year, 12));
                    loaiBC = "Quý IV năm " + ngayBD.Year;
                }
            }
            else if (request.Nhombc == "2")
            {
                if (request.Begin.Month >= 1 && request.Begin.Month < 7)
                {
                    ngayBD = new DateTime(request.Begin.Year, 1, 1);
                    ngayKT = new DateTime(request.Begin.Year, 6, DateTime.DaysInMonth(request.Begin.Year, 6));
                    loaiBC = "Sáu tháng đầu năm " + ngayBD.Year;
                }
                else if (request.Begin.Month >= 7 && request.Begin.Month <= 12)
                {
                    ngayBD = new DateTime(request.Begin.Year, 7, 1);
                    ngayKT = new DateTime(request.Begin.Year, 12, DateTime.DaysInMonth(request.Begin.Year, 12));
                    loaiBC = "Sáu tháng cuối năm " + ngayBD.Year;
                }
            }
            else if (request.Nhombc == "3")
            {
                if (request.Begin.Month >= 1 && request.Begin.Month < 10)
                {
                    ngayBD = new DateTime(request.Begin.Year, 1, 1);
                    ngayKT = new DateTime(request.Begin.Year, 9, DateTime.DaysInMonth(request.Begin.Year, 9));
                    loaiBC = "Chín tháng đầu năm " + ngayBD.Year;
                }
                else
                {
                    ngayBD = new DateTime(request.Begin.Year, 4, 1);
                    ngayKT = new DateTime(request.Begin.Year, 12, DateTime.DaysInMonth(request.Begin.Year, 12));
                    loaiBC = "Chín tháng cuối năm " + ngayBD.Year;
                }
            }
            else if (request.Nhombc == "4")
            {
                if (request.Begin.Month >= 1 && request.Begin.Month < 10)
                {
                    ngayBD = new DateTime(request.Begin.Year, 1, 1);
                    ngayKT = new DateTime(request.Begin.Year, 12, DateTime.DaysInMonth(request.Begin.Year, 12));
                    loaiBC = "Năm " + ngayBD.Year;
                }
            }
            else
            {
                if (request.Begin > request.End)
                {
                    ngayBD = request.Begin;
                    ngayKT = ngayBD;
                }
                else
                {
                    ngayBD = request.Begin;
                    ngayKT = request.End;
                }
                loaiBC = "Từ ngày " + ngayBD.ToString("dd.MM.yyyy") + " đến ngày " + ngayKT.ToString("dd.MM.yyyy");
            }
        }
        #endregion

        #region Vận dụng
        private void NapViewBag_Vandung(BCVandung request)
        {
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = DateTime.Today;
            string loaiBC = string.Empty;
            if (request.BCTratim != null)
            {
                Nap_Loaibc(request.BCTratim, ref ngayBD, ref ngayKT, ref loaiBC);
            }
            else
            {
                request.BCTratim = new BCTratim();
                loaiBC = "Tháng " + ngayBD.Month + " năm " + ngayBD.Year;
            }    
            request.BCTratim.Begin = ngayBD;
            request.BCTratim.End = ngayKT;
            request.BCTratim.Loaibc = loaiBC;
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep();
            List<SelectListItem> nhombc = NapViewBag_Nhombc();
            var tuyenList = HttpHelper.GetList<TuyenMap>(Configuration.UrlCBApi + "api/DanhMucs/GetTuyenMap");
            tuyenList.Add(new TuyenMap() { TuyenId = (short)0, TuyenName = "Tất cả các tuyến" });
            tuyenList = tuyenList.OrderBy(f => f.TuyenId).ToList();
            var tuyen = (from t in tuyenList select new SelectListItem { Value = t.TuyenId.ToString(), Text = t.TuyenName }).ToList<SelectListItem>();

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

            List<SelectListItem> nguon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Cơ báo điện tử" },
                new SelectListItem { Value = "1", Text = "Cơ báo điện giấy" },
            };
            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.nhombc = nhombc;
            ViewBag.tuyen = tuyen;
            ViewBag.loaimay = loaimay;
            ViewBag.nguon = nguon;
        }
        private void NapDuLieu_Vandung(BCVandung request)
        {
            string maDV = request.BCTratim.Xinghiep;
            string loaiMay = request.BCTratim.Loaimay;
            short tuyenTT = short.Parse(request.BCTratim.Tuyen.ToString());
            string strTuyen = "ALL";
            int nguonDL = int.Parse(request.BCTratim.Nguon.ToString());
            if (tuyenTT > 0)
            {
                strTuyen = string.Empty;
                var listTuyen = HttpHelper.GetList<Tuyen>(Configuration.UrlCBApi + "api/DanhMucs/GetTuyen").Where(x => x.TuyenMap == tuyenTT).ToList();
                foreach (Tuyen dm in listTuyen)
                {
                    strTuyen += dm.TuyenID + ",";
                }
                strTuyen = strTuyen.Substring(0, strTuyen.Length - 1);
            }

            int TongSoBG = 0;
            List<BCVanDungInfo> listVD = new List<BCVanDungInfo>();
            //Lấy dữ liệu
            BaoCaoDAO.NapBCVanDung(nguonDL, maDV, int.Parse(request.BCTratim.Nhombc), request.BCTratim.Begin, request.BCTratim.End, loaiMay, strTuyen, ref TongSoBG, ref listVD);
            request.BCVanDungInfo= new List<BCVanDungInfo>();
            request.BCVanDungInfo = listVD;
        }       
        public IActionResult Vandung()
        {
            BCVandung request = new BCVandung();
            NapViewBag_Vandung(request);
            return View(request);
        }
        [HttpPost]
        public IActionResult Vandung(BCVandung request)
        {
            NapViewBag_Vandung(request);
            NapDuLieu_Vandung(request);
            return View(request);
        }
        public IActionResult PdfReport_Vandung(BCVandung request)
        {
            NapViewBag_Vandung(request);
            NapDuLieu_Vandung(request);
            return VandungReport("PDF", "pdf", "application/pdf", request);
        }
        public IActionResult ExcelReport_Vandung(BCVandung request)
        {
            NapViewBag_Vandung(request);
            NapDuLieu_Vandung(request);
            return VandungReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", request);
        }
        public IActionResult WordReport_Vandung(BCVandung request)
        {
            NapViewBag_Vandung(request);
            NapDuLieu_Vandung(request);
            return VandungReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", request);
        }
        public IActionResult HtmlReport_Vandung(BCVandung request)
        {
            NapViewBag_Vandung(request);
            NapDuLieu_Vandung(request);
            return VandungReport("HTML5", "html", "text/html", request);
        }
        private IActionResult VandungReport(string renderFormat, string extension, string mimeType, BCVandung request)
        { 
            using var report = new LocalReport();
            string maDV = User.FindFirst(ClaimTypes.PrimarySid).Value;
            var donviDMList = HttpHelper.GetList<DonViDM>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViDM");
            var dVQL = donviDMList.Where(x => x.MaDV == request.BCTratim.Xinghiep).FirstOrDefault();
            string tenDV = dVQL.TenDV;
            string tenDVCha = donviDMList.Where(x => x.MaDV == dVQL.MaCha).FirstOrDefault().TenDV.ToUpper();            

            string strLoaiDM = "Loại đầu máy: " + request.BCTratim.Loaimay;
            request.BCTratim.Loaibc += " - " + tenDV;

            if (short.Parse(request.BCTratim.Tuyen.ToString()) > 0)
            {
                string tuyenName = HttpHelper.GetList<TuyenMap>(Configuration.UrlCBApi + "api/DanhMucs/GetTuyenMap").Where(x => x.TuyenId == short.Parse(request.BCTratim.Tuyen.ToString())).FirstOrDefault().TuyenName;
                strLoaiDM += " - Tuyến: " + tuyenName;
            }

            var parameters = new[]
            {
                 new  ReportParameter("prmDonvicha",tenDVCha),
                 new  ReportParameter("prmDonvicon",tenDV.ToUpper()),
                 new  ReportParameter("prmSocv","Số:................/BC-ĐM."),
                 new  ReportParameter("prmNhombc",strLoaiDM),
                  new  ReportParameter("prmLoaibc",request.BCTratim.Loaibc),
                   new  ReportParameter("prmKhachtn","Khách thống nhất"),
                    new  ReportParameter("prmKhachdp","Khách địa phương"),
                     new  ReportParameter("prmNgayth","Ngày " + DateTime.Today.ToString("dd") + " tháng " + DateTime.Today.ToString("MM") + " năm " + DateTime.Today.ToString("yyyy")),
                      new  ReportParameter("prmLapbieu","NGƯỜI LẬP BIỂU"),
                      new  ReportParameter("prmPhongban","PHÒNG KẾ HOẠCH VẬT TƯ"),
                      new  ReportParameter("prmGiamdoc","GIÁM ĐỐC"),
                      new  ReportParameter("prmNguoilb"," "),
                      new  ReportParameter("prmNguoipb"," "),
                       new  ReportParameter("prmNguoigd"," ")
            };
            var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptVanDung.rdlc";
            report.ReportPath = path;
            report.SetParameters(parameters);
            report.DataSources.Add(new ReportDataSource("BaoCaoDS", request.BCVanDungInfo));
            var render = report.Render(renderFormat);
            return File(render, mimeType, "Vandung." + extension);
        }
        #endregion

        #region Chỉ tiêu KTKT
        private void NapViewBag_Chitieuktkt(BCChitieuktkt request)
        {
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = DateTime.Today;
            string loaiBC = string.Empty;
            if (request.BCTratim != null)
            {
                Nap_Loaibc(request.BCTratim, ref ngayBD, ref ngayKT, ref loaiBC);
            }
            else
            {
                request.BCTratim = new BCTratim();
                loaiBC = "Tháng " + ngayBD.Month + " năm " + ngayBD.Year;
            }
            request.BCTratim.Begin = ngayBD;
            request.BCTratim.End = ngayKT;
            request.BCTratim.Loaibc = loaiBC;
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep();
            List<SelectListItem> nhombc = NapViewBag_Nhombc();
            var tuyenList = HttpHelper.GetList<TuyenMap>(Configuration.UrlCBApi + "api/DanhMucs/GetTuyenMap");
            tuyenList.Add(new TuyenMap() { TuyenId = (short)0, TuyenName = "Tất cả các tuyến" });
            tuyenList = tuyenList.OrderBy(f => f.TuyenId).ToList();
            var tuyen = (from t in tuyenList select new SelectListItem { Value = t.TuyenId.ToString(), Text = t.TuyenName }).ToList<SelectListItem>();

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

            List<SelectListItem> nguon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Cơ báo điện tử" },
                new SelectListItem { Value = "1", Text = "Cơ báo điện giấy" },
            };
            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.nhombc = nhombc;
            ViewBag.tuyen = tuyen;
            ViewBag.loaimay = loaimay;
            ViewBag.nguon = nguon;
        }
        private void NapDuLieu_Chitieuktkt(BCChitieuktkt request)
        {
            string maDV = request.BCTratim.Xinghiep;
            string loaiMay = request.BCTratim.Loaimay;
            short tuyenTT = short.Parse(request.BCTratim.Tuyen.ToString());
            string strTuyen = "ALL";
            int nguonDL = int.Parse(request.BCTratim.Nguon.ToString());
            if (tuyenTT > 0)
            {
                strTuyen = string.Empty;
                var listTuyen = HttpHelper.GetList<Tuyen>(Configuration.UrlCBApi + "api/DanhMucs/GetTuyen").Where(x => x.TuyenMap == tuyenTT).ToList();
                foreach (Tuyen dm in listTuyen)
                {
                    strTuyen += dm.TuyenID + ",";
                }
                strTuyen = strTuyen.Substring(0, strTuyen.Length - 1);
            }

            int TongSoBG = 0;
            List<BCKTKTXNInfo> listXN = new List<BCKTKTXNInfo>();
            List<BCKTKTTHInfo> listTH = new List<BCKTKTTHInfo>();
            if (maDV == "TCT" || maDV == "UB")
            {
                //Lấy dữ liệu
                BaoCaoDAO.NapBCKTKTTH(nguonDL, maDV, int.Parse(request.BCTratim.Nhombc), request.BCTratim.Begin, request.BCTratim.End, loaiMay, strTuyen, ref TongSoBG, ref listTH);
                request.BCKTKTTHInfo = new List<BCKTKTTHInfo>();
                request.BCKTKTTHInfo = listTH;
            }
            else
            {
                //Lấy dữ liệu
                BaoCaoDAO.NapBCKTKTXN(nguonDL, maDV, int.Parse(request.BCTratim.Nhombc), request.BCTratim.Begin, request.BCTratim.End, loaiMay, strTuyen, ref TongSoBG, ref listXN);
                request.BCKTKTXNInfo = new List<BCKTKTXNInfo>();
                request.BCKTKTXNInfo = listXN;
            }
        }
        public IActionResult Chitieuktkt()
        {
            BCChitieuktkt request = new BCChitieuktkt();
            NapViewBag_Chitieuktkt(request);
            return View(request);
        }
        [HttpPost]
        public IActionResult Chitieuktkt(BCChitieuktkt request)
        {
            NapViewBag_Chitieuktkt(request);
            NapDuLieu_Chitieuktkt(request);
            return View(request);
        }
        public IActionResult PdfReport_Chitieuktkt(BCChitieuktkt request)
        {
            NapViewBag_Chitieuktkt(request);
            NapDuLieu_Chitieuktkt(request);
            return ChitieuktktReport("PDF", "pdf", "application/pdf", request);
        }
        public IActionResult ExcelReport_Chitieuktkt(BCChitieuktkt request)
        {
            NapViewBag_Chitieuktkt(request);
            NapDuLieu_Chitieuktkt(request);
            return ChitieuktktReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", request);
        }
        public IActionResult WordReport_Chitieuktkt(BCChitieuktkt request)
        {
            NapViewBag_Chitieuktkt(request);
            NapDuLieu_Chitieuktkt(request);
            return ChitieuktktReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", request);
        }
        public IActionResult HtmlReport_Chitieuktkt(BCChitieuktkt request)
        {
            NapViewBag_Chitieuktkt(request);
            NapDuLieu_Chitieuktkt(request);
            return ChitieuktktReport("HTML5", "html", "text/html", request);
        }
        private IActionResult ChitieuktktReport(string renderFormat, string extension, string mimeType, BCChitieuktkt request)
        {
            using var report = new LocalReport();          
            var donviDMList = HttpHelper.GetList<DonViDM>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViDM");
            var dVQL = donviDMList.Where(x => x.MaDV == request.BCTratim.Xinghiep).FirstOrDefault();
            string tenDV = dVQL.TenDV;
            string tenDVCha = donviDMList.Where(x => x.MaDV == dVQL.MaCha).FirstOrDefault().TenDV.ToUpper();          

            string strLoaiDM = "Loại đầu máy: " + request.BCTratim.Loaimay;
            request.BCTratim.Loaibc += " - " + tenDV;

            if (short.Parse(request.BCTratim.Tuyen.ToString()) > 0)
            {
                string tuyenName = HttpHelper.GetList<TuyenMap>(Configuration.UrlCBApi + "api/DanhMucs/GetTuyenMap").Where(x => x.TuyenId == short.Parse(request.BCTratim.Tuyen.ToString())).FirstOrDefault().TuyenName;
                strLoaiDM += " - Tuyến: " + tuyenName;
            }

            var parameters = new[]
            {
                 new  ReportParameter("prmDonvicha",tenDVCha),
                 new  ReportParameter("prmDonvicon",tenDV.ToUpper()),
                 new  ReportParameter("prmSocv","Số:................/BC-ĐM."),
                 new  ReportParameter("prmNhombc",strLoaiDM),
                  new  ReportParameter("prmLoaibc",request.BCTratim.Loaibc),                  
                     new  ReportParameter("prmNgayth","Ngày " + DateTime.Today.ToString("dd") + " tháng " + DateTime.Today.ToString("MM") + " năm " + DateTime.Today.ToString("yyyy")),
                      new  ReportParameter("prmLapbieu","NGƯỜI LẬP BIỂU"),
                      new  ReportParameter("prmPhongban","PHÒNG KẾ HOẠCH VẬT TƯ"),
                      new  ReportParameter("prmGiamdoc","GIÁM ĐỐC"),
                      new  ReportParameter("prmNguoilb"," "),
                      new  ReportParameter("prmNguoipb"," "),
                       new  ReportParameter("prmNguoigd"," ")
            };
            if (request.BCTratim.Xinghiep == "TCT" || request.BCTratim.Xinghiep == "UB")
            {
                var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptKTKTTH.rdlc";
                report.ReportPath = path;
            }
            else
            {
                var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptKTKTXN.rdlc";
                report.ReportPath = path;
            }    
            report.SetParameters(parameters);
            if (request.BCTratim.Xinghiep == "TCT" || request.BCTratim.Xinghiep == "UB")
            {
                report.DataSources.Add(new ReportDataSource("BaoCaoDS", request.BCKTKTTHInfo));
            }
            else
            {
                report.DataSources.Add(new ReportDataSource("BaoCaoDS", request.BCKTKTXNInfo));
            }    
            var render = report.Render(renderFormat);
            return File(render, mimeType, "Chitieuktkt." + extension);
        }
        #endregion

        #region TH Giờ dồn
        private void NapViewBag_THGiodon(BCTHGiodon request)
        {
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = DateTime.Today;
            string loaiBC = string.Empty;
            if (request.BCTratim != null)
            {
                Nap_Loaibc(request.BCTratim, ref ngayBD, ref ngayKT, ref loaiBC);
            }
            else
            {
                request.BCTratim = new BCTratim();
                loaiBC = "Tháng " + ngayBD.Month + " năm " + ngayBD.Year;
            }
            request.BCTratim.Begin = ngayBD;
            request.BCTratim.End = ngayKT;
            request.BCTratim.Loaibc = loaiBC;
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep();
            List<SelectListItem> nhombc = NapViewBag_Nhombc();
            List<SelectListItem> loaidon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Tất cả" },
                new SelectListItem { Value = "1", Text = "Chuyên dồn" },
                new SelectListItem { Value = "2", Text = "Kiêm dồn" },
            };

            List<SelectListItem> nguon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Cơ báo điện tử" },
                new SelectListItem { Value = "1", Text = "Cơ báo điện giấy" },
            };
            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.nhombc = nhombc;
            ViewBag.loaidon = loaidon;           
            ViewBag.nguon = nguon;
        }
        private void NapDuLieu_THGiodon(BCTHGiodon request)
        {
            string maDV = request.BCTratim.Xinghiep;
            int loaiDon = int.Parse(request.BCTratim.Loaidon.ToString());
            int nguonDL = int.Parse(request.BCTratim.Nguon.ToString());           
            int TongSoBG = 0;
            List<BCGioDonInfo> listDon = new List<BCGioDonInfo>();
            //Lấy dữ liệu
            BaoCaoDAO.NapBCGioDon(nguonDL, maDV, loaiDon, int.Parse(request.BCTratim.Nhombc), request.BCTratim.Begin, request.BCTratim.End, ref TongSoBG, ref listDon);           
            request.BCGioDonInfo = new List<BCGioDonInfo>();
            request.BCGioDonInfo = listDon;
        }
        public IActionResult THGiodon()
        {
            BCTHGiodon request = new BCTHGiodon();
            NapViewBag_THGiodon(request);
            return View(request);
        }
        [HttpPost]
        public IActionResult THGiodon(BCTHGiodon request)
        {
            NapViewBag_THGiodon(request);
            NapDuLieu_THGiodon(request);
            return View(request);
        }
        public IActionResult PdfReport_THGiodon(BCTHGiodon request)
        {
            NapViewBag_THGiodon(request);
            NapDuLieu_THGiodon(request);
            return THGiodonReport("PDF", "pdf", "application/pdf", request);
        }
        public IActionResult ExcelReport_THGiodon(BCTHGiodon request)
        {
            NapViewBag_THGiodon(request);
            NapDuLieu_THGiodon(request);
            return THGiodonReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", request);
        }
        public IActionResult WordReport_THGiodon(BCTHGiodon request)
        {
            NapViewBag_THGiodon(request);
            NapDuLieu_THGiodon(request);
            return THGiodonReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", request);
        }
        public IActionResult HtmlReport_THGiodon(BCTHGiodon request)
        {
            NapViewBag_THGiodon(request);
            NapDuLieu_THGiodon(request);
            return THGiodonReport("HTML5", "html", "text/html", request);
        }
        private IActionResult THGiodonReport(string renderFormat, string extension, string mimeType, BCTHGiodon request)
        {
            using var report = new LocalReport();           
            var donviDMList = HttpHelper.GetList<DonViDM>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViDM");
            var dVQL = donviDMList.Where(x => x.MaDV == request.BCTratim.Xinghiep).FirstOrDefault();
            string tenDV = dVQL.TenDV.ToUpper();
            string tenDVCha = donviDMList.Where(x => x.MaDV == dVQL.MaCha).FirstOrDefault().TenDV.ToUpper();          
            string strLoaiDM = " ";
            var parameters = new[]
            {
                 new  ReportParameter("prmDonvicha",tenDVCha),
                 new  ReportParameter("prmDonvicon",tenDV),
                 new  ReportParameter("prmSocv","Số:................/BC-ĐM."),
                 new  ReportParameter("prmNhombc",strLoaiDM),
                  new  ReportParameter("prmLoaibc",request.BCTratim.Loaibc),                  
                     new  ReportParameter("prmNgayth","Ngày " + DateTime.Today.ToString("dd") + " tháng " + DateTime.Today.ToString("MM") + " năm " + DateTime.Today.ToString("yyyy")),
                      new  ReportParameter("prmLapbieu","NGƯỜI LẬP BIỂU"),
                      new  ReportParameter("prmPhongban","PHÒNG KẾ HOẠCH VẬT TƯ"),
                      new  ReportParameter("prmGiamdoc","GIÁM ĐỐC"),
                      new  ReportParameter("prmNguoilb"," "),
                      new  ReportParameter("prmNguoipb"," "),
                       new  ReportParameter("prmNguoigd"," ")
            };
            var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptGioDon.rdlc";
            report.ReportPath = path;
            report.SetParameters(parameters);
            report.DataSources.Add(new ReportDataSource("BaoCaoDS", request.BCGioDonInfo));
            var render = report.Render(renderFormat);
            return File(render, mimeType, "THGiodon." + extension);
        }
        #endregion

        #region CT Giờ dồn
        private void NapViewBag_CTGiodon(BCCTGiodon request)
        {
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = DateTime.Today;
            string loaiBC = string.Empty;
            if (request.BCTratim != null)
            {
                Nap_Loaibc(request.BCTratim, ref ngayBD, ref ngayKT, ref loaiBC);
            }
            else
            {
                request.BCTratim = new BCTratim();
                loaiBC = "Tháng " + ngayBD.Month + " năm " + ngayBD.Year;
            }
            request.BCTratim.Begin = ngayBD;
            request.BCTratim.End = ngayKT;
            request.BCTratim.Loaibc = loaiBC;
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep();
            List<SelectListItem> nhombc = NapViewBag_Nhombc();
            List<SelectListItem> loaidon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Tất cả" },
                new SelectListItem { Value = "1", Text = "Chuyên dồn" },
                new SelectListItem { Value = "2", Text = "Kiêm dồn" },
            };

            List<SelectListItem> nguon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Cơ báo điện tử" },
                new SelectListItem { Value = "1", Text = "Cơ báo điện giấy" },
            };

            var DonviKTList = HttpHelper.GetList<DonViKT>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViKT");
            var listKT = (from x in DonviKTList group x by new { x.MaDVCha } into g select new { TenDVCha = g.Key.MaDVCha }).ToList();
            List<SelectListItem> chinhanh = new List<SelectListItem>()
            {
                new SelectListItem { Value = "Tất cả", Text = "Tất cả" }
            };           
            foreach (var kt in listKT)
            {
                chinhanh.Add(new SelectListItem { Value = kt.TenDVCha, Text = kt.TenDVCha });               
            }
            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.nhombc = nhombc;
            ViewBag.chinhanh = chinhanh;
            ViewBag.nguon = nguon;
        }
        private void NapDuLieu_CTGiodon(BCCTGiodon request)
        {
            string maDV = request.BCTratim.Xinghiep;            
            int nguonDL = int.Parse(request.BCTratim.Nguon.ToString());
            var DonviKTList = HttpHelper.GetList<DonViKT>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViKT");
            int TongSoBG = 0;
            List<BCCTGioDonInfo> listDon = new List<BCCTGioDonInfo>();
            //Lấy dữ liệu
            BaoCaoDAO.NapBCCTGioDon(nguonDL, maDV, request.BCTratim.chinhanh, int.Parse(request.BCTratim.Nhombc), request.BCTratim.Begin, request.BCTratim.End, DonviKTList, ref TongSoBG, ref listDon);           
            request.BCCTGioDonInfo = new List<BCCTGioDonInfo>();
            request.BCCTGioDonInfo = listDon;
        }
        public IActionResult CTGiodon()
        {
            BCCTGiodon request = new BCCTGiodon();
            NapViewBag_CTGiodon(request);
            return View(request);
        }
        [HttpPost]
        public IActionResult CTGiodon(BCCTGiodon request)
        {
            NapViewBag_CTGiodon(request);
            NapDuLieu_CTGiodon(request);
            return View(request);
        }
        public IActionResult PdfReport_CTGiodon(BCCTGiodon request)
        {
            NapViewBag_CTGiodon(request);
            NapDuLieu_CTGiodon(request);
            return CTGiodonReport("PDF", "pdf", "application/pdf", request);
        }
        public IActionResult ExcelReport_CTGiodon(BCCTGiodon request)
        {
            NapViewBag_CTGiodon(request);
            NapDuLieu_CTGiodon(request);
            return CTGiodonReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", request);
        }
        public IActionResult WordReport_CTGiodon(BCCTGiodon request)
        {
            NapViewBag_CTGiodon(request);
            NapDuLieu_CTGiodon(request);
            return CTGiodonReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", request);
        }
        public IActionResult HtmlReport_CTGiodon(BCCTGiodon request)
        {
            NapViewBag_CTGiodon(request);
            NapDuLieu_CTGiodon(request);
            return CTGiodonReport("HTML5", "html", "text/html", request);
        }
        private IActionResult CTGiodonReport(string renderFormat, string extension, string mimeType, BCCTGiodon request)
        {
            using var report = new LocalReport();           
            var donviDMList = HttpHelper.GetList<DonViDM>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViDM");
            var dVQL = donviDMList.Where(x => x.MaDV == request.BCTratim.Xinghiep).FirstOrDefault();
            string tenDV = dVQL.TenDV.ToUpper();
            string tenDVCha = donviDMList.Where(x => x.MaDV == dVQL.MaCha).FirstOrDefault().TenDV.ToUpper();          
           
            var parameters = new[]
            {
                 new  ReportParameter("prmDonvicha",tenDVCha),
                 new  ReportParameter("prmDonvicon",tenDV),
                 new  ReportParameter("prmSocv","Số:................/BC-ĐM."),                
                  new  ReportParameter("prmLoaibc",request.BCTratim.Loaibc),
                     new  ReportParameter("prmNgayth","Ngày " + DateTime.Today.ToString("dd") + " tháng " + DateTime.Today.ToString("MM") + " năm " + DateTime.Today.ToString("yyyy")),
                      new  ReportParameter("prmLapbieu","NGƯỜI LẬP BIỂU"),
                      new  ReportParameter("prmPhongban","PHÒNG KẾ HOẠCH VẬT TƯ"),
                      new  ReportParameter("prmGiamdoc","GIÁM ĐỐC"),
                      new  ReportParameter("prmNguoilb"," "),
                      new  ReportParameter("prmNguoipb"," "),
                       new  ReportParameter("prmNguoigd"," ")
            };
            var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptGioDonCT.rdlc";
            report.ReportPath = path;
            report.SetParameters(parameters);
            report.DataSources.Add(new ReportDataSource("BaoCaoDS", request.BCCTGioDonInfo));
            var render = report.Render(renderFormat);
            return File(render, mimeType, "CTGiodon." + extension);
        }
        #endregion

        #region SPTN Thực hiện
        private void NapViewBag_SPTNThuchien(BCSPTNThuchien request)
        {
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = DateTime.Today;
            string loaiBC = string.Empty;
            if (request.BCTratim != null)
            {
                Nap_Loaibc(request.BCTratim, ref ngayBD, ref ngayKT, ref loaiBC);
            }
            else
            {
                request.BCTratim = new BCTratim();
                loaiBC = "Tháng " + ngayBD.Month + " năm " + ngayBD.Year;
            }
            request.BCTratim.Begin = ngayBD;
            request.BCTratim.End = ngayKT;
            request.BCTratim.Loaibc = loaiBC;            
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep();
            List<SelectListItem> nhombc = NapViewBag_Nhombc();           

            List<SelectListItem> nguon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Cơ báo điện tử" },
                new SelectListItem { Value = "1", Text = "Cơ báo điện giấy" },
            };
           
            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.nhombc = nhombc;           
            ViewBag.nguon = nguon;
        }
        private void NapDuLieu_SPTNThuchien(BCSPTNThuchien request)
        {
            string maDV = request.BCTratim.Xinghiep;
            int nguonDL = int.Parse(request.BCTratim.Nguon.ToString());           
            int TongSoBG = 0;
            List<BCTHSPTNInfo> listTH = new List<BCTHSPTNInfo>();
            //Lấy dữ liệu
            BaoCaoDAO.NapBCTHSPTN(nguonDL, maDV, int.Parse(request.BCTratim.Nhombc), request.BCTratim.Begin, request.BCTratim.End, ref TongSoBG, ref listTH);
            listTH = listTH.OrderBy(x => x.MaCT).ThenBy(x => x.MaLM).ToList();
            request.BCTHSPTNInfo = new List<BCTHSPTNInfo>();
            request.BCTHSPTNInfo = listTH;
        }
        public IActionResult SPTNThuchien()
        {
            BCSPTNThuchien request = new BCSPTNThuchien();
            NapViewBag_SPTNThuchien(request);
            return View(request);
        }
        [HttpPost]
        public IActionResult SPTNThuchien(BCSPTNThuchien request)
        {
            NapViewBag_SPTNThuchien(request);
            NapDuLieu_SPTNThuchien(request);
            return View(request);
        }
        public IActionResult PdfReport_SPTNThuchien(BCSPTNThuchien request)
        {
            NapViewBag_SPTNThuchien(request);
            NapDuLieu_SPTNThuchien(request);
            return SPTNThuchienReport("PDF", "pdf", "application/pdf", request);
        }
        public IActionResult ExcelReport_SPTNThuchien(BCSPTNThuchien request)
        {
            NapViewBag_SPTNThuchien(request);
            NapDuLieu_SPTNThuchien(request);
            return SPTNThuchienReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", request);
        }
        public IActionResult WordReport_SPTNThuchien(BCSPTNThuchien request)
        {
            NapViewBag_SPTNThuchien(request);
            NapDuLieu_SPTNThuchien(request);
            return SPTNThuchienReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", request);
        }
        public IActionResult HtmlReport_SPTNThuchien(BCSPTNThuchien request)
        {
            NapViewBag_SPTNThuchien(request);
            NapDuLieu_SPTNThuchien(request);
            return SPTNThuchienReport("HTML5", "html", "text/html", request);
        }
        private IActionResult SPTNThuchienReport(string renderFormat, string extension, string mimeType, BCSPTNThuchien request)
        {
            using var report = new LocalReport();           
            var donviDMList = HttpHelper.GetList<DonViDM>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViDM");
            var dVQL = donviDMList.Where(x => x.MaDV == request.BCTratim.Xinghiep).FirstOrDefault();
            string tenDV = dVQL.TenDV.ToUpper();
            string tenDVCha = donviDMList.Where(x => x.MaDV == dVQL.MaCha).FirstOrDefault().TenDV.ToUpper();
            var parameters = new[]
            {
                 new  ReportParameter("prmDonvicha",tenDVCha),
                 new  ReportParameter("prmDonvicon",tenDV),
                  new  ReportParameter("prmNhombc",tenDV),
                  new  ReportParameter("prmLoaibc",request.BCTratim.Loaibc)                    
            };
            var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptTHSPTN.rdlc";
            report.ReportPath = path;
            report.SetParameters(parameters);
            report.DataSources.Add(new ReportDataSource("BaoCaoDS", request.BCTHSPTNInfo));
            var render = report.Render(renderFormat);
            return File(render, mimeType, "SPTNThuchien." + extension);
        }
        #endregion

        #region NL Thực hiện
        private void NapViewBag_NLThuchien(BCNLThuchien request)
        {
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = DateTime.Today;
            string loaiBC = string.Empty;
            if (request.BCTratim != null)
            {
                Nap_Loaibc(request.BCTratim, ref ngayBD, ref ngayKT, ref loaiBC);
            }
            else
            {
                request.BCTratim = new BCTratim();
                loaiBC = "Tháng " + ngayBD.Month + " năm " + ngayBD.Year;
            }
            request.BCTratim.Begin = ngayBD;
            request.BCTratim.End = ngayKT;
            request.BCTratim.Loaibc = loaiBC;
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep();
            List<SelectListItem> nhombc = NapViewBag_Nhombc();

            List<SelectListItem> nguon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Cơ báo điện tử" },
                new SelectListItem { Value = "1", Text = "Cơ báo điện giấy" },
            };

            var tuyenList = HttpHelper.GetList<TuyenMap>(Configuration.UrlCBApi + "api/DanhMucs/GetTuyenMap");
            tuyenList.Add(new TuyenMap() { TuyenId = (short)0, TuyenName = "Tất cả các tuyến" });
            tuyenList = tuyenList.OrderBy(f => f.TuyenId).ToList();
            var tuyen = (from t in tuyenList select new SelectListItem { Value = t.TuyenId.ToString(), Text = t.TuyenName }).ToList<SelectListItem>();

            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.nhombc = nhombc;
            ViewBag.nguon = nguon;
            ViewBag.tuyen = tuyen;
        }
        private void NapDuLieu_NLThuchien(BCNLThuchien request)
        {
            string maDV = request.BCTratim.Xinghiep;
            int nguonDL = int.Parse(request.BCTratim.Nguon.ToString());
            short tuyenTT = short.Parse(request.BCTratim.Tuyen.ToString());
            string strTuyen = "ALL";            
            if (tuyenTT > 0)
            {
                strTuyen = string.Empty;
                var listTuyen = HttpHelper.GetList<Tuyen>(Configuration.UrlCBApi + "api/DanhMucs/GetTuyen").Where(x => x.TuyenMap == tuyenTT).ToList();
                foreach (Tuyen dm in listTuyen)
                {
                    strTuyen += dm.TuyenID + ",";
                }
                strTuyen = strTuyen.Substring(0, strTuyen.Length - 1);
            }
            int TongSoBG = 0;
            List<BCTHNLInfo> listTH = new List<BCTHNLInfo>();
            //Lấy dữ liệu
            BaoCaoDAO.NapBCTHNL(nguonDL, maDV, int.Parse(request.BCTratim.Nhombc), request.BCTratim.Begin, request.BCTratim.End,strTuyen, ref TongSoBG, ref listTH);           
            request.BCTHNLInfo = new List<BCTHNLInfo>();
            request.BCTHNLInfo = listTH;
        }
        public IActionResult NLThuchien()
        {
            BCNLThuchien request = new BCNLThuchien();
            NapViewBag_NLThuchien(request);
            return View(request);
        }
        [HttpPost]
        public IActionResult NLThuchien(BCNLThuchien request)
        {
            NapViewBag_NLThuchien(request);
            NapDuLieu_NLThuchien(request);
            return View(request);
        }
        public IActionResult PdfReport_NLThuchien(BCNLThuchien request)
        {
            NapViewBag_NLThuchien(request);
            NapDuLieu_NLThuchien(request);
            return NLThuchienReport("PDF", "pdf", "application/pdf", request);
        }
        public IActionResult ExcelReport_NLThuchien(BCNLThuchien request)
        {
            NapViewBag_NLThuchien(request);
            NapDuLieu_NLThuchien(request);
            return NLThuchienReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", request);
        }
        public IActionResult WordReport_NLThuchien(BCNLThuchien request)
        {
            NapViewBag_NLThuchien(request);
            NapDuLieu_NLThuchien(request);
            return NLThuchienReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", request);
        }
        public IActionResult HtmlReport_NLThuchien(BCNLThuchien request)
        {
            NapViewBag_NLThuchien(request);
            NapDuLieu_NLThuchien(request);
            return NLThuchienReport("HTML5", "html", "text/html", request);
        }
        private IActionResult NLThuchienReport(string renderFormat, string extension, string mimeType, BCNLThuchien request)
        {
            using var report = new LocalReport();         
            var donviDMList = HttpHelper.GetList<DonViDM>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViDM");
            var dVQL = donviDMList.Where(x => x.MaDV == request.BCTratim.Xinghiep).FirstOrDefault();
            string tenDV = dVQL.TenDV.ToUpper();
            string tenDVCha = donviDMList.Where(x => x.MaDV == dVQL.MaCha).FirstOrDefault().TenDV.ToUpper();            
            string strLoaiDM = "Tuyến: ";
            string tenBC = "Thực hiện định mức và chênh lệch nhiên liệu chạy tầu " + request.BCTratim.Loaibc;

            if (short.Parse(request.BCTratim.Tuyen.ToString()) > 0)
            {
                string tuyenName = HttpHelper.GetList<TuyenMap>(Configuration.UrlCBApi + "api/DanhMucs/GetTuyenMap").Where(x => x.TuyenId == short.Parse(request.BCTratim.Tuyen.ToString())).FirstOrDefault().TuyenName;
                strLoaiDM += tuyenName;
            }

            var parameters = new[]
            {
                 new  ReportParameter("prmDonvicha",tenDVCha),
                 new  ReportParameter("prmDonvicon",tenDV),
                 new  ReportParameter("prmSocv","Số:................/BC-ĐM."),
                 new  ReportParameter("prmNhombc",strLoaiDM),
                  new  ReportParameter("prmLoaibc",tenBC),
                   new  ReportParameter("prmNgaytct","................,Ngày     tháng      năm " + DateTime.Today.ToString("yyyy")),
                    new  ReportParameter("prmNgayxn","................,Ngày     tháng      năm " + DateTime.Today.ToString("yyyy")),
                     new  ReportParameter("prmTongct",tenDVCha),
                      new  ReportParameter("prmXinghiep",tenDV),
                      new  ReportParameter("prmNguoitct"," "),
                      new  ReportParameter("prmNguoixn"," ")                     
            };
            var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptThucHienNL.rdlc";
            report.ReportPath = path;
            report.SetParameters(parameters);
            report.DataSources.Add(new ReportDataSource("BaoCaoDS", request.BCTHNLInfo));
            var render = report.Render(renderFormat);
            return File(render, mimeType, "NLThuchien." + extension);
        }
        #endregion

        #region NL Thành tích
        private void NapViewBag_NLThanhtich(BCNLThanhtich request)
        {
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = DateTime.Today;
            string loaiBC = string.Empty;
            if (request.BCTratim != null)
            {
                Nap_Loaibc(request.BCTratim, ref ngayBD, ref ngayKT, ref loaiBC);
            }
            else
            {
                request.BCTratim = new BCTratim();
                loaiBC = "Tháng " + ngayBD.Month + " năm " + ngayBD.Year;
            }
            request.BCTratim.Begin = ngayBD;
            request.BCTratim.End = ngayKT;
            request.BCTratim.Loaibc = loaiBC;
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep();
            List<SelectListItem> nhombc = NapViewBag_Nhombc();

            List<SelectListItem> nguon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Cơ báo điện tử" },
                new SelectListItem { Value = "1", Text = "Cơ báo điện giấy" },
            };

            List<SelectListItem> loaidon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Theo công tác" },
                new SelectListItem { Value = "1", Text = "Theo loại máy" },
                new SelectListItem { Value = "2", Text = "Theo tài xế" }
            };

            var tuyenList = HttpHelper.GetList<TuyenMap>(Configuration.UrlCBApi + "api/DanhMucs/GetTuyenMap");
            tuyenList.Add(new TuyenMap() { TuyenId = (short)0, TuyenName = "Tất cả các tuyến" });
            tuyenList = tuyenList.OrderBy(f => f.TuyenId).ToList();
            var tuyen = (from t in tuyenList select new SelectListItem { Value = t.TuyenId.ToString(), Text = t.TuyenName }).ToList<SelectListItem>();

            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.nhombc = nhombc;
            ViewBag.nguon = nguon;
            ViewBag.tuyen = tuyen;
            ViewBag.loaidon = loaidon;
        }
        private void NapDuLieu_NLThanhtich(BCNLThanhtich request)
        {
            string maDV = request.BCTratim.Xinghiep;
            int nguonDL = int.Parse(request.BCTratim.Nguon.ToString());
            int loaiDon = int.Parse(request.BCTratim.Loaidon.ToString());
            short tuyenTT = short.Parse(request.BCTratim.Tuyen.ToString());
            string strTuyen = "ALL";
            if (tuyenTT > 0)
            {
                strTuyen = string.Empty;
                var listTuyen = HttpHelper.GetList<Tuyen>(Configuration.UrlCBApi + "api/DanhMucs/GetTuyen").Where(x => x.TuyenMap == tuyenTT).ToList();
                foreach (Tuyen dm in listTuyen)
                {
                    strTuyen += dm.TuyenID + ",";
                }
                strTuyen = strTuyen.Substring(0, strTuyen.Length - 1);
            }
            int TongSoBG = 0;
            List<BCTTNLInfo> listNL = new List<BCTTNLInfo>();
            List<BCTTDMInfo> listDM = new List<BCTTDMInfo>();
            List<BCTTTXInfo> listTX = new List<BCTTTXInfo>();
            //Lấy dữ liệu
            if (loaiDon == 0)
            {
                BaoCaoDAO.NapBCTTNL(nguonDL, maDV, int.Parse(request.BCTratim.Nhombc), request.BCTratim.Begin, request.BCTratim.End, strTuyen, ref TongSoBG, ref listNL);
                request.BCTTNLInfo = new List<BCTTNLInfo>();
                request.BCTTNLInfo = listNL;
            }
            else if (loaiDon == 1)
            {
                BaoCaoDAO.NapBCTTDM(nguonDL, maDV, int.Parse(request.BCTratim.Nhombc), request.BCTratim.Begin, request.BCTratim.End, strTuyen, ref TongSoBG, ref listDM);
                request.BCTTDMInfo = new List<BCTTDMInfo>();
                request.BCTTDMInfo = listDM;
            }
            else
            {
                BaoCaoDAO.NapBCTTTX(nguonDL, maDV, int.Parse(request.BCTratim.Nhombc), request.BCTratim.Begin, request.BCTratim.End, ref TongSoBG, ref listTX);
                request.BCTTTXInfo = new List<BCTTTXInfo>();
                request.BCTTTXInfo = listTX;
            }
        }
        public IActionResult NLThanhtich()
        {
            BCNLThanhtich request = new BCNLThanhtich();
            NapViewBag_NLThanhtich(request);
            return View(request);
        }
        [HttpPost]
        public IActionResult NLThanhtich(BCNLThanhtich request)
        {
            NapViewBag_NLThanhtich(request);
            NapDuLieu_NLThanhtich(request);
            return View(request);
        }
        public IActionResult PdfReport_NLThanhtich(BCNLThanhtich request)
        {
            NapViewBag_NLThanhtich(request);
            NapDuLieu_NLThanhtich(request);
            return NLThanhtichReport("PDF", "pdf", "application/pdf", request);
        }
        public IActionResult ExcelReport_NLThanhtich(BCNLThanhtich request)
        {
            NapViewBag_NLThanhtich(request);
            NapDuLieu_NLThanhtich(request);
            return NLThanhtichReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", request);
        }
        public IActionResult WordReport_NLThanhtich(BCNLThanhtich request)
        {
            NapViewBag_NLThanhtich(request);
            NapDuLieu_NLThanhtich(request);
            return NLThanhtichReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", request);
        }
        public IActionResult HtmlReport_NLThanhtich(BCNLThanhtich request)
        {
            NapViewBag_NLThanhtich(request);
            NapDuLieu_NLThanhtich(request);
            return NLThanhtichReport("HTML5", "html", "text/html", request);
        }
        private IActionResult NLThanhtichReport(string renderFormat, string extension, string mimeType, BCNLThanhtich request)
        {
            using var report = new LocalReport();
            var donviDMList = HttpHelper.GetList<DonViDM>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViDM");
            var dVQL = donviDMList.Where(x => x.MaDV == request.BCTratim.Xinghiep).FirstOrDefault();
            string tenDV = dVQL.TenDV.ToUpper();
            string tenDVCha = donviDMList.Where(x => x.MaDV == dVQL.MaCha).FirstOrDefault().TenDV.ToUpper();
            string strLoaiDM = "Tuyến: ";
            string tenBC = "Thực hiện định mức và chênh lệch nhiên liệu chạy tầu " + request.BCTratim.Loaibc;

            if (short.Parse(request.BCTratim.Tuyen.ToString()) > 0)
            {
                string tuyenName = HttpHelper.GetList<TuyenMap>(Configuration.UrlCBApi + "api/DanhMucs/GetTuyenMap").Where(x => x.TuyenId == short.Parse(request.BCTratim.Tuyen.ToString())).FirstOrDefault().TuyenName;
                strLoaiDM += tuyenName;
            }

            var parameters = new[]
            {
                 new  ReportParameter("prmDonvicha",tenDVCha),
                 new  ReportParameter("prmDonvicon",tenDV),
                 new  ReportParameter("prmSocv","Số:................/BC-ĐM."),
                 new  ReportParameter("prmNhombc",strLoaiDM),
                  new  ReportParameter("prmLoaibc",tenBC),
                   new  ReportParameter("prmNgayth","................,Ngày     tháng      năm " + DateTime.Today.ToString("yyyy")),
                    new  ReportParameter("prmLapbieu","NGƯỜI LẬP BIỂU"),
                     new  ReportParameter("prmPhongban","PHÒNG BAN"),
                      new  ReportParameter("prmGiamdoc","GIÁM ĐỐC"),
                      new  ReportParameter("prmNguoilb"," "),
                      new  ReportParameter("prmNguoipb"," "),
                      new  ReportParameter("prmNguoigd"," ")
            };

            if (request.BCTratim.Loaidon=="0")
            {
                var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptThanhTichNL.rdlc";
                report.ReportPath = path;
            }
            else if (request.BCTratim.Loaidon == "1")
            {
                var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptThanhTichDM.rdlc";
                report.ReportPath = path;
            }
            else
            {
                var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptThanhTichTX.rdlc";
                report.ReportPath = path;
            }
            report.SetParameters(parameters);
            if (request.BCTratim.Loaidon == "0")
            {
                report.DataSources.Add(new ReportDataSource("BaoCaoDS", request.BCTTNLInfo));
            }
            else if (request.BCTratim.Loaidon == "1")
            {
                report.DataSources.Add(new ReportDataSource("BaoCaoDS", request.BCTTDMInfo));
            }
            else
            {
                report.DataSources.Add(new ReportDataSource("BaoCaoDS", request.BCTTTXInfo));
            }
            var render = report.Render(renderFormat);
            return File(render, mimeType, "NLThanhtich." + extension);
        }
        #endregion

        #region SPTN Đối chiếu
        private void NapViewBag_SPTNDoichieu(BCSPTNDoichieu request)
        {
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = DateTime.Today;
            string loaiBC = string.Empty;
            if (request.BCTratim != null)
            {
                Nap_Loaibc(request.BCTratim, ref ngayBD, ref ngayKT, ref loaiBC);
            }
            else
            {
                request.BCTratim = new BCTratim();
                loaiBC = "Tháng " + ngayBD.Month + " năm " + ngayBD.Year;
            }
            request.BCTratim.Begin = ngayBD;
            request.BCTratim.End = ngayKT;
            request.BCTratim.Loaibc = loaiBC;
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep_Thieu();
            List<SelectListItem> nhombc = NapViewBag_Nhombc();

            List<SelectListItem> nguon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Cơ báo điện tử" },
                new SelectListItem { Value = "1", Text = "Cơ báo điện giấy" },
            };

            List<SelectListItem> loaidon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Theo cơ báo" },
                new SelectListItem { Value = "1", Text = "Theo đầu máy" }                
            };

            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.nhombc = nhombc;
            ViewBag.nguon = nguon;
            ViewBag.loaidon = loaidon;
        }
        private void NapDuLieu_SPTNDoichieu(BCSPTNDoichieu request)
        {
            string maDV = request.BCTratim.Xinghiep;
            int nguonDL = int.Parse(request.BCTratim.Nguon.ToString());
            int loaiDon = int.Parse(request.BCTratim.Loaidon.ToString());
            int TongSoBG = 0;
            List<BCDCSPTNInfo> list = new List<BCDCSPTNInfo>();
            //Lấy dữ liệu          
            if (loaiDon == 0)
                BaoCaoDAO.NapBCDCSPTNKT(nguonDL, maDV, int.Parse(request.BCTratim.Nhombc), request.BCTratim.Begin, request.BCTratim.End, ref TongSoBG, ref list);
            else
                BaoCaoDAO.NapBCDCSPTNQL(nguonDL, maDV, int.Parse(request.BCTratim.Nhombc), request.BCTratim.Begin, request.BCTratim.End, ref TongSoBG, ref list);
            request.BCDCSPTNInfo = new List<BCDCSPTNInfo>();
            request.BCDCSPTNInfo = list;
        }
        public IActionResult SPTNDoichieu()
        {
            BCSPTNDoichieu request = new BCSPTNDoichieu();
            NapViewBag_SPTNDoichieu(request);
            return View(request);
        }
        [HttpPost]
        public IActionResult SPTNDoichieu(BCSPTNDoichieu request)
        {
            NapViewBag_SPTNDoichieu(request);
            NapDuLieu_SPTNDoichieu(request);
            return View(request);
        }
        public IActionResult PdfReport_SPTNDoichieu(BCSPTNDoichieu request)
        {
            NapViewBag_SPTNDoichieu(request);
            NapDuLieu_SPTNDoichieu(request);
            return SPTNDoichieuReport("PDF", "pdf", "application/pdf", request);
        }
        public IActionResult ExcelReport_SPTNDoichieu(BCSPTNDoichieu request)
        {
            NapViewBag_SPTNDoichieu(request);
            NapDuLieu_SPTNDoichieu(request);
            return SPTNDoichieuReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", request);
        }
        public IActionResult WordReport_SPTNDoichieu(BCSPTNDoichieu request)
        {
            NapViewBag_SPTNDoichieu(request);
            NapDuLieu_SPTNDoichieu(request);
            return SPTNDoichieuReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", request);
        }
        public IActionResult HtmlReport_SPTNDoichieu(BCSPTNDoichieu request)
        {
            NapViewBag_SPTNDoichieu(request);
            NapDuLieu_SPTNDoichieu(request);
            return SPTNDoichieuReport("HTML5", "html", "text/html", request);
        }
        private IActionResult SPTNDoichieuReport(string renderFormat, string extension, string mimeType, BCSPTNDoichieu request)
        {
            using var report = new LocalReport();
            var donviDMList = HttpHelper.GetList<DonViDM>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViDM");
            var dVQL = donviDMList.Where(x => x.MaDV == request.BCTratim.Xinghiep).FirstOrDefault();
            string tenDV = dVQL.TenDV;
            string tenDVCha = donviDMList.Where(x => x.MaDV == dVQL.MaCha).FirstOrDefault().TenDV.ToUpper();
            string tenBC = "giữa tổng công ty đường sắt việt nam và " + tenDV;
            var parameters = new[]
            {
                 new  ReportParameter("prmDonvicha",tenDVCha),
                 new  ReportParameter("prmDonvicon",tenDV.ToUpper()),
                  new  ReportParameter("prmNhombc",tenBC.ToUpper()),
                  new  ReportParameter("prmLoaibc",request.BCTratim.Loaibc),
                   new  ReportParameter("prmNgaytct","................,Ngày     tháng      năm " + DateTime.Today.ToString("yyyy")),
                    new  ReportParameter("prmNgayxn","................,Ngày     tháng      năm " + DateTime.Today.ToString("yyyy")),
                     new  ReportParameter("prmTongct",tenDVCha),
                      new  ReportParameter("prmXinghiep",tenDV.ToUpper()),
                       new  ReportParameter("prmNguoitct"," "),
                        new  ReportParameter("prmNguoixn"," ")
            };
            if (request.BCTratim.Loaidon == "0")
            {
                var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptTacNghiepKT.rdlc";
                report.ReportPath = path;
            }           
            else
            {
                var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptTacNghiepQL.rdlc";
                report.ReportPath = path;
            }
            report.SetParameters(parameters);
            report.DataSources.Add(new ReportDataSource("BaoCaoDS", request.BCDCSPTNInfo));           
            var render = report.Render(renderFormat);
            return File(render, mimeType, "SPTNDoichieu." + extension);
        }
        #endregion

        #region Dầu mỡ
        private void NapViewBag_Daumo(BCDaumo request)
        {
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = DateTime.Today;
            string loaiBC = string.Empty;
            if (request.BCTratim != null)
            {
                Nap_Loaibc(request.BCTratim, ref ngayBD, ref ngayKT, ref loaiBC);
            }
            else
            {
                request.BCTratim = new BCTratim();
                loaiBC = "Tháng " + ngayBD.Month + " năm " + ngayBD.Year;
            }
            request.BCTratim.Begin = ngayBD;
            request.BCTratim.End = ngayKT;
            request.BCTratim.Loaibc = loaiBC;
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep();
            List<SelectListItem> nhombc = NapViewBag_Nhombc();

            List<SelectListItem> nguon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Cơ báo điện tử" },
                new SelectListItem { Value = "1", Text = "Cơ báo điện giấy" },
            };

            var DMLoaidmList = HttpHelper.GetList<DMLoaiDauMo>(Configuration.UrlCBApi + "api/DanhMucs/GetDMLoaiDauMo");
            var loaidmTT = (from ct in DMLoaidmList
                            select new
                            {
                                MaDM = (short)ct.ID,
                                TenDM = ct.LoaiDauMo
                            }).ToList();
            loaidmTT.Add(new { MaDM = (short)-1, TenDM = "Tồn nhiên liệu" });
            loaidmTT = loaidmTT.OrderBy(f => f.MaDM).ToList();
            var loaidon = (from t in loaidmTT select new SelectListItem { Value = t.MaDM.ToString(), Text = t.TenDM }).ToList<SelectListItem>();

            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.nhombc = nhombc;
            ViewBag.nguon = nguon;           
            ViewBag.loaidon = loaidon;
        }
        private void NapDuLieu_Daumo(BCDaumo request)
        {
            string maDV = request.BCTratim.Xinghiep;
            int nguonDL = int.Parse(request.BCTratim.Nguon.ToString());
            short loaiDon = short.Parse(request.BCTratim.Loaidon.ToString());           
            int TongSoBG = 0;          
            //Lấy dữ liệu           
            if (loaiDon == -1)
            {
                List<BCTonNLInfo> listTonNL = new List<BCTonNLInfo>();
                BaoCaoDAO.NapBCTonNL(nguonDL, maDV, request.BCTratim.Begin.Month, request.BCTratim.End.Month, request.BCTratim.End.Year, ref TongSoBG, ref listTonNL);
                request.BCTonNLInfo = new List<BCTonNLInfo>();
                request.BCTonNLInfo = listTonNL;
            }
            else
            {
                List<BKDauMoInfo> listBKDauMo = new List<BKDauMoInfo>();
                BaoCaoDAO.NapBCBKDauMo(nguonDL, loaiDon, maDV, request.BCTratim.Begin.Month, request.BCTratim.End.Month, request.BCTratim.End.Year, ref TongSoBG, ref listBKDauMo);
                request.BKDauMoInfo = new List<BKDauMoInfo>();
                request.BKDauMoInfo = listBKDauMo;
            }           
        }
        public IActionResult Daumo()
        {
            BCDaumo request = new BCDaumo();
            NapViewBag_Daumo(request);
            return View(request);
        }
        [HttpPost]
        public IActionResult Daumo(BCDaumo request)
        {
            NapViewBag_Daumo(request);
            NapDuLieu_Daumo(request);
            return View(request);
        }
        public IActionResult PdfReport_Daumo(BCDaumo request)
        {
            NapViewBag_Daumo(request);
            NapDuLieu_Daumo(request);
            return DaumoReport("PDF", "pdf", "application/pdf", request);
        }
        public IActionResult ExcelReport_Daumo(BCDaumo request)
        {
            NapViewBag_Daumo(request);
            NapDuLieu_Daumo(request);
            return DaumoReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", request);
        }
        public IActionResult WordReport_Daumo(BCDaumo request)
        {
            NapViewBag_Daumo(request);
            NapDuLieu_Daumo(request);
            return DaumoReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", request);
        }
        public IActionResult HtmlReport_Daumo(BCDaumo request)
        {
            NapViewBag_Daumo(request);
            NapDuLieu_Daumo(request);
            return DaumoReport("HTML5", "html", "text/html", request);
        }
        private IActionResult DaumoReport(string renderFormat, string extension, string mimeType, BCDaumo request)
        {
            using var report = new LocalReport();
            var donviDMList = HttpHelper.GetList<DonViDM>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViDM");
            var dVQL = donviDMList.Where(x => x.MaDV == request.BCTratim.Xinghiep).FirstOrDefault();
            string tenDV = dVQL.TenDV;
            string tenDVCha = donviDMList.Where(x => x.MaDV == dVQL.MaCha).FirstOrDefault().TenDV.ToUpper();
            string tenDM=request.BCTratim.Loaidon=="-1"? "Tồn nhiên liệu": HttpHelper.GetList<DMLoaiDauMo>(Configuration.UrlCBApi + "api/DanhMucs/GetDMLoaiDauMo").Where(x=>x.ID==short.Parse(request.BCTratim.Loaidon)).FirstOrDefault().LoaiDauMo;
            string strNhombc = "Đơn vị: " + tenDV + "-Loại báo cáo: " + tenDM;          
            var parameters = new[]
            {
                 new  ReportParameter("prmDonvicha",tenDVCha),
                 new  ReportParameter("prmDonvicon",tenDV),
                 new  ReportParameter("prmSocv","Số:................/BC-ĐM."),
                 new  ReportParameter("prmNhombc",strNhombc),
                  new  ReportParameter("prmLoaibc",request.BCTratim.Loaibc),
                   new  ReportParameter("prmNgayth","................,Ngày     tháng      năm " + DateTime.Today.ToString("yyyy")),
                    new  ReportParameter("prmLapbieu","NGƯỜI LẬP BIỂU"),
                     new  ReportParameter("prmPhongban","PHÒNG BAN"),
                      new  ReportParameter("prmGiamdoc","GIÁM ĐỐC"),
                      new  ReportParameter("prmNguoilb"," "),
                      new  ReportParameter("prmNguoipb"," "),
                      new  ReportParameter("prmNguoigd"," ")
            };

            if (request.BCTratim.Loaidon == "-1")
            {
                var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptTonNL.rdlc";
                report.ReportPath = path;
            }
           
            else
            {
                var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptBKDauMo.rdlc";
                report.ReportPath = path;
            }
            report.SetParameters(parameters);
            if (request.BCTratim.Loaidon == "-1")
            {
                report.DataSources.Add(new ReportDataSource("BaoCaoDS", request.BCTonNLInfo));
            }           
            else
            {
                report.DataSources.Add(new ReportDataSource("BaoCaoDS", request.BKDauMoInfo));
            }
            var render = report.Render(renderFormat);
            return File(render, mimeType, "Daumo." + extension);
        }
        #endregion

        #region Tính lương
        private void NapViewBag_Tinhluong(BCTinhluong request)
        {
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = DateTime.Today;
            string loaiBC = string.Empty;
            if (request.BCTratim != null)
            {
                Nap_Loaibc(request.BCTratim, ref ngayBD, ref ngayKT, ref loaiBC);
            }
            else
            {
                request.BCTratim = new BCTratim();
                loaiBC = "Tháng " + ngayBD.Month + " năm " + ngayBD.Year;
            }
            request.BCTratim.Begin = ngayBD;
            request.BCTratim.End = ngayKT;
            request.BCTratim.Loaibc = loaiBC;
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep_Thieu();
            List<SelectListItem> nhombc = NapViewBag_Nhombc();           

            List<SelectListItem> nguon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Cơ báo điện tử" },
                new SelectListItem { Value = "1", Text = "Cơ báo điện giấy" },
            };
            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.nhombc = nhombc;           
            ViewBag.nguon = nguon;
        }
        private void NapDuLieu_Tinhluong(BCTinhluong request)
        {
            string maDV = request.BCTratim.Xinghiep;           
            int nguonDL = int.Parse(request.BCTratim.Nguon.ToString());
            int TongSoBG = 0;
            List<BKTinhLuongInfo> listBK = new List<BKTinhLuongInfo>();
            //Lấy dữ liệu
            BaoCaoDAO.BKTinhLuong(nguonDL, maDV, int.Parse(request.BCTratim.Nhombc), request.BCTratim.Begin, request.BCTratim.End, ref TongSoBG, ref listBK);
            request.BKTinhLuongInfo = new List<BKTinhLuongInfo>();
            request.BKTinhLuongInfo = listBK;
        }
        public IActionResult Tinhluong()
        {
            BCTinhluong request = new BCTinhluong();
            NapViewBag_Tinhluong(request);
            return View(request);
        }
        [HttpPost]
        public IActionResult Tinhluong(BCTinhluong request)
        {
            NapViewBag_Tinhluong(request);
            NapDuLieu_Tinhluong(request);
            return View(request);
        }
        public IActionResult PdfReport_Tinhluong(BCTinhluong request)
        {
            NapViewBag_Tinhluong(request);
            NapDuLieu_Tinhluong(request);
            return TinhluongReport("PDF", "pdf", "application/pdf", request);
        }
        public IActionResult ExcelReport_Tinhluong(BCTinhluong request)
        {
            NapViewBag_Tinhluong(request);
            NapDuLieu_Tinhluong(request);
            return TinhluongReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", request);
        }
        public IActionResult WordReport_Tinhluong(BCTinhluong request)
        {
            NapViewBag_Tinhluong(request);
            NapDuLieu_Tinhluong(request);
            return TinhluongReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", request);
        }
        public IActionResult HtmlReport_Tinhluong(BCTinhluong request)
        {
            NapViewBag_Tinhluong(request);
            NapDuLieu_Tinhluong(request);
            return TinhluongReport("HTML5", "html", "text/html", request);
        }
        private IActionResult TinhluongReport(string renderFormat, string extension, string mimeType, BCTinhluong request)
        {
            using var report = new LocalReport();
            var donviDMList = HttpHelper.GetList<DonViDM>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViDM");
            var dVQL = donviDMList.Where(x => x.MaDV == request.BCTratim.Xinghiep).FirstOrDefault();
            string tenDV = dVQL.TenDV.ToUpper();
            string tenDVCha = donviDMList.Where(x => x.MaDV == dVQL.MaCha).FirstOrDefault().TenDV.ToUpper();           
            var parameters = new[]
            {
                 new  ReportParameter("prmDonvicha",tenDVCha),
                 new  ReportParameter("prmDonvicon",tenDV),                               
                  new  ReportParameter("prmLoaibc",request.BCTratim.Loaibc),
                     new  ReportParameter("prmNgayth","Ngày " + DateTime.Today.ToString("dd") + " tháng " + DateTime.Today.ToString("MM") + " năm " + DateTime.Today.ToString("yyyy")),
                      new  ReportParameter("prmLapbieu","NGƯỜI LẬP BIỂU"),
                      new  ReportParameter("prmPhongban","PHÒNG KẾ HOẠCH VẬT TƯ"),
                      new  ReportParameter("prmGiamdoc","GIÁM ĐỐC"),
                      new  ReportParameter("prmNguoilb"," "),
                      new  ReportParameter("prmNguoipb"," "),
                       new  ReportParameter("prmNguoigd"," ")
            };
            var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptBKTinhLuong.rdlc";
            report.ReportPath = path;
            report.SetParameters(parameters);
            report.DataSources.Add(new ReportDataSource("BaoCaoDS", request.BKTinhLuongInfo));
            var render = report.Render(renderFormat);
            return File(render, mimeType, "Tinhluong." + extension);
        }
        #endregion

        #region Hiệu quả
        private void NapViewBag_Hieuqua(BCHieuqua request)
        {
            DateTime ngayBD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime ngayKT = DateTime.Today;
            string loaiBC = string.Empty;
            if (request.BCTratim != null)
            {
                Nap_Loaibc(request.BCTratim, ref ngayBD, ref ngayKT, ref loaiBC);
            }
            else
            {
                request.BCTratim = new BCTratim();
                loaiBC = "Tháng " + ngayBD.Month + " năm " + ngayBD.Year;
            }
            request.BCTratim.Begin = ngayBD;
            request.BCTratim.End = ngayKT;
            request.BCTratim.Loaibc = loaiBC;
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep();
            List<SelectListItem> nhombc = NapViewBag_Nhombc();

            List<SelectListItem> nguon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Cơ báo điện tử" },
                new SelectListItem { Value = "1", Text = "Cơ báo điện giấy" },
            };

            List<SelectListItem> loaidon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Theo đơn vị" },
                new SelectListItem { Value = "1", Text = "Theo loại máy" }
            };

            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.nhombc = nhombc;
            ViewBag.nguon = nguon;
            ViewBag.loaidon = loaidon;
        }
        private void NapDuLieu_Hieuqua(BCHieuqua request)
        {
            //Lấy dữ liệu   
            DateTime ngayBDHT = request.BCTratim.Begin;
            DateTime ngayKTHT = request.BCTratim.End;
            DateTime ngayBDKT = request.BCTratim.Begin;
            DateTime ngayKTKT = request.BCTratim.End;
            DateTime ngayBDCK = request.BCTratim.Begin;
            DateTime ngayKTCK = request.BCTratim.End;
            string congtacHT = string.Empty;
            string congtacKT = string.Empty;
            string congtacCK = string.Empty;
            if (int.Parse(request.BCTratim.Nhombc) == 0)
            {
                ngayBDCK = new DateTime(ngayBDHT.Year - 1, ngayBDHT.Month, 1);
                ngayKTCK = new DateTime(ngayKTHT.Year - 1, ngayKTHT.Month, DateTime.DaysInMonth(ngayKTHT.Year - 1, ngayKTHT.Month));
                if (ngayBDHT.Month == 1)
                {
                    ngayBDKT = new DateTime(ngayBDHT.Year - 1, 12, 1);
                    ngayKTKT = new DateTime(ngayKTHT.Year - 1, 12, DateTime.DaysInMonth(ngayKTHT.Year - 1, 12));
                }
                else
                {
                    ngayBDKT = new DateTime(ngayBDHT.Year, ngayBDHT.Month - 1, 1);
                    ngayKTKT = new DateTime(ngayKTHT.Year, ngayKTHT.Month - 1, DateTime.DaysInMonth(ngayKTHT.Year, ngayKTHT.Month - 1));
                }
                congtacHT = "Hiện tại tháng " + ngayBDHT.Month + " năm " + ngayBDHT.Year;
                congtacKT = "Kỳ trước tháng " + ngayBDKT.Month + " năm " + ngayBDKT.Year;
                congtacCK = "Cùng kỳ tháng " + ngayBDCK.Month + " năm " + ngayBDCK.Year;

            }
            else if (int.Parse(request.BCTratim.Nhombc) == 1)
            {
                ngayBDCK = new DateTime(ngayBDHT.Year - 1, ngayBDHT.Month, 1);
                ngayKTCK = new DateTime(ngayKTHT.Year - 1, ngayKTHT.Month, DateTime.DaysInMonth(ngayKTHT.Year - 1, ngayKTHT.Month));
                if (request.BCTratim.Begin.Month < 4)
                {
                    ngayBDKT = new DateTime(ngayBDHT.Year - 1, 10, 1);
                    ngayKTKT = new DateTime(ngayKTHT.Year - 1, 12, DateTime.DaysInMonth(ngayKTHT.Year - 1, 12));
                    congtacHT = "Hiện tại quý I năm " + ngayBDHT.Year;
                    congtacKT = "Kỳ trước quý IV năm " + ngayBDKT.Year;
                    congtacCK = "Cùng kỳ quý I năm " + ngayBDCK.Year;
                }
                else if (request.BCTratim.Begin.Month >= 4 && request.BCTratim.Begin.Month < 7)
                {
                    ngayBDKT = new DateTime(ngayBDHT.Year, 1, 1);
                    ngayKTKT = new DateTime(ngayKTHT.Year, 3, DateTime.DaysInMonth(ngayKTHT.Year, 3));
                    congtacHT = "Hiện tại quý II năm " + ngayBDHT.Year;
                    congtacKT = "Kỳ trước quý I năm " + ngayBDKT.Year;
                    congtacCK = "Cùng kỳ quý II năm " + ngayBDCK.Year;

                }
                else if (request.BCTratim.Begin.Month >= 7 && request.BCTratim.Begin.Month < 10)
                {
                    ngayBDKT = new DateTime(ngayBDHT.Year, 4, 1);
                    ngayKTKT = new DateTime(ngayKTHT.Year, 6, DateTime.DaysInMonth(ngayKTHT.Year, 6));
                    congtacHT = "Hiện tại quý III năm " + ngayBDHT.Year;
                    congtacKT = "Kỳ trước quý II năm " + ngayBDKT.Year;
                    congtacCK = "Cùng kỳ quý III năm " + ngayBDCK.Year;
                }
                else
                {
                    ngayBDKT = new DateTime(ngayBDHT.Year, 7, 1);
                    ngayKTKT = new DateTime(ngayKTHT.Year, 9, DateTime.DaysInMonth(ngayKTHT.Year, 9));
                    congtacHT = "Hiện tại quý IV năm " + ngayBDHT.Year;
                    congtacKT = "Kỳ trước quý I năm " + ngayBDKT.Year;
                    congtacCK = "Cùng kỳ quý IV năm " + ngayBDCK.Year;
                }
            }
            else if (int.Parse(request.BCTratim.Nhombc) == 2)
            {
                ngayBDCK = new DateTime(ngayBDHT.Year - 1, ngayBDHT.Month, 1);
                ngayKTCK = new DateTime(ngayKTHT.Year - 1, ngayKTHT.Month, DateTime.DaysInMonth(ngayKTHT.Year - 1, ngayKTHT.Month));
                if (request.BCTratim.Begin.Month < 7)
                {
                    ngayBDKT = new DateTime(ngayBDHT.Year - 1, 7, 1);
                    ngayKTKT = new DateTime(ngayKTHT.Year - 1, 12, DateTime.DaysInMonth(ngayKTHT.Year - 1, 12));
                    congtacHT = "Hiện tại 6 tháng đầu năm " + ngayBDHT.Year;
                    congtacKT = "Kỳ trước 6 tháng cuối năm " + ngayBDKT.Year;
                    congtacCK = "Cùng kỳ 6 tháng đầu năm " + ngayBDCK.Year;
                }
                else
                {
                    ngayBDKT = new DateTime(ngayBDHT.Year, 1, 1);
                    ngayKTKT = new DateTime(ngayKTHT.Year, 6, DateTime.DaysInMonth(ngayKTHT.Year, 6));
                    congtacHT = "Hiện tại 6 tháng cuối năm " + ngayBDHT.Year;
                    congtacKT = "Kỳ trước 6 tháng đầu năm " + ngayBDKT.Year;
                    congtacCK = "Cùng kỳ 6 tháng cuối năm " + ngayBDCK.Year;
                }
            }
            else if (int.Parse(request.BCTratim.Nhombc) == 3)
            {
                ngayBDKT = new DateTime(ngayBDHT.Year - 1, 1, 1);
                ngayKTKT = new DateTime(ngayKTHT.Year - 1, 9, DateTime.DaysInMonth(ngayKTHT.Year - 1, 9));
                ngayBDCK = new DateTime(ngayBDHT.Year - 2, ngayBDHT.Month, 1);
                ngayKTCK = new DateTime(ngayKTHT.Year - 2, ngayKTHT.Month, DateTime.DaysInMonth(ngayKTHT.Year - 2, ngayKTHT.Month));
                congtacHT = "Hiện tại 9 tháng năm " + ngayBDHT.Year;
                congtacKT = "Kỳ trước 9 tháng năm " + ngayBDKT.Year;
                congtacCK = "Cùng kỳ 9 tháng năm " + ngayBDCK.Year;
            }
            else if (int.Parse(request.BCTratim.Nhombc) == 4)
            {
                ngayBDKT = new DateTime(ngayBDHT.Year - 1, 1, 1);
                ngayKTKT = new DateTime(ngayKTHT.Year - 1, 12, DateTime.DaysInMonth(ngayKTHT.Year - 1, 12));
                ngayBDCK = new DateTime(ngayBDHT.Year - 2, ngayBDHT.Month, 1);
                ngayKTCK = new DateTime(ngayKTHT.Year - 2, ngayKTHT.Month, DateTime.DaysInMonth(ngayKTHT.Year - 2, ngayKTHT.Month));
                congtacHT = "Hiện tại năm " + ngayBDHT.Year;
                congtacKT = "Kỳ trước năm " + ngayBDKT.Year;
                congtacCK = "Cùng kỳ năm " + ngayBDCK.Year;
            }
            else
            {
                int ngayDM = int.Parse((ngayKTHT - ngayBDHT).TotalDays.ToString());
                ngayBDKT = ngayBDHT.AddDays(-ngayDM);
                ngayKTKT = ngayBDHT.AddDays(-1);
                ngayBDCK = new DateTime(ngayBDHT.Year - 1, ngayBDHT.Month, ngayBDHT.Day);
                ngayKTCK = new DateTime(ngayKTHT.Year - 1, ngayKTHT.Month, ngayKTHT.Day);
                congtacHT = "Hiện tại từ " + ngayBDHT.ToString("dd/MM/yyyy") + " đến " + ngayKTHT.ToString("dd/MM/yyyy");
                congtacKT = "Kỳ trước từ " + ngayBDKT.ToString("dd/MM/yyyy") + " đến " + ngayKTKT.ToString("dd/MM/yyyy");
                congtacCK = "Cùng kỳ từ " + ngayBDCK.ToString("dd/MM/yyyy") + " đến " + ngayKTCK.ToString("dd/MM/yyyy");
            }
            int loaiBC = int.Parse(request.BCTratim.Nhombc);
            string maDV = request.BCTratim.Xinghiep;
            int nguonDL = int.Parse(request.BCTratim.Nguon.ToString());
            int loaiDon = int.Parse(request.BCTratim.Loaidon.ToString());
            int TongSoBG = 0;
            //Lấy dữ liệu
            List<BCHieuQuaSDDMInfo> listHT = new List<BCHieuQuaSDDMInfo>();
            List<BCHieuQuaSDDMInfo> listKT = new List<BCHieuQuaSDDMInfo>();
            List<BCHieuQuaSDDMInfo> listCK = new List<BCHieuQuaSDDMInfo>();
            List<BCHieuQuaSDDMInfo> list = new List<BCHieuQuaSDDMInfo>();
            if (loaiDon == 0)
            {
                BaoCaoDAO.NapBCHQSDDMDV(nguonDL, maDV, loaiBC, ngayBDHT, ngayKTHT, ref listHT);
                foreach (var ct in listHT)
                {
                    ct.CongTac = "1." + congtacHT;
                    list.Add(ct);
                }
                BaoCaoDAO.NapBCHQSDDMDV(nguonDL, maDV, loaiBC, ngayBDKT, ngayKTKT, ref listKT);
                foreach (var ct in listKT)
                {
                    ct.CongTac = "2." + congtacKT;
                    list.Add(ct);
                    var tyLe = list.Where(x => x.XiNghiep == ct.XiNghiep && x.CongTac.Substring(0, 2) == "1.").FirstOrDefault();
                    if (tyLe != null)
                    {
                        var ctCL = new BCHieuQuaSDDMInfo();
                        ctCL.XiNghiep = ct.XiNghiep;
                        ctCL.CongTac = "3.Chênh lệch với kỳ trước";
                        ctCL.GioDM = tyLe.GioDM - ct.GioDM;
                        ctCL.GioDon = tyLe.GioDon - ct.GioDon;
                        ctCL.KmChinh = tyLe.KmChinh - ct.KmChinh;
                        ctCL.KmPhuTro = tyLe.KmPhuTro - ct.KmPhuTro;
                        ctCL.VTKm = tyLe.VTKm - ct.VTKm;
                        ctCL.KmBQ = tyLe.KmBQ - ct.KmBQ;
                        ctCL.TanBQ = tyLe.TanBQ - ct.TanBQ;
                        ctCL.NSuatBQ = tyLe.NSuatBQ - ct.NSuatBQ;
                        ctCL.MayBQ = tyLe.MayBQ - ct.MayBQ;
                        ctCL.TieuThu = tyLe.TieuThu - ct.TieuThu;
                        list.Add(ctCL);
                        var ctTL = new BCHieuQuaSDDMInfo();
                        ctTL.XiNghiep = ct.XiNghiep;
                        ctTL.CongTac = "4.Tỷ lệ % với kỳ trước";
                        ctTL.GioDM = ct.GioDM > 0 ? 100 * (tyLe.GioDM / ct.GioDM) : 100;
                        ctTL.GioDon = ct.GioDon > 0 ? 100 * (tyLe.GioDon / ct.GioDon) : 100;
                        ctTL.KmChinh = ct.KmChinh > 0 ? 100 * (tyLe.KmChinh / ct.KmChinh) : 100;
                        ctTL.KmPhuTro = ct.KmPhuTro > 0 ? 100 * (tyLe.KmPhuTro / ct.KmPhuTro) : 100;
                        ctTL.VTKm = ct.VTKm > 0 ? 100 * (tyLe.VTKm / ct.VTKm) : 100;
                        ctTL.KmBQ = ct.KmBQ > 0 ? 100 * (tyLe.KmBQ / ct.KmBQ) : 100;
                        ctTL.TanBQ = ct.TanBQ > 0 ? 100 * (tyLe.TanBQ / ct.TanBQ) : 100;
                        ctTL.NSuatBQ = ct.NSuatBQ > 0 ? 100 * (tyLe.NSuatBQ / ct.NSuatBQ) : 100;
                        ctTL.MayBQ = ct.MayBQ > 0 ? 100 * (tyLe.MayBQ / ct.MayBQ) : 100;
                        ctTL.TieuThu = ct.TieuThu > 0 ? 100 * (tyLe.TieuThu / ct.TieuThu) : 100;
                        list.Add(ctTL);
                    }
                }
                BaoCaoDAO.NapBCHQSDDMDV(nguonDL, maDV, loaiBC, ngayBDCK, ngayKTCK, ref listCK);
                foreach (var ct in listCK)
                {
                    ct.CongTac = "5." + congtacCK;
                    list.Add(ct);
                    var tyLe = list.Where(x => x.XiNghiep == ct.XiNghiep && x.CongTac.Substring(0, 2) == "1.").FirstOrDefault();
                    if (tyLe != null)
                    {
                        var ctCL = new BCHieuQuaSDDMInfo();
                        ctCL.XiNghiep = ct.XiNghiep;
                        ctCL.CongTac = "6.Chênh lệch với cùng kỳ";
                        ctCL.GioDM = tyLe.GioDM - ct.GioDM;
                        ctCL.GioDon = tyLe.GioDon - ct.GioDon;
                        ctCL.KmChinh = tyLe.KmChinh - ct.KmChinh;
                        ctCL.KmPhuTro = tyLe.KmPhuTro - ct.KmPhuTro;
                        ctCL.VTKm = tyLe.VTKm - ct.VTKm;
                        ctCL.KmBQ = tyLe.KmBQ - ct.KmBQ;
                        ctCL.TanBQ = tyLe.TanBQ - ct.TanBQ;
                        ctCL.NSuatBQ = tyLe.NSuatBQ - ct.NSuatBQ;
                        ctCL.MayBQ = tyLe.MayBQ - ct.MayBQ;
                        ctCL.TieuThu = tyLe.TieuThu - ct.TieuThu;
                        list.Add(ctCL);
                        var ctTL = new BCHieuQuaSDDMInfo();
                        ctTL.XiNghiep = ct.XiNghiep;
                        ctTL.CongTac = "7.Tỷ lệ % với cùng kỳ";
                        ctTL.GioDM = ct.GioDM > 0 ? 100 * (tyLe.GioDM / ct.GioDM) : 100;
                        ctTL.GioDon = ct.GioDon > 0 ? 100 * (tyLe.GioDon / ct.GioDon) : 100;
                        ctTL.KmChinh = ct.KmChinh > 0 ? 100 * (tyLe.KmChinh / ct.KmChinh) : 100;
                        ctTL.KmPhuTro = ct.KmPhuTro > 0 ? 100 * (tyLe.KmPhuTro / ct.KmPhuTro) : 100;
                        ctTL.VTKm = ct.VTKm > 0 ? 100 * (tyLe.VTKm / ct.VTKm) : 100;
                        ctTL.KmBQ = ct.KmBQ > 0 ? 100 * (tyLe.KmBQ / ct.KmBQ) : 100;
                        ctTL.TanBQ = ct.TanBQ > 0 ? 100 * (tyLe.TanBQ / ct.TanBQ) : 100;
                        ctTL.NSuatBQ = ct.NSuatBQ > 0 ? 100 * (tyLe.NSuatBQ / ct.NSuatBQ) : 100;
                        ctTL.MayBQ = ct.MayBQ > 0 ? 100 * (tyLe.MayBQ / ct.MayBQ) : 100;
                        ctTL.TieuThu = ct.TieuThu > 0 ? 100 * (tyLe.TieuThu / ct.TieuThu) : 100;
                        list.Add(ctTL);
                    }
                }

                foreach (var ct in list)
                {
                    if (ct.XiNghiep == "YV") ct.XiNghiep = "1.Chi nhánh XNĐM Yên Viên";
                    else if (ct.XiNghiep == "HN") ct.XiNghiep = "2.Chi nhánh XNĐM Hà Nội";
                    else if (ct.XiNghiep == "VIN") ct.XiNghiep = "3.Chi nhánh XNĐM Vinh";
                    else if (ct.XiNghiep == "DN") ct.XiNghiep = "4.Chi nhánh XNĐM Đà Nẵng";
                    else if (ct.XiNghiep == "SG") ct.XiNghiep = "5.Chi nhánh XNĐM Sài Gòn";
                    else ct.XiNghiep = "6.Tổng công ty ĐSVN";
                }
            }
            else
            {
                BaoCaoDAO.NapBCHQSDDMLM(nguonDL, maDV, loaiBC, ngayBDHT, ngayKTHT, ref listHT);
                foreach (var ct in listHT)
                {
                    ct.CongTac = "1." + congtacHT;
                    list.Add(ct);
                }
                BaoCaoDAO.NapBCHQSDDMLM(nguonDL, maDV, loaiBC, ngayBDKT, ngayKTKT, ref listKT);
                foreach (var ct in listKT)
                {
                    ct.CongTac = "2." + congtacKT;
                    list.Add(ct);
                    var tyLe = list.Where(x => x.LoaiMay == ct.LoaiMay && x.CongTac.Substring(0, 2) == "1.").FirstOrDefault();
                    if (tyLe != null)
                    {
                        var ctCL = new BCHieuQuaSDDMInfo();
                        ctCL.LoaiMay = ct.LoaiMay;
                        ctCL.CongTac = "3.Chênh lệch với kỳ trước";
                        ctCL.GioDM = tyLe.GioDM - ct.GioDM;
                        ctCL.GioDon = tyLe.GioDon - ct.GioDon;
                        ctCL.KmChinh = tyLe.KmChinh - ct.KmChinh;
                        ctCL.KmPhuTro = tyLe.KmPhuTro - ct.KmPhuTro;
                        ctCL.VTKm = tyLe.VTKm - ct.VTKm;
                        ctCL.KmBQ = tyLe.KmBQ - ct.KmBQ;
                        ctCL.TanBQ = tyLe.TanBQ - ct.TanBQ;
                        ctCL.NSuatBQ = tyLe.NSuatBQ - ct.NSuatBQ;
                        ctCL.MayBQ = tyLe.MayBQ - ct.MayBQ;
                        ctCL.TieuThu = tyLe.TieuThu - ct.TieuThu;
                        list.Add(ctCL);
                        var ctTL = new BCHieuQuaSDDMInfo();
                        ctTL.LoaiMay = ct.LoaiMay;
                        ctTL.CongTac = "4.Tỷ lệ % với kỳ trước";
                        ctTL.GioDM = ct.GioDM > 0 ? 100 * (tyLe.GioDM / ct.GioDM) : 100;
                        ctTL.GioDon = ct.GioDon > 0 ? 100 * (tyLe.GioDon / ct.GioDon) : 100;
                        ctTL.KmChinh = ct.KmChinh > 0 ? 100 * (tyLe.KmChinh / ct.KmChinh) : 100;
                        ctTL.KmPhuTro = ct.KmPhuTro > 0 ? 100 * (tyLe.KmPhuTro / ct.KmPhuTro) : 100;
                        ctTL.VTKm = ct.VTKm > 0 ? 100 * (tyLe.VTKm / ct.VTKm) : 100;
                        ctTL.KmBQ = ct.KmBQ > 0 ? 100 * (tyLe.KmBQ / ct.KmBQ) : 100;
                        ctTL.TanBQ = ct.TanBQ > 0 ? 100 * (tyLe.TanBQ / ct.TanBQ) : 100;
                        ctTL.NSuatBQ = ct.NSuatBQ > 0 ? 100 * (tyLe.NSuatBQ / ct.NSuatBQ) : 100;
                        ctTL.MayBQ = ct.MayBQ > 0 ? 100 * (tyLe.MayBQ / ct.MayBQ) : 100;
                        ctTL.TieuThu = ct.TieuThu > 0 ? 100 * (tyLe.TieuThu / ct.TieuThu) : 100;
                        list.Add(ctTL);
                    }
                }
                BaoCaoDAO.NapBCHQSDDMLM(nguonDL, maDV, loaiBC, ngayBDCK, ngayKTCK, ref listCK);
                foreach (var ct in listCK)
                {
                    ct.CongTac = "5." + congtacCK;
                    list.Add(ct);
                    var tyLe = list.Where(x => x.LoaiMay == ct.LoaiMay && x.CongTac.Substring(0, 2) == "1.").FirstOrDefault();
                    if (tyLe != null)
                    {
                        var ctCL = new BCHieuQuaSDDMInfo();
                        ctCL.LoaiMay = ct.LoaiMay;
                        ctCL.CongTac = "6.Chênh lệch với cùng kỳ";
                        ctCL.GioDM = tyLe.GioDM - ct.GioDM;
                        ctCL.GioDon = tyLe.GioDon - ct.GioDon;
                        ctCL.KmChinh = tyLe.KmChinh - ct.KmChinh;
                        ctCL.KmPhuTro = tyLe.KmPhuTro - ct.KmPhuTro;
                        ctCL.VTKm = tyLe.VTKm - ct.VTKm;
                        ctCL.KmBQ = tyLe.KmBQ - ct.KmBQ;
                        ctCL.TanBQ = tyLe.TanBQ - ct.TanBQ;
                        ctCL.NSuatBQ = tyLe.NSuatBQ - ct.NSuatBQ;
                        ctCL.MayBQ = tyLe.MayBQ - ct.MayBQ;
                        ctCL.TieuThu = tyLe.TieuThu - ct.TieuThu;
                        list.Add(ctCL);
                        var ctTL = new BCHieuQuaSDDMInfo();
                        ctTL.LoaiMay = ct.LoaiMay;
                        ctTL.CongTac = "7.Tỷ lệ % với cùng kỳ";
                        ctTL.GioDM = ct.GioDM > 0 ? 100 * (tyLe.GioDM / ct.GioDM) : 100;
                        ctTL.GioDon = ct.GioDon > 0 ? 100 * (tyLe.GioDon / ct.GioDon) : 100;
                        ctTL.KmChinh = ct.KmChinh > 0 ? 100 * (tyLe.KmChinh / ct.KmChinh) : 100;
                        ctTL.KmPhuTro = ct.KmPhuTro > 0 ? 100 * (tyLe.KmPhuTro / ct.KmPhuTro) : 100;
                        ctTL.VTKm = ct.VTKm > 0 ? 100 * (tyLe.VTKm / ct.VTKm) : 100;
                        ctTL.KmBQ = ct.KmBQ > 0 ? 100 * (tyLe.KmBQ / ct.KmBQ) : 100;
                        ctTL.TanBQ = ct.TanBQ > 0 ? 100 * (tyLe.TanBQ / ct.TanBQ) : 100;
                        ctTL.NSuatBQ = ct.NSuatBQ > 0 ? 100 * (tyLe.NSuatBQ / ct.NSuatBQ) : 100;
                        ctTL.MayBQ = ct.MayBQ > 0 ? 100 * (tyLe.MayBQ / ct.MayBQ) : 100;
                        ctTL.TieuThu = ct.TieuThu > 0 ? 100 * (tyLe.TieuThu / ct.TieuThu) : 100;
                        list.Add(ctTL);
                    }
                }
            }
            //Kiểm tra xem có dữ liệu hay không
            if (list.Count <= 0)
                throw new Exception("Không có dữ liệu.");
            TongSoBG = list.Count;

            request.BCHieuQuaSDDMInfo = new List<BCHieuQuaSDDMInfo>();
            request.BCHieuQuaSDDMInfo = list;
        }
        public IActionResult Hieuqua()
        {
            BCHieuqua request = new BCHieuqua();
            NapViewBag_Hieuqua(request);
            return View(request);
        }
        [HttpPost]
        public IActionResult Hieuqua(BCHieuqua request)
        {
            NapViewBag_Hieuqua(request);
            NapDuLieu_Hieuqua(request);
            return View(request);
        }
        public IActionResult PdfReport_Hieuqua(BCHieuqua request)
        {
            NapViewBag_Hieuqua(request);
            NapDuLieu_Hieuqua(request);
            return HieuquaReport("PDF", "pdf", "application/pdf", request);
        }
        public IActionResult ExcelReport_Hieuqua(BCHieuqua request)
        {
            NapViewBag_Hieuqua(request);
            NapDuLieu_Hieuqua(request);
            return HieuquaReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", request);
        }
        public IActionResult WordReport_Hieuqua(BCHieuqua request)
        {
            NapViewBag_Hieuqua(request);
            NapDuLieu_Hieuqua(request);
            return HieuquaReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", request);
        }
        public IActionResult HtmlReport_Hieuqua(BCHieuqua request)
        {
            NapViewBag_Hieuqua(request);
            NapDuLieu_Hieuqua(request);
            return HieuquaReport("HTML5", "html", "text/html", request);
        }
        private IActionResult HieuquaReport(string renderFormat, string extension, string mimeType, BCHieuqua request)
        {
            using var report = new LocalReport();
            var donviDMList = HttpHelper.GetList<DonViDM>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViDM");
            var dVQL = donviDMList.Where(x => x.MaDV == request.BCTratim.Xinghiep).FirstOrDefault();
            string tenDV = dVQL.TenDV;
            string tenDVCha = donviDMList.Where(x => x.MaDV == dVQL.MaCha).FirstOrDefault().TenDV.ToUpper();
            string tenBC = "giữa tổng công ty đường sắt việt nam và " + tenDV;
            var parameters = new[]
            {
                 new  ReportParameter("prmDonvicha",tenDVCha),
                 new  ReportParameter("prmDonvicon",tenDV.ToUpper()),
                  new  ReportParameter("prmSocv","Số:................/BC-ĐM."),
                  new  ReportParameter("prmNgayth","Ngày " + DateTime.Today.ToString("dd") + " tháng " + DateTime.Today.ToString("MM") + " năm " + DateTime.Today.ToString("yyyy")),
                   new  ReportParameter("prmLapbieu","NGƯỜI LẬP BIỂU"),
                    new  ReportParameter("prmPhongban","PHÒNG BAN"),
                     new  ReportParameter("prmGiamdoc","GIÁM ĐỐC"),
            };
            if (request.BCTratim.Loaidon == "0")
            {
                var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptHQSDDV.rdlc";
                report.ReportPath = path;
            }
            else
            {
                var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptHQSDLM.rdlc";
                report.ReportPath = path;
            }
            report.SetParameters(parameters);
            report.DataSources.Add(new ReportDataSource("BaoCaoDS", request.BCHieuQuaSDDMInfo));
            var render = report.Render(renderFormat);
            return File(render, mimeType, "Hieuqua." + extension);
        }
        #endregion
    }
}
