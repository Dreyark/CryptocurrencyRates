using CryptocurrencyRates.ViewModels;

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
        rateListView.ItemsSource = RateVM.Rates.OrderBy(e=>e.sId);
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await RateVM.RefreshCommand.ExecuteAsync(this);
    }
}