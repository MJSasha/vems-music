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

        public User GetUserByEmail(string email)
        {
            var user = _dbContext.Users.Where(u=>u.Email == email).ToList();
            foreach (var item in user)
            {
                return item;
            }
            return null;
        }
    }
}
