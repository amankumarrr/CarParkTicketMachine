namespace CarParkTicket.Pages.Service
{
    public class NightRateCalculator: IRateCalculator
    {
        private static int parkingDurationDayLimit = 1; // 6 PM to 6 AM 

        public string CalculateRate(DateTime entryDateTime, DateTime exitDateTime)
        {
            return "Night Rate - $6.50";
        }

        public static bool IsNightRate(DateTime entryDateTime, DateTime exitDateTime)
        {
            return
                IsWeekDay(entryDateTime.DayOfWeek) 
                && entryDateTime.TimeOfDay >= new TimeSpan(18, 0, 0) // 6pm -> 
                && entryDateTime.TimeOfDay <= new TimeSpan(23, 59, 59)// 12am <-
                && exitDateTime.TimeOfDay >= TimeSpan.Zero // 12pm ->
                && exitDateTime.TimeOfDay <= new TimeSpan(6, 0, 0) // 6am <-
                && IsItUnderTheDaysLimit(entryDateTime, exitDateTime); // within 12 hours 
        }


        private static bool IsItUnderTheDaysLimit(DateTime entryDateTime, DateTime exitDateTime)
        {
            TimeSpan parkingDuration = exitDateTime - entryDateTime;
            int totalDays = (int)Math.Ceiling(parkingDuration.TotalDays);
            return (totalDays == parkingDurationDayLimit) ? true: false;
        }

        private static bool IsWeekDay(DayOfWeek day)
        {
            return (day != DayOfWeek.Saturday && day != DayOfWeek.Sunday) ? true : false;
        }

    }
}
