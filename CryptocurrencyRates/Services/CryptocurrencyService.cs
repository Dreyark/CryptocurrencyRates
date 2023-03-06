using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using CryptocurrencyRates.Models;
using System.ComponentModel;
using CryptocurrencyRates.Services;

namespace CryptocurrencyRates.Services
{
    public class CryptocurrencyService : ICryptocurrencyService
    {


        SQLiteConnection db;
        async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteConnection(databasePath);
            
            db.CreateTable<Cryptocurrency>();
        }

        public List<Cryptocurrency> GetCrypto()
        {
            Init();
            var CryptoCurrencies = db.Table<Cryptocurrency>().ToList();
            return CryptoCurrencies;
        }

        public async Task<Cryptocurrency> GetCrypto(int id)
        {
            await Init();

            var cryptocurrency =  db.Table<Cryptocurrency>()
                .FirstOrDefault(c => c.Id == id);

            return cryptocurrency;
        }

        public async Task AddCrypto(Cryptocurrency cryptocurrency)
        {
            await Init();

            var id =  db.Insert(cryptocurrency);
        }

        public async Task RemoveCrypto(int id)
        {
            await Init();
            db.Delete<Cryptocurrency>(id);
        }
        public async Task RemoveAllCryptocurrency()
        {
            await Init();
            db.DropTable<Cryptocurrency>();
            db.CreateTable<Cryptocurrency>();
        }
    }
}
