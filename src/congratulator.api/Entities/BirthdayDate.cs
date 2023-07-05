namespace Congratulator.Api.Entities
{
    public class BirthdayDate
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateOnly BirthDate { get; set; }
    }
}
