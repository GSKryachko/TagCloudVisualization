using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloudVisualization.Visualization;
using TagsCloudVisualization.WordsExtraction;

namespace TagsCloudVisualization.CloudBuilding
{
    public class CloudBuilder : ICloudBuilder

    {
        private IWordsFilter filter;
        private IFrequencyAnalyzer frequencyAnalyzer;
        private ICloudDrawer cloudDrawer;
        private IDictionaryNormalizer dictionaryNormalizer;
        private ICloudLayouter cloudLayouter;

        public CloudBuilder(IDictionaryNormalizer dictionaryNormalizer, IWordsFilter filter,
            IFrequencyAnalyzer frequencyAnalyzer, ICloudDrawer cloudDrawer, ICloudLayouter cloudLayouter)
        {
            this.dictionaryNormalizer = dictionaryNormalizer;
            this.filter = filter;
            this.frequencyAnalyzer = frequencyAnalyzer;
            this.cloudDrawer = cloudDrawer;
            this.cloudLayouter = cloudLayouter;
        }

        public Bitmap BuildCloud(IEnumerable<string> lines, int count, IDrawingConfig drawingConfig)
        {
            var mostFrequenWords = filter.Filter(lines);
            var frequentWords = frequencyAnalyzer.GetFrequencyDict(mostFrequenWords).Take(count);
            var mostFrequentWords = frequentWords
                .OrderByDescending(x => x.Value)
                .Take(count)
                .ToDictionary(x => x.Key, x => x.Value);
            mostFrequentWords = dictionaryNormalizer.NormalizeDictionary(mostFrequentWords);
            var rects = CalculateRectsForWords(mostFrequentWords, drawingConfig.Font);
            return cloudDrawer.DrawMap(rects, drawingConfig);
        }

        private WordInRect[] CalculateRectsForWords(Dictionary<string, int> words, Font font)
        {
            var graphics = Graphics.FromImage(new Bitmap(1, 1));

            return words.Select(x =>
            {
                font = new Font(font.FontFamily, x.Value);
                var size = graphics.MeasureString(x.Key, font);
                var rect = cloudLayouter.PutNextRectangle(size.ToSize());
                return new WordInRect(x.Key, rect, font);
            }).ToArray();
        }
    }
}