namespace Bookshop.ViewModels;

[QueryProperty(nameof(Author), "Author")]
public partial class AuthorsDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	Author? author;

	public override void OnNavigatedTo()
	{
		if (Author is null)
		{
			//
			return;
		}

		var fullName = Author.FirstName + " " + Author.LastName;

		Title = fullName;
	}

	[RelayCommand]
	private async Task GoToBook(Book? book)
	{
		if (book is null)
		{
			return;
		}

		// Very testable 😘
		await Shell.Current.GoToAsync(nameof(BookDetailPage), true, new Dictionary<string, object>
		{
			{ "Book", book }
		});
	}
}
