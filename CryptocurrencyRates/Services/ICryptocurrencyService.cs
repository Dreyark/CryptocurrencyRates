using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using CryptocurrencyRates.Models;

namespace CryptocurrencyRates.Services
{
    public interface ICryptocurrencyService
    {
        List<Cryptocurrency> GetCrypto();
        Task<Cryptocurrency> GetCrypto(int id);
        Task AddCrypto(Cryptocurrency cryptocurrency);
        Task RemoveCrypto(int id);
        Task RemoveAllCryptocurrency();
    }
}
