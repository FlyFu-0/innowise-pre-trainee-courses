using task_4_library_manger.Contracts.Repository;
using task_4_library_manger.Contracts.Service;
using task_4_library_manger.Repository;
using task_4_library_manger.Service;

namespace task_4_library_manger.Extansions;

public static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        // REVIEW: This is done for development ease but shouldn't be here in production
        // builder.Services.AddMigration<CatalogContext, CatalogContextSeed>();

        // builder.Services.AddSingleton<RepositoryContext>();
        var context = new RepositoryContext();
        context.SeedData();

        builder.Services.AddSingleton(context);

        builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
        builder.Services.AddScoped<IServiceManager, ServiceManager>();
    }
}
