using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VemsMusic.Interfaces;
using VemsMusic.Models;

namespace VemsMusic.Repositories
{
    public class GroupsRepository : IAllGroups
    {
        private readonly AppDBContext _dbContext;

        public GroupsRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public IEnumerable<MusicalGroup> GetMusicalGroups
        {
            get
            {
                var groups = _dbContext.Groups.ToList();
                _dbContext.Groups.Include(g => g.Genres).ToList();
                return groups;
            }
        }

        public async Task<IEnumerable<MusicalGroup>> GetMusicalGroupsAsync()
        {
            return await Task.Run(() => GetMusicalGroups);
        }

        public async Task<MusicalGroup> GetMusicalGroupByIdAsync(int id)
        {
            var group = await _dbContext.FindAsync<MusicalGroup>(id);
            _dbContext.Genres.Include(g => g.Musics).ToList();
            return group;
        }

        public async Task DeleteGroupsGenreAsync(int GroupId, int GenreId)
        {
            var group = await _dbContext.Groups.FindAsync(GroupId);
            var genre = await _dbContext.Genres.FindAsync(GenreId);
            _dbContext.Genres.Include(g => g.MusicalGroups).ToList();
            group.Genres.Remove(genre);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteGroupAsync(int id)
        {
            _dbContext.Groups.Remove(_dbContext.Groups.Find(id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddGroupAsync(MusicalGroup musicalGroup)
        {
            _dbContext.Groups.Add(musicalGroup);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateGroupAsync(MusicalGroup musicalGroup)
        {
            var newGenre = _dbContext.Find<Genre>(Convert.ToInt32(musicalGroup.GenreId));
            _dbContext.Genres.Include(g => g.MusicalGroups).ToList();
            musicalGroup = _dbContext.Find<MusicalGroup>(musicalGroup.Id);
            _dbContext.Groups.Update(musicalGroup);

            if (musicalGroup.Genres == null)
            {
                musicalGroup.Genres = new List<Genre> { newGenre };
            }
            else
            {
                if (musicalGroup.Genres.Contains(newGenre))
                {
                    musicalGroup.Genres.Remove(newGenre);
                }

                musicalGroup.Genres.Add(newGenre);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
