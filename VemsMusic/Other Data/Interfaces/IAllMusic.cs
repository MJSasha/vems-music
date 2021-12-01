using System.Collections.Generic;
using System.Threading.Tasks;
using VemsMusic.Models;

namespace VemsMusic.Other_Data.Interfaces
{
    public interface IAllMusic
    {
        IEnumerable<Music> GetAllMusic { get; }
        Task<Music> GetMusicsByIdAsync(int id);
        Task DeleteMusicAsync(int id);
        Task AddMusicAsync(Music music);
        Task UpdateMusicAsync(Music music);
    }
}
