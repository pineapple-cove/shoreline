namespace Shoreline.Reflection;

/// <summary>
/// Marks a class as a classic command.
/// </summary>
/// <param name="prefix">Specifies the prefix of the command.</param>
/// <param name="name">Specifies the name of the command.</param>
/// <param name="description">Describes what the command is for.</param>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class ClassicCommandAttribute(
    char prefix,
    string name,
    string description)
    : Attribute
{
    /// <summary>
    /// Gets the prefix of the command.
    /// </summary>
    public char Prefix { get; } = prefix;

    /// <summary>
    /// Gets the name of the command.
    /// </summary>
    public string Name { get; } = name;

    /// <summary>
    /// Gets the description of the command.
    /// </summary>
    public string Description { get; } = description;
}