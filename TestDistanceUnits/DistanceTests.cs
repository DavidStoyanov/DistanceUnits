using System;
using DistanceUnits;
using DistanceUnits.Interfaces;
using DistanceUnits.metrics;
using NUnit.Framework;

namespace TestDistanceUnits
{
    
    
    public class MetersToUnit
    {
        private Distance<IMetrics> _meters;

        [SetUp]
        public void Setup()
        {
            _meters = Distance<IMetrics>.FromMeters(1000);
        }
        
        [Test]
        public void TestMetersToMeters()
        {
            Assert.AreEqual(1000, _meters.AsMeters());
        }
        
        [Test]
        public void TestMetersToKilometers()
        {
            Assert.AreEqual(1, _meters.AsKilometers());
        }
        
        [Test]
        public void TestMetersToFeets()
        {
            var actual = Math.Round(_meters.AsFeet(), 4);
            Assert.AreEqual(3280.8399m, actual);
        }

        [Test]
        public void TestMetersToMiles()
        {
            var actual = Math.Round(_meters.AsMiles(), 9);
            Assert.AreEqual(0.621371192m, actual);
        }
        
        [Test]
        public void TestMetersToCentimeters()
        {
            Assert.AreEqual(100000, _meters.AsCentimeters());
        }
        
    }

    public class UnitToUnit
    {
        [SetUp]
        public void Setup()
        {
            
        }
        
        [Test]
        public void TestMilesToFeets()
        {
            var mile = new Distance<IMetrics>(new Mile(0.7m));
            Assert.AreEqual(3696 , mile.AsFeet());
        }
        
        [Test]
        public void TestCentimetersToFeets()
        {
            var cm = new Distance<IMetrics>(new Centimeter(88));
            var actual = Math.Round(cm.AsFeet(), 8);
            Assert.AreEqual(2.88713911 , actual);
        }
        
        [Test]
        public void TestKilometersToCentimeters()
        {
            var cm = new Distance<IMetrics>(new Kilometer(0.56887892m));
            Assert.AreEqual(56887.892, cm.AsCentimeters());
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

    public class StaticInitializers
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestFromMeter()
        {
            var a = Distance<IMetrics>.FromMeters(55);
            var b = new Distance<IMetrics>(new Meter(55));
            Assert.AreEqual(a.AsMeters(), b.AsMeters());
        }
        
        [Test]
        public void TestFromKilometers()
        {
            var a = Distance<IMetrics>.FromKilometers(55);
            var b = new Distance<IMetrics>(new Kilometer(55));
            Assert.AreEqual(a.AsKilometers(), b.AsKilometers());
        }
        
        [Test]
        public void TestFromFeets()
        {
            var a = Distance<IMetrics>.FromFeets(55);
            var b = new Distance<IMetrics>(new Feet(55));
            Assert.AreEqual(a.AsFeet(), b.AsFeet());
        }
        
        [Test]
        public void TestFromMiles()
        {
            var a = Distance<IMetrics>.FromMiles(55);
            var b = new Distance<IMetrics>(new Mile(55));
            Assert.AreEqual(a.AsMiles(), b.AsMiles());
        }
        
        [Test]
        public void TestFromCentimeters()
        {
            var a = Distance<IMetrics>.FromCentimeters(55);
            var b = new Distance<IMetrics>(new Centimeter(55));
            Assert.AreEqual(a.AsCentimeters(), b.AsCentimeters());
        }
        
        
    }
}