using Congratulator.Core.Entities;

namespace Congratulator.Core.Abstractions.Database
{
    public interface IBirthdayDateRepository
    {
        BirthdayDateCollection GetBirthdays();
        BirthdayDateCollection GetComingBirthdays();
        BirthdayDate? GetBirthdayDateById(int id);
        void AddBirthdayDate(BirthdayDate date);
        void RemoveBirthdayDate(BirthdayDate date);
        void EditBirthdayDate(BirthdayDate date);
    }
}
