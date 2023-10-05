using ClosedXML.Excel;
using CoBaoWeb.BLLs;
using CoBaoWeb.Models;
using CoBaoWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoBaoWeb.Controllers
{
    [Authorize]
  
    public class DanhMucController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvirnoment;
        public DanhMucController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvirnoment = webHostEnvironment;
        }

        #region DM Lý trình
        public IActionResult Lytrinh()
        {
            TTLytrinh request = new TTLytrinh();
            var tuyenList = HttpHelper.GetList<Tuyen>(Configuration.UrlCBApi + "api/DanhMucs/GetTuyen");
            tuyenList.Add(new Tuyen() { TuyenID = "ALL", TuyenName = "Tất cả các tuyến" });
            tuyenList = tuyenList.OrderBy(f => f.TuyenID).ToList();
            var tuyen = (from t in tuyenList select new SelectListItem { Value = t.TuyenID.ToString(), Text = t.TuyenName }).ToList<SelectListItem>();
            //assigning SelectListItem to view Bag
            ViewBag.tuyen = tuyen;          
            return View(request);
        }
        [HttpPost]
        public IActionResult Lytrinh(TTLytrinh request)
        {
            request.LyTrinh = new List<LyTrinh>();
            request.LyTrinh = Lytrinh_Napdl(request.Tuyentt,request.Gatt);
            //Creating the List of SelectListItem, this list you can bind from the database.
            var tuyenList = HttpHelper.GetList<Tuyen>(Configuration.UrlCBApi + "api/DanhMucs/GetTuyen");
            tuyenList.Add(new Tuyen() { TuyenID = "ALL", TuyenName = "Tất cả các tuyến" });
            tuyenList = tuyenList.OrderBy(f => f.TuyenID).ToList();
            var tuyen = (from t in tuyenList select new SelectListItem { Value = t.TuyenID.ToString(), Text = t.TuyenName }).ToList<SelectListItem>();
            ////assigning SelectListItem to view Bag
            ViewBag.tuyen = tuyen;
            return View(request);

        }
        private List<LyTrinh> Lytrinh_Napdl(string tuyen,string ga)
        {
            string data = "?TuyenID=" + tuyen;
            data += "&TenGa=" + ga;
            return  HttpHelper.GetList<LyTrinh>(Configuration.UrlCBApi + "api/LyTrinhs/GetByTraTim" + data)
               .OrderBy(x => x.TuyenID).ThenBy(x => x.Km).ToList();
         
        }

        public IActionResult ExcelReport_Lytrinh(TTLytrinh request)
        {
            request.LyTrinh = new List<LyTrinh>();
            request.LyTrinh = Lytrinh_Napdl(request.Tuyentt, request.Gatt);
            XLWorkbook workbook = new XLWorkbook();
            DataTable dt = new DataTable();
            string fileName = string.Empty;
            List<LyTrinh> listLT = request.LyTrinh.ToList();
            dt = CoBaoDAO.ToDataTable<LyTrinh>(listLT);
            fileName = "DMLytrinh.xlsx";           
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
