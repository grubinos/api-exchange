using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiExchange.Models
{
    public class ConvertRequest
    { 
        public decimal Amount { get; set; }
        public string CurrencyOrigin { get; set; }
        public string CurrencyDestination { get; set; }
    }
}
