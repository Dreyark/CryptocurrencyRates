using CryptocurrencyRates.Models;
using CryptocurrencyRates.ViewModels;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Globalization;

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
        CoinChart.YAxes = CryptocurrencyPageVM.YAxes;
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
        CurrentRate.Text = "Current Rate: "+Convert.ToDecimal(CryptocurrencyPageVM.crypto.CurrentRateUsd, CultureInfo.InvariantCulture).ToString("G29");
        supply.Text = "Supply: "+Convert.ToDecimal(CryptocurrencyPageVM.crypto.supply, CultureInfo.InvariantCulture).ToString("G29");
        maxSupply.Text = " Max Supply: " + Convert.ToDecimal(CryptocurrencyPageVM.crypto.maxSupply, CultureInfo.InvariantCulture).ToString("G29");
        marketCapUsd.Text = "Market Cap: " + Convert.ToDecimal(CryptocurrencyPageVM.crypto.marketCapUsd, CultureInfo.InvariantCulture).ToString("G29");
        changePercent.Text = "Change: " + CryptocurrencyPageVM.crypto.changePercent24Hr;

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
        this.d1.BackgroundColor = Color.FromHex("ff9000");
        this.d7.BackgroundColor = Color.FromHex("abff6e00");
        this.m1.BackgroundColor = Color.FromHex("abff6e00");
        this.m3.BackgroundColor = Color.FromHex("abff6e00");
        this.y1.BackgroundColor = Color.FromHex("abff6e00");
        this.y10.BackgroundColor = Color.FromHex("abff6e00");
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        long d7 = DateTimeOffset.UtcNow.AddDays(-7).ToUnixTimeMilliseconds();
        CryptocurrencyPageVM.ChangeChart(d7.ToString(), now.ToString(), "m30");
        CoinChart.Series = CryptocurrencyPageVM.series;
        CoinChart.XAxes = CryptocurrencyPageVM.XAxes;
        this.d1.BackgroundColor = Color.FromHex("abff6e00");
        this.d7.BackgroundColor = Color.FromHex("ff9000");
        this.m1.BackgroundColor = Color.FromHex("abff6e00");
        this.m3.BackgroundColor = Color.FromHex("abff6e00");
        this.y1.BackgroundColor = Color.FromHex("abff6e00");
        this.y10.BackgroundColor = Color.FromHex("abff6e00");
    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        long m1 = DateTimeOffset.UtcNow.AddMonths(-1).ToUnixTimeMilliseconds();
        CryptocurrencyPageVM.ChangeChart(m1.ToString(), now.ToString(), "h2");
        CoinChart.Series = CryptocurrencyPageVM.series;
        CoinChart.XAxes = CryptocurrencyPageVM.XAxes;
        this.d1.BackgroundColor = Color.FromHex("abff6e00");
        this.d7.BackgroundColor = Color.FromHex("abff6e00");
        this.m1.BackgroundColor = Color.FromHex("ff9000");
        this.m3.BackgroundColor = Color.FromHex("abff6e00");
        this.y1.BackgroundColor = Color.FromHex("abff6e00");
        this.y10.BackgroundColor = Color.FromHex("abff6e00");
    }

    private void Button_Clicked_4(object sender, EventArgs e)
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        long m3 = DateTimeOffset.UtcNow.AddMonths(-3).ToUnixTimeMilliseconds();
        CryptocurrencyPageVM.ChangeChart(m3.ToString(), now.ToString(), "h6");
        CoinChart.Series = CryptocurrencyPageVM.series;
        CoinChart.XAxes = CryptocurrencyPageVM.XAxes;
        this.d1.BackgroundColor = Color.FromHex("abff6e00");
        this.d7.BackgroundColor = Color.FromHex("abff6e00");
        this.m1.BackgroundColor = Color.FromHex("abff6e00");
        this.m3.BackgroundColor = Color.FromHex("ff9000");
        this.y1.BackgroundColor = Color.FromHex("abff6e00");
        this.y10.BackgroundColor = Color.FromHex("abff6e00");
    }

    private void Button_Clicked_5(object sender, EventArgs e)
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        long y1 = DateTimeOffset.UtcNow.AddYears(-1).ToUnixTimeMilliseconds();
        CryptocurrencyPageVM.ChangeChart(y1.ToString(), now.ToString(), "d1");
        CoinChart.Series = CryptocurrencyPageVM.series;
        CoinChart.XAxes = CryptocurrencyPageVM.XAxes;
        this.d1.BackgroundColor = Color.FromHex("abff6e00");
        this.d7.BackgroundColor = Color.FromHex("abff6e00");
        this.m1.BackgroundColor = Color.FromHex("abff6e00");
        this.m3.BackgroundColor = Color.FromHex("abff6e00");
        this.y1.BackgroundColor = Color.FromHex("ff9000");
        this.y10.BackgroundColor = Color.FromHex("abff6e00");
    }

    private void Button_Clicked_6(object sender, EventArgs e)
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        long y10 = DateTimeOffset.UtcNow.AddYears(-10).ToUnixTimeMilliseconds();
        CryptocurrencyPageVM.ChangeChart(y10.ToString(), now.ToString(), "d1");
        CoinChart.Series = CryptocurrencyPageVM.series;
        CoinChart.XAxes = CryptocurrencyPageVM.XAxes;
        this.d1.BackgroundColor = Color.FromHex("abff6e00");
        this.d7.BackgroundColor = Color.FromHex("abff6e00");
        this.m1.BackgroundColor = Color.FromHex("abff6e00");
        this.m3.BackgroundColor = Color.FromHex("abff6e00");
        this.y1.BackgroundColor = Color.FromHex("abff6e00");
        this.y10.BackgroundColor = Color.FromHex("ff9000");
    }
}