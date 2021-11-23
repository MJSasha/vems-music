using System.Collections.Generic;
using VemsMusic.Models;

namespace VemsMusic.Interfaces
{
    public interface IAllGenre
    {
        IEnumerable<Genre> GetAllGenres { get; }
        Genre GetGenreById(int id);
        void DeleteGenre(Genre genre);
        void UpdateGenre(Genre genre);
    }
}
