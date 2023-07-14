﻿namespace Bookshop.ViewModels;

public partial class BaseViewModel : ObservableObject
{
	[ObservableProperty]
	private string? title;

	public virtual void OnNavigatedTo() { }
}
