using CryptocurrencyRates.Models;
using CryptocurrencyRates.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyRates.ViewModels
{
    public class AddCryptocurrencyViewModel : ViewModelBase
    {
        string name;
        public string Name { get => name; set => SetProperty(ref name, value); }

        public AsyncCommand SaveCommand { get; }
        ICryptocurrencyService cryptocurrencyService;
        public AddCryptocurrencyViewModel()
        {
            Title = "Add Coffee";
            SaveCommand = new AsyncCommand(Save);
            cryptocurrencyService = DependencyService.Get<ICryptocurrencyService>();
        }

        async Task Save()
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }
            Cryptocurrency crypto = new Cryptocurrency();
            await cryptocurrencyService.AddCrypto(crypto);

            await Shell.Current.GoToAsync("..");
        }
    }
}
