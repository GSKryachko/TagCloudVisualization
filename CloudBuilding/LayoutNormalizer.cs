using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TagsCloudVisualization.CloudBuilding
{
	public class LayoutNormalizer : ILayoutNormalizer
	{
		public WordInRect[] ShiftLayout(IEnumerable<WordInRect> words, Rectangle mainRect) {
			return words.Select(x => {
				x.Rect.X -= mainRect.X;
				x.Rect.Y -= mainRect.Y;
				return x;
			}).ToArray();
		}

		public Rectangle GetMainRect(IEnumerable<WordInRect> words) {
			return words.Select(x => x.Rect).Aggregate(Rectangle.Union);
		}
	}
}