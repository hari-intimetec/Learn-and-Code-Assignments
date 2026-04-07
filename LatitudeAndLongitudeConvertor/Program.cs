using LatitudeAndLongitudeConvertor;
using LatitudeAndLongitudeConvertor.APIs;
using LatitudeAndLongitudeConvertor.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        var app = host.Services.GetRequiredService<ConsoleApp>();
        await app.RunAsync();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddHttpClient<IGoogleApiClient, GoogleApiClient>();
                services.AddScoped<IGeocodingService, GeocodingService>();
                services.AddScoped<ConsoleApp>();
            });
}