using System.Collections.Generic;
using System.Threading.Tasks;
using VemsMusic.Models;

namespace VemsMusic.Interfaces
{
    public interface IAllGenre
    {
        IEnumerable<Genre> GetAllGenres { get; }
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<Genre> GetGenreByIdAsync(int id);
        Task DeleteGenreAsync(int id);
        Task AddGenreAsync(Genre genre);
        Task UpdateGenreAsync(Genre genre);
    }
}
