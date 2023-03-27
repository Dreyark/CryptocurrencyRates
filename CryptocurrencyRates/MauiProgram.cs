using CryptocurrencyRates.Services;
using CryptocurrencyRates.ViewModels;
using CryptocurrencyRates.Views;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace CryptocurrencyRates;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseSkiaSharp(true)
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        RateUpdater rateUpdater = new RateUpdater();
        CoinUpdater coinUpdater = new CoinUpdater();
        builder.Services.AddSingleton<ICryptocurrencyService>((e) => new CryptocurrencyService());
        builder.Services.AddSingleton<ISharedDataInterface>((e) => new SharedDataInterface());
        builder.Services.AddSingleton<IOwnedCryptocurrencyService>((e) => new OwnedCryptocurrencyService());
        builder.Services.AddSingleton<IRateService>((e) => new RateService());
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<CryptocurrencyViewModel>();
		builder.Services.AddSingleton<CryptocurrencyPageViewModel>();
		builder.Services.AddSingleton<OwnedCryptocurrencyViewModel>();
        builder.Services.AddSingleton<RateViewModel>();
        builder.Services.AddSingleton<AddOwnedCryptocurrencyViewModel>();
        builder.Services.AddTransient<RateListPage>();
        builder.Services.AddTransient<AddOwnedCryptocurrencyPage>();
        builder.Services.AddTransient<CryptocurrencyPage>();
        builder.Services.AddTransient<OwnedCryptocurrencyListPage>();
        builder.Services.AddTransient<FavouriteCryptocurrencyListPage>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
