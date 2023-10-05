using ClosedXML.Excel;
using CoBaoWeb.BLLs;
using CoBaoWeb.Models;
using CoBaoWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    public class CoBaoGAController : Controller
    {       
        private readonly IWebHostEnvironment _webHostEnvirnoment;
        public CoBaoGAController(IWebHostEnvironment webHostEnvironment)
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
        private List<SelectListItem> NapViewBag_Trangthai()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem { Value = "Tất cả", Text = "Tất cả" },
                new SelectListItem { Value = "Đã chuyển", Text = "Đã chuyển" },
                new SelectListItem { Value = "Chưa chuyển", Text = "Chưa chuyển" },
                new SelectListItem { Value = "Thêm mới", Text = "Thêm mới" },               
            };
        }
        #endregion

        #region CBGA Cơ báo
        public IActionResult Cobaoga()
        {
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep();
            List<SelectListItem> trangthai = NapViewBag_Trangthai();

            TTCobaoga model = new TTCobaoga();
            CoBaoGAView vdtt = new CoBaoGAView();
            vdtt.Begin = DateTime.Today.AddDays(-1);
            vdtt.End = DateTime.Today;
            model.CobaoTT = vdtt;
            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.trangthai = trangthai;
            return View(model);
        }
        [HttpPost]
        public IActionResult Cobaoga(TTCobaoga request)
        {           
            var listCoBaoTT = GetCobaodtsPagings(request);
            request.CoBaoGA = listCoBaoTT;
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep();
            List<SelectListItem> trangthai = NapViewBag_Trangthai();
            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.trangthai = trangthai;
            return View(request);
        }       
        private IEnumerable<CoBaoGA> GetCobaodtsPagings(TTCobaoga request)
        {
            List<CoBaoGA> listCoBao = new List<CoBaoGA>();                                  
            DateTime dNgay = request.CobaoTT.Begin;
            bool isFist = true;
            while (dNgay < request.CobaoTT.End)
            {
                TimeSpan timeSpan = request.CobaoTT.End - dNgay;
                int iLen = timeSpan.Days;
                DateTime ngayBD = isFist ? dNgay : dNgay.AddDays(1);
                if (string.IsNullOrWhiteSpace(request.CobaoTT.Socb))
                {
                    if (timeSpan.Days > 5) iLen = 5;                    
                }
                else
                {
                    if (timeSpan.Days > 15) iLen = 15;                   
                }
                dNgay = dNgay.AddDays(iLen);
                DateTime ngayKT = dNgay;
                isFist = false;
                string data = "?MaDV=" + request.CobaoTT.Xinghiep;               
                data += "&NgayBD=" + ngayBD;
                data += "&NgayKT=" + ngayKT;
                data += "&DauMay=" + request.CobaoTT.Daumay;
                data += "&SoCB=" + request.CobaoTT.Socb;
                data += "&TaiXe=" + request.CobaoTT.Taixe;
                data += "&TrangThai=" + request.CobaoTT.Trangthai;

                var listCoBaoTT = HttpHelper.GetList<CoBaoGA>(Configuration.UrlCBApi + "api/CoBaoGAs/GetCoBaoGAView" + data);
                listCoBao = listCoBao.Concat(listCoBaoTT).ToList();
            }
            listCoBao = listCoBao.OrderByDescending(x => x.NhanMay).ToList();            
            return listCoBao;
        }
        #endregion
       
        #region CBGA Cơ báo chi tiết
        private async Task<TTCobaogact> Cobaogagact_Napdl(string id, string cobaoGoc)
        { 
            TTCobaogact request = new TTCobaogact();
            string data = "?id=" + id;
            data += "&cobaoGoc=" + cobaoGoc;
            var cb = await HttpHelper.Get<CoBaoGA>(Configuration.UrlCBApi + "api/CoBaoGAs/GetCoBaoGocID" + data);           
            if (cb != null)
            {               
                var objthanhtich = CoBaoDAO.NapObThanhTichByCoBaoGoc(cb.CoBaoGoc);
                if (cb.TrangThai != "Chưa chuyển")
                    objthanhtich = await CoBaoDAO.ObjNapThanhTichByCoBaoGA(cb.CoBaoID);
                request.CoBaoGA = new CoBaoGA();               
                request.CoBaoGA = cb;               
                request.BCCoBaoTTInfo = new BCCoBaoTTInfo();
                request.BCCoBaoTTInfo = objthanhtich;
            }
            return request;
        }
        public async Task<IActionResult> Cobaogact(string id, string cobaoGoc)
        {
            TTCobaogact request = await Cobaogagact_Napdl(id, cobaoGoc);
            return View(request);
        }
        public async Task<IActionResult> PdfReport_Cobaogact(TTCobaogact request)
        {            
            string id = request.CoBaoGA.CoBaoID.ToString();
            string cobaoGoc = request.CoBaoGA.CoBaoGoc.ToString();
            request = await Cobaogagact_Napdl(id, cobaoGoc);
            return CobaogactReport("PDF", "pdf", "application/pdf", request);
        }
        public async Task<IActionResult> ExcelReport_Cobaogact(TTCobaogact request)
        {
            string id = request.CoBaoGA.CoBaoID.ToString();
            string cobaoGoc = request.CoBaoGA.CoBaoGoc.ToString();
            request = await Cobaogagact_Napdl(id, cobaoGoc);
            return CobaogactReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", request);
        }
        public async Task<IActionResult> WordReport_Cobaodtct(TTCobaogact request)
        {
            string id = request.CoBaoGA.CoBaoID.ToString();
            string cobaoGoc = request.CoBaoGA.CoBaoGoc.ToString();
            request = await Cobaogagact_Napdl(id, cobaoGoc);
            return CobaogactReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", request);
        }
        public async Task<IActionResult> HtmlReport_Cobaodtct(TTCobaogact request)
        {
            string id = request.CoBaoGA.CoBaoID.ToString();
            string cobaoGoc = request.CoBaoGA.CoBaoGoc.ToString();
            request = await Cobaogagact_Napdl(id, cobaoGoc);
            return CobaogactReport("HTML5", "html", "text/html", request);
        }
        private IActionResult CobaogactReport(string renderFormat, string extension, string mimeType, TTCobaogact request)
        {
            using var report = new LocalReport();
            string tenDV = "THUỘC: " + request.CoBaoGA.DvcbName.ToUpper();
            var parameters = new[]
            {
                new  ReportParameter("prmLoaibc",tenDV)
            };
            var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptCoBaoGA.rdlc";
            report.ReportPath = path;
            report.SetParameters(parameters);
            //Nạp dữ liệu cơ báo
            List<CoBaoGA> listCoBao = new List<CoBaoGA>();
            listCoBao.Add(request.CoBaoGA);
            report.DataSources.Add(new ReportDataSource("CoBaoDS", listCoBao));
            //Nạp dữ liệu thành tích
            List<BCCoBaoTTInfo> listCoBaoTT = new List<BCCoBaoTTInfo>();
            listCoBaoTT.Add(request.BCCoBaoTTInfo);
            report.DataSources.Add(new ReportDataSource("CoBaoTTDS", listCoBaoTT));

           //Nạp dữ liệu cơ báo chi tiết
            int soTT = 1;
            List<BCCoBaoGACTInfo> listCoBaoCT = new List<BCCoBaoGACTInfo>();
            foreach (CoBaoGACT row in request.CoBaoGA.coBaoGACTs)
            {
                BCCoBaoGACTInfo info = new BCCoBaoGACTInfo();
                info.SoTT = soTT;
                info.NgayXP = row.NgayXP;
                info.GioDen = row.GioDen.ToString("HH:mm");
                info.GioDi = row.GioDi.ToString("HH:mm");
                info.GioDon = row.PhutDon.ToString();
                info.RutGioNL = row.RutGioNL.ToString();
                info.DungGioPT = row.DungGioPT;
                info.MacTau = row.MacTauID;
                info.GaDi = row.GaName;
                info.Tan = (decimal)row.Tan;
                info.xeTotal = (int)row.XeTotal;
                info.TanRong = (decimal)row.TanXeRong;
                info.xeRong = (int)row.XeRongTotal;
                info.TinhChat = row.TinhChatName;
                info.MayGhep = row.MayGhepID;
                info.KmAdd = (decimal)row.KmAdd;
                listCoBaoCT.Add(info);
                soTT++;
            }
            report.DataSources.Add(new ReportDataSource("CoBaoCTDS", listCoBaoCT));

            //Nạp dữ liệu cơ báo dầu mỡ           
            List<CoBaoGADM> listCoBaoDM = new List<CoBaoGADM>();
            if(request.CoBaoGA.coBaoGADMs!=null)
                listCoBaoDM = request.CoBaoGA.coBaoGADMs;            
            report.DataSources.Add(new ReportDataSource("CoBaoDMDS", listCoBaoDM));
           
            var render = report.Render(renderFormat);
            return File(render, mimeType, "Cobaoga." + extension);
        }
        public async Task<IActionResult> PdfReportRG_Cobaogact(TTCobaogact request)
        {

            string id = request.CoBaoGA.CoBaoID.ToString();
            string cobaoGoc = request.CoBaoGA.CoBaoGoc.ToString();
            request = await Cobaogagact_Napdl(id, cobaoGoc);
            return CobaogactReportRG("PDF", "pdf", "application/pdf", request);
        }
        public async Task<IActionResult> ExcelReportRG_Cobaogact(TTCobaogact request)
        {
            string id = request.CoBaoGA.CoBaoID.ToString();
            string cobaoGoc = request.CoBaoGA.CoBaoGoc.ToString();
            request = await Cobaogagact_Napdl(id, cobaoGoc);
            return CobaogactReportRG("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", request);
        }
        public async Task<IActionResult> WordReportRG_Cobaogact(TTCobaogact request)
        {
            string id = request.CoBaoGA.CoBaoID.ToString();
            string cobaoGoc = request.CoBaoGA.CoBaoGoc.ToString();
            request = await Cobaogagact_Napdl(id, cobaoGoc);
            return CobaogactReportRG("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", request);
        }
        public async Task<IActionResult> HtmlReportRG_Cobaogact(TTCobaogact request)
        {
            string id = request.CoBaoGA.CoBaoID.ToString();
            string cobaoGoc = request.CoBaoGA.CoBaoGoc.ToString();
            request = await Cobaogagact_Napdl(id, cobaoGoc);
            return CobaogactReportRG("HTML5", "html", "text/html", request);
        }
        private IActionResult CobaogactReportRG(string renderFormat, string extension, string mimeType, TTCobaogact request)
        {
            //Lấy dữ liệu
            var rowCBDGPT = request.CoBaoGA.coBaoGACTs.Where(x => x.DungGioPT == true).OrderBy(x => x.GioDi).FirstOrDefault();
            var rowCBRGNL = request.CoBaoGA.coBaoGACTs.Where(x => x.RutGioNL > 0).OrderBy(x => x.GioDi).FirstOrDefault();
            //Kiểm tra xem có dữ liệu hay không
            if (rowCBDGPT == null && rowCBRGNL == null)
            {               
                throw new Exception("Không có dữ liệu.");
            }   
            string macTau = rowCBDGPT != null ? rowCBDGPT.MacTauID : rowCBRGNL.MacTauID;
            var rowCBCTFist = request.CoBaoGA.coBaoGACTs.Where(x => x.MacTauID == macTau).OrderBy(x => x.GioDen).FirstOrDefault();
            var rowCBCTLast = request.CoBaoGA.coBaoGACTs.Where(x => x.MacTauID == macTau).OrderByDescending(x => x.GioDen).FirstOrDefault();
            long tienDungGio = 0; long tienGoGio = 0; long tienTong = 0;
            if (rowCBDGPT != null)
            {
                string data = "?NgayHL=" + request.CoBaoGA.NgayCB;
                data += "&LoaiPhieu=Đúng giờ";
                data += "&MacTau=" + rowCBDGPT.MacTauID + ",";
                data += "&GaName=" + rowCBDGPT.GaName;
                var dmDungGio = HttpHelper.Get<HNPhieuThuong>(Configuration.UrlCBApi + "api/HaNois/HNGetPhieuThuongOBJ" + data).Result;
                if (dmDungGio != null)
                {
                    tienDungGio = (long)dmDungGio.DonGia;
                    tienTong += tienDungGio;
                }
            }
            if (request.CoBaoGA.RutGio > 0)
            {
                string data = "?NgayHL=" + request.CoBaoGA.NgayCB;
                data += "&LoaiPhieu=Gỡ giờ";
                data += "&MacTau=" + rowCBCTFist.MacTauID + ",";
                data += "&GaName=";
                var dmGoGio = HttpHelper.Get<HNPhieuThuong>(Configuration.UrlCBApi + "api/HaNois/HNGetPhieuThuongOBJ" + data).Result;
                if (dmGoGio != null)
                {
                    tienGoGio = (long)(dmGoGio.DonGia * request.CoBaoGA.RutGio);
                    tienTong += tienGoGio;
                }
            }

            using var report = new LocalReport();
            string maDV = User.FindFirst(ClaimTypes.PrimarySid).Value;
            var donviDMList = HttpHelper.GetList<DonViDM>(Configuration.UrlCBApi + "api/DanhMucs/GetDonViDM");
            var dVQL = donviDMList.Where(x => x.MaDV == request.CoBaoGA.DvcbID).FirstOrDefault();
            string tenDV = dVQL.TenDV;
            string tenDVCha = donviDMList.Where(x => x.MaDV == dVQL.MaCha).FirstOrDefault().TenDV.ToUpper();
            string dungGio = ".....................................................................";
            if (rowCBDGPT != null)
                dungGio = " Đúng giờ;";
            string chuDung = "(viết bẵng chữ";
            if (request.CoBaoGA.RutGio > 0)
                chuDung = chuDung + " " + Library.NumberToText(request.CoBaoGA.RutGio) + " phút)";
            else
                chuDung = chuDung + ".....................................................................)";
            var parameters = new[]
          {
                 new  ReportParameter("prmDonvicha",tenDVCha),
                 new  ReportParameter("prmDonvicon",tenDV.ToUpper()),
                 new  ReportParameter("prmNgayth","............., ngày " + DateTime.Today.ToString("dd") + " tháng " + DateTime.Today.ToString("MM") + " năm " + DateTime.Today.ToString("yyyy")),
                 new  ReportParameter("prmDaumay","Đầu máy số hiệu: " + request.CoBaoGA.DauMayID+";      Thuộc " + request.CoBaoGA.DvdmName+";"),
                  new  ReportParameter("prmMactau","Kéo tàu số: " + rowCBCTFist.MacTauID + ";        Khu đoạn: " + rowCBCTFist.GaName +" - "+ rowCBCTLast.GaName + ";"),
                   new  ReportParameter("prmSocb","Số cơ báo điện tử: " + request.CoBaoGA.SoCB + ";"),
                    new  ReportParameter("prmGadi","Chạy từ ga: " + rowCBCTFist.GaName + ";      Lúc: "+ rowCBCTFist.GioDi.ToString("HH")+" giờ "+ rowCBCTFist.GioDi.ToString("mm")+" phút, ngày "+ rowCBCTFist.GioDi.ToString("dd.MM.yyyy")+";"),
                     new  ReportParameter("prmGaden","Đến ga: " + rowCBCTLast.GaName + ";     Lúc: " + rowCBCTLast.GioDen.ToString("HH") + " giờ " + rowCBCTLast.GioDen.ToString("mm") + " phút, ngày " + rowCBCTLast.GioDen.ToString("dd.MM.yyyy") + ";"),
                      new  ReportParameter("prmDunggio","- Đúng giờ BĐCT:" + dungGio),
                      new  ReportParameter("prmChamgiochu","- Thời gian rút chậm giờ: " + request.CoBaoGA.RutGio.ToString("N0") + " phút " + chuDung),
                      new  ReportParameter("prmSotienthuongdg","1. Tiền thưởng đến đúng giờ: " + tienDungGio.ToString("N0")+" VNĐ."),
                      new  ReportParameter("prmChutienthuongdg","(Bằng chữ: " + Library.NumberToText(tienDungGio) + " đồng)"),
                      new  ReportParameter("prmSotienthuongrg","2. Tiền thưởng rút ngắn thời gian chậm tàu: " + tienGoGio.ToString("N0") + " VNĐ."),
                       new  ReportParameter("prmChutienthuongrg","(Bằng chữ: " + Library.NumberToText(tienGoGio) + " đồng)"),
                       new  ReportParameter("prmSotienthuongtg","Tổng số tiền (1+2): " + tienTong.ToString("N0") + " VNĐ."),
                       new  ReportParameter("prmChutienthuongtg","(Bằng chữ: " + Library.NumberToText(tienTong) + " đồng)")
            };

            var path = $"{_webHostEnvirnoment.WebRootPath}\\Reports\\RptPhieuRutGio.rdlc";
            report.ReportPath = path;
            report.SetParameters(parameters);
            //Nạp dữ liệu cơ báo
            List<CoBaoGA> listCoBao = new List<CoBaoGA>();
            listCoBao.Add(request.CoBaoGA);
            report.DataSources.Add(new ReportDataSource("BaoCaoDS", listCoBao));

            var render = report.Render(renderFormat);
            return File(render, mimeType, "Rugioga." + extension);
        }
        #endregion

        #region CBGA Đoạn thống
        public IActionResult Doanthongga()
        {
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep();
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

            TTDoanthongga request = new TTDoanthongga();
            DoanthongGATT dttt = new DoanthongGATT();
            dttt.Begin = DateTime.Today.AddDays(-1);
            dttt.End = DateTime.Today;
            request.DoanthongGATT = dttt;
            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.loaimay = loaimay;
            return View(request);
        }
        [HttpPost]
        public IActionResult Doanthongga(TTDoanthongga request)
        {
            var listDoanThong = GetDoanthongdtsPagings(request);
            request.DoanThongGAView = listDoanThong;
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep();
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
            ViewBag.xinghiep = xinghiep;
            ViewBag.loaimay = loaimay;
            return View(request);
            //return PartialView(request);

        }
        [HttpGet]
        private IEnumerable<DoanThongGAView> GetDoanthongdtsPagings(TTDoanthongga request)
        {
            List<DoanThongGAView> listDoanThong = new List<DoanThongGAView>();
            List<DoanThongGAView> listdt = new List<DoanThongGAView>();
            DateTime dNgay = request.DoanthongGATT.Begin;
            bool isFist = true;
            while (dNgay < request.DoanthongGATT.End)
            {
                TimeSpan timeSpan = request.DoanthongGATT.End - dNgay;
                int iLen = timeSpan.Days;
                DateTime ngayBD = isFist ? dNgay : dNgay.AddDays(1);
                if (timeSpan.Days > 15) iLen = 15;
                dNgay = dNgay.AddDays(iLen);
                DateTime ngayKT = dNgay;
                isFist = false;
                string data = "NgayBD=" + ngayBD;
                data += "&NgayKT=" + ngayKT;
                data += "&LoaiMay=" + request.DoanthongGATT.Loaimay;
                data += "&DonVi=" + request.DoanthongGATT.Xinghiep;
                data += "&DauMay=" + request.DoanthongGATT.Daumay;
                data += "&SoCB=" + request.DoanthongGATT.Socb;
                data += "&TaiXe=" + request.DoanthongGATT.Taixe;
                data += "&MacTau=" + request.DoanthongGATT.Mactau;
                listdt = HttpHelper.GetList<DoanThongGAView>(Configuration.UrlCBApi + "api/CoBaoGAs/GetTTDoanThong?" + data);
                if (listdt.Count > 0)
                {
                    listDoanThong = listDoanThong.Concat(listdt).ToList();
                }
            }
            listDoanThong = listDoanThong.OrderByDescending(x => x.NhanMay).ToList();
            return listDoanThong;
        }
        #endregion

        #region CBGA Đoạn thống chi tiết
        private async Task<TTDoanthonggact> Doanthonggact_Napdl(long id)
        {
            TTDoanthonggact request = new TTDoanthonggact();
            //Nạp đoạn thống
            var dt = HttpHelper.Get<DoanThongGAView>(Configuration.UrlCBApi + "api/CoBaoGAs/GetDoanThongViewID?id=" + id).Result;
            var dtct = HttpHelper.GetList<DoanThongGACT>(Configuration.UrlCBApi + "api/CoBaoGAs/GetDoanThongGACTView?id=" + id);
            var dtdm = HttpHelper.GetList<DoanThongGADM>(Configuration.UrlCBApi + "api/CoBaoGAs/GetDoanThongGADMView?id=" + id);
            request.DoanThongGAView = new DoanThongGAView();
            request.DoanThongGAView = dt;
            request.DoanThongGACT = new List<DoanThongGACT>();
            request.DoanThongGACT = dtct;
            request.DoanThongGADM = new List<DoanThongGADM>();
            request.DoanThongGADM = dtdm;
            var objthanhtich = await CoBaoDAO.ObjNapThanhTichByCoBaoGA(id); ;
            request.BCCoBaoTTInfo = new BCCoBaoTTInfo();
            request.BCCoBaoTTInfo = objthanhtich;
            return request;
        }
        public async Task<IActionResult> Doanthonggact(long id)
        {
            TTDoanthonggact request = await Doanthonggact_Napdl(id);
            return View(request);
        }
        public async Task<IActionResult> PdfReport_Doanthonggact(TTDoanthonggact request)
        {
            string id = request.DoanThongGAView.DoanThongID.ToString();
            string cobaoGoc = "0";
            var requestcb = await Cobaogagact_Napdl(id, cobaoGoc);            
            return CobaogactReport("PDF", "pdf", "application/pdf", requestcb);
        }
        public async Task<IActionResult> ExcelReport_Doanthonggact(TTDoanthonggact request)
        {
            string id = request.DoanThongGAView.DoanThongID.ToString();
            string cobaoGoc = "0";
            var requestcb = await Cobaogagact_Napdl(id, cobaoGoc);
            return CobaogactReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetmt.sheet", requestcb);
        }
        public async Task<IActionResult> WordReport_Doanthonggact(TTDoanthonggact request)
        {
            string id = request.DoanThongGAView.DoanThongID.ToString();
            string cobaoGoc = "0";
            var requestcb = await Cobaogagact_Napdl(id, cobaoGoc);
            return CobaogactReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", requestcb);
        }
        public async Task<IActionResult> HtmlReport_Doanthonggact(TTDoanthonggact request)
        {
            string id = request.DoanThongGAView.DoanThongID.ToString();
            string cobaoGoc = "0";
            var requestcb = await Cobaogagact_Napdl(id, cobaoGoc);
            return CobaogactReport("HTML5", "html", "text/html", requestcb);
        }
        #endregion

        #region CBGA KT logic
        public IActionResult KTLogicga()
        {
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep();
            List<SelectListItem> loaidon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Giờ quay vòng" },
                new SelectListItem { Value = "1", Text = "Giờ đơn thuần" },
                new SelectListItem { Value = "2", Text = "Vận tốc kỹ thuật" },
                new SelectListItem { Value = "3", Text = "Dừng kho bãi" },
                new SelectListItem { Value = "4", Text = "Nhiên liệu giao nhận" },
            };
            List<SelectListItem> thang = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                thang.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }
            List<SelectListItem> nam = new List<SelectListItem>();
            int year = DateTime.Today.Year;
            for (int i = year - 10; i <= year + 1; i++)
            {
                nam.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }

            TTKTLogic request = new TTKTLogic();
            KTLogicTT dttt = new KTLogicTT();
            dttt.Thang = DateTime.Today.Month;
            dttt.Nam = DateTime.Today.Year;
            request.KTLogicTT = dttt;
            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.loaidon = loaidon;
            ViewBag.thang = thang;
            ViewBag.nam = nam;
            return View(request);
        }
        [HttpPost]
        public IActionResult KTLogicga(KTLogicTT kTLogicTT)
        {
            TTKTLogic request = new TTKTLogic();
            request = KTLogicga_Napdl(kTLogicTT);
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep();
            List<SelectListItem> loaidon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Giờ quay vòng" },
                new SelectListItem { Value = "1", Text = "Giờ đơn thuần" },
                new SelectListItem { Value = "2", Text = "Vận tốc kỹ thuật" },
                new SelectListItem { Value = "3", Text = "Dừng kho bãi" },
                new SelectListItem { Value = "4", Text = "Nhiên liệu giao nhận" },
            };
            List<SelectListItem> thang = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                thang.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }
            List<SelectListItem> nam = new List<SelectListItem>();
            int year = DateTime.Today.Year;
            for (int i = year - 10; i <= year + 1; i++)
            {
                nam.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }
            ViewBag.xinghiep = xinghiep;
            ViewBag.loaidon = loaidon;
            ViewBag.thang = thang;
            ViewBag.nam = nam;
            return View(request);

        }
        private TTKTLogic KTLogicga_Napdl(KTLogicTT kTLogicTT)
        {
            TTKTLogic request = new TTKTLogic();
            request.KTLogicTT = new KTLogicTT();
            //Nạp đoạn thống
            string data = "?madv=" + kTLogicTT.Xinghiep;
            data += "&thangdt=" + kTLogicTT.Thang;
            data += "&namdt=" + kTLogicTT.Nam;
            data += "&daumay=" + kTLogicTT.Daumay;
            if (kTLogicTT.Loaidon == "0")
            {
                var listqvs = HttpHelper.GetList<KTQuayVong>(Configuration.UrlCBApi + "api/KtLogics/GetKTQuayVongGA" + data);
                request.KTQuayVong = new LinkedList<KTQuayVong>();
                request.KTQuayVong = listqvs;
                request.KTLogicTT.Loaibc = " Giờ quay vòng nhỏ hơn 0 hoặc giờ quay vòng lớn hơn 720 phút (12 giờ).";

            }
            else if (kTLogicTT.Loaidon == "1")
            {
                var listdts = HttpHelper.GetList<KTDonThuan>(Configuration.UrlCBApi + "api/KtLogics/GetKTDonThuanGA" + data);
                request.KTDonThuan = new LinkedList<KTDonThuan>();
                request.KTDonThuan = listdts;
                request.KTLogicTT.Loaibc = " Giờ đơn thuần nhỏ hơn 0 hoặc giờ giờ đơn thuần lớn hơn 600 phút (10 giờ).";
            }
            else if (kTLogicTT.Loaidon == "2")
            {
                var listvts = new List<KTVanTocKT>();
                var query = HttpHelper.GetList<KTVanTocKT>(Configuration.UrlCBApi + "api/KtLogics/GetKTVantocKTGA" + data);

                if (query != null)
                {
                    foreach (var vt in query)
                    {
                        vt.VanToc = Math.Round(vt.VanToc, 2);
                        if (vt.CongTacID == 1 && (vt.VanToc < 35 || vt.VanToc > 65))
                        {
                            listvts.Add(vt);
                        }
                        if (vt.CongTacID >= 2 && vt.CongTacID <= 3 && (vt.VanToc < 30 || vt.VanToc > 65))
                        {
                            listvts.Add(vt);
                        }
                        if (vt.CongTacID == 4 && (vt.VanToc < 20 || vt.VanToc > 60))
                        {
                            listvts.Add(vt);
                        }
                        if (vt.CongTacID >= 5 && vt.CongTacID <= 7 && (vt.VanToc < 8 || vt.VanToc > 50))
                        {
                            listvts.Add(vt);
                        }
                        if (vt.CongTacID == 10 && (vt.VanToc < 30 || vt.VanToc > 70))
                        {
                            listvts.Add(vt);
                        }
                    }
                    request.KTVanTocKT = new LinkedList<KTVanTocKT>();
                    request.KTVanTocKT = listvts;
                    request.KTLogicTT.Loaibc = " Vận tốc kỹ thuật km/giờ. Đơn,thoi,đá (5,6,7) <8 và >50. Hàng thường (4) <20 và >60. Hàng nhanh80 (10) <30 và >70. Khách ĐP (2) <30 và >65. Khách TN (1) <35 và >65.";
                }
            }
            else if (kTLogicTT.Loaidon == "3")
            {
                var listkbs = HttpHelper.GetList<KTDungKB>(Configuration.UrlCBApi + "api/KtLogics/GetKTDungKBGA" + data);
                request.KTDungKB = new LinkedList<KTDungKB>();
                request.KTDungKB = listkbs;
                request.KTLogicTT.Loaibc = " Giờ dừng kho bãi nhỏ hơn 0 là trùng cơ báo, lớn hơn 1440 phút (24 giờ) là mất cơ báo hoặc vào cấp sửa chữa.";
            }
            else if (kTLogicTT.Loaidon == "4")
            {
                var listnls = HttpHelper.GetList<KTNhienLieu>(Configuration.UrlCBApi + "api/KtLogics/GetKTNhienLieuGA" + data);
                request.KTNhienLieu = new LinkedList<KTNhienLieu>();
                request.KTNhienLieu = listnls;
                request.KTLogicTT.Loaibc = " Nhiên liệu cùng một đầu máy giao ban trước không trùng khớp với nhận ban sau.";
            }
            return request;
        }

        public IActionResult ExcelReport_KTLogicga(KTLogicTT kTLogicTT)
        {
            TTKTLogic request = new TTKTLogic();
            request = KTLogicga_Napdl(kTLogicTT);
            XLWorkbook workbook = new XLWorkbook();
            DataTable dt = new DataTable();
            string fileName = string.Empty;
            if (kTLogicTT.Loaidon == "0")
            {
                List<KTQuayVong> litQV = request.KTQuayVong.ToList();
                dt = CoBaoDAO.ToDataTable<KTQuayVong>(litQV);
                fileName = "Quayvongga.xlsx";
            }
            else if (kTLogicTT.Loaidon == "1")
            {
                List<KTDonThuan> litDT = request.KTDonThuan.ToList();
                dt = CoBaoDAO.ToDataTable<KTDonThuan>(litDT);
                fileName = "Donthuanga.xlsx";
            }
            else if (kTLogicTT.Loaidon == "2")
            {
                List<KTVanTocKT> litVT = request.KTVanTocKT.ToList();
                dt = CoBaoDAO.ToDataTable<KTVanTocKT>(litVT);
                fileName = "Vantocga.xlsx";
            }
            else if (kTLogicTT.Loaidon == "3")
            {
                List<KTDungKB> litKB = request.KTDungKB.ToList();
                dt = CoBaoDAO.ToDataTable<KTDungKB>(litKB);
                fileName = "Khobaiga.xlsx";
            }
            else if (kTLogicTT.Loaidon == "4")
            {
                List<KTNhienLieu> litNL = request.KTNhienLieu.ToList();
                dt = CoBaoDAO.ToDataTable<KTNhienLieu>(litNL);
                fileName = "Nhienlieuga.xlsx";
            }
            workbook.Worksheets.Add(dt, "Sheet1");
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            MemoryStream memoryStream = new MemoryStream();
            workbook.SaveAs((Stream)memoryStream);
            memoryStream.Seek(0L, SeekOrigin.Begin);

            var content = memoryStream.ToArray();
            return File(content, contentType, fileName);
        }
        #endregion

        #region CBGA Xuất cơ báo
        public IActionResult XCobaoga()
        {
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep_Thieu();

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

            List<SelectListItem> loaidon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Cơ báo" },
                new SelectListItem { Value = "1", Text = "Cơ báo chi tiết" },
                new SelectListItem { Value = "2", Text = "Cơ báo dầu mỡ" },
            };

            List<SelectListItem> thang = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                thang.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }

            List<SelectListItem> nam = new List<SelectListItem>();
            int year = DateTime.Today.Year;
            for (int i = year - 10; i <= year + 1; i++)
            {
                nam.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }

            TTXCobaoga request = new TTXCobaoga();
            XCobaodtTT dttt = new XCobaodtTT();
            dttt.Thang = DateTime.Today.Month;
            dttt.Nam = DateTime.Today.Year;
            request.XCobaodtTT = dttt;
            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.loaimay = loaimay;
            ViewBag.loaidon = loaidon;
            ViewBag.thang = thang;
            ViewBag.nam = nam;
            return View(request);
        }
        [HttpPost]
        public IActionResult XCobaoga(XCobaodtTT xCobaodtTT)
        {
            TTXCobaoga request = new TTXCobaoga();
            request = XCobaoga_Napdl(xCobaodtTT);
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep_Thieu();

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

            List<SelectListItem> loaidon = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Cơ báo" },
                new SelectListItem { Value = "1", Text = "Cơ báo chi tiết" },
                new SelectListItem { Value = "2", Text = "Cơ báo dầu mỡ" },
            };

            List<SelectListItem> thang = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                thang.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }

            List<SelectListItem> nam = new List<SelectListItem>();
            int year = DateTime.Today.Year;
            for (int i = year - 10; i <= year + 1; i++)
            {
                nam.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }

            ViewBag.xinghiep = xinghiep;
            ViewBag.loaimay = loaimay;
            ViewBag.loaidon = loaidon;
            ViewBag.thang = thang;
            ViewBag.nam = nam;
            return View(request);

        }
        private TTXCobaoga XCobaoga_Napdl(XCobaodtTT xCobaodtTT)
        {
            TTXCobaoga request = new TTXCobaoga();
            request.XCobaodtTT = new XCobaodtTT();
            //Nạp dữ liệu
            string data = "thangDT=" + xCobaodtTT.Thang;
            data += "&namDT=" + xCobaodtTT.Nam;
            data += "&DonVi=" + xCobaodtTT.Xinghiep;
            data += "&LoaiMay=" + xCobaodtTT.Loaimay;
            if (xCobaodtTT.Loaidon == "0")
            {
                var obj = HttpHelper.GetList<XCoBaoGA>(Configuration.UrlCBApi + "api/CoBaoGAs/GetXCoBaoGA?" + data);
                if (xCobaodtTT.Xinghiep == "HN")
                {
                    foreach (XCoBaoGA ct in obj)
                    {
                        ct.SoCB = "'" + ct.SoCB;
                        ct.TaiXe1ID = string.IsNullOrEmpty(ct.TaiXe1ID) ? ct.TaiXe1ID : "'" + ct.TaiXe1ID;
                        ct.TaiXe2ID = string.IsNullOrEmpty(ct.TaiXe2ID) ? ct.TaiXe2ID : "'" + ct.TaiXe2ID;
                        ct.TaiXe3ID = string.IsNullOrEmpty(ct.TaiXe3ID) ? ct.TaiXe3ID : "'" + ct.TaiXe3ID;
                        ct.PhoXe1ID = string.IsNullOrEmpty(ct.PhoXe1ID) ? ct.PhoXe1ID : "'" + ct.PhoXe1ID;
                        ct.PhoXe2ID = string.IsNullOrEmpty(ct.PhoXe2ID) ? ct.PhoXe2ID : "'" + ct.PhoXe2ID;
                        ct.PhoXe3ID = string.IsNullOrEmpty(ct.PhoXe3ID) ? ct.PhoXe3ID : "'" + ct.PhoXe3ID;
                        ct.MaCB = "'" + ct.MaCB;
                        ct.SHDT = string.IsNullOrEmpty(ct.SHDT) ? ct.SHDT : "'" + ct.SHDT;
                    }
                }
                request.XCoBaoGA = new List<XCoBaoGA>();
                request.XCoBaoGA = obj;
                request.XCobaodtTT.Loaibc = "Xuất dữ liệu cơ báo điện tử.";

            }
            else if (xCobaodtTT.Loaidon == "1")
            {
                var obj = HttpHelper.GetList<XCoBaoGACT>(Configuration.UrlCBApi + "api/CoBaoGAs/GetXCoBaoGACT?" + data);
                if (xCobaodtTT.Xinghiep == "HN")
                {
                    foreach (XCoBaoGACT ct in obj)
                    {
                        ct.MacTauID = string.IsNullOrEmpty(ct.MacTauID) ? ct.MacTauID : "'" + ct.MacTauID;
                    }
                }
                request.XCoBaoGACT = new List<XCoBaoGACT>();
                request.XCoBaoGACT = obj;
                request.XCobaodtTT.Loaibc = "Xuất dữ liệu cơ báo điện tử chi tiết.";
            }
            else if (xCobaodtTT.Loaidon == "2")
            {
                var obj = HttpHelper.GetList<XCoBaoGADM>(Configuration.UrlCBApi + "api/CoBaoGAs/GetXCoBaoGADM?" + data);
                request.XCoBaoGADM = new List<XCoBaoGADM>();
                request.XCoBaoGADM = obj;
                request.XCobaodtTT.Loaibc = "Xuất dữ liệu cơ báo điện tử dầu mỡ.";
            }
            return request;
        }

        public IActionResult ExcelReport_XCobaoga(XCobaodtTT xCobaodtTT)
        {
            TTXCobaoga request = new TTXCobaoga();
            request = XCobaoga_Napdl(xCobaodtTT);
            XLWorkbook workbook = new XLWorkbook();
            DataTable dt = new DataTable();
            string fileName = string.Empty;
            if (xCobaodtTT.Loaidon == "0")
            {
                List<XCoBaoGA> litCB = request.XCoBaoGA.ToList();
                dt = CoBaoDAO.ToDataTable<XCoBaoGA>(litCB);
                fileName = "Cobaoga.xlsx";
            }
            else if (xCobaodtTT.Loaidon == "1")
            {
                List<XCoBaoGACT> litCT = request.XCoBaoGACT.ToList();
                dt = CoBaoDAO.ToDataTable<XCoBaoGACT>(litCT);
                fileName = "Cobaogact.xlsx";
            }
            else if (xCobaodtTT.Loaidon == "2")
            {
                List<XCoBaoGADM> litDM = request.XCoBaoGADM.ToList();
                dt = CoBaoDAO.ToDataTable<XCoBaoGADM>(litDM);
                fileName = "Cobaogadm.xlsx";
            }
            workbook.Worksheets.Add(dt, "Sheet1");
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            MemoryStream memoryStream = new MemoryStream();
            workbook.SaveAs((Stream)memoryStream);
            memoryStream.Seek(0L, SeekOrigin.Begin);

            var content = memoryStream.ToArray();
            return File(content, contentType, fileName);
        }
        #endregion

        #region CBGA Xuất đoạn thống
        public IActionResult XDoanthongga()
        {
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep_Thieu();

            List<SelectListItem> thang = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                thang.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }

            List<SelectListItem> nam = new List<SelectListItem>();
            int year = DateTime.Today.Year;
            for (int i = year - 10; i <= year + 1; i++)
            {
                nam.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }

            TTXDoanthongdt request = new TTXDoanthongdt();
            XCobaodtTT dttt = new XCobaodtTT();
            dttt.Thang = DateTime.Today.Month;
            dttt.Nam = DateTime.Today.Year;
            request.XCobaodtTT = dttt;
            //assigning SelectListItem to view Bag
            ViewBag.xinghiep = xinghiep;
            ViewBag.thang = thang;
            ViewBag.nam = nam;
            return View(request);
        }
        [HttpPost]
        public IActionResult XDoanthongga(XCobaodtTT xCobaodtTT)
        {
            TTXDoanthongdt request = new TTXDoanthongdt();
            request = XDoanthongga_Napdl(xCobaodtTT);
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> xinghiep = NapViewBag_Xinghiep_Thieu();

            List<SelectListItem> thang = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                thang.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }

            List<SelectListItem> nam = new List<SelectListItem>();
            int year = DateTime.Today.Year;
            for (int i = year - 10; i <= year + 1; i++)
            {
                nam.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }

            ViewBag.xinghiep = xinghiep;
            ViewBag.thang = thang;
            ViewBag.nam = nam;
            return View(request);

        }
        private TTXDoanthongdt XDoanthongga_Napdl(XCobaodtTT xCobaodtTT)
        {
            TTXDoanthongdt request = new TTXDoanthongdt();
            request.XCobaodtTT = new XCobaodtTT();
            //Nạp dữ liệu
            string data = "&maDV=" + xCobaodtTT.Xinghiep;
            data += "&thangDT=" + xCobaodtTT.Thang;
            data += "&namDT=" + xCobaodtTT.Nam;
            if (xCobaodtTT.Xinghiep == "YV")
            {
                var obj = HttpHelper.GetList<YVXuatDT>(Configuration.UrlCBApi + "api/YenViens/YVGetXuatDTGA?" + data);
                if (obj.Count <= 0)
                {
                    throw new Exception("Không có dữ liệu đoạn thống.");
                }
                var listDT = (from dt in obj
                              group dt by new
                              {
                                  dt.SOCB,
                                  dt.LMAY,
                                  dt.DMAY,
                                  dt.SDB1,
                                  dt.TEN1,
                                  dt.MTAU,
                                  dt.CTAC,
                                  dt.TCHAT,
                                  dt.MDOAN,
                                  dt.KDOAN,
                                  dt.SLBT,
                                  dt.SLLH,
                                  dt.SLBS,
                                  dt.SLPT,
                                  dt.NLANH,
                                  dt.PDOAN,
                                  dt.DAYCB,
                                  dt.DGKB,
                                  dt.SLRK,
                                  dt.CTY,
                                  dt.DTAU
                              } into g
                              select new YVXuatDT
                              {
                                  SOCB = g.Key.SOCB,
                                  LMAY = g.Key.LMAY,
                                  DMAY = g.Key.DMAY,
                                  SDB1 = g.Key.SDB1,
                                  TEN1 = g.Key.TEN1,
                                  SDB2 = g.FirstOrDefault().SOCB,
                                  TEN2 = g.FirstOrDefault().TEN2,
                                  SDB3 = g.FirstOrDefault().SDB3,
                                  TEN3 = g.FirstOrDefault().TEN3,
                                  MTAU = g.Key.MTAU,
                                  CTAC = g.Key.CTAC,
                                  TCHAT = g.Key.TCHAT,
                                  MDOAN = g.Key.MDOAN,
                                  KDOAN = g.Key.KDOAN,
                                  SLBT = g.Key.SLBT,
                                  SLLH = g.Key.SLLH,
                                  SLBS = g.Key.SLBS,
                                  SLTT = g.Sum(x => x.SLTT),
                                  SLTC = g.Sum(x => x.SLTC),
                                  SLPT = g.Key.SLPT,
                                  NLANH = g.Key.NLANH,
                                  GAXP = g.FirstOrDefault().GAXP,
                                  DAYCB = g.Key.DAYCB,
                                  DGKB = g.Key.DGKB,
                                  DGDM = g.Sum(x => x.DGDM),
                                  DGDN = g.Sum(x => x.DGDN),
                                  DGKM = g.Sum(x => x.DGKM),
                                  DGKN = g.Sum(x => x.DGKN),
                                  DGQD = g.Sum(x => x.DGQD),
                                  GIQV = g.Sum(x => x.GIQV),
                                  GILH = g.Sum(x => x.GILH),
                                  GIDT = g.Sum(x => x.GIDT),
                                  DGXP = g.Sum(x => x.DGXP),
                                  DGDD = g.Sum(x => x.DGDD),
                                  DGCC = g.Sum(x => x.DGCC),
                                  DNXP = g.Sum(x => x.DNXP),
                                  DNDD = g.Sum(x => x.DNDD),
                                  DNCC = g.Sum(x => x.DNCC),
                                  SLRK = g.Key.SLRK,
                                  KMCH = g.Sum(x => x.KMCH),
                                  KMDW = g.Sum(x => x.KMDW),
                                  KMGH = g.Sum(x => x.KMGH),
                                  KMDY = g.Sum(x => x.KMDY),
                                  TKCH = g.Sum(x => x.TKCH),
                                  TKDW = g.Sum(x => x.TKDW),
                                  TKGH = g.Sum(x => x.TKGH),
                                  TKDY = g.Sum(x => x.TKDY),
                                  L_DC = g.FirstOrDefault().L_DC,
                                  L_TL = g.FirstOrDefault().L_TL,
                                  L_GT = g.FirstOrDefault().L_GT,
                                  T_DC = g.FirstOrDefault().T_DC,
                                  T_TL = g.FirstOrDefault().T_TL,
                                  T_GT = g.FirstOrDefault().T_GT,
                                  C_DC = g.FirstOrDefault().C_DC,
                                  C_TL = g.FirstOrDefault().C_TL,
                                  C_GT = g.FirstOrDefault().C_GT,
                                  SLRKM = g.Sum(x => x.SLRKM),
                                  SLRKN = g.Sum(x => x.SLRKN),
                                  CTY = g.Key.CTY,
                                  DAY_LT = g.FirstOrDefault().DAY_LT,
                                  DTAU = g.Key.DTAU
                              }).ToList();
                YVXuatDT ctOld = new YVXuatDT();
                foreach (YVXuatDT ct in listDT)
                {
                    ct.DMAY = ct.DMAY.Split('-')[1];
                    if (!string.IsNullOrWhiteSpace(ct.NLANH))
                    {
                        if (ct.NLANH == "TFLCA") ct.NLANH = "LC";
                        if (ct.NLANH == "TFXGA") ct.NLANH = "XG";
                        if (ct.NLANH == "TFYBI") ct.NLANH = "YB";
                        if (ct.NLANH == "TFVTR") ct.NLANH = "VT";
                        if (ct.NLANH == "TFLTH") ct.NLANH = "LT";
                        if (ct.NLANH == "TFMKH") ct.NLANH = "MK";
                        if (ct.NLANH == "TFDDA") ct.NLANH = "DD";
                        if (ct.NLANH == "TFYVI") ct.NLANH = "YV";
                        if (ct.NLANH == "TFHPH") ct.NLANH = "HP";
                        if (ct.NLANH == "TFHNO") ct.NLANH = "HN";
                        if (ct.NLANH == "TFGBA") ct.NLANH = "GB";
                        if (ct.NLANH == "TFNBI") ct.NLANH = "NB";
                        if (ct.NLANH == "TFTHO") ct.NLANH = "TH";
                        if (ct.NLANH == "TFVIN") ct.NLANH = "VI";
                        if (ct.NLANH == "TFPUT") ct.NLANH = "PT";
                        if (ct.NLANH == "TFDHO") ct.NLANH = "DH";
                        if (ct.NLANH == "TFHUE") ct.NLANH = "HU";
                        if (ct.NLANH == "TFDNA") ct.NLANH = "DN";
                        if (ct.NLANH == "TFQNG") ct.NLANH = "QN";
                        if (ct.NLANH == "TFDTR") ct.NLANH = "DT";
                        if (ct.NLANH == "TFNTR") ct.NLANH = "NT";
                        if (ct.NLANH == "TFBTH") ct.NLANH = "BT";
                        if (ct.NLANH == "TFSGO") ct.NLANH = "SG";
                        if (ct.NLANH == "TFSOT") ct.NLANH = "ST";
                    }
                    if (ct.SOCB == ctOld.SOCB)
                    {

                        ct.SLBT = 0;
                        ct.SLLH = 0;
                        ct.SLBS = 0;
                        ct.SLPT = 0;
                        ct.NLANH = string.Empty;
                        ct.DGKB = 0;
                        ct.SLRK = 0;
                    }
                    if (ct.LMAY == "D10H") ct.LMAY = "D10H-CAT";
                    if (ct.CTAC == 2) ct.CTAC = 1;
                    if (ct.CTAC == 3) ct.CTAC = 2;
                    if (ct.CTAC == 4) ct.CTAC = 3;
                    if (ct.CTAC == 5) ct.CTAC = 4;
                    if (ct.CTAC == 6) ct.CTAC = 5;
                    if (ct.CTAC == 7) ct.CTAC = 6;
                    if (ct.CTAC == 8 || ct.CTAC == 9) ct.CTAC = 7;
                    if (ct.TCHAT == 5) ct.TCHAT = 3;
                    if (ct.TCHAT == 3 || ct.TCHAT == 4 || ct.TCHAT == 6) ct.TCHAT = 5;
                    if (ct.CTAC == 5)
                    {
                        if (ct.KDOAN == "DM-DD-di" || ct.KDOAN == "DM-DD-ve" || ct.KDOAN == "DM-ND-di" || ct.KDOAN == "DM-ND-ve" ||
                            ct.KDOAN == "ND-DD-di" || ct.KDOAN == "ND-DD-ve")
                            ct.CTACP = "DMDD";
                        if (ct.KDOAN == "LC-SY-di" || ct.KDOAN == "LC-SY-ve")
                            ct.CTACP = "LCSY";
                        if (ct.KDOAN == "CL-UB-di" || ct.KDOAN == "CL-UB-ve")
                            ct.CTACP = "CLCT";
                    }
                    if (ct.CTAC == 7 && ct.GAXP == "Lâm Thao") ct.CTACP = "DONLT";
                    ct.CTY = "1";
                    if (!string.IsNullOrWhiteSpace(ct.MTAU))
                    {
                        string cty = ct.MTAU.Substring(0, 1);
                        if (cty == "s" || cty == "S")
                            ct.CTY = "2";
                        if (cty == "a" || cty == "A")
                            ct.CTY = "5";
                    }
                    ctOld = ct;
                }

                request.YVXuatDT = new List<YVXuatDT>();
                request.YVXuatDT = listDT;
                request.XCobaodtTT.Loaibc = "Xuất dữ liệu đoạn thống điện tử Yên Viên.";
            }
            if (xCobaodtTT.Xinghiep == "HN")
            {
                var obj = HttpHelper.GetList<HNXuatDT>(Configuration.UrlCBApi + "api/HaNois/HNGetXuatDTGA?" + data).OrderBy(x => x.daycb).ThenBy(x => x.socb).ThenBy(x => x.mtau).ThenBy(x => x.dayxp).ToList();
                if (obj.Count <= 0)
                {
                    throw new Exception("Không có dữ liệu đoạn thống.");
                }
                var listDT = (from dt in obj
                              group dt by new
                              {
                                  dt.socb,
                                  dt.lmay,
                                  dt.dmay,
                                  dt.sdb1,
                                  dt.mtau,
                                  dt.ctac,
                                  dt.tchat,
                                  dt.kdoan,
                                  dt.pdoan,
                                  dt.daycb,
                                  dt.mghep,
                                  dt.ThangDT,
                                  dt.NamDT
                              } into g
                              select new HNXuatDT
                              {
                                  socb = g.Key.socb,
                                  lmay = g.Key.lmay,
                                  dmay = g.Key.dmay,
                                  sdb1 = g.Key.sdb1,
                                  ten1 = g.FirstOrDefault().ten1,
                                  sdb2 = g.FirstOrDefault().sdb2,
                                  ten2 = g.FirstOrDefault().ten2,
                                  sdb3 = g.FirstOrDefault().sdb3,
                                  ten3 = g.FirstOrDefault().ten3,
                                  mtau = g.Key.mtau,
                                  ctac = g.Key.ctac,
                                  tchat = g.Key.tchat,
                                  kdoan = g.Key.kdoan,
                                  slbt = g.FirstOrDefault().slbt,
                                  sllh = g.FirstOrDefault().sllh,
                                  slbs = g.FirstOrDefault().slbs,
                                  sltt = g.Sum(x => x.sltt),
                                  sltc = g.Sum(x => x.sltc),
                                  slpt = g.FirstOrDefault().slpt,
                                  nlanh = g.FirstOrDefault().nlanh,
                                  gaxp = g.FirstOrDefault().gaxp,
                                  daycb = g.Key.daycb,
                                  dgkb = g.FirstOrDefault().dgkb,
                                  dgdm = g.Sum(x => x.dgdm),
                                  dgdn = g.Sum(x => x.dgdn),
                                  dgkm = g.Sum(x => x.dgkm),
                                  dgkn = g.Sum(x => x.dgkn),
                                  dgqd = g.Sum(x => x.dgqd),
                                  giqv = g.Sum(x => x.giqv),
                                  gilh = g.Sum(x => x.gilh),
                                  gidt = g.Sum(x => x.gidt),
                                  dgxp = g.Sum(x => x.dgxp),
                                  dgdd = g.Sum(x => x.dgdd),
                                  dgcc = g.Sum(x => x.dgcc),
                                  dnxp = g.Sum(x => x.dnxp),
                                  dndd = g.Sum(x => x.dndd),
                                  dncc = g.Sum(x => x.dncc),
                                  slrk = g.FirstOrDefault().slrk,
                                  kmch = g.Sum(x => x.kmch),
                                  kmdw = g.Sum(x => x.kmdw),
                                  kmgh = g.Sum(x => x.kmgh),
                                  kmdy = g.Sum(x => x.kmdy),
                                  tkch = g.Sum(x => x.tkch),
                                  tkdw = g.Sum(x => x.tkdw),
                                  tkgh = g.Sum(x => x.tkgh),
                                  tkdy = g.Sum(x => x.tkdy),
                                  l_dc = g.FirstOrDefault().l_dc,
                                  l_tl = g.FirstOrDefault().l_tl,
                                  l_gt = g.FirstOrDefault().l_gt,
                                  t_dc = g.FirstOrDefault().t_dc,
                                  t_tl = g.FirstOrDefault().t_tl,
                                  t_gt = g.FirstOrDefault().t_gt,
                                  c_dc = g.FirstOrDefault().c_dc,
                                  c_tl = g.FirstOrDefault().c_tl,
                                  c_gt = g.FirstOrDefault().c_gt,
                                  slrkm = g.FirstOrDefault().slrkm,
                                  slrkn = g.FirstOrDefault().slrkn,
                                  dayxp = g.FirstOrDefault().dayxp,
                                  dtau = g.FirstOrDefault().dtau,
                                  mghep = g.Key.mghep,
                                  ThangDT = g.Key.ThangDT,
                                  NamDT = g.Key.NamDT
                              }).ToList();
                HNXuatDT ctOld = new HNXuatDT();
                foreach (HNXuatDT ct in listDT)
                {
                    ct.dmay = ct.dmay.Split('-')[1];
                    ct.socb = "'" + ct.socb;
                    ct.sdb1 = string.IsNullOrEmpty(ct.sdb1) ? ct.sdb1 : "'" + ct.sdb1;
                    ct.sdb2 = string.IsNullOrEmpty(ct.sdb2) ? ct.sdb2 : "'" + ct.sdb2;
                    ct.sdb3 = string.IsNullOrEmpty(ct.sdb3) ? ct.sdb3 : "'" + ct.sdb3;
                    ct.mtau = string.IsNullOrEmpty(ct.mtau) ? ct.mtau : "'" + ct.mtau;
                    if (!string.IsNullOrWhiteSpace(ct.nlanh))
                    {
                        if (ct.nlanh == "TFHNO") ct.nlanh = "HN";
                        if (ct.nlanh == "TFHPH") ct.nlanh = "HP";
                        if (ct.nlanh == "TFGBA") ct.nlanh = "GB";
                        if (ct.nlanh == "TFNBI") ct.nlanh = "NB";
                        if (ct.nlanh == "TFDHO") ct.nlanh = "DH";
                        if (ct.nlanh == "TFDNA") ct.nlanh = "DN";
                        if (ct.nlanh == "TFDTR") ct.nlanh = "DT";
                        if (ct.nlanh == "TFNTR") ct.nlanh = "NT";
                        if (ct.nlanh == "TFBTH") ct.nlanh = "BT";
                        if (ct.nlanh == "TFSGO") ct.nlanh = "SG";
                        if (ct.nlanh == "TFSOT") ct.nlanh = "ST";
                    }
                    if (ct.socb == ctOld.socb)
                    {

                        ct.slbt = 0;
                        ct.sllh = 0;
                        ct.slbs = 0;
                        ct.slpt = 0;
                        ct.dgkb = 0;
                        ct.slrk = 0;
                    }
                    ctOld = ct;
                }

                request.HNXuatDT = new List<HNXuatDT>();
                request.HNXuatDT = listDT;
                request.XCobaodtTT.Loaibc = "Xuất dữ liệu đoạn thống điện tử Hà Nội.";
            }
            if (xCobaodtTT.Xinghiep == "VIN")
            {
                var obj = HttpHelper.GetList<VIXuatDT>(Configuration.UrlCBApi + "api/Vinhs/VIGetXuatDTGA?" + data);
                if (obj.Count <= 0)
                {
                    throw new Exception("Không có dữ liệu đoạn thống.");
                }
                var listDT = (from dt in obj
                              group dt by new
                              {
                                  dt.socb,
                                  dt.lmay,
                                  dt.dmay,
                                  dt.sdb1,
                                  dt.ten1,
                                  dt.sdb2,
                                  dt.ten2,
                                  dt.sdb3,
                                  dt.ten3,
                                  dt.sdb4,
                                  dt.ten4,
                                  dt.tau,
                                  dt.cty,
                                  dt.ctac,
                                  dt.ctacp,
                                  dt.tchat,
                                  dt.kdoan,
                                  dt.slbt,
                                  dt.sll1,
                                  dt.sll2,
                                  dt.slsd,
                                  dt.slbs,
                                  dt.sltt,
                                  dt.sltc,
                                  dt.slpt,
                                  dt.kho1,
                                  dt.nlieu,
                                  dt.thnl,
                                  dt.thbt,
                                  dt.phnl,
                                  dt.phpt,
                                  dt.pdoan,
                                  dt.gaxp,
                                  dt.daycb,
                                  dt.dgkb,
                                  dt.dgdm,
                                  dt.dgdn,
                                  dt.dgkm,
                                  dt.dgkn,
                                  dt.dgqd,
                                  dt.giqv,
                                  dt.gilh,
                                  dt.gidt,
                                  dt.dgxp,
                                  dt.dgdd,
                                  dt.dgcc,
                                  dt.dnxp,
                                  dt.dndd,
                                  dt.dncc,
                                  dt.slrk,
                                  dt.kmch,
                                  dt.kmdw,
                                  dt.kmgh,
                                  dt.kmdy,
                                  dt.tkch,
                                  dt.tkdw,
                                  dt.tkgh,
                                  dt.tkdy,
                                  dt.slrkm,
                                  dt.slrkn,
                                  dt.tgtnm,
                                  dt.tgtnn,
                                  dt.ThangDT,
                                  dt.NamDT
                              } into g
                              select new VIXuatDT
                              {
                                  socb = g.Key.socb,
                                  lmay = g.Key.lmay,
                                  dmay = g.Key.dmay,
                                  sdb1 = g.Key.sdb1,
                                  ten1 = g.Key.ten1,
                                  sdb2 = g.Key.sdb2,
                                  ten2 = g.Key.ten2,
                                  sdb3 = g.Key.sdb3,
                                  ten3 = g.Key.ten3,
                                  sdb4 = g.Key.sdb4,
                                  ten4 = g.Key.ten4,
                                  tau = g.Key.tau,
                                  cty = g.Key.cty,
                                  ctac = g.Key.ctac,
                                  tchat = g.Key.tchat,
                                  kdoan = g.Key.kdoan,
                                  slbt = g.Key.slbt,
                                  slbs = g.Key.slbs,
                                  sltt = g.Key.sltt,
                                  sltc = g.Key.sltc,
                                  slpt = g.Key.slpt,
                                  kho1 = g.Key.kho1,
                                  gaxp = g.Key.gaxp,
                                  daycb = g.Key.daycb,
                                  dgkb = g.Key.dgkb,
                                  dgdm = g.Key.dgdm,
                                  dgdn = g.Key.dgdn,
                                  dgkm = g.Key.dgkm,
                                  dgkn = g.Key.dgkn,
                                  dgqd = g.Key.dgqd,
                                  giqv = g.Key.giqv,
                                  gilh = g.Key.gilh,
                                  gidt = g.Key.gidt,
                                  dgxp = g.Key.dgxp,
                                  dgdd = g.Key.dgdd,
                                  dgcc = g.Key.dgcc,
                                  dnxp = g.Key.dnxp,
                                  dndd = g.Key.dndd,
                                  dncc = g.Key.dncc,
                                  slrk = g.Key.slrk,
                                  kmch = g.Key.kmch,
                                  kmdw = g.Key.kmdw,
                                  kmgh = g.Key.kmgh,
                                  kmdy = g.Key.kmdy,
                                  tkch = g.Key.tkch,
                                  tkdw = g.Key.tkdw,
                                  tkgh = g.Key.tkgh,
                                  tkdy = g.Key.tkdy,
                                  slrkm = g.Key.slrkm,
                                  slrkn = g.Key.slrkn,
                                  ThangDT = g.Key.ThangDT,
                                  NamDT = g.Key.NamDT
                              }).ToList();
                VIXuatDT ctOld = new VIXuatDT();
                foreach (VIXuatDT ct in listDT)
                {
                    ct.dmay = ct.dmay.Split('-')[1];
                    //ct.socb = "'" + ct.socb;
                    //ct.sdb1 = string.IsNullOrEmpty(ct.sdb1) ? ct.sdb1 : "'" + ct.sdb1;
                    //ct.sdb2 = string.IsNullOrEmpty(ct.sdb2) ? ct.sdb2 : "'" + ct.sdb2;
                    //ct.sdb3 = string.IsNullOrEmpty(ct.sdb3) ? ct.sdb3 : "'" + ct.sdb3;
                    if (!string.IsNullOrWhiteSpace(ct.kho1))
                    {
                        if (ct.kho1 == "TFHNO") ct.kho1 = "HN";
                        if (ct.kho1 == "TFHPH") ct.kho1 = "HP";
                        if (ct.kho1 == "TFGBA") ct.kho1 = "GB";
                        if (ct.kho1 == "TFNBI") ct.kho1 = "NB";
                        if (ct.kho1 == "TFDHO") ct.kho1 = "DH";
                        if (ct.kho1 == "TFDNA") ct.kho1 = "DN";
                        if (ct.kho1 == "TFDTR") ct.kho1 = "DT";
                        if (ct.kho1 == "TFNTR") ct.kho1 = "NT";
                        if (ct.kho1 == "TFBTH") ct.kho1 = "BT";
                        if (ct.kho1 == "TFSGO") ct.kho1 = "SG";
                        if (ct.kho1 == "TFSOT") ct.kho1 = "ST";
                    }
                    if (ct.socb == ctOld.socb)
                    {

                        ct.slbt = 0;
                        ct.slbs = 0;
                        ct.slpt = 0;
                        ct.slrk = 0;
                    }
                    ctOld = ct;
                }

                request.VIXuatDT = new List<VIXuatDT>();
                request.VIXuatDT = listDT;
                request.XCobaodtTT.Loaibc = "Xuất dữ liệu đoạn thống điện tử Vinh.";
            }
            if (xCobaodtTT.Xinghiep == "DN")
            {
                var obj = HttpHelper.GetList<DNXuatDT>(Configuration.UrlCBApi + "api/DaNangs/DNGetXuatDTGA?" + data).OrderBy(x => x.giodi).ThenBy(x => x.socb).ThenBy(x => x.mactau).ThenBy(x => x.ngayxp).ToList();
                if (obj.Count <= 0)
                {
                    throw new Exception("Không có dữ liệu đoạn thống.");
                }
                var listDT = (from dt in obj
                              group dt by new
                              {
                                  dt.socb,
                                  dt.madm,
                                  dt.makd,
                                  dt.mactau,
                                  dt.matc,
                                  dt.ThangDT,
                                  dt.NamDT
                              } into g
                              select new DNXuatDT
                              {
                                  socb = g.Key.socb,
                                  madm = g.Key.madm,
                                  mact = g.FirstOrDefault().mact,
                                  makd = g.Key.makd,
                                  ngaydi = g.FirstOrDefault().ngaydi,
                                  mactau = g.Key.mactau,
                                  matc = g.Key.matc,
                                  solanrk = g.FirstOrDefault().solanrk,
                                  km = g.Sum(x => x.km),
                                  tan = g.Sum(x => x.km) > 0 ? g.Sum(x => x.tkm) / g.Sum(x => x.km) : 0,
                                  tkm = g.Sum(x => x.tkm),
                                  donxp = g.Sum(x => x.donxp),
                                  dondd = g.Sum(x => x.dondd),
                                  doncc = g.Sum(x => x.doncc),
                                  dungdd = g.Sum(x => x.dungdd),
                                  dungxp = g.Sum(x => x.dungxp),
                                  dungcc = g.Sum(x => x.dungcc),
                                  lh = g.Sum(x => x.lh),
                                  qvlh = g.Sum(x => x.qvlh),
                                  dungdn = g.Sum(x => x.dungdn),
                                  dungdm = g.Sum(x => x.dungdm),
                                  nltc = g.Sum(x => x.nltc),
                                  nltt = g.Sum(x => x.nltt),
                                  gaxp = g.FirstOrDefault().gaxp,
                                  ngayxp = g.FirstOrDefault().ngayxp,
                                  ThangDT = g.Key.ThangDT,
                                  NamDT = g.Key.NamDT
                              }).ToList();
                DNXuatDT ctOld = new DNXuatDT();
                foreach (DNXuatDT ct in listDT)
                {
                    ct.madm = ct.madm.Split('-')[1];
                    ct.tan = Math.Round(ct.tan, 2);
                    ct.tanqd = ct.tan;
                    ct.tkmqd = ct.tkm;
                    ct.giodi = ct.ngaydi.ToString("HHmm");
                    ct.dungddnl = ct.dungdd > 30 ? 30 : ct.dungdd;
                    ct.dungxpnl = ct.dungxp > 30 ? 30 : ct.dungxp;
                    ct.dungccnl = ct.dungcc > 30 ? 30 : ct.dungcc;
                    ct.dctlmdmnl = ct.dungdm > 30 ? 30 : ct.dungdm;
                    ct.dctlmdnnl = ct.dungdn > 30 ? 30 : ct.dungdn;
                    ct.nltt15 = ct.nltt;
                    if (ct.socb == ctOld.socb)
                    {
                        ct.solanrk = 0;
                    }
                    ctOld = ct;
                }

                request.DNXuatDT = new List<DNXuatDT>();
                request.DNXuatDT = listDT;
                request.XCobaodtTT.Loaibc = "Xuất dữ liệu đoạn thống điện tử Đà Nẵng.";
            }
            if (xCobaodtTT.Xinghiep == "SG")
            {
                var obj = HttpHelper.GetList<SGXuatDT>(Configuration.UrlCBApi + "api/SaiGons/SGGetXuatDTGA?" + data).OrderBy(x => x.daycb).ThenBy(x => x.socb).ToList();
                if (obj.Count <= 0)
                {
                    throw new Exception("Không có dữ liệu đoạn thống.");
                }
                SGXuatDT ctOld = new SGXuatDT();
                foreach (SGXuatDT ct in obj)
                {
                    ct.dmay = ct.dmay.Split('-')[1];
                    if (!string.IsNullOrWhiteSpace(ct.nlanh))
                    {
                        if (ct.nlanh == "TFGBA") ct.nlanh = "GB";
                        if (ct.nlanh == "TFDNA") ct.nlanh = "DN";
                        if (ct.nlanh == "TFDTR") ct.nlanh = "DT";
                        if (ct.nlanh == "TFNTR") ct.nlanh = "NT";
                        if (ct.nlanh == "TFBTH") ct.nlanh = "BT";
                        if (ct.nlanh == "TFSGO") ct.nlanh = "SG";
                        if (ct.nlanh == "TFSOT") ct.nlanh = "ST";
                    }
                    if (ct.socb == ctOld.socb)
                    {

                        ct.slbt = 0;
                        ct.sllh = 0;
                        ct.slbs = 0;
                        ct.slbs = 0;
                        ct.slsd = 0;
                        ct.dgkb = 0;
                        ct.slrk = 0;
                    }

                    ctOld = ct;
                }

                request.SGXuatDT = new List<SGXuatDT>();
                request.SGXuatDT = obj;
                request.XCobaodtTT.Loaibc = "Xuất dữ liệu đoạn thống điện tử Sài Gòn.";
            }
            return request;
        }

        public IActionResult ExcelReport_XDoanthongga(XCobaodtTT xCobaodtTT)
        {
            TTXDoanthongdt request = new TTXDoanthongdt();
            request = XDoanthongga_Napdl(xCobaodtTT);
            XLWorkbook workbook = new XLWorkbook();
            DataTable dt = new DataTable();
            string fileName = string.Empty;
            if (xCobaodtTT.Xinghiep == "YV")
            {
                List<YVXuatDT> litDT = request.YVXuatDT.ToList();
                dt = CoBaoDAO.ToDataTable<YVXuatDT>(litDT);
                fileName = "DTYenvienga.xlsx";
            }
            else if (xCobaodtTT.Xinghiep == "HN")
            {
                List<HNXuatDT> litDT = request.HNXuatDT.ToList();
                dt = CoBaoDAO.ToDataTable<HNXuatDT>(litDT);
                fileName = "DTHanoiga.xlsx";
            }
            else if (xCobaodtTT.Xinghiep == "VIN")
            {
                List<VIXuatDT> litDT = request.VIXuatDT.ToList();
                dt = CoBaoDAO.ToDataTable<VIXuatDT>(litDT);
                fileName = "DTVinhga.xlsx";
            }
            else if (xCobaodtTT.Xinghiep == "DN")
            {
                List<DNXuatDT> litDT = request.DNXuatDT.ToList();
                dt = CoBaoDAO.ToDataTable<DNXuatDT>(litDT);
                fileName = "DTDanangga.xlsx";
            }
            else if (xCobaodtTT.Xinghiep == "SG")
            {
                List<SGXuatDT> litDT = request.SGXuatDT.ToList();
                dt = CoBaoDAO.ToDataTable<SGXuatDT>(litDT);
                fileName = "DTSaigonga.xlsx";
            }
            workbook.Worksheets.Add(dt, "Sheet1");
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            MemoryStream memoryStream = new MemoryStream();
            workbook.SaveAs((Stream)memoryStream);
            memoryStream.Seek(0L, SeekOrigin.Begin);

            var content = memoryStream.ToArray();
            return File(content, contentType, fileName);
        }
        #endregion
    }
}
