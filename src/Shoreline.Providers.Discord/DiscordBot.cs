using System.Diagnostics.CodeAnalysis;

using Discord;
using Discord.WebSocket;

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
    IConfiguration configuration,
    IHostApplicationLifetime lifetime) : IHostedService
{
    /// <inheritdoc />
    public async Task StartAsync(
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Attempting to connect to Discord.");
        var token = configuration["DiscordToken"];
        if (string.IsNullOrWhiteSpace(token))
        {
            logger.LogError("Discord token is missing.");
            lifetime.StopApplication();
            return;
        }

        client.Log += LogAsync;
        await client.LoginAsync(TokenType.Bot, token).ConfigureAwait(false);
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