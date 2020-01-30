﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Query
{
    public class StatStandDev
    {
        public static double StandDev(int[] values)
        {
            int sumVals = 0;
            foreach (int a in values)
            {
                sumVals += a;
            }
            double mean = sumVals / values.Length;

            dynamic squaredDeviation = new dynamic[values.Length]; ;
            int i = 0;

            foreach (int a in values)
            {
                dynamic dev = a - mean;
                squaredDeviation[i] = dev * dev;
                i++;
            }

            int sumSDevs = 0;
            foreach (dynamic a in squaredDeviation)
            {
                sumSDevs += a;
            }
            double variance = sumSDevs / squaredDeviation.Length;

            double standDev = Math.Pow(variance, 1.0 / 2.0);
            return standDev;
        }

        public static double StandDev(double[] values)
        {
            double sumVals = 0.0;
            foreach (double a in values)
            {
                sumVals += a;
            }
            double mean = sumVals / values.Length;

            double[] squaredDeviation = new double[values.Length]; ;
            int i = 0;

            foreach (double a in values)
            {
                double dev = a - mean;
                squaredDeviation[i] = dev * dev;
                i++;
            }

            double sumSDevs = 0;
            foreach (double a in squaredDeviation)
            {
                sumSDevs += a;
            }
            double variance = sumSDevs / squaredDeviation.Length;

            double standDev = Math.Pow(variance, 1.0 / 2.0);
            return standDev;
        }
    }
}
