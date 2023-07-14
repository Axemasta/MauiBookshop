namespace Bookshop.Pages;

public partial class AuthorsDetailPage : BaseContentPage<AuthorsDetailViewModel>
{
	public AuthorsDetailPage(AuthorsDetailViewModel viewModel)
		: base(viewModel)
	{
		InitializeComponent();
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		ViewModel.OnNavigatedTo();
	}
}
