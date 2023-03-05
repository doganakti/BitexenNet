using System;
using System.Text.Json.Serialization;

namespace BitexenNet.Models
{
    public class OrderData : Data
    {
        [JsonPropertyName("order")]
        public Order? Order { get; set; }
    }
}
