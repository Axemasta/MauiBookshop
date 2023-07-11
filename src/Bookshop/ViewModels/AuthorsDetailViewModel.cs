namespace Bookshop.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class AuthorsDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	SampleItem? item;

	public void OnNavigatedTo()
	{
		Title = Item?.Title;
	}
}
