namespace Bookshop.Pages.Base;

public class BaseContentPage<TViewModel> : ContentPage
	where TViewModel : BaseViewModel
{
	protected TViewModel ViewModel { get; init; }

	public BaseContentPage(TViewModel viewmMdel)
	{
		this.ViewModel = viewmMdel;
		this.BindingContext = viewmMdel;
	}
}
