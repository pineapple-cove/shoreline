namespace Shoreline;

/// <summary>
/// Represents a query that can be executed.
/// </summary>
/// <typeparam name="T">The type of result that the query will return.</typeparam>
public interface IQuery<T>
{
    /// <summary>
    /// Executes the query.
    /// </summary>
    /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
    /// <returns>The result of the query.</returns>
    Task<T> Execute(CancellationToken cancellationToken = default);
}