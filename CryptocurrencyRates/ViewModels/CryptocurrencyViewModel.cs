using CryptocurrencyRates.Models;
using CryptocurrencyRates.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptocurrencyRates.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Collections;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;

namespace CryptocurrencyRates.ViewModels
{
    public partial class CryptocurrencyViewModel : ObservableObject
    {
        public ObservableCollection<Cryptocurrency> Cryptocurrencies { get; set; } = new ObservableCollection<Cryptocurrency>();
        CoinListUpdater coinListUpdater = new CoinListUpdater();
        ICryptocurrencyService cryptocurrencyService;

        public CryptocurrencyViewModel(ICryptocurrencyService cryptocurrencyService)
        {
            this.cryptocurrencyService = cryptocurrencyService;
        }

        [RelayCommand]
        async Task Refresh()
        {
            var cryptocurrency = cryptocurrencyService.GetCrypto();
            if (cryptocurrency.Count() != Cryptocurrencies.Count())
            {
                Cryptocurrencies.Clear();
                foreach (Cryptocurrency crypto in cryptocurrency)
                {
                    Cryptocurrencies.Add(crypto);
                }
            }
        }

        [RelayCommand]
        async Task Add()
        {
            await Shell.Current.GoToAsync($"{nameof(AddOwnedCryptocurrencyPage)}");
        }

        async Task Remove(Cryptocurrency cryptocurrency)
        {
            await cryptocurrencyService.RemoveCrypto(cryptocurrency.Id);
            await Refresh();
        }

        public Cryptocurrency selectedItem { get; set; }
        [RelayCommand]
        async Task CryptoSelected()
        {
            await Shell.Current.GoToAsync($"{nameof(CryptocurrencyPage)}");
            //await AppShell.Current.DisplayAlert("Error", selectedItem.Alias, "OK");
        }

        public ISeries[] Series { get; set; }
            = new ISeries[]
            {
                new LineSeries<int>
                {
                    Values = CoinListUpdater.GetCoinHistory("Bitcoin", "d1")
                },
                new ColumnSeries<double>
                {
                    Values = new double[] { 2, 5, 4, -2, 4, -3, 5 }
                }
            };

    }
}
