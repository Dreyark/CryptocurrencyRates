using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptocurrencyRates.Models;
using CryptocurrencyRates.Services;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyRates.ViewModels
{
    public partial class CryptocurrencyPageViewModel : ObservableObject
    {

        ISharedDataInterface sharedDataInterface;
        public Cryptocurrency crypto { get; set; }
        public ISeries[] series { get; set; }
        public CryptocurrencyPageViewModel(ISharedDataInterface sharedDataInterface)
        {
            this.sharedDataInterface = sharedDataInterface;
        }

        [RelayCommand]
        async Task Refresh()
        {
            crypto = sharedDataInterface.GetSharedCrypto();
            CoinHistoryValues();
        }

        public static ObservableCollection<Decimal> priceUSDList;
        public static ObservableCollection<DateTime> timeList;

        public void CoinHistoryValues()
        {
            CoinHistory coinHistory = new CoinHistory(crypto.coinId, "d1");
            priceUSDList = coinHistory.priceUSDList;
            timeList = coinHistory.timeList;
            series = new ISeries[]
            {
                new LineSeries<Decimal> {Values = priceUSDList }
            };
        }
    }
}
