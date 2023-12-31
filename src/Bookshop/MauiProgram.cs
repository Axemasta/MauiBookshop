﻿using Bookshop.Abstractions;
using Bookshop.DAL;
using Bookshop.DAL.Abstractions;
using Bookshop.DAL.Contexts;
using Bookshop.Extensions;
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;

namespace Bookshop;

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
				fonts.AddFont("FontAwesome6Free_Solid_900.otf", "FASolid");
				fonts.AddFont("FontAwesome6Free_Regular_400.otf", "FARegular");
				fonts.AddFont("FontAwesome6Brands_Regular_400.otf", "FABrands");
			});

		builder.Services.AddSingleton<IFileSystem>(FileSystem.Current);
		builder.Services.AddTransient<IFilePathProvider, BookshopDbPathProvider>();

		builder.Services.AddDbContextFactory<BookshopDbContext>((services, options) =>
		{
			var dbProvider = services.GetRequiredService<IFilePathProvider>();
			var dbPath = dbProvider.GetFilePath();
			options.UseSqlite($"FileName={dbPath}");
		});

		builder.Services.AddSingleton<IAuthorService, AuthorService>();

		builder.Services.AddTransient<AuthorsDetailViewModel>();
		builder.Services.AddTransient<AuthorsDetailPage>();
		builder.Services.AddTransient<AuthorsViewModel>();
		builder.Services.AddTransient<AuthorsPage>();
		builder.Services.AddTransient<BookDetailViewModel>();
		builder.Services.AddTransient<BookDetailPage>();

		var app = builder.Build();

		app.SeedDatabase();

		return app;
	}
}
