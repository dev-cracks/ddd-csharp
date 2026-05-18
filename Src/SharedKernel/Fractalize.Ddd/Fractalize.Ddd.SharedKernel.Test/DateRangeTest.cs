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
        var startDateDefaultException = Assert.Throws<ArgumentNullException>(() => new DateRange(startDate: default, endDate: DateTimeOffset.Now.AddDays(-1)));
        Assert.Equal("startDate", startDateDefaultException.ParamName);

        var endDateDefaultException = Assert.Throws<ArgumentNullException>(() => new DateRange(startDate: DateTimeOffset.Now.AddDays(-1), endDate: default));
        Assert.Equal("endDate", endDateDefaultException.ParamName);
    }
}
