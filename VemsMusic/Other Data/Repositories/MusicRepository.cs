using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VemsMusic.Models;
using VemsMusic.Other_Data.Interfaces;

namespace VemsMusic.Other_Data.Repositories
{
    public class MusicRepository : IAllMusic
    {
        private readonly AppDBContext _dbContext;

        public MusicRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public IEnumerable<Music> GetAllMusic
        {
            get
            {
                return _dbContext.Musics.ToList();
            }
        }

        public async Task<Music> GetMusicsByIdAsync(int id)
        {
            return await _dbContext.FindAsync<Music>(id);
        }

        public async Task DeleteMusicAsync(int id)
        {
            _dbContext.Musics.Remove(_dbContext.Musics.Find(id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddMusicAsync(Music music)
        {
            _dbContext.Musics.Add(music);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateMusicAsync(Music music)
        {
            _dbContext.Musics.Update(music);
            await _dbContext.SaveChangesAsync();
        }
    }
}
