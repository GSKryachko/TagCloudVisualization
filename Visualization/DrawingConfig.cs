using System;
using System.Drawing;
using ColorConverter = System.Windows.Media.ColorConverter;

namespace TagsCloudVisualization.Visualization
{
    public class DrawingConfig : IDrawingConfig
    {
        public Font Font { get; set; }
        public Size Size { get; set; }
        private SolidBrush Brush;

        public DrawingConfig(string fontName, string brushColor, Size size)
        {
            var color = GetColorByName(brushColor);

            Font = new Font(fontName, 10);
            Brush = new SolidBrush(color);
            Size = size;
        }

        public SolidBrush GenerateBrush(WordInRect wordInRect)
        {
            return Brush;
        }


        public static Color GetColorByName(string name)
        {
            var convertationResult = Result.Of(() =>
                (System.Windows.Media.Color) ColorConverter.ConvertFromString(name));

            if (!convertationResult.IsSuccess)
            {
                Console.WriteLine($"{name} is not a valid color name. Magenta will be used instead");
                return Color.Magenta;
            }
            var color = convertationResult.Value;
            return Color.FromArgb(color.A, color.R, color.G,
                color.B);
        }
    }
}