using CommunityToolkit.Maui;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using OnegaiMuscle.CustomRenderer;
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
			})
			.UseMauiCompatibility()
            .ConfigureMauiHandlers((handlers) => {
#if ANDROID
                handlers.AddCompatibilityRenderer(typeof(EntryCustomRenderer), typeof(OnegaiMuscle.Platforms.Android.Renderer.MyEntryRenderer));
#endif

#if IOS
                        handlers.AddCompatibilityRenderer(typeof(EntryCustomRenderer), typeof(OnegaiMuscle.Platforms.iOS.Renderer.MyEntryRenderer));
#endif
            });
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();

		builder.Services.AddSingleton<VerificationPage>();
		builder.Services.AddSingleton<VerificationViewModel>();

		builder.Services.AddTransient<BookingPage>();
		builder.Services.AddTransient<BookingViewModel>();

        return builder.Build();
	}
}
