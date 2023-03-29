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
        CoinChart.Series = CryptocurrencyPageVM.series;
        CoinChart.XAxes = CryptocurrencyPageVM.XAxes;
        Title = CryptocurrencyPageVM.crypto.Name;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (CryptocurrencyPageVM.crypto.IsFavourite)
        {
            AddTofavourite.IconImageSource = "yellowstar.png";
        }
        else
        {
            AddTofavourite.IconImageSource = "wstar.png";
        }

    }
    private void isFavourite_Click(Object sender, EventArgs e)
    {

        CryptocurrencyPageVM.crypto.IsFavourite = !CryptocurrencyPageVM.crypto.IsFavourite;
        if (CryptocurrencyPageVM.crypto.IsFavourite)
        {
            AddTofavourite.IconImageSource = "yellowstar.png";
        }
        else
        {
            AddTofavourite.IconImageSource = "wstar.png";
        }
    }
    private void Button_Clicked_1(object sender, EventArgs e)
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        long d1 = DateTimeOffset.UtcNow.AddDays(-1).ToUnixTimeMilliseconds();
        CryptocurrencyPageVM.ChangeChart(d1.ToString(), now.ToString(), "m1");
        CoinChart.Series = CryptocurrencyPageVM.series;
        CoinChart.XAxes = CryptocurrencyPageVM.XAxes;
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        long d7 = DateTimeOffset.UtcNow.AddDays(-7).ToUnixTimeMilliseconds();
        CryptocurrencyPageVM.ChangeChart(d7.ToString(), now.ToString(), "m30");
        CoinChart.Series = CryptocurrencyPageVM.series;
        CoinChart.XAxes = CryptocurrencyPageVM.XAxes;
    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        long m1 = DateTimeOffset.UtcNow.AddMonths(-1).ToUnixTimeMilliseconds();
        CryptocurrencyPageVM.ChangeChart(m1.ToString(), now.ToString(), "h1");
        CoinChart.Series = CryptocurrencyPageVM.series;
        CoinChart.XAxes = CryptocurrencyPageVM.XAxes;
    }

    private void Button_Clicked_4(object sender, EventArgs e)
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        long m3 = DateTimeOffset.UtcNow.AddMonths(-3).ToUnixTimeMilliseconds();
        CryptocurrencyPageVM.ChangeChart(m3.ToString(), now.ToString(), "h6");
        CoinChart.Series = CryptocurrencyPageVM.series;
        CoinChart.XAxes = CryptocurrencyPageVM.XAxes;
    }

    private void Button_Clicked_5(object sender, EventArgs e)
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        long y1 = DateTimeOffset.UtcNow.AddYears(-1).ToUnixTimeMilliseconds();
        CryptocurrencyPageVM.ChangeChart(y1.ToString(), now.ToString(), "d1");
        CoinChart.Series = CryptocurrencyPageVM.series;
        CoinChart.XAxes = CryptocurrencyPageVM.XAxes;
    }

    private void Button_Clicked_6(object sender, EventArgs e)
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        long y10 = DateTimeOffset.UtcNow.AddYears(-10).ToUnixTimeMilliseconds();
        CryptocurrencyPageVM.ChangeChart(y10.ToString(), now.ToString(), "d1");
        CoinChart.Series = CryptocurrencyPageVM.series;
        CoinChart.XAxes = CryptocurrencyPageVM.XAxes;
    }
}