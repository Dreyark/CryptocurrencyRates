#if WINDOWS
    using Microsoft.UI;
    using Microsoft.UI.Windowing;
    using Windows.Graphics;
#endif
namespace CryptocurrencyRates;

public partial class App : Application
{
	public App()
	{
        InitializeComponent();

        MainPage = new AppShell();
	}
#if WINDOWS
    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        const int newWidth = 480;
        const int newHeight = 680;

        window.Width = newWidth;
        window.Height = newHeight;

        return window;
    }
#endif
}
