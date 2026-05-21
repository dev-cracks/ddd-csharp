using Fractalize.Ddd.SharedKernel.Audit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using Xunit.Categories;

namespace Fractalize.Ddd.SharedKernel.Test.Audit;

public class AuditLogProcessorConfiguratorTest
{
    [Fact]
    [UnitTest]
    public async Task ProcessEventAsync_WithRightConfiguration_CallsGetCurrentTimeAndSaveEventAsync()
    {
        //Arrange
        var IClockStampMock = new Mock<IClockStamp>();
        var IAuditRepositoryMock = new Mock<IAuditRepository>();

        var services = new ServiceCollection();
        services.ConfigureAuditLogProccesor();
        var provider = services.BuildServiceProvider();
        
        //Act
        var auditService= provider.GetRequiredService<IAuditLogProcessor>();

        //Assert
        Assert.NotNull(auditService);
    }
}
