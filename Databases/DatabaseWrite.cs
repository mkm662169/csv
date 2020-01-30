using System;
using Cities;
using System.Collections.Generic;
using System.Linq;

namespace Databases
{
    public class DatabaseWrite
    {
        public static void WriteToDB(IList<CitiesImportModel> myList, string typeOfCity)
        {
            var countryCapitalQuery = (from s in myList
                                       where s.Capital.Equals(typeOfCity)
                                       orderby s.Country ascending
                                       select s);

            using (var dbContext = new CityContext())
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

            using (var db = new CityContext())
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
