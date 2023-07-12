using Bookshop.DAL.Contexts;
using Microsoft.EntityFrameworkCore.Design;

namespace Bookshop.DAL.Migrations;

public class DbContextMigrationFactory : IDesignTimeDbContextFactory<BookshopDbContext>
{
	public BookshopDbContext CreateDbContext(string[] args)
	{
		var builder = new DbContextOptionsBuilder<BookshopDbContext>();

		var dbProvider = new BookshopDbPathProvider(FileSystem.Current);
		var dbPath = dbProvider.GetFilePath();

		builder.UseSqlite($"FileName={dbPath}");

		return new BookshopDbContext(builder.Options);
	}
}