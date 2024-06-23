using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Reactive.Disposables;
using ThirdProject.Models;

namespace ThirdProject.Services
{
    public class CocktailStream : IObservable<Cocktail>, IDisposable
    {
        private readonly ISubject<Cocktail> _subject;
        private readonly ICocktailService _cocktailService;
        private readonly CompositeDisposable _disposables;
        private bool _isDisposed;

        public CocktailStream(ICocktailService cocktailService)
        {
            _subject = new Subject<Cocktail>();
            _cocktailService = cocktailService;
            _disposables = new CompositeDisposable();
        }

        public IObservable<Cocktail> GetCocktailsAsync(string name)
        {
            var observable = _cocktailService.GetCocktailsByNameAsync(name)
                .SelectMany(cocktails => cocktails.ToObservable())
                .ObserveOn(TaskPoolScheduler.Default)
                .Do(cocktail => _subject.OnNext(cocktail))
                .Catch<Cocktail, Exception>(ex =>
                {
                    Console.WriteLine($":( Error processing cocktail: {ex.Message}");
                    return Observable.Empty<Cocktail>();
                })
                .Finally(() => _subject.OnCompleted());

            return observable;
        }

        public IDisposable Subscribe(IObserver<Cocktail> observer)
        {
            var subscription = _subject.Subscribe(observer);
            _disposables.Add(subscription);
            return subscription;
        }

        public void Publish(Cocktail cocktail)
        {
            if (!_isDisposed)
            {
                _subject.OnNext(cocktail);
            }
        }

        public void Complete()
        {
            if (!_isDisposed)
            {
                _subject.OnCompleted();
            }
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _disposables.Dispose();
                _isDisposed = true;
            }
        }
    }
}
