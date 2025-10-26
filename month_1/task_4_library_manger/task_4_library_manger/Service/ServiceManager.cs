using AutoMapper;
using task_4_library_manger.Contracts.Repository;
using task_4_library_manger.Contracts.Service;

namespace task_4_library_manger.Service;

public sealed class ServiceManager(IRepositoryManager repositoryManager, IMapper mapper) : IServiceManager
{
    private readonly Lazy<IAuthorService> _authorService = new(() =>
        new AuthorService(repositoryManager, mapper));
    private readonly Lazy<IBookService> _bookService = new(() =>
        new BookService(repositoryManager, mapper));

    public IAuthorService AuthorService => _authorService.Value;
    public IBookService BookService => _bookService.Value;
}
