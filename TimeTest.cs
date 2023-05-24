using NUnit.Framework;
namespace WorkshopTime.Tests
{
    [TestFixture]
    public class TimeTests
    {
        [Test]
        public void Time_ConstructWithValidValues_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => new Time(12, 30, 0));
        }

       

        [Test]
        public void Time_Equals_TwoTimesWithSameValues_ReturnsTrue()
        {
            var time1 = new Time(12, 30, 0);
            var time2 = new Time(12, 30, 0);

            Assert.AreEqual(time1, time2);
        }

        [Test]
        public void Time_CompareTo_TwoTimesWithDifferentValues_ReturnsCorrectComparisonResult()
        {
            var earlierTime = new Time(10, 0, 0);
            var laterTime = new Time(12, 0, 0);
            
        }

        [Test]
        public void Time_Plus_TimePeriod_AddsTimePeriodToTime()
        {
            var time = new Time(12, 30, 0);
            var period = new TimePeriod(1, 15, 0);

            var expected = new Time(13, 45, 0);
        }

        [Test]
        public void Time_Plus_TimePeriod_Exceeding24Hours_WrapsAround()
        {
            var time = new Time(23, 0, 0);
            var period = new TimePeriod(2, 0, 0);
            

            var expected = new Time(1, 0, 0);
        }
        
        [Test]
        public void Time_ToString_ReturnsCorrectStringRepresentation()
        {
            var time = new Time(12, 30, 45);

            var result = time.ToString();

            var expected = "12:30:45";
            Assert.AreEqual(expected, result);
        }
    }
}
