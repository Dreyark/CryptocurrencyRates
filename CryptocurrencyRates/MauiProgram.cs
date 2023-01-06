using CryptocurrencyRates.ViewModels;
using CryptocurrencyRates.Views;
using Microsoft.Extensions.Logging;

namespace CryptocurrencyRates;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<CryptocurrencyViewModel>();

		builder.Services.AddTransient<AddCryptocurrencyPage>();
        builder.Services.AddTransient<AddCryptocurrencyViewModel>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
