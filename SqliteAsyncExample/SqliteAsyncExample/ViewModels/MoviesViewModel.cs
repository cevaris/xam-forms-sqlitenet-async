using SqliteAsyncExample.Services;
using MvvmHelpers;
using Xamarin.Forms;
using SqliteAsyncExample.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SqliteAsyncExample.ViewModels
{
    public class MoviesViewModel : BaseViewModel
    {
        private static IMoviesService MoviesService { get; } = DependencyService.Get<IMoviesService>();

        public MoviesViewModel(Page page)
        {
            page.Appearing += async (sender, e) => {

                await AddMovies();

                await BindMovies();
            };
        }

        private IList<Movie> _movies;
        public IList<Movie> Movies
        {
            get { return _movies; }
            private set { SetProperty(ref _movies, value); }
        }

        private static async Task AddMovies()
        {
            var movies = new List<Movie>();

            movies.Add(new Movie { Title = "The Shawshank Redemption", Year = "1994" });
            movies.Add(new Movie { Title = "The Godfather", Year = "1972" });
            movies.Add(new Movie { Title = "The Godfather: Part II", Year = "1974" });
            movies.Add(new Movie { Title = "The Dark Knight", Year = "2008" });
            movies.Add(new Movie { Title = "Schindler's List", Year = "1993" });

            await MoviesService.AddMovies(movies);
        }

        private async Task BindMovies()
        {
            Movies = await MoviesService.GetMovies();
        }
    }
}

