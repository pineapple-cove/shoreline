using Shoreline.Metrics;
using Shoreline.Reflection;

namespace Shoreline.Commands.Statistics;

/// <summary>
/// Represents the uptime of the hosting bot.
/// </summary>
[GlobalCommand("uptime", "Displays the uptime of the bot.")]
public sealed class Uptime(IUptime uptime)
    : IQuery<TimeSpan>
{
    /// <inheritdoc />
    public Task<TimeSpan> Execute(CancellationToken cancellationToken = default) =>
        Task.FromResult(uptime.Value);
}