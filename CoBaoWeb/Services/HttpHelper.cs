using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CoBaoWeb.Services
{
    [Authorize]
    public class HttpHelper
    {
        private static readonly string apiBasicUri = Configuration.UrlCBApi;
        public static List<T> GetList<T>(string url)
        {
            using (var client = new HttpClient())
            {   
                client.BaseAddress = new Uri(apiBasicUri);
                List<T> obj = null;
                try
                {
                    var task = client.GetAsync(url)
                      .ContinueWith((taskwithresponse) =>
                      {
                          var response = taskwithresponse.Result;
                          var jsonString = response.Content.ReadAsStringAsync();
                          jsonString.Wait();
                          obj = JsonConvert.DeserializeObject<List<T>>(jsonString.Result);

                      });
                    task.Wait();

                }
                catch
                {
                    return null;
                }
                client.Dispose();
                return obj;
            }
        }
        public static List<T> GetList<T>(string url,string sessions)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
                client.BaseAddress = new Uri(apiBasicUri);
                List<T> obj = null;
                try
                {
                    var task = client.GetAsync(url)
                      .ContinueWith((taskwithresponse) =>
                      {
                          var response = taskwithresponse.Result;
                          var jsonString = response.Content.ReadAsStringAsync();
                          jsonString.Wait();
                          obj = JsonConvert.DeserializeObject<List<T>>(jsonString.Result);

                      });
                    task.Wait();

                }
                catch
                {
                    return null;
                }
                client.Dispose();
                return obj;
            }
        }
        public static async Task<T> Get<T>(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBasicUri);
                var result = await client.GetAsync(url).ConfigureAwait(false);
                result.EnsureSuccessStatusCode();
                string resultContentString = await result.Content.ReadAsStringAsync();
                T resultContent = JsonConvert.DeserializeObject<T>(resultContentString);
                client.Dispose();
                return resultContent;
            }
        }
        public static async Task<string> GetString<T>(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBasicUri);
                var result = await client.GetAsync(url).ConfigureAwait(false);
                result.EnsureSuccessStatusCode();
                string resultContentString = await result.Content.ReadAsStringAsync();
                client.Dispose();
                return resultContentString;
            }
        }
        public static async Task<decimal> GetDecimal<T>(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBasicUri);
                var result = await client.GetAsync(url).ConfigureAwait(false);
                result.EnsureSuccessStatusCode();
                string resultContentString = await result.Content.ReadAsStringAsync();
                client.Dispose();
                return decimal.Parse(resultContentString);
            }
        }
        public static async Task<T> Post<T>(string url, T contentValue)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBasicUri);
                var content = new StringContent(JsonConvert.SerializeObject(contentValue), Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, content).ConfigureAwait(false);
                result.EnsureSuccessStatusCode();
                string resultContentString = await result.Content.ReadAsStringAsync();
                T resultContent = JsonConvert.DeserializeObject<T>(resultContentString);
                client.Dispose();
                return resultContent;
            }
        }
        public async static Task<T> Put<T>(string url, T stringValue)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBasicUri);
                var content = new StringContent(JsonConvert.SerializeObject(stringValue), Encoding.UTF8, "application/json");
                var result = await client.PutAsync(url, content).ConfigureAwait(false);
                result.EnsureSuccessStatusCode();
                string resultContentString = await result.Content.ReadAsStringAsync();
                T resultContent = JsonConvert.DeserializeObject<T>(resultContentString);
                client.Dispose();
                return resultContent;
            }
        }
        public async static Task<T> Delete<T>(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBasicUri);
                var result = await client.DeleteAsync(url).ConfigureAwait(false);
                result.EnsureSuccessStatusCode();
                string resultContentString = await result.Content.ReadAsStringAsync();
                T resultContent = JsonConvert.DeserializeObject<T>(resultContentString);
                client.Dispose();
                return resultContent;
            }
        }
    }
}
