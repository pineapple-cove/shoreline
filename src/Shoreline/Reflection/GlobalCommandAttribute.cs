namespace Shoreline.Reflection;

/// <summary>
/// Marks a class as a slash command.
/// </summary>
/// <param name="name">Specifies the name of the command.</param>
/// <param name="description">Describes what the command is for.</param>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class GlobalCommandAttribute(
    string name,
    string description)
    : Attribute
{
    /// <summary>
    /// Gets the name of the command.
    /// </summary>
    public string Name { get; } = name;
    
    /// <summary>
    /// Gets the description of the command.
    /// </summary>
    public string Description { get; } = description;
}