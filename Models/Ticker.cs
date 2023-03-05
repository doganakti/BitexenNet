using System;
using System.Text.Json.Serialization;

namespace BitexenNet.Models
{
    public class Ticker
    {
        [JsonPropertyName("market")]
        public Market? Market { get; set; }

        [JsonPropertyName("bid")]
        public string? Bid { get; set; }

        [JsonPropertyName("ask")]
        public string? Ask { get; set; }

        [JsonPropertyName("last_price")]
        public string? LastPrice { get; set; }

        [JsonPropertyName("volume_24h")]
        public string? Volume24H { get; set; }

        [JsonPropertyName("change_24h")]
        public string? Change24H { get; set; }

        [JsonPropertyName("low_24h")]
        public string? Low24H { get; set; }

        [JsonPropertyName("high_24h")]
        public string? High24H { get; set; }

        [JsonPropertyName("avg_24h")]
        public string? Avg24H { get; set; }

        [JsonPropertyName("timestamp")]
        public string? Timestamp { get; set; }

    }
}
