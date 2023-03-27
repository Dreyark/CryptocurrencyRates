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
        Cryptocurrency FavouritecryptocurrencyShare;
        public void SetSharedCrypto(Cryptocurrency crypto)
        {
            //if (page == 1)
            //{
                cryptocurrencyShare = crypto;
            //}
            //else
            //{
            //    FavouritecryptocurrencyShare = crypto;
            //}
        }

        public Cryptocurrency GetSharedCrypto()
        {
            //if (page == 1)
            //{
                return cryptocurrencyShare;
            //}
            //else
            //{
            //    return FavouritecryptocurrencyShare;
            //}
        }
    }
}
