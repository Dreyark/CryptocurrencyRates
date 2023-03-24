using CryptocurrencyRates.ViewModels;

namespace CryptocurrencyRates.Views;

public partial class FavouriteCryptocurrencyListPage : ContentPage
{
    CryptocurrencyViewModel CryptocurrencyVM;
    public FavouriteCryptocurrencyListPage(CryptocurrencyViewModel vm)
    {
        CryptocurrencyVM = vm;
        InitializeComponent();
        BindingContext = CryptocurrencyVM;
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //await CryptocurrencyVM.RefreshCommand.ExecuteAsync(this);
    }
}