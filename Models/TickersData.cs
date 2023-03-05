using System;
using System.Text.Json.Serialization;

namespace BitexenNet.Models
{
    public class TickersData : Data
    {
        [JsonPropertyName("tickers")]
        public List<Ticker>? Tickers { get; set; }
    }
}
