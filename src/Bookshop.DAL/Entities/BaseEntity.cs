namespace Bookshop.DAL.Entities;

public class BaseEntity
{
	public int Id { get; set; }

	public DateTime CreatedDate { get; set; }

	public DateTime? ModifiedDate { get; set; }
}

