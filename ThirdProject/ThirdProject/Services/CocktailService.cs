using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ThirdProject.Models;

namespace ThirdProject.Services
{
    public class CocktailService : ICocktailService
    {
        private readonly HttpClient _httpClient;

        public CocktailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IObservable<List<Cocktail>> GetCocktailsByNameAsync(string name)
        {
            return Observable.StartAsync(async () =>
            {
                var response = await _httpClient.GetStringAsync($"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={name}");
                var jsonDoc = JsonDocument.Parse(response);

                var cocktails = new List<Cocktail>();

                if (jsonDoc.RootElement.TryGetProperty("drinks", out JsonElement drinksElement) && drinksElement.ValueKind == JsonValueKind.Array && drinksElement.GetArrayLength() > 0)
                {
                    foreach (var drink in drinksElement.EnumerateArray())
                    {
                        var cocktail = new Cocktail
                        {
                            Name = drink.GetProperty("strDrink").GetString(),
                            Instructions = drink.GetProperty("strInstructions").GetString()
                        };

                        cocktails.Add(cocktail);
                    }
                }

                return cocktails;
            })
            .ObserveOn(TaskPoolScheduler.Default)
            .Catch<List<Cocktail>, Exception>(ex =>
            {
                Console.WriteLine($":( Error fetching cocktails: {ex.Message}");
                return Observable.Return(new List<Cocktail>());
            });
        }
    }
}
