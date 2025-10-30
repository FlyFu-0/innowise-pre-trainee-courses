using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using task_4_library_manger.ActionFilters;
using task_4_library_manger.Contracts.Service;
using task_4_library_manger.Shared.DTOs;
using task_4_library_manger.Shared.RequestFeatures;

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
    public static async Task<IResult> GetAllAuthors(HttpContext context, IServiceManager services,
        [AsParameters] AuthorParameters authorParameters)
    {
        var result = await services.AuthorService.GetAllAuthorsAsync(authorParameters, false);

        context.Response.Headers["X-Pagination"] = JsonSerializer.Serialize(result.metaData);
        return Results.Ok(result.authors.ToList());
    }

    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static async Task<IResult> GetAuthor(IServiceManager services, Guid id)
    {
        return Results.Ok(await services.AuthorService.GetAuthorAsync(id, false));
    }

    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static async Task<IResult> CreateAuthor(IServiceManager services, AuthorDtoForCreation author)
    {
        var createdAuthor = await services.AuthorService.CreateAuthorAsync(author);
        return Results.Created($"api/authors/{createdAuthor.Id}", createdAuthor);
    }

    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static async Task<IResult> UpdateAuthor(IServiceManager services, Guid id, AuthorDtoForUpdate author)
    {
        await services.AuthorService.UpdateAuthorAsync(id, author);
        return Results.Ok();
    }

    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public static async Task<IResult> DeleteAuthor(IServiceManager services, Guid id)
    {
        await services.AuthorService.DeleteAuthorAsync(id);
        return Results.NoContent();
    }
}
