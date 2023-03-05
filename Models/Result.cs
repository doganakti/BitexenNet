using System;
using System.Text.Json.Serialization;

namespace BitexenNet.Models
{
    public class Result<T> where T : Data
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("reason")]
        public string? Reason { get; set; }

        [JsonPropertyName("status_code")]
        public int? StatusCode { get; set; }

        [JsonPropertyName("data")]
        public T? Data { get; set; }

    }
}
