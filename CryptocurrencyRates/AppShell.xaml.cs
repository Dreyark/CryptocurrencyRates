using CryptocurrencyRates.Views;

namespace CryptocurrencyRates;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddCryptocurrencyPage), typeof(AddCryptocurrencyPage));
	}
}
