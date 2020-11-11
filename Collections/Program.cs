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

            WithList(reader);

            //WithDictionary(reader);
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
            reader.RemoveCommaCountries(countries);
            //adding to the end of the list
            Country southAfrica = new Country("South Africa", "ZAF", "Africa", 59_308_690);
            countries.Add(southAfrica);

            //inserting in the list
            int tanzaniaIndex = countries.FindIndex(x => x.Population < 59_734_218);
            Country tanzania = new Country("Tanzania", "TZA", "Africa", 59_734_218);
            countries.Insert(tanzaniaIndex, tanzania);

            //removing from the list
            countries.RemoveAt(tanzaniaIndex);

            //Console.WriteLine($"Top {countries.Count}º most populated:");
            //Console.WriteLine();

            /*foreach (var country in countries)
            {
                Console.WriteLine($"{(country.Name).PadRight(15)} : {FormatPopulation.PopulationFormat(country.Population).PadLeft(15)}");
            }*/

            Console.WriteLine("Enter the no. of countries to display: ");
            bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);
            if (!inputIsInt || userInput <= 0)
            {
                Console.Write("You must type a positive integer. Exiting...");
                return;
            }

            int maxToDisplay = Math.Min(userInput, countries.Count);

            //fisrt to the last
            DisplayFirstToLast(countries, maxToDisplay);


            //last to the first
            //DisplayLastToFirst(countries, maxToDisplay);

            Console.WriteLine();
        }

        private static void DisplayLastToFirst(List<Country> countries, int maxToDisplay)
        {
            for (int i = countries.Count - 1; i >= 0; i--)
            {
                int displayIndex = countries.Count - 1 - i;
                if (displayIndex > 0 && (displayIndex % maxToDisplay == 0))
                {
                    Console.WriteLine();
                    Console.WriteLine("Hit return to continue, anything else to quit: ");
                    if (Console.ReadLine() != "")
                        break;
                }

                Country country = countries[i];
                Console.WriteLine(
                    $"{i + 1} : {(country.Name).PadRight(15)} : {FormatPopulation.PopulationFormat(country.Population).PadLeft(15)}");
            }
        }

        private static void DisplayFirstToLast(List<Country> countries, int maxToDisplay)
        {
            //first to the last
            for (int i = 0; i < countries.Count; i++)
            {
                if (i > 0 && (i % maxToDisplay == 0))
                {
                    Console.WriteLine("Hit return to continue, anything else to quit: ");
                    if (Console.ReadLine() != "")
                        break;
                }

                Country country = countries[i];
                Console.WriteLine(
                    $"{i + 1} : {(country.Name).PadRight(30).PadLeft(2)} : {FormatPopulation.PopulationFormat(country.Population).PadLeft(30)}");
            }
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
