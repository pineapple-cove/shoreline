namespace Shoreline;

public class Worker(ILogger<Worker> logger)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Worker running at: {Timestamp}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken).ConfigureAwait(false);
        }
    }
}