using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using apiExchange.Models;


namespace apiExchange
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ExchangeContext>(o => o.UseInMemoryDatabase("DataList"));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }

        private void AddData(ExchangeContext context)
        {

            context.Exchanges.Add(new Models.Exchange
            {
                ID = 1,
                CurrencyOrigin = "USD",
                CurrencyDestination = "PEN",
                ConversionValue = 3.4M
            });

            context.Exchanges.Add(new Models.Exchange
            {
                ID = 2,
                CurrencyOrigin = "PEN",
                CurrencyDestination = "USD",
                ConversionValue = 0.29M
            });

            context.Exchanges.Add(new Models.Exchange
            {
                ID = 3,
                CurrencyOrigin = "PEN",
                CurrencyDestination = "EUR",
                ConversionValue = 0.27M
            });

            context.Exchanges.Add(new Models.Exchange
            {
                ID = 4,
                CurrencyOrigin = "EUR",
                CurrencyDestination = "PEN",
                ConversionValue = 3.71M
            });

            context.Exchanges.Add(new Models.Exchange
            {
                ID = 5,
                CurrencyOrigin = "JPY",
                CurrencyDestination = "PEN",
                ConversionValue = 0.031M
            });

            context.Exchanges.Add(new Models.Exchange
            {
                ID = 6,
                CurrencyOrigin = "PEN",
                CurrencyDestination = "JPY",
                ConversionValue = 32.4M
            });


            context.SaveChanges();
        }
    }
}
