using NeighbouringCountries.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdjacentCountriesApp.Services
{
    public class CountryService
    {
        private readonly List<Country> countries;

        public CountryService(string jsonFilePath)
        {
            countries = LoadCountries(jsonFilePath);
        }

        public Country GetCountryByCode(string countryCode)
        {
            return countries.FirstOrDefault(
                country => country.Code.Equals(countryCode, System.StringComparison.OrdinalIgnoreCase)
            );
        }

        private List<Country> LoadCountries(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Country>>(jsonData);
        }

        public void DisplayAdjacentCountries(Country country)
        {
            Console.WriteLine($"\nAdjacent countries to {country.Name}:");

            if (country.AdjacentCountries.Count == 0)
            {
                Console.WriteLine("No land-adjacent countries.");
                return;
            }

            foreach (string adjacentCountry in country.AdjacentCountries)
            {
                Console.WriteLine($"- {adjacentCountry}");
            }
        }
    }
}
