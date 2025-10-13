using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using task_3_tasks_manager;
using task_3_tasks_manager.Models;
using task_3_tasks_manager.Repositories;
using task_3_tasks_manager.Contracts;
using task_3_tasks_manager.Migrations;

class Program
{
    static async Task Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables()
            .Build();
        
        await using var serviceProvider = CreateServices(configuration);
        using var scope = serviceProvider.CreateScope();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        
        try
        {
            Console.WriteLine("Database migrator started");
            UpdateDatabase(scope.ServiceProvider);
            Console.WriteLine("Database migrator ended");
            
            var taskRepository = scope.ServiceProvider.GetRequiredService<IRepository<TaskItem>>();
            var app = new Application(taskRepository);
            app.Run();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while running the application.");
            throw;
        }
    }
    
    private static ServiceProvider CreateServices(IConfiguration configuration)
    {
        var defaultConnection = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(defaultConnection))
        {
            throw new InvalidOperationException("DefaultConnection string is not properly configured.");
        }

        var services = new ServiceCollection();

        services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddSqlServer2016()
                .WithGlobalConnectionString(defaultConnection)
                .ScanIn(typeof(Program).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole());
        
        services.AddSingleton(defaultConnection);
        services.AddTransient<IDbConnectionFactory, SqlConnectionFactory>(sp =>
            new SqlConnectionFactory(sp.GetRequiredService<string>()));
        
        services.AddTransient<IRepository<TaskItem>, TasksRepository>();
        
        services.AddLogging(builder => builder
            .AddConsole()
            .SetMinimumLevel(LogLevel.Information));
        
        return services.BuildServiceProvider();
    }
    
    private static void UpdateDatabase(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

        runner.MigrateUp();
    }
}