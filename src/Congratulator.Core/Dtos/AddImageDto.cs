namespace Congratulator.Core.Dtos
{
    public class AddImageDto
    {
        public required int Id { get; set; }
        public required int BirthdayId { get; init; }
        public required byte[] Img { get; init; }
    }
}
