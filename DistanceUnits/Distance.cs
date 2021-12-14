using System;
using System.Collections.Generic;
using DistanceUnits.Interfaces;
using DistanceUnits.metrics;
using Microsoft.VisualBasic.CompilerServices;

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

        public static Distance<T> operator +(Distance<T> a, Distance<T> b)
        {
            if (a._metric.GetType() != b._metric.GetType())
            {
                throw new Exception("Operator overloading with different types for: " +
                        $"{a._metric.GetType()}, {b._metric.GetType()}"
                );
            }

            var aLength = a._metric.Length;
            var bLength = a._metric.Length;
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
            
            throw new NotSupportedException($"Unsupported operator overloading for type {a.GetType()}");
        }
    }
}