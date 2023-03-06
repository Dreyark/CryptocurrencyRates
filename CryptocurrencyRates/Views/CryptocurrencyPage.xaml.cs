using CryptocurrencyRates.ViewModels;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace CryptocurrencyRates.Views;

public partial class CryptocurrencyPage : ContentPage
{
    public CryptocurrencyPage(CryptocurrencyViewModel vm)

    {
        InitializeComponent();
        BindingContext = vm;
    }
}