using Bookshop.DAL;
using Bookshop.DAL.Abstractions;
using Bookshop.DAL.Contexts;
using Bookshop.Extensions;
using Microsoft.EntityFrameworkCore;

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

		builder.Services.AddSingleton<IFileSystem>(FileSystem.Current);
		builder.Services.AddTransient<IFilePathProvider, BookshopDbPathProvider>();

		builder.Services.AddDbContext<BookshopDbContext>((services, options) =>
		{
			var dbProvider = services.GetRequiredService<IFilePathProvider>();
			var dbPath = dbProvider.GetFilePath();
			options.UseSqlite($"FileName={dbPath}");
		});

		builder.Services.AddTransient<SampleDataService>();
		builder.Services.AddTransient<AuthorsDetailViewModel>();
		builder.Services.AddTransient<AuthorsDetailPage>();
		builder.Services.AddTransient<AuthorsViewModel>();
		builder.Services.AddTransient<AuthorsPage>();

		var app = builder.Build();

		app.SeedDatabase();

		return app;
	}
}
