using Microsoft.EntityFrameworkCore;
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

        public async Task<MusicalGroup> GetMusicalGroupByIdAsync(int id)
        {
            return await _dbContext.FindAsync<MusicalGroup>(id);
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
            _dbContext.Groups.Update(musicalGroup);
            await _dbContext.SaveChangesAsync();
        }
    }
}
