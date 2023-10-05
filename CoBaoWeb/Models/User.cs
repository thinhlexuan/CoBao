using System;
using System.ComponentModel.DataAnnotations;

namespace CoBaoWeb.Models
{
    public class UserRequest
    {
        public string MaDV { get; set; }
        public string MaNV { get; set; }
        public string BearerToken { get; set; }
    }
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Passwrod { get; set; }
        public bool RememberMe { get; set; }
    }
    public class RegisterRequest
    {
        [Key]
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string MatKhau { get; set; }
        public string DonVi { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyName { get; set; }
    }
}
