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

        private IEnumerable<MusicalGroup> GetMusicalGroups
        {
            get
            {
                var groups = _dbContext.Groups.ToList();
                _dbContext.Groups.Include(g => g.Genres).ToList();
                return groups;
            }
        }

        public async Task<IEnumerable<MusicalGroup>> GetAllMusicalGroupsAsync()
        {
            return await Task.Run(() => GetMusicalGroups);
        }
        public async Task<MusicalGroup> GetMusicalGroupByIdAsync(int groupId)
        {
            var group = await _dbContext.FindAsync<MusicalGroup>(groupId);
            _dbContext.Genres.Include(g => g.Musics).ToList();
            return group;
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
            var editableMusicalGroup = _dbContext.Find<MusicalGroup>(musicalGroup.Id);

            editableMusicalGroup.Name = musicalGroup.Name;
            editableMusicalGroup.Description = musicalGroup.Description;
            editableMusicalGroup.Picture = musicalGroup.Picture;

            _dbContext.Groups.Update(editableMusicalGroup);

            if (editableMusicalGroup.Genres == null)
            {
                editableMusicalGroup.Genres = new List<Genre> { newGenre };
            }
            else
            {
                if (editableMusicalGroup.Genres.Contains(newGenre))
                {
                    editableMusicalGroup.Genres.Remove(newGenre);
                }

                editableMusicalGroup.Genres.Add(newGenre);
            }

            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteGroupsGenreAsync(int GroupId, int GenreId)
        {
            var group = await _dbContext.Groups.FindAsync(GroupId);
            var genre = await _dbContext.Genres.FindAsync(GenreId);
            _dbContext.Genres.Include(g => g.MusicalGroups).ToList();
            group.Genres.Remove(genre);
            await _dbContext.SaveChangesAsync();

        }
        public async Task DeleteGroupAsync(int groupId)
        {
            var groupToDelete = await _dbContext.Groups.FindAsync(groupId);
            _dbContext.Musics.Include(m => m.Group).ToList();

            foreach (var item in groupToDelete.Musics)
            {
                _dbContext.Musics.Remove(item);
            }

            _dbContext.Groups.Remove(groupToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
