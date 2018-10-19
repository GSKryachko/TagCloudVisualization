using System.Drawing;

namespace TagsCloudVisualization.CloudBuilding
{
    public interface ICloudSaver
    {
        Result<None> SaveCloud(Bitmap cloud, string filename, string extension);
    }
}