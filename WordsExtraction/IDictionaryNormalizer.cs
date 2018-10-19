using System.Collections.Generic;

namespace TagsCloudVisualization.WordsExtraction
{
    public interface IDictionaryNormalizer
    {
        Dictionary<string, int> NormalizeDictionary(Dictionary<string, int> dict);
    }
}