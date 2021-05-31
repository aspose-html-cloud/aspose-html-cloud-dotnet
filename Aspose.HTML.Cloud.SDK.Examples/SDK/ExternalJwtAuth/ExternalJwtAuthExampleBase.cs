using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

using Aspose.Html.Cloud.Sdk.Client.Authentication;

namespace Aspose.HTML.Cloud.Examples.SDK.ExternalJwtAuth
{
    public abstract class ExternalJwtAuthExampleBase
    {
        internal JwtToken GetAuthToken()
        {
            string authServicePath = $"{CommonSettings.AuthPath}/connect/token";
            List<KeyValuePair<string, string>> authReqContent = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("grant_type", "client_credentials"),
                            new KeyValuePair<string, string>("client_id", CommonSettings.ClientId),
                            new KeyValuePair<string, string>("client_secret", CommonSettings.ClientSecret)
                        };

            HttpRequestMessage authReq = new HttpRequestMessage()
            {
                RequestUri = new Uri(authServicePath),
                Method = HttpMethod.Post
            };
            authReq.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            authReq.Content = new FormUrlEncodedContent(authReqContent);
            authReq.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            HttpClient authClient = new HttpClient();
            var authResponse = authClient.SendAsync(authReq).Result;
            if (authResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = authResponse.Content.ReadAsStringAsync().Result;
                Dictionary<string, object> dict =
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(content);
                if(dict.ContainsKey("error"))
                {
                    var errDescr = dict.ContainsKey("error_description") ? dict["error_description"] : "";
                    Console.WriteLine($"Unsuccessful authorization: {errDescr}");
                    return null;
                }
                JwtToken token = new JwtToken()
                {
                    Token = dict["access_token"].ToString(),
                    IssuedOn = DateTime.UtcNow,
                    ExpiresInSeconds = Convert.ToInt32(dict["expires_in"])
                };
                return token;
            }
            return null;
        }
    }
}
