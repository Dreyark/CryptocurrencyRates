using CryptocurrencyRates.ViewModels;
using Microsoft.Maui.Controls;
using System.Linq;
using System.Net.WebSockets;

namespace CryptocurrencyRates.Views;

public partial class FavouriteCryptocurrencyListPage : ContentPage
{
    CryptocurrencyViewModel CryptocurrencyVM;
    public FavouriteCryptocurrencyListPage(CryptocurrencyViewModel vm)
    {
        InitializeComponent();
        CryptocurrencyVM = vm;
        BindingContext = CryptocurrencyVM;
	}
    protected override async void OnAppearing()
    {
        await CryptocurrencyVM.RefreshCommand.ExecuteAsync(this);
        var a = CryptocurrencyVM.Cryptocurrencies.Where(c=>c.IsFavourite == true ).ToList();
        FavouriteListView.ItemsSource = a;
        base.OnAppearing();
    }
}