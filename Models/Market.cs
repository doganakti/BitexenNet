using System;
using System.Text.Json.Serialization;

namespace BitexenNet.Models
{
    public class Market
    {
        [JsonPropertyName("market_code")]
        public string? MarketCode { get; set; }

        [JsonPropertyName("base_currency")]
        public string? BaseCurrency { get; set; }

        [JsonPropertyName("url_symbol")]
        public string? UrlSymbol { get; set; }

        [JsonPropertyName("counter_currency")]
        public string? CounterCurrency { get; set; }

        [JsonPropertyName("minimum_order_amount")]
        public string? MinimumOrderAmount { get; set; }

        [JsonPropertyName("base_currency_decimal")]
        public int? BaseCurrencyDecimal { get; set; }

        [JsonPropertyName("counter_currency_decimal")]
        public int? CounterCurrencyDecimal { get; set; }
    }
}
