using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyRates.Models
{
    public class Cryptocurrency
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public string Alias { get; set; }
        public double CurrentRate {  get; set; }
    }
}
