using System.Collections.Generic;
using System.Linq;

namespace TagsCloudVisualization.WordsExtraction
{
    public class WordsFilter : IWordsFilter
    {
        private static readonly char[] BannedChars = new char[]
        {
            '.',
            ',',
            '!',
            '?',
            '\'',
            ':',
            '\"'
        };

        private static string[] bannedWords;

        public WordsFilter(IEnumerable<string> linesOfBannedWords)
        {
            bannedWords = linesOfBannedWords.SelectMany(x => x.Split(' '))
                .Select(x => x.ToUpper()).ToArray();
        }

        public IEnumerable<string> Filter(IEnumerable<string> words)
        {
            return words.SelectMany(x => x.Split(' ')).Select(x => x.Trim(BannedChars).ToUpper())
                .Where(x => !bannedWords.Contains(x));
        }
    }
}