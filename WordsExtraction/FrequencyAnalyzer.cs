using System.Collections.Generic;
using System.Linq;

namespace TagsCloudVisualization.WordsExtraction
{
	public class FrequencyAnalyzer : IFrequencyAnalyzer
	{
		public Dictionary<string, int> GetFrequencyDict(IEnumerable<string> lines)
		{
			return
				lines.GroupBy(x => x)
					.ToDictionary(k => k.Key, v => v.Count());
		}
	}
}