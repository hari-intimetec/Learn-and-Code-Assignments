using LatitudeAndLongitudeConvertor.APIs;
using LatitudeAndLongitudeConvertor.Models;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace LatitudeAndLongitudeConvertor.Services
{
    public class GeocodingService : IGeocodingService
    {
        private readonly IGoogleApiClient _apiClient;
        private readonly string _apiKey;

        public GeocodingService(IGoogleApiClient apiClient, IConfiguration config)
        {
            _apiClient = apiClient;
            _apiKey = config["GoogleApi:ApiKey"]!;
        }


        public async Task<List<LocationResult>> GetCoordinatesAsync(string locationName)
        {
            try
            {
                var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={locationName}&key={_apiKey}";

                var responseJson = await _apiClient.GetAsync(url);

                var geoResponse = JsonSerializer.Deserialize<GeoResponse>(responseJson);

                if (geoResponse == null || geoResponse.Status != "OK")
                    throw new Exception($"API Error: {geoResponse?.Status}");

                return geoResponse.Results.Select(response => new LocationResult
                {
                    Address = response.Formatted_Address,
                    Latitude = response.Geometry.Location.Lat,
                    Longitude = response.Geometry.Location.Lng
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
