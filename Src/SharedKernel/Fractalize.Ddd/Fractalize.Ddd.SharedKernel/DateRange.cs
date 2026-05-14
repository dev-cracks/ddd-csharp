namespace Fractalize.Ddd.SharedKernel;

public record DateRange : ValueObjectBase
{
    public DateTimeOffset Start { get; set; }
    public DateTimeOffset End { get; set; }

    public DateRange(DateTimeOffset startDate, DateTimeOffset endDate)
    {
        if(endDate <= startDate)
        {
            throw new ArgumentOutOfRangeException($"{nameof(endDate)} should be higher than {startDate}");
        }
        Start = startDate;
        End = endDate;
    }

    private DateRange()
    {
    }

    public bool Overlaps(DateRange dateRange) =>
        Start < End && End > dateRange.Start;
}