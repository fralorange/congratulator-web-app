using Congratulator.Core.Abstractions;
using Congratulator.Core.Abstractions.Database;
using Congratulator.Core.Dtos;
using Congratulator.Core.Entities;

namespace Congratulator.Core.Services
{
    public class BirthdayDateService : IBirthdayDateService
    {
        private readonly IBirthdayDateRepository _repository;

        public BirthdayDateService(IBirthdayDateRepository repository) => _repository = repository;

        public BirthdayDateCollectionDto GetBirthdays()
        {
            return new BirthdayDateCollectionDto()
            {
                Birthdays = _repository.GetBirthdays().Birthdays
                    .Select(bd =>
                    {
                        return new BirthdayDateDto()
                        {
                            Id = bd.Id,
                            FirstName = bd.FirstName,
                            LastName = bd.LastName,
                            BirthDate = bd.BirthDate
                        };
                    })
                    .ToList()
            };
        }

        public BirthdayDateCollectionDto GetComingBirthdays()
        {
            return new BirthdayDateCollectionDto()
            {
                Birthdays = _repository.GetComingBirthdays().Birthdays
                    .Select(bd =>
                    {
                        return new BirthdayDateDto()
                        {
                            Id = bd.Id,
                            FirstName = bd.FirstName,
                            LastName = bd.LastName,
                            BirthDate = bd.BirthDate
                        };
                    })
                    .ToList()
            };
        }

        public BirthdayDateDto? GetBirthdayDateById(int id)
        {
            var date = _repository.GetBirthdayDateById(id);

            if (date == null)
                return null;

            return new BirthdayDateDto()
            {
                Id = date.Id,
                FirstName = date.FirstName,
                LastName = date.LastName,
                BirthDate = date.BirthDate
            };
        }

        public void AddBirthdayDate(AddBirthdayDateDto date)
        {
            if (_repository.GetBirthdays().Birthdays.Any(bd => bd.Id == date.Id))
                return;
            date.Id = GetBirthdays().Birthdays.Max(bd => bd.Id) + 1;
            var newDate = new BirthdayDate()
            {
                Id = date.Id,
                FirstName = date.FirstName,
                LastName = date.LastName,
                BirthDate = date.BirthDate
            };

            _repository.AddBirthdayDate(newDate);
        }

        public void EditBirthdayDate(EditBirthdayDateDto date)
        {
            var updatedDate = new BirthdayDate()
            {
                Id = date.Id,
                FirstName = date.FirstName,
                LastName = date.LastName,
                BirthDate = date.BirthDate
            };

            _repository.EditBirthdayDate(updatedDate);
        }


        public bool RemoveBirthdayDate(int id)
        {
            var dateDto = GetBirthdayDateById(id);

            if (dateDto == null)
                return false;

            var date = new BirthdayDate()
            {
                Id = dateDto.Id,
                FirstName = dateDto.FirstName,
                LastName = dateDto.LastName,
                BirthDate = dateDto.BirthDate
            };

            _repository.RemoveBirthdayDate(date);
            return true;
        }
    }
}
