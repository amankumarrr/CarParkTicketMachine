namespace CarParkTicket.Pages.Service
{
    public class EarlyBirdRateCalculator: IRateCalculator
    {
        public string CalculateRate(DateTime entryDateTime, DateTime exitDateTime)
        {
            return "Early Bird Rate - $13.00";
        }
        public static bool IsEarlyBirdRate(DateTime entryDateTime, DateTime exitDateTime)
        {
            return entryDateTime.TimeOfDay >= new TimeSpan(6, 0, 0) // 6 Am ->
                && entryDateTime.TimeOfDay <= new TimeSpan(9, 0, 0) // 9 Am <-
                && exitDateTime.TimeOfDay >= new TimeSpan(15, 30, 0) // 3: 30 PM ->
                && exitDateTime.TimeOfDay <= new TimeSpan(23, 30, 0) // 11:30 PM <-
                && entryDateTime.Date == exitDateTime.Date; // Same Day 
        }
    }
}
