using System;
using System.Text.Json.Serialization;

namespace BitexenNet.Models
{
    public class BalancesData : Data
    {
        [JsonPropertyName("balances")]
        public Dictionary<string, TokenBalance>? Balances { get; set; }
    }
}
