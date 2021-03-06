﻿using System;
using System.Threading.Tasks;
using AngularAndNetCoreAPI.Models;
using AngularAndNetCoreAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TalTestChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PremiumController : ControllerBase
    {
        private readonly IPremiumCalculationService _premiumCalculationService;

        private readonly ILogger<PremiumController> _logger;

        public PremiumController(ILogger<PremiumController> logger,
            IPremiumCalculationService premiumCalculationService)
        {
            _logger = logger;
            _premiumCalculationService = premiumCalculationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _premiumCalculationService.GetOccupationRatingsAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetBaseException().Message, ex);
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        [HttpGet]
        [Route("quote")]
        public async Task<IActionResult> Get([FromQuery] PremiumQuoteModel premiumQuote)
        {
            var premium = await _premiumCalculationService.CalculatePremiumAsync(premiumQuote);
            return Ok(premium);
        }
    }
}
