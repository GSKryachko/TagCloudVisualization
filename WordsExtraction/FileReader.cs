using System.Collections.Generic;
using System.IO;

namespace TagsCloudVisualization.WordsExtraction
{
    public class FileReader : IFileReader
    {
        public Result<IEnumerable<string>> ReadFile(string filename)
        {
            if (!filename.EndsWith(".txt"))
                return Result.Fail<IEnumerable<string>>(
                    $"Format of {filename} is unsupported. Supported formats are: txt, doc, docx");
            return Result.Of(() => File.ReadLines(filename));
        }
    }
}