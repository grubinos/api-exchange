using System;

namespace apiExchange.Models
{
    public class Exchange
    {
        public long ID { get; set; }
        public string CurrencyOrigin { get; set; }
        public string CurrencyDestination { get; set; }
        public decimal ConversionValue { get; set; }
    }
}
