using System.ComponentModel.DataAnnotations;

namespace Congratulator.Core.Entities
{
    public class BirthdayDate
    {
        [Range(0, int.MaxValue, ErrorMessage = "Please enter an ID bigger than 0")]
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateOnly BirthDate { get; set; }
    }
}
