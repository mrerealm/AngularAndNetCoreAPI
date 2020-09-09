using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngularAndNetCoreAPI.Models;
using AngularAndNetCoreAPI.Services.Interfaces;

namespace AngularAndNetCoreAPI.Services
{
    public class PremiumCalculationService: IPremiumCalculationService
    {
        private static readonly decimal[] OccupationRatingFactor = new decimal[]
        {
            1.0M, 1.25M, 1.50M, 1.75M
        };

        public Task<decimal> CalculatePremiumAsync(PremiumQuoteModel premiumQuote)
        {
            var rating = premiumQuote.OccupationRating >= 1 && premiumQuote.OccupationRating <= 4 ?
                OccupationRatingFactor[premiumQuote.OccupationRating - 1] : 0;
            var premium = (premiumQuote.Amount * rating * premiumQuote.Age) / 1000 * 12;
            return Task.FromResult<decimal>(premium);
        }

        public Task<IEnumerable<OccupationRatingModel>> GetOccupationRatingsAsync()
        {
            var result = new List<OccupationRatingModel>()
            {
                new OccupationRatingModel{ Occupation = "Cleaner", Rating = 3},
                new OccupationRatingModel{ Occupation = "Doctor", Rating = 1},
                new OccupationRatingModel{ Occupation = "Author", Rating = 2},
                new OccupationRatingModel{ Occupation = "Farmer", Rating = 4},
                new OccupationRatingModel{ Occupation = "Mechanic", Rating = 4},
                new OccupationRatingModel{ Occupation = "Florist", Rating = 3},
            };

            return Task.FromResult<IEnumerable<OccupationRatingModel>>(result);
        }
    }
}
