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
using LiveChartsCore.Defaults;

namespace CryptocurrencyRates.ViewModels
{
    public partial class CryptocurrencyPageViewModel : ObservableObject
    {

        ISharedDataInterface sharedDataInterface;
        public Cryptocurrency crypto { get; set; }
        public ISeries[] series { get; set; }

        //public ObservableCollection<Decimal> priceUSDList;
        //public ObservableCollection<DateTime> timeList;
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
        public void CoinHistoryValues()
        {
            string StartDateTime = "1333500000000";
            string EndDateTime = "1800000000000";
            CoinHistory coinHistory = new CoinHistory(crypto.coinId, "d1", StartDateTime, EndDateTime);
            //priceUSDList = coinHistory.priceUSDList;
            //timeList = coinHistory.timeList;
            series = new ISeries[]
                {
                new ColumnSeries<DateTimePoint>
                {
                    TooltipLabelFormatter = (chartPoint) =>
                    $"{new DateTime((long) chartPoint.SecondaryValue):MMMM dd}: {chartPoint.PrimaryValue}",
                    Values = coinHistory.dateTimePoint
                    }
                };
        }
    }
}
