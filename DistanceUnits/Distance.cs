using DistanceUnits.metrics;

namespace DistanceUnits
{
    public class Distance<T> where T : IMetrics
    {
        private static decimal CentimetersToMeters = 0.01m;
        private static decimal MilesToMeters = 1.609344m;
        
        private readonly T _metric;

        public Distance(T metric)
        {
            _metric = metric;
        }

        public decimal AsMeters()
        {
            if (_metric.GetType() == typeof(Meter))
            {
                return _metric.Length;
            }
            
            return ((IConvert)_metric).lengthToMeters();
        }

        public decimal AsMiles()
        {
            if (_metric.GetType() == typeof(Mile))
            {
                return _metric.Length;
            }

            decimal meters = ((IConvert)_metric).lengthToMeters();
            return meters / MilesToMeters;
        }
        
        public decimal AsCentimeters()
        {
            if (_metric.GetType() == typeof(Centimeter))
            {
                return _metric.Length;
            }

            decimal meters = ((IConvert)_metric).lengthToMeters();
            return meters / CentimetersToMeters;
        }
        
        public static Distance<T> FromMeters(decimal metrics)
        {
            return new Distance<T>( (T)(IMetrics) new Meter(metrics));
        }
        
        public static Distance<T> FromMiles(decimal miles)
        {
            return new Distance<T>((T)(IMetrics) new Mile(miles));
        }

        /*public static Distance operator +(Distance a, Distance b)
        {
            return new Distance(a._metric + b._metric);
        }
        
        public static Distance operator -(Distance a, Distance b)
        {
            return new Distance(a._metric - b._metric);
        }*/
    }
}