﻿using Cities;
using Csv;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace csv.Tests
{
    [TestClass()]
    public class readcsvTests
    {
        [TestMethod()]
        public void ReadInCSVTest()
        {
            var path = "c://csvfiles//worldcities.csv";
            var model = new CityModel();
            var map = new CityMap();
            var doubleTypeConversion = new DoubleConversion();
            IList<CityModel> myList = (IList<CityModel>)ReadCsv.ReadCsvFile<CityModel>(path, model, map, doubleTypeConversion);
            //var cityList = myList.Where(city => city.Capital.Equals("primary"));
            var cityList = from s in myList
                           where s.Capital.Equals("primary")
                           orderby s.Country ascending
                           select s;
            foreach (CityModel city in cityList) {
                Debug.Write(city.Country + ": " + city.City_name + Environment.NewLine);
            }

            var QSCount = (from city in cityList
                           select city).Count();


            Debug.Write(QSCount);
            
            Assert.AreEqual(15493, myList.Count());
            


            // countryQuery = records.Where(city => city.Country.Equals("United States"));
            /*
            foreach (CityModel city in countryQuery)
            {
                var name = city.City_name.ToString();
            }
            */
        }
    }
}