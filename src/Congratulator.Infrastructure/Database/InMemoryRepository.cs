using Congratulator.Core.Entities;
using Congratulator.Core.Abstractions.Database;

namespace Congratulator.Infrastructure.Database
{
    public class InMemoryRepository : IBirthdayDateRepository
    {
        private readonly List<BirthdayDate> _birthdayDateCollection;

        public InMemoryRepository()
        {
            _birthdayDateCollection = new List<BirthdayDate>()
            {
                new BirthdayDate()
                {
                    Id = 1,
                    FirstName = "Alexander",
                    LastName = "Makedonsky",
                    BirthDate = new DateOnly(356, 10, 6)
                },
                new BirthdayDate()
                {
                    Id = 2,
                    FirstName = "Alexander",
                    LastName = "Pushkin",
                    BirthDate = new DateOnly(1799, 6, 6)
                },
                new BirthdayDate()
                {
                    Id = 3,
                    FirstName = "Sergey",
                    LastName = "Esenin",
                    BirthDate = new DateOnly(1895, 10, 3)
                },
                new BirthdayDate()
                {
                    Id = 4,
                    FirstName = "Evgeniy",
                    LastName = "Vilnuis",
                    BirthDate = new DateOnly(2001, 7, 8)
                },
                new BirthdayDate()
                {
                    Id = 5,
                    FirstName = "Alice",
                    LastName = "Selezneva",
                    BirthDate = new DateOnly(2078, 7, 10)
                }
                
            };
        }

        public BirthdayDateCollection GetBirthdays()
        {
            return new BirthdayDateCollection()
            {
                Birthdays = _birthdayDateCollection
            };
        }

        public BirthdayDateCollection GetComingBirthdays()
        {
            return new BirthdayDateCollection()
            {
                Birthdays = _birthdayDateCollection
                    .Where(bd => bd.BirthDate.Day >= DateTime.Now.Day && DateTime.Now.Month == bd.BirthDate.Month)
            };
        }

        public BirthdayDate? GetBirthdayDateById(int id)
        {
            return _birthdayDateCollection.FirstOrDefault(bd => bd.Id == id);
        }

        public void AddBirthdayDate(BirthdayDate date)
        {
            _birthdayDateCollection.Add(date);
        }

        public void EditBirthdayDate(BirthdayDate date)
        {
            throw new NotImplementedException();
        }


        public void RemoveBirthdayDate(BirthdayDate date)
        {
            throw new NotImplementedException();
        }
    }
}
