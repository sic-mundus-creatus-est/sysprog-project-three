using Microsoft.AspNetCore.Mvc;
using ThirdProject.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using ThirdProject.Models;
using System.Reactive.Linq;

namespace ThirdProject.Controllers
{
    public class CocktailController : Controller
    {
        private readonly ICocktailService _cocktailService;
        private readonly IWordCloudService _wordCloudService;
        private readonly CocktailStream _cocktailStream;
        private readonly CocktailObserver _cocktailObserver;

        private readonly Random _random = new Random();

        public CocktailController(ICocktailService cocktailService, IWordCloudService wordCloudService, CocktailStream cocktailStream)
        {
            _cocktailService = cocktailService;
            _wordCloudService = wordCloudService;
            _cocktailStream = cocktailStream;
            _cocktailObserver = new CocktailObserver(wordCloudService);
            _cocktailStream.Subscribe(_cocktailObserver);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string cocktailName)
        {
            try
            {
                var randomColor = GetRandomConsoleColor();

                var searchStartTime = DateTime.Now;
                Console.ForegroundColor = randomColor;
                Console.WriteLine($"[{DateTime.Now:dd-MM-yyyy HH:mm:ss}] -> Search initiated for cocktails with '{cocktailName}' in their name.");

                var cocktails = await _cocktailStream.GetCocktailsAsync(cocktailName)
                    .ToList()
                    .ToTask();

                var searchEndTime = DateTime.Now;
                var processingTime = searchEndTime - searchStartTime;
                Console.ForegroundColor = randomColor;
                Console.WriteLine($"[{DateTime.Now:dd-MM-yyyy HH:mm:ss}] -> Search for '{cocktailName}' completed in {processingTime.TotalSeconds:F3} seconds.");

                if (cocktails == null || cocktails.Count == 0)
                {
                    ViewBag.Message = ":( Cocktail not found.";
                    Console.ForegroundColor = randomColor;
                    Console.WriteLine($"[{DateTime.Now:dd-MM-yyyy HH:mm:ss}] :( No cocktails with '{cocktailName}' in their name found.");

                }
                else
                {
                    ViewBag.Cocktails = cocktails;
                    Console.ForegroundColor = randomColor;
                    if (cocktails.Count > 1)
                    {
                        Console.WriteLine($"[{DateTime.Now:dd-MM-yyyy HH:mm:ss}] -> {cocktails.Count} cocktails retrieved with the word '{cocktailName}' in their name.");
                    }
                    else
                    {
                        Console.WriteLine($"[{DateTime.Now:dd-MM-yyyy HH:mm:ss}] -> 1 cocktail retrieved with the word '{cocktailName}' in their name.");
                    }
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $":( Error fetching cocktails named '{cocktailName}': {ex.Message}";
                return View("Index");
            }
        }

        private ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
