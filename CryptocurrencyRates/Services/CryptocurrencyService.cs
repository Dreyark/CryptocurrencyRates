using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using CryptocurrencyRates.Models;
using System.ComponentModel;

namespace CryptocurrencyRates.Services
{
    public class CryptocurrencyService : ICryptocurrencyService
    {


        SQLiteAsyncConnection db;
        async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Cryptocurrency>();
        }

        public async Task<IEnumerable<Cryptocurrency>> GetCrypto()
        {
            await Init();
            var CryptoCurrencies = await db.Table<Cryptocurrency>().ToListAsync();
            return CryptoCurrencies;
        }

        public async Task<Cryptocurrency> GetCrypto(int id)
        {
            await Init();

            var cryptocurrency = await db.Table<Cryptocurrency>()
                .FirstOrDefaultAsync(c => c.Id == id);

            return cryptocurrency;
        }

        public async Task AddCrypto(Cryptocurrency cryptocurrency)
        {
            await Init();

            var crypto = new Cryptocurrency
            {
                Name = "nazwa",
                Description = "opis"
            };

            var id = await db.InsertAsync(crypto);
        }

        public async Task RemoveCrypto(int id)
        {
            await Init();
            await db.DeleteAsync<Cryptocurrency>(id);
        }
    }
}
