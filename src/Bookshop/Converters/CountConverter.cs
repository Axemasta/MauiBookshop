using System.Collections;

namespace Bookshop.Converters;

public class CountConverter : IValueConverter
{
	public string? TextTemplate { get; set; }

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is not IList list)
		{
			throw new InvalidOperationException($"Value must be {nameof(IList)}");
		}

		if (string.IsNullOrEmpty(TextTemplate))
		{
			return list.Count;
		}

		try
		{
			return string.Format(TextTemplate, list.Count);
		}
		catch
		{
			return $"Invalid string format: {list.Count}";
		}
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}

