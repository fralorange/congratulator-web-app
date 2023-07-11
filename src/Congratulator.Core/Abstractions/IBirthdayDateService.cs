using Congratulator.Core.Dtos;

namespace Congratulator.Core.Abstractions
{
    public interface IBirthdayDateService
    {
        BirthdayDateCollectionDto GetBirthdays();
        BirthdayDateCollectionDto GetComingBirthdays();
        BirthdayDateDto? GetBirthdayDateById(int id);
        int AddBirthdayDate(AddBirthdayDateDto date);
        bool RemoveBirthdayDate(int id);
        void EditBirthdayDate(EditBirthdayDateDto date);
    }
}
