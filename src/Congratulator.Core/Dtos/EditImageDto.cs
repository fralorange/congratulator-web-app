namespace Congratulator.Core.Dtos
{
    public class EditImageDto
    {
        public required int Id { get; init; }
        public required int BirthdayId { get; init; }
        public required byte[] Img { get; init; }
    }
}
