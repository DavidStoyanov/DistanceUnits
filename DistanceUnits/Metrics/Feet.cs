using DistanceUnits.Constants;

namespace DistanceUnits.metrics
{
    public class Feet : Metric
    {
        public Feet(decimal length) : base(length)
        {
        }

        public override decimal lengthToMeters()
        {
            return Length * Units.FeetToMeters;
        }
    }
}