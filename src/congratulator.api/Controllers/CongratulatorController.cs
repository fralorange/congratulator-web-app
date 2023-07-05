using Congratulator.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace congratulator.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CongratulatorController : ControllerBase
    {
        [HttpGet]
        [Route("api/all")]
        public BirthdayDateCollection GetBirthdays()
        {
            return new BirthdayDateCollection()
            {
                Birthdays = new[]
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
                    }
                }
            };
        }

        [HttpGet]
        [Route("api/coming")]
        public BirthdayDateCollection GetComingBirthdays()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("api/add")]
        public IActionResult AddBirthdayDate([FromBody] BirthdayDate birthdayDate)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("api/delete/{id}")]
        public IActionResult RemoveBirthdayDate(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("api/edit/{id}")]
        public IActionResult EditBirthdayDate(int id, [FromBody] BirthdayDate editedBirthdayDate)
        {
            throw new NotImplementedException();
        }
    }
}
