using AdjacentCountriesApp.Services;
using NeighbouringCountries.Models;
using System;
using System.IO;

namespace AdjacentCountriesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonFilePath = Path.Combine(
                AppContext.BaseDirectory,
                "Data",
                "countries.json"
            );

            string unSupportedCode = "Invalid or unsupported country code.";

            CountryService countryService = new CountryService(jsonFilePath);

            Console.Write("Enter country code (e.g., IN, US, DE): ");
            string countryCode = Console.ReadLine();

            Country country = countryService.GetCountryByCode(countryCode);

            if (country == null)
            {
                Console.WriteLine(unSupportedCode);
                return;
            }

            countryService.DisplayAdjacentCountries(country);
        }

    }
}
