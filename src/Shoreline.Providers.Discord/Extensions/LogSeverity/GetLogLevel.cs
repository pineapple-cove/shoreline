using Discord;

namespace Shoreline.Providers.Discord;

/// <summary>
/// Defines extension methods for <see cref="LogSeverity"/>.
/// </summary>
public static class LogSeverityExtensions
{
    /// <summary>
    /// Converts a <see cref="LogSeverity"/> to a <see cref="LogLevel"/>.
    /// </summary>
    /// <param name="source">The source to convert.</param>
    /// <returns>The converted <see cref="LogLevel"/>.</returns>
    public static LogLevel GetLogLevel(
        this LogSeverity source) =>
        source switch
        {
            LogSeverity.Critical => LogLevel.Critical,
            LogSeverity.Error => LogLevel.Error,
            LogSeverity.Warning => LogLevel.Warning,
            LogSeverity.Info => LogLevel.Information,
            LogSeverity.Verbose => LogLevel.Debug,
            LogSeverity.Debug => LogLevel.Trace,
            _ => LogLevel.Trace
        };
}