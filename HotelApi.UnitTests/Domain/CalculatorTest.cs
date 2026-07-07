using HotelApi.Domain.Business.Calculus;
using HotelApi.Domain.Data.Location.Params;
using NUnit.Framework;

namespace HotelApi.Tests
{
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void CalculateDistance_ReturnsCorrectValue()
        {
            var a = new LocationQuery() { Latitude = 10, Longitude = 10 };
            var b = new LocationQuery() { Latitude = 13, Longitude = 14 };

            var result = _calculator.CalculateDistance(a, b);

            Assert.AreEqual(5, result, 0.1);
        }

        [Test]
        public void SortLocation_ReturnsMinusOne_WhenFirstIsCloser()
        {
            var user = new LocationQuery() { Latitude = 0, Longitude = 0 };
            var first = new LocationQuery() { Latitude = 1, Longitude = 1 };
            var second = new LocationQuery() { Latitude = 5, Longitude = 5 };

            var negativeResult = _calculator.DetermineLocationSort(user, first, second);
            var positiveResult = _calculator.DetermineLocationSort(user, second, first);

            Assert.Multiple(() =>
            {
                Assert.That(-1 == negativeResult, "The negative result is thrown correctly.");
                Assert.That(1 == positiveResult, "The positive result is thrown correctly.");
            });

        }

        [Test]
        public void IsInRange_ReturnsTrue_WhenWithinRadius()
        {
            var userLocation = new LocationQuery() { Latitude = 0, Longitude = 0 };
            var hotelLocation = new LocationQuery() { Latitude = 3, Longitude = 4 };
            var radius = 10.0;

            Assert.That(_calculator.CalculateDistance(userLocation, hotelLocation) < radius);
        }
    }
}
