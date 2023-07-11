namespace Bookshop.Views;

public partial class AuthorsDetailPage : ContentPage
{
	public AuthorsDetailPage(AuthorsDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
