namespace Bookshop.Views;

public partial class AuthorsDetailPage : ContentPage
{
	public AuthorsDetailPage(AuthorsDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		if (BindingContext is AuthorsDetailViewModel vm)
		{
			vm.OnNavigatedTo();
		}
	}
}
