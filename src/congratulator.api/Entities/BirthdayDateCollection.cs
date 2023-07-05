namespace Congratulator.Api.Entities
{
    public class BirthdayDateCollection
    {
        public required IEnumerable<BirthdayDate> Birthdays { get; init; }
    }
}
