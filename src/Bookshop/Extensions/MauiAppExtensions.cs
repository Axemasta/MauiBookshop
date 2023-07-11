using Bookshop.DAL.Contexts;
using Bookshop.DAL.Entities;
using System.Text.Json;

namespace Bookshop.Extensions;

public static class MauiAppExtensions
{
	public static void SeedDatabase(this MauiApp mauiApp)
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

			var seedJson = GetResourceString("Seed.json");

			var authors = JsonSerializer.Deserialize<List<Author>>(seedJson);

			if (authors is null || authors.Count < 1)
			{
				throw new InvalidOperationException("Seed data failed to load");
			}

			dbContext.Authors.AddRange(authors);
			dbContext.SaveChanges();
		}
	}

	private static string GetResourceString(string resourceName)
	{
		var assembly = typeof(App).Assembly;

		var resourceNames = assembly.GetManifestResourceNames();

		var assemblyResourceName = resourceNames.FirstOrDefault(r => r.EndsWith(resourceName, StringComparison.InvariantCultureIgnoreCase));

		if (assemblyResourceName is null)
		{
			throw new InvalidOperationException($"Resource not found: {resourceName}");
		}

		using (var stream = assembly.GetManifestResourceStream(assemblyResourceName))
		using (var streamReader = new StreamReader(stream))
		{
			return streamReader.ReadToEnd();
		}
	}
}

