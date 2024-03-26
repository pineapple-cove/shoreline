namespace Shoreline.Providers.Discord.Variables;

/// <summary>
/// Represents an environment variable.
/// </summary>
/// <typeparam name="TSelf">The type of the environment variable.</typeparam>
public interface IEnvironmentVariable<in TSelf>
    where TSelf : IEnvironmentVariable<TSelf>
{
    /// <summary>
    /// Gets the value of the environment variable.
    /// </summary>
    string? Value { get; }
}