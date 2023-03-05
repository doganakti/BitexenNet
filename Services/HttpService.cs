using System.Net;
using System.Text.Json;
using BitexenNet.Models;

namespace BitexenNet.Services
{
    public class HttpService
    {
        public Credentials? Credentials { get; set; }

        public HttpService(Credentials? credentials)
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

        public virtual Result<T>? Get<T>(string url) where T : Data
        {
            var response = GetClient(data: null).GetAsync(url).Result;
            return ParseResponse<T>(response);
        }

        public virtual Result<T>? Post<T>(string url, object? data) where T : Data
        {
            var response = GetClient(data).PostAsync(url, new StringContent(JsonSerializer.Serialize(data))).Result;
            return ParseResponse<T>(response);
        }

        Result<T>? ParseResponse<T>(HttpResponseMessage response) where T : Data
        {
            var content = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine($"Failed to receive content from server: {response.ReasonPhrase}");
                throw new Exception(response.ReasonPhrase);
            }
            else
            {
                var result = JsonSerializer.Deserialize<Result<T>>(content);
                if (result!.Status != "success")
                {
                    Console.WriteLine($"Failed to receive content from server: {result.Reason}");
                    throw new Exception($"{result.StatusCode}: {result.Reason}");
                }
                else
                {
                    return result;
                }
            }
        }
    }
}
