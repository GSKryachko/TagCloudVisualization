using System.Collections.Generic;
using System.Drawing;
using TagsCloudVisualization.Visualization;

namespace TagsCloudVisualization.CloudBuilding
{
    public interface ICloudBuilder
    {
         Bitmap BuildCloud(IEnumerable<string> lines, int count, IDrawingConfig drawingConfig);
    }
}