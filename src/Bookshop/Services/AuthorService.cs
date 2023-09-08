using Bookshop.Abstractions;
using Bookshop.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Bookshop.Services;

public class AuthorService : IAuthorService
{
	private readonly IDbContextFactory<BookshopDbContext> bookshopDbContextFactory;

	public AuthorService(IDbContextFactory<BookshopDbContext> bookshopDbContextFactory)
	{
		this.bookshopDbContextFactory = bookshopDbContextFactory;
	}

	public List<Author> GetAuthors()
	{
		using var dbContext = bookshopDbContextFactory.CreateDbContext();

		return dbContext.Authors
			.Include(a => a.Books)
			.ToList();
	}
}

