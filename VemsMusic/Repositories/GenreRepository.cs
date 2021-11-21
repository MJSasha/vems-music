using System.Collections.Generic;
using System.Linq;
using VemsMusic.Interfaces;
using VemsMusic.Models;

namespace VemsMusic.Repositories
{
    public class GenreRepository : IAllGenre
    {
        private readonly AppDBContext _dbContext;

        public GenreRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public IEnumerable<Genre> GetAllGenres
        {
            get
            {
                return _dbContext.Genres.ToList();
            }
        }
    }
}
