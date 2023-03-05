using System;
using System.Text.Json.Serialization;

namespace BitexenNet.Models
{
    public class Transaction
    {
        [JsonPropertyName("amount")]
        public string? Amount { get; set; }

        [JsonPropertyName("price")]
        public string? Price { get; set; }

        [JsonPropertyName("time")]
        public string? Time { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
