namespace ThirdProject.Models
{
    public class Cocktail
    {
        public string Name { get; set; }
        public string Instructions { get; set; }

        public Dictionary<string, int> WordCloud {  get; set; }
    }
}
