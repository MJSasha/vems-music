using System.Collections.Generic;
using System.Threading.Tasks;
using VemsMusic.Models;

namespace VemsMusic.Interfaces
{
    /// <summary>
    /// Encapsulates all methods related to editing genre information.
    /// </summary>
    public interface IAllGenre
    {
        /// <summary>
        /// Returns all genres from the database.
        /// </summary>
        /// <returns><see cref="IEnumerable{Genre}">IEnumerable&lt;Genre&gt;</see></returns>
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        /// <summary>
        /// Returns the genre with the matching ID. The genre is retrieved from the database.
        /// </summary>
        /// <param name="genreId">The id of the genre to be obtained.</param>
        /// <returns><see cref="Genre"/></returns>
        Task<Genre> GetGenreByIdAsync(int genreId);
        /// <summary>
        /// Writes a new genre to the database.
        /// </summary>
        /// <param name="genre">Genre to add to the database.</param>
        Task AddGenreAsync(Genre genre);
        /// <summary>
        /// Updates the genre in the database.
        /// </summary>
        /// <param name="genre">A new kind of <see cref="Genre"/>.</param>
        Task UpdateGenreAsync(Genre genre);
        /// <summary>
        /// Removes genre from database by id.
        /// </summary>
        /// <param name="genreId">Genre id to be removed from the database.</param>
        Task DeleteGenreAsync(int genreId);
    }
}
