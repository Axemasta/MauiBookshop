namespace Bookshop.DAL.Contexts;

public sealed class BookshopDbContext : DbContext, IBookshopDbContext
{
	public DbSet<Author> Authors { get; set; }

	public DbSet<Book> Books { get; set; }

	public DbSet<BigDog> BigDogs { get; set; }

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
			if (entityEntry.State == EntityState.Added)
			{
				((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
			}
			else
			{
				((BaseEntity)entityEntry.Entity).ModifiedDate = DateTime.Now;
			}
		}

		return base.SaveChanges();
	}
}

