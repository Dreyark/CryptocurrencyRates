using CryptocurrencyRates.ViewModels;

namespace CryptocurrencyRates.Views;

public partial class AddOwnedCryptocurrencyPage : ContentPage
{
	public AddOwnedCryptocurrencyPage(AddOwnedCryptocurrencyViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		CoinPicker.ItemsSource = vm.Cryptocurrencies.Select(x => x.Name).ToList();

    }
}