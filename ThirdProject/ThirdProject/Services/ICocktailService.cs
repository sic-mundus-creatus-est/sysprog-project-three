using ThirdProject.Models;

namespace ThirdProject.Services
{
    public interface ICocktailService
    {
        IObservable<List<Cocktail>> GetCocktailsByNameAsync(string name);
    }
}
