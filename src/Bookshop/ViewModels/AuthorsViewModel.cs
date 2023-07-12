using MvvmHelpers;

namespace Bookshop.ViewModels;

public partial class AuthorsViewModel : BaseViewModel
{
	private readonly IAuthorService authorService;

	public ObservableRangeCollection<Author> Authors { get; } = new ObservableRangeCollection<Author>();

	public AuthorsViewModel(IAuthorService authorService)
	{
		this.authorService = authorService;

		Title = "Authors";
	}

	public void LoadDataAsync()
	{
		var authors = authorService.GetAuthors();

		Authors.ReplaceRange(authors);
	}

	[RelayCommand]
	private async void GoToDetails(Author author)
	{
		await Shell.Current.GoToAsync(nameof(AuthorsDetailPage), true, new Dictionary<string, object>
		{
			{ "Author", author }
		});
	}
}
