using CryptocurrencyRates.Services;
using CryptocurrencyRates.ViewModels;
using CryptocurrencyRates.Views;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace CryptocurrencyRates;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<ICryptocurrencyService>((e) => new CryptocurrencyService());
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<CryptocurrencyViewModel>();
		builder.Services.AddTransient<AddOwnedCryptocurrencyPage>();
        builder.Services.AddTransient<CryptocurrencyPage>();
        //builder.Services.AddTransient<OwnedCryptocurrencyListPage>();
        builder.Services.AddTransient<AddOwnedCryptocurrencyViewModel>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
