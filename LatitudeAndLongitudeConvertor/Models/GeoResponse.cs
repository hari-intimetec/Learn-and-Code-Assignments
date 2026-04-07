using System.Text.Json.Serialization;

namespace LatitudeAndLongitudeConvertor.Models
{
    public class GeoResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("results")]
        public List<Result> Results { get; set; } = new();
    }
}
