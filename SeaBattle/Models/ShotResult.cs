using System.Text.Json.Serialization;

namespace SeaBattle.Models
{
    public class ShotResult
    {
        [JsonPropertyName("destroy")]
        public bool IsDestroyed { get; set; }

        [JsonPropertyName("knock")]
        public bool IsKnocked { get; set; }

        [JsonPropertyName("end")]
        public bool IsEndOfTheGame { get; set; }
    }
}
