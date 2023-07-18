namespace CarParkTicket.Pages.Service
{
    public class WeekendRateCalculator : IRateCalculator
    {
        private static int parkingDurationLimit = 48;  // 12 AM Friday till Sunday 12 AM 

        public string CalculateRate(DateTime entryDateTime, DateTime exitDateTime)
        {
            return "Weekend Rate - $10.00";
        }

        public static bool IsWeekendRate(DateTime entryDateTime, DateTime exitDateTime)
        {
            return 
                ((entryDateTime.DayOfWeek == DayOfWeek.Friday && entryDateTime.TimeOfDay >= TimeSpan.Zero) // Friday and after 12 AM 
                    || IsWeekend(entryDateTime.DayOfWeek)) // Or any Weekend
                && ((exitDateTime.DayOfWeek == DayOfWeek.Sunday && exitDateTime.TimeOfDay <= new TimeSpan(23, 59, 59) ) // If it is Sunday, time must be before 12 AM  
                    || exitDateTime.DayOfWeek == DayOfWeek.Saturday)//Or Anytime on Saturday
                && IsItWithinParkingDurationLimit(entryDateTime, exitDateTime);  
        }


        private static bool IsItWithinParkingDurationLimit(DateTime entryDateTime, DateTime exitDateTime)
        {
            TimeSpan parkingDuration = exitDateTime - entryDateTime;
            int totalHours = (int)Math.Ceiling(parkingDuration.TotalHours);
            return (totalHours <= parkingDurationLimit) ? true : false;
        }

        private static bool IsWeekend(DayOfWeek day)
        {
            return (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday) ? true : false;
        }
    }
}
