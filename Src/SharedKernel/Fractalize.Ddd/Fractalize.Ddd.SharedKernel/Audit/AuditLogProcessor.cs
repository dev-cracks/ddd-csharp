namespace Fractalize.Ddd.SharedKernel.Audit;

public class AuditLogProcessor(
    IReadOnlyCollection<AuditedEvent> eventList, 
    IClockStamp clockStamp, 
    IAuditRepository auditRepository)
{
    public async Task ProcessEventAsync(AuditedEvent auditedEvent)
    {
        // Process the audited event (e.g., log it, store it in a database, etc.)
        Console.WriteLine($"Processing event: Id={auditedEvent.Id}, Date={auditedEvent.CreatedAt}, UserId={auditedEvent.UserId}");

        auditedEvent.CreatedAt = clockStamp.GetCurrentTime();
        await auditRepository.SaveEventAsync(auditedEvent);
    }
}

public record AuditedEvent 
{
    public required Guid Id { get; set; }

    public required DateTimeOffset CreatedAt { get; set; }

    public required Guid UserId { get; set; }
}
