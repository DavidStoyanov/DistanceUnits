// See https://aka.ms/new-console-template for more information

using System;
using DistanceUnits;
using DistanceUnits.Interfaces;

namespace DistanceMain
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Distance<IMetrics> a = Distance<IMetrics>.FromMeters(150);
            Distance<IMetrics> b = Distance<IMetrics>.FromMeters(70);
            Console.WriteLine((a + b).AsMeters());
            
            //todo: Add KM FEET
        }
    }
}