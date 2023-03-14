using CryptocurrencyRates.ViewModels;

namespace CryptocurrencyRates.Views;

public partial class OwnedCryptocurrencyListPage : ContentPage
{
    OwnedCryptocurrencyViewModel VM;
    public OwnedCryptocurrencyListPage(OwnedCryptocurrencyViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
        VM = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //await VM.RefreshCommand.ExecuteAsync(this);
    }

}