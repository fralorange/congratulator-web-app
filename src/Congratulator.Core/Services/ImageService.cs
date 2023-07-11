using Congratulator.Core.Abstractions;
using Congratulator.Core.Abstractions.Database;
using Congratulator.Core.Dtos;

namespace Congratulator.Core.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _repository;

        public ImageService(IImageRepository repository) => _repository = repository;

        public ImageCollectionDto GetImages()
        {
            return new ImageCollectionDto()
            {
                Images = _repository.GetImages().Images
                .Select(img =>
                {
                    return new ImageDto()
                    {
                        Id = img.Id,
                        BirthdayId = img.BirthdayId,
                        Img = img.Img,
                    };
                })
            };
        }

        public ImageDto? GetImageById(int id)
        {
            var img = _repository.GetImageById(id);

            if (img == null)
                return null;

            return new ImageDto()
            {
                Id = img.Id,
                BirthdayId = img.Id,
                Img = img.Img
            };
        }

        public void AddImage(AddImageDto image)
        {
            _repository.AddImage(new Entities.Image()
            {
                Id = image.Id,
                BirthdayId = image.BirthdayId,
                Img = image.Img,
            });
        }

        public void EditImage(EditImageDto image)
        {
            _repository.EditImage(new Entities.Image()
            {
                Id = image.Id,
                BirthdayId = image.BirthdayId,
                Img = image.Img,
            });
        }
    }
}
