using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VemsMusic.Models;
using VemsMusic.Other_Data.Interfaces;
using VemsMusic.Other_Data.PersonalExceptions;
using VemsMusic.Other_Data.ViewModels;

namespace VemsMusic.Other_Data.Repositories
{
    public class UserRepository : IAllUsers
    {
        private readonly AppDBContext _dbContext;

        public UserRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public async Task AddNewUser(User user)
        {
            Role userRole = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Name == "user");
            if (userRole != null)
            {
                user.Role = userRole;
            }

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<User> GetUserByLoginModelAsync(LoginViewModel loginModel)
        {
            User user = await _dbContext.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == loginModel.Email && u.Password == loginModel.Password);
            if (user == null)
            {
                throw new NotFound("User is not found");
            }
            _dbContext.Roles.Include(m => m.Users).ToList();
            return user;
        }
        public async Task<User> GetUserByRegistraterModelAsync(RegisterViewModel registerModel)
        {
            User user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == registerModel.Email);
            if (user == null)
            {
                throw new NotFound("User is not found");
            }
            _dbContext.Roles.Include(m => m.Users).ToList();
            return user;
        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            var user = await _dbContext.FindAsync<User>(userId);
            _dbContext.Musics.Include(m => m.Users).ToList();
            _dbContext.Roles.Include(m => m.Users).ToList();

            return user;
        }
        public async Task AddMusicToUserAsync(int musicId, int userId)
        {
            var user = await _dbContext.FindAsync<User>(userId);
            _dbContext.Musics.Include(m => m.Users).ToList();
            Music music = _dbContext.Find<Music>(musicId);
            if (user.Musics.Contains(music))
            {
                throw new Exception("MusicAlreadyAdded");
            }
            user.Musics.Add(music);
            await _dbContext.SaveChangesAsync();
        }
        public async Task RemoveMusicFromUserAsync(int musicId, int userId)
        {
            var user = await _dbContext.FindAsync<User>(userId);
            _dbContext.Musics.Include(m => m.Users).ToList();
            Music music = _dbContext.Find<Music>(musicId);
            user.Musics.Remove(music);
            await _dbContext.SaveChangesAsync();
        }

    }
}
