namespace DistanceUnits.metrics
{
    public class Meter : Metric
    {
        public Meter(decimal length) : base(length)
        {
        }

        public override decimal lengthToMeters()
        {
            return Length;
        }
    }
}