using System;
using System.Collections.Generic;
using System.Text;

namespace Query
{
    public class StatMean
    {
        public static dynamic Mean(int[] values)
        {
            var sum = 0;
            foreach (int a in values)
            {
                sum += a;
            }
            double tempMean = sum / values.Length;
            double mean = Math.Round(tempMean, 2, MidpointRounding.AwayFromZero);
            return mean;
        }

        public static dynamic Mean(double[] values)
        {
            var sum = 0.0;
            foreach (double a in values)
            {
                sum += a;
            }
            double tempMean = sum / values.Length;
            double mean = Math.Round(tempMean, 2, MidpointRounding.AwayFromZero);
            return mean;
        }
    }
}
