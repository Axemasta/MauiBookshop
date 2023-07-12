namespace Bookshop.DAL.Entities;

public class Book : BaseEntity
{
	public required string Title { get; set; }

	public DateOnly PublishDate { get; set; }

	public decimal Price { get; set; }

	public required Author Author { get; set; }

	public BookType BookType { get; set; }

	public string? ImageUrl { get; set; }
}
