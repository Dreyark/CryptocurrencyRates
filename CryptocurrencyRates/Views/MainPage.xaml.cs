using CryptocurrencyRates.ViewModels;

namespace CryptocurrencyRates.Views;

public partial class MainPage : ContentPage
{

    public MainPage(CryptocurrencyViewModel vm)
    {
        InitializeComponent();
        BindingContext =  vm;
    }

    //protected override async void OnAppearing()
    //{
    //    //base.OnAppearing();
    //    //var vm = (CryptocurrencyViewModel)BindingContext;
    //    //if (vm.Cryptocurrency.Count == 0)
    //    //    await vm.RefreshCommand.ExecuteAsync();
    //}

}

