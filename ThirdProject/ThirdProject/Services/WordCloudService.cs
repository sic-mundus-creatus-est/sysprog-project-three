using System.Text.RegularExpressions;

namespace ThirdProject.Services
{
    public class WordCloudService : IWordCloudService
    {
        public Dictionary<string, int> GenerateWordCloud(string instructions)
        {
            var words = Regex.Split(instructions, @"\W+")
                             .Where(w => !string.IsNullOrWhiteSpace(w))
                             .Select(w => w.ToLowerInvariant());

            var wordCounts = words.GroupBy(w => w)
                                  .ToDictionary(g => g.Key, g => g.Count());

            //Console.WriteLine($"Generated word cloud with {wordCounts.Count} words.");
            return wordCounts;
        }
    }
}
