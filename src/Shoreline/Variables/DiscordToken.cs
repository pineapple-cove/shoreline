namespace Shoreline.Providers.Discord.Variables;

/// <summary>
/// Represents the Discord token.
/// </summary>
/// <param name="configuration">The configuration for the application.</param>
public sealed class DiscordToken(IConfiguration configuration)
    : IEnvironmentVariable<DiscordToken>
{
    /// <inheritdoc />
    public string? Value { get; } = configuration[nameof(DiscordToken)];
}