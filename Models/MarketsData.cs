using System;
using System.Text.Json.Serialization;

namespace BitexenNet.Models
{
    public class MarketsData : Data
    {
        [JsonPropertyName("markets")]
        public List<Market>? Markets { get; set; }
    }
}
