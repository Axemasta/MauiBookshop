using Bookshop.DAL.Entities;

namespace Bookshop.Abstrations;

public interface IAuthorService
{
	List<Author> GetAuthors();
}
