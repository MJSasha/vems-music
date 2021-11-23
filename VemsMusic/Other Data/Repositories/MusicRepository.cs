using System.Collections.Generic;
using System.Linq;
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

        public async void DeleteMusic(Music music)
        {
            _dbContext.Musics.Remove(music);
            await _dbContext.SaveChangesAsync();
        }

        public async void UpdateMusic(Music music)
        {
            _dbContext.Musics.Update(music);
            await _dbContext.SaveChangesAsync();
        }
    }
}
