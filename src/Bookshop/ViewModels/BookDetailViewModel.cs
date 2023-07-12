namespace Bookshop.ViewModels;

[QueryProperty(nameof(Book), "Book")]
public partial class BookDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	Book? book;

	public override void OnNavigatedTo()
	{
		if (Book is null)
		{
			return;
		}

		Title = Book.Title;
	}
}

