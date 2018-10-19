using System.Collections.Generic;
using System.Linq;

namespace TagsCloudVisualization.WordsExtraction
{
	public class DictionaryNormalizer : IDictionaryNormalizer
	{
		private const int OldRange = 100;
		private const int NewRange = 90;
		private const int NewMin = 10;

		public Dictionary<string, int> NormalizeDictionary(Dictionary<string, int> dict) {
			var ratio = 100.0 / dict.Values.Max();
			var normalizedList = dict.ToDictionary(x => x.Key, x => ConvertValue((int)(x.Value * ratio)));
			return normalizedList;
		}

		private static int ConvertValue(int value) {
			return value  * NewRange / OldRange + NewMin;
		}
	}
}