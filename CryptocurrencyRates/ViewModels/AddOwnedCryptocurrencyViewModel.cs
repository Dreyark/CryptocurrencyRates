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
    [QueryProperty(nameof(CombinedCrypto), "CombinedCrypto")]
    public partial class AddOwnedCryptocurrencyViewModel : ObservableObject
    {
        [ObservableProperty]
        OwnCryptoCombined _CombinedCrypto;

        //int coinIndex;
        //string description;
        //double amount;
        //int id;
        //public string Description { get => description; set => SetProperty(ref description, value); }
        //public double Amount { get => amount; set => SetProperty(ref amount, value); }
        //public int CoinIndex { get => coinIndex; set => SetProperty(ref coinIndex, value); }

        IOwnedCryptocurrencyService ownedCryptocurrencyService;
        ICryptocurrencyService cryptocurrencyService;
        ISharedDataInterface sharedDataInterface;
        public List<Cryptocurrency> Cryptocurrencies { get; set; } = new List<Cryptocurrency>();
        public AddOwnedCryptocurrencyViewModel(IOwnedCryptocurrencyService ownedCryptocurrencyService, ICryptocurrencyService cryptocurrencyService, ISharedDataInterface sharedDataInterface)
        {
            this.sharedDataInterface = sharedDataInterface;
            this.ownedCryptocurrencyService = ownedCryptocurrencyService;
            this.cryptocurrencyService = cryptocurrencyService;
            Cryptocurrencies = cryptocurrencyService.GetCrypto();
        }

        [RelayCommand]
        async Task Save()
        {
            OwnedCryptocurrency ownCrypto = new OwnedCryptocurrency();
            ownCrypto.Description = _CombinedCrypto.Description;
            ownCrypto.Amount = _CombinedCrypto.Amount;
            if(_CombinedCrypto.StartPrice == null )
            {
                ownCrypto.StartPrice = _CombinedCrypto.CurrentRateUsd;
            }
            else
            {
                ownCrypto.StartPrice = _CombinedCrypto.StartPrice;
            }
            ownCrypto.CoinId = _CombinedCrypto.CoinId+1;
            if(_CombinedCrypto.Id > 0) {
                ownCrypto.Id = _CombinedCrypto.Id;
                //sharedDataInterface.SetSharedOwnedCrypto(null);
                await ownedCryptocurrencyService.UpdateOwnCrypto(ownCrypto);
            }
            else
            {
                await ownedCryptocurrencyService.AddOwnCrypto(ownCrypto);
            }
            await Shell.Current.GoToAsync("..");
        }
    }
}
