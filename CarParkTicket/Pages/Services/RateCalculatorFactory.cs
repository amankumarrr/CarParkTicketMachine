namespace CarParkTicket.Pages.Service
{
    public class RateCalculatorFactory
    {
        public IRateCalculator CreateRateCalculator(DateTime entryDateTime, DateTime exitDateTime)
        {
            if (entryDateTime < exitDateTime)
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
            }else
            {
                throw new ArgumentException("Entry time should be earlier than exit time.");
            }
        }
    
    }
}
