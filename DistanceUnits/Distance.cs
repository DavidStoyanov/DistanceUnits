using System;
using DistanceUnits.Constants;
using DistanceUnits.Interfaces;
using DistanceUnits.metrics;

namespace DistanceUnits
{
    public class Distance<T> where T : IMetrics
    {
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
            return meters / Units.MilesToMeters;
        }
        
        public decimal AsCentimeters()
        {
            if (_metric.GetType() == typeof(Centimeter))
            {
                return _metric.Length;
            }

            decimal meters = ((IConvert)_metric).lengthToMeters();
            return meters / Units.CentimetersToMeters;
        }
        
        public static Distance<T> FromMeters(decimal metrics)
        {
            return new Distance<T>( (T)(IMetrics) new Meter(metrics));
        }
        
        public static Distance<T> FromMiles(decimal miles)
        {
            return new Distance<T>((T)(IMetrics) new Mile(miles));
        }

        public static Distance<T> operator +(Distance<T> a, Distance<T> b)
        {
            var aType = a._metric.GetType();
            var bType = b._metric.GetType();
            
            if (aType != bType)
            {
                throw new Exception(ExceptionMessages
                    .OperatorOverloadingWithDifferentTypesMsg(aType, bType)
                );
            }

            var aLength = a._metric.Length;
            var bLength = b._metric.Length;
            var sumLength = aLength + bLength;
            
            if (a._metric.GetType() == typeof(Meter))
            {
                return new Distance<T>((T)(IMetrics)new Meter(sumLength));
            }
            else if (a._metric.GetType() == typeof(Kilometer))
            {
                return new Distance<T>((T)(IMetrics)new Kilometer(sumLength));
            }
            else if (a._metric.GetType() == typeof(Feet))
            {
                return new Distance<T>((T)(IMetrics)new Feet(sumLength));
            }
            else if (a._metric.GetType() == typeof(Mile))
            {
                return new Distance<T>((T)(IMetrics)new Mile(sumLength));
            }
            else if (a._metric.GetType() == typeof(Centimeter))
            {
                return new Distance<T>((T)(IMetrics)new Centimeter(sumLength));
            }
            
            throw new NotSupportedException(ExceptionMessages
                .UnsupportedOperatorOverloadingMsg(a._metric.GetType())
            );
        }
    }
}