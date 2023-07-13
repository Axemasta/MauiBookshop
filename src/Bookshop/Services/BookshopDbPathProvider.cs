using Bookshop.DAL;
using Bookshop.DAL.Abstractions;

namespace Bookshop.Services;

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

