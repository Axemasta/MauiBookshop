using Bookshop.DAL.Contexts;
using Bookshop.DAL.Providers;
using Microsoft.EntityFrameworkCore.Design;

namespace Bookshop.DAL.Migrations;

public class DbContextMigrationFactory : IDesignTimeDbContextFactory<BookshopDbContext>
{
	private readonly IFilePathProvider dbPathProvider;

	public DbContextMigrationFactory()
		: this(new DesignTimePathProvider())
	{
	}

	private DbContextMigrationFactory(IFilePathProvider filePathProvider)
	{
		this.dbPathProvider = filePathProvider;
	}

	public BookshopDbContext CreateDbContext(string[] args)
	{
		var builder = new DbContextOptionsBuilder<BookshopDbContext>();

		var dbPath = dbPathProvider.GetFilePath();

		// This filename can be anything
		builder.UseSqlite($"FileName={dbPath}");

		return new BookshopDbContext(builder.Options);
	}
}
