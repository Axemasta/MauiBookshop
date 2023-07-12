namespace Bookshop;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AuthorsDetailPage), typeof(AuthorsDetailPage));
		Routing.RegisterRoute(nameof(BookDetailPage), typeof(BookDetailPage));
	}
}
