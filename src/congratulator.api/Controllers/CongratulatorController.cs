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
        private readonly IImageService _imageService;

        public CongratulatorController(IBirthdayDateService dateService, IImageService imageService)
        {
            _dateService = dateService;
            _imageService = imageService;
        }

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

        [HttpGet]
        [Route("api/image")]
        public ImageCollectionDto GetImages()
        {
            return _imageService.GetImages();
        }

        [HttpGet]
        [Route("api/image/{id}")]
        public ImageDto? GetImageById(int id)
        {
            return _imageService.GetImageById(id);
        }

        [HttpPost]
        [Route("api/birthdaydate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddBirthdayDate([FromBody] AddBirthdayDateDto addBirthdayDateDto)
        {
            int id = _dateService.AddBirthdayDate(addBirthdayDateDto);

            return CreatedAtAction(nameof(GetBirthdayDateById), new { id }, new { id });
        }

        [HttpPost]
        [Route("api/image")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddImage([FromBody] AddImageDto addImageDto)
        {
            _imageService.AddImage(addImageDto);

            return CreatedAtAction(nameof(GetImageById), new { id = addImageDto.Id }, addImageDto);
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
        public IActionResult EditBirthdayDate(int id, [FromBody] EditBirthdayDateDto editedBirthdayDateDto)
        {
            if (editedBirthdayDateDto == null || id != editedBirthdayDateDto.Id)
                return BadRequest();

            if (GetBirthdayDateById(editedBirthdayDateDto.Id) == null)
                return NotFound();

            _dateService.EditBirthdayDate(editedBirthdayDateDto);

            return NoContent();
        }

        [HttpPut]
        [Route("api/image/{id}")]
        public IActionResult EditImage(int id, [FromBody] EditImageDto editedImageDto)
        {
            if (editedImageDto == null || id != editedImageDto.BirthdayId)
                return BadRequest();

            _imageService.EditImage(editedImageDto);

            return NoContent();
        }
    }
}
