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
        var expectedEventId = Guid.NewGuid();
        var expectedOcurredOn = DateTimeOffset.UtcNow;
        var domainEventBase = new DomainEventStub()
        {
            EventId = expectedEventId,
            OccurredOn = expectedOcurredOn,
        };

        //Act
        var rawEvent = JsonConvert.SerializeObject(domainEventBase);
        var deserializedEvent = JsonConvert.DeserializeObject<DomainEventStub>(rawEvent);

        //Assert
        Assert.Equal(expectedEventId, deserializedEvent!.EventId);
        Assert.Equal(expectedOcurredOn, deserializedEvent!.OccurredOn);
    }
}

public class DomainEventStub : DomainEventBase
{
}