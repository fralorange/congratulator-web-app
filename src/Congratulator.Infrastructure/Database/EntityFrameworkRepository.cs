﻿using Congratulator.Core.Abstractions.Database;
using Congratulator.Core.Entities;
using Microsoft.Extensions.Configuration;

namespace Congratulator.Infrastructure.Database
{
    public class EntityFrameworkRepository : IBirthdayDateRepository
    {
        private readonly string _connectionString;

        public EntityFrameworkRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default")!;
        }

        public BirthdayDateCollection GetBirthdays()
        {
            using (var db = new BirthdayDateContext(_connectionString))
            {
                return new BirthdayDateCollection()
                {
                    Birthdays = db.Birthdays.ToList()
                };
            }
        }

        public BirthdayDateCollection GetComingBirthdays()
        {
            using (var db = new BirthdayDateContext(_connectionString))
            {
                return new BirthdayDateCollection()
                {
                    Birthdays = db.Birthdays
                        .Where(bd => bd.BirthDate.Day >= DateTime.Now.Day && DateTime.Now.Month == bd.BirthDate.Month)
                        .ToList()
                };
            };
        }

        public BirthdayDate? GetBirthdayDateById(int id)
        {
            using (var db = new BirthdayDateContext(_connectionString))
            {
                return db.Birthdays.FirstOrDefault(bd => bd.Id == id);
            }
        }

        public void AddBirthdayDate(BirthdayDate date)
        {
            using (var db = new BirthdayDateContext(_connectionString))
            {
                db.Birthdays.Add(date);
                db.SaveChanges();
            }
        }

        public void EditBirthdayDate(BirthdayDate date)
        {
            using (var db = new BirthdayDateContext(_connectionString))
            {
                var birthdayDate = db.Birthdays.First(bd => bd.Id == date.Id);
                birthdayDate.FirstName = date.FirstName;
                birthdayDate.LastName = date.LastName;
                birthdayDate.BirthDate = date.BirthDate;

                db.SaveChanges();
            }
        }

        public void RemoveBirthdayDate(BirthdayDate date)
        {
            using (var db = new BirthdayDateContext(_connectionString))
            {
                db.Birthdays.Remove(date);
                db.SaveChanges();
            }
        }
    }
}
