using System.Text.Json.Serialization;

namespace SeaBattle.Models
{
    public class BattleStatistics
    {
        [JsonPropertyName("ship_count")]
        public int ShipCount { get; set; }

        [JsonPropertyName("destroyed")]
        public int DestroyedCount { get; set; }

        [JsonPropertyName("knocked")]
        public int KnockedCount { get; set; }

        [JsonPropertyName("shot_count")]
        public int ShotCount { get; set; }
    }
}