using Microsoft.EntityFrameworkCore;

namespace apiExchange.Models
{
    public class ExchangeContext : DbContext
    {
        public ExchangeContext(DbContextOptions<ExchangeContext> options)
            : base(options)
        {
        }

        public DbSet<Exchange> Exchanges { get; set; }
    }
}