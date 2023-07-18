namespace CarParkTicket.Pages.Service
{
    public class StandardRateCalculator : IRateCalculator
    {
        public string CalculateRate(DateTime entryDateTime, DateTime exitDateTime)
        {
            TimeSpan parkingDuration = exitDateTime - entryDateTime;
            int totalHours = (int)Math.Ceiling(parkingDuration.TotalHours);

            if (totalHours <= 1)
            {
                return "Standard Rate - $5.00";
            }
            else if (totalHours <= 2)
            {
                return "Standard Rate - $10.00";
            }
            else if (totalHours <= 3)
            {
                return "Standard Rate - $15.00";
            }
            else
            {

                int totalDays = totalHours / 24;
                int remainderHours = totalHours % 24;

                if (remainderHours > 0)  // it checks if we have more than 24 hours then it charges for the next day 
                {
                    totalDays++;
                }

                double totalPrice = (totalDays * 20.00);
                return $"Standard Rate - $20.00 per day, Total Price: ${totalPrice}";
            }
        }
    }
}
