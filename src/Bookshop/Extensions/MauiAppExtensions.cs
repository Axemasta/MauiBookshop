using Bookshop.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Bookshop.Extensions;

public static class MauiAppExtensions
{
	public static async void SeedDatabase(this MauiApp mauiApp)
	{
		using (var scope = mauiApp.Services.CreateScope())
		{
			var dbContext = scope.ServiceProvider.GetRequiredService<BookshopDbContext>();

			var pendingMigrations = MigrationsPending(dbContext);

			dbContext.Database.Migrate();

			if ((dbContext.Authors.Any() || dbContext.Books.Any()) && !pendingMigrations)
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

	private static bool MigrationsPending(BookshopDbContext bookshopDbContext)
	{
		// I'm not sure how this would work if the db didnt exist so for safety...

		try
		{
			return bookshopDbContext.Database.GetPendingMigrations()
				.Any();
		}
		catch
		{
			return false;
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

