using System.ComponentModel.DataAnnotations;

namespace task_4_library_manger.ActionFilters;

public class ValidationFilter<T> : IEndpointFilter where T : class
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var argument = context.Arguments.OfType<T>().FirstOrDefault();

        if (argument is null)
        {
            return Results.BadRequest($"Object of type {typeof(T).Name} is null.");
        }

        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(argument);

        if (Validator.TryValidateObject(argument, validationContext, validationResults, true))
        {
            return await next(context);
        }

        var errors = validationResults.ToDictionary(
            v => v.MemberNames.FirstOrDefault() ?? "Property",
            v => new[] { v.ErrorMessage ?? "Validation error" }
        );
        return Results.ValidationProblem(errors);

    }
}
