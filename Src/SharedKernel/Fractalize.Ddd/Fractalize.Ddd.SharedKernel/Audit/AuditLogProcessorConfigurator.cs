using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Fractalize.Ddd.SharedKernel.Audit;

public static class AuditLogProcessorConfigurator
{
    /// <summary>
    /// Registra las implementaciones relacionadas con el registro de auditoría en el contenedor de dependencias.
    /// Las dependencias estan mockeadas por no tener la implementación aún.
    /// </summary>
    /// <remarks>Utiliza TryAddScoped y TryAddSingleton para registrar IAuditLogProcessor (AuditLogProcessor),
    /// IClockStamp (ClockStampStub) e IAuditRepository (AuditRepositoryStub).</remarks>
    /// <param name="services">Colección de servicios en la que se añaden las implementaciones de auditoría.</param>
    /// <returns>La misma instancia de IServiceCollection para permitir el encadenamiento de llamadas.</returns>
    public static IServiceCollection ConfigureAuditLogProccesor(this IServiceCollection services)
    {
        services.TryAddScoped<IAuditLogProcessor, AuditLogProcessor>();
        services.TryAddSingleton<IClockStamp, ClockStampStub>();
        services.TryAddScoped<IAuditRepository, AuditRepositoryStub>();

        return services;
    }
}

/// <summary>
/// This is a stub implementation of the IClockStamp interface for testing purposes. It provides a simple implementation of the GetCurrentTime method that returns the current UTC time. This can be useful for unit testing the AuditLogProcessor class without worrying about the complexities of time management or dependencies on external time sources.
/// </summary>
public class ClockStampStub : IClockStamp
{
    public DateTimeOffset GetCurrentTime()
    {
        return DateTimeOffset.UtcNow;
    }
}

/// <summary>
/// This is a stub implementation of the IAuditRepository interface for testing purposes. It provides a simple implementation of the SaveEventAsync method that does nothing, allowing tests to run without needing a real database or storage mechanism. This can be useful for unit testing the AuditLogProcessor class without worrying about the complexities of data persistence.
/// </summary>
public class AuditRepositoryStub : IAuditRepository
{
    public Task SaveEventAsync(AuditedEvent auditedEvent)
    {
        return Task.CompletedTask;
    }
}
