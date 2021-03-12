using System.Text.Json.Serialization;

namespace SeaBattle.Models
{
    public class MatrixModel
    {
        [JsonPropertyName("range")]
        public int Range { get; set; }
    }
}
