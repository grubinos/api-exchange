using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiExchange.Models;

namespace apiExchange
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly ExchangeContext _context;

        public ExchangeController(ExchangeContext context)
        {
            _context = context;
        }

        // GET: api/Exchange
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exchange>>> GetExchanges()
        {
            return await _context.Exchanges.ToListAsync();
        }

        // GET: api/Exchange/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exchange>> GetExchange(long id)
        {
            var exchange = await _context.Exchanges.FindAsync(id);

            if (exchange == null)
            {
                return NotFound();
            }

            return exchange;
        }

        // PUT: api/Exchange/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExchange(long id, Exchange exchange)
        {
            if (id != exchange.ID)
            {
                return BadRequest();
            }

            _context.Entry(exchange).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExchangeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Exchange
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Exchange>> PostExchange(Exchange exchange)
        {
            _context.Exchanges.Add(exchange);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExchange", new { id = exchange.ID }, exchange);
        }

        // DELETE: api/Exchange/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Exchange>> DeleteExchange(long id)
        {
            var exchange = await _context.Exchanges.FindAsync(id);
            if (exchange == null)
            {
                return NotFound();
            }

            _context.Exchanges.Remove(exchange);
            await _context.SaveChangesAsync();

            return exchange;
        }

        private bool ExchangeExists(long id)
        {
            return _context.Exchanges.Any(e => e.ID == id);
        }

    }
}
