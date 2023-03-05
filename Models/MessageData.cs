using System;
using System.Text.Json.Serialization;

namespace BitexenNet.Models
{
    public class MessageData : Data
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
