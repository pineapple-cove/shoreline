namespace Shoreline.Metrics;

/// <summary>
/// Represents the uptime of the hosting bot.
/// </summary>
public interface IUptime
{
    /// <summary>
    /// Gets the amount of time that the bot has been running.
    /// </summary>
    TimeSpan Value { get; }
}

/// <summary>
/// Represents the runtime of the hosting bot.
/// </summary>
public sealed class Uptime
    : IUptime
{
    private readonly DateTime _startTime = DateTime.UtcNow;

    /// <inheritdoc />
    public TimeSpan Value =>
        DateTime.UtcNow - _startTime;
}