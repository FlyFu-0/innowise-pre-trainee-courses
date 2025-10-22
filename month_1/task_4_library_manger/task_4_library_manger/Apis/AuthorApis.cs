using Microsoft.AspNetCore.Mvc;
using task_4_library_manger.ActionFilters;
using task_4_library_manger.Contracts.Service;
using task_4_library_manger.Shared.DTOs;

namespace task_4_library_manger.Apis;

public static class AuthorApis
{
    public static IEndpointRouteBuilder MapAuthorsApi(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api");

        api.MapGet("/authors", GetAllAuthors)
            .WithName("AllAuthors")
            .WithSummary("Get all authors")
            .WithTags("Authors");
        api.MapGet("/authors/{id:guid}", GetAuthor)
            .WithName("Author")
            .WithSummary("Author's data")
            .WithTags("Authors");

        api.MapPost("/authors", CreateAuthor)
            .WithName("CreateAuthor")
            .WithSummary("Create author")
            .WithTags("Authors")
            .AddEndpointFilter<ValidationFilter<AuthorDtoForCreation>>();
        api.MapPut("/authors/{id:guid}", UpdateAuthor)
            .WithName("UpdateAuthor")
            .WithSummary("Update author")
            .WithTags("Authors");
        api.MapDelete("/authors/{id:guid}", DeleteAuthor)
            .WithName("DeleteAuthor")
            .WithSummary("Delete author")
            .WithTags("Authors");

        return app;
    }

    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static IResult GetAllAuthors(IServiceManager services)
    {
        var authors = services.AuthorService.GetAllAuthors();
        return Results.Ok(authors.ToList());
    }

    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static IResult GetAuthor(IServiceManager services, Guid id)
    {
        return Results.Ok(services.AuthorService.GetAuthor(id));
    }

    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static IResult CreateAuthor(IServiceManager services, AuthorDtoForCreation author)
    {
        services.AuthorService.CreateAuthor(author);
        return Results.Created();
    }

    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static IResult UpdateAuthor(IServiceManager services, Guid id, AuthorDtoForUpdate author)
    {
        return Results.Ok(services.AuthorService.UpdateAuthor(id, author));
    }

    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static IResult DeleteAuthor(IServiceManager services, Guid id)
    {
        services.AuthorService.DeleteAuthor(id);
        return Results.NoContent();
    }
}
