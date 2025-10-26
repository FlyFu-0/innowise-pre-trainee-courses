using AutoMapper;
using task_4_library_manger.Contracts.Repository;
using task_4_library_manger.Contracts.Service;
using task_4_library_manger.Exceptions;
using task_4_library_manger.Models;
using task_4_library_manger.Shared.DTOs;

namespace task_4_library_manger.Service;

public sealed class BookService(IRepositoryManager repository, IMapper mapper) : IBookService
{
    public IEnumerable<BookDto> GetBooks()
    {
        var books = repository.BookRepository.GetBooks();

        var bookMapped = mapper.Map<IEnumerable<BookDto>>(books);
        return bookMapped;
    }

    public IEnumerable<BookDto> GetBooksForAuthor(Guid authorId)
    {
        var books = repository.BookRepository.GetBooksForAuthor(authorId);

        var bookMapped = mapper.Map<IEnumerable<BookDto>>(books);
        return bookMapped;
    }

    public BookDto GetBook(Guid authorId, Guid id)
    {
        var book = repository.BookRepository.GetBook(authorId, id);

        var bookMapped = mapper.Map<BookDto>(book);
        return bookMapped;
    }

    public BookDto CreateBookForAuthor(Guid authorId, BookDtoForCreation bookForCreation)
    {
        var author = GetAuthorAndCheckIfExists(authorId);

        var book = mapper.Map<Book>(bookForCreation);

        book.Id = Guid.NewGuid();
        book.AuthorId = author.Id;
        repository.BookRepository.CreateBook(book);

        var bookMapped = mapper.Map<BookDto>(book);
        return bookMapped;
    }

    public void DeleteBookForAuthor(Guid authorId, Guid id)
    {
        GetAuthorAndCheckIfExists(authorId);

        var book = GetBookAndCheckIfExists(authorId, id);
        repository.BookRepository.DeleteBook(book);
    }

    private Author GetAuthorAndCheckIfExists(Guid id)
    {
        var author = repository.AuthorRepository.GetAuthor(id);

        return author ?? throw new AuthorNotFoundException(id);
    }

    private Book GetBookAndCheckIfExists(Guid authorId, Guid id)
    {
        var book = repository.BookRepository.GetBook(authorId, id);

        return book ?? throw new BookNotFoundException(id);
    }

    public void UpdateBookForAuthor(Guid authorId, Guid id, BookDtoForUpdate bookForUpdate)
    {
        var author = GetAuthorAndCheckIfExists(authorId);

        var bookEntity = GetBookAndCheckIfExists(authorId, id);

        bookForUpdate.AuthorId = author.Id;

        var book = mapper.Map(bookForUpdate, bookEntity);
        repository.BookRepository.UpdateBook(book);
    }
}
