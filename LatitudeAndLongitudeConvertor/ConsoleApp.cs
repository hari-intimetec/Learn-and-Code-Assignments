using LatitudeAndLongitudeConvertor.Helpers;
using LatitudeAndLongitudeConvertor.Services;

namespace LatitudeAndLongitudeConvertor
{
    public class ConsoleApp
    {
        private readonly IGeocodingService _geocodingService;

        public ConsoleApp(IGeocodingService geocodingService)
        {
            _geocodingService = geocodingService;
        }

        public async Task RunAsync()
        {
            Console.Write("Enter location: ");
            var input = Console.ReadLine();

            if (!InputValidator.IsValid(input!))
            {
                Console.WriteLine("Invalid input. Please enter a valid location.");
                return;
            }

            try
            {
                var results = await _geocodingService.GetCoordinatesAsync(input!);

                Console.WriteLine("\nResults:\n");

                foreach (var result in results)
                {
                    Console.WriteLine($"Address  : {result.Address}");
                    Console.WriteLine($"Latitude : {result.Latitude}");
                    Console.WriteLine($"Longitude: {result.Longitude}");
                    Console.WriteLine(new string('-', 40));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
