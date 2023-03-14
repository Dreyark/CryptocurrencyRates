using CryptocurrencyRates.Models;
using CryptocurrencyRates.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptocurrencyRates.Views;
using System.Collections.ObjectModel;

namespace CryptocurrencyRates.ViewModels
{
    public partial class OwnedCryptocurrencyViewModel
    {
        public ObservableCollection<OwnedCryptocurrency> OwnedCryptocurrencies { get; set; } = new ObservableCollection<OwnedCryptocurrency>();
        public List<Cryptocurrency> Cryptocurrencies { get; set; } = new List<Cryptocurrency>();
        IOwnedCryptocurrencyService ownedCryptocurrencyService;
        ICryptocurrencyService cryptocurrencyService;

        public IEnumerable<dynamic> combinedCrypto()
        {

            var Crypto = cryptocurrencyService.GetCrypto();
            var OwnCrypto = ownedCryptocurrencyService.GetOwnCrypto();
            var combined = from o in OwnCrypto
                           join c in Crypto on o.CoinId equals c.Id
                           select new { o.CoinId, o.Amount, c.Name, c.changePercent24Hr, c.Alias, c.CurrentRateUsd };
            return combined;
        }


        public OwnedCryptocurrencyViewModel(IOwnedCryptocurrencyService ownedCryptocurrencyService, ICryptocurrencyService cryptocurrencyService)
        {
            this.ownedCryptocurrencyService = ownedCryptocurrencyService;
            this.cryptocurrencyService = cryptocurrencyService;
            combinedCrypto();
        }

        [RelayCommand]
        async Task Refresh()
        {
            var ownedCryptocurrency = ownedCryptocurrencyService.GetOwnCrypto();
            if (ownedCryptocurrency.Count() != OwnedCryptocurrencies.Count())
            {
                OwnedCryptocurrencies.Clear();
                foreach (OwnedCryptocurrency ownCrypto in ownedCryptocurrency)
                {
                    OwnedCryptocurrencies.Add(ownCrypto);
                }
            }
            //var dynamics = from o in OwnedCryptocurrencies
            //               join c in Cryptocurrencies on o.CoinId equals c.Id
            //               select new { o.CoinId, o.Amount, c.Name, c.changePercent24Hr, c.Alias, c.CurrentRateUsd };
        }

        [RelayCommand]
        async Task Add()
        {
            await Shell.Current.GoToAsync($"{nameof(AddOwnedCryptocurrencyPage)}");
        }

        [RelayCommand]
        async Task Remove(OwnedCryptocurrency ownCryptocurrency)
        {
            await ownedCryptocurrencyService.RemoveOwnCrypto(ownCryptocurrency.Id);
            await Refresh();
        }
    }
}
