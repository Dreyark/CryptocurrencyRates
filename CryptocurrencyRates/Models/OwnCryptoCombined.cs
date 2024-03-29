﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyRates.Models
{
    public class OwnCryptoCombined
    {
        public int Id { get; set; }
        public int CoinId { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
        public string imgSRC { get; set; }
        public string changePercent24Hr { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string CurrentRateUsd { get; set; }
        public string Summary { get; set; }
        public string StartPrice { get; set; }
    }
}
