using CryptocurrencyRates.ViewModels;

namespace CryptocurrencyRates.Views;

public partial class AddOwnedCryptocurrencyPage : ContentPage
{
    AddOwnedCryptocurrencyViewModel VM;
    public AddOwnedCryptocurrencyPage(AddOwnedCryptocurrencyViewModel vm)
    {
        VM = vm;
        InitializeComponent();
        BindingContext = vm;
        CoinPicker.ItemsSource = vm.Cryptocurrencies.Select(x => x.Name).ToList();

    }
    protected override async void OnAppearing()
    {
        CoinPicker.SelectedIndex = VM.CombinedCrypto.CoinId - 1;
        base.OnAppearing();
        //CoinPicker.SelectedIndex = VM.CoinIndex;
        //AmountEntry.Text = VM.Amount.ToString();
        //DescrEntry.Text = VM.Description;
    }
}