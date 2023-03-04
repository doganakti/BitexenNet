using System;
using System.Text.Json.Serialization;

namespace BitexenNet.Models
{
    public class TokenBalance
    {
        [JsonPropertyName("currency_code")]
        public string? CurrencyCode { get; set; }

        [JsonPropertyName("balance")]
        public string? Balance { get; set; }

        [JsonPropertyName("available")]
        public string? Available { get; set; }
    }
}
