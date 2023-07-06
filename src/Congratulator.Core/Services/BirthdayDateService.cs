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

        public BirthdayDateDto GetBirthdayDateById(int id)
        {
            var date = _repository.GetBirthdayDateById(id);

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
            var newDate = new BirthdayDate()
            {
                Id = date.Id,
                FirstName = date.FirstName,
                LastName = date.LastName,
                BirthDate = date.BirthDate
            };

            _repository.AddBirthdayDate(newDate);
        }

        public void EditBirthdayDate(int id, EditBirthdayDateDto date)
        {
            throw new NotImplementedException();
        }


        public void RemoveBirthdayDate(int id)
        {
            throw new NotImplementedException();
        }
    }
}
