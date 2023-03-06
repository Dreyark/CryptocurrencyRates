using CryptocurrencyRates.ViewModels;

namespace CryptocurrencyRates.Views;

public partial class CryptocurrencyPage : ContentPage
{
    public CryptocurrencyPage(CryptocurrencyViewModel vm)

    {
        InitializeComponent();
        BindingContext = vm;
    }
}