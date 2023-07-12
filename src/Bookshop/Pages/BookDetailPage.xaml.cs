namespace Bookshop.Pages;

public partial class BookDetailPage : BaseContentPage<BookDetailViewModel>
{
	public BookDetailPage(BookDetailViewModel viewModel)
		: base(viewModel)
	{
		InitializeComponent();
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		ViewModel.OnNavigatedTo();
	}
}
