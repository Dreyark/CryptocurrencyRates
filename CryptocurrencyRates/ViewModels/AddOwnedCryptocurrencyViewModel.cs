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
        int id, coinId;
        double amount;
        public int Id { get => id; set => SetProperty(ref id, value); }
        public double Amount { get => amount; set => SetProperty(ref amount, value); }
        public int CoinId { get => coinId; set => SetProperty(ref coinId, value); }

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
            ownCrypto.Id = id;
            ownCrypto.Amount = amount;
            ownCrypto.CoinId = coinId;
            await ownedCryptocurrencyService.AddOwnCrypto(ownCrypto);

            await Shell.Current.GoToAsync("..");
        }
    }
}
