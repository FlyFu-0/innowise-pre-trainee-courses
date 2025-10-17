using task_4_library_manger.Contracts.Repository;
using task_4_library_manger.Contracts.Service;

namespace task_4_library_manger.Service;

public sealed class ServiceManager: IServiceManager
{
    private readonly Lazy<IAuthorService> _authorService;
    private readonly Lazy<IBookService> _bookService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _authorService = new Lazy<IAuthorService>(() =>
            new AuthorService(repositoryManager));
        _bookService = new Lazy<IBookService>(() =>
            new BookService(repositoryManager));
    }

    public IAuthorService AuthorService => _authorService.Value;
    public IBookService BookService => _bookService.Value;
}
