namespace Bookshop.Views;

public partial class AuthorsPage : ContentPage
{
	AuthorsViewModel ViewModel;

	public AuthorsPage(AuthorsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = ViewModel = viewModel;
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		await ViewModel.LoadDataAsync();
	}
}
