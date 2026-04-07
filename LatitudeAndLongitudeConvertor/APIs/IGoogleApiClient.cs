namespace LatitudeAndLongitudeConvertor.APIs
{
    public interface IGoogleApiClient
    {
        Task<string> GetAsync(string url);
    }
}
