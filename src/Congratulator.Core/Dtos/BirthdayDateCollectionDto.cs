namespace Congratulator.Core.Dtos
{
    public class BirthdayDateCollectionDto
    {
        public required IEnumerable<BirthdayDateDto> Birthdays { get; init; }
    }
}
