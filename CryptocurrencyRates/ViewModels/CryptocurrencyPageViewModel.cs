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
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace CryptocurrencyRates.ViewModels
{
    public partial class CryptocurrencyPageViewModel : ObservableObject
    {

        ISharedDataInterface sharedDataInterface;
        public Cryptocurrency crypto { get; set; }
        public ISeries[] series { get; set; }
        public Axis[] XAxes { get; set; }

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
            long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            long lastYear = DateTimeOffset.UtcNow.AddYears(-1).ToUnixTimeMilliseconds();
            CoinHistoryValues(lastYear.ToString(), now.ToString(), "d1");
        }
        public void ChangeChart(string StartDateTime, string EndDateTime, string interval)
        {
            crypto = sharedDataInterface.GetSharedCrypto();
            CoinHistoryValues(StartDateTime, EndDateTime, interval);
        }
        public void CoinHistoryValues(string StartDateTime,string EndDateTime, string interval )
        {
            //string StartDateTime = "1333500000000";
            //string EndDateTime = "1800000000000";
            ////string StartDateTime = " 	31556926";
            //string EndDateTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            CoinHistory coinHistory = new CoinHistory(crypto.coinId, interval, StartDateTime, EndDateTime);
            //priceUSDList = coinHistory.priceUSDList;
            //timeList = coinHistory.timeList;
            series = new ISeries[]
                {
                new LineSeries<DateTimePoint>
                {
                    TooltipLabelFormatter = (chartPoint) =>
                    $"{chartPoint.PrimaryValue}$  {new DateTime((long) chartPoint.SecondaryValue):dd MMMM yyyy hh:mm}",
                    Values = coinHistory.dateTimePoint,
                    Stroke = new SolidColorPaint(SKColors.DarkOrange) { StrokeThickness = 1 },
                    Fill = new SolidColorPaint(SKColors.Orange.WithAlpha(40)),
                    GeometryFill = null,
                    GeometryStroke = null
                    

                    }
                };
            XAxes = new Axis[]
            {
                new Axis
                {
                    Labeler = value => new DateTime((long) value).ToString("dd.mm.yyyy hh:mm"),
                    LabelsRotation = 60,
                    TextSize = 14,
                    UnitWidth = TimeSpan.FromDays(1).Ticks
                }
            };
        }
    }
}
