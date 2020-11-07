using System;
using System.Collections.Generic;
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

        public Country[] ReadFirstNCountries(int nCountries)
        {
            return null;
        }
    }
}
