using Congratulator.Core.Abstractions;
using Congratulator.Core.Dtos;
using Hangfire;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Congratulator.Core.Services
{
    public class EmailDistributionService : IEmailDistributionService
    {
        private readonly string _login;
        private readonly string _password;
        private readonly IBirthdayDateService _birthdayDateService;
        private readonly IRecurringJobManager _recurringJobManager;

        public EmailDistributionService(IConfiguration configuration, IBirthdayDateService birthdayDateService, IRecurringJobManager recurringJobManager)
        {
            _login = configuration["EmailAuth:Login"]!;
            _password = configuration["EmailAuth:Password"]!;
            _birthdayDateService = birthdayDateService;
            _recurringJobManager = recurringJobManager;
        }

        public void ScheduleEmailTask(SendBirthdayMailDto sendBirthdayMailDto)
        {
            _recurringJobManager.AddOrUpdate(
                "EmailTask",
                () => SendScheduledEmail(sendBirthdayMailDto),
                "0 12 * * *",
                new RecurringJobOptions
                {
                    TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time"),
                });
        }

        public void SendScheduledEmail(SendBirthdayMailDto sendBirthdayMailDto)
        {
            var email = CreateEmail(sendBirthdayMailDto);
            SendEmail(email);
        }

        public void CancelEmailTask()
        {
            _recurringJobManager.RemoveIfExists("EmailTask");
        }

        public MailMessage CreateEmail(SendBirthdayMailDto sendBirthdayMailDto)
        {
            MailMessage mail = new()
            {
                From = new MailAddress(_login),
                Subject = sendBirthdayMailDto.Subject,
            };
            mail.To.Add(new MailAddress(sendBirthdayMailDto.Recipient));

            var comingBirthdays = _birthdayDateService.GetComingBirthdays();
            var msg = string.Join("\n", comingBirthdays.Birthdays.Select(bd => $"{bd.FirstName} {bd.LastName} - {bd.BirthDate}"));

            mail.Body = msg;

            return mail;
        }

        public void SendEmail(MailMessage mail)
        {
            using (mail)
            {
                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(_login, _password);
                    smtp.EnableSsl = true;

                    smtp.Send(mail);
                }
            }
        }
    }
}
