using System.Drawing;

namespace TagsCloudVisualization.Visualization
{
    public interface IDrawingConfig
    {
        Size Size { get; }
        Font Font { get; }
        SolidBrush GenerateBrush(WordInRect word);
    }
}