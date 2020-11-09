using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Pluralsight\C# Path\C# Development Fundamentals\Collections\Collections\CountriesInfo.csv";

            CsvReader reader = new CsvReader(filePath);

            // WithArrays(reader);

            //WithList(reader);

            WithDictionary(reader);
        }

        public static void WithArrays(CsvReader reader)
        {

            Country[] countries = reader.ReadFirstNCountries(10);

            Console.WriteLine($"Top {countries.Length}º most populated:");
            Console.WriteLine();

            foreach (var country in countries)
            {
                Console.WriteLine($"{(country.Name).PadRight(15)} : {FormatPopulation.PopulationFormat(country.Population).PadLeft(15)}");
            }
            Console.WriteLine();
        }

        public static void WithList(CsvReader reader)
        {
            List<Country> countries = reader.ReadAllCountries();

            //adding to the end of the list
            Country southAfrica = new Country("South Africa", "ZAF", "Africa", 59_308_690);
            countries.Add(southAfrica);

            //inserting in the list
            int tanzaniaIndex = countries.FindIndex(x => x.Population < 59_734_218);
            Country tanzania = new Country("Tanzania", "TZA", "Africa", 59_734_218);
            countries.Insert(tanzaniaIndex, tanzania);

            //removing from the list
            countries.RemoveAt(tanzaniaIndex);

            Console.WriteLine($"Top {countries.Count}º most populated:");
            Console.WriteLine();

            foreach (var country in countries)
            {
                Console.WriteLine($"{(country.Name).PadRight(15)} : {FormatPopulation.PopulationFormat(country.Population).PadLeft(15)}");
            }
            Console.WriteLine();
        }

        public static void WithDictionary(CsvReader reader)
        {
            //Dictionary<string, Country> = new Dictionary<string, Country>();
            //or
            Dictionary<string, Country> countries = reader.ReadAllCountriesDictionary();

            Console.WriteLine("Which country code do you want to look up? ");
            string userInput = Console.ReadLine();

            bool gotCountry = countries.TryGetValue(userInput, out Country country);
            if (!gotCountry)
                Console.WriteLine($"Sorry, there is no country with code, {userInput}");
            else
                Console.WriteLine($"{country.Name} has {FormatPopulation.PopulationFormat(country.Population)} people");
            //adding to the Dictionary
            Country tanzania = new Country("Tanzania", "TZA", "Africa", 59_734_218);
            Country southAfrica = new Country("South Africa", "ZAF", "Africa", 59_308_690);
            countries.Add(tanzania.Code, tanzania);
            countries.Add(southAfrica.Code, southAfrica);
        }
    }
}
