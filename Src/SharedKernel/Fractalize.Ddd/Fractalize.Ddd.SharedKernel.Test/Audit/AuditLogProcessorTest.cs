using Fractalize.Ddd.SharedKernel.Audit;
using Moq;
using Xunit.Categories;

namespace Fractalize.Ddd.SharedKernel.Test.Audit;

public class AuditLogProcessorTest
{
    [Fact]
    [UnitTest]
    public async Task ProcessEventAsync_WithRightConfiguration_CallsGetCurrentTimeAndSaveEventAsync()
    {
        //Arrange
        var IClockStampMock = new Mock<IClockStamp>();
        var IAuditRepositoryMock = new Mock<IAuditRepository>();
        IReadOnlyCollection<AuditedEvent> eventList = new List<AuditedEvent>();
        AuditLogProcessor auditLogProcessor = new AuditLogProcessor(eventList, IClockStampMock.Object, IAuditRepositoryMock.Object);

        //Act
        await auditLogProcessor.ProcessEventAsync(new AuditedEvent()
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTimeOffset.UtcNow,
            UserId = Guid.NewGuid(),
        });

        //Assert
        IClockStampMock.Verify(x => x.GetCurrentTime(), Times.Once);
        IAuditRepositoryMock.Verify(x => x.SaveEventAsync(It.IsAny<AuditedEvent>()), Times.Once);
    }

    [Fact]
    [UnitTest]
    public async Task ProcessEventAsync_GettingTimeFromClockStamp_IsUseAsAuditEventCreationTime()
    {
        //Arrange
        var eventTarget = new AuditedEvent()
        {
            Id = Guid.NewGuid(),
            CreatedAt = default,
            UserId = Guid.NewGuid(),
        };
        DateTimeOffset expectedCreationTime = DateTimeOffset.UtcNow;
        var IClockStampMock = new Mock<IClockStamp>();
        IClockStampMock.Setup(x => x.GetCurrentTime()).Returns(expectedCreationTime);

        var IAuditRepositoryMock = new Mock<IAuditRepository>();
        IReadOnlyCollection<AuditedEvent> eventList = new List<AuditedEvent>();
        AuditLogProcessor auditLogProcessor = new AuditLogProcessor(eventList, IClockStampMock.Object, IAuditRepositoryMock.Object);

        //Act
        await auditLogProcessor.ProcessEventAsync(eventTarget);

        //Assert
        IClockStampMock.Verify(x => x.GetCurrentTime(), Times.Once);
        IAuditRepositoryMock.Verify(x => x.SaveEventAsync(It.Is<AuditedEvent>(ev => ev.CreatedAt == expectedCreationTime)), Times.Once);
    }
}
