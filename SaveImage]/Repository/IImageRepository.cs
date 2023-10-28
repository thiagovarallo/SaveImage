using SaveImage_.Models;

namespace SaveImage_.Repository
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);

    }
}
