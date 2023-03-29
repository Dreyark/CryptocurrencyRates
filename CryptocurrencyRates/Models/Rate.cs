using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyRates.Models
{
    public class Rate
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string sId { get; set; }
        public string symbol { get; set; }
        public string currencySymbol { get; set; }
        public string type { get; set; }
        public string rateUsd { get; set; }
    }
}
