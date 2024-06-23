namespace ThirdProject.Services
{
    public interface IWordCloudService
    {
        Dictionary<string, int> GenerateWordCloud(string text);
    }
}
