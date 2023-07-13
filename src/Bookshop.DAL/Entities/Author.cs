namespace Bookshop.DAL.Entities;

public class Author : BaseEntity
{
	public required string FirstName { get; set; }

	public required string LastName { get; set; }

	public string? Description { get; set; }

	public string? ImageUrl { get; set; }

	public List<Book> Books { get; set; } = new();
}

