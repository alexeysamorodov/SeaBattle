using System.Text.Json.Serialization;

namespace SeaBattle.Data
{
    public class BattleStatistics
    {
        [JsonPropertyName("ship_count")]
        public int ShipCount { get; set; } = 0;

        [JsonPropertyName("destroyed")]
        public int DestroyedCount { get; set; } = 0;

        [JsonPropertyName("knocked")]
        public int KnockedCount { get; set; } = 0;

        [JsonPropertyName("shot_count")]
        public int ShotCount { get; set; } = 0;
    }
}