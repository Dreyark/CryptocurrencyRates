using CryptocurrencyRates.Models;
using CryptocurrencyRates.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Controls.Xaml;
using System.Data;

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
        await VM.RefreshCommand.ExecuteAsync(this);
        //OwnCryptoList.ItemsSource = VM.Combined;
        base.OnAppearing();
    }
}