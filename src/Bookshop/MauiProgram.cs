namespace Bookshop;

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

		builder.Services.AddTransient<SampleDataService>();
		builder.Services.AddTransient<AuthorsDetailViewModel>();
		builder.Services.AddTransient<AuthorsDetailPage>();
		builder.Services.AddTransient<AuthorsViewModel>();
		builder.Services.AddTransient<AuthorsPage>();

		return builder.Build();
	}
}
