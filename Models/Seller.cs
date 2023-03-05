using System;
using System.Text.Json.Serialization;

namespace BitexenNet.Models
{
    public class Seller
    {
        [JsonPropertyName("orders_total_amount")]
        public string? OrdersTotalAmount { get; set; }

        [JsonPropertyName("orders_price")]
        public string? OrdersPrice { get; set; }
    }
}
