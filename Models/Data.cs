using System;
using System.Text.Json.Serialization;

namespace BitexenNet.Models
{
    public class Data
    {

        [JsonPropertyName("balances")]
        public Dictionary<string, TokenBalance>? Balances { get; set; }

        [JsonPropertyName("orders")]
        public List<Order>? Orders { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("order")]
        public Order? Order { get; set; }

        [JsonPropertyName("page_number")]
        public int PageNumber { get; set; }

        [JsonPropertyName("total_page_count")]
        public int TotalPageCount { get; set; }

        [JsonPropertyName("has_next")]
        public bool HasNext { get; set; }
    }
}
