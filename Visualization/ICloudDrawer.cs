using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization.Visualization
 {
     public interface ICloudDrawer
     {
         Bitmap DrawMap(IEnumerable<WordInRect> words, IDrawingConfig drawingConfig);
     }
 }