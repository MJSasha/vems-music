﻿using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task AddMusicToUserAsync(int musicId, int userId)
        {
            var user = await _dbContext.FindAsync<User>(userId);
            _dbContext.Musics.Include(m => m.Users).ToList();
            Music music = _dbContext.Find<Music>(musicId);
            if (user.Musics.Contains(music))
            {
                user.Musics.Remove(music);
                user.Musics.Add(music);
            }
            user.Musics.Add(music);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveMusicAsync(int musicId, int userId)
        {
            var user = await _dbContext.FindAsync<User>(userId);
            _dbContext.Musics.Include(m => m.Users).ToList();
            Music music = _dbContext.Find<Music>(musicId);
            user.Musics.Remove(music);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _dbContext.FindAsync<User>(id);
            _dbContext.Musics.Include(m => m.Users).ToList();
            _dbContext.Roles.Include(m => m.Users).ToList();

            return user;
        }
    }
}
