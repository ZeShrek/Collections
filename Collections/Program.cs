using System;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Pluralsight\C# Path\C# Development Fundamentals\Collections\Collections\CountriesInfo.csv";

            CsvReader reader = new CsvReader(filePath);

            Country[] countries = reader.ReadFirstNCountries(10);

            foreach (var country in countries)
            {
                Console.WriteLine($"{(country.Name).PadRight(15)} : {FormatPopulation.PopulationFormat(country.Population).PadLeft(15)}");
            }
        }
    }
}
