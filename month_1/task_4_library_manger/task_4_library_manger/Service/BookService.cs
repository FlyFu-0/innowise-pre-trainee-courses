using AutoMapper;
using task_4_library_manger.Contracts.Repository;
using task_4_library_manger.Contracts.Service;
using task_4_library_manger.Entities.Models;
using task_4_library_manger.Exceptions;
using task_4_library_manger.Models;
using task_4_library_manger.Shared.DTOs;
using task_4_library_manger.Shared.RequestFeatures;

namespace task_4_library_manger.Service;

public sealed class BookService(IRepositoryManager repository, IMapper mapper) : IBookService
{
    public async Task<(IEnumerable<BookDto> books, MetaData metaData)> GetBooksAsync(BookParameters bookParameters, bool trackChanges = false, Guid? authorId = null)
    {
        if (!bookParameters.ValidYearRange)
        {
            throw new InvalidYearRange();
        }

        var booksWithMetaData = await repository.BookRepository.GetBooksAsync(bookParameters, trackChanges, authorId);

        var bookMapped = mapper.Map<IEnumerable<BookDto>>(booksWithMetaData);
        return (bookMapped, booksWithMetaData.MetaData);
    }

    public async Task<BookDto> GetBookAsync(Guid authorId, Guid id, bool trackChanges = false)
    {
        var book = await repository.BookRepository.GetBookAsync(authorId, id, trackChanges);

        var bookMapped = mapper.Map<BookDto>(book);
        return bookMapped;
    }

    public async Task<BookDto> CreateBookForAuthorAsync(Guid authorId, BookDtoForCreation bookForCreation)
    {
        var author = await GetAuthorAndCheckIfExists(authorId);

        var book = mapper.Map<Book>(bookForCreation);

        book.Id = Guid.NewGuid();
        book.AuthorId = author.Id;
        repository.BookRepository.CreateBookAsync(book);
        await repository.SaveAsync();

        var bookMapped = mapper.Map<BookDto>(book);
        return bookMapped;
    }

    public async Task DeleteBookForAuthorAsync(Guid authorId, Guid id)
    {
        await GetAuthorAndCheckIfExists(authorId);

        var book = await GetBookAndCheckIfExists(authorId, id);
        repository.BookRepository.DeleteBookAsync(book);
        await repository.SaveAsync();
    }

    private async Task<Author> GetAuthorAndCheckIfExists(Guid id)
    {
        var author = await repository.AuthorRepository.GetAuthorAsync(id, false);

        return author ?? throw new AuthorNotFoundException(id);
    }

    private async Task<Book> GetBookAndCheckIfExists(Guid authorId, Guid id)
    {
        var book = await repository.BookRepository.GetBookAsync(authorId, id, false);

        return book ?? throw new BookNotFoundException(id);
    }

    public async Task UpdateBookForAuthorAsync(Guid authorId, Guid id, BookDtoForUpdate bookForUpdate)
    {
        var bookEntity = await GetBookAndCheckIfExists(authorId, id);

        var book = mapper.Map(bookForUpdate, bookEntity);
        repository.BookRepository.UpdateBookAsync(book);
        await repository.SaveAsync();
    }
}
