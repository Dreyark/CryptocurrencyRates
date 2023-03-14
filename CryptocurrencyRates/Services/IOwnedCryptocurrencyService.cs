using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using CryptocurrencyRates.Models;

namespace CryptocurrencyRates.Services
{
    public interface IOwnedCryptocurrencyService
    {
        List<OwnedCryptocurrency> GetOwnCrypto();
        Task<OwnedCryptocurrency> GetOwnCrypto(int id);
        Task AddOwnCrypto(OwnedCryptocurrency ownedCryptocurrency);
        Task RemoveOwnCrypto(int id);
        Task RemoveAllOwnCryptocurrency();
    }
}
