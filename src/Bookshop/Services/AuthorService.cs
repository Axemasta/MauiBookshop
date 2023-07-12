namespace Bookshop.Services;

public class AuthorService : IAuthorService
{
	private readonly IBookshopDbContext bookshopDbContext;

	public AuthorService(IBookshopDbContext bookshopDbContext)
	{
		this.bookshopDbContext = bookshopDbContext;
	}

	public List<Author> GetAuthors()
	{
		return bookshopDbContext.Authors.ToList();
	}
}

