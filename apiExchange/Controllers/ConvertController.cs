
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiExchange.Models;

namespace apiExchange.Controllers
{
    [ApiController]
    public class ConvertController : ControllerBase
    {
        private readonly ExchangeContext _context;

        public ConvertController(ExchangeContext context)
        {
            _context = context;
        }

        [Route("api/Conversion")]
        [HttpPost]
        public async Task<ActionResult<Models.ConvertResponse>> PostConversion(Models.ConvertRequest exchange)
        {
            var exchangeRate = await _context.Exchanges.ToListAsync();

            exchangeRate = exchangeRate.Where(x => x.CurrencyOrigin.Equals(exchange.CurrencyOrigin) && x.CurrencyDestination.Equals(exchange.CurrencyDestination)).ToList();

            if (exchangeRate == null || exchangeRate.Count < 1)
            {
                return NotFound();
            }

            var responseExchangeRate = new Models.ConvertResponse();
            responseExchangeRate.ConvertedAmount = exchange.Amount * exchangeRate[0].ConversionValue;

            return responseExchangeRate;
        }
    }
}