using System.Collections.Generic;

namespace TagsCloudVisualization.WordsExtraction
{
    public interface IWordsFilter
    {
        IEnumerable<string> Filter(IEnumerable<string> words);
    }
}