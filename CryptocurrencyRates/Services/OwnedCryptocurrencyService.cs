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
    public class OwnedCryptocurrencyService : IOwnedCryptocurrencyService
    {


        SQLiteConnection db;
        async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteConnection(databasePath);

            db.CreateTable<OwnedCryptocurrency>();
        }

        public List<OwnedCryptocurrency> GetOwnCrypto()
        {
            Init();
            var CryptoCurrencies = db.Table<OwnedCryptocurrency>().ToList();
            return CryptoCurrencies;
        }

        public async Task<OwnedCryptocurrency> GetOwnCrypto(int id)
        {
            await Init();

            var cryptocurrency = db.Table<OwnedCryptocurrency>()
                .FirstOrDefault(c => c.Id == id);

            return cryptocurrency;
        }

        public async Task AddOwnCrypto(OwnedCryptocurrency cryptocurrency)
        {
            await Init();

            var id = db.Insert(cryptocurrency);
        }

        public async Task RemoveOwnCrypto(int id)
        {
            await Init();
            db.Delete<OwnedCryptocurrency>(id);
        }
        public async Task RemoveAllOwnCryptocurrency()
        {
            await Init();
            db.DropTable<OwnedCryptocurrency>();
            db.CreateTable<OwnedCryptocurrency>();
        }

    }
}
