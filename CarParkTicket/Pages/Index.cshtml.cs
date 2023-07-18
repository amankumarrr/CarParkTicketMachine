using CarParkTicket.Pages.Models;
using CarParkTicket.Pages.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarParkTicket.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private RateCalculatorFactory rateCalculatorFactory;

        public Parking cpK;
        public string ticketPrice { get; set; }
        public string Error { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            rateCalculatorFactory = new RateCalculatorFactory();
            ticketPrice = "";
        }

        public void OnGet()
        {

        }

        public void OnPostSubmit(Parking parking)
        {

            try
            {

                if(parking.EntryTime < parking.ExitTime)
                {
                    this.Error = string.Empty;
                    IRateCalculator rateCalculator = rateCalculatorFactory.CreateRateCalculator(parking.EntryTime, parking.ExitTime);
                    string rate = rateCalculator.CalculateRate(parking.EntryTime, parking.ExitTime);
                    this.ticketPrice = rate;
                    cpK = parking;
                }
                else
                {
                    throw new Exception("Entry time should be earlier than exit time.");
                }
            }
            catch(Exception ex)
            {
                this.ticketPrice = string.Empty;
                this.Error =  $"Oops! {ex.Message}";
            }
        }
    }
}