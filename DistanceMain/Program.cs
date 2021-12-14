// See https://aka.ms/new-console-template for more information

using System;
using DistanceUnits;
using DistanceUnits.Interfaces;
using DistanceUnits.metrics;

namespace DistanceMain
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //todo: Add KM FEET, fix MILE

            const decimal n = 500m;
            Distance<IMetrics> a = Distance<IMetrics>.FromMeters(150);
            Distance<IMetrics> b = Distance<IMetrics>.FromMeters(70);
            Console.WriteLine((a + b).AsMeters());
            
            Distance<IMetrics> mile = Distance<IMetrics>.FromMiles(1);
            Console.WriteLine(mile.AsMeters());
            
            
            
            
        }
    }
}