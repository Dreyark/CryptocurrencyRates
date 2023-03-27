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
        CryptocurrencyPageVM.RefreshCommand.ExecuteAsync(this);
        if (CryptocurrencyPageVM.crypto.Name != CoinLabel.Text)
        {
            CoinLabel.Text = CryptocurrencyPageVM.crypto.Name;
            CoinChart.Series = CryptocurrencyPageVM.series;
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        isFavourite.IsChecked = CryptocurrencyPageVM.crypto.IsFavourite;

    }
    private void isFavourite_CheckedChanged(Object sender, EventArgs e)
    {

        CryptocurrencyPageVM.crypto.IsFavourite = isFavourite.IsChecked;
    }
}