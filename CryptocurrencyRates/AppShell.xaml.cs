using CryptocurrencyRates.Views;

namespace CryptocurrencyRates;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddOwnedCryptocurrencyPage), typeof(AddOwnedCryptocurrencyPage));
        Routing.RegisterRoute(nameof(CryptocurrencyPage), typeof(CryptocurrencyPage));
    }
}
