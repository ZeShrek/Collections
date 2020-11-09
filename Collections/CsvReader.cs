using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Collections
{
    class CsvReader
    {
        private string _csvFilePath;

        public CsvReader(string cvCsvFilePath)
        {
            this._csvFilePath = cvCsvFilePath;
        }

        //with array
        public Country[] ReadFirstNCountries(int nCountries)
        {
            Country[] countries = new Country[nCountries];

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                sr.ReadLine();

                for (int i = 0; i < nCountries; i++)
                {
                    string csvLine = sr.ReadLine();
                    countries[i] = ReadCountryFromCsvFile(csvLine);
                }
            }

            return countries;
        }
        

        //with list<T>
        public List<Country> ReadAllCountries()
        {
            List<Country> countries = new List<Country>();

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                sr.ReadLine();

                string csvLine;

                while ((csvLine = sr.ReadLine()) != null)
                {
                    countries.Add(ReadCountryFromCsvFile(csvLine)); 
                }
            }

            return countries;
        }

        //with Dictionary
        //with list<T>
        public Dictionary<string, Country> ReadAllCountriesDictionary()
        {
            var countries = new Dictionary<string, Country>();

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                // read header line
                sr.ReadLine();

                string csvLine;
                while ((csvLine = sr.ReadLine()) != null)
                {
                    Country country = ReadCountryFromCsvFile(csvLine);
                    countries.Add(country.Code, country);
                }
            }

            return countries;
        }

        public Country ReadCountryFromCsvFile(string csvLine)
        {
            string[] parts = csvLine.Split(new char[]{','});

            string name = parts[0];
            string code = parts[1];
            string region = parts[2];
            int population = int.Parse(parts[3]);

            return new Country(name, code, region, population);
        }
    }
}
