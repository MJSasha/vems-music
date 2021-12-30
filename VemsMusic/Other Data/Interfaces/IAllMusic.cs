using System.Collections.Generic;
using System.Threading.Tasks;
using VemsMusic.Models;

namespace VemsMusic.Other_Data.Interfaces
{
    /// <summary>
    /// Encapsulates all methods related to editing music information.
    /// </summary>
    public interface IAllMusic
    {
        /// <summary>
        /// Returns all music retrieved from the database.
        /// </summary>
        /// <returns><see cref="IEnumerable{Music}">IEnumerable&lt;Music&gt;</see></returns>
        Task<IEnumerable<Music>> GetAllMusicAsync();
        /// <summary>
        /// Returns the music with the given id, retrieved from the database.
        /// </summary>
        /// <param name="musicId">The id of the music that will be retrieved from the database.</param>
        /// <returns><see cref="Music"/></returns>
        Task<Music> GetMusicsByIdAsync(int musicId);
        /// <summary>
        /// Adds music to the database.
        /// </summary>
        /// <param name="music">Music to add to the database.</param>
        Task AddMusicAsync(Music music);
        /// <summary>
        /// Updates the given music in the database.
        /// </summary>
        /// <param name="music">A new kind of <see cref="Music"/>.</param>
        /// <returns></returns>
        Task UpdateMusicAsync(Music music);
        /// <summary>
        /// Removes the specified genre from the specified music.
        /// </summary>
        /// <param name="MusicId">The ID of the music from which the genre will be deleted.</param>
        /// <param name="GenreId">The id of the genre to be deleted.</param>
        Task DeleteMusicsGenreAsync(int MusicId, int GenreId);
        /// <summary>
        /// Delete music in the database.
        /// </summary>
        /// <param name="musicId">The id of the music to be deleted.</param>
        Task DeleteMusicAsync(int musicId);
    }
}
