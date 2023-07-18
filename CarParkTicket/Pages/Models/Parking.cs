using Microsoft.AspNetCore.Mvc;

namespace CarParkTicket.Pages.Models
{
    public class Parking
    {
        [BindProperty]
        public DateTime EntryTime { get; set; }
        [BindProperty]
        public DateTime ExitTime { get; set; }
    }
}
