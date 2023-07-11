using MvvmHelpers;

namespace Bookshop.ViewModels;

public partial class AuthorsViewModel : BaseViewModel
{
	readonly SampleDataService dataService;

	[ObservableProperty]
	bool isRefreshing;

	public ObservableRangeCollection<SampleItem> Items { get; } = new ObservableRangeCollection<SampleItem>();

	public AuthorsViewModel(SampleDataService service)
	{
		Title = "Authors";

		dataService = service;
	}

	[RelayCommand]
	private async void OnRefreshing()
	{
		IsRefreshing = true;

		try
		{
			await LoadDataAsync();
		}
		finally
		{
			IsRefreshing = false;
		}
	}

	[RelayCommand]
	public async Task LoadMore()
	{
		var items = await dataService.GetItems();

		Items.AddRange(items);
	}

	public async Task LoadDataAsync()
	{
		var items = await dataService.GetItems();

		Items.ReplaceRange(items);
	}

	[RelayCommand]
	private async void GoToDetails(SampleItem item)
	{
		await Shell.Current.GoToAsync(nameof(AuthorsDetailPage), true, new Dictionary<string, object>
		{
			{ "Item", item }
		});
	}
}
