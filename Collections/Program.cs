using System;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"asdasd.csv";

            CsvReader reader = new CsvReader(filePath);

            Country[] countries = reader.ReadFirstNCountries(10);

            foreach (var countrie in countries)
            {
                Console.WriteLine($"{Country.Population}: {Country.Name}");
            }
        }
    }
}
