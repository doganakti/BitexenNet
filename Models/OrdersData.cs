using System;
using System.Text.Json.Serialization;

namespace BitexenNet.Models
{
    public class OrdersData : Data
    {
        [JsonPropertyName("orders")]
        public List<Order>? Orders { get; set; }
    }
}
