using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngularAndNetCoreAPI.Models;

namespace AngularAndNetCoreAPI.Services.Interfaces
{
    public interface IPremiumCalculationService
    {
        public Task<decimal> CalculatePremiumAsync(PremiumQuoteModel premiumQuote);
        public Task<IEnumerable<OccupationRatingModel>> GetOccupationRatingsAsync();
    }
}
