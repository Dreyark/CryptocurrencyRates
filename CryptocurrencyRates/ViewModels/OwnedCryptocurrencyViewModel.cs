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
    public partial class OwnedCryptocurrencyViewModel : ObservableObject
    {
        public ObservableCollection<OwnedCryptocurrency> OwnedCryptocurrencies { get; set; } = new ObservableCollection<OwnedCryptocurrency>();
        public ObservableCollection<OwnCryptoCombined> Combined { get; set; } = new ObservableCollection<OwnCryptoCombined>();
        public List<Cryptocurrency> Cryptocurrencies { get; set; } = new List<Cryptocurrency>();
        IOwnedCryptocurrencyService ownedCryptocurrencyService;
        ICryptocurrencyService cryptocurrencyService;
        ISharedDataInterface sharedDataInterface;

        //public IEnumerable<dynamic> combinedCrypto {get;set;}

        public OwnedCryptocurrencyViewModel(IOwnedCryptocurrencyService ownedCryptocurrencyService, ICryptocurrencyService cryptocurrencyService, ISharedDataInterface sharedDataInterface)
        {
            this.ownedCryptocurrencyService = ownedCryptocurrencyService;
            this.cryptocurrencyService = cryptocurrencyService;
            this.sharedDataInterface = sharedDataInterface;
        }

        [RelayCommand]
        async Task Refresh()
        {
            var ownedCryptocurrency = ownedCryptocurrencyService.GetOwnCrypto();
            Combined.Clear();
            foreach (OwnedCryptocurrency ownCrypto in ownedCryptocurrency)
            {
                Cryptocurrency c = cryptocurrencyService.GetCrypto(ownCrypto.CoinId).Result;
                OwnCryptoCombined comb = new OwnCryptoCombined
                {
                    Id = ownCrypto.Id,
                    CoinId = ownCrypto.CoinId,
                    Amount = ownCrypto.Amount,
                    Description = ownCrypto.Description,
                    Alias = c.Alias,
                    changePercent24Hr = c.changePercent24Hr,
                    CurrentRateUsd = c.CurrentRateUsd,
                    Name = c.Name,
                    imgSRC = c.imgSRC,
                };
                Combined.Add(comb);

            }
            //var Crypto = cryptocurrencyService.GetCrypto();
            //var combined = from o in ownedCryptocurrency
            //               join c in Crypto on o.CoinId equals c.Id
            //               select new { o.CoinId, o.Amount, c.Name, c.changePercent24Hr, c.Alias, c.CurrentRateUsd };
            //combinedCrypto =  combined;


        }

        public OwnCryptoCombined selectedItem { get; set; }
        [RelayCommand]
        async Task OwnedCryptoSelected()
        {
            sharedDataInterface.SetSharedOwnedCrypto(selectedItem);
            await Shell.Current.GoToAsync($"{nameof(OwnedCryptocurrencyPage)}");
        }


        [RelayCommand]
        async Task Add()
        {
            await Shell.Current.GoToAsync($"{nameof(AddOwnedCryptocurrencyPage)}?",
                new Dictionary<string, object>
                {
                    ["CombinedCrypto"] = new OwnCryptoCombined()
                });
        }

        [RelayCommand]
        async Task Edit()
        {
            //var navParam = new Dictionary<string, object>();
            //navParam.Add("ownedCryptocurrency", selectedItem);
            //await Shell.Current.GoToAsync($"{nameof(AddOwnedCryptocurrencyPage)}", navParam);

            await Shell.Current.GoToAsync($"{nameof(AddOwnedCryptocurrencyPage)}?",
                new Dictionary<string, object>
                {
                    ["CombinedCrypto"] = selectedItem
                });

        }

        [RelayCommand]
        async Task Remove()
        {
            await Shell.Current.GoToAsync("..");
            await ownedCryptocurrencyService.RemoveOwnCrypto(selectedItem.Id);
            await Refresh();
        }
    }
}
