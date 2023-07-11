using Congratulator.Core.Entities;

namespace Congratulator.Core.Abstractions.Database
{
    public interface IImageRepository
    {
        ImageCollection GetImages();
        Image? GetImageById(int id);
        void AddImage(Image image);
        void EditImage(Image image);
    }
}
