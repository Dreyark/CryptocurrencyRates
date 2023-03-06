using CryptocurrencyRates.ViewModels;

namespace CryptocurrencyRates.Views;

public partial class MainPage : ContentPage
{
    CryptocurrencyViewModel CryptocurrencyVM;
    public MainPage(CryptocurrencyViewModel vm)
    {
        CryptocurrencyVM = vm;
        CryptocurrencyVM.RefreshCommand.Execute(this);
        //CryptocurrencyViewModel vm
        InitializeComponent();
        BindingContext = CryptocurrencyVM;

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CryptocurrencyVM.RefreshCommand.ExecuteAsync(this);
    }


}

