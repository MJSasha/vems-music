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

        public void DeleteMusic(Music music)
        {
            _dbContext.Musics.Remove(music);
            _dbContext.SaveChanges();
        }

        public void AddMusic(Music music)
        {
            _dbContext.Musics.Add(music);
            _dbContext.SaveChanges();
        }

        public void UpdateMusic(Music music)
        {
            _dbContext.Musics.Update(music);
            _dbContext.SaveChanges();
        }
    }
}
