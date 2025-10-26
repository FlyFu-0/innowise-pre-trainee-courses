using Microsoft.AspNetCore.Mvc;
using task_4_library_manger.ActionFilters;
using task_4_library_manger.Contracts.Service;
using task_4_library_manger.Models;
using task_4_library_manger.Shared.DTOs;

namespace task_4_library_manger.Apis;

public static class BookApis
{
    public static IEndpointRouteBuilder MapBooksApi(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/{authorId:guid}");

        app.MapGet("/books", GetBooks)
            .WithName("AllBooks")
            .WithSummary("Get all books")
            .WithTags("Books");

        api.MapGet("/books", GetBooksForAuthor)
            .WithName("Books for {authorId:guid}")
            .WithSummary("Books for author")
            .WithTags("Books");
        api.MapGet("/books/{id:guid}", GetBook)
            .WithName("Book")
            .WithSummary("Book's data")
            .WithTags("Books");

        api.MapPost("/books", CreateBook)
            .WithName("CreateBook")
            .WithSummary("Create author")
            .WithTags("Books")
            .AddEndpointFilter<ValidationFilter<BookDtoForCreation>>();
        api.MapPut("/books/{id:guid}", UpdateBook)
            .WithName("UpdateBook")
            .WithSummary("Update author")
            .WithTags("Books");
        api.MapDelete("/books/{id:guid}", DeleteBook)
            .WithName("DeleteBook")
            .WithSummary("Delete author")
            .WithTags("Books");

        return app;
    }

    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static IResult GetBooks(IServiceManager services)
    {
        var books = services.BookService.GetBooks();
        return Results.Ok(books);
    }

    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static IResult GetBooksForAuthor(IServiceManager services, Guid authorId)
    {
        var books = services.BookService.GetBooksForAuthor(authorId);
        return Results.Ok(books);
    }


    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static IResult GetBook(IServiceManager services, Guid authorId, Guid id)
    {
        var book = services.BookService.GetBook(authorId, id);
        return Results.Ok(book);
    }

    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static IResult CreateBook(IServiceManager services, Guid authorId, BookDtoForCreation book)
    {
        var createdBook = services.BookService.CreateBookForAuthor(authorId, book);
        return Results.Created($"api/{createdBook.AuthorId}/books/{createdBook.Id}", createdBook);
    }

    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static IResult UpdateBook(IServiceManager services, Guid authorId, Guid id, BookDtoForUpdate book)
    {
        services.BookService.UpdateBookForAuthor(authorId, id, book);
        return Results.Ok();
    }

    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static IResult DeleteBook(IServiceManager services, Guid authorId, Guid id)
    {
        services.BookService.DeleteBookForAuthor(authorId, id);
        return Results.NoContent();
    }
}
