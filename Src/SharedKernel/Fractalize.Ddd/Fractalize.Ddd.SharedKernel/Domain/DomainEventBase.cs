namespace Fractalize.Ddd.SharedKernel.Domain;

/// <summary>
///  Domain events are a powerful way to capture and communicate significant occurrences within a domain. They represent something that has happened in the past and can be used to trigger actions, update other parts of the system, or integrate with external systems. By defining a base class for domain events, we can ensure consistency and provide a common structure for all events in our application.
/// </summary>
public abstract class DomainEventBase
{
    /// <summary>
    /// Identificador único del evento, representado como Guid.
    /// </summary>
    /// <remarks>Propiedad marcada con required; debe establecerse al inicializar la
    /// instancia.</remarks>
    public required Guid EventId { get; init; }

    /// <summary>
    /// DateTimeOffset ISO 8601
    /// </summary>
    public required DateTimeOffset OccurredOn { get; init; }
}
