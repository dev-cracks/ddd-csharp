namespace Fractalize.Ddd.SharedKernel;

public record DateRange : ValueObjectBase
{
    public DateTimeOffset Start { get; set; }
    public DateTimeOffset End { get; set; }

    private DateRange()
    {
    }

    public DateRange(DateTimeOffset startDate, DateTimeOffset endDate)
    {
        if (startDate == default)
        {
            throw new ArgumentNullException(nameof(startDate));
        }

        if (endDate == default)
        {
            throw new ArgumentNullException(nameof(endDate));
        }

        if (endDate <= startDate)
        {
            throw new ArgumentOutOfRangeException($"{nameof(endDate)} should be higher than {startDate}");
        }

        Start = startDate;
        End = endDate;
    }

    public bool Overlaps(DateRange dateRange) =>
        Start < End && End > dateRange.Start;
}