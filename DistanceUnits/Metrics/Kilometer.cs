using DistanceUnits.Constants;

namespace DistanceUnits.metrics
{
    public class Kilometer : Metric
    {
        public Kilometer(decimal length) : base(length)
        {
        }

        public override decimal lengthToMeters()
        {
            return Length * Units.KilometersToMeters;
        }
    }
}