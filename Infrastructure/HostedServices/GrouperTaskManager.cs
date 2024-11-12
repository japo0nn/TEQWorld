using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infrastructure.HostedServices;

public class GrouperTaskManager : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<GrouperTaskManager> _logger;
    private readonly TimeSpan _delay = TimeSpan.FromMinutes(5);

    public GrouperTaskManager(IServiceScopeFactory scopeFactory, ILogger<GrouperTaskManager> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var itemGrouperService =
                        scope.ServiceProvider.GetRequiredService<IGrouperService>();
                    await itemGrouperService.GroupItems();
                    _logger.LogInformation("Товары успешно сгруппированы");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Возникла ошибка при группировке товаров");
            }

            await Task.Delay(_delay, stoppingToken);
        }
    }
}
