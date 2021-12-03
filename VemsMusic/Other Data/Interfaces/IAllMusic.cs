using System.Collections.Generic;
using System.Threading.Tasks;
using VemsMusic.Models;

namespace VemsMusic.Other_Data.Interfaces
{
    public interface IAllMusic
    {
        Task<IEnumerable<Music>> GetAllMusicAsync();
        Task DeleteMusicsGenreAsync(int MusicId, int GenreId);
        Task<Music> GetMusicsByIdAsync(int id);
        Task DeleteMusicAsync(int id);
        Task AddMusicAsync(Music music);
        Task UpdateMusicAsync(Music music);
    }
}
