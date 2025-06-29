using Microsoft.Extensions.Logging;

namespace AlphaVet;

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
				fonts.AddFont("Bukhari Script.ttf", "AlphaVet");
                fonts.AddFont("Quicksand-VariableFont_wght.ttf", "MainFont");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
