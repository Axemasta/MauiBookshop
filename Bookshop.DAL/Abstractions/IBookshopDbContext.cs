namespace Bookshop.DAL.Abstractions;

public interface IBookshopDbContext
{
	DbSet<Author> Authors { get; set; }

	DbSet<Book> Books { get; set; }
}
