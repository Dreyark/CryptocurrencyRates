using CryptocurrencyRates.ViewModels;

namespace CryptocurrencyRates.Views;

public partial class OwnedCryptocurrencyPage : ContentPage
{
	public OwnedCryptocurrencyPage(OwnedCryptocurrencyViewModel vm)
	{
		BindingContext = vm;
		Title = vm.selectedItem.Name;
		InitializeComponent();
	}
}