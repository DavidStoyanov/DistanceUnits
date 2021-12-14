using DistanceUnits.Constants;

namespace DistanceUnits.metrics
{
    public class Centimeter : Metric
    {
        public Centimeter(decimal length) : base(length)
        {
        }

        public override decimal lengthToMeters()
        {
            return Length * Units.CentimetersToMeters;
        }
    }
}