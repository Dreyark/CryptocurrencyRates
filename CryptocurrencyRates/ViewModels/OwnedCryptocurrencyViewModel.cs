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
        IOwnedCryptocurrencyService ownedCryptocurrencyService;

        public OwnedCryptocurrencyViewModel(IOwnedCryptocurrencyService ownedCryptocurrencyService)
        {
            this.ownedCryptocurrencyService = ownedCryptocurrencyService;
        }

        [RelayCommand]
        async Task Refresh()
        {
            var a = 2 + 2;
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
