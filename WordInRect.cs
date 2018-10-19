using System.Drawing;

namespace TagsCloudVisualization
{
	public class WordInRect
	{
		public string Word;
		public Rectangle Rect;
		public Font Font;

		public WordInRect(string word, Rectangle rect, Font font)
		{
			Word = word;
			Rect = rect;
			Font = font;
		}
	}
}