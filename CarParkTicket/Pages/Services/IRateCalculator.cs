using System;

namespace CarParkTicket.Pages.Service
{
    public interface IRateCalculator
    {
        string CalculateRate(DateTime entryDateTime, DateTime exitDateTime);
    }

}
