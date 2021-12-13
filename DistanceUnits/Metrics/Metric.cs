namespace DistanceUnits.metrics
{
    public abstract class Metric : IMetrics, IConvert
    {
        public decimal Length { get; private set; }

        protected Metric(decimal length)
        {
            Length = length;
        }

        public abstract decimal lengthToMeters();
    }
}