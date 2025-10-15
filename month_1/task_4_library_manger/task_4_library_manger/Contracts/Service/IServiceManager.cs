namespace task_4_library_manger.Contracts.Service;

public interface IServiceManager
{
    IAuthorService AuthorService { get; }
    IBookService BookService { get; }
}