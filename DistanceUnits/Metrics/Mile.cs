namespace DistanceUnits.metrics
{
    public class Mile : Metric
    {
        private static decimal MilesToMeters = 1609.344m;

        public Mile(decimal length) : base(length)
        {
        }
        
        public override decimal lengthToMeters()
        {
            return Length * MilesToMeters;
        }

    }
}