using System;
using System.Text.Json.Serialization;

namespace BitexenNet.Models
{
    public class Data
    {
        [JsonPropertyName("page_number")]
        public int PageNumber { get; set; }

        [JsonPropertyName("total_page_count")]
        public int TotalPageCount { get; set; }

        [JsonPropertyName("has_next")]
        public bool HasNext { get; set; }
    }
}
