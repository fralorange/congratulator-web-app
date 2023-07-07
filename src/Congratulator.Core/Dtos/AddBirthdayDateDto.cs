namespace Congratulator.Core.Dtos
{
    public class AddBirthdayDateDto
    {
        public required int Id { get; set; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required DateOnly BirthDate { get; init; }
    }
}
