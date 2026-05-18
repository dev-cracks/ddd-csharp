namespace Fractalize.Ddd.SharedKernel.Test;

public class DateRangeTest
{
    [Fact]
    public void Constructor_WithStartDateHigherThanEnd_ThrowsArgumentOutOfRangeException()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new DateRange(startDate: DateTimeOffset.Now.AddDays(1), endDate: DateTimeOffset.Now.AddDays(-1)));
    }

    [Fact]
    public void Constructor_WithNullStartDate_ThrowsArgumentOutOfRangeException()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentNullException>(() => new DateRange(startDate: default, endDate: DateTimeOffset.Now.AddDays(-1)));
        Assert.Throws<ArgumentNullException>(() => new DateRange(startDate: DateTimeOffset.Now.AddDays(-1), endDate: default));
    }
}
