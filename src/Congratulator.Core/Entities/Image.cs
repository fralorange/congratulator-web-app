using System.ComponentModel.DataAnnotations;

namespace Congratulator.Core.Entities
{
    public class Image
    {
        [Range(0, int.MaxValue, ErrorMessage = "Please enter an ID bigger than 0")]
        public required int Id { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter an ID bigger than 0")]
        public required int BirthdayId { get; set; }
        public required byte[] Img { get; set; }
    }
}
