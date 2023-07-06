using Congratulator.Core.Abstractions;
using Congratulator.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Congratulator.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CongratulatorController : ControllerBase
    {
        private readonly IBirthdayDateService _dateService;

        public CongratulatorController(IBirthdayDateService dateService) => _dateService = dateService;

        [HttpGet]
        [Route("api/birthdaydate")]
        public BirthdayDateCollectionDto GetBirthdays()
        {
            return _dateService.GetBirthdays();
        }

        [HttpGet]
        [Route("api/birthdaydate/coming")]
        public BirthdayDateCollectionDto GetComingBirthdays()
        {
            return _dateService.GetComingBirthdays();
        }

        [HttpGet]
        [Route("api/birthdaydate/{id}")]
        public BirthdayDateDto? GetBirthdayDateById(int id)
        {
            return _dateService.GetBirthdayDateById(id);
        }

        [HttpPost]
        [Route("api/birthdaydate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddBirthdayDate([FromBody] AddBirthdayDateDto addBirthdayDateDto)
        {
            _dateService.AddBirthdayDate(addBirthdayDateDto);

            return CreatedAtAction(nameof(GetBirthdayDateById), new { id = addBirthdayDateDto.Id }, addBirthdayDateDto);
        }

        [HttpDelete]
        [Route("api/birthdaydate/{id}")]
        public IActionResult RemoveBirthdayDate(int id)
        {
            bool answer = _dateService.RemoveBirthdayDate(id);
            if (!answer)
                return NotFound();
            return NoContent();
        }

        [HttpPut]
        [Route("api/birthdaydate/{id}")]
        public IActionResult EditBirthdayDate(int id, [FromBody] BirthdayDateDto editedBirthdayDate)
        {
            throw new NotImplementedException();
        }
    }
}
