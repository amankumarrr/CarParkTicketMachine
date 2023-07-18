namespace CarParkTicket.Pages.Service
{
    public class RateCalculatorFactory
    {
        public IRateCalculator CreateRateCalculator(DateTime entryDateTime, DateTime exitDateTime)
        {
            if (EarlyBirdRateCalculator.IsEarlyBirdRate(entryDateTime, exitDateTime))
            {
                return new EarlyBirdRateCalculator();
            }
            else if (NightRateCalculator.IsNightRate(entryDateTime, exitDateTime))
            {
                return new NightRateCalculator();
            }
            else if (WeekendRateCalculator.IsWeekendRate(entryDateTime, exitDateTime))
            {
                return new WeekendRateCalculator();
            }
            else
            {
                return new StandardRateCalculator();
            }
        }
    
    }
}
