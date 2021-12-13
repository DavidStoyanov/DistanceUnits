using System;
using DistanceUnits.metrics;

namespace DistanceUnits
{
    class Program
    {
        public static void Main(string[] args)
        {
            var a = new Distance<IMetrics>(new Mile(150));
            Distance<IMetrics> b = Distance<IMetrics>.FromMeters(1700);
            Console.WriteLine(a.AsMeters());
            Console.WriteLine(a.AsMiles());
            
            //todo: Add KM FEET, fix MILE
        }
    }

}
