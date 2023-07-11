namespace Bookshop.DAL.Contexts;

public class BookshopDbContext : DbContext
{
	public BookshopDbContext(DbContextOptions<BookshopDbContext> options)
		: base(options)
	{
	}
}

