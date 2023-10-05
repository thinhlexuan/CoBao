using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CoBaoWeb.Services
{
    public class CoBaoService
    {
        public static Task<ResponseDetail<partnerTCTCoBaoByDateOutput>> GetListCoBaoDienTuByDate(TimKiemCoBaoByDateInput input, string username, string access_token = "")
        {
            return MakeRequest<partnerTCTCoBaoByDateOutput>(
                ResfulApiMethod.PostJsonAsync,
               Configuration.UrlApi,
                "service/api/socobao/PartnerTCTGetListCoBaoDienTuByDate",
                input,
                access_token,
                username,
                Guid.NewGuid().ToString("N"));
        }
        public static Task<ResponseDetail<partnerTCTCoBaoByIDOutput>> PartnerTCTGetCoBaoDienTuByID(TimKiemCoBaoByIDInput input, string username, string access_token = "")
        {
            return MakeRequest<partnerTCTCoBaoByIDOutput>(
                ResfulApiMethod.PostJsonAsync,
               Configuration.UrlApi,
                "service/api/socobao/PartnerTCTGetCoBaoDienTuByID",
                input,
                access_token,
                username,
                Guid.NewGuid().ToString("N"));
        }
        public static Task<ResponseDetail<CoBaoResult>> PartnerTCTFeedBackThanhTichByID(PartnerThanhTichInput input, string username, string access_token = "")
        {
            return MakeRequest<CoBaoResult>(
                ResfulApiMethod.PostJsonAsync,
               Configuration.UrlApi,
                "service/api/socobao/PartnerTCTFeedBackThanhTichByID",
                input,
                access_token,
                username,
                Guid.NewGuid().ToString("N"));
        }
        public static Task<ResponseDetail<IEnumerable<DMTramFuel>>> LayThongTinTramFuel(string username, string access_token = "")
        {
            return MakeRequest<IEnumerable<DMTramFuel>>(
                ResfulApiMethod.PostJsonAsync,
               Configuration.UrlApi,
                "service/api/socobao/LayThongTinTramFuel",
                null,
                access_token,
                username,
                Guid.NewGuid().ToString("N"));
        }
        public static Task<ResponseDetail<DMNhanVien>> GetNhanVienByUsername(NhanVienInput input, string Username, string access_token = "")
        {
            return MakeRequest<DMNhanVien>(
               ResfulApiMethod.PostJsonAsync,
               Configuration.UrlApi,
                "service/api/nhan-vien/GetNhanVienByUsername",
                input,
                access_token,
                Username,
                Guid.NewGuid().ToString("N"));
        }
        public static Task<ResponseDetail<LoginData>> Login(LoginInput input, string userName, string access_token = "")
        {
            return MakeRequest<LoginData>(
                ResfulApiMethod.PostJsonAsync,
                Configuration.UrlLogin,
                "token",
                input,
                access_token, userName,
                Guid.NewGuid().ToString("N"));
        }

        public static async Task<ResponseDetail<T>> MakeRequest<T>(ResfulApiMethod method,
          string root_url,
          string end_point_url,
          object data, string access_token, string userName, string request_id)
        {
            var url = Path.Combine(root_url, end_point_url);

            ResponseDetail<T> ret = null;


            Debug.WriteLine("Start call API = " + url);
            Debug.WriteLine("token:" + access_token);
            int retry_counter = 3;
            int Timeout = 30;

            while (ret == null)
            {


                try
                {
                    Task<HttpResponseMessage> res = null;
                    switch (method)
                    {

                        case ResfulApiMethod.URLEnclosePost:

                            HttpClient client_http1 = new HttpClient();

                            var postData1 = new Dictionary<string, string>();

                            var json = JsonConvert.SerializeObject(data);
                            var postData = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                            var c1 = new FormUrlEncodedContent(postData);

                            var res1 = await client_http1.PostAsync(url, c1);

                            ret = new ResponseDetail<T>()
                            {
                                StatusCode = AdapterStatus.Succcess,
                                Data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await res1.Content.ReadAsStringAsync())
                            };
                            client_http1 = null;
                            json = null;
                            postData = null;
                            res1 = null;

                            break;

                        case ResfulApiMethod.PostJsonAsync:


                            if (string.IsNullOrEmpty(access_token))
                            {
                                Debug.WriteLine("input " + JsonConvert.SerializeObject(data));
                                if (!string.IsNullOrEmpty(end_point_url) && (end_point_url == "token"))
                                {
                                    if ((end_point_url == "token"))
                                    {
                                        var input = data as LoginInput;
                                        using (res = url
                                        .WithHeaders(new { request_id = "req:mobi:" + request_id, UserName = userName, User_Agent = Configuration.User_Agent })
                                        .WithTimeout(TimeSpan.FromSeconds(Timeout))
                                        .PostUrlEncodedAsync(new
                                        {
                                            username = input.UserName,
                                            password = input.Password,
                                            grant_type = input.GrantType,
                                            client_id = input.ClientID,
                                            client_secret = input.ClientSecret,
                                            deviceKey = input.DeviceKey
                                        }))
                                        {
                                            ret = new ResponseDetail<T>()
                                            {
                                                StatusCode = AdapterStatus.Succcess,
                                                Data = await res.ReceiveJson<T>()
                                            };
                                        }
                                    }
                                }
                                else
                                {
                                    using (res = url
                                  .WithHeaders(new { request_id = "req:mobi:" + request_id, UserName = userName, User_Agent = Configuration.User_Agent })
                                  .WithTimeout(TimeSpan.FromSeconds(Timeout))
                                  .PostJsonAsync(data))
                                    {
                                        ret = new ResponseDetail<T>()
                                        {
                                            StatusCode = AdapterStatus.Succcess,
                                            Data = await res.ReceiveJson<T>()
                                        };
                                    }

                                }

                            }
                            else
                            {
                                Debug.WriteLine("input " + JsonConvert.SerializeObject(data));
                                using (res = url
                                    .WithHeaders(new { request_id = "req:mobi:" + request_id, UserName = userName, Authorization = access_token, User_Agent = Configuration.User_Agent })
                                    .WithTimeout(TimeSpan.FromSeconds(Timeout))
                                    .PostJsonAsync(data))
                                {
                                    ret = new ResponseDetail<T>()
                                    {
                                        StatusCode = AdapterStatus.Succcess,
                                        Data = await res.ReceiveJson<T>()
                                    };
                                }

                            }
                            break;
                        case ResfulApiMethod.GetAsync:

                            if (string.IsNullOrEmpty(access_token))
                            {
                                Debug.WriteLine("input " + JsonConvert.SerializeObject(data));
                                using (res = url
                                    .WithHeaders(new { request_id = "req:mobi:" + request_id, UserName = userName, User_Agent = Configuration.User_Agent })
                                    .WithTimeout(TimeSpan.FromSeconds(Timeout))
                                    .SetQueryParams(data)
                                    .GetAsync())

                                {
                                    ret = new ResponseDetail<T>()
                                    {
                                        StatusCode = AdapterStatus.Succcess,
                                        Data = await res.ReceiveJson<T>()
                                    };
                                }
                            }
                            else
                            {
                                Debug.WriteLine("input " + JsonConvert.SerializeObject(data));
                                using (res = url
                                   .WithHeaders(new { request_id = "req:mobi:" + request_id, UserName = userName, Authorization = access_token, User_Agent = Configuration.User_Agent })
                                   .WithTimeout(TimeSpan.FromSeconds(Timeout))
                                   .SetQueryParams(data)
                                   .GetAsync())

                                {
                                    ret = new ResponseDetail<T>()
                                    {
                                        StatusCode = AdapterStatus.Succcess,
                                        Data = await res.ReceiveJson<T>()
                                    };
                                }
                            }
                            break;

                    }
                    res = null;
                }
                catch (FlurlHttpTimeoutException e)
                {
                    Debug.WriteLine("API Adapter error ----- FlurlHttpTimeoutException: " + e.ToString());

                    if (retry_counter > 0)
                    {
                        retry_counter--;
                        await Task.Delay(1000);
                        Timeout += 10; //unit in second
                        ret = null;
                    }
                    else
                    {
                        ret = CreateErrorMessage<T>(AdapterStatus.ConnectionError, e.ToString());
                    }
                }
                catch (FlurlHttpException e)
                {
                    throw e;
                    /*#region xamarin
                    if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                     {
                         while (Connectivity.NetworkAccess != NetworkAccess.Internet)
                         {

                             await Task.Delay(1000);
                             Debug.WriteLine("Network down. wait and retry");
                             //Thông báo không có mạng với trường hợp ở form login
                             if (!string.IsNullOrEmpty(end_point_url) && end_point_url.Contains("token"))
                             {
                                 break;
                             }
                         }
                         //Thông báo không có mạng với trường hợp ở form login
                         if (!string.IsNullOrEmpty(end_point_url) && end_point_url.Contains("token"))
                         {
                             ret = CreateErrorMessage<T>(AdapterStatus.ErrorLogin, "Thiết bị không có kết nối mạng hoặc 3G-4G, vui lòng kiểm tra lại kết nối!");
                         }
                         else
                             ret = null;
                     }
                     else
                     {


                         if (retry_counter > 0)
                         {
                             retry_counter--;
                             await Task.Delay(1000);
                             //Timeout += 10; //unit in second
                             ret = null;
                         }
                         else
                         {
                             //trường hợp ở form login
                             if (!string.IsNullOrEmpty(end_point_url) && end_point_url.Contains("token"))
                             {
                                 string strError = await e.Call.Response.Content.ReadAsStringAsync();
                                 if (!string.IsNullOrEmpty(e.Message) && e.Message.Contains("400 (Bad Request)") && !string.IsNullOrEmpty(strError))
                                 {
                                     try
                                     {
                                         var res = JsonConvert.DeserializeObject<Respone>(strError);
                                         if (res != null && !string.IsNullOrEmpty(res.error_description))
                                         {
                                             ret = CreateErrorMessage<T>(AdapterStatus.ConnectionError, res.error_description);
                                         }
                                     }
                                     catch (Exception ex)
                                     {
                                         Debug.WriteLine(ex);
                                         ret = CreateErrorMessage<T>(AdapterStatus.ConnectionError, e.ToString());
                                     }
                                 }
                                 else
                                     ret = CreateErrorMessage<T>(AdapterStatus.ConnectionError, e.ToString());
                             }
                             else
                             {
                                 if (!string.IsNullOrEmpty(e.Message) && e.Message.Contains("401 (Unauthorized)"))
                                     ret = CreateErrorMessage<T>(AdapterStatus.TokenExpired, e.ToString());
                                 else
                                     ret = CreateErrorMessage<T>(AdapterStatus.ConnectionError, e.ToString());
                             }
                         }

                         Debug.WriteLine(e.Call?.HttpStatus + e.Message + e.Call?.ToString());
                     }#endregion xamarin*/

                }

                catch (Exception e)
                {
                    if (Connectivity.NetworkAccess != Xamarin.Essentials.NetworkAccess.Internet)
                    {
                        while (Connectivity.NetworkAccess != Xamarin.Essentials.NetworkAccess.Internet)
                        {

                            await Task.Delay(1000);
                            //Thông báo không có mạng với trường hợp ở form login
                            if (!string.IsNullOrEmpty(end_point_url) && end_point_url.Contains("token"))
                            {
                                break;
                            }

                        }
                        //Thông báo không có mạng với trường hợp ở form login
                        if (!string.IsNullOrEmpty(end_point_url) && end_point_url.Contains("token"))
                        {
                            ret = CreateErrorMessage<T>(AdapterStatus.ErrorLogin, "Thiết bị không có kết nối mạng hoặc 3G-4G, vui lòng kiểm tra lại kết nối!");
                        }
                        else
                            ret = null;
                    }
                    else
                    {

                        ret = CreateErrorMessage<T>(AdapterStatus.Error, e.ToString());
                    }
                }

                if (ret != null)
                {
                    switch (ret.StatusCode)
                    {
                        case AdapterStatus.Succcess:
                            break;

                        case AdapterStatus.TokenExpired:


                            ret = null;
                            break;

                        case AdapterStatus.Unauthorized:
                        case AdapterStatus.TokenEmpty:
                        case AdapterStatus.TokenInvalid:
                        case AdapterStatus.TokenNotGrant:
                        case AdapterStatus.AccessDenined:
                            ret = CreateErrorMessage<T>(AdapterStatus.AccessDenined, ret.Message);
                            break;

                        default:
                            Debug.WriteLine("Error from API server, error code:" + ret.StatusCode + " ==>" + ret.Message);
                            break;
                    }
                }
            }

            return ret;
        }
        private static ResponseDetail<T> CreateErrorMessage<T>(int ErrorCode, string message)
        {
            return new ResponseDetail<T>
            {
                StatusCode = (int)ErrorCode,
                Message = message
            };
        }
    }
}
