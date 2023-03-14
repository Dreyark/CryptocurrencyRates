using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyRates.Models
{
    public class OwnedCryptocurrency
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int CoinId { get; set; }
        public double Amount { get; set; }

    }
}
