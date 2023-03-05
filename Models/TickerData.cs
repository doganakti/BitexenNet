using System;
using System.Text.Json.Serialization;

namespace BitexenNet.Models
{
    public class TickerData : Data
    {
        [JsonPropertyName("ticker")]
        public Ticker? Ticker { get; set; }
    }
}
