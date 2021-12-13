namespace DistanceUnits.metrics
{
    public class Centimeter : Metric
    {
        private static decimal CentimetersToMeters = 0.01m;
        
        public Centimeter(decimal length) : base(length)
        {
        }

        public override decimal lengthToMeters()
        {
            return Length * CentimetersToMeters;
        }
    }
}