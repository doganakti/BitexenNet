using System;
using System.Text.Json.Serialization;

namespace BitexenNet.Models
{
    public class Order
    {
        [JsonPropertyName("order_number")]
        public long? OrderNumber { get; set; }

        [JsonPropertyName("account_number")]
        public long? AccountNumber { get; set; }

        [JsonPropertyName("order_type")]
        public string? OrderType { get; set; }

        [JsonPropertyName("market_code")]
        public string? MarketCode { get; set; }

        [JsonPropertyName("base_currency")]
        public string? BaseCurrency { get; set; }

        [JsonPropertyName("counter_currency")]
        public string? CounterCurrency { get; set; }

        [JsonPropertyName("channel_code")]
        public string? ChannelCode { get; set; }

        [JsonPropertyName("price")]
        public string? Price { get; set; }

        [JsonPropertyName("volume")]
        public string? Volume { get; set; }

        [JsonPropertyName("volume_executed")]
        public string? VolumeExecuted { get; set; }

        [JsonPropertyName("volume_remaining")]
        public string? VolumeRemaining { get; set; }

        [JsonPropertyName("buy_sell")]
        public string? BuySell { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("add_date")]
        public string? AddDate { get; set; }

        [JsonPropertyName("total")]
        public string? Total { get; set; }

        [JsonPropertyName("avg_price")]
        public string? AvgPrice { get; set; }

        [JsonPropertyName("client_id")]
        public int? ClientId { get; set; }

        [JsonPropertyName("post_only")]
        public bool? PostOnly { get; set; }
    }
}
