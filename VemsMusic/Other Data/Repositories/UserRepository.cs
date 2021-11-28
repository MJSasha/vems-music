using Microsoft.EntityFrameworkCore;
using System.Linq;
using VemsMusic.Models;
using VemsMusic.Other_Data.Interfaces;

namespace VemsMusic.Other_Data.Repositories
{
    public class UserRepository : IAllUsers
    {
        private readonly AppDBContext _dbContext;

        public UserRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public void AddMusicToUser(int musicId, int userId)
        {
            var user = _dbContext.Find<User>(userId);
            _dbContext.Musics.Include(m => m.Users).ToList();
            Music music = _dbContext.Find<Music>(musicId);
            if (user.Musics.Contains(music))
            {
                user.Musics.Remove(music);
                user.Musics.Add(music);
            }
            user.Musics.Add(music);
            _dbContext.SaveChanges();
        }

        public void RemoveMusic(int musicId, int userId)
        {
            var user = _dbContext.Find<User>(userId);
            _dbContext.Musics.Include(m => m.Users).ToList();
            Music music = _dbContext.Find<Music>(musicId);
            user.Musics.Remove(music);
            _dbContext.SaveChanges();
        }

        public User GetUserById(int id)
        {
            var user = _dbContext.Find<User>(id);
            _dbContext.Musics.Include(m => m.Users).ToList();

            return user;
        }
    }
}
