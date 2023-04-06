using CryptocurrencyRates.Views;

namespace CryptocurrencyRates;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(CryptocurrencyPage), typeof(CryptocurrencyPage));
        Routing.RegisterRoute(nameof(AddOwnedCryptocurrencyPage), typeof(AddOwnedCryptocurrencyPage));
        Routing.RegisterRoute(nameof(OwnedCryptocurrencyListPage), typeof(OwnedCryptocurrencyListPage));
        Routing.RegisterRoute(nameof(OwnedCryptocurrencyPage), typeof(OwnedCryptocurrencyPage));
        Routing.RegisterRoute(nameof(RateListPage), typeof(RateListPage));
    }
}
