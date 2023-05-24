using NUnit.Framework;

namespace WorkshopTime.Tests
{
    [TestFixture]
        public class TimePeriodTests
    {
        [Test]
        public void TimePeriod_ConstructWithValidValues_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => new TimePeriod(1, 30, 0));
        }

        [Test]
        public void TimePeriod_ConstructWithInvalidValues_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new TimePeriod(-1, 0, 0));
            Assert.Throws<ArgumentException>(() => new TimePeriod(0, -1, 0));
            Assert.Throws<ArgumentException>(() => new TimePeriod(0, 0, -1));
        }

        [Test]
        public void TimePeriod_Equals_TwoTimePeriodsWithSameValues_ReturnsTrue()
        {
            var period1 = new TimePeriod(1, 30, 0);
            var period2 = new TimePeriod(1, 30, 0);

            Assert.AreEqual(period1, period2);
        }

        [Test]
        public void TimePeriod_CompareTo_TwoTimePeriodsWithDifferentValues_ReturnsCorrectComparisonResult()
        {
            var shorterPeriod = new TimePeriod(1, 0, 0);
            var longerPeriod = new TimePeriod(2, 0, 0);
        }

        [Test]
        public void TimePeriod_Plus_TimePeriod_Exceeding24Hours_WrapsAround()
        {
            var period1 = new TimePeriod(23, 0, 0);
            var period2 = new TimePeriod(2, 0, 0);

            var result = period1.Plus(period2);

            var expected = new TimePeriod(1, 0, 0);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void TimePeriod_ToString_ReturnsCorrectStringRepresentation()
        {
            var period = new TimePeriod(12, 30, 45);

            var result = period.ToString();

            var expected = "12:30:45";
            Assert.AreEqual(expected, result);
        }
    }

    public class TestFixtureAttribute : Attribute
    {
    }


}

