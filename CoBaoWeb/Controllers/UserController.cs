using CoBaoWeb.Models;
using CoBaoWeb.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoBaoWeb.Controllers
{
    public class UserController : Controller
    {       
        private readonly IConfiguration _configuration;       
       
        public UserController(IConfiguration configuration)
        {   
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var token = await Authenticate(request);

            var userPrincipal = ValidateToken(token);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                //IsPersistent = true
                IsPersistent = false
            };
            HttpContext.Session.SetString("Token", token);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                userPrincipal,
                authProperties);           
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Login", "User");
        }
        private async Task<string> Authenticate(LoginRequest request)
        {
            try
            {
                var data = await Services.AuthenticationService.Login(request.UserName, request.Passwrod, null);
                if (data != null && !string.IsNullOrEmpty(data.userName) && !string.IsNullOrEmpty(data.access_token))
                {

                    var tokenApi = string.Format("Bearer {0}{1}", data.userClientId, data.access_token);
                    var input = new NhanVienInput();
                    input.Username = data.userName;
                    var res = await Services.AuthenticationService.GetNhanVienByUsername(input, data.userName, tokenApi);
                    if (res == null) return null;
                    var nhanVien = HttpHelper.GetList<NhanVien>(Configuration.UrlCBApi + "api/DanhMucs/GetNhanVien").Where(x => x.MaNV == data.userName && x.Active==true).FirstOrDefault();
                    var donVi = HttpHelper.GetList<DmdonVi>(Configuration.UrlCBApi + "api/DanhMucs/GetDmdonVi").Where(x => x.MaDv == res.MaDV).FirstOrDefault().MaCt;
                    var claims = new[]
                   {
                    new Claim(ClaimTypes.GivenName,res.Username),
                    new Claim(ClaimTypes.Name,res.FullName),
                    new Claim(ClaimTypes.SerialNumber,tokenApi),
                    new Claim(ClaimTypes.NameIdentifier,string.IsNullOrWhiteSpace(res.ChucVu)?string.Empty:res.ChucVu),
                    new Claim(ClaimTypes.PrimarySid,donVi),
                    new Claim(ClaimTypes.PrimaryGroupSid,res.TenDV),
                    new Claim(ClaimTypes.Role,nhanVien==null?"0": nhanVien.MaQH.ToString()),
                    new Claim(ClaimTypes.Rsa,nhanVien==null?"0": nhanVien.NL.ToString())
                };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_configuration["Tokens:Issuer"], _configuration["Tokens:Issuer"], claims, expires: DateTime.Now.AddHours(3), signingCredentials: creds);                    
                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;
            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();
            validationParameters.ValidateLifetime = true;
            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);
            return principal;
        }
    }
}
