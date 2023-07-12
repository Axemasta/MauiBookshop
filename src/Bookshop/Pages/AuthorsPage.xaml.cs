namespace Bookshop.Pages;

public partial class AuthorsPage : BaseContentPage<AuthorsViewModel>
{
	public AuthorsPage(AuthorsViewModel viewModel)
		: base(viewModel)
	{
		InitializeComponent();
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		ViewModel.LoadDataAsync();
	}

	void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (sender is CollectionView cv)
		{
			// Clear selection after author selected
			cv.SelectedItem = null;
		}
	}
}
