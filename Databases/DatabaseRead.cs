using System;
using System.Collections.Generic;
using System.Text;
using Cities;
using System.Linq;

namespace Databases
{
    public class DatabaseRead
    {
        public static IOrderedQueryable<CityEntity> ReadCitiesDB(string typeOfCity)
        {
            CityContext db = new CityContext();
            var city = (from s in db.Cities
                        where s.Capital.Equals(typeOfCity)
                        orderby s.Country ascending
                        select s);
            return city;

        }
    }
}
