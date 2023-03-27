using CryptocurrencyRates.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyRates.Services
{
    public class RateService : IRateService
    {
        SQLiteConnection db;
        async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteConnection(databasePath);

            db.CreateTable<Rate>();
        }

        public List<Rate> GetRate()
        {
            Init();
            var rates = db.Table<Rate>().ToList();
            return rates;
        }

        public async Task<Rate> GetRate(int id)
        {
            await Init();

            var rate = db.Table<Rate>()
                .FirstOrDefault(c => c.Id == id);

            return rate;
        }

        public async Task AddRate(Rate rate)
        {
            await Init();
            var id = db.Insert(rate);
        }

        public async Task RemoveRate(int id)
        {
            await Init();
            db.Delete(id);
        }

        public async Task RemoveAllRate()
        {
            await Init();
            db.DropTable<Rate>();
            db.CreateTable<Rate>();
        }
    }
}
