using Xamarin.Forms;
using System.Threading.Tasks;
using SqliteAsyncExample.Models;
using SqliteAsyncExample.Views;

namespace SqliteAsyncExample
{
    public class App : Application
    {
        public App()
        {
            // Drop the DB tables
            DropAllTables();

            // Create the DB tables
            CreateAllTables();

            // The root page of your application
            MainPage = new MoviesPage();
        }

        public void CreateAllTables()
        {
            var db = DependencyService.Get<ISQLite>().GetConnection();

            db.CreateTable<Movie>();
        }

        public async Task CreateAllTablesAsync()
        {
            var db = DependencyService.Get<ISQLite>().GetAsyncConnection();

            await db.CreateTableAsync<Movie>().ConfigureAwait(false);
        }

        /// <summary>
        /// Dropping tables ONLY works using the synchronous DB connection
        /// For some reason, dropping asynchronously fails miserably
        /// </summary>
        public void DropAllTables()
        {
            var db = DependencyService.Get<ISQLite>().GetConnection();

            db.DropTable<Movie>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

