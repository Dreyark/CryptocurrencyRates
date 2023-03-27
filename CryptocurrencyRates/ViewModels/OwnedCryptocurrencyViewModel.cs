﻿using CryptocurrencyRates.Models;
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
        public List<Cryptocurrency> Cryptocurrencies { get; set; } = new List<Cryptocurrency>();
        IOwnedCryptocurrencyService ownedCryptocurrencyService;
        ICryptocurrencyService cryptocurrencyService;

        public IEnumerable<dynamic> combinedCrypto {get;set;}

        public OwnedCryptocurrencyViewModel(IOwnedCryptocurrencyService ownedCryptocurrencyService, ICryptocurrencyService cryptocurrencyService)
        {
            this.ownedCryptocurrencyService = ownedCryptocurrencyService;
            this.cryptocurrencyService = cryptocurrencyService;
        }

        [RelayCommand]
        async Task Refresh()
        {
            var ownedCryptocurrency = ownedCryptocurrencyService.GetOwnCrypto();
            if (ownedCryptocurrency.Count() != OwnedCryptocurrencies.Count())
            {
                OwnedCryptocurrencies.Clear();
                foreach (OwnedCryptocurrency ownCrypto in ownedCryptocurrency)
                {
                    OwnedCryptocurrencies.Add(ownCrypto);
                }
            }
            var Crypto = cryptocurrencyService.GetCrypto();
            var combined = from o in ownedCryptocurrency
                           join c in Crypto on o.CoinId equals c.Id
                           select new { o.CoinId, o.Amount, c.Name, c.changePercent24Hr, c.Alias, c.CurrentRateUsd };
            combinedCrypto =  combined;
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
