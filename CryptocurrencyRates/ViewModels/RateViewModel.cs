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
    public partial class RateViewModel : ObservableObject
    {
        public ObservableCollection<Rate> Rates { get; set; } = new ObservableCollection<Rate>();
        //RateUpdater rateUpdater = new RateUpdater();
        IRateService rateService;
        public RateViewModel(IRateService rateService)
        {   
            this.rateService = rateService;
        }

        [RelayCommand]
        async Task Refresh()
        {
            var rate = rateService.GetRate();
            if (Rates.Count() != rate.Count())
            {
                Rates.Clear();
                foreach (Rate cash in rate)
                {
                    Rates.Add(cash);
                }
            }
        }

    }
}
