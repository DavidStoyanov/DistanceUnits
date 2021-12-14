using DistanceUnits.Constants;

namespace DistanceUnits.metrics
{
    public class Mile : Metric
    {
        public Mile(decimal length) : base(length)
        {
        }
        
        public override decimal lengthToMeters()
        {
            return Length * Units.MilesToMeters;
        }

    }
}