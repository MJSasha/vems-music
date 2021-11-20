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

        public IEnumerable<MusicalGroup> GetMusicalGroups
        {
            get
            {
                return _dbContext.Groups.ToList();
            }
        }
    }
}
