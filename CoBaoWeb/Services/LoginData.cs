using System;

namespace CoBaoWeb.Services
{
    public class LoginData
    {
		public string access_token { get; set; }
		public string token_type { get; set; }
		public long expires_in { get; set; }
		public string userName { get; set; }
		public string displayName { get; set; }
		public string userClientId { get; set; }
		public string roles { get; set; }
		public DateTime issued { get; set; }
		public DateTime expires { get; set; }
		public string refresh_token { get; set; }

		//Bổ sung 
		public short ChucDanhID { get; set; }
		public string MaDV { get; set; }
		public string MaCT { get; set; }
	}
}
