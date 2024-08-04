using Discord;
using Discord.WebSocket;

using Shoreline.Providers.Discord.Variables;

using System.Diagnostics.CodeAnalysis;

namespace Shoreline.Providers.Discord;

/// <summary>
/// Represents the Discord bot.
/// </summary>
/// <param name="client">The client for interacting with Discord.</param>
/// <param name="logger">The logger for the bot.</param>
[SuppressMessage("Design",
    "CA1812: Avoid uninstantiated internal classes",
    Justification = "Instantiated through dependency injection.")]
internal sealed class DiscordBot(
    DiscordSocketClient client,
    ILogger<DiscordBot> logger,
    IEnvironmentVariable<DiscordToken> token,
    IHostApplicationLifetime lifetime) : IHostedService
{
    public readonly string _sample = "sample";

    /// <inheritdoc />
    public async Task StartAsync(
        CancellationToken cancellationToken)
    {
        Console.WriteLine(_sample);
        logger.LogInformation("Attempting to connect to Discord.");
        if (string.IsNullOrWhiteSpace(token.Value))
        {
            logger.LogError("Discord token is missing.");
            lifetime.StopApplication();
            return;
        }

        client.Log += LogAsync;
        await client.LoginAsync(TokenType.Bot, token.Value).ConfigureAwait(false);
        await client.StartAsync().ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task StopAsync(
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Attempting to disconnect from Discord.");
        await client.LogoutAsync().ConfigureAwait(false);
        await client.StopAsync().ConfigureAwait(false);

        client.Log -= LogAsync;
    }

    private Task LogAsync(
        LogMessage message)
    {
        logger.Log(message);
        return Task.CompletedTask;
    }
}