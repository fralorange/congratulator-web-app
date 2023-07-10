using Congratulator.Core.Dtos;

namespace Congratulator.Core.Abstractions
{
    public interface IImageService
    {
        ImageCollectionDto GetImages();
        ImageDto? GetImageById(int id);
        void AddImage(AddImageDto image);
        void EditImage(EditImageDto image);
    }
}
