using CryptocurrencyRates.Models;
using CryptocurrencyRates.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Command = MvvmHelpers.Commands.Command;
using CryptocurrencyRates.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyRates.ViewModels
{
    public class CryptocurrencyViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Cryptocurrency> Cryptocurrency { get; set; }   
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Cryptocurrency> RemoveCommand { get; }

        ICryptocurrencyService cryptocurrencyService;

        public CryptocurrencyViewModel()
        {
            Title = "Cryptocurrency";
            Cryptocurrency = new ObservableRangeCollection<Cryptocurrency>();

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Cryptocurrency>(Remove);

            cryptocurrencyService = DependencyService.Get<ICryptocurrencyService>();
        }

        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(500);
            Cryptocurrency.Clear();
            var cryptocurrency = await cryptocurrencyService.GetCrypto();
            Cryptocurrency.AddRange(cryptocurrency);
            IsBusy = false;
        }

        async Task Add()
        {
            //Cryptocurrency crypto = new Cryptocurrency();
            //var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Name");
            //await cryptocurrencyService.AddCrypto(crypto);
            //await Refresh();

            //var route = $"{nameof(AddCryptocurrencyPage)}?Name=Motz";
            //await Shell.Current.GoToAsync(AddCryptocurrencyPage);
            // var page =
            // await Navigation.PushAsync(new AddCryptocurrencyPage(), true);
            await Shell.Current.GoToAsync($"{nameof(AddCryptocurrencyPage)}");
        }

        async Task Remove(Cryptocurrency cryptocurrency)
        {
            await cryptocurrencyService.RemoveCrypto(cryptocurrency.Id);
            await Refresh();
        }
    }
}
