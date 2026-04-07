using System.Text.Json.Serialization;

namespace LatitudeAndLongitudeConvertor.Models
{
    public class Result
    {
        [JsonPropertyName("formatted_address")]
        public string Formatted_Address { get; set; } = string.Empty;

        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; } = new();
    }
}
