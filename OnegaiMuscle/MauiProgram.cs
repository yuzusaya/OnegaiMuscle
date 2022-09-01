using CommunityToolkit.Maui;
using OnegaiMuscle.ViewModels;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace OnegaiMuscle;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseSkiaSharp()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();

		builder.Services.AddSingleton<VerificationPage>();
		builder.Services.AddSingleton<VerificationViewModel>();

		builder.Services.AddTransient<BookingPage>();
		builder.Services.AddTransient<BookingViewModel>();

        return builder.Build();
	}
}
