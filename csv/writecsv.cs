using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
//using System.Linq;
using System.Diagnostics;
using CsvHelper;

namespace Csv
{
    public class writecsv
    {
        public static IList<T> WritecsvFile<T>(IEnumerable<T> countryCapitalQuery, string file_name)
        {

            var writePath = "c://csvfiles//" + file_name + ".csv";
            using (var writer = new StreamWriter(writePath))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(countryCapitalQuery);
            }

            return null;
        }
    }
}
