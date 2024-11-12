using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Context;

public static class InitialiserExtensions
{
    public static void InitialiseDatabase(this IServiceProvider services)
    {
        using var scope = services.CreateScope();

        var initialiser =
            scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        initialiser.Initialise();
    }
}

public class ApplicationDbContextInitialiser(
    ILogger<ApplicationDbContextInitialiser> logger,
    ApplicationDbContext context
)
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger = logger;
    private readonly ApplicationDbContext _context = context;

    public void Initialise()
    {
        try
        {
            _context.Database.Migrate();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }
}
