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
            var music = _dbContext.Find<Music>(musicId);
            user.Musics.Add(music);
            //music.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public User GetUserById(int id)
        {
            return _dbContext.Find<User>(id);
        }
    }
}
