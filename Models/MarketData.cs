using System;
using System.Text.Json.Serialization;

namespace BitexenNet.Models
{
    public class MarketData : Data
    {
        [JsonPropertyName("markets")]
        public Market? Market { get; set; }
    }
}
