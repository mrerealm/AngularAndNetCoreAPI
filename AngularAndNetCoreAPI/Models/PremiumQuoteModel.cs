using System;
namespace AngularAndNetCoreAPI.Models
{
    public class PremiumQuoteModel
    {
        public decimal Amount { get; set; }
        public int OccupationRating { get; set; }
        public string DOB { get; set; }
        public int Age { get; set; }
    }
}
