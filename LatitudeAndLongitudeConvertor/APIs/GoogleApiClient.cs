namespace LatitudeAndLongitudeConvertor.APIs
{ 

    public class GoogleApiClient : IGoogleApiClient
    {
        private readonly HttpClient _httpClient;

        public GoogleApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"HTTP Error: {response.StatusCode}");

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching data from Google API: {ex.Message}", ex);
            }
        }
    }
}
