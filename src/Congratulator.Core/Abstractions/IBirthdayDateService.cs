using Congratulator.Core.Dtos;

namespace Congratulator.Core.Abstractions
{
    public interface IBirthdayDateService
    {
        BirthdayDateCollectionDto GetBirthdays();
        BirthdayDateCollectionDto GetComingBirthdays();
        BirthdayDateDto GetBirthdayDateById(int id);
        void AddBirthdayDate(AddBirthdayDateDto date);
        void RemoveBirthdayDate(int id);
        void EditBirthdayDate(int id, EditBirthdayDateDto date);
    }
}
