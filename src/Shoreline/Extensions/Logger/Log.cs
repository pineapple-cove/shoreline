using Discord;

namespace Shoreline.Providers.Discord;

/// <summary>
/// Defines extension methods for logging.
/// </summary>
public static class LoggerExtensions
{
    /// <summary>
    /// Logs a message.
    /// </summary>
    /// <param name="logger">The logger to use.</param>
    /// <param name="message">The message to log.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="logger"/> is <see langword="null"/> -or-
    ///     <paramref name="message"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="message"/>.<see cref="LogMessage.Message"/> is <see langword="null"/>, empty, or whitespace.
    /// </exception>
    public static void Log(
        this ILogger logger,
        LogMessage message)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        ArgumentException.ThrowIfNullOrWhiteSpace(message.Message, nameof(message.Message));

        var level = message.Severity.GetLogLevel();
        logger.Log(level, message.Exception, message.Message);
    }
}