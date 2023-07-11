namespace Bookshop.DAL.Contexts;

public class BookshopDbContext : DbContext
{
	public DbSet<Author> Authors { get; set; }

	public DbSet<Book> Books { get; set; }

	public BookshopDbContext(DbContextOptions<BookshopDbContext> options)
		: base(options)
	{
	}

	public override int SaveChanges()
	{
		var entries = ChangeTracker
			.Entries()
			.Where(e => e.Entity is BaseEntity && (
				e.State == EntityState.Added ||
				e.State == EntityState.Modified));

		foreach (var entityEntry in entries)
		{
			((BaseEntity)entityEntry.Entity).ModifiedDate = DateTime.Now;

			if (entityEntry.State == EntityState.Added)
			{
				((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
			}
		}

		return base.SaveChanges();
	}
}

