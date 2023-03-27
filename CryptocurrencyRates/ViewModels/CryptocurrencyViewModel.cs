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
        //CoinUpdater coinUpdater = new CoinUpdater();
        ICryptocurrencyService cryptocurrencyService;
        ISharedDataInterface sharedDataInterface;

        public CryptocurrencyViewModel(ICryptocurrencyService cryptocurrencyService, ISharedDataInterface sharedDataInterface)
        {
            this.cryptocurrencyService = cryptocurrencyService;
            this.sharedDataInterface = sharedDataInterface;
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

        public Cryptocurrency selectedItem { get; set; }
        [RelayCommand]
        async Task CryptoSelected()
        {
            sharedDataInterface.SetSharedCrypto(selectedItem);
            await Shell.Current.GoToAsync($"{nameof(CryptocurrencyPage)}");
        }
    }
}
