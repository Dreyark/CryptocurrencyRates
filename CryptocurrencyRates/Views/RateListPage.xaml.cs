using CryptocurrencyRates.Models;
using CryptocurrencyRates.ViewModels;
using System.Globalization;
using System.Linq;

namespace CryptocurrencyRates.Views;

public partial class RateListPage : ContentPage
{
    RateViewModel RateVM;
    public RateListPage(RateViewModel vm)
    {
        RateVM = vm;
        RateVM.RefreshCommand.Execute(this);
        InitializeComponent();
        BindingContext = RateVM;
        rateListView.ItemsSource = RateVM.Rates.OrderBy(e => e.sId);
        FirstCurrPicker.ItemsSource = RateVM.Rates.OrderBy(e => e.sId).Select(x => x.sId).ToList();
        SecCurrPicker.ItemsSource = RateVM.Rates.OrderBy(e => e.sId).Select(x => x.sId).ToList();
        RateVM.RefreshCommand.ExecuteAsync(this);
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
    }

    private void SelectedIndexChanged(object sender, EventArgs e)
    {

            //FirstCurrText.Text = (string)FirstCurrPicker.SelectedItem;
            //SecCurrText.Text = (string)SecCurrPicker.SelectedItem;
        if (SecCurrPicker.SelectedIndex != -1 && FirstCurrPicker.SelectedIndex != -1)
        {
            Rate first = RateVM.Rates.OrderBy(e => e.sId).First(x => x.sId == (string)FirstCurrPicker.SelectedItem);
            Rate sec = RateVM.Rates.OrderBy(e => e.sId).First(x => x.sId == (string)SecCurrPicker.SelectedItem);
            var value = Convert.ToDecimal(first.rateUsd, CultureInfo.InvariantCulture) * 1 / Convert.ToDecimal(sec.rateUsd, CultureInfo.InvariantCulture);
            decimal inputValue = 0;
            if (decimal.TryParse(FirstCurr.Text, out decimal result))
            {
                inputValue = Convert.ToDecimal(result);
            }
            value = Math.Round(inputValue * value, 6);
            SecCurr.Text = value.ToString();
        }
    }

    private void Exchange_Clicked(object sender, EventArgs e)
    {
        ExchangeFrame.IsVisible = !ExchangeFrame.IsVisible;
    }

    private void IsVisible(object sender, EventArgs e)
    {
        ExchangeFrame.IsVisible = true;
    }

}