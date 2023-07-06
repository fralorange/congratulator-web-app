namespace Congratulator.Core.Entities
{
    public class BirthdayDateCollection
    {
        public required IEnumerable<BirthdayDate> Birthdays { get; init; }
    }
}
