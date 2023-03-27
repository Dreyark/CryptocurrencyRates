using CryptocurrencyRates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyRates.Services
{
    public interface IRateService
    {
        List<Rate> GetRate();
        Task<Rate> GetRate(int id);
        Task AddRate(Rate rate);
        Task RemoveRate(int id);
        Task RemoveAllRate();
    }
}
