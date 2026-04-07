using System.Text.Json.Serialization;

namespace LatitudeAndLongitudeConvertor.Models
{
    public class Geometry
    {
        [JsonPropertyName("location")]
        public Location Location { get; set; } = new();
    }
}
