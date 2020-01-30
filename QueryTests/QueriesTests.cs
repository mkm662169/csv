using Cities;
using Csv;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Query.Tests
{
    [TestClass()]
    public class QueriesTests
    {
        private readonly string path = "c://csvfiles//worldcities.csv";
        private readonly DoubleConversion doubleTypeConversion = new DoubleConversion();
        private dynamic myList;
        private string cityType = "primary";

        [TestMethod()]
        public void GetPopulationsTest()
        {
            myList = ReadCsv.ReadCsvFile<CitiesImportModel, CityMap>(path, doubleTypeConversion);
            int[] populations = Queries.GetPopulations(myList, cityType);
            Assert.IsNotNull(populations);
        }

        [TestMethod()]
        public void StandDevQueryTest()
        {
            myList = ReadCsv.ReadCsvFile<CitiesImportModel, CityMap>(path, doubleTypeConversion);
            double standDev = Queries.StandDevQuery(myList, cityType);
            Assert.AreEqual(350.4383, Math.Round(standDev, 4, MidpointRounding.AwayFromZero));
        }

        [TestMethod()]
        public void ZScoreQueryTest()
        {
            myList = ReadCsv.ReadCsvFile<CitiesImportModel, CityMap>(path, doubleTypeConversion);
            int[] populations = Queries.GetPopulations(myList, cityType);
            int score = populations[9];
            double zScore = Queries.ZScoreQuery(myList, cityType, score);
            Assert.AreEqual(27872.3504, Math.Round(zScore, 4, MidpointRounding.AwayFromZero));
        }
    }
}