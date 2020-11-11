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
            string[] parts = csvLine.Split(',');
            string name;
            string code;
            string region;
            string populationString;

            switch (parts.Length)
            {
                case 4:
                    name = parts[0];
                    code = parts[1];
                    region = parts[2];
                    populationString = parts[3];
                    break;
                case 5:
                    name = parts[0] + ", " + parts[1];
                    name = name.Replace("\"", null).Trim();
                    code = parts[2];
                    region = parts[3];
                    populationString = parts[4];
                    break;
                default:
                    throw new Exception($"Can't parse country from csvLine: {csvLine}");
            }

            int.TryParse(populationString, out int population);
            return new Country(name, code, region, population);
        }

        public void RemoveCommaCountries(List<Country> countries)
        {
            /*for (int i = countries.Count; i >= 0; i--)
            {
                if (countries[i].Name.Contains(","))
                {
                    countries.RemoveAt(i);
                }
            }*/

            countries.RemoveAll(x => x.Name.Contains(","));
        }
    }
}
