using System.Text.Json.Serialization;

namespace SeaBattle.Models
{
    public class MatrixSize
    {
        [JsonPropertyName("range")]
        public int Range { get; set; }
    }
}
