using CryptocurrencyRates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyRates.Services
{
    public class SharedDataInterface : ISharedDataInterface
    {
        Cryptocurrency cryptocurrencyShare;
        public void SetSharedCrypto(Cryptocurrency crypto)
        {
            cryptocurrencyShare = crypto;
        }

        public Cryptocurrency GetSharedCrypto()
        {
            return cryptocurrencyShare;
        }
    }
}
