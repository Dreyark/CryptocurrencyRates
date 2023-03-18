using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptocurrencyRates.Models;
using CryptocurrencyRates.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyRates.ViewModels
{
    public partial class AddOwnedCryptocurrencyViewModel : ObservableObject
    {
        int coinIndex;
        string description;
        double amount;
        public string Description { get => description; set => SetProperty(ref description, value); }
        public double Amount { get => amount; set => SetProperty(ref amount, value); }
        public int CoinIndex { get => coinIndex; set => SetProperty(ref coinIndex, value); }

        IOwnedCryptocurrencyService ownedCryptocurrencyService;
        ICryptocurrencyService cryptocurrencyService;
        public List<Cryptocurrency> Cryptocurrencies { get; set; } = new List<Cryptocurrency>();
        public AddOwnedCryptocurrencyViewModel(IOwnedCryptocurrencyService ownedCryptocurrencyService, ICryptocurrencyService cryptocurrencyService)
        {
            this.ownedCryptocurrencyService = ownedCryptocurrencyService;
            this.cryptocurrencyService = cryptocurrencyService;
            Cryptocurrencies = cryptocurrencyService.GetCrypto();
        }

        [RelayCommand]
        async Task Save()
        {
            OwnedCryptocurrency ownCrypto = new OwnedCryptocurrency();
            ownCrypto.Description = description;
            ownCrypto.Amount = amount;
            ownCrypto.CoinId = coinIndex+1;
            await ownedCryptocurrencyService.AddOwnCrypto(ownCrypto);

            await Shell.Current.GoToAsync("..");
        }
    }
}
