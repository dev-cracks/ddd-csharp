using Fractalize.Ddd.SharedKernel.Audit;
using Fractalize.Ddd.SharedKernel.Domain;
using Moq;
using Newtonsoft.Json;
using Xunit.Categories;

namespace Fractalize.Ddd.SharedKernel.Test.Domain;

public class DomainEventBaseTest
{
    [Fact]
    [UnitTest]
    public async Task Serialization_WhenSerializeAndDeserialize_SuccessSerialization()
    {
        //Arrange
        var domainEventBase = new DomainEventStub()
        {
            EventId = Guid.NewGuid(),
            OccurredOn = DateTimeOffset.UtcNow,
        };

        //Act && Assert
        var rawEvent = JsonConvert.SerializeObject(domainEventBase);
        var deserializedEvent = JsonConvert.DeserializeObject<AuditedEvent>(rawEvent);
    }
}

public class DomainEventStub : DomainEventBase
{
}