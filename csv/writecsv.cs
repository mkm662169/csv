using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Csv
{
    public class writecsv
    {

        public static void WriteCsvFile<T>(IList<T> myList, string fileName)
        {
            var query = (from s in myList select s);
            var writePath = "c://csvfiles//" + fileName + ".csv";
            using (var writer = new StreamWriter(writePath))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(query);
            }

        }
    }
}