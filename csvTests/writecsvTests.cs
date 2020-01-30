using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cities;
using Csv;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Csv.Tests
{
    [TestClass()]
    public class writecsvTests
    {
        [TestMethod()]
        public void WriteCsvFileTest()
        {
            var path = "c://csvfiles//worldcities.csv";
            var doubleTypeConversion = new DoubleConversion();
            var myList = ReadCsv.ReadCsvFile<CitiesImportModel, CityMap>(path, doubleTypeConversion);
            var writeName = "Output1";
            var writePath = "c://csvfiles//" + writeName + ".csv";
            writecsv.WriteCsvFile<CitiesImportModel>(myList, writeName);
            Assert.IsTrue(File.Exists(writePath));
        }
    }
}