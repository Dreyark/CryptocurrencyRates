using CryptocurrencyRates.Models;
using CryptocurrencyRates.ViewModels;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace CryptocurrencyRates.Views;

public partial class CryptocurrencyPage : ContentPage
{
    CryptocurrencyPageViewModel CryptocurrencyPageVM;
    public CryptocurrencyPage(CryptocurrencyPageViewModel vm)

    {
        InitializeComponent();
        BindingContext = vm;
        CryptocurrencyPageVM = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CryptocurrencyPageVM.RefreshCommand.ExecuteAsync(this);
        CoinLabel.Text = CryptocurrencyPageVM.crypto.Name;
        CoinChart.Series = CryptocurrencyPageVM.series;
    }
}