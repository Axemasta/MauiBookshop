namespace Bookshop.Views;

public partial class AuthorsPage : BaseContentPage<AuthorsViewModel>
{
	public AuthorsPage(AuthorsViewModel viewModel)
		: base(viewModel)
	{
		InitializeComponent();
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		ViewModel.LoadDataAsync();
	}
}
