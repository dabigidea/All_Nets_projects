using All_Nets.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace All_Nets.Data
{
    public class RestService
    {
        HttpClient client;
        string grant_type = "password";

        public RestService ()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded' "));
        }

        public async Task<Token> Login(User user)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("grant_type", grant_type));
            postData.Add(new KeyValuePair<string, string>("username", user.Username));
            postData.Add(new KeyValuePair<string, string>("password", user.Password));
            var content = new FormUrlEncodedContent(postData);
            var response = await PostResponse<Token>(Constants.loginUrl, content);
            DateTime dt = new DateTime();
            dt = DateTime.Today;
            response.expire_date = dt.AddSeconds(response.expires_in);
            return response;
        }

        public async Task<T> PostResponse<T>(string weburl, FormUrlEncodedContent content) where T : class
        {
            
            var response = await client.PostAsync(weburl, content);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var ResponseObject = JsonConvert.DeserializeObject<T>(jsonResult);
            return ResponseObject;
        }

        public async Task<T> PostResponse<T>(string weburl, string jsonstring) where T : class
        {
            var Token = App.TokenDatabase.GetToken();
            string contentType = "application/ json";
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.access_token);
            try
            {
                var Result = await client.PostAsync(weburl, new StringContent(jsonstring, Encoding.UTF8, contentType));
                if (Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var JsonResult = Result.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var ContentResp = JsonConvert.DeserializeObject<T>(JsonResult);
                        return ContentResp;
                    }
                    catch { return null; }
                }
            }
            catch { return null; }
            return null;
        }
        
        public async Task<T> GetRestponse<T>(string weburl) where T : class
        {
            var Token = App.TokenDatabase.GetToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.access_token);
            try
            {
                var response = await client.GetAsync(weburl);
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var JsonResult = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<T>(JsonResult);
                        return contentResp;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
    }
}
