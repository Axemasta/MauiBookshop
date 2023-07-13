namespace Bookshop.DAL.Providers;

public class DesignTimePathProvider : IFilePathProvider
{
	public string GetFilePath()
	{
		return "DesignTime.db";
	}
}
