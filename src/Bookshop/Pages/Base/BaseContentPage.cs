namespace Bookshop.Pages.Base;

public class BaseContentPage<TViewModel> : ContentPage
	where TViewModel : BaseViewModel
{
	protected TViewModel ViewModel { get; }

	protected BaseContentPage(TViewModel viewModel)
	{
		this.ViewModel = viewModel;
		this.BindingContext = viewModel;
	}
}
