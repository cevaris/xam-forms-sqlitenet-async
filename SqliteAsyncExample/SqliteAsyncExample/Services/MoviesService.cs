using SqliteAsyncExample.Helpers;
using SQLite.Net.Async;
using System.Threading.Tasks;
using SqliteAsyncExample.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using SqliteAsyncExample.Services;
using System.Linq;

[assembly: Dependency(typeof(MoviesService))]
namespace SqliteAsyncExample.Services
{
    public class MoviesService : IMoviesService
    {
        private static readonly AsyncLock Locker = new AsyncLock();

        private SQLiteAsyncConnection Database { get; } = DependencyService.Get<ISQLite>().GetAsyncConnection();

        public async Task AddMovies(IList<Movie> movies)
        {
            using (await Locker.LockAsync())
            {
                await Database.InsertAllAsync(movies);
            }
        }

        public async Task<IList<Movie>> GetMovies()
        {
            using (await Locker.LockAsync())
            {
                return await Database.Table<Movie>().Where(x => x.Id > 0).ToListAsync();
            }
        }
    }
}

