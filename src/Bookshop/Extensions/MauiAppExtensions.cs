using Bookshop.DAL.Contexts;
using Bookshop.DAL.Entities;
using System.Text.Json;

namespace Bookshop.Extensions;

public static class MauiAppExtensions
{
	public static async void SeedDatabase(this MauiApp mauiApp)
	{
		using (var scope = mauiApp.Services.CreateScope())
		{
			var dbContext = scope.ServiceProvider.GetRequiredService<BookshopDbContext>();

			dbContext.Database.EnsureCreated();

			if (dbContext.Authors.Any() || dbContext.Books.Any())
			{
				Debug.WriteLine("Database already seeded");
				return;
			}

			Debug.WriteLine("Seeding Database");

			var authors = await GetResourceData<List<Author>>("Seed.json");

			if (authors is null || authors.Count < 1)
			{
				throw new InvalidOperationException("Seed data failed to load");
			}

			dbContext.Authors.AddRange(authors);
			dbContext.SaveChanges();
		}
	}

	private static async Task<T?> GetResourceData<T>(string resourceName)
	{
		using var stream = await FileSystem.OpenAppPackageFileAsync(resourceName);

		if (stream is null)
		{
			return default;
		}

		using var streamReader = new StreamReader(stream);

		return JsonSerializer.Deserialize<T>(stream);
	}
}

