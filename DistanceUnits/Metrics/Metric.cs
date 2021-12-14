using System;
using DistanceUnits.Interfaces;

namespace DistanceUnits.metrics
{
    public abstract class Metric : IMetrics, IConvert
    {
        public decimal Length { get; private set; }

        protected Metric(decimal length)
        {
            Length = length;
        }

        public abstract decimal lengthToMeters();
        

        public static Metric operator +(Metric a, Metric b)
        {
            ValidateMetricType(a, b);
            return a + b;
        }
        
        public static Metric operator -(Metric a, Metric b)
        {
            ValidateMetricType(a, b);
            return a - b;
        }

        private static void ValidateMetricType(Metric a, Metric b)
        {
            if (a.GetType() != b.GetType())
            {
                throw new Exception($"Type difference: {a.GetType()} to {b.GetType()}");
            }
        }
    }
}