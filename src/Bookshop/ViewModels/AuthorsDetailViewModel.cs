namespace Bookshop.ViewModels;

[QueryProperty(nameof(Author), "Author")]
public partial class AuthorsDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	Author? author;

	public void OnNavigatedTo()
	{
		if (Author is null)
		{
			//
			return;
		}

		var fullName = Author.FirstName + " " + Author.LastName;

		Title = fullName;
	}
}
