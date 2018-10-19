using System.Drawing;

namespace TagsCloudVisualization.CloudBuilding
{
    public interface ICloudLayouter
    {
        Rectangle PutNextRectangle(Size size);
    }
}