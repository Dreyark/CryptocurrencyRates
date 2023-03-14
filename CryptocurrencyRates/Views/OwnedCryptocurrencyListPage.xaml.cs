using CryptocurrencyRates.ViewModels;
using Microsoft.Maui;

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
        OwnCryptoList.ItemsSource = VM.combinedCrypto();
        var c = VM.combinedCrypto().GetType();
        //LabelX.Text = c.ToString();
        await VM.RefreshCommand.ExecuteAsync(this);
        
    }   

}