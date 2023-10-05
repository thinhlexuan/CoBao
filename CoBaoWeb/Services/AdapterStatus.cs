namespace CoBaoWeb.Services
{
    public class AdapterStatus
    {
        public const int Succcess = 0;
        public const int Error = 1000;
        public const int UnknowError = 1001;
        public const int ConnectionError = 1100;
        public const int ConnectionTimeout = 1101;
        public const int ServerNotReady = 1201;
        public const int ServiceNotFound = 1202;
        public const int ClientError = 1300;
        public const int AccessDenined = 1306;
        public const int ServerError = 5000;
        public const int TokenEmpty = 5010;
        public const int TokenInvalid = 5020;
        public const int TokenExpired = 5030;
        public const int TokenNotGrant = 5040;
        public const int Unauthorized = 5050;
        public const int ResourceNotExists = 5060;
        public const int DeviceNotExists = 5066;
        public const int ErrorLogin = 5068;
    }

    public enum ResfulApiMethod : short
    {
        PostJsonAsync = 0,
        GetAsync = 1,
        URLEnclosePost = 2
    }
}
