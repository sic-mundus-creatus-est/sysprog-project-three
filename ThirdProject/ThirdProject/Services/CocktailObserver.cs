using System;
using System.Collections.Generic;
using ThirdProject.Models;

namespace ThirdProject.Services
{
    public class CocktailObserver : IObserver<Cocktail>
    {
        private readonly IWordCloudService _wordCloudService;

        public CocktailObserver(IWordCloudService wordCloudService)
        {
            _wordCloudService = wordCloudService;
        }

        public void OnNext(Cocktail cocktail)
        {
            var wordCloud = _wordCloudService.GenerateWordCloud(cocktail.Instructions);

            cocktail.WordCloud = wordCloud;

            //Console.WriteLine($"Generated word cloud for cocktail '{cocktail.Name}'.");
            //Console.Out.Flush();
        }

        public void OnCompleted()
        {
            //Console.WriteLine("CocktailObserver completed observing.");
            //Console.Out.Flush();
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($":( CocktailObserver encountered an error: {error.Message}");
            Console.Out.Flush();
        }

    }
}
