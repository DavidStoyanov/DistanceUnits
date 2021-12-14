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
            return IsMetricTypeOf(typeof(Meter)) ?
                _metric.Length : LengthToMeters();
        }
        
        public decimal AsKilometers()
        {
            return IsMetricTypeOf(typeof(Kilometer)) ?
                _metric.Length :LengthByRatio(Units.KilometersToMeters);
        }
        
        public decimal AsFeet()
        {
            return IsMetricTypeOf(typeof(Feet)) ?
                _metric.Length :LengthByRatio(Units.FeetToMeters);
        }

        public decimal AsMiles()
        {
            return IsMetricTypeOf(typeof(Mile)) ?
                _metric.Length :LengthByRatio(Units.MilesToMeters);
        }
        
        public decimal AsCentimeters()
        {
            return IsMetricTypeOf(typeof(Centimeter)) ?
                _metric.Length :LengthByRatio(Units.CentimetersToMeters);
        }
        
        public static Distance<T> FromMeters(decimal meters)
        {
            return new Distance<T>( (T)(IMetrics) new Meter(meters));
        }
        
        public static Distance<T> FromKilometers(decimal kilometers)
        {
            return new Distance<T>( (T)(IMetrics) new Kilometer(kilometers));
        }
        
        public static Distance<T> FromFeets(decimal feets)
        {
            return new Distance<T>((T)(IMetrics) new Feet(feets));
        } 
        
        public static Distance<T> FromMiles(decimal miles)
        {
            return new Distance<T>((T)(IMetrics) new Mile(miles));
        }
        
        public static Distance<T> FromCentimeters(decimal centimeters)
        {
            return new Distance<T>((T)(IMetrics) new Centimeter(centimeters));
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
        
        private decimal LengthToMeters()
        {
            return ((IConvert)_metric).lengthToMeters();
        }
        
        private decimal LengthByRatio(decimal ratio)
        {
            return LengthToMeters() / ratio;
        }

        private bool IsMetricTypeOf(Type type)
        {
            return _metric.GetType() == type;
        }
    }
}