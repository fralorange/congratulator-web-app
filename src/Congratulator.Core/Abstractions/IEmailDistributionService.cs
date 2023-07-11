using Congratulator.Core.Dtos;
using System.Net.Mail;

namespace Congratulator.Core.Abstractions
{
    public interface IEmailDistributionService
    {
        void ScheduleEmailTask(SendBirthdayMailDto sendBirthdayMailDto);
        void SendScheduledEmail(SendBirthdayMailDto sendBirthdayMailDto);
        void CancelEmailTask();
        MailMessage CreateEmail(SendBirthdayMailDto sendBirthdayMailDto);
        void SendEmail(MailMessage mail);
    }
}
