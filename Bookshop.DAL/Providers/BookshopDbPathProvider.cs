using Bookshop.DAL.Abstractions;

namespace Bookshop.DAL;

public class BookshopDbPathProvider : IFilePathProvider
{
	private readonly IFileSystem fileSystem;

	public BookshopDbPathProvider(IFileSystem fileSystem)
	{
		this.fileSystem = fileSystem;
	}

	public string GetFilePath()
	{
		return Path.Combine(fileSystem.AppDataDirectory, Constants.DatabaseFileName);
	}
}

