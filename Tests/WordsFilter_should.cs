using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudVisualization.WordsExtraction;

namespace TagsCloudVisualization.Tests
{
    public class WordsFilter_Should
    {
        [TestFixture]
        public class WordsFilter_should
        {
            private WordsFilter wordsFilter;

            [SetUp]
            public void SetUp()
            {
                
                var bannedLines = new []
                {
                    "I have some",
                    "Should be"
                };
                wordsFilter =
                    new WordsFilter(bannedLines);
            }

            [Test]
            public void ShouldCountOnlyWordsWithLengthGreaterOrEqualTo()
            {
                var lines = new List<string>() {"Some words should be skipped"};
                var actualWords = wordsFilter.Filter(lines).ToArray();
                var expectedWords = new []
                {
                    "WORDS",
                    "SKIPPED",
                };
                expectedWords.ShouldBeEquivalentTo(actualWords);
            }

            [Test]
            public void ShouldIgnoreCases()
            {
                var lines = new List<string>() {"test TEST Test"};
                var actualWords = wordsFilter.Filter(lines).ToArray();
                var expectedWords = new []
                {
                    "TEST",
                    "TEST",
                    "TEST",
                };
                expectedWords.ShouldBeEquivalentTo(actualWords);
            }
        }
    }
}