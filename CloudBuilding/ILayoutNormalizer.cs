using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization.CloudBuilding
{
    public interface ILayoutNormalizer
    {
        WordInRect[] ShiftLayout(IEnumerable<WordInRect> words, Rectangle mainRect);
        Rectangle GetMainRect(IEnumerable<WordInRect> words);
    }
}