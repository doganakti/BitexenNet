using System;
using System.Text.Json.Serialization;

namespace BitexenNet.Models
{
    public class Result
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; }


        [JsonPropertyName("data")]
        public Data? Data { get; set; }

    }
}
