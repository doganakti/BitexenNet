using System.Text.Json;
using BitexenNet.Models;

namespace BitexenNet.Helpers
{
    public class HttpHelper
    {
        public Credentials? Credentials { get; set; }

        public HttpHelper(Credentials? credentials)
        {
            Credentials = credentials;
        }

        AuthHeader GetAuthHeader(long timestamp, object? data)
        {
            return new AuthHeader(credentials: Credentials!, timestamp: timestamp, body: data != null ? JsonSerializer.Serialize(data) : "{}");
        }

        void SetHeaders(HttpClient client, object? data)
        {
            var timestamp = DateTime.Now.ConvertToTimeStamp();
            client.DefaultRequestHeaders.Add("ACCESS-USER", Credentials!.UserName);
            client.DefaultRequestHeaders.Add("ACCESS-PASSPHRASE", Credentials!.Passphrase);
            client.DefaultRequestHeaders.Add("ACCESS-TIMESTAMP", timestamp.ToString());
            client.DefaultRequestHeaders.Add("ACCESS-SIGN", GetAuthHeader(timestamp, data).Signature);
            client.DefaultRequestHeaders.Add("ACCESS-KEY", Credentials!.ApiKey);
        }


        HttpClient GetClient(object? data = null)
        {
            var client = new HttpClient();
            if (Credentials != null)
            {
                SetHeaders(client, data);
            }
            return client;
        }

        public T? Get<T>(string url)
        {
            var response = GetClient(data: null).GetAsync(url).Result;
            return ParseResponse<T>(response);
        }

        public T? Post<T>(string url, object? data)
        {
            var response = GetClient(data).PostAsync(url, new StringContent(JsonSerializer.Serialize(data))).Result;
            return ParseResponse<T>(response);
        }

        T? ParseResponse<T>(HttpResponseMessage response)
        {
            var content = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<T>(content);
        }
    }
}
