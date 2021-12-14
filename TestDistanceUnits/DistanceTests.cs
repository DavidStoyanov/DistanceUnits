using System;
using DistanceUnits;
using DistanceUnits.Interfaces;
using DistanceUnits.metrics;
using NUnit.Framework;

namespace TestDistanceUnits
{
    
    
    public class UnitTests1
    {
        private Distance<IMetrics> _meters;

        [SetUp]
        public void Setup()
        {
            _meters = Distance<IMetrics>.FromMeters(1000);
        }

        [Test]
        public void TestMetersToMiles()
        {
            var expected = Math.Round(0.621371192m, 7);
            var actual = Math.Round(_meters.AsMiles(), 7);
            Assert.AreEqual(expected, actual);
        }
        
    }
    
    public class OperatorOverloads
    {
        private Distance<IMetrics> _distanceA, _distanceB;

        [SetUp]
        public void Setup()
        {
            Distance<IMetrics> miles = new Distance<IMetrics>(new Mile(150));
            Distance<IMetrics> meters = Distance<IMetrics>.FromMiles(1000);
            
            _distanceA = Distance<IMetrics>.FromMeters(11);
            _distanceB = Distance<IMetrics>.FromMeters(33);
        }

        [Test]
        public void TestPlusOperatorOverloadWithMeters()
        {
            var distance = _distanceA + _distanceB;
            Assert.AreEqual(44, distance.AsMeters());
        }
        
        [Test]
        [Ignore("not-implemented")]
        public void TestMinusOperatorOverloadWithMeters()
        {
            
        }
    }
}