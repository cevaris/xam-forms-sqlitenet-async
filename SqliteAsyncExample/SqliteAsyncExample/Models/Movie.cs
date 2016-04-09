using SQLite.Net.Attributes;

namespace SqliteAsyncExample.Models
{
    public class Movie
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Year { get; set; }
    }
}

