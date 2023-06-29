using CryptocurrencyRates.ViewModels;
using System.Globalization;

namespace CryptocurrencyRates.Views;

public partial class OwnedCryptocurrencyPage : ContentPage
{
    OwnedCryptocurrencyViewModel OwnedCryptocurrencyPageVM;
    public OwnedCryptocurrencyPage(OwnedCryptocurrencyViewModel vm)
	{
        OwnedCryptocurrencyPageVM = vm;
        BindingContext = vm;
		Title = vm.selectedItem.Name;
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        decimal changePrcnt = (Math.Round(Convert.ToDecimal(OwnedCryptocurrencyPageVM.selectedItem.CurrentRateUsd, CultureInfo.InvariantCulture) / Convert.ToDecimal(OwnedCryptocurrencyPageVM.selectedItem.StartPrice), 4) - 1) * 100;
        decimal sum = Math.Round(Convert.ToDecimal(OwnedCryptocurrencyPageVM.selectedItem.Summary) - Convert.ToDecimal(OwnedCryptocurrencyPageVM.selectedItem.StartPrice)* Convert.ToDecimal(OwnedCryptocurrencyPageVM.selectedItem.Amount), 2);
        CurrentRate.Text = "Current rate: " + Convert.ToDecimal(OwnedCryptocurrencyPageVM.selectedItem.CurrentRateUsd, CultureInfo.InvariantCulture).ToString("G29") + "$";
        Amount.Text = "Quantity: " + Convert.ToDecimal(OwnedCryptocurrencyPageVM.selectedItem.Amount, CultureInfo.InvariantCulture).ToString("G29");
        Summary.Text = " Current value: " + OwnedCryptocurrencyPageVM.selectedItem.Summary+"$";
        ChangePrcnt.Text = " Profit %: ↓" + changePrcnt.ToString("G29")+"%";
        StartPrice.Text = "Average cost: " + OwnedCryptocurrencyPageVM.selectedItem.StartPrice+"$";
        Profit.Text = "↓" + sum.ToString("G29")+"$";
        Change.Text = "24h Change: " + OwnedCryptocurrencyPageVM.selectedItem.changePercent24Hr.Replace(".",",")+"";
        Description.Text =  OwnedCryptocurrencyPageVM.selectedItem.Description;

    }
}