using System.Collections.Generic;
using System.Linq;
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

        public MusicalGroup GetMusicalGroupById(int id)
        {
            return _dbContext.Find<MusicalGroup>(id);
        }

        public IEnumerable<MusicalGroup> GetMusicalGroups
        {
            get
            {
                return _dbContext.Groups.ToList();
            }
        }
        public void DeleteGroup(int id)
        {
            _dbContext.Groups.Remove(_dbContext.Groups.Find(id));
            _dbContext.SaveChanges();
        }

        public void AddGroup(MusicalGroup musicalGroup)
        {
            _dbContext.Groups.Add(musicalGroup);
            _dbContext.SaveChanges();
        }

        public void UpdateGroup(MusicalGroup musicalGroup)
        {
            _dbContext.Groups.Update(musicalGroup);
            _dbContext.SaveChanges();
        }
    }
}
