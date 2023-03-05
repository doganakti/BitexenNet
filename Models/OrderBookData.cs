using System;
using System.Text.Json.Serialization;

namespace BitexenNet.Models
{
    public class OrderBookData : Data
    {
        [JsonPropertyName("market_code")]
        public string? MarketCode { get; set; }

        [JsonPropertyName("ticker")]
        public Ticker? Ticker { get; set; }

        [JsonPropertyName("buyers")]
        public List<Buyer>? Buyers { get; set; }

        [JsonPropertyName("sellers")]
        public List<Seller>? Sellers { get; set; }

        [JsonPropertyName("last_transactions")]
        public List<Transaction>? LastTransactions { get; set; }

        [JsonPropertyName("timestamp")]
        public string? Timestamp { get; set; }
    }
}
