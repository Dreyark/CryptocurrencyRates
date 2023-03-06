using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptocurrencyRates.Models;
using CryptocurrencyRates.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyRates.ViewModels
{
    public partial class AddOwnedCryptocurrencyViewModel : ObservableObject
    {
        string name, alias;
        double amount;
        public string Name { get => name; set => SetProperty(ref name, value); }
        public double Amount { get => amount; set => SetProperty(ref amount, value); }
        public string Alias { get => alias; set => SetProperty(ref alias, value); }

        ICryptocurrencyService cryptocurrencyService;
        public AddOwnedCryptocurrencyViewModel(ICryptocurrencyService cryptocurrencyService)
        {
            this.cryptocurrencyService = cryptocurrencyService;
        }

        [RelayCommand]
        async Task Save()
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }
            Cryptocurrency crypto = new Cryptocurrency();
            crypto.Name = name;
            //crypto.Amount = amount;
            crypto.Alias = alias;
            await cryptocurrencyService.AddCrypto(crypto);

            await Shell.Current.GoToAsync("..");
        }
    }
}
