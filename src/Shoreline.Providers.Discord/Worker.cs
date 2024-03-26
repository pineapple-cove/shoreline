using Shoreline.Metrics;

namespace Shoreline.Providers.Discord;

public class Worker(
    IUptime uptime,
    ILogger<Worker> logger)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Uptime: {Uptime}", uptime.Value);

            var iterationDelay = TimeSpan.FromSeconds(3);
            await Task.Delay(iterationDelay, stoppingToken).ConfigureAwait(false);
        }
    }
}