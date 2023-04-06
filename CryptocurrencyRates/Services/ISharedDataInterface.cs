using CryptocurrencyRates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyRates.Services
{
    public interface ISharedDataInterface
    {
        void SetSharedCrypto(Cryptocurrency crypto);
        Cryptocurrency GetSharedCrypto();

        void SetSharedOwnedCrypto(OwnCryptoCombined crypto);
        OwnCryptoCombined GetSharedOwnedCrypto();
    }
}
