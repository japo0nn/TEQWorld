using Infrastructure.HostedServices;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfastractureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(
            (sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseSqlite(connectionString, b => b.MigrationsAssembly("Infrastructure"));
            }
        );

        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>()
        );
        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();

        services.AddScoped<IExcelService, ExcelService>();
        services.AddScoped<IGrouperService, GrouperService>();

        services.AddHostedService<GrouperTaskManager>();
        services.AddSingleton(TimeProvider.System);

        return services;
    }
}
