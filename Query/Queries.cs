using System;
using Cities;
using System.Collections.Generic;
using System.Linq;

namespace Query
{
    public class Queries
    {
        public static int[] GetPopulations(IList<CitiesImportModel> myList, string cityType)
        {
            var query = (from s in myList
                         where s.Capital.Equals(cityType)
                         select s);

            int[] populations = new int[myList.Count];
            int i = 0;

            foreach (CitiesImportModel city in query)
            {
                populations[i] = Convert.ToInt32(city.Population);
                i++;

            }
            return populations;

        }
        public static double StandDevQuery(IList<CitiesImportModel> myList, string cityType)
        {
            int[] populations = GetPopulations(myList, cityType);
            double standDev = StatStandDev.StandDev(populations);

            return standDev;
        }

        public static double ZScoreQuery(IList<CitiesImportModel> myList, string cityType, int score)
        {
            int[] populations = GetPopulations(myList, cityType);
            double mean = StatMean.Mean(populations);
            double standDev = StandDevQuery(myList, cityType);
            double zScore = (score - mean) / standDev;
            return zScore;
        }
    }
}
