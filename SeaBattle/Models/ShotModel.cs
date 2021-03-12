using System.Text.Json.Serialization;

namespace SeaBattle.Models
{
    public class ShotModel
    {
        [JsonPropertyName("сoord")]
        public string Coordinates { get; set; }
    }
}
