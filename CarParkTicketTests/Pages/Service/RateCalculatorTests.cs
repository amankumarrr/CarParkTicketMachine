using NUnit.Framework;

namespace CarParkTicket.Pages.Service.Tests
{

    public class RateCalculatorTests
    {
        private RateCalculatorFactory rateCalculatorFactory;


        [SetUp]
        public void Setup()
        {
            this.rateCalculatorFactory = new RateCalculatorFactory();
        }

        [Test]
        public void CalculateRate_EarlyBirdRate()
        {
            DateTime entryDateTime = new DateTime(2023, 7, 13, 8, 0, 0); // Thursday, 08:00 AM 
            DateTime exitDateTime = new DateTime(2023, 7, 13, 16, 0, 0); // Thursday, 04:00 PM 

            IRateCalculator rateCalculator = rateCalculatorFactory.CreateRateCalculator(entryDateTime, exitDateTime);

            string rate = rateCalculator.CalculateRate(entryDateTime, exitDateTime);

            Assert.AreEqual("Early Bird Rate - $13.00", rate);
        }

        [Test]
        public void CalculateRate_NightRate()
        {
            DateTime entryDateTime = new DateTime(2023, 7, 14, 19, 0, 0); // Friday,   7:00 PM
            DateTime exitDateTime = new DateTime(2023, 7, 15, 5, 0, 0);   // Saturday, 5:00 AM

            IRateCalculator rateCalculator = rateCalculatorFactory.CreateRateCalculator(entryDateTime, exitDateTime);

            string rate = rateCalculator.CalculateRate(entryDateTime, exitDateTime);

            Assert.AreEqual("Night Rate - $6.50", rate);
        }

        [Test]
        public void CalculateRate_WeekendRate()
        {
            DateTime entryDateTime = new DateTime(2023, 7, 15, 0, 0, 0); // Friday, 12:00 AM
            DateTime exitDateTime = new DateTime(2023, 7, 16, 20, 0, 0);  // Sunday, 08:00 PM 

            IRateCalculator rateCalculator = rateCalculatorFactory.CreateRateCalculator(entryDateTime, exitDateTime);

            string rate = rateCalculator.CalculateRate(entryDateTime, exitDateTime);

            Assert.AreEqual("Weekend Rate - $10.00", rate);
        }


        [Test]
        public void CalculateRate_For_1HourWeekDay()
        {
            DateTime entryDateTime = new DateTime(2023, 7, 17, 10, 0, 0); // Monday, 10:00 AM 
            DateTime exitDateTime = new DateTime(2023, 7, 17, 11, 0, 0);  // Monday, 11:00 AM

            IRateCalculator rateCalculator = rateCalculatorFactory.CreateRateCalculator(entryDateTime, exitDateTime);

            string rate = rateCalculator.CalculateRate(entryDateTime, exitDateTime);

            Assert.AreEqual("Standard Rate - $5.00", rate);
        }

        [Test]
        public void CalculateRate_For_2HoursWeekDay()
        {
            DateTime entryDateTime = new DateTime(2023, 7, 17, 10, 0, 0); // Monday, 10:00 AM
            DateTime exitDateTime = new DateTime(2023, 7, 17, 12, 0, 0);  // Monday, 12:00 AM

            IRateCalculator rateCalculator = rateCalculatorFactory.CreateRateCalculator(entryDateTime, exitDateTime);

            string rate = rateCalculator.CalculateRate(entryDateTime, exitDateTime);

            Assert.AreEqual("Standard Rate - $10.00", rate);
        }
        [Test]
        public void CalculateRate_For_3HoursWeekDay()
        {
            DateTime entryDateTime = new DateTime(2023, 7, 17, 10, 0, 0); // Monday, 10:00 AM
            DateTime exitDateTime = new DateTime(2023, 7, 17, 13, 0, 0);  // Monday, 01:00 PM

            IRateCalculator rateCalculator = rateCalculatorFactory.CreateRateCalculator(entryDateTime, exitDateTime);

            string rate = rateCalculator.CalculateRate(entryDateTime, exitDateTime);
            
            Assert.AreEqual("Standard Rate - $15.00", rate);
        }

        [Test]
        public void CalculateRate_For_WeekendOverTime()
        {
            DateTime entryDateTime = new DateTime(2023, 7, 15, 10, 0, 0); // Saturday, 10:00 AM
            DateTime exitDateTime = new DateTime(2023, 7, 18, 13, 30, 0); // Tuesday,  01:30 AM

            IRateCalculator rateCalculator = rateCalculatorFactory.CreateRateCalculator(entryDateTime, exitDateTime);

            string rate = rateCalculator.CalculateRate(entryDateTime, exitDateTime);

            Assert.AreEqual("Standard Rate - $20.00 per day, Total Price: $80", rate);
        }

        [Test]
        public void CalculateRate_For_24HoursWeekDays()
        {
            DateTime entryDateTime = new DateTime(2023, 7, 13, 6, 0, 0); // Thursday, 06:00 AM
            DateTime exitDateTime = new DateTime(2023, 7, 14, 6, 0, 0); //  Friday,   06:00 AM

            IRateCalculator rateCalculator = rateCalculatorFactory.CreateRateCalculator(entryDateTime, exitDateTime);

            string rate = rateCalculator.CalculateRate(entryDateTime, exitDateTime);

            Assert.AreEqual("Standard Rate - $20.00 per day, Total Price: $20", rate);
        }

        [Test]
        public void CalculateRate_For_25HoursWeekDays()
        {
            DateTime entryDateTime = new DateTime(2023, 7, 13, 6, 0, 0); // Thursday, 06:00 AM
            DateTime exitDateTime = new DateTime(2023, 7, 14, 7, 0, 0); //  Friday,   07:00 AM

            IRateCalculator rateCalculator = rateCalculatorFactory.CreateRateCalculator(entryDateTime, exitDateTime);

            string rate = rateCalculator.CalculateRate(entryDateTime, exitDateTime);

            Assert.AreEqual("Standard Rate - $20.00 per day, Total Price: $40", rate);
        }

        [Test]
        public void CalculateRate_ShouldThrowArgumentException_WhenEntryTimeAfterExitTime()
        {
            // Arrange
            DateTime entryDateTime = new DateTime(2023, 7, 21, 12, 0, 0); // Entry time after exit time
            DateTime exitDateTime = new DateTime(2023, 7, 21, 10, 0, 0); // Exit time before entry time

            RateCalculatorFactory rateCalculatorFactory = new RateCalculatorFactory();
            // Act & Assert 
            Assert.Throws<ArgumentException>(() => rateCalculatorFactory.CreateRateCalculator(entryDateTime, exitDateTime));
        }
    }
}