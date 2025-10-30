using task_4_library_manger.Apis;
using task_4_library_manger.Contracts.Service;
using task_4_library_manger.Extensions;

namespace task_4_library_manger;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.ConfigureSqlContext(builder.Configuration);
        builder.Services.AddApplicationServices();
        builder.Services.AddProblemDetails();

        builder.Services.AddAutoMapper(cfg => { }, typeof(Program));

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.ConfigureExceptionHandler();

        app.UseHttpsRedirection();

        app.MapGet("/", () => Results.Redirect("/swagger"));
        app.MapAuthorsApi();
        app.MapBooksApi();

        app.Run();
    }
}
