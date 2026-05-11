namespace Fractalize.Ddd.SharedKernel;

/// <summary>
/// TODO
/// </summary>
public abstract class DomainEventBase
{
    public required string Name { get; set; }

    /// <summary>
    /// DateTimeOffset ISO 8601
    /// </summary>
    public required DateTimeOffset Date { get; set; }
}
