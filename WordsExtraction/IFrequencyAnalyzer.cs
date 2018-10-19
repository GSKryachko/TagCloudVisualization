using System.Collections.Generic;

namespace TagsCloudVisualization.WordsExtraction
{
    public interface IFrequencyAnalyzer
    {
        Dictionary<string, int> GetFrequencyDict(IEnumerable<string> lines);
    }
}