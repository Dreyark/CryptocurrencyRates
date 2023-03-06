using CryptocurrencyRates.ViewModels;

namespace CryptocurrencyRates.Views;

public partial class AddOwnedCryptocurrencyPage : ContentPage
{
	public AddOwnedCryptocurrencyPage(AddOwnedCryptocurrencyViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}