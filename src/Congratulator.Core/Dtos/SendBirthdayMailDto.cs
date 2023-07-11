namespace Congratulator.Core.Dtos
{
    public class SendBirthdayMailDto
    {
        public required string Recipient { get; init; }
        public required string Subject { get; init; }
    }
}
