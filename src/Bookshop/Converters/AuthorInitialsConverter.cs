namespace Bookshop.Converters;

public class AuthorInitialsConverter : IValueConverter
{
	public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is null)
		{
			return null;
		}

		if (value is not Author author)
		{
			throw new NotSupportedException($"Value must be of type {nameof(Author)}");
		}

		string initals = string.Empty;

		if (!string.IsNullOrEmpty(author.FirstName))
		{
			initals += author?.FirstName.FirstOrDefault();
		}

		if (!string.IsNullOrEmpty(author.LastName))
		{
			initals += author?.LastName.FirstOrDefault();
		}

		return initals.ToUpperInvariant();
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}

