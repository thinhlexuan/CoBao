using CoBaoWeb.Models;
using CoBaoWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoBaoWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {           
            var data = GetUsersPagings();          
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private IEnumerable<DauMay> GetUsersPagings()
        {           
            var sessions = HttpContext.Session.GetString("Token");
            //var request = new UserRequest()
            //{
            //    MaDV = User.FindFirst(ClaimTypes.PrimarySid).Value,
            //    MaNV = User.FindFirst(ClaimTypes.GivenName).Value,
            //    BearerToken = sessions
            //};

            string data = "?maDVSH=TCT";
            data += "&maDVQL=TCT";
            data += "&loaiMay=";
            data += "&dauMay=";
            List<ViewDauMay> listDauMay = HttpHelper.GetList<ViewDauMay>(Configuration.UrlCBApi + "api/DauMays/GetViewDauMay" + data,sessions).Where(x=>x.NgayHL<=DateTime.Today)
                .OrderBy(x => x.LoaiMayID).ThenBy(x => x.DauMayID).ThenByDescending(x=>x.NgayHL).ToList();
            var listDauMayGRDM= (from x in listDauMay
                               group x by new { x.LoaiMayID,x.DauMayID } into g
                               select new
                               {
                                   LoaiMayID = g.Key.LoaiMayID,
                                   MaDV = g.First().MaCTQuanLy,
                                   TenDV = g.First().TenCTQuanLy,
                                   DauMayID = g.Key.DauMayID
                               }).ToList();
            var listDauMayGRLM = (from x in listDauMayGRDM
                                  group x by new { x.LoaiMayID, x.MaDV, x.TenDV } into g
                                  select new
                                  {
                                      LoaiMayID = g.Key.LoaiMayID,
                                      MaDV = g.Key.MaDV,
                                      TenDV = g.Key.TenDV,
                                      CountDM = (int)g.Count()
                                  }).ToList();
            string loaiMay = string.Empty;
            List<DauMay> dauMays = new List<DauMay>();
            DauMay dm = new DauMay();
            foreach (var vlm in listDauMayGRLM)
            {
                if(loaiMay!=vlm.LoaiMayID)
                {
                    dm = new DauMay();
                    dm.LoaiMayID = vlm.LoaiMayID;
                    dm.HN += vlm.MaDV == "YV" ? vlm.CountDM : 0;
                    dm.HN += vlm.MaDV == "HN" ? vlm.CountDM : 0;
                    dm.VIN += vlm.MaDV == "VIN" ? vlm.CountDM : 0;
                    dm.SG += vlm.MaDV == "DN" ? vlm.CountDM : 0;
                    dm.SG += vlm.MaDV == "SG" ? vlm.CountDM : 0;
                    dm.TCT += vlm.CountDM;
                    dauMays.Add(dm);
                } 
                else
                {
                    dm.HN += vlm.MaDV == "YV" ? vlm.CountDM : 0;
                    dm.HN += vlm.MaDV == "HN" ? vlm.CountDM : 0;
                    dm.VIN += vlm.MaDV == "VIN" ? vlm.CountDM : 0;
                    dm.SG += vlm.MaDV == "DN" ? vlm.CountDM : 0;
                    dm.SG += vlm.MaDV == "SG" ? vlm.CountDM : 0;
                    dm.TCT += vlm.CountDM;
                }
                loaiMay = vlm.LoaiMayID;
            }
            dm = new DauMay();
            dm.LoaiMayID = "Tổng cộng:";
            dm.HN = dauMays.Sum(x=>x.HN);
            dm.VIN = dauMays.Sum(x => x.VIN);
            dm.SG = dauMays.Sum(x => x.SG);
            dm.TCT = dauMays.Sum(x => x.TCT);
            dauMays.Add(dm);
            return dauMays;
        }
    }
}
