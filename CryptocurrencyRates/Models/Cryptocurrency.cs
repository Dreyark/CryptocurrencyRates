using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyRates.Models
{
    public class Cryptocurrency
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string imgSRC { get; set; }
        public string CurrentRateUsd { get; set; }
        public string supply { get; set; }
        public string maxSupply { get; set; }
        public string marketCapUsd { get; set; }
        public string changePercent24Hr { get; set; }
        public bool IsFavourite { get; set; }

    }
}
