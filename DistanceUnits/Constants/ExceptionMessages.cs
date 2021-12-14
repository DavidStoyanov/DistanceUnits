using System;

namespace DistanceUnits.Constants
{
    public static class ExceptionMessages
    {
        public static string OperatorOverloadingWithDifferentTypesMsg(Type a, Type b)
        {
            return new string($"Operator overloading with different types for: {a}, {b}");
        }
        
        public static string UnsupportedOperatorOverloadingMsg(Type type)
        {
            return new string($"Unsupported operator overloading for type {type}");
        }
    }
}