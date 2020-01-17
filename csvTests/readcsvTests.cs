using Cities;
using Csv;
using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Csv.Tests
{
    [TestClass()]
    public class readcsvTests
    {
        [TestMethod()]
        public void WritecsvFileTest()
        {
            string file_name = "capital";
            var path = "c://csvfiles//worldcities.csv";
            var doubleTypeConversion = new DoubleConversion();
            IList<CityModel> myList = ReadCsv.ReadCsvFile<CityModel, CityMap>(path, doubleTypeConversion);

            IEnumerable<CityModel> countryCapitalQuery = from s in myList
                                                         where s.Capital.Equals("primary")
                                                         orderby s.Capital ascending
                                                         select s;

            foreach (CityModel city in countryCapitalQuery)
            {
                Debug.Write(city.Capital + ": " + city.City_name + Environment.NewLine);
            }

            writecsv.WritecsvFile<CityModel>(countryCapitalQuery, file_name);

            var QSCount = (from city in countryCapitalQuery
                           select city).Count();
            Debug.Write(QSCount);

            Assert.AreEqual(15493, myList.Count());
        }
    }

    [TestClass()]
    public class ReadcsvTests
    {
        [TestMethod()]
        public void ReadInCSVTest()
        {
            var path = "c://csvfiles//worldcities.csv";
            var doubleTypeConversion = new DoubleConversion();
            IList<CityModelImport> myList = ReadCsv.ReadCsvFile<CityModelImport, CityMap>(path, doubleTypeConversion);
            var countryCapitalQuery = (from s in myList
                                       where s.Capital.Equals("primary")
                                       orderby s.Country ascending
                                       select s);

            var queryName = nameof(countryCapitalQuery);
            var writePath = "c://csvfiles//" + queryName + ".csv";
            using (var writer = new StreamWriter(writePath))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(countryCapitalQuery);
            }
            Assert.IsTrue(File.Exists(writePath));

            var QSCount = (from city in countryCapitalQuery
                           select city).Count();



            Assert.AreEqual(15493, myList.Count());

            using (var dbContext = new CitiesContext())
            {
                dbContext.Database.Connection.Close();
            }
            var countryGroups = from city in countryCapitalQuery
                                group city by new
                                {
                                    city.Country,
                                    city.ISO2,
                                    city.ISO3
                                }
                                into countryGroup
                                orderby countryGroup.Key.Country
                                select countryGroup;

            using (var db = new CitiesContext())
            {
                foreach (var country in countryGroups)
                {
                    var countryName = country.Key.Country;
                    var ISO2 = country.Key.ISO2;
                    var ISO3 = country.Key.ISO3;
                    var CountryEntity = new CountryEntity
                    {
                        Name = countryName,
                        ISO2 = ISO2,
                        ISO3 = ISO3
                    };
                    db.Countries.Add(CountryEntity);
                    db.SaveChanges();
                    int id = CountryEntity.CountryID;
                    Debug.Write(country);
                    foreach (var city in country)
                    {
                        var CityEntity = new CityEntity
                        {
                            City_name = city.City_name,
                            Admin_name = city.Admin_name,
                            City_ascii = city.City_ascii,
                            Lat = city.Lat,
                            Lng = city.Lng,
                            Capital = city.Capital,
                            CountryId = id,
                            Population = city.Population
                        };
                        db.Cities.Add(CityEntity);
                        db.SaveChanges();
                    }
                }
            }


        }
    }
}