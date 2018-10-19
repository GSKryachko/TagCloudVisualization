using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudVisualization.WordsExtraction;

namespace TagsCloudVisualization.Tests
{
	public class DictionaryNormalzer_should
	{
		[TestFixture]
		public class DictionaryNormalzer_Should
		{
			[Test]
			public void NormalizeDictionary()
			{
				var dict = new Dictionary<string, int>()
				{
					{"Hundred", 100},
					{"Fifty", 50},
					{"Ten", 10},
					{"Five", 5},
					{"Zero", 0}
				};

				var expectedDict = new Dictionary<string, int>()
				{
					{"Hundred", 100},
					{"Fifty", 55},
					{"Ten", 19},
					{"Five", 14},
					{"Zero", 10}
				};

				var dictionaryNormalizer = new DictionaryNormalizer();
				var actualDict = dictionaryNormalizer.NormalizeDictionary(dict);
				actualDict.ShouldBeEquivalentTo(expectedDict);
			}
		}
	}
}