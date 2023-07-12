using Microsoft.EntityFrameworkCore;

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
		return bookshopDbContext.Authors
			.Include(a => a.Books)
			.ToList();
	}
}

