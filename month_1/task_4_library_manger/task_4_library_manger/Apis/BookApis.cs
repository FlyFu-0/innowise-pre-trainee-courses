using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using task_4_library_manger.ActionFilters;
using task_4_library_manger.Contracts.Service;
using task_4_library_manger.Shared.DTOs;
using task_4_library_manger.Shared.RequestFeatures;

namespace task_4_library_manger.Apis;

public static class BookApis
{
    public static IEndpointRouteBuilder MapBooksApi(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/{authorId:guid}");

        app.MapGet("api/books", GetBooks)
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
    public static async Task<IResult> GetBooks(HttpContext context, IServiceManager services,
        [AsParameters] BookParameters bookParameters)
    {
        var result = await services.BookService.GetBooksAsync(bookParameters, false);

        context.Response.Headers["X-Pagination"] = JsonSerializer.Serialize(result.metaData);
        return Results.Ok(result.books);
    }

    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static async Task<IResult> GetBooksForAuthor(IServiceManager services, Guid authorId,
        [AsParameters] BookParameters bookParameters)
    {
        var books = await services.BookService.GetBooksAsync(bookParameters, false, authorId);
        return Results.Ok(books);
    }


    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static async Task<IResult> GetBook(IServiceManager services, Guid authorId, Guid id)
    {
        var book = await services.BookService.GetBookAsync(authorId, id, false);
        return Results.Ok(book);
    }

    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static async Task<IResult> CreateBook(IServiceManager services, Guid authorId, BookDtoForCreation book)
    {
        var createdBook = await services.BookService.CreateBookForAuthorAsync(authorId, book);
        return Results.Created($"api/{createdBook.AuthorId}/books/{createdBook.Id}", createdBook);
    }

    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static async Task<IResult> UpdateBook(IServiceManager services, Guid authorId, Guid id,
        BookDtoForUpdate book)
    {
        await services.BookService.UpdateBookForAuthorAsync(authorId, id, book);
        return Results.Ok();
    }

    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static async Task<IResult> DeleteBook(IServiceManager services, Guid authorId, Guid id)
    {
        await services.BookService.DeleteBookForAuthorAsync(authorId, id);
        return Results.NoContent();
    }
}
