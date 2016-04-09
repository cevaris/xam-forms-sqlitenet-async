using System.Threading.Tasks;
using System.Collections.Generic;
using SqliteAsyncExample.Models;

namespace SqliteAsyncExample.Services
{
    public interface IMoviesService
    {
        Task AddMovies(IList<Movie> movies);

        Task<IList<Movie>> GetMovies();
    }
}

