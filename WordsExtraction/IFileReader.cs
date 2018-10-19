using System.Collections.Generic;

namespace TagsCloudVisualization.WordsExtraction
{
    public interface IFileReader
    {
        Result<IEnumerable<string>> ReadFile(string filename);
    }
}